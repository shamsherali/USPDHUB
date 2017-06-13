using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserFormsDAL;

namespace UserFormsBLL
{
    public class BusinessBLL
    {
        /// <summary>
        /// for retrieving profile details by profile id
        /// </summary>
        /// <param name="profileID">profileid</param>
        /// <returns></returns>
        public DataTable GetProfileDetailsByProfileID(int profileID)
        {
            return BusinessDAL.GetProfileDetailsByProfileID(profileID);
        }
        /// <summary>
        /// for retrieving business details by userid
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns></returns>
        public DataTable GetBusinessDeatilsByUserID(int userID)
        {
            return BusinessDAL.GetBusinessDetailsByUserID(userID);
        }
        /// <summary>
        /// for retrieving user details by user id
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>datatable</returns>
        public DataTable GetUserDetailsByUserID(int userID)
        {
            return BusinessDAL.GetUserDetailsByUserID(userID);
        }
        /// <summary>
        /// for retrieving user details by user id
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>data table</returns>
        public DataTable GetUserDetailsByID(int userID)
        {
            return BusinessDAL.GetUserDetailsByID(userID);
        }
        /// <summary>
        /// for retrieving user permissions by associateid
        /// </summary>
        /// <param name="associateID">associateID</param>
        /// <returns>data table</returns>
        public DataTable GetPermissionsById(int associateID)
        {
            return BusinessDAL.GetPermissionsById(associateID);
        }
        /// <summary>
        /// for retrieving selected tools by user id
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>datatable</returns>
        public DataTable GetSelectedToolsByUserID(int userID)
        {
            return BusinessDAL.GetSelectedToolsByUserID(userID);
        }
        /// <summary>
        /// for retrieving  menu links by pakage number and liteversion
        /// </summary>
        /// <param name="packageNumber">package number</param>
        /// <param name="isLiteVersion">isLiteversion</param>
        /// <returns>datatable</returns>
        public DataTable GetPackageMenuLinks(int packageNumber, bool isLiteVersion)
        {
            return BusinessDAL.GetPackageMenuLinks(packageNumber, isLiteVersion);
        }
        /// <summary>
        /// retrieving permissions using associateuserid
        /// </summary>
        /// <param name="associateUserID">associateUserID</param>
        /// <returns>datatable</returns>
        public DataTable GetPermissionsByAssociateId(int associateUserID)
        {
            return BusinessDAL.GetPermissionsByAssociateId(associateUserID);
        }
        /// <summary>
        /// retrieves th publishers of the bulletin
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="itemType">itemType</param>
        /// <returns>datatable</returns>
        public DataTable GetAllPublishersofItem(int userID, string itemType, int customId)
        {
            return BusinessDAL.GetAllPublishersofItem(userID, itemType, customId);
        }
        /// <summary>
        /// retrieves tab names for default profile.
        /// </summary>
        /// <param name="DomainName">domain name</param>
        /// <returns>datatable</returns>
        public DataTable GetDefaultProfileTabNames(string DomainName)
        {
            return BusinessDAL.GetDefaultProfileTabNames(DomainName);
        }
        /// <summary>
        /// for retrieving dashboard icons
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>datatable</returns>
        public DataTable DashboardIcons(int userID)
        {
            return BusinessDAL.DashboardIcons(userID);
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

        #region Store Module Functionality
        public bool CheckModulePermission(string ButtonType, int ProfileID)
        {
            return BusinessDAL.CheckModulePermission(ButtonType, ProfileID);
        }
        #endregion
    }
}
