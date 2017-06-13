using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace USPDHUBBLL
{
    public class PrivateModuleBLL
    {
        /// <summary>
        /// Get Private Module Invitaions
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPrivateModuleInvitaions(int pPID, int pUserModuleID)
        {
            return USPDHUBDAL.PrivateModuleDAL.GetPrivateModuleInvitaions(pPID, pUserModuleID);
        }

        /// <summary>
        /// Invitations Action
        /// </summary>
        /// <param name="pActionType">pActionType</param>
        /// <param name="pInvationID">pInvationID</param>
        /// <param name="pIsActive">pIsActive</param>
        /// <param name="pInvitorID">pInvitorID</param>
        /// <returns>Int</returns>
        public int InvitationsAction(string pActionType, int pInvationID, bool pIsActive, int pInvitorID)
        {
            return USPDHUBDAL.PrivateModuleDAL.InvitationsAction(pActionType, pInvationID, pIsActive, pInvitorID);
        }

        /// <summary>
        /// Get Inviters
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <param name="pGroupID">pGroupID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInviters(int pPID, int pGroupID)
        {
            return USPDHUBDAL.PrivateModuleDAL.GetInviters(pPID, pGroupID);
        }

        /// <summary>
        /// Insert and Update Invitation
        /// </summary>
        /// <param name="pInvitatorUserID">pInvitatorUserID</param>
        /// <param name="pStatus">pStatus</param>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pUniqueID">pUniqueID</param>
        /// <param name="pOTP">pOTP</param>
        /// <param name="pDeviceType">pDeviceType</param>
        /// <param name="pInvitationID">pInvitationID</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pMobileNumber">pMobileNumber</param>
        /// <returns>Int</returns>
        public int Insert_Update_Invitation(int pInvitatorUserID, string pStatus, string pDeviceID, string pUniqueID, string pOTP,
            string pDeviceType, int pInvitationID, int pUserModuleID, int pPID, string pMobileNumber, string pButtonType)
        {
            return USPDHUBDAL.PrivateModuleDAL.Insert_Update_Invitation(pInvitatorUserID,
                pStatus, pDeviceID, pUniqueID, pOTP, pDeviceType, pInvitationID, pUserModuleID, pPID, pMobileNumber, pButtonType);
        }

        /// <summary>
        /// Get Invitations By InvitorID
        /// </summary>
        /// <param name="pinvitatorID">pinvitatorID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInvitationsByInvitorID(int pinvitatorID)
        {
            return USPDHUBDAL.PrivateModuleDAL.GetInvitationsByInvitorID(pinvitatorID);
        }

        /// <summary>
        /// Insert and Update Invitees
        /// </summary>
        /// <param name="pFirstName">pFirstName</param>
        /// <param name="pLastname">pLastname</param>
        /// <param name="pEmailID">pEmailID</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pContactID">pContactID</param>
        /// <returns>Int</returns>
        public int Insert_Update_Invitees(string pFirstName, string pLastname, string pEmailID, int pPID, int pUserModuleID, int pContactID, string pButtonType)
        {
            return USPDHUBDAL.PrivateModuleDAL.Insert_Update_Invitees(pFirstName, pLastname, pEmailID, pPID, pUserModuleID, pContactID, pButtonType);
        }

        /// <summary>
        /// Get App Display Name
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppDisplayName(int pPID)
        {
            return USPDHUBDAL.PrivateModuleDAL.GetAppDisplayName(pPID);
        }



    }
}
