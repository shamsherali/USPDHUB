using System;
using System.Data;

namespace USPDHUBBLL
{
    public class MenuDashBoard
    {
        /// <summary>
        /// Get Master Menu Links
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetMasterMenuLinks()
        {
            return USPDHUBDAL.MenuDashBoard.GetMasterMenuLinks();
        }

        /// <summary>
        /// Get Child Menu Links By MasterID
        /// </summary>
        /// <param name="masterID">masterID</param>
        /// <returns>DataTable</returns>
        public DataTable GetChildMenuLinksByMasterID(int masterID)
        {
            return USPDHUBDAL.MenuDashBoard.GetChildMenuLinksByMasterID(masterID);
        }

        /// <summary>
        /// Get Scheduled Email Count By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int GetSchEmailCountByProfileID(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetSchEmailCountByProfileID(profileID);
        }

        /// <summary>
        /// Get Top Profiles For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Images For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesImagesForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesImagesForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Video For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesVideoForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesVideoForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Newsletter For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesNewsletterForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesNewsletterForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Coupons For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesCouponsForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesCouponsForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Affiliates For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesAffiliatesForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesAffiliatesForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Events For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesEventsForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesEventsForDashBoard(profileID);
        }

        /// <summary>
        /// Get Top Profiles Business Updates For DashBoard
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTopProfilesBusinessUpdatesForDashBoard(int profileID)
        {
            return USPDHUBDAL.MenuDashBoard.GetTopProfilesBusinessUpdatesForDashBoard(profileID);
        }
        // *** Dashboard Redign 29-08-2012 *** //

        /// <summary>
        /// Get Parent Menu Links
        /// </summary>
        /// <returns>DataTable</returns>
     
        public DataTable GetParentMenuLinks(bool isLiteVersion)

        {
            return USPDHUBDAL.MenuDashBoard.GetParentMenuLinks(isLiteVersion);
        }
    }
}
