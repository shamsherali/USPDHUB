using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;
using AnetApi.Schema;

namespace USPDHUBBLL
{
    public class BusinessBLL
    {
        //Issue No: #203
        //29-01-09
        //Lavanya

        /// <summary>
        /// Validate tab invitations
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="email">email</param>
        /// <returns>DataTable</returns>
        public DataTable Validategtabinvitations(int profileid, string email)
        {
            return BusinessDAL.Validategtabinvitations(profileid, email);
        }

        /// <summary>
        /// Validate aff invitations
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="email">email</param>
        /// <returns>DataTable</returns>
        public DataTable Validateaffinvitations(int profileid, string email)
        {
            return BusinessDAL.Validateaffinvitations(profileid, email);
        }


        //Issue No: #85
        //27-12-08
        //Lavanya
        /// <summary>
        /// Get Reviews by reviewid
        /// </summary>
        /// <param name="reviewid">reviewid</param>
        /// <returns>DataTable</returns>
        public DataTable GetReviewsbyreviewid(int reviewid)
        {
            return BusinessDAL.GetReviewsbyreviewid(reviewid);
        }

        /// <summary>
        /// Get Aff invitation count
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>DataTable</returns>
        public DataTable GetAffinvcount(int userid)
        {
            return BusinessDAL.GetAffinvcount(userid);
        }

        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>DataTable</returns>
        public DataTable ValidateUser(string username, string password)
        {
            return USPDHUBDAL.Consumer.ValidateConsumer(username, password);
        }

        /// <summary>
        /// Get Subscriptions by Type
        /// </summary>
        /// <param name="subtype">subtype</param>
        /// <returns>DataTable</returns>
        public DataTable GetSubscriptionsbyType(int subtype)
        {
            return BusinessDAL.GetSubscriptionsbyType(subtype);
        }

        /// <summary>
        /// Delete Subscription Order by orderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>Int</returns>
        public int DeleteSubscriptionOrder(int orderID)
        {
            return BusinessDAL.DeleteSubscriptionOrder(orderID);
        }

        /// <summary>
        /// Get Order Subscription By ProfileID
        /// </summary>
        /// <param name="profileID">ProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOrderSubscriptionByProfileID(int profileID)
        {
            return BusinessDAL.GetOrderSubscriptionByProfileID(profileID);
        }

        /// <summary>
        /// Add Business User
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
        /// <param name="isFree">isFree</param>
        /// <returns>Int</returns>
        public int AddBusinessUser(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status, Boolean isFree)
        {
            return BusinessDAL.AddBusinessUser(username, password, email, firstname, lastname, pswdQ1, pswdA1, pswdQ2, pswdA2, roleId, isActive, addr1, addr2, city, state, country, zipcode, phone, userid, status, isFree);
        }

        /// <summary>
        /// Get All Main Industry Categories
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllMainIndustryCategories()
        {
            return BusinessDAL.GetAllMainIndustryCategories();
        }

        /// <summary>
        /// Get User Details By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetailsByUserID(int userID)
        {
            return BusinessDAL.GetUserDetailsByUserID(userID);
        }

        /// <summary>
        /// Add Business Profile
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="websitename">websitename</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="categories">categories</param>
        /// <param name="isActive">isActive</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="searchindustries">searchindustries</param>
        /// <param name="searchcities">searchcities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="status">status</param>
        /// <param name="membership">membership</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="verificationtype">verificationtype</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int AddBusinessProfile(string buzname, string websitename, string email, string description, string address1, string address2, string city, string state, string country, string categories, bool isActive, string zipcode, string phone1, string searchindustries, string searchcities, string searchstates, string status, int membership, int userid, int profileid, string verificationtype, int id)
        {
            return BusinessDAL.AddBusinessProfile(buzname, websitename, email, description, address1, address2, city, state, country, categories, isActive, zipcode, phone1, searchindustries, searchcities, searchstates, status, membership, userid, profileid, verificationtype, id);
        }

        /// <summary>
        /// Get Profile Details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileDetailsByProfileID(int profileID)
        {
            return BusinessDAL.GetProfileDetailsByProfileID(profileID);
        }

        /// <summary>
        /// Get Subscription Details By Name
        /// </summary>
        /// <param name="subname">subname</param>
        /// <returns>DataTable</returns>
        public DataTable GetSubscriptionDetailsByName(string subname)
        {
            return BusinessDAL.GetSubscriptionDetailsByName(subname);
        }

        /// <summary>
        /// Get Discount Details By Code
        /// </summary>
        /// <param name="discCode">discCode</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiscountDetailsByCode(string discCode)
        {
            return BusinessDAL.GetDiscountDetailsByCode(discCode);
        }

        /// <summary>
        /// Add Business Profile Order
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subscribeID">subscribeID</param>
        /// <param name="price">price</param>
        /// <param name="ecitiescost">ecitiescost</param>
        /// <param name="einduscost">einduscost</param>
        /// <param name="discCode">discCode</param>
        /// <param name="discamt">discamt</param>
        /// <param name="totalamt">totalamt</param>
        /// <param name="taxamt">taxamt</param>
        /// <param name="billableamt">billableamt</param>
        /// <param name="period">period</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="country">country</param>
        /// <param name="ptype">ptype</param>
        /// <param name="ccnumber">ccnumber</param>
        /// <param name="ccfirstname">ccfirstname</param>
        /// <param name="cclastname">cclastname</param>
        /// <param name="ccmonth">ccmonth</param>
        /// <param name="ccyear">ccyear</param>
        /// <param name="ccvv">ccvv</param>
        /// <param name="cType">cType</param>
        /// <param name="isRecurring">isRecurring</param>
        /// <returns>Int</returns>
        public int AddBusinessProfileOrder(int profileID, int userID, int subscribeID, decimal price, decimal ecitiescost, decimal einduscost, string discCode, decimal discamt, decimal totalamt, decimal taxamt, decimal billableamt, int period, string startdate, string enddate, string address1, string address2, string city, string state, string zipcode, string country, string ptype, string ccnumber, string ccfirstname, string cclastname, int ccmonth, int ccyear, string ccvv, string cType, bool isRecurring)
        {
            return BusinessDAL.AddBusinessProfileOrder(profileID, userID, subscribeID, price, ecitiescost, einduscost, discCode, discamt, totalamt, taxamt, billableamt, period, startdate, enddate, address1, address2, city, state, zipcode, country, ptype, ccnumber, ccfirstname, cclastname, ccmonth, ccyear, ccvv, cType, isRecurring);
        }

        /// <summary>
        /// Update Business Profile Status
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="isActive">isActive</param>
        /// <param name="strresponse">strresponse</param>
        /// <returns>Int</returns>
        public int UpdateBusinessProfileStatus(int orderID, int profileID, int userID, bool isActive, string strresponse)
        {
            return BusinessDAL.UpdateBusinessProfileStatus(orderID, profileID, userID, isActive, strresponse);
        }

        /// <summary>
        /// Get Profile Order By orderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileOrderByID(int orderID)
        {
            return BusinessDAL.GetProfileOrderByID(orderID);
        }

        /// <summary>
        /// Cancel Business Registraion By orderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>Int</returns>
        public int CancelBusinessRegistraionByID(int orderID)
        {
            return BusinessDAL.CancelBusinessRegistraionByID(orderID);
        }

        /// <summary>
        /// Get Business Profile By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessProfileByUserID(int userID)
        {
            return BusinessDAL.GetBusinessProfileByUserID(userID);
        }

        /// <summary>
        /// Get Business Links
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessLinks(bool top5Flag, int profileID)
        {
            return BusinessDAL.GetBusinessLinks(top5Flag, profileID);
        }

        /// <summary>
        /// Get Business Affiliates
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessAffiliates(bool top5Flag, int profileID)
        {
            return BusinessDAL.GetBusinessAffiliates(top5Flag, profileID);
        }

        /// <summary>
        /// Get Business Name By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>String</returns>
        public string GetBusinessNameByProfileID(int profileID)
        {
            return BusinessDAL.GetBusinessNameByProfileID(profileID);
        }

        /// <summary>
        /// Update Business Profile Details
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="description">description</param>
        /// <param name="contactname">contactname</param>
        /// <param name="bdays">bdays</param>
        /// <param name="bhours">bhours</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="extection">extection</param>
        /// <param name="fax">fax</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int UpdateBusinessProfileDetails(string buzname, string description, string contactname, string bdays, string bhours, string address1, string address2, string city, string state, string zipcode, string phone1, string extection, string fax, int userid, int profileid)
        {
            return BusinessDAL.UpdateBusinessProfileDetails(buzname, description, contactname, bdays, bhours, address1, address2, city, state, zipcode, phone1, extection, fax, userid, profileid);
        }

        /// <summary>
        /// Update Business Profile Logo
        /// </summary>
        /// <param name="logopath">logopath</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdateBusinessProfileLogo(string logopath, int profileID, int userID, int id)
        {
            return BusinessDAL.UpdateBusinessProfileLogo(logopath, profileID, userID, id);
        }

        /// <summary>
        /// Manage Business Profile Photos
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="photoname">photoname</param>
        /// <param name="photonum">photonum</param>
        /// <param name="imagepath">imagepath</param>
        /// <param name="primeflag">primeflag</param>
        /// <param name="isactive">isactive</param>
        /// <param name="userID">userID</param>
        /// <param name="photoIDval">photoIDval</param>
        /// <param name="tType">tType</param>
        /// <param name="imgdesc">imgdesc</param>
        /// <param name="imageOrderNo">imageOrderNo</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ManageBusinessProfilePhotos(int profileID, string photoname, int photonum, string imagepath, bool primeflag, bool isactive, int userID, int photoIDval, int tType, string imgdesc, decimal imageOrderNo, int id)
        {
            return BusinessDAL.ManageBusinessProfilePhotos(profileID, photoname, photonum, imagepath, primeflag, isactive, userID, photoIDval, tType, imgdesc, imageOrderNo, id);
        }

        /// <summary>
        /// Manage Business Profile Videos
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="videoname">videoname</param>
        /// <param name="videopath">videopath</param>
        /// <param name="videotype">videotype</param>
        /// <param name="primeflag">primeflag</param>
        /// <param name="isactive">isactive</param>
        /// <param name="userID">userID</param>
        /// <param name="videoID">videoID</param>
        /// <param name="tType">tType</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ManageBusinessProfileVideos(int profileID, string videoname, string videopath, string videotype, bool primeflag, bool isactive, int userID, int videoID, int tType, int id)
        {
            return BusinessDAL.ManageBusinessProfileVideos(profileID, videoname, videopath, videotype, primeflag, isactive, userID, videoID, tType, id);
        }

        /// <summary>
        /// Get Profile Photos By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfilePhotosByProfileID(int profileID, int galleryOrder = 1)
        {
            return BusinessDAL.GetProfilePhotosByProfileID(profileID, galleryOrder);
        }

        /// <summary>
        /// Get Profile Videos By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileVideosByProfileID(int profileID)
        {
            return BusinessDAL.GetProfileVideosByProfileID(profileID);
        }

        /// <summary>
        /// Update Primary Business Profile Photo
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="photonum">photonum</param>
        /// <param name="primeflag">primeflag</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int UpdatePrimaryBusinessProfilePhoto(int profileID, int photonum, bool primeflag, int userID)
        {
            return BusinessDAL.UpdatePrimaryBusinessProfilePhoto(profileID, photonum, primeflag, userID);
        }

        /// <summary>
        /// Get ProfileID By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int GetProfileIDByUserID(int userID)
        {
            return BusinessDAL.GetProfileIDByUserID(userID);
        }

        /// <summary>
        /// Get Profile Messages
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileMessages(bool top5Flag, int profileID)
        {
            return BusinessDAL.GetProfileMessages(top5Flag, profileID);
        }

        /// <summary>
        /// Get Message Details By msgID
        /// </summary>
        /// <param name="msgID">msgID</param>
        /// <returns>DataTable</returns>
        public DataTable GetMessageDetailsByID(int msgID)
        {
            return BusinessDAL.GetMessageDetailsByID(msgID);
        }

        /// <summary>
        /// Manage Business Message
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
        public int ManageBusinessMessage(int toid, int totypeID, int fromID, string subject, string message, int replyid, bool activeflag, int msgID, int userID, int tType, int id)
        {
            return BusinessDAL.ManageBusinessMessage(toid, totypeID, fromID, subject, message, replyid, activeflag, msgID, userID, tType, id);
        }

        /// <summary>
        /// Get Profile Sent Messages
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileSentMessages(bool top5Flag, int profileID)
        {
            return BusinessDAL.GetProfileSentMessages(top5Flag, profileID);
        }

        /// <summary>
        /// Update Business Read Message
        /// </summary>
        /// <param name="totypeID">totypeID</param>
        /// <param name="msgID">msgID</param>
        /// <returns>Int</returns>
        public int UpdateBusinessReadMessage(int totypeID, int msgID)
        {
            return BusinessDAL.UpdateBusinessReadMessage(totypeID, msgID);
        }

        /// <summary>
        /// Get Profile Statistics by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileStatistics(int profileID)
        {
            return BusinessDAL.GetProfileStatistics(profileID);
        }

        /// <summary>
        /// Update Profile Statistics
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="iPaddress">iPaddress</param>
        /// <param name="addlvalue">addlvalue</param>
        /// <returns>Int</returns>
        public int UpdateProfileStatistics(int profileID, string iPaddress, string addlvalue)
        {
            return BusinessDAL.UpdateProfileStatistics(profileID, iPaddress, addlvalue);
        }

        /// <summary>
        /// Get Aff Invitations by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAffInvitationsbyID(int profileID)
        {
            return BusinessDAL.GetAffInvitationsbyID(profileID);
        }

        /// <summary>
        /// Get Aff Invitation Details by InvitationID
        /// </summary>
        /// <param name="invID">invID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAffInvDetailsbyInvitationID(int invID)
        {
            return BusinessDAL.GetAffInvDetailsbyInvitationID(invID);
        }

        /// <summary>
        /// Add Affiliate Invitation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="sendto">sendto</param>
        /// <param name="buzname">buzname</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="memberID">memberID</param>
        /// <param name="userID">userID</param>
        /// <param name="guID">guID</param>
        /// <returns>Int</returns>
        public int AddAffiliateInvitation(int profileID, string sendto, string buzname, string subject, string message, int memberID, int userID, string guID)
        {
            return BusinessDAL.AddAffiliateInvitation(profileID, sendto, buzname, subject, message, memberID, userID, guID);
        }

        /// <summary>
        /// Delete Affiliate Invitation by inviteID
        /// </summary>
        /// <param name="inviteID">inviteID</param>
        /// <returns>Int</returns>
        public int DeleteAffiliateInvitation(int inviteID)
        {
            return BusinessDAL.DeleteAffiliateInvitation(inviteID);
        }
        /// <summary>
        /// Get Tip Of the Week By TipID
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTipOftheWeekByTipID(int tipID)
        {
            return BusinessDAL.GetTipOftheWeekByTipID(tipID);
        }
        /// <summary>
        /// Get All Tip Of the Weeks by ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllTipOftheWeeks(int profileID)
        {
            return BusinessDAL.GetAllTipOftheWeeks(profileID);
        }
        /// <summary>
        /// Add New Tip OF The Week
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <param name="tipName">tipName</param>
        /// <param name="tipCategory">tipCategory</param>
        /// <param name="tipDescription">tipDescription</param>
        /// <param name="tipbroughtBy">tipbroughtBy</param>
        /// <param name="isActive">isActive</param>
        /// <param name="username">username</param>
        /// <returns>Int</returns>
        public int AddNewTip(int tipID, string tipName, string tipCategory, string tipDescription, int tipbroughtBy, bool isActive, string username)
        {
            return BusinessDAL.AddNewTip(tipID, tipName, tipCategory, tipDescription, tipbroughtBy, isActive, username);
        }
        /// <summary>
        /// Delete Tip By TipID
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <returns>Int</returns>
        public int DeleteTip(int tipID)
        {
            return BusinessDAL.DeleteTip(tipID);
        }
        /// <summary>
        ///  Fill Bessiness Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillBussinessData()
        {
            return BusinessDAL.FillBussinessData();
        }

        /// <summary>
        /// Bussiness Link Name Search
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <returns>DataTable</returns>
        public DataTable BussinessLinkNameSearch(string searchText)
        {
            return BusinessDAL.BussinessLinkNameSearch(searchText);
        }
        /// <summary>
        /// Get Business Deatils By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessDeatilsByUserID(int userID)
        {
            return BusinessDAL.GetBusinessDetailsByUserID(userID);
        }
        /// <summary>
        /// Insert BLink Data With ProfileID
        /// </summary>
        /// <param name="blinkName">blinkName</param>
        /// <param name="blinkUrl">blinkUrl</param>
        /// <param name="profileID">profileID</param>
        /// <param name="username">username</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <returns>Int</returns>
        public int InsertBLinkDataWithProfileID(string blinkName, string blinkUrl, int profileID, string username, bool activeFlag)
        {
            return BusinessDAL.InsertBLinkDataWithProfileID(blinkName, blinkUrl, profileID, username, activeFlag);
        }

        /// <summary>
        /// Get Favorites Links by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFavoritesLinks(int profileID)
        {
            return BusinessDAL.GetFavoritesLinks(profileID);
        }

        /// <summary>
        /// Get Profile Reviews by profileid
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileReviews(int profileid)
        {
            return BusinessDAL.GetReviewProfile(profileid);
        }

        /// <summary>
        /// Get Invoice Details by userID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInvoiceDetails(int userID)
        {
            return BusinessDAL.GetDetailInvoice(userID);
        }
        public DataTable GetInvoiceDetail_New(int profileID)
        {
            return BusinessDAL.GetInvoiceDetail_New(profileID);
        }
        /// <summary>
        /// Get OrderID Invoice by orderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOrderIDInvoice(int orderID)
        {
            return BusinessDAL.GetDetailInvoicebyOrderID(orderID);
        }
        public DataTable GetInvoiceDetailsBySubTypeID(int subscriptionTypeID)
        {
            return BusinessDAL.GetInvoiceDetailsBySubTypeID(subscriptionTypeID);
        }

        /// <summary>
        /// Add Affilicate Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="affilicateID">affilicateID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="affguid">affguid</param>
        /// <returns>Int</returns>
        public int AddAffilicateDetails(int userID, int affilicateID, int profileID, string affguid)
        {
            return BusinessDAL.InsertAffilicateDetails(userID, affilicateID, profileID, affguid);
        }
        /// <summary>
        /// Update Affiliate Accept flag
        /// </summary>
        /// <param name="affguid">affguid</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int UpdateAffiliateAcceptflag(string affguid, int profileID)
        {
            return BusinessDAL.UpdateAffiliateAcceptFlag(affguid, profileID);

        }

        /// <summary>
        /// Get Receive ProfileID By InvitationID
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Int</returns>
        public int GetReceiveProfileIDByInvitationID(int invitationID)
        {
            return BusinessDAL.GetReceiveProfileIDByInvitationID(invitationID);

        }

        /// <summary>
        /// Select Affiliate Details by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable SelectAffiliateDetails(int profileID)
        {
            return BusinessDAL.GetAffiliateDetails(profileID);
        }

        /// <summary>
        /// Add Affiliate Invitation User
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="websitename">websitename</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="categories">categories</param>
        /// <param name="isActive">isActive</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="searchindustries">searchindustries</param>
        /// <param name="searchcities">searchcities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="status">status</param>
        /// <param name="membership">membership</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="affProfileID">affProfileID</param>
        /// <param name="leadCode">leadCode</param>
        /// <returns>Int</returns>
        public int AddAffiliateInvitationUser(string buzname, string websitename, string email, string description, string address1, string address2, string city, string state, string country, string categories, bool isActive, string zipcode, string phone1, string searchindustries, string searchcities, string searchstates, string status, int membership, int userid, int profileid, int affProfileID, string leadCode)
        {
            return BusinessDAL.InsertAfflicateInvitationRecord(buzname, websitename, email, description, address1, address2, city, state, country, categories, isActive, zipcode, phone1, searchindustries, searchcities, searchstates, status, membership, userid, profileid, affProfileID, leadCode);
        }

        /// <summary>
        /// Insert Profile Setting
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="addressflag">addressflag</param>
        /// <param name="cityflag">cityflag</param>
        /// <param name="stateflag">stateflag</param>
        /// <param name="zipflag">zipflag</param>
        /// <param name="contactflag">contactflag</param>
        /// <param name="faxflag">faxflag</param>
        /// <param name="reviewflag">reviewflag</param>
        /// <param name="joinmailinglistflag">joinmailinglistflag</param>
        /// <param name="generaltabflag">generaltabflag</param>
        /// <param name="tabname">tabname</param>
        /// <param name="settingsid">settingsid</param>
        /// <param name="addlDesc">addlDesc</param>
        /// <param name="businessdays">businessdays</param>
        /// <param name="bgmPlayerEnabled">bgmPlayerEnabled</param>
        /// <param name="bgMusicPalyOnOff">bgMusicPalyOnOff</param>
        /// <param name="eventCal">eventCal</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int InsertProfileSetting(int profileid, bool addressflag, bool cityflag, bool stateflag, bool zipflag, bool contactflag, bool faxflag, bool reviewflag, bool joinmailinglistflag, bool generaltabflag, string tabname, int settingsid, bool addlDesc, bool businessdays, bool bgmPlayerEnabled, bool bgMusicPalyOnOff, bool eventCal, int id)
        {
            return BusinessDAL.InsertProfileSetting(profileid, addressflag, cityflag, stateflag, zipflag, contactflag, faxflag, reviewflag, joinmailinglistflag, generaltabflag, tabname, settingsid, addlDesc, businessdays, bgmPlayerEnabled, bgMusicPalyOnOff, eventCal, id);
        }

        /// <summary>
        /// Get Profile Settings By profileID
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileSettingsByprofileID(int profileid)
        {
            return BusinessDAL.GetProfileSettingsByprofileID(profileid);
        }

        /// <summary>
        /// Get ProfileID to Authenticate Affilicate User
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileIDtoAuthenticateAffilicateUser(string emailID)
        {
            return BusinessDAL.GetAuthenticateUserProfileID(emailID);
        }

        /// <summary>
        /// Get Profile Affiliate Count by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int GetProfileAffiliateCount(int profileID)
        {
            return BusinessDAL.GetAffiliateCountprofile(profileID);
        }

        /// <summary>
        /// Get Profile Category 
        /// </summary>
        /// <param name="industryName">industryName</param>
        /// <returns>String</returns>
        public string GetProfileCategory(string industryName)
        {
            return BusinessDAL.GetProfileCategory(industryName);
        }

        /// <summary>
        /// Add Business Profile Order1
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subscribeID">subscribeID</param>
        /// <param name="price">price</param>
        /// <param name="ecitiescost">ecitiescost</param>
        /// <param name="einduscost">einduscost</param>
        /// <param name="discCode">discCode</param>
        /// <param name="discamt">discamt</param>
        /// <param name="totalamt">totalamt</param>
        /// <param name="taxamt">taxamt</param>
        /// <param name="billableamt">billableamt</param>
        /// <param name="period">period</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="country">country</param>
        /// <param name="ptype">ptype</param>
        /// <param name="ccnumber">ccnumber</param>
        /// <param name="ccname">ccname</param>
        /// <param name="ccmonth">ccmonth</param>
        /// <param name="ccyear">ccyear</param>
        /// <param name="flag">flag</param>
        /// <returns>Int</returns>
        public int AddBusinessProfileOrder1(int profileID, int userID, int subscribeID, decimal price, decimal ecitiescost, decimal einduscost, string discCode, decimal discamt, decimal totalamt, decimal taxamt, decimal billableamt, int period, string startdate, string enddate, string address1, string address2, string city, string state, string zipcode, string country, string ptype, string ccnumber, string ccname, string ccmonth, string ccyear, Boolean flag)
        {
            return BusinessDAL.AddBusinessProfileOrder1(profileID, userID, subscribeID, price, ecitiescost, einduscost, discCode, discamt, totalamt, taxamt, billableamt, period, startdate, enddate, address1, address2, city, state, zipcode, country, ptype, ccnumber, ccname, ccmonth, ccyear, flag);
        }

        /// <summary>
        /// Get Profile Details By ProfileID1
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileDetailsByProfileID1(int profileID)
        {
            return BusinessDAL.GetProfileDetailsByProfileID1(profileID);
        }

        /// <summary>
        /// Verify Affiliate Details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="affiliateID">affiliateID</param>
        /// <returns>Int</returns>
        public int VerifyAffiliateDetailsByProfileID(int profileID, int affiliateID)
        {
            return BusinessDAL.VerifyAffiliateDetailsByProfileID(profileID, affiliateID);
        }

        /// <summary>
        /// Get ProfileID By UserID1
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileIDByUserID1(int userID)
        {
            return BusinessDAL.GetProfileIDByUserID1(userID);
        }

        /// <summary>
        /// Activate User Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="flag">flag</param>
        public void ActivateUserDetails(int userID, Boolean flag)
        {
            BusinessDAL.ActivateUserDetails(userID, flag);
        }

        //General Tab
        /// <summary>
        /// Get General tab Invitations by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetGeneraltabInvitationsbyID(int profileID)
        {
            return BusinessDAL.GetGeneraltabInvitationsbyID(profileID);
        }

        /// <summary>
        /// Add General tab Invitation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="sendto">sendto</param>
        /// <param name="buzname">buzname</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="memberID">memberID</param>
        /// <param name="userID">userID</param>
        /// <param name="guID">guID</param>
        /// <returns>Int</returns>
        public int AddGeneraltabInvitation(int profileID, string sendto, string buzname, string subject, string message, int memberID, int userID, string guID)
        {
            return BusinessDAL.AddGeneraltabInvitation(profileID, sendto, buzname, subject, message, memberID, userID, guID);
        }

        /// <summary>
        /// Delete General tab Invitation by inviteID
        /// </summary>
        /// <param name="inviteID">inviteID</param>
        /// <returns>Int</returns>
        public int DeleteGeneraltabInvitation(int inviteID)
        {
            return BusinessDAL.DeleteGeneraltabInvitation(inviteID);
        }


        /// <summary>
        /// Add General tab Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="generaltabID">generaltabID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="uniqueID">uniqueID</param>
        /// <returns>Int</returns>
        public int AddGeneraltabDetails(int userID, int generaltabID, int profileID, string uniqueID)
        {
            return BusinessDAL.InsertGeneraltabDetails(userID, generaltabID, profileID, uniqueID);
        }

        /// <summary>
        /// Select General tab Details by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable SelectGeneraltabDetails(int profileID)
        {
            return BusinessDAL.GetGeneraltabDetails(profileID);
        }

        /// <summary>
        /// Add General tab Invitation User
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="websitename">websitename</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="categories">categories</param>
        /// <param name="isActive">isActive</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="searchindustries">searchindustries</param>
        /// <param name="searchcities">searchcities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="status">status</param>
        /// <param name="membership">membership</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="generaltabProfileID">generaltabProfileID</param>
        /// <param name="uniqueID1">uniqueID1</param>
        /// <param name="leadcode">leadcode</param>
        /// <returns>Int</returns>
        public int AddGeneraltabInvitationUser(string buzname, string websitename, string email, string description, string address1, string address2, string city, string state, string country, string categories, bool isActive, string zipcode, string phone1, string searchindustries, string searchcities, string searchstates, string status, int membership, int userid, int profileid, int generaltabProfileID, string uniqueID1, string leadcode)
        {
            return BusinessDAL.InsertGeneraltabInvitationRecord(buzname, websitename, email, description, address1, address2, city, state, country, categories, isActive, zipcode, phone1, searchindustries, searchcities, searchstates, status, membership, userid, profileid, generaltabProfileID, uniqueID1, leadcode);
        }

        /// <summary>
        /// Verify General tab Details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="generaltabID">generaltabID</param>
        /// <returns>Int</returns>
        public int VerifyGeneraltabDetailsByProfileID(int profileID, int generaltabID)
        {
            return BusinessDAL.VerifyGeneraltabDetailsByProfileID(profileID, generaltabID);
        }

        /// <summary>
        /// Check Buiness Name
        /// </summary>
        /// <param name="profileCode">profileCode</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int CheckBuinessName(string profileCode, int profileID)
        {
            return BusinessDAL.CheckBuinessName(profileCode, profileID);
        }

        /// <summary>
        /// Get ProfileID By InvitationID
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Int</returns>
        public int GetProfileIDByInvitationID(int invitationID)
        {
            return BusinessDAL.GetProfileIDByInvitationID(invitationID);

        }

        /// <summary>
        /// Update Buiness Name
        /// </summary>
        /// <param name="profileCode">profileCode</param>
        /// <param name="profileID">profileID</param>
        /// <param name="id">id</param>
        public void UpdateBuinessName(string profileCode, int profileID, int id)
        {
            BusinessDAL.UpdateBuinessName(profileCode, profileID, id);
        }

        /// <summary>
        /// Get State Code For State Name
        /// </summary>
        /// <param name="stateName">stateName</param>
        /// <returns>String</returns>
        public string GetStateCodeForStateName(string stateName)
        {
            return BusinessDAL.GetStateCodeForState(stateName);
        }

        /// <summary>
        /// Update Accept flag in general tab
        /// </summary>
        /// <param name="gtabuniqueID">gtabuniqueID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int UpdateAcceptflagingeneraltab(string gtabuniqueID, int profileID)
        {
            return BusinessDAL.UpdateAcceptflagingeneraltab(gtabuniqueID, profileID);

        }
        //Html Convert Methods
        /// <summary>
        /// Get All Business Categories
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllBusiness_Categories()
        {
            return BusinessDAL.GetAllBusiness_Categories();
        }

        /// <summary>
        /// Get All Business Subcategory
        /// </summary>
        /// <param name="categoryName">categoryName</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllBusiness_Subcategory(string categoryName)
        {
            return BusinessDAL.GetAllBusiness_Subcategory(categoryName);
        }

        /// <summary>
        /// Get All Business Profiles
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllBusinessProfiles()
        {
            return BusinessDAL.GetAllBusinessProfiles();
        }

        /// <summary>
        /// Get Category name For CategoryID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>String</returns>
        public string GetCategorynameForCategoryID(int id)
        {
            return BusinessDAL.GetCategorynameForCategoryID(id);
        }

        /// <summary>
        /// Get Category ID For Category Name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>DataTable</returns>
        public DataTable GetCategoryIDForCategoryName(string name)
        {
            return BusinessDAL.GetCategoryIDForCategoryName(name);
        }

        /// <summary>
        /// Delete alert by alertID
        /// </summary>
        /// <param name="alertID">alertID</param>
        /// <returns>Int</returns>
        public int Deletealert(int alertID)
        {
            return BusinessDAL.Deletealert(alertID);
        }

        /// <summary>
        /// Get Alert By AlertID
        /// </summary>
        /// <param name="alertid">alertid</param>
        /// <returns>DataTable</returns>
        public DataTable GetAlertByAlertID(int alertid)
        {
            return BusinessDAL.GetAlertByAlertID(alertid);
        }
        // Start of issue 823
        /// <summary>
        /// Update Cities And Industries
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="industries">industries</param>
        /// <param name="industryNames">industryNames</param>
        public void UpdateCitiesAndIndustries(int profileID, int userID, string industries, string industryNames)
        {
            BusinessDAL.UpdateCitiesAndIndustries(profileID, userID, industries, industryNames);
        }

        /// <summary>
        /// Update Cities And Industries with different parameters
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="cities">cities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="searchcityState">searchcityState</param>
        /// <param name="zipcodes">zipcodes</param>
        public void UpdateCitiesAndIndustries(int profileID, int userID, string cities, string searchstates, string searchcityState, string zipcodes)
        {
            BusinessDAL.UpdateCitiesAndIndustries(profileID, userID, cities, searchstates, searchcityState, zipcodes);
        }
        // End of issue 823
        //New Registraion flow Methods
        /// <summary>
        /// Insert User Activation Code
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="userActivationCode">userActivationCode</param>
        public void InsertUserActivationCode(int userID, string userActivationCode)
        {
            BusinessDAL.InsertUserActivationCode(userID, userActivationCode);
        }

        /// <summary>
        /// Check User Activation Code by userActivationCode
        /// </summary>
        /// <param name="userActivationCode">userActivationCode</param>
        /// <returns>Boolean</returns>
        public Boolean CheckUserActivationCode(string userActivationCode)
        {
            return BusinessDAL.CheckUserActivationCode(userActivationCode);
        }

        /// <summary>
        /// Get User Activation code by userName
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns>String</returns>
        public string GetUserActivationcode(string userName)
        {
            return BusinessDAL.GetUserActivationcode(userName);
        }

        /// <summary>
        /// Enable User Flag by activationCode
        /// </summary>
        /// <param name="activationCode">activationCode</param>
        public void EnableUserFlag(string activationCode)
        {
            BusinessDAL.EnableUserFlag(activationCode);
        }

        /// <summary>
        /// Check User Activation Code For Activate Profile by userActivationCode
        /// </summary>
        /// <param name="userActivationCode">userActivationCode</param>
        /// <returns>Int</returns>
        public int CheckUserActivationCodeForActivateProfile(string userActivationCode)
        {
            return BusinessDAL.CheckUserActivationCodeForActivateProfile(userActivationCode);
        }

        /// <summary>
        /// Check UserName and Password For Vaild User
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>Int</returns>
        public int CheckUserNameandPasswordForVaildUser(string username, string vertical, string country)
        {
            return BusinessDAL.CheckUserNameandPasswordForVaildUser(username, vertical, country);
        }

        /// <summary>
        /// Get count from refer a friend by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int Getcountfromreferafriend(int profileID)
        {
            return BusinessDAL.Getcountfromreferafriend(profileID);

        }

        /// <summary>
        /// Get User Details By User Activation Code
        /// </summary>
        /// <param name="activationCode">activationCode</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetailsByUserActivationCode(string activationCode)
        {
            return BusinessDAL.GetUserDetailsByUserActivationCode(activationCode);
        }
        // Start of Issue 823 
        /// <summary>
        /// Update Database and Update Cities And Industries
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="cities">cities</param>
        /// <param name="states">states</param>
        /// <param name="zipcodes">zipcodes</param>
        /// <param name="cityStates">cityStates</param>
        public void UpdateDBUpdateCitiesAndIndustries(int profileID, int userID, string cities, string states, string zipcodes, string cityStates)
        {
            BusinessDAL.UpdateDBUpdateCitiesAndIndustries(profileID, userID, cities, states, zipcodes, cityStates);
        }

        /// <summary>
        /// Update Database and Update Cities And Industries
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="industries">industries</param>
        /// <param name="industryNames">industryNames</param>
        public void UpdateDBUpdateCitiesAndIndustries(int profileID, int userID, string industries, string industryNames)
        {
            BusinessDAL.UpdateDBUpdateCitiesAndIndustries(profileID, userID, industries, industryNames);
        }
        // End of Issue 823

        /// <summary>
        /// Check User Activation Code For Registration
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>String</returns>
        public string CheckUserActivationCodeForRegistration(int userid)
        {
            return BusinessDAL.CheckUserActivationCodeForRegistration(userid);
        }

        /// <summary>
        /// Add Business User1
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
        /// <param name="forumUserName">forumUserName</param>
        /// <returns>Int</returns>
        public int AddBusinessUser1(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status, string forumUserName)
        {
            return BusinessDAL.AddBusinessUser1(username, password, email, firstname, lastname, pswdQ1, pswdA1, pswdQ2, pswdA2, roleId, isActive, addr1, addr2, city, state, country, zipcode, phone, userid, status, forumUserName);
        }

        /// <summary>
        /// Get UserName And Paswword For UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserNameAndPaswwordForUserID(int userID)
        {
            return BusinessDAL.GetUserNameAndPaswwordForUserID(userID);
        }

        /// <summary>
        /// Get all business users
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable Getallbusinessusers()
        {
            return BusinessDAL.Getallbusinessusers();

        }
        //Admin Alerts dated 17th October 2008
        /// <summary>
        /// Get orderid by userid
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>DataTable</returns>
        public DataTable Getorderidbyuserid(int userid)
        {
            return BusinessDAL.Getorderidbyuserid(userid);
        }

        /// <summary>
        /// Get test user Deatils By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GettestuserDeatilsByUserID(int userID)
        {
            return BusinessDAL.GettestuserDetailsByUserID(userID);
        }
        //Business Payment On October 17 th
        /// <summary>
        /// Update User Profile Order
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="price">price</param>
        /// <param name="billAmount">billAmount</param>
        /// <param name="citiesAmount">citiesAmount</param>
        /// <param name="industriesamount">industriesamount</param>
        public void UpdateUserProfileOrder(int orderID, string startDate, string enddate, decimal price, decimal billAmount, decimal citiesAmount, decimal industriesamount)
        {
            BusinessDAL.UpdateUserProfileOrder(orderID, startDate, enddate, price, billAmount, citiesAmount, industriesamount);
        }

        /// <summary>
        /// Update Profile Order In Reg
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="subscriptionAmount">subscriptionAmount</param>
        /// <param name="discountamt">discountamt</param>
        /// <param name="billableamt">billableamt</param>
        public void UpdateProfileOrderInReg(int profileID, decimal subscriptionAmount, decimal discountamt, decimal billableamt)
        {
            BusinessDAL.UpdateProfileOrderInReg(profileID, subscriptionAmount, discountamt, billableamt);
        }

        /// <summary>
        /// Get Latest profiles
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetLatestprofiles()
        {
            return BusinessDAL.GetLatestprofiles();
        }

        /// <summary>
        /// Get top Review
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GettopReview()
        {
            return BusinessDAL.GettopReview();
        }
        //New Profile Related Classes
        /// <summary>
        /// Get Top 3 Review Profile by profileid 
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>DataTable</returns>
        public DataTable GetTop3ReviewProfile(int profileid)
        {
            return BusinessDAL.GetTop3ReviewProfile(profileid);
        }

        /// <summary>
        /// Get active coupons count by profileid
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int Getactivecouponscount(int profileid)
        {
            return BusinessDAL.Getactivecouponscount(profileid);
        }

        /// <summary>
        /// Get agents count by profileid
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int Getagentscount(int profileid)
        {
            return BusinessDAL.Getagentscount(profileid);
        }

        /// <summary>
        /// Get affiliates count by profileid
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int Getaffiliatescount(int profileid)
        {
            return BusinessDAL.Getaffiliatescount(profileid);
        }

        /// <summary>
        /// Get top 3 Affiliates by profileid
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>DataTable</returns>
        public DataTable Gettop3Affiliates(int profileid)
        {
            return BusinessDAL.Gettop3Affiliates(profileid);
        }

        /// <summary>
        /// Get user details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetuserdetailsByProfileID(int profileID)
        {
            return BusinessDAL.GetuserdetailsByProfileID(profileID);
        }

        /// <summary>
        /// Get profile description by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable Getprofiledescription(int profileID)
        {
            return BusinessDAL.Getprofiledescription(profileID);
        }

        /// <summary>
        /// Update profile description
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="businessDuration">businessDuration</param>
        /// <param name="noOfEmp">noOfEmp</param>
        /// <param name="localMemberships">localMemberships</param>
        /// <param name="businessDescription">businessDescription</param>
        /// <param name="productDescription">productDescription</param>
        /// <param name="iD">iD</param>
        /// <returns>Int</returns>
        public int Updateprofiledescription(int profileid, string businessDuration, int noOfEmp, string localMemberships, string businessDescription, string productDescription, int iD)
        {
            return BusinessDAL.Updateprofiledescription(profileid, businessDuration, noOfEmp, localMemberships, businessDescription, productDescription, iD);
        }

        //User Tracking Code
        /// <summary>
        /// User tracking
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="ipadress">ipadress</param>
        /// <param name="logintime">logintime</param>
        /// <param name="logouttime">logouttime</param>
        /// <param name="logindate">logindate</param>
        /// <param name="logoutdate">logoutdate</param>
        /// <param name="status">status</param>
        /// <param name="browser">browser</param>
        /// <param name="browserVersion">browserVersion</param>
        /// <returns>Int</returns>
        public int Usertracking(int userid, string ipadress, string logintime, string logouttime, string logindate, string logoutdate, int status, string browser, string browserVersion)
        {
            return BusinessDAL.Usertracking(userid, ipadress, logintime, logouttime, logindate, logoutdate, status, browser, browserVersion);
        }
        //get lastlogindateandtime
        /// <summary>
        /// Get Last Login By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetLastLoginByUserID(int userID)
        {
            return BusinessDAL.GetLastLoginByUserID(userID);
        }

        //get Tip by TipID
        /// <summary>
        /// Get Tip By TipID
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTipByTipID(int tipID)
        {
            return BusinessDAL.GetTipByTipID(tipID);
        }

        /// <summary>
        /// Get Total ProfileTips Count
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int GetTipsCountbyProfileID(int profileID)
        {
            return BusinessDAL.GetTipsCountbyProfileID(profileID);
        }
        //delete Affilaites by Lavanaya
        /// <summary>
        /// Delete Received affiliate
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="afffiliateid">afffiliateid</param>
        /// <returns>Int</returns>
        public int DeleteReceivedaffiliate(int profileid, int afffiliateid)
        {
            return BusinessDAL.DeleteReceivedaffiliate(profileid, afffiliateid);
        }

        /// <summary>
        /// Get received Aff Invitations by profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetreceivedAffInvitationsbyID(int profileID)
        {
            return BusinessDAL.GetreceivedAffInvitationsbyID(profileID);
        }
        //------- Add User Contacts
        /// <summary>
        /// Add User Contact Details
        /// </summary>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="email">email</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="mobile">mobile</param>
        /// <param name="fax">fax</param>
        /// <param name="sourcetype">sourcetype</param>
        /// <param name="userid">userid</param>
        /// <param name="importdate">importdate</param>
        /// <param name="contactgroupname">contactgroupname</param>
        /// <param name="companyname">companyname</param>
        /// <param name="id">id</param>
        public void AddUserContactDetails(string firstname, string lastname, string email, string address, string city, string state, string zipcode, string phone, string mobile, string fax, string sourcetype, int userid, DateTime importdate, string contactgroupname, string companyname, int id)
        {
            BusinessDAL.AddBusinessContacts(firstname, lastname, email, address, city, state, zipcode, phone, mobile, fax, sourcetype, userid, importdate, contactgroupname, companyname, id);
        }

        /// <summary>
        /// Update Business User Contacts
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="email">email</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="mobile">mobile</param>
        /// <param name="fax">fax</param>
        /// <param name="contactgroupname">contactgroupname</param>
        /// <param name="companyname">companyname</param>
        /// <param name="id">id</param>
        public void UpdateBusinessUserContacts(int contactID, string firstname, string lastname, string email, string address, string city, string state, string zipcode, string phone, string mobile, string fax, string contactgroupname, string companyname, int id)
        {
            BusinessDAL.UpdateBusinessContacts(contactID, firstname, lastname, email, address, city, state, zipcode, phone, mobile, fax, contactgroupname, companyname, id);
        }

        /// <summary>
        /// Delete User Contact by contactID
        /// </summary>
        /// <param name="contactID">contactID</param>
        public void DeleteUserContact(int contactID)
        {
            BusinessDAL.DeleteBuinessContact(contactID);
        }

        /// <summary>
        /// Get All User Contacts by UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <param name="selectType">selectType</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllUserContactsbyUserID(int userID, int checkFlag, string selectType)
        {
            return BusinessDAL.GetAllUserContacts(userID, checkFlag, selectType);
        }

        /// <summary>
        /// Get All User Contacts by UserID by Type
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <param name="selectType">selectType</param>
        /// <param name="isPrivateModule">isPrivateModule</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllUserContactsbyUserIDbyType(int userID, int checkFlag, string selectType, bool isPrivateModule)
        {
            return BusinessDAL.GetAllUserContactsbyType(userID, checkFlag, selectType, isPrivateModule);
        }

        /// <summary>
        /// Get User Contact Details by ContactID
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactDetailsbyContactID(int contactID)
        {
            return BusinessDAL.GetUserContactDetails(contactID);
        }

        /// <summary>
        /// Get User Contact Details by Group Name
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactDetailsbyGroupName(string groupName, int userID)
        {
            return BusinessDAL.GetUserContactDetailsbyGroupName(groupName, userID);
        }

        /// <summary>
        /// Insert User Contact Usage
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="affiliateUsage">affiliateUsage</param>
        /// <param name="generalTabUsage">generalTabUsage</param>
        /// <param name="couponUsage">couponUsage</param>
        /// <param name="messageUsage">messageUsage</param>
        /// <param name="emailUsage">emailUsage</param>
        /// <param name="newsletterUsage">newsletterUsage</param>
        /// <param name="businessUpdateUsage">businessUpdateUsage</param>
        /// <param name="usageDate">usageDate</param>
        /// <param name="iD">iD</param>
        public void InsertUserContactUsage(int userID, int profileID, int affiliateUsage, int generalTabUsage, int couponUsage, int messageUsage, int emailUsage, int newsletterUsage, int businessUpdateUsage, DateTime usageDate, int iD)
        {
            BusinessDAL.InsertUserContactUsage(userID, profileID, affiliateUsage, generalTabUsage, couponUsage, messageUsage, emailUsage, newsletterUsage, businessUpdateUsage, usageDate, iD);
        }

        /// <summary>
        /// Update User Contact Usage
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="affiliateUsage">affiliateUsage</param>
        /// <param name="generalTabUsage">generalTabUsage</param>
        /// <param name="couponUsage">couponUsage</param>
        /// <param name="messageUsage">messageUsage</param>
        /// <param name="emailUsage">emailUsage</param>
        /// <param name="newsletterUsage">newsletterUsage</param>
        /// <param name="businessUpdateUsage">businessUpdateUsage</param>
        /// <param name="usageDate">usageDate</param>
        /// <param name="iD">iD</param>
        public void UpdateUserContactUsage(int userID, int affiliateUsage, int generalTabUsage, int couponUsage, int messageUsage, int emailUsage, int newsletterUsage, int businessUpdateUsage, DateTime usageDate, int iD)
        {
            BusinessDAL.UpdateUserContactUsage(userID, affiliateUsage, generalTabUsage, couponUsage, messageUsage, emailUsage, newsletterUsage, businessUpdateUsage, usageDate, iD);
        }

        /// <summary>
        /// Get User Contact Details Usage
        /// </summary>
        /// <param name="usageDate">usageDate</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactDetailsUsage(DateTime usageDate, int userID)
        {
            return BusinessDAL.GetUserContactDetailsUsage(usageDate, userID);
        }
        /// <summary>
        /// Check User Contact Validation
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="email">email</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckUserContactValidation(string groupName, string email, int userID)
        {
            return BusinessDAL.CheckUserContactValidation(groupName, email, userID);
        }
        //------- End User Contacts
        /// <summary>
        /// Insert Contact Group Name
        /// </summary>
        /// <param name="contactGroupID">contactGroupID</param>
        /// <param name="contactGroupname">contactGroupname</param>
        /// <param name="userID">userID</param>
        /// <param name="dateCreated">dateCreated</param>
        /// <param name="dateModified">dateModified</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="discription">discription</param>
        /// <param name="iD">iD</param>
        /// <param name="pGroupType">pGroupType</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pIsSystemGroup">pIsSystemGroup</param>
        /// <param name="pIsMasterGroup">pIsMasterGroup</param>
        public void InsertContactGroupName(int contactGroupID, string contactGroupname, int userID, DateTime dateCreated, DateTime dateModified,
            Boolean activeFlag, string discription, int iD, string pGroupType, int pUserModuleID, bool pIsSystemGroup, bool pIsMasterGroup)
        {
            BusinessDAL.InsertContactGroupName(contactGroupID, contactGroupname, userID, dateCreated, dateModified, activeFlag,
                discription, iD, pGroupType, pUserModuleID, pIsSystemGroup, pIsMasterGroup);
        }

        /// <summary>
        /// Update Contact Group Name
        /// </summary>
        /// <param name="contactGroupname">contactGroupname</param>
        /// <param name="contactGroupID">contactGroupID</param>
        /// <param name="dateModified">dateModified</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="discription">discription</param>
        /// <param name="iD">iD</param>
        public void UpdateContactGroupName(string contactGroupname, int contactGroupID, DateTime dateModified, Boolean activeFlag, string discription, int iD)
        {
            BusinessDAL.UpdateContactGroupName(contactGroupname, contactGroupID, dateModified, activeFlag, discription, iD);
        }

        /// <summary>
        /// Get User Contact Group Names
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactGroupNames(int userID)
        {
            return BusinessDAL.GetUserContactGroupNames(userID);
        }

        /// <summary>
        /// Check User Listing Validation
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckUserListingValidation(string groupName, int userID)
        {
            return BusinessDAL.CheckUserListingValidation(groupName, userID);
        }

        /// <summary>
        /// Get User Contact Group Details By GroupID
        /// </summary>
        /// <param name="cid">cid</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactGroupDetailsByGroupID(int cid)
        {
            return BusinessDAL.GetUserContactGroupByGroupID(cid);
        }
        /// <summary>
        /// To Get Latest  sent invitation  by profile_id 
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="username">username</param>
        /// <returns>DataTable</returns>
        public DataTable Getnewaffiliateinvitation(int profileId, string username)
        {
            return BusinessDAL.Getnewaffiliateinvitation(profileId, username);
        }
        /// <summary>
        /// Delete Affiliate Invitation
        /// </summary>
        /// <param name="uniqueID">uniqueID</param>
        public void DeleteAffiliateInvitation(string uniqueID)
        {
            BusinessDAL.DeleteAffiliateInvitation(uniqueID);
        }
        /// <summary>
        /// Adding ResellerCode
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="resellerCode">resellerCode</param>
        /// <param name="dateCreated">dateCreated</param>
        public void InsertResellerCode(int profileID, int userID, string resellerCode, DateTime dateCreated)
        {
            BusinessDAL.InsertResellerCode(profileID, userID, resellerCode, dateCreated);
        }

        /// <summary>
        /// Get Reseller Code for ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetResellerCodeforProfileID(int profileID)
        {
            return BusinessDAL.GetResellerCodeforProfileID(profileID);
        }
        // End of ResellerCode
        //Issue  No : 253 
        //Pallavi
        //25-feb-2009
        /// <summary>
        /// Get Replied Message Count By MsgID
        /// </summary>
        /// <param name="msgID">msgID</param>
        /// <returns>Int</returns>
        public int GetRepliedMessageCountByMsgID(int msgID)
        {
            return BusinessDAL.GetRepliedMessageCountByMsgID(msgID);
        }
        //End of Issue 253
        //-------------------  Reseller Track Code
        /// <summary>
        /// Insert Reseller Track
        /// </summary>
        /// <param name="clientIPAddress">clientIPAddress</param>
        /// <param name="sessionID">sessionID</param>
        /// <param name="trackingCode">trackingCode</param>
        /// <param name="dateCreated">dateCreated</param>
        public void InsertResellerTrack(string clientIPAddress, string sessionID, string trackingCode, DateTime dateCreated)
        {
            BusinessDAL.InsertResellerTrack(clientIPAddress, sessionID, trackingCode, dateCreated);
        }
        //------------------- End of Reseller Track code
        /// <summary>
        /// Delete User Contact Group
        /// </summary>
        /// <param name="groupID">groupID</param>
        /// <param name="contactGroupID">contactGroupID</param>
        /// <param name="userID">userID</param>
        public void DeleteUserContactGroup(int groupID, string contactGroupID, int userID)
        {
            BusinessDAL.DeleteUserContactGroup(groupID, contactGroupID, userID);
        }
        // End
        // ----------------- BuyAddons Transaction----------
        // Start of Issue 823
        /// <summary>
        /// Insert Buy Content Module Transaction
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="cities">cities</param>
        /// <param name="state">state</param>
        /// <param name="categories">categories</param>
        /// <param name="categorieIds">categorieIds</param>
        /// <param name="userid">userid</param>
        /// <param name="createdDate">createdDate</param>
        /// <param name="profileID">profileID</param>
        /// <param name="cityAmount">cityAmount</param>
        /// <param name="cityPrice">cityPrice</param>
        /// <param name="industryAmount">industryAmount</param>
        /// <param name="industryPrice">industryPrice</param>
        /// <param name="cityCount">cityCount</param>
        /// <param name="industryCount">industryCount</param>
        /// <param name="searchcityState">searchcityState</param>
        /// <param name="zipcodes">zipcodes</param>
        /// <returns>Int</returns>
        public int InsertBuyAddonsTraans(int orderID, string cities, string state, string categories, string categorieIds, int userid, DateTime createdDate, int profileID, int cityAmount, string cityPrice, int industryAmount, string industryPrice, int cityCount, int industryCount, string searchcityState, string zipcodes)
        {
            return BusinessDAL.InsertBuyAddonsTraans(orderID, cities, state, categories, categorieIds, userid, createdDate, profileID, cityAmount, cityPrice, industryAmount, industryPrice, cityCount, industryCount, searchcityState, zipcodes);
        }
        // End of Issue 823

        /// <summary>
        /// Get Buy Content Module Transaction
        /// </summary>
        /// <param name="orderno">orderno</param>
        /// <returns>DataTable</returns>
        public DataTable GetBuyAdddonsTransaction(int orderno)
        {
            return BusinessDAL.GetBuyAdddonsTransaction(orderno);
        }
        //-------------------End---------------------------

        /// <summary>
        /// Get zipcodes by city and state
        /// </summary>
        /// <param name="cityname">cityname</param>
        /// <param name="statename">statename</param>
        /// <returns>DataTable</returns>
        public DataTable Getzipcodesbycityandstate(string cityname, string statename)
        {
            return BusinessDAL.Getzipcodesbycityandstate(cityname, statename);
        }

        /// <summary>
        /// Get users for search update
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable Getusersforsearchupdate()
        {
            return BusinessDAL.Getusersforsearchupdate();
        }

        /// <summary>
        /// Update city,state and zipcodes
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="states">states</param>
        /// <param name="citystates">citystates</param>
        /// <param name="zipcodes">zipcodes</param>
        public void Updatecitystateandzipcodes(int userid, string states, string citystates, string zipcodes)
        {
            BusinessDAL.Updatecitystateandzipcodes(userid, states, citystates, zipcodes);
        }

        /// <summary>
        /// Get Buy Content Module Transaction by OrderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBuyAddonsTransactionbyOrderID(int orderID)
        {
            return BusinessDAL.GetBuyAddonsTransactionbyOrderID(orderID);
        }

        /// <summary>
        /// Get Profileid To Update Calendar details
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetProfileidToUpdateCalendardetails()
        {
            return BusinessDAL.GetProfileidToUpdateCalendardetails();
        }

        /// <summary>
        /// Insert Email Message
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="toEmails">toEmails</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="sentDate">sentDate</param>
        /// <param name="attachment">attachment</param>
        /// <returns>Int</returns>
        public int InsertEmailMessage(int userID, int profileID, string toEmails, string subject, string message, DateTime sentDate, string attachment)
        {
            return BusinessDAL.InsertEmailMessage(userID, profileID, toEmails, subject, message, sentDate, attachment);
        }

        /// <summary>
        /// Delete Email Message By EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        public void DeleteEmailMessageBYEmailID(int emailID)
        {
            BusinessDAL.DeleteEmailMessageBYEmailID(emailID);
        }

        /// <summary>
        /// Get Email Message by UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEmailMessagebyUserID(int userID)
        {
            return BusinessDAL.GetEmailMessagebyUserID(userID);
        }

        /// <summary>
        /// Get Email Message by EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEmailMessagebyEmailID(int emailID)
        {
            return BusinessDAL.GetEmailMessagebyEmailID(emailID);
        }

        /// <summary>
        /// Get User Details by user email
        /// </summary>
        /// <param name="useremail">useremail</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetailsbyuseremail(string useremail)
        {
            return BusinessDAL.GetUserDetailsbyuseremail(useremail);
        }
        //--------------------Start Update OnlineBusiness Account---------------------
        /// <summary>
        /// Update User Online Business Account
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="enabled">enabled</param>
        public void UpdateUserOnlineBusinessAccount(int profileID, Boolean enabled)
        {
            BusinessDAL.UpdateUserOnlineBusinessAccount(profileID, enabled);
        }

        //--------------------End Update OnlineBusiness Account---------------------


        //----------------- Start URL Submitter Functionality------------------
        /// <summary>
        /// Insert Submit Engine Details
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="name">name</param>
        /// <param name="url">url</param>
        /// <param name="logopath">logopath</param>
        /// <param name="pagerank">pagerank</param>
        /// <param name="status">status</param>
        public void InsertSubmitEngineDetails(int category, string name, string url, string logopath, int pagerank, Boolean status)
        {
            BusinessDAL.InsertSubmitEngineDetails(category, name, url, logopath, pagerank, status);
        }

        /// <summary>
        /// Insert Submit status
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="engineId">engineId</param>
        /// <param name="status">status</param>
        /// <param name="address">address</param>
        /// <param name="phone">phone</param>
        /// <param name="profilename">profilename</param>
        /// <param name="profileurl">profileurl</param>
        /// <param name="servicekeywords">servicekeywords</param>
        /// <param name="uniqueurl">uniqueurl</param>
        /// <param name="iD">iD</param>
        public void InsertSubmitstatus(int profileid, int engineId, string status, string address, string phone, string profilename, string profileurl, string servicekeywords, string uniqueurl, int iD)
        {
            BusinessDAL.InsertSubmitstatus(profileid, engineId, status, address, phone, profilename, profileurl, servicekeywords, uniqueurl, iD);
        }

        /// <summary>
        /// Get Submit engine details
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSubmitenginedetails()
        {
            return BusinessDAL.GetSubmitenginedetails();
        }

        /// <summary>
        /// Get Submit directories
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSubmitdirectories()
        {
            return BusinessDAL.GetSubmitdirectories();
        }

        //--------------------------------GetUrlSubmissionReport------------------------------
        /// <summary>
        /// Get User Url Submisssion Report
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserUrlSubmisssionReport(int profileID)
        {
            return BusinessDAL.GetUserUrlSubmisssionReport(profileID);
        }
        /// <summary>
        /// Get User Url Submisssion Details By EngineID
        /// </summary>
        /// <param name="engineID">engineID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserUrlSubmisssionDetailsByEngineID(int engineID)
        {
            return BusinessDAL.GetUserUrlSubmisssionDetailsByEngineID(engineID);
        }

        //--------------------------------GetUrlSubmissionReport------------------------------


        //----------------- End URL Submitter Functionality------------------


        //---------------Email Scheduling----------------------------------------
        /// <summary>
        /// Insert Email Schedule History
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="contactsCount">contactsCount</param>
        /// <param name="emailsCount">emailsCount</param>
        /// <param name="emailsTableID">emailsTableID</param>
        /// <param name="sendFlag">sendFlag</param>
        /// <param name="createddate">createddate</param>
        /// <param name="modifiedDate">modifiedDate</param>
        /// <returns>Int</returns>
        public int InsertEmailScheduleHistory(int profileID, int userID, int contactsCount, int emailsCount, int emailsTableID, int sendFlag, DateTime createddate, DateTime modifiedDate)
        {
            return BusinessDAL.InsertEmailScheduleHistory(profileID, userID, contactsCount, emailsCount, emailsTableID, sendFlag, createddate, modifiedDate);
        }

        /// <summary>
        /// Insert Scheduled Email
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subject">subject</param>
        /// <param name="emails">emails</param>
        /// <param name="messages">messages</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <param name="isAttachment">isAttachment</param>
        /// <param name="attachment">attachment</param>
        /// <param name="schHisID">schHisID</param>
        /// <param name="emailsTableID">emailsTableID</param>
        /// <param name="schduleDate">schduleDate</param>
        /// <param name="iD">iD</param>
        public void InsertScheduledEmail(int profileID, int userID, string subject, string emails, string messages, DateTime sendingDate, int sentFlag, Boolean isAttachment, string attachment, int schHisID, int emailsTableID, DateTime schduleDate, int iD)
        {
            BusinessDAL.InsertScheduledEmail(profileID, userID, subject, emails, messages, sendingDate, sentFlag, isAttachment, attachment, schHisID, emailsTableID, schduleDate, iD);
        }

        /// <summary>
        /// Get Scheduled Email Count
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int GetSchEmailCount(int userID)
        {
            return BusinessDAL.GetSchEmailCount(userID);
        }

        /// <summary>
        /// Get Campaign Email Count
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>Int</returns>
        public int GetCampaignEmailCount(int emailID)
        {
            return BusinessDAL.GetCampaignEmailCount(emailID);
        }

        /// <summary>
        /// Get Campaign Email Details
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCampaignEmailDetails(int emailID)
        {
            return BusinessDAL.GetCampaignEmailDetails(emailID);
        }

        /// <summary>
        /// Get Schedule Email Count for Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="schID">schID</param>
        /// <returns>Int</returns>
        public int GetSchduleEmailCountforDate(int userID, DateTime sendingDate, int schID)
        {
            return BusinessDAL.GetSchduleEmailCountforDate(userID, sendingDate, schID);
        }

        /// <summary>
        /// Cancel Email Campaign
        /// </summary>
        /// <param name="schduleID">schduleID</param>
        public void CancelEmailCampaign(int schduleID)
        {
            BusinessDAL.CancelEmailCampaign(schduleID);
        }

        /// <summary>
        /// Update Email Usage By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="usageDate">usageDate</param>
        public void UpdateEmailUsageByUserID(int userID, DateTime usageDate)
        {
            BusinessDAL.UpdateEmailUsageByUserID(userID, usageDate);
        }

        /// <summary>
        /// Get Max Scheduled Date for Email
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>String</returns>
        public string GetMaxSchDateforEmail(int profileID)
        {
            return BusinessDAL.GetMaxSchDateforEmail(profileID);
        }

        /// <summary>
        /// Get Email Sent History
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEmailSentHistory(int emailID, int profileID)
        {
            return BusinessDAL.GetEmailSentHistory(emailID, profileID);
        }

        /// <summary>
        /// Get Email Scheduled Count for EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int GetEmailScheuleCountforEmailID(int emailID, int profileID)
        {
            return BusinessDAL.GetEmailScheuleCountforEmailID(emailID, profileID);
        }




        //---------------Email Scheduling----------------------------------------


        //-------------- Check For Reaseller DiscountAmount-----------------------
        /// <summary>
        /// Get Reseller Discount Amount
        /// </summary>
        /// <param name="resellerCode">resellerCode</param>
        /// <returns>decimal</returns>
        public decimal GetResellerDiscountAmount(string resellerCode)
        {
            return BusinessDAL.GetResellerDiscountAmount(resellerCode);
        }

        //-------------- Check For Reaseller DiscountAmount-----------------------

        //-------------- Check For Email ID for Default Group -----------------------
        /// <summary>
        /// Check EmailID For Default Group
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckEmailIDForDefaultGroup(string emailID, int userID)
        {
            return BusinessDAL.CheckEmailIDForDefaultGroup(emailID, userID);
        }
        /// <summary>
        /// Check For Email Opt Flag Count
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckForEmailOptFlagCount(string emailID, int userID)
        {
            return BusinessDAL.CheckForEmailOptFlagCount(emailID, userID);
        }

        /// <summary>
        /// UnSubscribe User Emails
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        public void UnSubscribeUserEmails(string emailID, int userID)
        {
            BusinessDAL.UnSubscribeUserEmails(emailID, userID);
        }

        /// <summary>
        /// Subscribe User Emails
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        public void SubscribeUserEmails(string emailID, int userID)
        {
            BusinessDAL.SubscribeUserEmails(emailID, userID);
        }

        /// <summary>
        /// Add UnGrouped Contacts Group
        /// </summary>
        /// <param name="userID">userID</param>
        public void AddUnGroupedContactsGroup(int userID)
        {
            BusinessDAL.AddUnGroupedContactsGroup(userID);
        }

        /// <summary>
        /// Check For Ungrouped Contacts Group
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckForUngroupedContactsGroup(int userID)
        {
            return BusinessDAL.CheckForUngroupedContactsGroup(userID);
        }
        //-------------- Check For Email ID for Default Group -----------------------

        /// <summary>
        /// Get Pending Invitations by ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPendingInvitationsbyProfileID(int profileID)
        {
            return BusinessDAL.GetPendingInvitationsbyProfileID(profileID);
        }

        /// <summary>
        /// Delete Affiliate
        /// </summary>
        /// <param name="profileAffiliateID">profileAffiliateID</param>
        /// <returns>Int</returns>
        public int DeleteAffiliate(int profileAffiliateID)
        {
            return BusinessDAL.DeleteAffiliate(profileAffiliateID);
        }

        //********** New Affiliates Status ***************/
        /// <summary>
        /// Get New Affiliates Count
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int GetNewAffiliatesCount(int profileID)
        {
            return BusinessDAL.GetNewAffiliatesCount(profileID);
        }

        /// <summary>
        /// Update New Affiliate Status
        /// </summary>
        /// <param name="profileID">profileID</param>
        public void UpdateNewAffiliateStatus(int profileID)
        {
            BusinessDAL.UpdateNewAffiliateStatus(profileID);
        }
        //************************************************//

        //*********** Update Second URL **************//
        /// <summary>
        /// Update Profile Second Url
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="profileSecondUrl">profileSecondUrl</param>
        /// <param name="iD">iD</param>
        public void UpdateProfileSecondUrl(int profileID, string profileSecondUrl, int iD)
        {
            BusinessDAL.UpdateProfileSecondUrl(profileID, profileSecondUrl, iD);
        }
        //*********** Update Second URL **************//
        /// <summary>
        /// Get General Tab Invitation Details By InvitationID
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>DataTable</returns>
        public DataTable GetGeneralTabInvitationDetailsByInvitationID(int invitationID)
        {
            return BusinessDAL.GetGeneralTabInvitationDetailsByInvitationID(invitationID);
        }

        /*********************** Monthly subscription Changes ********/
        /// <summary>
        /// Update Subscription Type in Users table
        /// </summary>
        /// <param name="subscriptionType">subscriptionType</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int UpdateSubscriptionTypeinUserstable(int subscriptionType, int userID)
        {
            return BusinessDAL.UpdateSubscriptionTypeinUserstable(subscriptionType, userID);
        }
        /// <summary>
        /// Update Profile Order details
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="enddate">enddate</param>
        /// <param name="subscriptionPeriod">subscriptionPeriod</param>
        /// <returns>Int</returns>
        public int UpdateProfileOrderdetails(int orderID, string enddate, int subscriptionPeriod)
        {
            return BusinessDAL.UpdateProfileOrderdetails(orderID, enddate, subscriptionPeriod);
        }
        /*********************** End Monthly subscription Changes ********/

        /**********************  Email Tracking Report  ***************/
        /// <summary>
        /// Insert Email Tracking Histroy
        /// </summary>
        /// <param name="schID">schID</param>
        /// <param name="schHisID">schHisID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="emailID">emailID</param>
        /// <param name="address">address</param>
        /// <param name="browserType">browserType</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="viewCount">viewCount</param>
        /// <param name="ipAddress">ipAddress</param>
        public void InsertEmailTrackingHistroy(int schID, int schHisID, int profileID, string emailID, string address, string browserType, string latitude, string longitude, int viewCount, string ipAddress)
        {
            BusinessDAL.InsertEmailTrackingHistroy(schID, schHisID, profileID, emailID, address, browserType, latitude, longitude, viewCount, ipAddress);
        }

        /// <summary>
        /// Update Email Track View Count
        /// </summary>
        /// <param name="schID">schID</param>
        /// <param name="viewCount">viewCount</param>
        public void UpdateEmailTrackViewCount(int schID, int viewCount)
        {
            BusinessDAL.UpdateEmailTrackViewCount(schID, viewCount);
        }

        /// <summary>
        /// Get Email Receiver Track Report
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEmailReceiverTrackRreport(int schID)
        {
            return BusinessDAL.GetEmailReceiverTrackRreport(schID);
        }

        /// <summary>
        /// Get Top Schedule EmailID for Email Track
        /// </summary>
        /// <returns>Int</returns>
        public int GetTopScheduleEmailIDforEmailTrack()
        {
            return BusinessDAL.GetTopScheduleEmailIDforEmailTrack();
        }
        /// <summary>
        /// Get Email Schduled Details by ScheduledID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEmailSchduleDetailsbySchduleID(int schID)
        {
            return BusinessDAL.GetEmailSchduleDetailsbySchduleID(schID);
        }

        /// <summary>
        /// Get Tracked Email Count For Scheduled ID
        /// </summary>
        /// <param name="schHisID">schHisID</param>
        /// <returns>Int</returns>
        public int GetTrackedEmailCountForSchHisID(int schHisID)
        {
            return BusinessDAL.GetTrackedEmailCountForSchHisID(schHisID);
        }

        /// <summary>
        /// Update Email Tracking Opt out
        /// </summary>
        /// <param name="schID">schID</param>
        public void UpdateEmailTrackingOptout(int schID)
        {
            BusinessDAL.UpdateEmailTrackingOptout(schID);
        }

        /// <summary>
        /// Get Email Track Opt Out Flag Count
        /// </summary>
        /// <param name="schHisID">schHisID</param>
        /// <returns>Int</returns>
        public int GetEmailTrackOptOutFlagCount(string schHisID)
        {
            return BusinessDAL.GetEmailTrackOptOutFlagCount(schHisID);
        }

        /// <summary>
        /// Get Affiliate by ProfileAffiliateID
        /// </summary>
        /// <param name="profileAffiliateID">profileAffiliateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAffiliatebyProfile_Affiliate_ID(int profileAffiliateID)
        {
            return BusinessDAL.GetAffiliatebyProfile_Affiliate_ID(profileAffiliateID);
        }

        /// <summary>
        /// Get Affiliate Invitation by Profile And Receive profileIDs
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="receiveProfileID">receiveProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAffInvbyProfileAndReceiveprofileIDs(int profileID, int receiveProfileID)
        {
            return BusinessDAL.GetAffInvbyProfileAndReceiveprofileIDs(profileID, receiveProfileID);
        }
        /// <summary>
        /// Delete Affiliate Invitation by InvitationID
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Int</returns>
        public int DeleteAffInvbyInvitationID(int invitationID)
        {
            return BusinessDAL.DeleteAffInvbyInvitationID(invitationID);
        }
        /// <summary>
        /// Update new site Invitation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="streetaddress">streetaddress</param>
        /// <param name="businessdesc">businessdesc</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdatenewsiteIntiation(int profileID, string streetaddress, string businessdesc, string city, string state, string country, string zipcode, double platitude1, double plongitude1, int id)
        {
            return BusinessDAL.UpdatenewsiteIntiation(profileID, streetaddress, businessdesc, city, state, country, zipcode, platitude1, plongitude1, id);
        }

        /// <summary>
        /// Get new General tab invitation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userName">userName</param>
        /// <returns>DataTable</returns>
        public DataTable GetnewGeneraltabinvitation(int profileID, string userName)
        {
            return BusinessDAL.GetnewGeneraltabinvitation(profileID, userName);
        }

        //------------ Business UpdateModule -------------------------------------------

        /// <summary>
        /// Get User Contact Details by UserID And Email
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactDetailsbyUserIDAndEmail(int userID, string emailAddress)
        {
            return BusinessDAL.GetUserContactDetailsbyUserIDAndEmail(userID, emailAddress);
        }

        //------------ Business UpdateModule -------------------------------------------

        //------------Confirmation Message Box------------------------------------------
        /// <summary>
        /// Get Email Scheduled History Count
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>Int</returns>
        public int GetEmailSheduledHistoryCount(int emailID)
        {
            return BusinessDAL.GetEmailSheduledHistoryCount(emailID);
        }
        //------------Confirmation Message Box------------------------------------------

        // Start Issue 554
        /// <summary>
        /// Update Status Flag
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="flag">flag</param>
        public void UpdateStatusFlag(int orderID, int flag)
        {
            BusinessDAL.UpdateStatusFlag(orderID, flag);
        }
        /// <summary>
        /// Get Orderid Details by Userid
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>DataTable</returns>
        public DataTable GetOrderidDetailsbyUserid(int userid)
        {
            return BusinessDAL.GetOrderidDetailsbyUserid(userid);
        }
        // End Issue 554

        //Start ISSUE 557
        /// <summary>
        /// Get Top 1 Profile Photos By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTop1ProfilePhotosByProfileID(int profileID)
        {
            return BusinessDAL.GetTop1ProfilePhotosByProfileID(profileID);
        }

        // End ISSUE 557

        /// <summary>
        ///  Unsubscribe Email Blast Opt Outs
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="schID">schID</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <returns>Int</returns>
        public int UnsubscrineEmailBlastEamils(int userID, int schID, string emailAddress)
        {
            return BusinessDAL.UnsubscrineEmailBlastEamils(userID, schID, emailAddress);
        }

        /// <summary>
        /// Get Opt Out Count For EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptOutCountForEmailID(int emailID)
        {
            return BusinessDAL.GetOptOutCountForEmailID(emailID);
        }

        /// <summary>
        /// Add User Default Contact Groups
        /// </summary>
        /// <param name="userID">userID</param>
        public void AddUserDefaultContactGroups(int userID)
        {
            BusinessDAL.AddUserDefaultContactGroups(userID);
        }

        // End

        /// <summary>
        ///  Update User Free Flag
        /// </summary>
        /// <param name="userID">userID</param>
        public void UpdateUserFreeFlag(int userID)
        {
            BusinessDAL.UpdateUserFreeFlag(userID);
        }
        /// <summary>
        /// Get Opt out Contacts
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptoutContacts(int userID, int checkFlag)
        {
            return BusinessDAL.GetOptoutContacts(userID, checkFlag);
        }

        /// <summary>
        /// Insert and Delete Opt Contact
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="contactID">contactID</param>
        /// <param name="cEmail">cEmail</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="group">group</param>
        public void InsertandDeleteOptContact(int profileID, int userID, int contactID, string cEmail, string firstname, string lastname, string group)
        {
            BusinessDAL.InsertandDeleteOptContact(profileID, userID, contactID, cEmail, firstname, lastname, group);
        }

        /// <summary>
        /// Get Contact Group Name
        /// </summary>
        /// <param name="groupID">groupID</param>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public string GetContactGroupName(int groupID, int userID)
        {
            return BusinessDAL.GetContactGroupName(groupID, userID);

        }

        /// <summary>
        /// To Get Profile Template For User
        /// </summary>
        /// <param name="templateName">templateName</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileTemplateForTemplatename(string templateName)
        {
            return BusinessDAL.GetProfileTemplateForTemplatename(templateName);
        }

        // End

        #region Business days and time settings
        // To fix Issue 621
        /// <summary>
        /// Get Business Days and Timings
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessDaysandTimings(int profileID)
        {
            return BusinessDAL.GetBusinessDaysandTimings(profileID);
        }

        /// <summary>
        /// Manage Business Days and Times
        /// </summary>
        /// <param name="dayval">dayval</param>
        /// <param name="userID">userID</param>
        /// <param name="starttime">starttime</param>
        /// <param name="endtime">endtime</param>
        /// <param name="profileID">profileID</param>
        /// <param name="ttype">ttype</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="calendarID">calendarID</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ManageBusinessDaysandTimes(string dayval, int userID, string starttime, string endtime, int profileID, int ttype, bool activeFlag, int calendarID, int id)
        {
            return BusinessDAL.ManageBusinessDaysandTimes(dayval, userID, starttime, endtime, profileID, ttype, activeFlag, 0, id);
        }

        #endregion

        /// <summary>
        /// Get Max Contact Group ID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int GetMaximunContactGroupIDForUserID(int userID)
        {
            return BusinessDAL.GetMaximunContactGroupIDForUserID(userID);
        }

        /// <summary>
        /// Update Photo Description by PhotoID
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <param name="photodesc">photodesc</param>
        /// <param name="profileid">profileid</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdatePhotoDescbyPhotoID(int photoID, string photodesc, int profileid, int id)
        {
            return BusinessDAL.UpdatePhotoDescbyPhotoID(photoID, photodesc, profileid, id);
        }
        //Balaji 20-06-2012 For FOr Image Order Number
        /// <summary>
        /// Update Image Order Number
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <param name="imgorderno">imgorderno</param>
        /// <param name="profileid">profileid</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdateImageOrderNumber(int photoID, decimal imgorderno, int profileid, int id)
        {
            return BusinessDAL.UpdateImageOrderNumber(photoID, imgorderno, profileid, id);
        }
        //Balaji 22-06-2012
        /// <summary>
        /// Get Max Image OrderNo
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int GetMaxImageOrderNo(int profileID)
        {
            return BusinessDAL.GetMaxImageOrderNo(profileID);
        }

        /// <summary>
        /// Get Photo details By PhotoID
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPhotodetailsByPhotoID(int photoID)
        {
            return BusinessDAL.GetPhotodetailsByPhotoID(photoID);
        }

        /// <summary>
        /// Update Photo Primary flag by PhotoID
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <param name="primaryflag">primaryflag</param>
        /// <param name="profileid">profileid</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdatePhotoPrimaryflagbyPhotoID(int photoID, bool primaryflag, int profileid, int id)
        {
            return BusinessDAL.UpdatePhotoPrimaryflagbyPhotoID(photoID, primaryflag, profileid, id);
        }

        /// <summary>
        /// Update Business Type
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="businessType">businessType</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdateBusinessType(int profileID, string businessType, int id)
        {
            return BusinessDAL.UpdateBusinessType(profileID, businessType, id);
        }

        /// <summary>
        /// Get Business Types
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessTypes()
        {
            return BusinessDAL.GetBusinessTypes();
        }
        //----------Moving Contacts from One Group to Another
        /// <summary>
        /// Move User Contacts From One Group to Another Group
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="parentGroupID">parentGroupID</param>
        /// <param name="movingGroupID">movingGroupID</param>
        /// <param name="contactID">contactID</param>
        /// <param name="id">id</param>
        public void MoveUserContactsFromOneGrouptoAnotherGroup(int userID, string parentGroupID, string movingGroupID, int contactID, int id)
        {
            BusinessDAL.MoveUserContactsFromOneGrouptoAnotherGroup(userID, parentGroupID, movingGroupID, contactID, id);
        }

        /// <summary>
        /// Search User Contacts On UserID and Email
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <param name="searchGroup">searchGroup</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <param name="isprivateModule">isprivateModule</param>
        /// <returns>DataTable</returns>
        public DataTable SearchUserContactsOnUserIDandEmail(int userID, string emailAddress, string searchGroup, int checkFlag, bool isprivateModule)
        {
            return BusinessDAL.SearchUserContactsOnUserIDandEmail(userID, emailAddress, searchGroup, checkFlag, isprivateModule);
        }
        // ENd

        /// <summary>
        /// Update Year and Establishment Flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="establishmentFlag">establishmentFlag</param>
        /// <param name="noofemp">noofemp</param>
        /// <param name="eventcalendarflag">eventcalendarflag</param>
        /// <param name="appointmentCaledar">appointmentCaledar</param>
        /// <param name="couponPage">couponPage</param>
        /// <param name="webAddress1">webAddress1</param>
        /// <param name="webAddress2">webAddress2</param>
        /// <param name="facebook">facebook</param>
        /// <param name="fanpage">fanpage</param>
        /// <param name="linkedin">linkedin</param>
        /// <param name="twitter">twitter</param>
        /// <param name="media">media</param>
        /// <param name="myNetwork">myNetwork</param>
        /// <param name="updates">updates</param>
        /// <param name="mobilePhone">mobilePhone</param>
        /// <param name="id">id</param>
        public void UpdateYearodEstablishmentFlag(int profileID, bool establishmentFlag, bool noofemp, bool eventcalendarflag, bool appointmentCaledar, bool couponPage, bool webAddress1, bool webAddress2, bool facebook, bool fanpage, bool linkedin, bool twitter, bool media, bool myNetwork, bool updates, bool mobilePhone, int id)
        {
            BusinessDAL.UpdateYearodEstablishmentFlag(profileID, establishmentFlag, noofemp, eventcalendarflag, appointmentCaledar, couponPage, webAddress1, webAddress2, facebook, fanpage, linkedin, twitter, media, myNetwork, updates, mobilePhone, id);
        }

        /// <summary>
        /// Get ProfileID by RenewalID
        /// </summary>
        /// <param name="renewID">renewID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileIDbyRenewalID(int renewID)
        {
            return BusinessDAL.GetProfileIDbyRenewalID(renewID);
        }
        // BG Music
        /// <summary>
        /// Insert BG Music File Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="bGMusicNum">bGMusicNum</param>
        /// <param name="profileBGMusicPath">profileBGMusicPath</param>
        /// <param name="bGMusicPrimeFlag">bGMusicPrimeFlag</param>
        /// <param name="statusFlag">statusFlag</param>
        /// <param name="playFile">playFile</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int InsertBGMusicFileDetails(int profileID, int userID, int bGMusicNum, string profileBGMusicPath, bool bGMusicPrimeFlag, bool statusFlag, string playFile, int id)
        {
            return BusinessDAL.InsertBGMusicFileDetails(profileID, userID, bGMusicNum, profileBGMusicPath, bGMusicPrimeFlag, statusFlag, playFile, id);
        }

        /// <summary>
        /// Get BG Music File Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBGMusicFileDetails(int profileID)
        {
            return BusinessDAL.GetBGMusicFileDetails(profileID);
        }

        /// <summary>
        /// Delete User BG Music File Details
        /// </summary>
        /// <param name="bGMusicFileID">bGMusicFileID</param>
        /// <returns>Int</returns>
        public int Delete_UserBGMusicFileDetails(int bGMusicFileID)
        {
            return BusinessDAL.Delete_UserBGMusicFileDetails(bGMusicFileID);
        }

        /// <summary>
        /// Get Active BG Music
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveBGMusic(int profileID)
        {
            return BusinessDAL.GetActiveBGMusic(profileID);
        }

        /// <summary>
        /// Get Play Sequence Active BG Music
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPlaySequenceActiveBGMusic(int profileID)
        {
            return BusinessDAL.GetPlaySequenceActiveBGMusic(profileID);
        }

        /// <summary>
        /// Update Default BG Music By MusicID
        /// </summary>
        /// <param name="musicID">musicID</param>
        /// <param name="defaultFlag">defaultFlag</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdateDefaultBGMusicByMusicID(int musicID, bool defaultFlag, int id)
        {

            return BusinessDAL.UpdateDefaultBGMusicByMusicID(musicID, defaultFlag, id);
        }

        /// <summary>
        /// BG Music Play List Sequence
        /// </summary>
        /// <param name="bgMusicFileID">bgMusicFileID</param>
        /// <param name="bgMusicSeqNo">bgMusicSeqNo</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int BGMusicPlayListSequence(int bgMusicFileID, int bgMusicSeqNo, int id)
        {

            return BusinessDAL.BGMusicPlayListSequence(bgMusicFileID, bgMusicSeqNo, id);
        }

        /// <summary>
        /// Profile Update BG Music Default Play
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="defaultBGMusicPlay">defaultBGMusicPlay</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ProfileUpdateBGMusicDefaultPlay(int profileID, bool defaultBGMusicPlay, int id)
        {
            return BusinessDAL.ProfileUpdateBGMusicDefaultPlay(profileID, defaultBGMusicPlay, id);
        }

        /// <summary>
        /// Get Profile Update BG Music Default Play
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileUpdateBGMusicDefaultPlay(int profileID)
        {
            return BusinessDAL.GetProfileUpdateBGMusicDefaultPlay(profileID);
        }

        /// <summary>
        /// Get BG Music Path MusicID
        /// </summary>
        /// <param name="musicID">musicID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBGMusicPathMusicID(int musicID)
        {
            return BusinessDAL.GetBGMusicPathMusicID(musicID);
        }
        // END BG Music

        //Start Issue 766
        /// <summary>
        /// Update No of Employees Flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="noofEmployees">noofEmployees</param>
        public void UpdateNoofEmployeesFlag(int profileID, bool noofEmployees)
        {
            BusinessDAL.UpdateNoofEmployeesFlag(profileID, noofEmployees);
        }
        //End issue 766

        /// <summary>
        /// Update Year and Establishment Flag with only two parameters
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="establishmentflag">establishmentflag</param>
        public void UpdateYearodEstablishmentFlag(int profileID, bool establishmentflag)
        {
            BusinessDAL.UpdateYearodEstablishmentFlag(profileID, establishmentflag);
        }

        /// <summary>
        /// Get the duplicate contact email IDs by User_ID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkvalue">checkvalue</param>
        /// <returns>DataTable</returns>
        public DataTable GetDuplicateContactEmailIDsbyUserID(int userID, int checkvalue)
        {
            return BusinessDAL.GetDuplicateContactEmailIDsbyUserID(userID, checkvalue);
        }


        /// <summary>
        ///  GNN Registration
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="networkid">networkid</param>
        public void UpdateNetworkIDbyUserID(int userID, int networkid)
        {
            BusinessDAL.UpdateNetworkIDbyUserID(userID, networkid);
        }


        // ------------------------- NetWork Image ----------------------------- //
        /// <summary>
        /// Get NetWork Details By ID
        /// </summary>
        /// <param name="nid">nid</param>
        /// <returns>DataTable</returns>
        public DataTable GetNetWorkDetailsByID(int nid)
        {
            return BusinessDAL.GetNetWorkDetailsByID(nid);
        }
        /// <summary>
        /// Update Event calendar Flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="eventcalendarflag">eventcalendarflag</param>
        public void UpdateEventcalendarFlag(int profileID, bool eventcalendarflag)
        {
            BusinessDAL.UpdateEventcalendarFlag(profileID, eventcalendarflag);
        }
        //Issue 969 
        /// <summary>
        /// Update Audio Flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="audioflag">audioflag</param>
        public void UpdateAudioFlag(int profileID, bool audioflag)
        {
            BusinessDAL.UpdateAudioFlag(profileID, audioflag);
        }
        // -------------------------Events  Info ----------------------------- //
        /// <summary>
        /// Get Top 1 Profile Events Info By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTop1ProfileEventsInfoByProfileID(int profileID)
        {
            return BusinessDAL.GetTop1ProfileEventsInfoByProfileID(profileID);


        }
        // -------------------------BusinessUpdates  Info ----------------------------- //
        /// <summary>
        /// Get Top 1 Business Updates Info By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTop1BusinessUpdatesInfoByProfileID(int profileID)
        {
            return BusinessDAL.GetTop1BusinessUpdatesInfoByProfileID(profileID);
        }


        // -------------------------Get Active Events Count ----------------------------- //
        /// <summary>
        /// Get Active Events Count
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int GetActiveEventsCount(int profileid)
        {
            return BusinessDAL.GetActiveEventsCount(profileid);
        }

        // *** Start Get Promocode Details *** //
        /// <summary>
        /// Get Promo Code Details
        /// </summary>
        /// <param name="promoCode">promoCode</param>
        /// <param name="pricePlan">pricePlan</param>
        /// <returns>DataTable</returns>
        public DataTable GetProMoCodeDetails(string promoCode, string pricePlan)
        {
            return BusinessDAL.GetProMoCodeDetails(promoCode, pricePlan);
        }
        // *** End Get Promocode Details *** // 
        // *** Issue 991 *** //
        /// <summary>
        /// Update Profile About Us Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="aboutUsText">aboutUsText</param>
        /// <param name="iD">iD</param>
        /// <param name="pEditHtml">pEditHtml</param>
        public void UpdateProfileAboutUsDetails(int profileID, string aboutUsText, int iD, string pEditHtml)
        {
            BusinessDAL.UpdateProfileAboutUsDetails(profileID, aboutUsText, iD, pEditHtml);
        }
        /// <summary>
        /// Update Business Profile Details
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="description">description</param>
        /// <param name="contactname">contactname</param>
        /// <param name="bdays">bdays</param>
        /// <param name="bhours">bhours</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="extection">extection</param>
        /// <param name="fax">fax</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="mobileNumber">mobileNumber</param>
        /// <param name="alternatePhone">alternatePhone</param>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="iD">iD</param>
        /// <param name="pDescriptionEditHtml">pDescriptionEditHtml</param>
        /// <param name="timezoneid">timezoneid</param>
        /// <returns>Int</returns>
        public int UpdateBusinessProfileDetails(string buzname, string description, string contactname, string bdays, string bhours, string address1,
            string address2, string city, string state, string country, string zipcode, string phone1, string extection, string fax, int userid, int profileid,
            string mobileNumber, string alternatePhone, double platitude1, double plongitude1, int iD, string pDescriptionEditHtml, int timezoneid)
        {
            return BusinessDAL.UpdateBusinessProfileDetails(buzname, description, contactname, bdays, bhours, address1, address2, city, state, country,
                zipcode, phone1, extection, fax, userid, profileid, mobileNumber, alternatePhone, platitude1, plongitude1, iD, pDescriptionEditHtml, timezoneid);
        }
        // *** End Issue 991 *** //

        //issue 752 start
        /// <summary>
        /// Check Group Existence By Group Name
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="groupName">groupName</param>
        /// <returns>Int</returns>
        public int CheckGroupExistenceByGroupName(int userID, string groupName)
        {
            return BusinessDAL.CheckGroupExistenceByGroupName(userID, groupName);
        }
        //issue 752 end

        /// <summary>
        /// Update Photo Primary flag By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="audioflag">audioflag</param>
        /// <param name="iD">iD</param>
        public void UpdatePhotoPrimaryflagByProfileID(int profileID, bool audioflag, int iD)
        {
            BusinessDAL.UpdatePhotoPrimaryflagByProfileID(profileID, audioflag, iD);
        }

        /// <summary>
        /// Get Duplicate Contacts By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkvalue">checkvalue</param>
        /// <param name="pgNmb">pgNmb</param>
        /// <param name="isPrivateModule">isPrivateModule</param>
        /// <returns>DataTable</returns>
        public DataTable GetDuplicateContactsByUserID(int userID, int checkvalue, int pgNmb, bool isPrivateModule)
        {
            return BusinessDAL.GetDuplicateContactsByUserID(userID, checkvalue, pgNmb, isPrivateModule);
        }

        /// <summary>
        /// Get Profile Reviews By ID
        /// </summary>
        /// <param name="testimonialID">testimonialID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileReviewsByID(int testimonialID)
        {
            return BusinessDAL.GetProfileReviewsByID(testimonialID);
        }
        /// <summary>
        /// Get Reviews For User
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetRiveiwsForUser(int userID)
        {
            return BusinessDAL.GetRiveiwsForUser(userID);
        }

        /// <summary>
        /// Get Profile Reviews For Category
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="rating">rating</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileReviewsForCategory(string category, int rating, int userID)
        {
            return BusinessDAL.GetProfileReviewsForCategory(category, rating, userID);
        }

        /// <summary>
        /// Change To Test Account
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="flag">flag</param>
        public void ChangeToTestAccount(int userId, int flag)
        {
            BusinessDAL.ChangeToTestAccount(userId, flag);
        }

        /// <summary>
        /// Get Created User
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>String</returns>
        public string GetCreatedUser(int userId)
        {
            return BusinessDAL.GetCreatedUser(userId);
        }

        /// <summary>
        /// Get Google Places Types
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetGooglePlacesTypes()
        {
            return BusinessDAL.GetGooglePlacesTypes();
        }

        /// <summary>
        /// Insert Google Place Response Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="businessName">businessName</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="types">types</param>
        /// <param name="referenceKey">referenceKey</param>
        /// <param name="referenceID">referenceID</param>
        public void InsertGooglePlaceResponseDetails(int userID, string businessName, string address, string city, string types, string referenceKey, string referenceID)
        {
            BusinessDAL.InsertGooglePlaceResponseDetails(userID, businessName, address, city, types, referenceKey, referenceID);
        }


        /// <summary>
        /// for Temp Mailing List Adding in Public Site
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pMailingEmailID">pMailingEmailID</param>
        public void AddTempMailingList(int pUserID, string pMailingEmailID)
        {
            BusinessDAL.AddTempMailingList(pUserID, pMailingEmailID);
        }

        /// <summary>
        /// for Temp Mailing List Details in Public Site
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTempMailingListDetails(int pUserID)
        {
            return BusinessDAL.GetTempMailingListDetails(pUserID);
        }

        /// <summary>
        /// Delete Temp Mailing List Details
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        public void DeleteTempMailingListDetails(int pUserID)
        {
            BusinessDAL.DeleteempMailingListDetails(pUserID);
        }
        // *** Update Social Network links *** //
        /// <summary>
        /// Update Social Networks
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="facebooklink">facebooklink</param>
        /// <param name="fbfanpagelink">fbfanpagelink</param>
        /// <param name="linkdinlink">linkdinlink</param>
        /// <param name="twitterlink">twitterlink</param>
        /// <param name="youtubeLink">youtubeLink</param>
        /// <param name="instagramLink">instagramLink</param>
        /// <param name="id">id</param>
        public void UpdateSocialNetworks(int profileid, string facebooklink, string fbfanpagelink, string linkdinlink, string twitterlink, string youtubeLink, string instagramLink, int id)
        {
            BusinessDAL.UpdateSocialNetworks(profileid, facebooklink, fbfanpagelink, linkdinlink, twitterlink, youtubeLink, instagramLink, id);
        }

        /// <summary>
        /// Check Credentials
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="email">email</param>
        /// <returns>Int</returns>
        public int CheckCredentials(string name, string email)
        {
            return BusinessDAL.CheckCredentials(name, email);
        }

        /// <summary>
        /// Insert Reports Inquiry
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="email">email</param>
        public void InsertReportsInquiry(string name, string email)
        {
            BusinessDAL.InsertReportsInquiry(name, email);
        }

        /// <summary>
        /// Get Report Inquiry Name And GroupID
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="groupName">groupName</param>
        /// <param name="firstname">firstname</param>
        /// <returns>Int</returns>
        public int GetReportInquiryNameAndGroupID(string email, string groupName, out string firstname)
        {
            return BusinessDAL.GetReportInquiryNameAndGroupID(email, groupName, out firstname);
        }

        /// <summary>
        /// Get Pricing And Multi Tool Labels
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetPricingAndMultiToolLabels()
        {
            return BusinessDAL.GetPricingAndMultiToolLabels();
        }

        /// <summary>
        /// Insert User Selected Tools
        /// </summary>
        /// <param name="tools">tools</param>
        public void InsertUserSelectedTools(BusinessDAL.ToolsEntities tools)
        {
            BusinessDAL.InsertUserSelectedTools(tools);
        }

        /// <summary>
        /// Get Selected Tools By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSelectedToolsByUserID(int userID)
        {
            return BusinessDAL.GetSelectedToolsByUserID(userID);
        }

        /// <summary>
        /// Insert Transaction Details
        /// </summary>
        /// <param name="transactionQuery">transactionQuery</param>
        public void InsertTransactionDetails(string transactionQuery)
        {
            BusinessDAL.InsertTransactionDetails(transactionQuery);
        }

        /// <summary>
        /// Get Updated Selected Tools Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUpdatedSelectedToolsDetails(int userID)
        {
            return BusinessDAL.GetUpdatedSelectedToolsDetails(userID);
        }

        /// <summary>
        /// Update Newly Selected Tools
        /// </summary>
        /// <param name="updatedtools">updatedtools</param>
        public void UpdateNewlySelectedTools(BusinessDAL.ToolsEntities updatedtools)
        {
            BusinessDAL.UpdateNewlySelectedTools(updatedtools);
        }


        /* ******************* domain registration ********************** */
        /// <summary>
        /// Update Domain Flag
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="flag">flag</param>
        /// <param name="id">id</param>
        public void UpdateDomainFlag(int userID, bool flag, int id)
        {
            BusinessDAL.UpdateDomainFlag(userID, flag, id);
        }

        /// <summary>
        /// Update Forward Domain Flag
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="flag">flag</param>
        public void UpdateForwardDomainFlag(int userID, bool flag)
        {
            BusinessDAL.UpdateForwardDomainFlag(userID, flag);
        }

        /// <summary>
        /// Get Items IDs
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="flag">flag</param>
        /// <returns>DataTable</returns>
        public DataTable GetItemsIDs(int profileID, int flag)
        {
            return BusinessDAL.GetItemsIDs(profileID, flag);
        }

        /// <summary>
        /// Check Paid Items
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckPaidItems(int profileID)
        {
            return BusinessDAL.CheckPaidItems(profileID);
        }

        /// <summary>
        /// Add Increased Emails Level
        /// </summary>
        /// <param name="selectedEmailsCount">selectedEmailsCount</param>
        /// <param name="userID">userID</param>
        /// <param name="subcost">subcost</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="cost">cost</param>
        public void AddIncreasedEmailsLevel(int selectedEmailsCount, int userID, decimal subcost, int subPeriod, int cost)
        {
            BusinessDAL.AddIncreasedEmailsLevel(selectedEmailsCount, userID, subcost, subPeriod, cost);
        }

        /// <summary>
        /// Update Join My Mailing List Text
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="joinMailingList">joinMailingList</param>
        /// <param name="id">id</param>
        public void UpdateJoinMyMailingListText(int profileID, string joinMailingList, int id)
        {
            BusinessDAL.UpdateJoinMyMailingListText(profileID, joinMailingList, id);
        }

        /// <summary>
        /// Validate Promo code
        /// </summary>
        /// <param name="promocodeName">promocodeName</param>
        /// <returns>Int</returns>
        public int ValidatePromocode(string promocodeName)
        {
            return BusinessDAL.ValidatePromocode(promocodeName);
        }

        /// <summary>
        /// Update Dashbaord Video Check
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="flag">flag</param>
        public void UpdateDashbaordVideoCheck(int userID, bool flag)
        {
            BusinessDAL.UpdateDashbaordVideoCheck(userID, flag);
        }
        // *** Used to get the Databoard Setting Details *** //
        /// <summary>
        /// Get Dashboard Settings Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetDashboardSettingsDtls(int profileID)
        {
            return BusinessDAL.GetDashboardSettingsDtls(profileID);
        }
        // *** Used to insert/update the Databoard Setting Details *** //
        /// <summary>
        /// Insert Dashboard Settings Details
        /// </summary>
        /// <param name="tools">tools</param>
        /// <param name="isMobileApp">isMobileApp</param>
        /// <param name="isBulletins">isBulletins</param>
        /// <param name="id">id</param>
        public void InsertDashboardSettingsDtls(BusinessDAL.ToolsEntities tools, bool isMobileApp, bool isBulletins, int id)
        {
            BusinessDAL.InsertDashboardSettingsDtlst(tools, isMobileApp, isBulletins, id);
        }
        // *** Insert Profile Tabs Balaji *** //
        /// <summary>
        /// Insert and Update Profile Tabs
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pTabNo">pTabNo</param>
        /// <param name="pTabName">pTabName</param>
        /// <param name="pTabID">pTabID</param>
        /// <param name="pOrderNo">pOrderNo</param>
        /// <param name="id">id</param>
        public void Inser_Update_ProfileTabs(int pProfileID, int pTabNo, string pTabName, string pTabID, int pOrderNo, int id)
        {
            BusinessDAL.Inser_Update_ProfileTabs(pProfileID, pTabNo, pTabName, pTabID, pOrderNo, id);
        }

        /// <summary>
        /// Get Profile Tabs By ProfileID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileTabsByProfileID(int pProfileID)
        {
            return BusinessDAL.GetProfileTabsByProfileID(pProfileID);
        }
        /// <summary>
        /// Get Profile Master tabs
        /// </summary>
        /// <param name="pPageName">pPageName</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileMastertabs(string pPageName)
        {
            return BusinessDAL.GetProfileMastertabs(pPageName);
        }
        /// <summary>
        /// Remove Primary Flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="imgNum">imgNum</param>
        /// <param name="photoID">photoID</param>
        /// <param name="id">id</param>
        public void RemovePrimaryFlag(int profileID, int imgNum, int photoID, int id)
        {
            BusinessDAL.RemovePrimaryFlag(profileID, imgNum, photoID, id);
        }

        /// <summary>
        /// Get User Subscriptions By Type
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="subscType">subscType</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserSubscriptionsByType(int userID, int subscType)
        {
            return BusinessDAL.GetUserSubscriptionsByType(userID, subscType);
        }

        /// <summary>
        /// Insert User Content Module
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subscAmount">subscAmount</param>
        /// <param name="discount">discount</param>
        /// <param name="billableAmount">billableAmount</param>
        /// <param name="subscType">subscType</param>
        /// <param name="subperiod">subperiod</param>
        /// <param name="purchageOrderID">purchageOrderID</param>
        /// <param name="totalAmt">totalAmt</param>
        /// <param name="totalBillableAmt">totalBillableAmt</param>
        /// <param name="type">type</param>
        /// <param name="endDate">endDate</param>
        /// <returns>Int</returns>
        public int Insert_UserAddOns(int profileID, int userID, decimal subscAmount, decimal discount, decimal billableAmount, int subscType, int subperiod, int purchageOrderID, decimal totalAmt, decimal totalBillableAmt, int type, DateTime endDate)
        {
            return BusinessDAL.Insert_UserAddOns(profileID, userID, subscAmount, discount, billableAmount, subscType, subperiod, purchageOrderID, totalAmt, totalBillableAmt, type, endDate);
        }
        public DataTable GetPackageMenuLinks(int packageNumber, bool isLiteVersion, string VerticalName)
        {
            return BusinessDAL.GetPackageMenuLinks(packageNumber, isLiteVersion, VerticalName);
        }

        /// <summary>
        /// Get Child Menu Links
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <returns>DataTable</returns>
        public DataTable GetChildMenuLinks(int parentId)
        {
            return BusinessDAL.GetChildMenuLinks(parentId);
        }

        /// <summary>
        /// Delete NonRegistered User by userID
        /// </summary>
        /// <param name="userID">userID</param>
        public void DeleteNonRegisteredUser(int userID)
        {
            BusinessDAL.DeleteNonRegisteredUser(userID);
        }
        // *** Fix for IRH-72 31-01-2013 *** //
        /// <summary>
        /// Decline User Appointment
        /// </summary>
        /// <param name="schID">schID</param>
        public void DeclineUserAppointment(int schID)
        {
            BusinessDAL.DeclineUserAppointment(schID);
        }

        /// <summary>
        /// Add Failed Transactions
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="package">package</param>
        /// <param name="emails">emails</param>
        /// <param name="isAccoutSetup">isAccoutSetup</param>
        /// <param name="isCampaignSetup">isCampaignSetup</param>
        /// <param name="totalAmount">totalAmount</param>
        /// <param name="billableAmount">billableAmount</param>
        /// <param name="discount">discount</param>
        /// <returns>Int</returns>
        public int AddFailedTransactions(int profileID, int userID, int package, int emails, bool isAccoutSetup, bool isCampaignSetup, decimal totalAmount, decimal billableAmount, decimal discount)
        {
            return BusinessDAL.AddFailedTransactions(profileID, userID, package, emails, isAccoutSetup, isCampaignSetup, totalAmount, billableAmount, discount);
        }

        /// <summary>
        /// Update Failed Transaction
        /// </summary>
        /// <param name="orderID">orderID</param>
        public void UpdateFailedTransaction(int orderID)
        {
            BusinessDAL.UpdateFailedTransaction(orderID);
        }

        /// <summary>
        /// Update Business Unique Code
        /// </summary>
        /// <param name="uniqueCode">uniqueCode</param>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        public void UpdateBusinessUniqueCode(string uniqueCode, int userID, int profileID)
        {
            BusinessDAL.UpdateBusinessUniqueCode(uniqueCode, userID, profileID);
        }

        /// <summary>
        /// Get Web Links
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetWebLinks(int profileId)
        {
            return BusinessDAL.GetWebLinks(profileId);
        }

        /// <summary>
        /// Get Web Links By linkID
        /// </summary>
        /// <param name="linkID">linkID</param>
        /// <returns>DataTable</returns>
        public DataTable GetWebLinksById(int linkID)
        {
            return BusinessDAL.GetWebLinksById(linkID);
        }

        /// <summary>
        /// Create Web Links
        /// </summary>
        /// <param name="linkID">linkID</param>
        /// <param name="title">title</param>
        /// <param name="linkUrl">linkUrl</param>
        /// <param name="userid">userid</param>
        /// <param name="iD">iD</param>
        /// <param name="flag">flag</param>
        /// <param name="profileId">profileId</param>
        /// <param name="pCatID">pCatID</param>
        /// <returns>Int</returns>
        public int CreateWebLinks(int linkID, string title, string linkUrl, int userid, int iD, int flag, int profileId, int pCatID)
        {
            return BusinessDAL.CreateWebLinks(linkID, title, linkUrl, userid, iD, flag, profileId, pCatID);
        }
        // *** App Manage Buttons 25-03-2013 *** //
        /// <summary>
        /// Get Manage Buttons By ProfileID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageButtonsByProfileID(int pProfileID)
        {
            return BusinessDAL.GetManageButtonsByProfileID(pProfileID);
        }

        /// <summary>
        /// Get Master Manage Buttons
        /// </summary>
        /// <param name="pPageName">pPageName</param>
        /// <param name="domainName">domainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetMastermanageButtons(string pPageName, string domainName)
        {
            return BusinessDAL.GetMastermanageButtons(pPageName, domainName);
        }

        /// <summary>
        /// Insert and Update Manage Buttons
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pTabNo">pTabNo</param>
        /// <param name="pTabName">pTabName</param>
        /// <param name="pTabID">pTabID</param>
        /// <param name="pOrderNo">pOrderNo</param>
        /// <param name="id">id</param>
        public void Inser_Update_ManageButtons(int pProfileID, int pTabNo, string pTabName, string pTabID, int pOrderNo, int id)
        {
            BusinessDAL.Inser_Update_ManageButtons(pProfileID, pTabNo, pTabName, pTabID, pOrderNo, id);
        }

        /// <summary>
        /// Get Send Notifications
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendNotifications(int profileId)
        {
            return BusinessDAL.GetSendNotifications(profileId);
        }

        /// <summary>
        /// Get Mobile App Alerts
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="blockedType">blockedType</param>
        /// <returns>DataTable</returns>
        public DataTable GetMobileAppAlerts(bool flag, int userID, int? blockedType = null, int ArchiveType = 0)
        {
            return BusinessDAL.GetMobileNewsletterAlerts(flag, userID, blockedType, ArchiveType);
        }

        public DataTable GetMobilePublicCallsHistory(bool pIsAllItems, int pHistoryID, int pProfileID, bool? IsRead = false, bool? IsArchive = false)
        {
            return BusinessDAL.GetMobilePublicCallsHistory(pIsAllItems, pHistoryID, pProfileID, IsRead, IsArchive);
        }

        public DataTable GetMobilePrivateCallsHistory(bool pIsAllItems, int pHistoryID, int pProfileID, bool? IsRead = false, int ArchiveType = 0)
        {
            return BusinessDAL.GetMobilePrivateCallsHistory(pIsAllItems, pHistoryID, pProfileID, IsRead, ArchiveType);
        }
        public void DeletePubicCallHistory(int historyID)
        {
            BusinessDAL.DeletePubicCallHistory(historyID);
        }

        public void DeletePrivateCallHistory(int historyID)
        {
            BusinessDAL.DeletePrivateCallHistory(historyID);
        }

        /// <summary>
        /// Select Mobile App Alerts
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="contactID">contactID</param>
        /// <param name="flag">flag</param>
        /// <param name="id">id</param>
        /// <returns>DataTable</returns>
        public DataTable SelectMobileAppAlerts(int userID, int contactID, bool flag, int id, string Archive = "0")
        {
            return BusinessDAL.SelectMobileNewsletters(userID, contactID, flag, id, Archive);
        }

        /// <summary>
        /// Get Mobile Tips
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="blockedType">blockedType</param>
        /// <returns>DataTable</returns>
        public DataTable GetMobileTips(bool flag, int userID, int? blockedType = null, int ArchiveType = 0)
        {
            return BusinessDAL.GetMobileTips(flag, userID, blockedType, ArchiveType);
        }

        /// <summary>
        /// Select Mobile Tips
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="contactID">contactID</param>
        /// <param name="flag">flag</param>
        /// <param name="id">id</param>
        /// <returns>DataTable</returns>
        public DataTable SelectMobileTips(int userID, int contactID, bool flag, int id)
        {
            return BusinessDAL.SelectMobileTips(userID, contactID, flag, id);
        }

        /// <summary>
        /// Get Dashboard Flow
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="loggedUser">loggedUser</param>
        /// <returns>DataTable</returns>
        public DataTable GetDashboardFlow(int userID, int loggedUser)
        {
            return BusinessDAL.GetDashboardFlow(userID, loggedUser);
        }

        /// <summary>
        /// Update Dashboard Flow
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="type">type</param>
        /// <param name="loggedUser">loggedUser</param>
        public void UpdateDashboardFlow(int userID, int type, int loggedUser)
        {
            BusinessDAL.UpdateDashboardFlow(userID, type, loggedUser);
        }

        /// <summary>
        /// Get Detail Invoice by ProfileID
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetDetailInvoicebyProfileID(int profileId)
        {
            return BusinessDAL.GetDetailInvoicebyProfileID(profileId);
        }

        /// <summary>
        /// Get User Details By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDtlsByUserID(int userID)
        {
            return BusinessDAL.GetUserDtlsByUserID(userID);
        }

        /// <summary>
        /// Delete Messages
        /// </summary>
        /// <param name="messageID">messageID</param>
        /// <returns>Int</returns>
        public static int DeleteMessages(int messageID)
        {
            return BusinessDAL.DeleteMessages(messageID);
        }

        /// <summary>
        /// Get Pie Chart Data
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalDownloads">totalDownloads</param>
        /// <returns>DataTable</returns>
        public DataTable GetPieChartData(int profileID, DateTime startDate, DateTime endDate, out int totalDownloads)
        {
            return BusinessDAL.GetPieChartData(profileID, startDate, endDate, out totalDownloads);
        }
        /// <summary>
        /// Pie Chart for App Open Reports
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalDownloads">totalDownloads</param>
        /// <returns>DataTable</returns>
        public DataTable GetPieChartDataForOpenReport(int profileID, DateTime startDate, DateTime endDate, out int totalDownloads)
        {
            return BusinessDAL.GetPieChartDataForOpenReport(profileID, startDate, endDate, out totalDownloads);
        }
        /// <summary>
        /// Column Chart for Banner Ad Click Count Report
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="BannerId">BannerId</param>
        /// <param name="totalDownloads">totalDownloads</param>
        /// <returns>DataSet</returns>
        public DataSet GetPieChartDataForBannerAdReport(int profileID, DateTime startDate, DateTime endDate, int BannerId, out int totalDownloads)
        {
            return BusinessDAL.GetPieChartDataForBannerAdReport(profileID, startDate, endDate, BannerId, out totalDownloads);
        }

        /// <summary>
        /// Get Parent Profiles
        /// </summary>
        /// <param name="searchString">searchString</param>
        /// <returns>DataTable</returns>
        public DataTable GetParentProfiles(string searchString)
        {
            return BusinessDAL.GetParentProfiles(searchString);
        }

        /// <summary>
        /// Check Parent Profile Exists
        /// </summary>
        /// <param name="profileName">profileName</param>
        /// <returns>Int</returns>
        public int CheckParentProfileExists(string profileName)
        {
            return BusinessDAL.CheckParentProfileExists(profileName);
        }

        /// <summary>
        /// Block UnBlock Message Senders
        /// </summary>
        /// <param name="messageID">messageID</param>
        /// <param name="blockFlag">blockFlag</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int BlockUnBlockMessageSenders(int messageID, bool blockFlag, int userID)
        {
            return BusinessDAL.BlockUnBlockMessageSenders(messageID, blockFlag, userID);
        }

        /// <summary>
        /// Block UnBlock Message Senders
        /// </summary>
        /// <param name="deviceID">deviceID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="blockFlag">blockFlag</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int BlockUnBlockMessageSenders(string deviceID, int profileID, bool blockFlag, int userID, string pModuleType)
        {
            return BusinessDAL.BlockUnBlockMessageSenders(deviceID, profileID, blockFlag, userID, pModuleType);
        }

        /// <summary>
        /// Block UnBlock Message Senders
        /// </summary>
        /// <param name="messageID">messageID</param>
        /// <param name="blockFlag">blockFlag</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int BlockUnBlockSmartConnectSenders(int messageID, bool blockFlag, int userID)
        {
            return BusinessDAL.BlockUnBlockSmartConnectSenders(messageID, blockFlag, userID);
        }

        /// <summary>
        /// Get Blocked Users
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataSet</returns>
        public DataSet GetBlockedUsers(int profileID)
        {
            return BusinessDAL.GetBlockedUsers(profileID);
        }

        /// <summary>
        /// Get Time Zones
        /// </summary>
        /// <param name="country">country</param>
        /// <returns>DataTable</returns>
        public DataTable GetTimeZones(string country)
        {
            return BusinessDAL.GetTimeZones(country);
        }

        /// <summary>
        /// Update TimeZoneID
        /// </summary>
        /// <param name="profileIDfromAJAX">profileIDfromAJAX</param>
        /// <param name="timeZoneSelectedValue">timeZoneSelectedValue</param>
        /// <returns>String</returns>
        public string UpdateTimeZoneID(int profileIDfromAJAX, int timeZoneSelectedValue)
        {
            return BusinessDAL.UpdateTimeZoneID(profileIDfromAJAX, timeZoneSelectedValue);
        }

        /// <summary>
        /// Get Profile Subcriptions By Dates
        /// </summary>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileSubcriptionsByDates(DateTime pStartDate, DateTime pEndDate)
        {
            return BusinessDAL.GetProfileSubcriptonsByDates(pStartDate, pEndDate);
        }

        /// <summary>
        /// Get Default Profile Tab Names
        /// </summary>
        /// <param name="DomainName">DomainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetDefaultProfileTabNames(string DomainName)
        {
            return BusinessDAL.GetDefaultProfileTabNames(DomainName);
        }

        /// <summary>
        /// Get Alternate Cards
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAlternateCards(int profileID)
        {
            return BusinessDAL.GetAlternateCards(profileID);
        }

        /// <summary>
        /// Get Existed Preferred Details
        /// </summary>
        /// <param name="preferredID">preferredID</param>
        /// <returns>DataTable</returns>
        public DataTable GetExistedPreferredDetails(int preferredID)
        {
            return BusinessDAL.GetExistedPreferredDetails(preferredID);
        }

        /// <summary>
        /// Insert Billing Details
        /// </summary>
        /// <param name="pCCNumber">pCCNumber</param>
        /// <param name="pExMonth">pExMonth</param>
        /// <param name="pExYear">pExYear</param>
        /// <param name="pIsDefaultCard">pIsDefaultCard</param>
        /// <param name="pFirstName">pFirstName</param>
        /// <param name="pLastName">pLastName</param>
        /// <param name="pAddress1">pAddress1</param>
        /// <param name="pAddress2">pAddress2</param>
        /// <param name="pCity">pCity</param>
        /// <param name="pState">pState</param>
        /// <param name="pCountry">pCountry</param>
        /// <param name="pZipcode">pZipcode</param>
        /// <param name="pPayementDetailsID">pPayementDetailsID</param>
        /// <param name="pCustomerSubcriptionID">pCustomerSubcriptionID</param>
        /// <param name="pCardType">pCardType</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pSubOrderID">pSubOrderID</param>
        /// <param name="pCVV">pCVV</param>
        public void Insert_CC_BillingDetails(string pCCNumber, int pExMonth, int pExYear, bool pIsDefaultCard, string pFirstName, string pLastName, string pAddress1,
            string pAddress2, string pCity, string pState, string pCountry, string pZipcode, long pPayementDetailsID, long pCustomerSubcriptionID, string pCardType,
           int pProfileID, int pSubOrderID, int pCVV)
        {
            BusinessDAL.Insert_CC_BillingDetails(pCCNumber, pExMonth, pExYear, pIsDefaultCard, pFirstName, pLastName, pAddress1, pAddress2,
                pCity, pState, pCountry, pZipcode, pPayementDetailsID, pCustomerSubcriptionID, pCardType, pProfileID, pSubOrderID, pCVV);
        }

        /// <summary>
        /// Get Subcription Payment Card Details
        /// </summary>
        /// <param name="pID">pID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSubcription_PaymentCardDetails(int pID)
        {
            return BusinessDAL.GetSubcription_PaymentCardDetails(pID);
        }

        /// <summary>
        /// Update Billing Details
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="addressOne">addressOne</param>
        /// <param name="addressTwo">addressTwo</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipCode">zipCode</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>Int</returns>
        public int Update_CC_BillingDetails(string firstName, string lastName, string addressOne, string addressTwo, string city, string state, string zipCode, int ProfileID)
        {
            return BusinessDAL.Update_CC_BillingDetails(firstName, lastName, addressOne, addressTwo, city, state, zipCode, ProfileID);
        }

        /// <summary>
        /// Insert Request Custom Form Details
        /// </summary>
        /// <param name="pDescription">pDescription</param>
        /// <param name="pRemarks">pRemarks</param>
        /// <param name="pFormType">pFormType</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pUserID">pUserID</param>
        /// <returns>Int</returns>
        public int Insert_RequestCustomFormDetails(string pDescription, string pRemarks, string pFormType, int pProfileID, int pUserID)
        {
            return BusinessDAL.Insert_RequestCustomFormDetails(pDescription, pRemarks, pFormType, pProfileID, pUserID);
        }

        /// <summary>
        /// Insert User Subscriptions
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="totalAmount">totalAmount</param>
        /// <param name="discount">discount</param>
        /// <param name="billable">billable</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipCode">zipCode</param>
        /// <param name="country">country</param>
        /// <param name="number">number</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="month">month</param>
        /// <param name="year">year</param>
        /// <param name="type">type</param>
        /// <param name="numberC">numberC</param>
        /// <param name="discountCode">discountCode</param>
        /// <param name="isRecurring">isRecurring</param>
        /// <returns>Int</returns>
        public int InsertUserSubscriptions(int profileID, int userID, int subPeriod, decimal totalAmount, decimal discount, decimal billable, string address1, string address2, string city, string state, string zipCode, string country, string number, string firstname, string lastname, int month, int year, string type, string numberC, string discountCode, bool isRecurring)
        {
            return BusinessDAL.InsertUserSubscriptions(profileID, userID, subPeriod, totalAmount, discount, billable, address1, address2, city, state, zipCode, country, number, firstname, lastname, month, year, type, numberC, discountCode, isRecurring);
        }

        /// <summary>
        /// Get Store Items
        /// </summary>
        /// <param name="pCategory">pCategory</param>
        /// <param name="pProductType">pProductType</param>
        /// <returns>DataTable</returns>
        public DataTable GetStoreItems(string pCategory, string pProductType)
        {
            return BusinessDAL.GetStoreItems(pCategory, pProductType);
        }

        public DataTable GetPackageTypes(string domainName)
        {
            return BusinessDAL.GetPackageTypes(domainName);
        }
        /// <summary>
        /// Insert Transaction
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subOrderID">subOrderID</param>
        /// <param name="subscrType">subscrType</param>
        /// <param name="discount">discount</param>
        /// <param name="billableAmt">billableAmt</param>
        /// <param name="totalAmt">totalAmt</param>
        /// <param name="cUserID">cUserID</param>
        /// <param name="subscrPeriod">subscrPeriod</param>
        /// <param name="expirationDate">expirationDate</param>
        /// <param name="description">description</param>
        /// <param name="discountCode">discountCode</param>
        /// <param name="cnumber">cnumber</param>
        /// <param name="cType">cType</param>
        /// <param name="cexpDate">cexpDate</param>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipCode">zipCode</param>
        /// <param name="requestType">requestType</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="pPaymentProfileID">pPaymentProfileID</param>
        /// <param name="pCustomerSubscriptionID">pCustomerSubscriptionID</param>
        /// <param name="purchageOrderNo">purchageOrderNo</param>
        /// <param name="billingPhone">billingPhone</param>
        /// <param name="billingEmail">billingEmail</param>
        /// <returns>Int</returns>
        public int InsertTransaction(int profileID, int userID, int subOrderID, int subscrType, decimal discount, decimal billableAmt,
            decimal totalAmt, int cUserID, int subscrPeriod, DateTime expirationDate, string description, string discountCode, string cnumber,
            string cType, string cexpDate, string firstName, string lastName, string address1, string address2, string city, string state,
            string zipCode, int requestType, int subPeriod, long pPaymentProfileID, long pCustomerSubscriptionID, string purchageOrderNo, string billingPhone, string billingEmail, string salesCode)
        {
            return BusinessDAL.InsertTransaction(profileID, userID, subOrderID, subscrType, discount, billableAmt, totalAmt, cUserID, subscrPeriod,
                expirationDate, description, discountCode, cnumber, cType, cexpDate, firstName, lastName, address1, address2, city, state, zipCode,
                requestType, subPeriod, pPaymentProfileID, pCustomerSubscriptionID, purchageOrderNo, billingPhone, billingEmail, salesCode);
        }

        /// <summary>
        /// Get Affilates Invitation Details by PID
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAffilatesInvitationDetailsbyPID(int pPID)
        {
            return BusinessDAL.GetAffilatesInvitationDetailsbyPID(pPID);
        }

        /// <summary>
        /// Insert Order Details
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pSubcriptionTypeID">pSubcriptionTypeID</param>
        /// <param name="pSID">pSID</param>
        /// <param name="pTotalAmount">pTotalAmount</param>
        /// <param name="pDiscountAmount">pDiscountAmount</param>
        /// <param name="pBillableAmount">pBillableAmount</param>
        /// <param name="pCreatedDate">pCreatedDate</param>
        /// <param name="pCreatedUser">pCreatedUser</param>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pRenewalDate">pRenewalDate</param>
        /// <param name="pRequestType">pRequestType</param>
        /// <param name="pSub_SID">pSub_SID</param>
        /// <param name="reqSubApps">reqSubApps</param>
        /// <param name="pPeriod">pPeriod</param>
        /// <param name="pPromocode">pPromocode</param>
        /// <param name="pRenewalCost">pRenewalCost</param>
        /// <param name="isRenewLifeTime">isRenewLifeTime</param>
        /// <param name="promoCodeId">promoCodeId</param>
        /// <returns>Int</returns>
        public int InsertOrderDetails(int pProfileID, int pUserID, int pSubcriptionTypeID, int pSID, decimal pTotalAmount, decimal pDiscountAmount, decimal pBillableAmount,
           DateTime pCreatedDate, int pCreatedUser, DateTime pStartDate, DateTime pRenewalDate, int pRequestType, int? pSub_SID, int? reqSubApps,
           int pPeriod, string pPromocode, decimal pRenewalCost, bool isRenewLifeTime, int? promoCodeId, string salesCode, int pQuantity = 0, int? pPackageID = 0, int? pParentOrderDetailsID = 0)
        {
            return BusinessDAL.InsertOrderDetails(pProfileID, pUserID, pSubcriptionTypeID, pSID, pTotalAmount, pDiscountAmount, pBillableAmount,
                pCreatedDate, pCreatedUser, pStartDate, pRenewalDate, pRequestType, pSub_SID, reqSubApps, pPeriod, pPromocode, pRenewalCost, isRenewLifeTime, promoCodeId, salesCode, pQuantity, pPackageID, pParentOrderDetailsID);
        }

        /// <summary>
        /// Insert sms count very first time
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="cUserID"></param>
        /// <param name="orderDetailsID"></param>
        /// <param name="smsType"></param>
        /// <param name="smsQuantity"></param>
        public void InsertSMSAddons(int profileID, int cUserID, int orderDetailsID, string smsType, int smsQuantity)
        {
            BusinessDAL.InsertSMSAddons(profileID, cUserID, orderDetailsID, smsType, smsQuantity);
        }
        /// <summary>
        /// Insert Order Payment
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="paymentAmount">paymentAmount</param>
        /// <param name="pendingAmount">pendingAmount</param>
        /// <param name="chequeNo">chequeNo</param>
        /// <param name="userID">userID</param>
        public void InsertOrderPayment(int orderID, decimal paymentAmount, decimal pendingAmount, string chequeNo, int userID)
        {
            BusinessDAL.InsertOrderPayment(orderID, paymentAmount, pendingAmount, chequeNo, userID);
        }

        /// <summary>
        /// Get Subscription By ID
        /// </summary>
        /// <param name="subscrID">subscrID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSubscriptionByID(int subscrID)
        {
            return BusinessDAL.GetSubscriptionByID(subscrID);
        }

        public DataTable GetStoreItems_New(string pCategory, string pDomainName, int pPackageID, int pProfileID)
        {
            return BusinessDAL.GetStoreItems_New(pCategory, pDomainName, pPackageID, pProfileID);
        }
        /// <summary>
        /// Update User Branded App
        /// </summary>
        /// <param name="profilID">profilID</param>
        public void UpdateUserBrandedApp(int profilID)
        {
            BusinessDAL.UpdateUserBrandedApp(profilID);
        }

        /// <summary>
        /// Get Order Details By OrderID
        /// </summary>
        /// <param name="OrderID">OrderID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOrderDetailsByOrderID(int OrderID)
        {
            return BusinessDAL.GetOrderDetailsByOrderID(OrderID);
        }

        /// <summary>
        /// Update Order Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="orderID">orderID</param>
        /// <param name="subPeriod">subPeriod</param>
        public void UpdateOrderDetails(int profileID, int userID, int orderID, int subPeriod)
        {
            BusinessDAL.UpdateOrderDetails(profileID, userID, orderID, subPeriod);
        }

        /// <summary>
        /// Get All RFP Custom Form
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllRFPCustomForm()
        {
            return BusinessDAL.GetAllRFPCustomForm();
        }

        /// <summary>
        /// Get RFP Custom Details By ID
        /// </summary>
        /// <param name="pRFPID">pRFPID</param>
        /// <returns>DataTable</returns>
        public DataTable GetRFP_CustomDetailsByID(int pRFPID)
        {
            return BusinessDAL.GetRFP_CustomDetailsByID(pRFPID);
        }

        /// <summary>
        /// Check UserName and Password For Create User
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Int</returns>
        public int CheckUserNameandPasswordForCreateUser(string username)
        {
            return BusinessDAL.CheckUserNameandPasswordForCreateUser(username);
        }

        /// <summary>
        /// New Admin User Insertion
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="userName">userName</param>
        /// <param name="pwd">pwd</param>
        /// <param name="userID">userID</param>
        public void NewAdminUserInsertion(string firstName, string lastName, string userName, string pwd, int userID)
        {
            BusinessDAL.NewAdminUserInsertion(firstName, lastName, userName, pwd, userID);
        }

        /// <summary>
        /// Get Branded App Process All Status
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppProcessAllStatus()
        {
            return BusinessDAL.GetBrandedAppProcessAllStatus();
        }

        /// <summary>
        /// Insert and Update App Process Status
        /// </summary>
        /// <param name="pAppOrderID">pAppOrderID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pLogo">pLogo</param>
        /// <param name="pApp_Icon">pApp_Icon</param>
        /// <param name="pApp_Description">pApp_Description</param>
        /// <param name="splashCotent">splashCotent</param>
        /// <param name="appshortDesc">appshortDesc</param>
        /// <param name="pAppDisplayName">pAppDisplayName</param>
        /// <param name="pApp_Keywords">pApp_Keywords</param>
        /// <param name="pIOS_URL">pIOS_URL</param>
        /// <param name="pAndroid_URL">pAndroid_URL</param>
        /// <param name="pWindows_URL">pWindows_URL</param>
        /// <param name="pWebsite_URL">pWebsite_URL</param>
        /// <param name="pAppOrderStatusID">pAppOrderStatusID</param>
        /// <param name="pAssignedCSID">pAssignedCSID</param>
        /// <param name="pAppStoreIcon">pAppStoreIcon</param>
        /// <param name="pPrintableAppStoreIcon">pPrintableAppStoreIcon</param>
        /// <param name="pBackgroundIcon">pBackgroundIcon</param>
        public void Insert_Update_AppProcessStatus(int pAppOrderID, int pUserID, int pProfileID, string pLogo, string pApp_Icon, string pApp_Description, string splashCotent, string appshortDesc, string pAppDisplayName,
            string pApp_Keywords, string pIOS_URL, string pAndroid_URL, string pWindows_URL, string pWebsite_URL, int pAppOrderStatusID,
            int? pAssignedCSID, string pAppStoreIcon = "", string pPrintableAppStoreIcon = "", string pBackgroundIcon = "", string pQRCode_StoreUrl = "")
        {
            BusinessDAL.Insert_Update_AppProcessStatus(pAppOrderID, pUserID, pProfileID, pLogo, pApp_Icon, pApp_Description, splashCotent, appshortDesc, pAppDisplayName,
                pApp_Keywords, pIOS_URL, pAndroid_URL, pWindows_URL, pWebsite_URL, pAppOrderStatusID, pAssignedCSID, pAppStoreIcon, pPrintableAppStoreIcon, pBackgroundIcon, pQRCode_StoreUrl);
        }

        /// <summary>
        /// Insert and Update Checked App Process Status
        /// </summary>
        /// <param name="chkReplaceAppNameData">chkReplaceAppNameData</param>
        /// <param name="chkReplaceSlashData">chkReplaceSlashData</param>
        /// <param name="chkReplaceShortDescData">chkReplaceShortDescData</param>
        /// <param name="chkReplaceDescData">chkReplaceDescData</param>
        /// <param name="chkReplaceKeyWordsData">chkReplaceKeyWordsData</param>
        /// <param name="chkLogo">chkLogo</param>
        /// <param name="chkAppIcon">chkAppIcon</param>
        /// <param name="chkBackIcon">chkBackIcon</param>
        /// <param name="AppDisplayName">AppDisplayName</param>
        /// <param name="AppKeywords">AppKeywords</param>
        /// <param name="AppDescription">AppDescription</param>
        /// <param name="SplashContent">SplashContent</param>
        /// <param name="AppShortDescription">AppShortDescription</param>
        /// <param name="Logo">Logo</param>
        /// <param name="App_Icon">App_Icon</param>
        /// <param name="BackgroundIcon">BackgroundIcon</param>
        /// <param name="BrandedApp_OrderId">BrandedApp_OrderId</param>
        public void Insert_Update_CheckedAppProcessStatus(Boolean chkReplaceAppNameData, Boolean chkReplaceSlashData, Boolean chkReplaceShortDescData, Boolean chkReplaceDescData, Boolean chkReplaceKeyWordsData, Boolean chkLogo, Boolean chkAppIcon, Boolean chkBackIcon, Boolean chkReplaceAppUpdate, string AppDisplayName, string AppKeywords, string AppDescription, string SplashContent, string AppShortDescription, string AppUpdateNotes, string Logo, string App_Icon, string BackgroundIcon,
                int BrandedApp_OrderId)
        {
            BusinessDAL.Insert_Update_CheckedAppProcessStatus(chkReplaceAppNameData, chkReplaceSlashData, chkReplaceShortDescData, chkReplaceDescData, chkReplaceKeyWordsData, chkLogo, chkAppIcon, chkBackIcon, chkReplaceAppUpdate, AppDisplayName, AppKeywords, AppDescription, SplashContent, AppShortDescription, AppUpdateNotes, Logo, App_Icon, BackgroundIcon, BrandedApp_OrderId);
        }


        /// <summary>
        /// Insert and Update Branded App Additional Status
        /// </summary>
        /// <param name="BrandedApp_OrderId">BrandedApp_OrderId</param>
        /// <param name="StatusID">StatusID</param>
        /// <param name="BrandedApp_RequestID">BrandedApp_RequestID</param>
        public void usp_Insert_Update_BrandedAppAdditionalStatus(int BrandedApp_OrderId, int StatusID, int BrandedApp_RequestID)
        {
            BusinessDAL.usp_Insert_Update_BrandedAppAdditionalStatus(BrandedApp_OrderId, StatusID, BrandedApp_RequestID);
        }

        /// <summary>
        /// Get Manage Branded App Order Status
        /// </summary>
        /// <param name="pTabType">pTabType</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageBrandedAppOrderStatus(int pTabType, string pSearchText, string pVertical)
        {
            return BusinessDAL.GetManageBrandedAppOrderStatus(pTabType, pSearchText, pVertical);
        }

        /// <summary>
        /// Get Branded App Order Status Details
        /// </summary>
        /// <param name="pAppOrderStatusID">pAppOrderStatusID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppOrderStatusDetails(int pAppOrderStatusID)
        {
            return BusinessDAL.GetBrandedAppOrderStatusDetails(pAppOrderStatusID);
        }

        /// <summary>
        /// Change Branded App Order Status
        /// </summary>
        /// <param name="pAppOrderID">pAppOrderID</param>
        /// <param name="pStatusID">pStatusID</param>
        public void ChangeBrandedAppOrderStatus(int pAppOrderID, int pStatusID)
        {
            BusinessDAL.ChangeBrandedAppOrderStatus(pAppOrderID, pStatusID);
        }

        /// <summary>
        /// Get App Order Status By StatusID
        /// </summary>
        /// <param name="pStatusID">pStatusID</param>
        /// <param name="pTabType">pTabType</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppOrderStatusByStatusID(int pStatusID, int pTabType)
        {
            return BusinessDAL.GetAppOrderStatusByStatusID(pStatusID, pTabType);
        }

        /// <summary>
        /// Get Store Details By UserId
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>DataTable</returns>
        public DataTable GetStoreDetailsById(int UserId)
        {
            return BusinessDAL.GetStoreDetailsById(UserId);
        }

        /// <summary>
        /// Get Web links Categories
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetWeblinksCategories(int pProfileID)
        {
            return BusinessDAL.GetWebLinksCategories(pProfileID);
        }

        /// <summary>
        /// Insert and Update Web links Category
        /// </summary>
        /// <param name="pWebLinkCatID">pWebLinkCatID</param>
        /// <param name="pCatName">pCatName</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>Int</returns>
        public int Insert_Update_WeblinksCategory(int pWebLinkCatID, string pCatName, int pUserID, int pProfileID)
        {
            return BusinessDAL.Insert_Update_WeblinksCategory(pWebLinkCatID, pCatName, pUserID, pProfileID);
        }

        /// <summary>
        /// Get Manage Web link Categories
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageWeblinkCategories(int pProfileID)
        {
            return BusinessDAL.GetManageWeblinksCategories(pProfileID);
        }

        /// <summary>
        /// Delete Web link Category
        /// </summary>
        /// <param name="pWeblinkCategoryID">pWeblinkCategoryID</param>
        public void DeleteWeblinkCategory(int pWeblinkCategoryID)
        {
            BusinessDAL.DeleteWeblinkCategory(pWeblinkCategoryID);
        }

        /// <summary>
        /// Get Web link Category Details By ID
        /// </summary>
        /// <param name="pWeblinkCategoryID">pWeblinkCategoryID</param>
        /// <returns>DataTable</returns>
        public DataTable GetWeblinkCategoryDetailsByID(int pWeblinkCategoryID)
        {
            return BusinessDAL.GetWeblinkCategoryDetailsByID(pWeblinkCategoryID);
        }

        /// <summary>
        /// Get Branded App DeskNotes
        /// </summary>
        /// <param name="pBrandedAppOrderID">pBrandedAppOrderID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppDeskNotes(int pBrandedAppOrderID)
        {
            return BusinessDAL.GetBrandedAppDeskNotes(pBrandedAppOrderID);
        }

        /// <summary>
        /// Insert Branded App DeskNotes
        /// </summary>
        /// <param name="pBrandedAppID">pBrandedAppID</param>
        /// <param name="pNotes">pNotes</param>
        /// <param name="pNotes_by">pNotes_by</param>
        /// <param name="pAdminiUserName">pAdminiUserName</param>
        public void InsertBrandedAppDeskNotes(int pBrandedAppID, string pNotes, string pNotes_by, string pAdminiUserName)
        {
            BusinessDAL.InsertBrandedAppDeskNotes(pBrandedAppID, pNotes, pNotes_by, pAdminiUserName);
        }

        /// <summary>
        /// Get Profile Details
        /// </summary>
        /// <param name="criteria">criteria</param>
        /// <param name="criteriaType">criteriaType</param>
        /// <param name="userType">userType</param>
        /// <param name="isGenericApps">isGenericApps</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileDetails(string criteria, string criteriaType, string userType, bool isGenericApps, DateTime startDate, DateTime endDate)
        {
            return BusinessDAL.GetProfileDetails(criteria, criteriaType, userType, isGenericApps, startDate, endDate);
        }

        /// <summary>
        /// Select Inquiry Alerts
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="ContactID">ContactID</param>
        /// <returns>DataTable</returns>
        public DataTable SelectInquiryAlerts(int UserID, int ContactID)
        {
            return BusinessDAL.SelectInquiryAlerts(UserID, ContactID);
        }

        /// <summary>
        /// Insert User Custom Modules
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="module">module</param>
        /// <param name="appIcon">appIcon</param>
        /// <param name="tabName">tabName</param>
        /// <param name="isActive">isActive</param>
        /// <param name="createdDate">createdDate</param>
        /// <param name="modifyDate">modifyDate</param>
        /// <param name="expiredDate">expiredDate</param>
        /// <param name="manageUrl">manageUrl</param>
        /// <param name="isHasChilds">isHasChilds</param>
        /// <param name="pButtonType">pButtonType</param>
        /// <param name="purchaseType">purchaseType</param>
        /// <returns>Int</returns>
        public int InsertUserCustomModules(int ProfileID, int UserID, int createdUser, int module, string appIcon, string tabName, bool isActive,
            DateTime createdDate, DateTime modifyDate, DateTime expiredDate, string manageUrl, bool isHasChilds, string pButtonType = WebConstants.Tab_ContentAddOns, string purchaseType = WebConstants.Purchase_ContentAddOns)
        {
            return BusinessDAL.InsertUserCustomModules(ProfileID, UserID, createdUser, module, appIcon, tabName, isActive, createdDate, modifyDate, expiredDate, pButtonType, purchaseType, manageUrl, isHasChilds);
        }

        /// <summary>
        /// Checking default call addon exists for lite version
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>int</returns>
        public int CheckDefaultAddonForLite(int profileId, string buttonType)
        {
            return BusinessDAL.CheckDefaultAddonForLite(profileId, buttonType);
        }
        /// <summary>
        /// Dashboard Icons
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable DashboardIcons(int userID, bool isLitevVersion = false, string domain = null)
        {
            return BusinessDAL.DashboardIcons(userID, isLitevVersion, domain);
        }

        /// <summary>
        /// Update Short or Long Logo
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="isShortLogo">isShortLogo</param>
        public void UpdateShortorLongLogo(int userID, bool isShortLogo)
        {
            BusinessDAL.UpdateShortorLongLogo(userID, isShortLogo);
        }

        /// <summary>
        /// Get Send Notification By ID
        /// </summary>
        /// <param name="pushNotifyID">pushNotifyID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendNotificationByID(int pushNotifyID)
        {
            return BusinessDAL.GetSendNotificationByID(pushNotifyID);
        }

        /// <summary>
        /// Update Launch Play
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="playType">playType</param>
        public void UpdateLaunchPlay(int userID, string playType)
        {
            BusinessDAL.UpdateLaunchPlay(userID, playType);
        }

        #region  All Image Gallery Type Methods Nov (28/14)

        /// <summary>
        /// Insert Default Albums
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <param name="pUserID">pUserID</param>
        public void InsertDefaultAlbums(int pPID, int pUserID)
        {
            BusinessDAL.InsertDefaultAlbums(pPID, pUserID);
        }

        /// <summary>
        /// Insert and Update Album Details
        /// </summary>
        /// <param name="pAlbumID">pAlbumID</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pAlbumName">pAlbumName</param>
        /// <param name="pAlbumUniqueName">pAlbumUniqueName</param>
        /// <param name="pGalleryType">pGalleryType</param>
        /// <returns>Int</returns>
        public int Insert_Update_AlbumDetails(int pAlbumID, int pPID, int pUserID, string pAlbumName, string pAlbumUniqueName, string pGalleryType)
        {
            return BusinessDAL.Insert_Update_AlbumDetails(pAlbumID, pPID, pUserID, pAlbumName, pAlbumUniqueName, pGalleryType);
        }

        /// <summary>
        /// Get Active Albums By Gallery Type
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <param name="pGalleryType">pGalleryType</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveAlbumsByGalleryType(int pPID, string pGalleryType)
        {
            return BusinessDAL.GetActiveAlbumsByGalleryType(pPID, pGalleryType);
        }

        /// <summary>
        /// Get Album Details By AlbumID
        /// </summary>
        /// <param name="pAlbumID">pAlbumID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAlbumDetailsByAlbumID(int pAlbumID)
        {
            return BusinessDAL.GetAlbumDetailsByAlbumID(pAlbumID);
        }

        /// <summary>
        /// Delete Album
        /// </summary>
        /// <param name="pAlbumID">pAlbumID</param>
        public void DeleteAlbum(int pAlbumID)
        {
            BusinessDAL.DeleteAlbum(pAlbumID);
        }

        /// <summary>
        /// Get Gallery Images By AlbumID
        /// </summary>
        /// <param name="pAlbumID">pAlbumID</param>
        /// <returns>DataTable</returns>
        public DataTable GetGalleryImagesByAlbumID(int pAlbumID)
        {
            return BusinessDAL.GetGalleryImagesByAlbumID(pAlbumID);
        }

        /// <summary>
        /// Insert Gallery Images
        /// </summary>
        /// <param name="pImgName">pImgName</param>
        /// <param name="pImgUniqueName">pImgUniqueName</param>
        /// <param name="pImgCaption">pImgCaption</param>
        /// <param name="pAlbumID">pAlbumID</param>
        /// <param name="pOrderNo">pOrderNo</param>
        /// <param name="pUserID">pUserID</param>
        public void InsertGalleryImages(string pImgName, string pImgUniqueName, string pImgCaption, int pAlbumID, int pOrderNo, int pUserID)
        {
            BusinessDAL.InsertGalleryImages(pImgName, pImgUniqueName, pImgCaption, pAlbumID, pOrderNo, pUserID);
        }

        /// <summary>
        /// Delete Gallery Images by ImgID
        /// </summary>
        /// <param name="pImgID">pImgID</param>
        public void DeleteGalleryImagesbyImgID(int pImgID)
        {
            BusinessDAL.DeleteGalleryImagesbyImgID(pImgID);
        }

        /// <summary>
        /// Update Image OrderNo and Image Caption
        /// </summary>
        /// <param name="pImgID">pImgID</param>
        /// <param name="pImgOrderNo">pImgOrderNo</param>
        /// <param name="pImgCaption">pImgCaption</param>
        /// <param name="pUpdateColumnName">pUpdateColumnName</param>
        public void Update_ImgOrderNo_ImgCaption(int pImgID, int pImgOrderNo, string pImgCaption, string pUpdateColumnName)
        {
            BusinessDAL.Update_ImgOrderNo_ImgCaption(pImgID, pImgOrderNo, pImgCaption, pUpdateColumnName);
        }

        /// <summary>
        /// Checking Existed Image OrderNo
        /// </summary>
        /// <param name="pImgID">pImgID</param>
        /// <param name="pImgOrderNo">pImgOrderNo</param>
        /// <param name="pAlbumID">pAlbumID</param>
        /// <param name="pModeType">pModeType</param>
        /// <returns>Int</returns>
        public int CheckingExistedImgOrderNo(int pImgID, int pImgOrderNo, int pAlbumID, string pModeType)
        {
            return BusinessDAL.CheckingExistedImgOrderNo(pImgID, pImgOrderNo, pAlbumID, pModeType);
        }

        /// <summary>
        /// Get Root Album Details By Gallery Type
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <param name="pGalleryType">pGalleryType</param>
        /// <returns>DataTable</returns>
        public DataTable GetRootAlbumDetailsByGallerType(int pPID, string pGalleryType)
        {
            return BusinessDAL.GetRootAlbumDetailsByGallerType(pPID, pGalleryType);
        }

        #endregion

        /// <summary>
        /// Update Web Links Order
        /// </summary>
        /// <param name="LinkID">LinkID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="ID">ID</param>
        /// <returns>Int</returns>
        public int UpdateWebLinksOrder(int LinkID, int OrderNo, int ID)
        {
            return BusinessDAL.UpdateWebLinksOrder(LinkID, OrderNo, ID);
        }

        /// <summary>
        /// Get Web Links By UserID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetWebLinksByUserID(int UserID)
        {
            return BusinessDAL.GetWebLinksByUserID(UserID);
        }

        /// <summary>
        /// Get Custom Modules By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomModulesByUserID(int userID) //UserPermissions-Suneel
        {
            return BusinessDAL.GetCustomModulesByUserID(userID);
        }

        /// <summary>
        /// Delete Branded App By Id
        /// </summary>
        /// <param name="brandedOrderId">brandedOrderId</param>
        public void DeleteBrandedAppById(int brandedOrderId)
        {
            BusinessDAL.DeleteBrandedAppById(brandedOrderId);
        }

        /// <summary>
        /// Get All Parent Details
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllParentDetails()
        {
            return BusinessDAL.GetAllParentDetails();
        }

        /// <summary>
        /// Get All Approve Reject CC Users
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="itemId">itemId</param>
        /// <param name="type">type</param>
        /// <param name="assocUser">assocUser</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllApproveRejectCCUsers(int userID, int itemId, string type, int assocUser)
        {
            return BusinessDAL.GetAllApproveRejectCCUsers(userID, itemId, type, assocUser);
        }

        /// <summary>
        /// Get All Publishers of Item
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="itemType">itemType</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllPublishersofItem(int userID, string itemType, int pCustomID)
        {
            return BusinessDAL.GetAllPublishersofItem(userID, itemType, pCustomID);
        }

        /// <summary>
        /// Get App Stores Links
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppStoresLinks(int pPID)
        {
            return BusinessDAL.GetAppStoresLinks(pPID);
        }

        /// <summary>
        /// Get User Contact Group Names For Private Module
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="pGroupType">pGroupType</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserContactGroupNamesForPrivateModule(int userID, string pGroupType, int pUserModuleID)
        {
            return BusinessDAL.GetUserContactGroupNamesForPrivateModule(userID, pGroupType, pUserModuleID);
        }

        /// <summary>
        /// Get All User Contacts For Private Module
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <param name="selectType">selectType</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllUserContactsForPrivateModule(int userID, int checkFlag, string selectType, int pUserModuleID)
        {
            return BusinessDAL.GetAllUserContactsForPrivateModule(userID, checkFlag, selectType, pUserModuleID);
        }

        /// <summary>
        /// Check Valid User For Webnair
        /// </summary>
        /// <param name="emailAddress">emailAddress</param>
        /// <param name="schId">schId</param>
        /// <returns>String</returns>
        public string CheckValidUserForWebnair(string emailAddress, int schId)
        {
            return BusinessDAL.CheckValidUserForWebnair(emailAddress, schId);
        }

        /// <summary>
        /// Insert Webnair User
        /// </summary>
        /// <param name="schId">schId</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="phone">phone</param>
        /// <returns>Int</returns>
        public int InsertWebnairUser(int schId, string emailAddress, string firstName, string lastName, string phone)
        {
            return BusinessDAL.InsertWebnairUser(schId, emailAddress, firstName, lastName, phone);
        }

        /// <summary>
        /// Get Webnair Details
        /// </summary>
        /// <param name="schId">schId</param>
        /// <returns>DataTable</returns>
        public DataTable GetWebnairDetails(int schId)
        {
            return BusinessDAL.GetWebnairDetails(schId);
        }

        /// <summary>
        /// Update Modified date for BGImages
        /// </summary>
        /// <param name="profileId">profileId</param>
        public void UpdateModifieddateforBGImages(int profileId)
        {
            BusinessDAL.UpdateModifieddateforBGImages(profileId);
        }
        public void SaveProfileBGImage(int profileId, bool isActive, int modifiedUser)
        {
            BusinessDAL.SaveProfileBGImage(profileId, isActive, modifiedUser);
        }

        #region Canned Messages
        /// <summary>
        /// Get All Canned Messages
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllCannedMessages(int pPID)
        {
            return BusinessDAL.GetAllCannedMessages(pPID);
        }

        /// <summary>
        /// Insert Canned Message
        /// </summary>
        /// <param name="CannedMessageID">CannedMessageID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="MessageText">MessageText</param>
        /// <param name="CUserID">CUserID</param>
        /// <param name="MUserID">MUserID</param>
        /// <param name="CDate">CDate</param>
        /// <param name="MDate">MDate</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <returns>Int</returns>
        public int InsertCannedMessage(int CannedMessageID, int ProfileID, int UserID, string MessageText, int CUserID, int MUserID, DateTime CDate, DateTime MDate, bool IsDeleted)
        {
            return BusinessDAL.InsertCannedMessage(CannedMessageID, ProfileID, UserID, MessageText, CUserID, MUserID, CDate, MDate, IsDeleted);
        }

        /// <summary>
        /// Get Message By CannedID
        /// </summary>
        /// <param name="CannedMessageID">CannedMessageID</param>
        /// <returns>DataSet</returns>
        public DataSet GetMessageByCannedID(int CannedMessageID)
        {
            return BusinessDAL.GetMessageByCannedID(CannedMessageID);
        }

        #endregion
        /// <summary>
        /// Get User BannerAds
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserBannerAds(int profileId, bool IsLiteVersion = false)
        {
            return BusinessDAL.GetUserBannerAds(profileId, IsLiteVersion);
        }

        /// <summary>
        /// Update BannerAd App Display
        /// </summary>
        /// <param name="bananerAdId">bananerAdId</param>
        /// <param name="updateFlag">updateFlag</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void UpdateBannerAdAppDisplay(int bananerAdId, bool updateFlag, int modifiedUser)
        {
            BusinessDAL.UpdateBannerAdAppDisplay(bananerAdId, updateFlag, modifiedUser);
        }

        public void UpdateSponsorAdAppDisplay(int bananerAdId, bool updateFlag, int modifiedUser, bool IsAdMob, int OrderNo, string ProfileId)
        {
            BusinessDAL.UpdateSponsorAdAppDisplay(bananerAdId, updateFlag, modifiedUser, IsAdMob, OrderNo, ProfileId);
        }

        /// <summary>
        /// Insert BannerAds
        /// </summary>
        /// <param name="bannerAdId">bannerAdId</param>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="hyperlinkUrl">hyperlinkUrl</param>
        /// <param name="orderNo">orderNo</param>
        /// <param name="adTimeSpan">adTimeSpan</param>
        /// <param name="isAppDisplay">isAppDisplay</param>
        /// <param name="createdUser">createdUser</param>
        public void Insert_BannerAds(int bannerAdId, int profileId, int userId, string hyperlinkUrl, int orderNo, string adTimeSpan, bool isAppDisplay, int createdUser)
        {
            BusinessDAL.Insert_BannerAds(bannerAdId, profileId, userId, hyperlinkUrl, orderNo, adTimeSpan, isAppDisplay, createdUser);
        }

        public void Insert_SponsorAds(int bannerAdId, int profileId, int userId, string hyperlinkUrl, int orderNo, string adTimeSpan, bool isAppDisplay, int createdUser, bool IsAdMob)
        {
            BusinessDAL.Insert_SponsorAds(bannerAdId, profileId, userId, hyperlinkUrl, orderNo, adTimeSpan, isAppDisplay, createdUser, IsAdMob);
        }

        /// <summary>
        /// Get BannerAd By Id
        /// </summary>
        /// <param name="bannerAdId">bannerAdId</param>
        /// <returns>DataTable</returns>
        public DataTable GetBannerAdById(int bannerAdId)
        {
            return BusinessDAL.GetBannerAdById(bannerAdId);
        }

        /// <summary>
        /// Update BannerAd Delete
        /// </summary>
        /// <param name="bannerAdId">bannerAdId</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void UpdateBannerAdDelete(int bannerAdId, int modifiedUser)
        {
            BusinessDAL.UpdateBannerAdDelete(bannerAdId, modifiedUser);
        }

        /// <param name="modifiedUser">modifiedUser</param>
        public void UpdateSponsorAdDelete(int bannerAdId, int modifiedUser)
        {
            BusinessDAL.UpdateSponsorAdDelete(bannerAdId, modifiedUser);
        }

        /// <summary>
        /// Checking IsSponsor For BannerAds
        /// </summary>
        /// <param name="pAssociateUserID">pAssociateUserID</param>
        /// <returns>Boolean</returns>
        public bool CheckingIsSponsorForBannerAds(int pAssociateUserID)
        {
            return BusinessDAL.CheckingIsSponsorForBannerAds(pAssociateUserID);
        }


        #region Ser_SilentPushMessages
        /// <summary>
        /// Insert Silent Push Messages
        /// </summary>
        /// <param name="ProfileId">ProfileId</param>
        /// <param name="CreatedDate">CreatedDate</param>
        /// <param name="Sent_Flag">Sent_Flag</param>
        /// <param name="ContentType_Id">ContentType_Id</param>
        /// <param name="ContentType">ContentType</param>
        /// <param name="ActionType">ActionType</param>
        public void Insert_SilentPushMessages(int ProfileId, DateTime CreatedDate, bool Sent_Flag, int? ContentType_Id, string ContentType, string ActionType)
        {
            BusinessDAL.Insert_SilentPushMessages(ProfileId, CreatedDate, Sent_Flag, ContentType_Id, ContentType, ActionType);
        }



        #endregion

        /// <summary>
        /// Get Button Details
        /// </summary>
        /// <param name="pInvitationID">pInvitationID</param>
        /// <param name="pUniqueID">pUniqueID</param>
        /// <returns>DataTable</returns>
        public DataTable GetButtonDetails(int pInvitationID, string pUniqueID)
        {
            return BusinessDAL.GetButtonDetails(pInvitationID, pUniqueID);
        }

        #region Check Branded App

        /// <summary>
        /// Get Business Profile By ProfileID
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessProfileByProfileID(int ProfileID)
        {
            return BusinessDAL.GetBusinessProfileByProfileID(ProfileID);
        }
        #endregion

        /// <summary>
        /// Insert Update BrandedApp Request
        /// </summary>
        /// <param name="pAppRequestID">pAppRequestID</param>
        /// <param name="pAppOrderID">pAppOrderID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pLogo">pLogo</param>
        /// <param name="pApp_Icon">pApp_Icon</param>
        /// <param name="pApp_Description">pApp_Description</param>
        /// <param name="pApp_SplashCotent">pApp_SplashCotent</param>
        /// <param name="appshortDesc">appshortDesc</param>
        /// <param name="pAppDisplayName">pAppDisplayName</param>
        /// <param name="pApp_Keywords">pApp_Keywords</param>
        /// <param name="pAppOrderStatusID">pAppOrderStatusID</param>
        /// <param name="pAssignedCSID">pAssignedCSID</param>
        /// <param name="pRequestAction">pRequestAction</param>
        /// <param name="pLogoNotes">pLogoNotes</param>
        /// <param name="pAppNameNotes">pAppNameNotes</param>
        /// <param name="pSplashNotes">pSplashNotes</param>
        /// <param name="pShortDescNotes">pShortDescNotes</param>
        /// <param name="pDescNotes">pDescNotes</param>
        /// <param name="pKeywordsNotes">pKeywordsNotes</param>
        /// <param name="pAppStoreIcon">pAppStoreIcon</param>
        /// <param name="pPrintableAppStoreIcon">pPrintableAppStoreIcon</param>
        /// <param name="pBackgroundIcon">pBackgroundIcon</param>
        public void InsertUpdateBrandedAppRequest(int pAppRequestID, int pAppOrderID, int pUserID, int pProfileID, string pLogo, string pApp_Icon, string pApp_Description, string pApp_SplashCotent, string appshortDesc, string pAppDisplayName,
            string pApp_Keywords, string pAppUpdate, int pAppOrderStatusID, int? pAssignedCSID, string pRequestAction, string pLogoNotes, string pAppNameNotes, string pSplashNotes, string pShortDescNotes, string pDescNotes, string pKeywordsNotes, string pAppUpdateNotes,
            string pAppStoreIcon = "", string pPrintableAppStoreIcon = "", string pBackgroundIcon = "")
        {
            BusinessDAL.Insert_Update_BrandedAppRequest(pAppRequestID, pAppOrderID, pUserID, pProfileID, pLogo, pApp_Icon, pApp_Description, pApp_SplashCotent, appshortDesc, pAppDisplayName,
                pApp_Keywords, pAppUpdate, pAppOrderStatusID, pAssignedCSID, pRequestAction, pLogoNotes, pAppNameNotes, pSplashNotes, pShortDescNotes, pDescNotes, pKeywordsNotes, pAppUpdateNotes, pAppStoreIcon, pPrintableAppStoreIcon, pBackgroundIcon);
        }

        /// <summary>
        /// Get App Order Status By BrandedApp RequestID
        /// </summary>
        /// <param name="BrandedApp_RequestID">BrandedApp_RequestID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppOrderStatusByBrandedAppRequestID(int BrandedApp_RequestID)
        {
            return BusinessDAL.GetAppOrderStatusByBrandedAppRequestID(BrandedApp_RequestID);
        }

        /// <summary>
        /// Get Unique ProfileID
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetUniqueProfileID()
        {
            return BusinessDAL.GetUniqueProfileID();
        }
        /// <summary>
        /// Get Total SMS Optins and call module contacts
        /// </summary>
        /// <returns>int</returns>
        public int GetCallTotalSMSOptIns(int profileId)
        {
            return BusinessDAL.GetCallTotalSMSOptIns(profileId);
        }
        public DataTable GetISAUpgradeUsers(int pProfileID)
        {
            return BusinessDAL.GetISAUpgradeUsers(pProfileID);
        }

        public int CheckUserNameandDomainForUpgradeUser(string username, string vertical, string country)
        {
            return BusinessDAL.CheckUserNameandDomainForUpgradeUser(username, vertical, country);
        }

        public int ShowMessageForISAUpgrade(int pPID)
        {
            return BusinessDAL.ShowMessageForISAUpgrade(pPID);
        }



        public DataTable GetWebLinksByCategoryID(int lnkWeblinkCategory_ID)
        {
            return BusinessDAL.GetWebLinksByCategoryID(lnkWeblinkCategory_ID);
        }

        /// <summary>
        /// InsertApprovalProccessDetails /*** July 26 2016  ***/
        /// </summary>
        /// <param name="remarks"></param>
        /// <param name="Publish_Date"></param>
        /// <param name="Uid"></param>
        /// <param name="Initials"></param>
        /// <param name="Modified_Date"></param>
        /// <param name="UserId"></param>
        /// <param name="surveyID"></param>
        /// <param name="hdnProcess"></param>
        /// <param name="IDType"></param>
        /// <param name="BusinessUpdateID"></param>
        /// <param name="EventId"></param>
        /// <param name="CustomID"></param>
        /// <param name="CalenderType"></param>
        /// <param name="BulletinID"></param>
        /// <returns></returns>
        public void InsertApprovalProccessDetails(string remarks, DateTime Publish_Date, int Uid, string Initials, int? UserID, int surveyID, string hdnProcess, string IDType, int BusinessUpdateID, int EventId, int CustomID, string CalenderType, int BulletinID)
        {
            BusinessDAL.InsertApprovalProccessDetails(remarks, Publish_Date, Uid, Initials, UserID, surveyID, hdnProcess, IDType, BusinessUpdateID, EventId, CustomID, CalenderType, BulletinID);
        }


        public DataTable GetSponsorAdUsers()
        {
            return BusinessDAL.GetSponsorAdUsers();
        }
        public DataTable getManageContentActivityLogs(string vertical, int Start, int End, int profileID = 0)
        {
            return BusinessDAL.getManageContentActivityLogs(vertical, Start, End, profileID);
        }

        public DataTable GetManageLogByActivityID(int ActivityID = 0, string DomainName = "")
        {
            return BusinessDAL.GetManageLogByActivityID(ActivityID, DomainName);
        }


        public void UpdateRecurringDetails(int subOrderID, decimal discount, decimal billableAmt, decimal totalAmt, int cUserID, DateTime expirationDate, string discountCode, int subPeriod)
        {
            BusinessDAL.UpdateRecurringDetails(subOrderID, discount, billableAmt, totalAmt, cUserID, expirationDate, discountCode, subPeriod);
        }
        public void Insert_Update_AppProcessStatus(int pAppOrderID, int pUserID, int pProfileID, string pLogo, string pApp_Icon, string pApp_Description, string splashCotent, string appshortDesc,
            string pApp_Keywords, string pIOS_URL, string pAndroid_URL, string pWindows_URL, string pWebsite_URL, int pAppOrderStatusID, int pAssignedCSID)
        {
            BusinessDAL.Insert_Update_AppProcessStatus(pAppOrderID, pUserID, pProfileID, pLogo, pApp_Icon, pApp_Description, splashCotent, appshortDesc,
                pApp_Keywords, pIOS_URL, pAndroid_URL, pWindows_URL, pWebsite_URL, pAppOrderStatusID, pAssignedCSID);
        }
        public DataTable GetOrderDetailsByProfileID_RequestType(int pPID, int pRequestTypeID)
        {
            return BusinessDAL.GetOrderDetailsByProfileID_RequestType(pPID, pRequestTypeID);
        }
        public void InsertUpdateBillingInfo(string Name, string LastName, string BillingEmail, string Address1, string Address2, string CityCapital, string City, string Zipcode, int UserID, int ProfileID, int BillingInfoID, int AddressId = 0)
        {
            BusinessDAL.InsertUpdateBillingInfo(Name, LastName, BillingEmail, Address1, Address2, CityCapital, City, Zipcode, UserID, ProfileID, BillingInfoID, AddressId);
        }
        public DataTable GetInvoiceDetailsbyUserID(int userID)
        {
            return BusinessDAL.GetInvoiceDetailsbyUserID(userID);
        }

        #region Store Module Functionality
        public bool CheckModulePermission(string ButtonType, int ProfileID)
        {
            return BusinessDAL.CheckModulePermission(ButtonType, ProfileID);
        }
        #endregion

        public DataTable CaliculateAmount(int PackageID)
        {
            return BusinessDAL.CaliculateAmount(PackageID);
        }
        public void UpdateMemorySpace(int profileID, int createdUser, int size)
        {
            BusinessDAL.UpdateMemorySpace(profileID, createdUser, size);
        }

        public int InsertPackageItem(string domainName, string buttonType, string accessType, int orderDetailsId, DateTime renewalDate, int profileID, int userID)
        {
            return BusinessDAL.InsertPackageItem(domainName, buttonType, accessType, orderDetailsId, renewalDate, profileID, userID);
        }

        public void InsertPurchaseAddons(int profileID, int userID, int cUserID, string purchaseType)
        {
            BusinessDAL.InsertPurchaseAddons(profileID, userID, cUserID, purchaseType);
        }
        public void EnableSMSSetup(int profileId)
        {
            BusinessDAL.EnableSMSSetup(profileId);
        }

        public DataTable GetSearchSubAppsByUserID_EmailID(int pUserID, string pEmailID, string pVertical)
        {
            return BusinessDAL.GetSearchSubAppsByUserID_EmailID(pUserID, pEmailID, pVertical);
        }
        public void InsertSubAppInvitationRequest(int pParentProfileID, int pProfileID, string pNotes, int pUserID)
        {
            BusinessDAL.InsertSubAppInvitationRequest(pParentProfileID, pProfileID, pNotes, pUserID);
        }
        public DataTable GetSubAppsByInvitationID(int pProfileID, int pInvitationID)
        {
            return BusinessDAL.GetSubAppsByInvitationID(pProfileID, pInvitationID);
        }

        public void UpdateSubAppInvitationRequest(int pInvitationID, int pProfileID, string pStatus, string pNotes)
        {
            BusinessDAL.UpdateSubAppInvitationRequest(pInvitationID, pProfileID, pStatus, pNotes);
        }
        public DataTable GetSubAppsByParentID(int pParentProfileID, string searchTag, out int totalAffiliates)
        {
            return BusinessDAL.GetSubAppsByParentID(pParentProfileID, searchTag, out totalAffiliates);
        }

        public DataTable GetBillInfoDetailsByProfileID(int profileid)
        {
            return BusinessDAL.GetBillInfoDetailsByProfileID(profileid);
        }
        public DataTable GetPaymentBillingInfo(int profileID)
        {
            return BusinessDAL.GetPaymentBillingInfo(profileID);
        }
        public bool ValidateUserSubApp(int profileId)
        {
            return BusinessDAL.ValidateUserSubApp(profileId);
        }

        /***************************** SmartConnect Categories Feb 06 2017 ************************************************/

        public DataTable GetSmartConnectCategories(int pUserModuleID, string pDomainName, int pProfileID)
        {
            return BusinessDAL.GetSmartConnectCategories(pUserModuleID, pDomainName, pProfileID);
        }

        public void DeleteSmartConnectCategory(int pCategoryID, int pUserID, int pProfileID)
        {
            BusinessDAL.DeleteSmartConnectCategory(pCategoryID, pUserID, pProfileID);
        }

        public int Insert_Update_SmartConnectCategory(int pCategoryID, string pCatName, string pDescription,
            int pUserModuleID, int pProfileID, int pUserID, string pCategoryType)
        {

            return BusinessDAL.Insert_Update_SmartConnectCategory(pCategoryID, pCatName, pDescription, pUserModuleID, pProfileID, pUserID, pCategoryType);
        }

        public DataTable GetSmartConnectCategoryDetailsByID(int pCategoryID)
        {
            return BusinessDAL.GetSmartConnectCategoryDetailsByID(pCategoryID);
        }

        public DataSet ViewMessageHistoryDetailsByID(int pMessageHistoryID, string pButtonType, int pProfileID)
        {
            return BusinessDAL.ViewMessageHistoryDetailsByID(pMessageHistoryID, pButtonType, pProfileID);
        }

        public DataTable GetAssociateUsersForMessageDetails(int pUserID, int pUMID, string pButtonType, int pMessageHistoryID)
        {
            return BusinessDAL.GetAssociateUsersForMessageDetails(pUserID, pUMID, pButtonType, pMessageHistoryID);
        }

        public void Insert_ReplyHistory_Notes(string pNotes, string pReplyEmailIDs, int pUserID, int pMessageHistoryID, string pButtonType, bool pIsSender)
        {
            BusinessDAL.Insert_ReplyHistory_Notes(pNotes, pReplyEmailIDs, pUserID, pMessageHistoryID, pButtonType, pIsSender);
        }

        //Assigning Category to SmartConnect Messages
        public void AssignCategoryMessage(int CallAddOnsHistoryID, int CategoryID)
        {
            BusinessDAL.AssignCategoryMessage(CallAddOnsHistoryID, CategoryID);
        }

        //Search the SmartConnectMessage by using startdate,enddate,category,text
        public DataSet GetSmartConnectSearch(string CategoryID, string searchText, int ProfileID, bool IsArchive, DateTime? startDate = null, DateTime? endDate = null)
        {
            return BusinessDAL.GetSmartConnectSearch(CategoryID, searchText, ProfileID, IsArchive, startDate, endDate);
        }

        public DataTable GetPieChartDataForSmartConnectMessages(int ProfileID, bool IsArchive, int? GraphCurrentArchive = null)
        {
            return BusinessDAL.GetPieChartDataForSmartConnectMessages(ProfileID, IsArchive, GraphCurrentArchive);
        }

        public DataTable GetSmartConnectCategoriesList(int ProfileID, int UserModuleID)
        {
            return BusinessDAL.GetSmartConnectCategoriesList(ProfileID, UserModuleID);
        }
        public DataTable GetModuleItemsCount(int ProfileID, int UserId)
        {
            return BusinessDAL.GetModuleItemsCount(ProfileID, UserId);
        }

        public DataTable GetContactsbyHistoryID(int HistoryId, string pButtonType)
        {
            return BusinessDAL.GetContactsbyHistoryID(HistoryId, pButtonType);
        }

        public DataTable CheckingModuleExists(int pProfileID, string pButtonType)
        {
            return BusinessDAL.CheckingModuleExists(pProfileID, pButtonType);
        }


        public int UserCustomizeSettings(int CustomizeSettingsID, int ProfileID, int UserID, string PageType, string XMLValue, int UserModuleID = 0)
        {
            return BusinessDAL.UserCustomizeSettings(CustomizeSettingsID, ProfileID, UserID, PageType, XMLValue, UserModuleID);
        }

        public DataTable GetReadPublicCalls(int ProfileID, bool IsRead, bool IsArchive)
        {
            return BusinessDAL.GetReadPublicCalls(ProfileID,IsRead,IsArchive);
        }

        public DataTable GetDisplayReadFirst(int ProfileID, string PageType, int UserModuleID = 0)
        {
            return BusinessDAL.GetDisplayReadFirst(ProfileID, PageType,UserModuleID);
        }

        public DataTable GetPrepoulatesettings(int ProfileID, string PageType)
        {
            return BusinessDAL.GetPrepoulatesettings(ProfileID, PageType);
        }
    }
}
