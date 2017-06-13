using System;
using System.Data;
using System.Net;
using System.Web;
using USPDHUBDAL;
using System.IO;
using System.Configuration;
using Winnovative.HtmlToPdfClient;


namespace USPDHUBBLL
{
    public class AdminBLL
    {
        /// <summary>
        /// Get Users Data
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="ddlSelectValue">ddlSelectValue</param>
        /// <param name="type">type</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>DataTable</returns>
        public DataTable GetUsersData(string searchText, string ddlSelectValue, bool type, string vertical, string country)
        {
            return USPDHUBDAL.AdminDAL.GetUsersData(searchText, ddlSelectValue, type, vertical, country);
        }

        //public DataTable GetUserDetails(string username)
        //{
        //    return USPDHUBDAL.AdminDAL.GetUserDetails(username);
        //}

        /// <summary>
        /// Validating Consumer by using username and password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>DataTable</returns>
        public DataTable ValidateConsumer(string username, string password)
        {
            return USPDHUBDAL.AdminDAL.ValidateConsumer(username, password);
        }

        /// <summary>
        /// Get Admin User Details by using username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>DataTable</returns>
        public DataTable GetAdminUserDetails(string username)
        {
            return USPDHUBDAL.AdminDAL.GetAdminUserDetails(username);
        }

        /// <summary>
        /// Get User Details by using UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetailsByID(int userID)
        {
            return USPDHUBDAL.AdminDAL.GetUserDetailsByID(userID);
        }

       
        /// <summary>
        /// Fill Subscription Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillSubscriptionData()
        {
            return USPDHUBDAL.AdminDAL.FillSubscriptionData();
        }

        /// <summary>
        /// Fill Users Data 
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>DataTable</returns>
        public DataTable FillUsersData(bool type)
        {
            return USPDHUBDAL.AdminDAL.FillUsersData(type);
        }

        /// <summary>
        /// Fill Industry Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillIndustryData()
        {
            return USPDHUBDAL.AdminDAL.FillIndustryData();
        }

        /// <summary>
        /// Get Industry Data
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="ddlSelectValue">ddlSelectValue</param>
        /// <returns>DataTable</returns>
        public DataTable GetIndustryData(string searchText, string ddlSelectValue)
        {
            return USPDHUBDAL.AdminDAL.GetIndustryData(searchText, ddlSelectValue);
        }
        
        /// <summary>
        /// Delete User Record
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="userID">userID</param>
        /// <param name="ipAddress">ipAddress</param>
        /// <returns>Int</returns>
        public int DeleteUsersRecord(int uid, int userID, string ipAddress)
        {
            return USPDHUBDAL.AdminDAL.DeleteUsersRecord(uid, userID, ipAddress);
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
        /// <param name="status">status</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="userid">userid</param>
        /// <param name="isFree">isFree</param>
        /// <returns>Int</returns>
        public int AddConsumer(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string status, string zipcode, string phone, int userid, bool isFree)
        {
            return USPDHUBDAL.AdminDAL.AddConsumer(username, password, email, firstname, lastname, pswdQ1, pswdA1, pswdQ2, pswdA2, roleId, isActive, addr1, addr2, city, state, country, status, zipcode, phone, userid, isFree);
        }

        /// <summary>
        /// Subscription Updates
        /// </summary>
        /// <param name="subscriptionID">subscriptionID</param>
        /// <param name="subscriptionPeriod">subscriptionPeriod</param>
        /// <param name="subscriptionName">subscriptionName</param>
        /// <param name="subscriptionDesc">subscriptionDesc</param>
        /// <param name="subscriptionPrice">subscriptionPrice</param>
        /// <param name="subscriptionType">subscriptionType</param>
        /// <param name="userName">userName</param>
        /// <param name="activeFlag">activeFlag</param>
        public void AddSubscription(string subscriptionID, string subscriptionPeriod, string subscriptionName, string subscriptionDesc, string subscriptionPrice, string subscriptionType, string userName, bool activeFlag)
        {
            USPDHUBDAL.AdminDAL.AddSubscription(subscriptionID, subscriptionPeriod, subscriptionName, subscriptionDesc, subscriptionPrice, subscriptionType, userName, activeFlag);
        }

        /// <summary>
        /// Get Subscription Details
        /// </summary>
        /// <param name="typeID">typeID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSubscriptionDetails(int typeID)
        {
            return USPDHUBDAL.AdminDAL.GetSubscriptionDetails(typeID);
        }

        /// <summary>
        /// Add Industry
        /// </summary>
        /// <param name="industryid">industryid</param>
        /// <param name="industryName">industryName</param>
        /// <param name="industryCategory">industryCategory</param>
        /// <param name="username">username</param>
        /// <param name="industryDescription">industryDescription</param>
        /// <param name="industryKeyWord">industryKeyWord</param>
        /// <param name="activeFlag">activeFlag</param>
        public void AddIndustry(string industryid, string industryName, string industryCategory, string username, string industryDescription, string industryKeyWord, bool activeFlag)
        {
            USPDHUBDAL.AdminDAL.AddIndustry(industryid, industryName, industryCategory, username, industryDescription, industryKeyWord, activeFlag);
        }

        /// <summary>
        /// Industry Update
        /// </summary>
        /// <param name="industryid">industryid</param>
        /// <returns>DataTable</returns>
        public DataTable GetIndustryDetails(string industryid)
        {
            return USPDHUBDAL.AdminDAL.GetIndustryDetails(industryid);
        }

        /// <summary>
        /// Bussiness Link Name Search
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <returns>DataTable</returns>
        public DataTable BussinessLinkNameSearch(string searchText)
        {
            return USPDHUBDAL.AdminDAL.BussinessLinkNameSearch(searchText);
        }

        /// <summary>
        /// Insert Update in Bussiness Link  
        /// </summary>
        /// <param name="bLinkID">bLinkID</param>
        /// <param name="bLinkName">bLinkName</param>
        /// <param name="bLinkUrl">bLinkUrl</param>
        /// <param name="blinkDesc">blinkDesc</param>
        /// <param name="userName">userName</param>
        /// <param name="activeFlag">activeFlag</param>
        public void AddBussinessLink(string bLinkID, string bLinkName, string bLinkUrl, string blinkDesc, string userName, bool activeFlag)
        {
            USPDHUBDAL.AdminDAL.AddBussinessLink(bLinkID, bLinkName, bLinkUrl, blinkDesc, userName, activeFlag);
        }

        /// <summary>
        /// Get Bussiness Link Deatails
        /// </summary>
        /// <param name="bLinkID">bLinkID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessLinksDetails(string bLinkID)
        {
            return USPDHUBDAL.AdminDAL.GetBusinessLinksDetails(bLinkID);
        }

        /// <summary>
        /// Fill Bessiness Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillBussinessData()
        {
            return USPDHUBDAL.AdminDAL.FillBussinessData();
        }

        #region Start Discount Code
        /// <summary>
        /// DiscountCode Fill Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillDiscountData()
        {
            return USPDHUBDAL.AdminDAL.FillDiscountData();
        }

        /// <summary>
        /// Get Discount Code Details
        /// </summary>
        /// <param name="discountCodeID">discountCodeID</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiscountCodeDetails(string discountCodeID)
        {
            return USPDHUBDAL.AdminDAL.GetDiscountCodeDetails(discountCodeID);
        }

        /// <summary>
        /// DiscountCode search
        /// </summary>
        /// <param name="searchCode">searchCode</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiscountData(string searchCode)
        {
            return USPDHUBDAL.AdminDAL.GetDiscountData(searchCode);
        }
        #endregion

        /// <summary>
        /// Update InActive flag By profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int UpdateInActiveflagByprofileID(int profileID)
        {
            return USPDHUBDAL.AdminDAL.UpdateInActiveflagByprofileID(profileID);
        }

        /// <summary>
        /// Update Active flag By profileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int UpdateActiveflagByprofileID(int profileID)
        {
            return USPDHUBDAL.AdminDAL.UpdateActiveflagByprofileID(profileID);
        }

        /// <summary>
        /// Update Business Profile Details
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="websitename">websitename</param>
        /// <param name="description">description</param>
        /// <param name="contactname">contactname</param>
        /// <param name="bdays">bdays</param>
        /// <param name="bhours">bhours</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="categories">categories</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="fax">fax</param>
        /// <param name="templatename">templatename</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int UpdateBusinessProfileDetails(string buzname, string websitename, string description, string contactname, string bdays, string bhours, string address1, string address2, string city, string state, string categories, string zipcode, string phone1, string fax, string templatename, int userid, int profileid)
        {
            return USPDHUBDAL.AdminDAL.UpdateBusinessProfileDetails(buzname, websitename, description, contactname, bdays, bhours, address1, address2, city, state, categories, zipcode, phone1, fax, templatename, userid, profileid);
        }

        /// <summary>
        /// Get Profile Details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileDetailsByProfileID(int profileID)
        {
            return USPDHUBDAL.AdminDAL.GetProfileDetailsByProfileID(profileID);
        }

        /// <summary>
        /// Fill Profile Active Data
        /// </summary>
        /// <param name="isactive">isactive</param>
        /// <returns>DataTable</returns>
        public DataTable FillProfileActiveData(int isactive)
        {
            return USPDHUBDAL.AdminDAL.FillProfileActiveData(isactive);
        }

        /// <summary>
        /// Search InActive profiles
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="ddlSelectValue">ddlSelectValue</param>
        /// <returns>DataTable</returns>
        public DataTable SearchInActiveprofiles(string searchText, string ddlSelectValue)
        {
            return USPDHUBDAL.AdminDAL.SearchInActiveprofiles(searchText, ddlSelectValue);
        }

        /// <summary>
        /// Search profiles
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="ddlSelectValue">ddlSelectValue</param>
        /// <returns>DataTable</returns>
        public DataTable Searchprofiles(string searchText, string ddlSelectValue)
        {
            return USPDHUBDAL.AdminDAL.Searchprofiles(searchText, ddlSelectValue);
        }
        
        /// <summary>
        /// Fill Ads Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillAdsData()
        {
            return USPDHUBDAL.AdminDAL.FillAdsData();
        }

        /// <summary>
        /// Insert Update in Ads Slots   slotID.ToString(), Pname, Maxislots, Avaliableslots, slotcost,
        /// </summary>
        /// <param name="slotID">slotID</param>
        /// <param name="pname">pname</param>
        /// <param name="maxislots">maxislots</param>
        /// <param name="avaliableslots">avaliableslots</param>
        /// <param name="slotcost">slotcost</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="userName">userName</param>
        public void AddAdsSlots(string slotID, string pname, string maxislots, string avaliableslots, string slotcost, bool activeFlag, string userName)
        {
            USPDHUBDAL.AdminDAL.AddAdsSlots(slotID, pname, maxislots, avaliableslots, slotcost, activeFlag, userName);
        }
        
        /// <summary>
        /// Get Ads Details
        /// </summary>
        /// <param name="slotID">slotID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAdsDetails(string slotID)
        {
            return USPDHUBDAL.AdminDAL.GetAdsDetails(slotID);
        }

        /// <summary>
        /// Fill WordFilter Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillWordFilterData()
        {
            return USPDHUBDAL.AdminDAL.FillWordFilterData();
        }

        /// <summary>
        /// Get Word Filter Details
        /// </summary>
        /// <param name="wordID">wordID</param>
        /// <returns>DataTable</returns>
        public DataTable GetWordFilterDetails(string wordID)
        {
            return USPDHUBDAL.AdminDAL.GetWordFilterDetails(wordID);
        }

        /// <summary>
        /// Admin Alerts methods
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetActiveTemplates()
        {
            return USPDHUBDAL.AdminDAL.GetActiveTemlates();
        }

        /// <summary>
        /// Get group names
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable Getgroupnames()
        {
            return USPDHUBDAL.AdminDAL.Getgroupnames();

        }

        /// <summary>
        /// Add Alert Template
        /// </summary>
        /// <param name="templateId">templateId</param>
        /// <param name="alertGroup">alertGroup</param>
        /// <param name="subject">subject</param>
        /// <param name="eventname">eventname</param>
        /// <param name="message">message</param>
        /// <param name="fromdate">fromdate</param>
        /// <param name="todate">todate</param>
        /// <param name="destType">destType</param>
        /// <param name="userid">userid</param>
        /// <param name="eventWinner">eventWinner</param>
        /// <param name="filter">filter</param>
        /// <returns>Int</returns>
        public int AddAlertTemplate(int templateId, string alertGroup, string subject, string eventname, string message, DateTime fromdate, DateTime todate, string destType, int userid, bool eventWinner, string filter)
        {
            return USPDHUBDAL.AdminDAL.AddAlertTemplate(templateId, alertGroup, subject, eventname, message, fromdate, todate, destType, userid, eventWinner, filter);
        }

        /// <summary>
        /// Get Active Template By TemplateID
        /// </summary>
        /// <param name="templateID">templateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveTemplateByTemplateID(int templateID)
        {
            return USPDHUBDAL.AdminDAL.GetActiveTemplateByTemplateID(templateID);

        }

        /// <summary>
        /// Send alert to Rocklin Users
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable Rocklinusers()
        {
            return USPDHUBDAL.AdminDAL.Rocklinusers();
        }

        /// <summary>
        /// Get Sales Report
        /// </summary>
        /// <param name="sqlQuery">sqlQuery</param>
        /// <returns>DataTable</returns>
        public DataTable Getsalesdetails(string sqlQuery)
        {
            return USPDHUBDAL.AdminDAL.Getsalesdetails(sqlQuery);
        }

        /// <summary>
        /// Get event names
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable Geteventnames()
        {
            return USPDHUBDAL.AdminDAL.Geteventnames();

        }
        
        /// <summary>
        /// Get template by TemplateId 
        /// </summary>
        /// <param name="templateID">templateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTemplateByTemplateID(int templateID)
        {
            return USPDHUBDAL.AdminDAL.GetTemplateByTemplateID(templateID);

        }

        /// <summary>
        /// Get Reseller Details by User ProfileId
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetResellerDetailsbyUserProfileId(int profileId)
        {
            return USPDHUBDAL.AdminDAL.GetResellerDetailsbyUserProfileId(profileId);
        }

        /// <summary>
        /// Get Login Details by UserID
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="fromdate">fromdate</param>
        /// <param name="todate">todate</param>
        /// <returns>DataTable</returns>
        public DataTable GetLoginDetailsbyUserID(int userid, string fromdate, string todate)
        {
            return USPDHUBDAL.AdminDAL.GetLoginDetailsbyUserID(userid, fromdate, todate);
        }

        #region Page Traffic Report
        /// <summary>
        /// Get Page Traffic Report For Admin
        /// </summary>
        /// <param name="queryString">queryString</param>
        /// <returns>DataTable</returns>
        public DataTable GetPageTrafficReportForAdmin(string queryString)
        {
            return USPDHUBDAL.AdminDAL.GetPageTrafficReportForAdmin(queryString);
        }

        #endregion

        /// <summary>
        /// Get Reg order details by ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetRegorderdetailsbyProfileID(int profileID)
        {
            return USPDHUBDAL.AdminDAL.GetRegorderdetailsbyProfileID(profileID);
        }

        /// <summary>
        /// Insert and Update Business Type
        /// </summary>
        /// <param name="bid">bid</param>
        /// <param name="businesstype">businesstype</param>
        /// <param name="status">status</param>
        /// <returns>Int</returns>
        public int InsertUpdateBusinessType(int bid, string businesstype, bool status)
        {
            return USPDHUBDAL.AdminDAL.InsertUpdateBusinessType(bid, businesstype, status);
        }

        /// <summary>
        /// Get Business Type Usability Count
        /// </summary>
        /// <param name="bid">bid</param>
        /// <returns>Int</returns>
        public int GetBusinessTypeUsabilityCount(int bid)
        {
            return USPDHUBDAL.AdminDAL.GetBusinessTypeUsabilityCount(bid);
        }

        /// <summary>
        /// Get Business Type details By ID
        /// </summary>
        /// <param name="bid">bid</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessTypedetailsByID(int bid)
        {
            return USPDHUBDAL.AdminDAL.GetBusinessTypedetailsByID(bid);
        }

        /// <summary>
        /// Get all Business Types
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetallBusinessTypes()
        {
            return USPDHUBDAL.AdminDAL.GetallBusinessTypes();
        }

        // *** Start Get User Details based on registrtion type  ***//
        /// <summary>
        /// Fill Users Data
        /// </summary>
        /// <param name="regType">regType</param>
        /// <returns>DataTable</returns>
        public DataTable FillUsersData(int regType)
        {
            return USPDHUBDAL.AdminDAL.FillUsersData(regType);
        }
        // *** End Get User Details based on registrtion type *** //    
    
        // *** From Anand *** //
        /// <summary>
        /// Fill Users Analysis Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillUsersAnalysisData()
        {
            return USPDHUBDAL.AdminDAL.FillAnalysisUsersData();
        }

        /// <summary>
        /// Insert Customer DeskNotes Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="notes">notes</param>
        /// <param name="adminUserName">adminUserName</param>
        /// <param name="notesBy">notesBy</param>
        /// <returns>Int</returns>
        public int InsertCustomerDeskNotesDetails(int userID, string notes, string adminUserName, string notesBy)
        {
            return USPDHUBDAL.AdminDAL.InsertCustomerDeskNotesDetails(userID, notes, adminUserName, notesBy);
        }

        /// <summary>
        /// Get Customer DeskNotes Details By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomerDeskNotesDetailsByUser_ID(int userID)
        {
            return USPDHUBDAL.AdminDAL.GetCustomerDeskNotesDetailsByUser_ID(userID);
        }

        /// <summary>
        /// Get Member Details
        /// </summary>
        /// <param name="queryUserID">queryUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetMemberDetails(int queryUserID)
        {
            return USPDHUBDAL.AdminDAL.GetMemberDetails(queryUserID);
        }

        /// <summary>
        /// Get Admin Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAdminDetails(int userID)
        {
            return USPDHUBDAL.AdminDAL.GetAdminDetails(userID);
        }

        /// <summary>
        /// Get Member Details
        /// </summary>
        /// <param name="queryID">queryID</param>
        /// <param name="queryUser">queryUser</param>
        /// <returns>DataTable</returns>
        public DataTable GetMemberDetails(int queryID, string queryUser)
        {
            return USPDHUBDAL.AdminDAL.GetMemberDetails(queryID, queryUser);
        }

        /// <summary>
        /// Get ProfileID By User Email
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="vertical">vertical</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileIDByUserEmail(string username, string vertical)
        {
            return USPDHUBDAL.AdminDAL.GetProfileIDByUserEmail(username, vertical);
        }

        /// <summary>
        /// Update Ezsmart Site By profileID
        /// </summary>
        /// <param name="ezsmartflag">ezsmartflag</param>
        /// <param name="profileID">profileID</param>
        public void UpdateEzsmartSiteByprofileID(bool ezsmartflag, int profileID)
        {
            USPDHUBDAL.AdminDAL.UpdateEzsmartSiteByprofileID(ezsmartflag, profileID);
        }

        /// <summary>
        /// Get User Details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetailsByProfileID(int profileID)
        {
            return USPDHUBDAL.AdminDAL.GetUserDetailsByProfileID(profileID);
        }

        /// <summary>
        /// Get Customer DeskNotes Details By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomerDeskNotesDetailsByProfileID(int profileID)
        {
            return USPDHUBDAL.AdminDAL.GetCustomerDeskNotesDetailsByProfileID(profileID);
        }

        /// <summary>
        /// Get Customer DeskNotes Details By ProfileID
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetCustomerDeskNotesDetailsByProfileID()
        {
            return GetCustomerDeskNotesDetailsByProfileID(0);
        }

        #region             *** Payments Renuals ***

        /// <summary>
        /// Get All Subcriptions
        /// </summary>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllSubcriptions(DateTime pStartDate, DateTime pEndDate)
        {
            return USPDHUBDAL.AdminDAL.GetAllSubcriptions(pStartDate, pEndDate);
        }

        /// <summary>
        /// Update Subcription Renewal Date
        /// </summary>
        /// <param name="pRenewalDate">pRenewalDate</param>
        /// <param name="pOrderID">pOrderID</param>
        public void UpdateSubcriptionRenewalDate(DateTime pRenewalDate, int pOrderID)
        {
            USPDHUBDAL.AdminDAL.UpdateSubcriptionRenewalDate(pRenewalDate, pOrderID);
        }



        #endregion

       

        #region         *** Update User Tools ***
        /// <summary>
        /// Update User Selected Tools
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pIsWebsite">pIsWebsite</param>
        /// <param name="pIsFlyers">pIsFlyers</param>
        /// <param name="pIsUpdate">pIsUpdate</param>
        /// <param name="pIsCoupon">pIsCoupon</param>
        /// <param name="pIsEventCalendar">pIsEventCalendar</param>
        /// <param name="pIsAppointmentCalendar">pIsAppointmentCalendar</param>
        /// <param name="pIsSocialmedia">pIsSocialmedia</param>
        /// <param name="pIsCustomDomain">pIsCustomDomain</param>
        /// <param name="pTotalEmails">pTotalEmails</param>
        /// <param name="pSelectedEmailsCount">pSelectedEmailsCount</param>
        /// <param name="pModifyUser">pModifyUser</param>
        /// <param name="pTotalPrice">pTotalPrice</param>
        /// <param name="pDiscount">pDiscount</param>
        public void UpdateUserSelectedTools(int pUserID, bool pIsWebsite, bool pIsFlyers, bool pIsUpdate, bool pIsCoupon,
            bool pIsEventCalendar, bool pIsAppointmentCalendar, bool pIsSocialmedia, bool pIsCustomDomain, int pTotalEmails,
            int pSelectedEmailsCount, string pModifyUser, decimal pTotalPrice, decimal pDiscount)
        {
            USPDHUBDAL.AdminDAL.UpdateSelectedUserTools(pUserID, pIsWebsite, pIsFlyers, pIsUpdate, pIsCoupon,
                pIsEventCalendar, pIsAppointmentCalendar, pIsSocialmedia, pIsCustomDomain, pTotalEmails,
                pSelectedEmailsCount, pModifyUser, pTotalPrice, pDiscount);
        }

        /// <summary>
        /// Get Update Tools By UserID
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUpdateToolsByUserID(int pUserID)
        {
            return USPDHUBDAL.AdminDAL.GetUpdateToolsByUserID(pUserID);
        }

        #endregion

        /// <summary>
        /// Get Password By UserName
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>DataTable</returns>
        public DataTable GetPasswordByUserName(string username)
        {
            return USPDHUBDAL.AdminDAL.GetPasswordByUserName(username);
        }

        /// <summary>
        /// Change Password By Admin
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>Int</returns>
        public int ChangePasswordByAdmin(string username, string password)
        {
            return USPDHUBDAL.AdminDAL.ChangePasswordByAdmin(username, password);
        }

        //----------------- COONTACT US DETAILS
        /// <summary>
        /// Insert Contact Us Details
        /// </summary>
        /// <param name="pName">pName</param>
        /// <param name="pEmail">pEmail</param>
        /// <param name="pPhone">pPhone</param>
        /// <param name="pType">pType</param>
        /// <param name="pSubject">pSubject</param>
        /// <param name="pComments">pComments</param>
        /// <returns>Int</returns>
        public int InsertContactUsDetails(string pName, string pEmail, string pPhone, string pType, string pSubject, string pComments)
        {
            return USPDHUBDAL.AdminDAL.InsertContactUsDetails(pName, pEmail, pPhone, pType, pSubject, pComments);
        }
        // *** Update User Type *** //
        /// <summary>
        /// Update User Type
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="type">type</param>
        /// <returns>Int</returns>
        public int UpdateUserType(int userID, bool type)
        {
            return USPDHUBDAL.AdminDAL.UpdateUserType(userID, type);
        }
        // *** Start Sales Person Operations *** //
        /// <summary>
        /// Get Sales Person
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSalesPerson()
        {
            return USPDHUBDAL.AdminDAL.GetSalesPerson();
        }
        /// <summary>
        /// Create Sales Person
        /// </summary>
        /// <param name="iD">iD</param>
        /// <param name="name">name</param>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="email">email</param>
        /// <param name="phone">phone</param>
        /// <param name="effectedDate">effectedDate</param>
        /// <param name="comments">comments</param>
        /// <param name="commissionID">commissionID</param>
        /// <param name="managerID">managerID</param>
        /// <param name="comsRate">comsRate</param>
        /// <param name="verticals">verticals</param>
        /// <returns>Int</returns>
        public int CreateSalesPerson(int iD, string name, string firstName, string lastName, string email, string phone, DateTime effectedDate, string comments, int commissionID, int? managerID, int? comsRate, string verticals)
        {
            return USPDHUBDAL.AdminDAL.CreateSalesPerson(iD, name, firstName, lastName, email, phone, effectedDate, comments, commissionID, managerID, comsRate, verticals);
        }

        /// <summary>
        /// Get Sales Person By salesPersonID
        /// </summary>
        /// <param name="salesPersonID">salesPersonID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSalesPersonByID(int salesPersonID)
        {
            return USPDHUBDAL.AdminDAL.GetSalesPersonByID(salesPersonID);
        }

        /// <summary>
        /// Delete Sale Person By salesPersonID
        /// </summary>
        /// <param name="id">id</param>
        public void DeleteSalePerson(int id)
        {
            USPDHUBDAL.AdminDAL.DeleteSalesPerson(id);
        }

        /// <summary>
        /// Update ReferBy
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pReferBy">pReferBy</param>
        public void UpdateReferBy(int pUserID, int pReferBy)
        {
            USPDHUBDAL.AdminDAL.UpdateReferBy(pUserID, pReferBy);
        }

        /// <summary>
        /// Get User Profile Subcription
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns></returns>
        public DataTable GetUserProfileSubcription(int pUserID)
        {
            return USPDHUBDAL.AdminDAL.GetUserProfileSubcription(pUserID);
        }

        // *** End Sales Person Operations *** //

        /// <summary>
        /// Update Profile Subcription Recurring
        /// </summary>
        /// <param name="pIsRecurring">pIsRecurring</param>
        /// <param name="pOrderID">pOrderID</param>
        public void UpdateProfileSubcriptionRecurring(bool pIsRecurring, int pOrderID)
        {
            USPDHUBDAL.AdminDAL.UpdateProfileSubcriptionRecurring(pIsRecurring, pOrderID);
        }

        /// <summary>
        /// Get Credit Card Details By UserID
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCreditCardDetailsByUserID(int pUserID)
        {
            return USPDHUBDAL.AdminDAL.GetCreditCardDetailsByUserID(pUserID);
        }

        /// <summary>
        /// Update Credit Card Details By UserID
        /// </summary>
        /// <param name="pOrderID">pOrderID</param>
        /// <param name="pCCNumber">pCCNumber</param>
        /// <param name="pFirstName">pFirstName</param>
        /// <param name="pLastName">pLastName</param>
        /// <param name="pExMonth">pExMonth</param>
        /// <param name="pExYear">pExYear</param>
        /// <param name="pCvvNumber">pCvvNumber</param>
        /// <param name="pCardType">pCardType</param>
        /// <param name="pAddress1">pAddress1</param>
        /// <param name="pAddress2">pAddress2</param>
        /// <param name="pCity">pCity</param>
        /// <param name="pState">pState</param>
        /// <param name="pZipcode">pZipcode</param>
        public void UpdateCreditCardDetailsByUserID(int pOrderID, string pCCNumber, string pFirstName,
            string pLastName, int pExMonth, int pExYear, string pCvvNumber, string pCardType, string pAddress1,
            string pAddress2, string pCity, string pState, string pZipcode)
        {
            USPDHUBDAL.AdminDAL.UpdateCreditCardDetailsByUserID(pOrderID, pCCNumber, pFirstName, pLastName,
                pExMonth, pExYear, pCvvNumber, pCardType, pAddress1, pAddress2, pCity, pState, pZipcode);
        }
        // *** Fix for IRH-45 05-02-2013 *** //
        /// <summary>
        /// Get Active Commissions
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetActiveCommissions()
        {
            return USPDHUBDAL.AdminDAL.GetActiveCommissions();
        }

        /// <summary>
        /// Get Commission Reports
        /// </summary>
        /// <param name="pSalesPersonID">pSalesPersonID</param>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetCommissionReports(int pSalesPersonID, DateTime pStartDate, DateTime pToDate)
        {
            return USPDHUBDAL.AdminDAL.GetCommissionReports(pSalesPersonID, pStartDate, pToDate);
        }

        /// <summary>
        /// Insert Sales Commission Export Details
        /// </summary>
        /// <param name="pSalesPersonID">pSalesPersonID</param>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <param name="pUserName">pUserName</param>
        /// <param name="pComments">pComments</param>
        public void InsertSalesCommissionExportDetails(int pSalesPersonID, DateTime pStartDate, DateTime pToDate, string pUserName, string pComments)
        {
            USPDHUBDAL.AdminDAL.InsertSalesCommissionExportDetails(pSalesPersonID, pStartDate, pToDate, pUserName, pComments);
        }

        /// <summary>
        /// Get Accounts Reports
        /// </summary>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetAccountsReports(DateTime pStartDate, DateTime pEndDate)
        {
            return USPDHUBDAL.AdminDAL.GetAccountsDetailsReport(pStartDate, pEndDate);
        }

        /// <summary>
        /// Insert Account Export Details
        /// </summary>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <param name="pUsername">pUsername</param>
        /// <param name="pComments">pComments</param>
        public void InsertAccountExportDetails(DateTime pStartDate, DateTime pEndDate, string pUsername, string pComments)
        {
            USPDHUBDAL.AdminDAL.InsertAccountExportDetails(pStartDate, pEndDate, pUsername, pComments);
        }

        // *** Payment Process *** //
        #region Payment Process
        /// <summary>
        /// Add Inquiry Transactions
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="totalAmt">totalAmt</param>
        /// <param name="discount">discount</param>
        /// <param name="billableAmt">billableAmt</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="ccnumber">ccnumber</param>
        /// <param name="ccfirstname">ccfirstname</param>
        /// <param name="cclastname">cclastname</param>
        /// <param name="ccmonth">ccmonth</param>
        /// <param name="ccyear">ccyear</param>
        /// <param name="ccvv">ccvv</param>
        /// <param name="cType">cType</param>
        /// <param name="country">country</param>
        /// <param name="userID">userID</param>
        /// <param name="isCard">isCard</param>
        /// <param name="checkNumber">checkNumber</param>
        /// <param name="status">status</param>
        /// <param name="discountCode">discountCode</param>
        /// <param name="purchageOrderNo">purchageOrderNo</param>
        /// <param name="isRecurring">isRecurring</param>
        /// <param name="oneTimeSetupFee">oneTimeSetupFee</param>
        /// <returns>Int</returns>
        public int AddInquiryTransactions(int inquiryID, int subPeriod, decimal totalAmt, decimal discount, decimal billableAmt, string address1, string address2, string city, string state, string zipcode, string ccnumber, string ccfirstname, string cclastname, int ccmonth, int ccyear, string ccvv, string cType, string country, int userID, bool isCard, string checkNumber, bool status, string discountCode, string purchageOrderNo, bool isRecurring, decimal? oneTimeSetupFee)
        {
            return USPDHUBDAL.AdminDAL.AddInquiryTransactions(inquiryID, subPeriod, totalAmt, discount, billableAmt, address1, address2, city, state, zipcode, ccnumber, ccfirstname, cclastname, ccmonth, ccyear, ccvv, cType, country, userID, isCard, checkNumber, status, discountCode, purchageOrderNo, isRecurring, oneTimeSetupFee);
        }

        /// <summary>
        /// Update Inquiry Transaction
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="userID">userID</param>
        public void UpdateInquiryTransaction(int orderID, int inquiryID, int userID)
        {
            USPDHUBDAL.AdminDAL.UpdateInquiryTransaction(orderID, inquiryID, userID);
        }

        /// <summary>
        /// Add Check Invoice
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="purchaseOrderNo">purchaseOrderNo</param>
        /// <param name="invoiceEmail">invoiceEmail</param>
        /// <param name="invoiceAmount">invoiceAmount</param>
        /// <param name="package">package</param>
        /// <param name="oneTimeSetFee">oneTimeSetFee</param>
        /// <param name="invoiceDiscount">invoiceDiscount</param>
        /// <param name="customNotes">customNotes</param>
        /// <returns>Int</returns>
        public int AddCheckInvoice(int inquiryID, string purchaseOrderNo, string invoiceEmail, decimal invoiceAmount, string package, decimal? oneTimeSetFee, decimal invoiceDiscount, string customNotes, bool isUpgrade)
        {
            return USPDHUBDAL.AdminDAL.AddCheckInvoice(inquiryID, purchaseOrderNo, invoiceEmail, invoiceAmount, package, oneTimeSetFee, invoiceDiscount, customNotes, isUpgrade);
        }

        /// <summary>
        /// Add Subscription Package
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="package">package</param>
        public void AddSubscriptionPackage(int inquiryID, string package)
        {
            USPDHUBDAL.AdminDAL.AddSubscriptionPackage(inquiryID, package);
        }

        /// <summary>
        /// Get Inquiry Invoice
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInquiryInvoice(int inquiryID, bool isUpgrade)
        {
            return USPDHUBDAL.AdminDAL.GetInquiryInvoice(inquiryID, isUpgrade);
        }

        /// <summary>
        /// Update Verify Status
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="verifyStatus">verifyStatus</param>
        public void UpdateVerifyStatus(int inquiryID, string verifyStatus, bool isUpgrade)
        {
            USPDHUBDAL.AdminDAL.UpdateVerifyStatus(inquiryID, verifyStatus, isUpgrade);
        }
        #endregion

        /// <summary>
        /// Fill Training Users Data
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FillTrainingUsersData()
        {
            return USPDHUBDAL.AdminDAL.FillTrainingUsersData();
        }

        /// <summary>
        /// Get Notes Count By inquiryId
        /// </summary>
        /// <param name="inquiryId">inquiryId</param>
        /// <returns>Int</returns>
        public int GetNotesCountById(int inquiryId)
        {
            return USPDHUBDAL.AdminDAL.GetNotesCountById(inquiryId);
        }

        /// <summary>
        /// Get Sales Person Maangers
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSalesPersonMaangers()
        {
            return USPDHUBDAL.AdminDAL.GetSalesPersonManagers();
        }

        /// <summary>
        /// Check Admin User
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>Int</returns>
        public int CheckAdminUser(string userName, string password)
        {
            return USPDHUBDAL.AdminDAL.CheckAdminUser(userName, password);
        }

        /// <summary>
        /// Insert Promo code
        /// </summary>
        /// <param name="pDoaminName">pDoaminName</param>
        /// <param name="isSingle">isSingle</param>
        /// <param name="pAllowedCount">pAllowedCount</param>
        /// <param name="isAutoGenerated">isAutoGenerated</param>
        /// <param name="pPromocodeName">pPromocodeName</param>
        /// <param name="productId">productId</param>
        /// <param name="productPrice">productPrice</param>
        /// <param name="productAmtCharged">productAmtCharged</param>
        /// <param name="setupFee">setupFee</param>
        /// <param name="setupFeeCharged">setupFeeCharged</param>
        /// <param name="isLifeTime">isLifeTime</param>
        /// <param name="initialFirst">initialFirst</param>
        /// <param name="initialLast">initialLast</param>
        /// <param name="pPromocodeExDate">pPromocodeExDate</param>
        /// <param name="pDescription">pDescription</param>
        /// <param name="pValidFor">pValidFor</param>
        /// <param name="pCreatedUser">pCreatedUser</param>
        /// <param name="pDuration">pDuration</param>
        /// <param name="pIsProduct">pIsProduct</param>
        /// <param name="isDollarAmount">isDollarAmount</param>
        /// <returns>String</returns>
        public string InsertPromocode(string pDoaminName, bool isSingle, int pAllowedCount, bool isAutoGenerated, string pPromocodeName, int productId, decimal productPrice, decimal productAmtCharged, decimal? setupFee, decimal? setupFeeCharged, bool isLifeTime, string initialFirst, string initialLast,
            DateTime pPromocodeExDate, string pDescription, int pValidFor, int pCreatedUser, int? pDuration, bool pIsProduct, bool isDollarAmount)
        {
            return USPDHUBDAL.AdminDAL.InsertPromoCode(pDoaminName, isSingle, pAllowedCount, isAutoGenerated,  pPromocodeName, productId, productPrice, productAmtCharged, setupFee, setupFeeCharged, isLifeTime, initialFirst, initialLast,
                pPromocodeExDate, pDescription, pValidFor, pCreatedUser, pDuration, pIsProduct,  isDollarAmount);
        }

        /// <summary>
        /// Get All Promo codes
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="type">type</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllPromocodes(int pUserID, string type)
        {
            return USPDHUBDAL.AdminDAL.GetAllPromocodes(pUserID, type);
        }

        /// <summary>
        /// Generate New Promo code
        /// </summary>
        /// <returns>String</returns>
        public string GenerateNewPromocode()
        {
            return USPDHUBDAL.AdminDAL.GenerateNewPromocode();
        }

        /// <summary>
        /// Validate Promo Code
        /// </summary>
        /// <param name="promoCode">promoCode</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>DataTable</returns>
        public DataTable ValidatePromoCode(string promoCode, int inquiryID, bool isUpgrade)
        {
            return USPDHUBDAL.AdminDAL.ValidatePromoCode(promoCode, inquiryID, isUpgrade);
        }

        /// <summary>
        /// Get Business Access Codes
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessAccessCodes()
        {
            return USPDHUBDAL.AdminDAL.GetBusinessAccessCodes();
        }

        /// <summary>
        /// Delete Access Codes
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="type">type</param>
        /// <param name="AccessCode">AccessCode</param>
        /// <returns>Int</returns>
        public int DeleteAccessCodes(int ProfileID, string type, string AccessCode)
        {
            return USPDHUBDAL.AdminDAL.DeleteAccessCodes(ProfileID, type, AccessCode);
        }

        /// <summary>
        /// Create and Update Access Codes
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="AccessCode">AccessCode</param>
        /// <param name="isDelete">isDelete</param>
        /// <returns>Int</returns>
        public int CreateUpdateAccessCodes(int ProfileID, string AccessCode, bool isDelete)
        {
            return USPDHUBDAL.AdminDAL.CreateUpdateAccessCodes(ProfileID, AccessCode, isDelete);
        }

        /// <summary>
        /// Get CS Users
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetCSUsers()
        {
            return USPDHUBDAL.AdminDAL.GetCSUsers();
        }
        /// <summary>
        /// Extend Subscription Period
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="memberID">memberID</param>
        /// <param name="updateRenewDate">updateRenewDate</param>
        /// <returns>Int</returns>
        public int ExtendSubscriptionPeriod(int profileID, int memberID, DateTime updateRenewDate)
        {
            return USPDHUBDAL.AdminDAL.ExtendSubscriptionPeriod(profileID, memberID, updateRenewDate);
        }
        /// <summary>
        /// Preserve Subscription Renew Dates
        /// </summary>
        /// <param name="textSubscription">textSubscription</param>
        /// <param name="renewDate">renewDate</param>
        public void PreserveSubscriptionRenewDates(string textSubscription, DateTime renewDate)
        {
            USPDHUBDAL.AdminDAL.PreserveSubscriptionRenewDates(textSubscription, renewDate);
        }
        /// <summary>
        /// Get Admin User Details Check
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>DataTable</returns>
        public DataTable GetAdminUserDetailsCheck(string username)
        {
            return USPDHUBDAL.AdminDAL.GetAdminUserDetailsCheck(username);
        }
        /// <summary>
        /// Get Admin Details Check
        /// </summary>
        /// <param name="AdminUserID">AdminUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAdminDetailsCheck(int AdminUserID)
        {
            return USPDHUBDAL.AdminDAL.GetAdminDetailsCheck(AdminUserID);
        }
        /// <summary>
        /// Get Associate Latest Login
        /// </summary>
        /// <param name="parentID">parentID</param>
        /// <param name="parentLastLogin">parentLastLogin</param>
        /// <returns>DataTable</returns>
        public DataTable GetAssociateLatestLogin(int parentID, DateTime parentLastLogin)
        {
            return USPDHUBDAL.AdminDAL.GetAssociateLatestLogin(parentID, parentLastLogin);
        }
        // *** Update User Type *** //
        /// <summary>
        /// Archive User
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="type">type</param>
        /// <returns>Int</returns>
        public int ArchiveUser(int userID, bool type)
        {
            return USPDHUBDAL.AdminDAL.ArchiveUser(userID, type);
        }
        /// <summary>
        /// Check SubApp
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>String</returns>
        public string CheckSubApp(int userId)
        {
            return USPDHUBDAL.AdminDAL.CheckSubApp(userId);
        }
        /// <summary>
        /// Get All Active SubApps
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllActiveSubApps()
        {
            return USPDHUBDAL.AdminDAL.GetAllActiveSubApps();
        }

        /// <summary>
        /// Get CS Notes Report Data
        /// </summary>
        /// <param name="pSearchType">pSearchType</param>
        /// <param name="pSearchStr">pSearchStr</param>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetCSNotesReportData(string pSearchType, string pSearchStr, DateTime pStartDate, DateTime pEndDate)
        {
            return USPDHUBDAL.AdminDAL.GetCSNotesReportData(pSearchType, pSearchStr, pStartDate, pEndDate);
        }
        /// <summary>
        /// Get All Webnairs
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllWebnairs()
        {
            return AdminDAL.GetAllWebnairs();
        }
        /// <summary>
        /// Get All Registrations By TipId
        /// </summary>
        /// <param name="systemTipId">systemTipId</param>
        /// <param name="webnairtitle">webnairtitle</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllRegistrationsByTipId(int systemTipId, out string webnairtitle)
        {
            return AdminDAL.GetAllRegistrationsByTipId(systemTipId, out webnairtitle);
        }
        /// <summary>
        /// Get All Emails By TipId
        /// </summary>
        /// <param name="systemTipId">systemTipId</param>
        /// <param name="webnairtitle">webnairtitle</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllEmailsByTipId(int systemTipId, out string webnairtitle)
        {
            return AdminDAL.GetAllEmailsByTipId(systemTipId, out webnairtitle);
        }
        /// <summary>
        /// Get Exipiration Members
        /// </summary>
        /// <param name="fromDate">fromDate</param>
        /// <param name="toDate">toDate</param>
        /// <returns>DataTable</returns>
        public DataTable GetExipirationMembers(DateTime fromDate, DateTime toDate)
        {
            return AdminDAL.GetExipirationMembers(fromDate, toDate);
        }
        /// <summary>
        /// Get Branded App Users
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name="userId">userId</param>
        /// <param name="profileName">profileName</param>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppUsers(string vertical, int? userId, string profileName)
        {
            return AdminDAL.GetBrandedAppUsers(vertical, userId, profileName);
        }
        /// <summary>
        /// Update Member App Version
        /// </summary>
        /// <param name="brandedOrderId">brandedOrderId</param>
        /// <param name="version">version</param>
        public void UpdateMemberAppVersion(int brandedOrderId, string version)
        {
            AdminDAL.UpdateMemberAppVersion(brandedOrderId, version);
        }
        /// <summary>
        /// Get Branded App Additional Request
        /// </summary>
        /// <param name="BrandedApp_OrderId">BrandedApp_OrderId</param>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppAdditionalRequest(int BrandedApp_OrderId)
        {
            return AdminDAL.GetBrandedAppAdditionalRequest(BrandedApp_OrderId);
        }
        /// <summary>
        /// Get Branded App Request By RequestID
        /// </summary>
        /// <param name="brandedAppRequestID">brandedAppRequestID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppRequestByRequestID(int brandedAppRequestID)
        {
            return AdminDAL.GetBrandedAppRequestByRequestID(brandedAppRequestID);
        }

        public int InsertActivityLog(int activityId,string Title, string editHTML, string previewHtml, string DomainName,int? ProfileID,DateTime? expiryDate)
        {
            return AdminDAL.InsertActivityLog(activityId,Title, editHTML, previewHtml, DomainName,ProfileID,expiryDate);
        }

        public void DeleteActivityLog(int activityID)
        {
            AdminDAL.DeleteActivityLog(activityID);
        }


        #region Manage Sales Code
        public DataTable GetManageSalesCode()
        {
            return AdminDAL.GetManageSalesCode();
        }
        public void DeleteSalesCode(int ConfigId)
        {
            AdminDAL.DeleteSalesCode(ConfigId);
        }
        public DataTable GetNamesByRoleID(int RoleId)
        {
            return AdminDAL.GetNamesByRoleID(RoleId);
        }
        public void InsertChannelPartnerDetails(string FirstName, string LastName, string CompanyName, string Address, string City, string State, int ZipCode, string EmailId, string WebSite, int RoleID,
            string PhoneNumber, string Extension)
        {
            AdminDAL.InsertChannelPartnerDetails(FirstName, LastName, CompanyName, Address, City, State, ZipCode, EmailId, WebSite, RoleID, PhoneNumber, Extension);
        }


        public int InsertSalesPersonDetails(string SalesCode, int LTManagerId, int LTManagerCommission, int ChannelPartnerId, int ChannelPartnerCommission, int ChannelManagerId,
           int ChannelManagerCommission, int ChannelAffiliateId, int ChannelAffiliateCommission, DateTime AgreementDate, DateTime AgreementExpiryDate, int UserID,string Notes,string CreatedByName,string ApprovedBy)
        {
           return AdminDAL.InsertSalesPersonDetails(SalesCode, LTManagerId, LTManagerCommission, ChannelPartnerId, ChannelPartnerCommission, ChannelManagerId,
                ChannelManagerCommission, ChannelAffiliateId, ChannelAffiliateCommission, AgreementDate, AgreementExpiryDate,UserID,Notes,CreatedByName,ApprovedBy);
        
        }
        #endregion

        public DataTable GetRecurringTransactionDetails()
        {
            return AdminDAL.GetRecurringTransactionDetails();
        }

        public DataTable getBillMeProfileDetails()
        {
            return AdminDAL.getBillMeProfileDetails();
        }

        public DataTable getBillMedetailsbySubID(int ProfileID)
        {
            return AdminDAL.getBillMedetailsbySubID(ProfileID);
        }
      

        #region invoice generation from admin
        public string CreateInvoiceReport(int OrderID, string Vertical, string DomainName, string strHTML)
        {
            string savelocation = string.Empty;

           try
            {
                if (strHTML != "")
                {
                    string domainwithoutext = CommonDAL.GetVerticalDomain(Vertical);
                    string RootPath = "";
                    DataTable dtConfigsemails1 = CommonDAL.GetVerticalConfigsByType(DomainName, "Paths");
                    if (dtConfigsemails1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails1.Rows)
                        {
                            if (row[0].ToString() == "RootPath")
                                RootPath = row[1].ToString();
                        }
                    }

                    string filepath = System.Web.HttpContext.Current.Server.MapPath("~");

                    string filename = filepath + "/temp/" + domainwithoutext + "_invoice_" + OrderID.ToString() + ".html";

                    string hmtlfileurl = RootPath + "/temp/" + domainwithoutext + "_invoice_" + OrderID.ToString() + ".html";

                    string pdffilename = filepath + "/temp/" + domainwithoutext + "_invoice_" + OrderID.ToString() + ".pdf";

                    string pdfilenameval = domainwithoutext + "_invoice_" + OrderID.ToString() + ".pdf";

                    /*
                    LicensingManager.LicenseKey = ConfigurationSettings.AppSettings.Get("pdfkeyval");

                    //create a PDF document
                    Document document = new Document();

                    //optional settings for the PDF document like margins, compression level,
                    //security options, viewer preferences, document information, etc
                    document.CompressionLevel = CompressionLevel.NormalCompression;
                    document.Margins = new Margins(10, 10, 0, 0);
                    document.Security.CanPrint = true;
                    document.Security.UserPassword = "";
                    document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                    document.ViewerPreferences.HideToolbar = false;


                    //Add a first page to the document. The next pages will inherit the settings from this page 
                    PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

                    // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

                    //PdfPage page = document.Pages.AddNewPage();

                    // add a font to the document that can be used for the texts elements 

                    PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

                    // the result of adding an element to a PDF page

                    AddElementResult addResult;

                    // Get the specified location and size of the rendered content

                    // A negative value for width and height means to auto determine

                    // The auto determined width is the available width in the PDF page

                    // and the auto determined height is the height necessary to render all the content

                    float xLocation = 5;

                    float yLocation = 5;

                    float width = -1;

                    float height = -1;

                    // convert HTML to PDF

                    HtmlToPdfElement htmlToPdfElement;

                    // convert a URL to PDF

                    //string urlToConvert = hmtlfileurl;

                    //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

                    htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

                    // add theHTML to PDF converter element to page
                    addResult = page.AddElement(htmlToPdfElement);
                    savelocation = System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\Upload\\Invoices\\" + pdfilenameval;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    document.Save(savelocation);
                    */


                    // Get the server IP and port
                    String serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                    uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                    // Create a HTML to PDF converter object with default settings
                    HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);
                    htmlToPdfConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");
                    htmlToPdfConverter.HtmlViewerWidth = 650;
                    //htmlToImageConverter.HtmlViewerHeight = 200;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = Winnovative.HtmlToPdfClient.PdfPageSize.A4;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                    htmlToPdfConverter.PdfDocumentOptions.LeftMargin = 10;
                    htmlToPdfConverter.PdfDocumentOptions.TopMargin = 10;

                    htmlToPdfConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                    htmlToPdfConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));

                    // The buffer to receive the generated PDF document
                    byte[] outPdfBuffer = null;
                    string baseUrl = "";

                    savelocation = System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\Upload\\Invoices\\" + pdfilenameval;
                    // Convert a HTML string with a base URL to a PDF document in a memory buffer
                    outPdfBuffer = htmlToPdfConverter.ConvertHtml(strHTML.ToString(), baseUrl);
                    System.IO.File.WriteAllBytes(savelocation, outPdfBuffer);

                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CommonBLL.cs", "CreateInvoiceReport(" + savelocation + ")", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return savelocation;
        }
        public string CreateInvoiceHtml(int OrderID, string Vertical, string DomainName, string PurchaseOrderNo, decimal discount, int PackageID)
        {
            string strhtml = "";
            string savelocation = string.Empty;
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                DataTable dtInvoiceOrderDetails = new DataTable();
                dtInvoiceOrderDetails = objBus.GetOrderIDInvoice(OrderID);
                decimal paidAmount = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["PaidAmount"].ToString());
                DataTable dtOrderDetails = new DataTable();
                dtOrderDetails = objBus.GetOrderDetailsByOrderID(OrderID);
                if (dtInvoiceOrderDetails.Rows.Count > 0)
                {
                    DataTable dtUserDetails = new DataTable();
                    dtUserDetails = objBus.GetUserDetailsByUserID(Convert.ToInt32(dtInvoiceOrderDetails.Rows[0]["User_ID"].ToString()));
                    decimal discAmt = 0.00M;
                    decimal totalAmount = 0.00M;
                    decimal totalBalCalAmt = 0.00M;
                    string tools = string.Empty;
                    string domainwithoutext = CommonDAL.GetVerticalDomain(Vertical);
                    string FromEmailsupport = "";
                    DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                    if (dtConfigsemails.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails.Rows)
                        {
                            if (row[0].ToString() == "EmailSupport")
                                FromEmailsupport = row[1].ToString();
                        }
                    }
                    string RootPath = "";
                    DataTable dtConfigsemails1 = CommonDAL.GetVerticalConfigsByType(DomainName, "Paths");
                    if (dtConfigsemails1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails1.Rows)
                        {
                            if (row[0].ToString() == "RootPath")
                                RootPath = row[1].ToString();
                        }
                    }
                    // start Change Invoice UI Format 
                    /*** Agency Info ***/
                    string ProfileInfo = "";
                    DataTable dtprofileName = new DataTable();
                    dtprofileName = objBus.GetProfileDetailsByProfileID(Convert.ToInt32(dtInvoiceOrderDetails.Rows[0]["Profile_ID"].ToString()));
                    string profileBusinessName = string.Empty;
                    if (dtprofileName.Rows.Count > 0)
                    {
                        ProfileInfo = dtprofileName.Rows[0]["Profile_Name"].ToString();
                        ProfileInfo = ProfileInfo + "<br/> " + dtUserDetails.Rows[0]["Firstname"].ToString() + " " + dtUserDetails.Rows[0]["Lastname"].ToString();

                        ProfileInfo = ProfileInfo + "<br/>" + dtprofileName.Rows[0]["Profile_StreetAddress1"].ToString();
                        if (!string.IsNullOrEmpty(dtprofileName.Rows[0]["Profile_StreetAddress2"].ToString()))
                            ProfileInfo = ProfileInfo + ", " + dtprofileName.Rows[0]["Profile_StreetAddress2"].ToString();
                        ProfileInfo = ProfileInfo + "<br/>" + dtprofileName.Rows[0]["Profile_City"].ToString();
                        ProfileInfo = ProfileInfo + ", " + dtprofileName.Rows[0]["Profile_State"].ToString();
                        ProfileInfo = ProfileInfo + " " + dtprofileName.Rows[0]["Profile_Zipcode"].ToString();
                        ProfileInfo = ProfileInfo + " " + dtprofileName.Rows[0]["Profile_County"].ToString();
                    }

                    /*** Billing Info ***/
                    string billinginfo = "";
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString()))
                    {
                        billinginfo = dtprofileName.Rows[0]["Profile_Name"].ToString();
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString();
                        billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_LastName"].ToString();
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Address1"].ToString();
                        if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Address2"].ToString()))
                            billinginfo = billinginfo + ", " + dtInvoiceOrderDetails.Rows[0]["Billing_Address2"].ToString();
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_City"].ToString();
                        billinginfo = billinginfo + ", " + dtInvoiceOrderDetails.Rows[0]["Billing_State"].ToString();
                        billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_Zipcode"].ToString();
                        if (dtInvoiceOrderDetails.Rows[0]["Billing_Country"].ToString() == string.Empty)
                            billinginfo = billinginfo + " " + dtprofileName.Rows[0]["Profile_County"].ToString();
                        else
                            billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_Country"].ToString();
                        //if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Phone"].ToString()))
                        //    billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Phone"].ToString();
                        //if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString()))
                        //    billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString();
                    }

                    string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\Preview\\";
                    StreamReader re = File.OpenText(strfilepath + "InoviceFormat__New.txt");
                    string invoice_htmlText = string.Empty;
                    string content = string.Empty;

                    while ((content = re.ReadLine()) != null)
                    {
                        invoice_htmlText = invoice_htmlText + content;
                    }

                    invoice_htmlText = invoice_htmlText.Replace("#Logo#", RootPath + "/Images/Dashboard/logictree_logo.png");
                    invoice_htmlText = invoice_htmlText.Replace("#BillingAddress#", billinginfo);
                    invoice_htmlText = invoice_htmlText.Replace("#ProfileInfo#", ProfileInfo);
                    invoice_htmlText = invoice_htmlText.Replace("#ProfileID#  ", dtInvoiceOrderDetails.Rows[0]["Profile_ID"].ToString());
                    string dueDate = "";
                    if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Created_Date"]) == string.Empty)
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", "&nbsp;");
                    }
                    else
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).ToString("MMMM dd, yyyy"));
                        dueDate = "Net 30 " + Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).AddDays(30).ToShortDateString();
                    }

                    string payInfo = "";
                    if (!string.IsNullOrEmpty(Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Number"])))
                    {
                        payInfo = EncryptDecrypt.DESDecrypt(Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Number"]));
                        if (String.IsNullOrEmpty(payInfo.Trim()))
                        {
                            payInfo = Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Number"]);
                            if (payInfo.Length > 4)
                                payInfo = payInfo.Substring(payInfo.Length - 4);
                        }
                    }

                    /*** Paypal Payments ***/
                    string ccInfo = "";
                    if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == PaymentModes.PayPal || Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == PaymentModes.BillMe ||
                        Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == string.Empty)
                    {
                        ccInfo = Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == PaymentModes.PayPal ? "paypal" : "P.O.";
                    }
                    else
                    {
                        /*** Credit card ***/
                        ccInfo = "credit card ending XXXX" + payInfo; ;
                    }

                    invoice_htmlText = invoice_htmlText.Replace("#CCDetails#", ccInfo);
                    invoice_htmlText = invoice_htmlText.Replace("#InvoiceNumber#", dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString());
                    invoice_htmlText = invoice_htmlText.Replace("#PONumber#", PurchaseOrderNo);


                    int ordersCount = 0;
                    string orderDetailsHTML = "";
                    string selectedPackageName = "";
                    string subscriptionCost = "";
                    if (PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Custom)
                        || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Custom_Twovie)
                        || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Custom_InSchoolHub)
                        || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Custom_MyYouthHub))
                    {

                        selectedPackageName = Convert.ToInt32(dtOrderDetails.Rows[0]["Subscription_Period"]) == 1 ? "Custom Monthly" : "Custom Yearly";
                    }
                    else if (PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Premium)
                        || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Premium_Twovie)
                        || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Premium_InSchoolHub)
                        || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Premium_MyYouthHub))
                    {
                        selectedPackageName = Convert.ToInt32(dtOrderDetails.Rows[0]["Subscription_Period"]) == 1 ? "Premium Monthly" : "Premium Yearly";

                    }
                    else if (PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Basic)
                       || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Basic_Twovie)
                       || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Basic_InSchoolHub)
                       || PackageID == Convert.ToInt32(ProfileSubscriptionTypes.Basic_MyYouthHub))
                    {
                        selectedPackageName = Convert.ToInt32(dtOrderDetails.Rows[0]["Subscription_Period"]) == 1 ? "Basic Monthly" : "Basic Yearly";
                    }

                    if (Vertical.ToLower().Contains("uspd"))
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#Agency#", "Agency");
                        selectedPackageName = "USPDhub " + selectedPackageName;
                    }
                    else if (Vertical.ToLower().Contains("twovie"))
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#Agency#", "Organization");
                        selectedPackageName = "TwoVieHub " + selectedPackageName;
                    }
                    else if (Vertical.ToLower().Contains("inschool"))
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#Agency#", "School");
                        selectedPackageName = "InSchoolHub " + selectedPackageName;
                    }
                    else if (Vertical.ToLower().Contains("myyouth"))
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#Agency#", "Organization");
                        selectedPackageName = "MyYouthHub " + selectedPackageName;
                    }
                    else
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#Agency#", "Agency");
                        selectedPackageName = "USPDhub " + selectedPackageName;
                    }

                    for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                    {
                        string includeText = " $" + dtOrderDetails.Rows[i]["Total_Amount"].ToString();
                        if (Convert.ToString(dtOrderDetails.Rows[i]["ParentOrderDetailsID"]) != string.Empty)
                        {
                            continue;
                            includeText = "(Included)";
                        }

                    

                        if (Convert.ToInt32(dtOrderDetails.Rows[i]["Request_Type"]) == Convert.ToInt32(RequestCustomFormTypes.NewRegistration))
                        {
                            orderDetailsHTML = orderDetailsHTML + "<tr><td>" + selectedPackageName + "</td>";
                            orderDetailsHTML = orderDetailsHTML + "<td align='center' style='border-left: 1px solid #D9D9D9;' > " + includeText + "</td></tr>";
                        }
                        else
                        {
                            orderDetailsHTML = orderDetailsHTML + "<tr><td >" + dtOrderDetails.Rows[i]["Email_Description"].ToString() + "</td>";
                            orderDetailsHTML = orderDetailsHTML + "<td align='center' style='border-left: 1px solid #D9D9D9;' > " + includeText + "</td></tr>";
                        }
                        ordersCount += 1;

                        discAmt = discAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Discount_Amount"].ToString());
                        totalAmount = totalAmount + Convert.ToDecimal(dtOrderDetails.Rows[i]["Total_Amount"].ToString());
                        totalBalCalAmt = totalBalCalAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Billable_Amount"].ToString());
                    }
                    decimal dueAmt = totalBalCalAmt - paidAmount;
                    if (dueAmt < 0)
                        dueAmt = 0;
                    if (dueAmt > 0)
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", Convert.ToString(dtInvoiceOrderDetails.Rows[0]["DueDateTitle"]));
                        invoice_htmlText = invoice_htmlText.Replace("#DueDate#", dueDate);
                    }
                    else
                    {
                        invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", "");
                        invoice_htmlText = invoice_htmlText.Replace("#DueDate#", "");

                    }


                    if (Convert.ToString(dtOrderDetails.Rows[0]["Discount_Amount"]).Trim() == "0.00")
                        invoice_htmlText = invoice_htmlText.Replace("#DiscountRow#", "");
                    else
                        invoice_htmlText = invoice_htmlText.Replace("#DiscountRow#", "<tr><td style=\"border: 1px solid #D9D9D9;\">Discount</td><td style=\"border: 1px solid #D9D9D9; padding-right: 10px;\" align=\"right\">$" + dtOrderDetails.Rows[0]["Discount_Amount"].ToString() + "</td></tr>");

                    /*
                    if (!string.IsNullOrEmpty(pobjBillingInfo.PromoCode))
                    { invoice_htmlText = invoice_htmlText.Replace("#DiscountRow#", pobjBillingInfo.Discount); }
                    else
                        invoice_htmlText = invoice_htmlText.Replace("#DiscountAmount#", "0.00");
                    */

                    invoice_htmlText = invoice_htmlText.Replace("#OrderDetailsRows#", orderDetailsHTML);
                    invoice_htmlText = invoice_htmlText.Replace("#TotalBill#", totalAmount.ToString()); // *** totalBalCalAmt.ToString() *** //
                    invoice_htmlText = invoice_htmlText.Replace("#PaidBill#", paidAmount.ToString());
                    invoice_htmlText = invoice_htmlText.Replace("#BalanceBill#", dueAmt.ToString());
                    invoice_htmlText = invoice_htmlText.Replace("#AmountDue#", (totalAmount - Convert.ToDecimal(dtOrderDetails.Rows[0]["Discount_Amount"])).ToString());
                    invoice_htmlText = invoice_htmlText.Replace("#CustomNotes#", "");

                    re.Close();

                    // final HTML Invoice Format
                    strhtml = invoice_htmlText;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CommonBLL.cs", "CreateInvoiceHtml", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return strhtml;
        }
   

        #endregion

        public void insertInvoiceSendHistory(int ProfileID, int UserId, decimal RenewalAmount,string InitialName,string Remarks)
        {
            AdminDAL.insertInvoiceSendHistory(ProfileID, UserId, RenewalAmount, InitialName, Remarks);
        }

        public DataTable GetPromocodesBySearch(string vertical, string SearchText, string TabValue, string fromDate, string toDate)
        {
            return AdminDAL.GetPromocodesBySearch(vertical, SearchText,TabValue,fromDate,toDate);
        }

        public void ArchivePromocodes(bool IsArchive, int PromocodeID) {
            AdminDAL.ArchivePromocodes(IsArchive, PromocodeID);
        }

        public DataTable GetStoreItems_Renewal( int pProfileID)
        {
            return AdminDAL.GetStoreItems_Renewal( pProfileID);
        }
        public int UpdatePackageItems(int pUserModuleID, DateTime pRenewalDate, int pProfileID, int pUserID, int orderDetailsID)
        {
            return AdminDAL.UpdatePackageItems(pUserModuleID, pRenewalDate, pProfileID, pUserID, orderDetailsID);
        }

        public DataTable GetResellerDetailsByConfigID(int ConfigID)
        {
            return AdminDAL.GetResellerDetailsByConfigID(ConfigID);
        }
    }

    public class CartList
    {
        public int Subscription_ID { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string SubTotal { get; set; }
        public bool AllowMultiple { get; set; }
        public string ModuleType { get; set; }
        public bool IsExpand { get; set; }
        public string Group_Name { get; set; }
        public int Request_Type { get; set; }
        public string ListName { get; set; }
        public string AccessType { get; set; }
        public bool IsPackageItem { get; set; }
        public bool IsSelected { get; set; }
        public string Annual_Price { get; set; }
        public bool IsDefaultItem { get; set; }
        public int OrderDetails_ID { get; set; }
        public string ToolTip { get; set; }
        public int UserModuleID { get; set; }
        public string Monthly_Price { get; set; }
        public string Renewal_Date { get; set; }
        public int Subscription_Period { get; set; }
    }
}
