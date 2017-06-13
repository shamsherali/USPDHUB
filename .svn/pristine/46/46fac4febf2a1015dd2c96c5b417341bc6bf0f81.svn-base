using System;
using System.Linq;
using System.Data;
using USPDHUBDAL;

namespace USPDHUBBLL
{
    public class AgencyBLL
    {
        /// <summary>
        /// Add Agency User
        /// </summary>
        /// <param name="agencyname">agencyname</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="phone">phone</param>
        /// <param name="date">date</param>
        /// <param name="remarks">remarks</param>
        /// <param name="userid">userid</param>
        /// <param name="title">title</param>
        /// <param name="howIKnow">howIKnow</param>
        /// <param name="vertical">vertical</param>
        /// <param name="promoCode">promoCode</param>
        /// <param name="parentProfileID">parentProfileID</param>
        /// <param name="affInvID">affInvID</param>
        /// <param name="pLastName">pLastName</param>
        /// <param name="pCountry">pCountry</param>
        /// <param name="pAddress">pAddress</param>
        /// <param name="pCity">pCity</param>
        /// <param name="pState">pState</param>
        /// <param name="pZipcode">pZipcode</param>
        /// <param name="pWebsiteURL">pWebsiteURL</param>
        /// <returns>Int</returns>
        public int AddAgencyUser(string pSalesCode, string agencyname, string email, string firstname, string phone, string date, string remarks, int userid,
            string title, string howIKnow, string vertical, string promoCode, int? parentProfileID, int? affInvID, string pLastName = "",
            string pCountry = "",string pAddress="", string pCity = "",
            string pState = "", string pZipcode = "", string pWebsiteURL = "", bool pIsLiteversion = false, string pAddress2 = "")
        {
            return AgencyDAL.AddAgencyUser(agencyname, email, firstname, phone, date, remarks, userid, title, howIKnow, vertical, promoCode, parentProfileID, affInvID,
                pLastName, pCountry, pAddress, pCity, pState, pZipcode, pWebsiteURL, pIsLiteversion, pSalesCode, pAddress2);
        }
        public void UpdateLiteVersion(int inquirryId, int flagType)
        {
            AgencyDAL.UpdateLiteVersion(inquirryId, flagType);
        }
        /// <summary>
        /// Get Agency details By AgencyID
        /// </summary>
        /// <param name="agencyID">agencyID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAgencydetailsByAgencyID(int agencyID)
        {
            return AgencyDAL.GetAgencydetailsByAgencyID(agencyID);
        }

        /// <summary>
        /// Get Verify Listing Details
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="type">type</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>DataTable</returns>
        public DataTable GetVerifyListingDtls(int inquiryID, string type, string vertical, string country)
        {
            return AgencyDAL.GetVerifyListingDtls(inquiryID, type, vertical, country);
        }

        /// <summary>
        /// Get Verify Details By inquiryID
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>DataTable</returns>
        public DataTable GetVerifyDetailsById(int inquiryID)
        {
            return AgencyDAL.GetVerifyDetailsById(inquiryID);
        }

        /// <summary>
        /// Update Agency Details By Id
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="agencyname">agencyname</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="phone">phone</param>
        /// <param name="state">state</param>
        /// <param name="city">city</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="address">address</param>
        /// <param name="websiteaddress">websiteaddress</param>
        /// <param name="salespersonsId">salespersonsId</param>
        /// <param name="status">status</param>
        /// <param name="vertical">vertical</param>
        /// <param name="title">title</param>
        /// <param name="howIknow">howIknow</param>
        /// <param name="country">country</param>
        /// <param name="parentProfileID">parentProfileID</param>
        /// <returns>Int</returns>
        public int UpdateAgencyDtlsById(int inquiryID, string agencyname, string email, string firstname, string lastname, string phone, string state, string city, string zipcode, string address, string websiteaddress, int? salespersonsId, string status, string vertical, string title, string howIknow, string country, int? parentProfileID, string address2="")
        {
            return AgencyDAL.UpdateAgencyDtlsById(inquiryID, agencyname, email, firstname, lastname, phone, state, city, zipcode, address, websiteaddress, salespersonsId, status, vertical, title, howIknow, country, parentProfileID, address2);
        }

        /// <summary>
        /// Get Enquiry Notes
        /// </summary>
        /// <param name="noteID">noteID</param>
        /// <param name="notetext">notetext</param>
        /// <param name="addedby">addedby</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="flag">flag</param>
        /// <returns>DataTable</returns>
        public DataTable GetEnquiryNotes(int noteID, string notetext, string addedby, int inquiryID, bool flag)
        {
            return AgencyDAL.GetEnquiryNotes(noteID, notetext, addedby, inquiryID, flag);
        }

        /// <summary>
        /// Insert Enquiry Notes With Action Date
        /// </summary>
        /// <param name="noteID">noteID</param>
        /// <param name="notetext">notetext</param>
        /// <param name="addedby">addedby</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="flag">flag</param>
        /// <param name="nextActDateTime">nextActDateTime</param>
        /// <returns>Int</returns>
        public int InsertEnquiryNotesWithActioDate(int noteID, string notetext, string addedby, int inquiryID, bool flag, DateTime nextActDateTime)
        {
            return AgencyDAL.InsertEnquiryNotesWithActioDate(noteID, notetext, addedby, inquiryID, flag, nextActDateTime);
        }

        /// <summary>
        /// Insert Enquiry Notes
        /// </summary>
        /// <param name="noteID">noteID</param>
        /// <param name="notetext">notetext</param>
        /// <param name="addedby">addedby</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="flag">flag</param>
        /// <returns>Int</returns>
        public int InsertEnquiryNotes(int noteID, string notetext, string addedby, int inquiryID, bool flag)
        {
            return AgencyDAL.InsertEnquiryNotes(noteID, notetext, addedby, inquiryID, flag);
        }

        /// <summary>
        /// Insert Optional Details by Id
        /// </summary>
        /// <param name="facebook">facebook</param>
        /// <param name="twitter">twitter</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="logo">logo</param>
        /// <param name="flag">flag</param>
        /// <returns>Int</returns>
        public int InsertOptionalDtlsbyId(string facebook, string twitter, int inquiryID, string logo, bool flag)
        {
            return AgencyDAL.InsertOptionalDtlsbyId(facebook, twitter, inquiryID, logo, flag);
        }

        /// <summary>
        /// Insert User Details
        /// </summary>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="password">password</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>Int</returns>
        public int InsertUserDetails(double platitude1, double plongitude1, string password, int inquiryID)
        {
            return AgencyDAL.InsertUserDetails(platitude1, plongitude1, password, inquiryID);
        }

        /// <summary>
        /// Get Sales Person
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSalesPerson()
        {
            return USPDHUBDAL.AgencyDAL.GetSalesPerson();
        }

        /// <summary>
        /// Update Logo Path
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="logopath">logopath</param>
        /// <returns>Int</returns>
        public int UpdateLogoPath(int profileid, string logopath)
        {
            return AgencyDAL.UpdateLogoPath(profileid, logopath);
        }

        /// <summary>
        /// Insert Training User Details
        /// </summary>
        /// <param name="agencyname">agencyname</param>
        /// <param name="firstname">firstname</param>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phoneno">phoneno</param>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="vertical">vertical</param>
        /// <returns>Int</returns>
        public int InsertTrainingUserDetails(string agencyname, string firstname, string username, string password, string address, string city, string state, string zipcode, string phoneno, double platitude1, double plongitude1, string vertical)
        {
            return AgencyDAL.InsertTrainingUserDetails(agencyname, firstname, username, password, address, city, state, zipcode, phoneno, platitude1, plongitude1, vertical);
        }

        /// <summary>
        /// Get Group Types
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetGroupTypes()
        {
            return USPDHUBDAL.AgencyDAL.GetGroupTypes();
        }

        /// <summary>
        /// Insert User Permission Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="pType">pType</param>
        /// <param name="settings">settings</param>
        /// <param name="permissionID">permissionID</param>
        /// <param name="associateID">associateID</param>
        /// <param name="isTipsAdmin">isTipsAdmin</param>
        /// <param name="createdBy">createdBy</param>
        /// <returns>Int</returns>
        public int InsertUserPermissionDetails(int userID, string pType, int settings, int permissionID, int associateID, bool isTipsAdmin, int createdBy)
        {
            return AgencyDAL.InsertUserPermissionDetails(userID, pType, settings, permissionID, associateID, isTipsAdmin, createdBy);
        }

        /// <summary>
        /// Get Permissions By associateID
        /// </summary>
        /// <param name="associateID">associateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPermissionsById(int associateID)
        {
            return USPDHUBDAL.AgencyDAL.GetPermissionsById(associateID);
        }

        /// <summary>
        /// Delete Permissions
        /// </summary>
        /// <param name="permissionID">permissionID</param>
        /// <returns></returns>
        public int DeletePermissions(int permissionID)
        {
            return AgencyDAL.DeletePermissions(permissionID);
        }

        /// <summary>
        /// Get Active Verticals
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetActiveVerticals()
        {
            return USPDHUBDAL.AgencyDAL.GetActiveVerticals();
        }

        /// <summary>
        /// Delete Selected Listing
        /// </summary>
        /// <param name="listingID">listingID</param>
        public void DeleteSelectedListing(int listingID)
        {
            AgencyDAL.DeleteSelectedListing(listingID);
        }

        /// <summary>
        /// Validate Agency EmailID
        /// </summary>
        /// <param name="pEmailID">pEmailID</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>Int</returns>
        public int ValidateAgencyEmailID(string pEmailID, string vertical, string country)
        {
            return AgencyDAL.ValidateAgencyEmailID(pEmailID, vertical, country);
        }

        /// <summary>
        /// Get Promo code Details
        /// </summary>
        /// <param name="pPromocode">pPromocode</param>
        /// <returns>DataTable</returns>
        public DataTable GetPromocodeDetails(string pPromocode)
        {
            return AgencyDAL.GetPromocodeDetails(pPromocode);
        }

        /// <summary>
        /// Check Promo Code
        /// </summary>
        /// <param name="promoCode">promoCode</param>
        /// <param name="domain">domain</param>
        /// <param name="checkVertical">checkVertical</param>
        /// <returns>DataTable</returns>
        public DataTable CheckPromoCode(string promoCode, string domain, bool checkVertical)
        {
            return AgencyDAL.CheckPromoCode(promoCode, domain, checkVertical);
        }

        /// <summary>
        /// Get Domain Verticals
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDomainVerticals()
        {
            return USPDHUBDAL.AgencyDAL.GetDomainVerticals();
        }

        /// <summary>
        /// Get Active Invitations by ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveInvitations(int profileID)
        {
            return USPDHUBDAL.AgencyDAL.GetActiveInvitations(profileID);
        }

        /// <summary>
        /// Check Send Invitation Email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>Int</returns>
        public int CheckSendInvitationEmail(string email)
        {
            return USPDHUBDAL.AgencyDAL.CheckSendInvitationEmail(email);
        }

        /// <summary>
        /// Get Invitation Code Details By ID
        /// </summary>
        /// <param name="invCodeID">invCodeID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInvitatioCodeDetailsByID(int invCodeID)
        {
            return USPDHUBDAL.AgencyDAL.GetInvitatioCodeDetailsByID(invCodeID);
        }

        /// <summary>
        /// Add Invitation
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="email">email</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="invCodeID">invCodeID</param>
        /// <returns>Int</returns>
        public int AddInvitation(string firstName, string lastName, string email, int profileID, int userID, int invCodeID)
        {
            return USPDHUBDAL.AgencyDAL.AddInvitation(firstName, lastName, email, profileID, userID, invCodeID);
        }

        /// <summary>
        /// Get Invitation Details By ID
        /// </summary>
        /// <param name="affiliateInvID">affiliateInvID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInvitationDetailsByID(int? affiliateInvID)
        {
            return USPDHUBDAL.AgencyDAL.GetInvitationDetailsByID(affiliateInvID);
        }

        /// <summary>
        /// Cancel Invitation
        /// </summary>
        /// <param name="affiliateID">affiliateID</param>
        /// <param name="userID">userID</param>
        public void CancelInvitation(int affiliateID, int userID)
        {
            USPDHUBDAL.AgencyDAL.CancelInvitation(affiliateID, userID);
        }

        /// <summary>
        /// Generate SubApp Codes
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="count">count</param>
        /// <param name="isPaid">isPaid</param>
        /// <returns>Int</returns>
        public int GenerateSubAppCodes(int profileID, int createdUser, int count, bool isPaid)
        {
            return USPDHUBDAL.AgencyDAL.GenerateSubAppCodes(profileID, createdUser, count, isPaid);
        }

        /// <summary>
        /// Insert New Subcription User Details
        /// </summary>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="password">password</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>Int</returns>
        public int InsertNewSubcriptionUserDetails(double platitude1, double plongitude1, string password, int inquiryID, int pProfileSubTypeID)
        {
            return AgencyDAL.InsertNewSubcriptionUserDetails(platitude1, plongitude1, password, inquiryID, pProfileSubTypeID);
        }

        /// <summary>
        /// Update Agency Subscription
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="orderID">orderID</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="branded">branded</param>
        /// <returns>Int</returns>
        public int UpdateAgencySubscription(int inquiryID, int orderID, int subPeriod, string branded, bool isUpgrade)
        {
            return AgencyDAL.UpdateAgencySubscription(inquiryID, orderID, subPeriod, branded, isUpgrade);
        }

        /// <summary>
        /// Get Data Feeds
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pFeedsType">pFeedsType</param>
        /// <param name="moduleID">moduleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataFeeds(int pProfileID, string pFeedsType, int moduleID)
        {
            return AgencyDAL.GetDataFeeds(pProfileID, pFeedsType, moduleID);
        }

        /// <summary>
        /// Get Profiles By Vertical
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfilesByVertical(string vertical)
        {
            return USPDHUBDAL.AgencyDAL.GetProfilesByVertical(vertical);
        }

        // Tips Manager
        /// <summary>
        /// Get Audio Tips Manager
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pVerticalDomain">pVerticalDomain</param>
        /// <returns>DataTable</returns>
        public DataTable GetAudio_TipsManager(int pProfileID, int pUserID, string pVerticalDomain)
        {
            return AgencyDAL.GetAudio_TipsManager(pProfileID, pUserID, pVerticalDomain);
        }

        /// <summary>
        /// Insert and Update Audio Tips Manager
        /// </summary>
        /// <param name="pAudioID">pAudioID</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pAudioName">pAudioName</param>
        /// <param name="pAudioFile">pAudioFile</param>
        /// <param name="pIsDefault">pIsDefault</param>
        /// <param name="pDefaultAudioID">pDefaultAudioID</param>
        /// <param name="pAudioType">pAudioType</param>
        public void Insert_UpdateAudio_TipsManager(int pAudioID, int pPID, int pUserID, string pAudioName, string pAudioFile,
            bool pIsDefault, int pDefaultAudioID, string pAudioType)
        {
            AgencyDAL.Insert_UpdateAudio_TipsManager(pAudioID, pPID, pUserID, pAudioName, pAudioFile, pIsDefault, pDefaultAudioID, pAudioType);
        }

        /// <summary>
        /// Delete Audio Tips Manager by AudioID
        /// </summary>
        /// <param name="pAudioID">pAudioID</param>
        public void DeleteAudio_TipsManager(int pAudioID)
        {
            AgencyDAL.DeleteAudio_TipsManager(pAudioID);
        }

        /// <summary>
        /// Get Purchase Content Module By ProfileID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPurchaseAddOnsByProfileID(int pProfileID)
        {
            return AgencyDAL.GetPurchaseAddOnsByProfileID(pProfileID);
        }

        /// <summary>
        /// Get Custom Module Templates
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="isTemplate">isTemplate</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomModuleTemplates(string domainName, bool isTemplate)
        {
            return AgencyDAL.GetCustomModuleTemplates(domainName, isTemplate);
        }

        /// <summary>
        /// Get Custom Module App Icons
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="pIsPrivate">pIsPrivate</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomModuleAppIcons(int moduleID, string domainName, bool pIsPrivate)
        {
            return AgencyDAL.GetCustomModuleAppIcons(moduleID, domainName, pIsPrivate);
        }

        /// <summary>
        /// Update Auto On/Off
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="autoEmailOnOff">autoEmailOnOff</param>
        public void UpdateAutoOnOff(int userID, bool autoEmailOnOff)
        {
            AgencyDAL.UpdateAutoOnOff(userID, autoEmailOnOff);
        }

        /// <summary>
        /// Get App Pin Code
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppPinCode(int userId)
        {
            return AgencyDAL.GetAppPinCode(userId);
        }

        /// <summary>
        /// Create Update Pin Code
        /// </summary>
        /// <param name="pinCode">pinCode</param>
        /// <param name="appName">appName</param>
        public void CreateUpdatePinCode(string pinCode, string appName)
        {
            AgencyDAL.CreateUpdatePinCode(pinCode, appName);
        }

        /// <summary>
        /// Get Products By Domain
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetProductsByDomain(string domainName)
        {
            return USPDHUBDAL.AgencyDAL.GetProductsByDomain(domainName);
        }

        /// <summary>
        /// Insert and Update User Permissions
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="isCreate">isCreate</param>
        /// <param name="isPublisher">isPublisher</param>
        /// <param name="isReviewer">isReviewer</param>
        /// <param name="associateID">associateID</param>
        /// <param name="pageTitle">pageTitle</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void InsertUpdateUserPermissions(int profileID, int userID, int? userModuleID, bool isCreate, bool isPublisher, bool isReviewer, int associateID, string pageTitle, int modifiedUser,bool? isDeleter=false )
        {
            AgencyDAL.InsertUpdateUserPermissions(profileID, userID, userModuleID, isCreate, isPublisher, isReviewer, associateID, pageTitle, modifiedUser,isDeleter);
        }

        /// <summary>
        /// Delete Permissions By Associate UserID
        /// </summary>
        /// <param name="associateUserID">associateUserID</param>
        public void DeletePermissionsByAssociate(int associateUserID)
        {
            AgencyDAL.DeletePermissionsByAssociate(associateUserID);
        }

        /// <summary>
        /// Get Permissions By Associate UserID
        /// </summary>
        /// <param name="associateUserID">associateUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPermissionsByAssociateId(int associateUserID)
        {
            return AgencyDAL.GetPermissionsByAssociateId(associateUserID);
        }

        /// <summary>
        /// Save User Permissions By associateID
        /// </summary>
        /// <param name="associateID">associateID</param>
        /// <returns>DataTable</returns>
        public DataTable SaveUserPermissionsById(int associateID)
        {
            return USPDHUBDAL.AgencyDAL.SaveUserPermissionsById(associateID);
        }

        /// <summary>
        /// Get Permission Value By UserModuleID
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="assocUser">assocUser</param>
        /// <returns>DataTable</returns>
        public DataTable GetPermissionValueByUserModuleID(int userModuleID, int assocUser)
        {
            return AgencyDAL.GetPermissionValueByUserModuleID(userModuleID, assocUser);
        }

        public DataTable GetSubAppsByPID(int profileID)
        {
            return AgencyDAL.GetSubAppsByPID(profileID);
        }

        public DataTable GetProfileSubscriptionType()
        {
            return AgencyDAL.GetProfileSubscriptionType();
        }

        public DataTable GetUpgradeInfoByProfileID(int profileId)
        {
            return AgencyDAL.GetUpgradeInfoByProfileID(profileId);
        }

    }
}
