using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class PrivateModuleDAL
    {
        public static DataTable GetPrivateModuleInvitaions(int pPID, int pUserModuleID)
        {
            DataTable dtInvitaion = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateModuleInviations", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtInvitaion);

                return dtInvitaion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int InvitationsAction(string pActionType, int pInvationID, bool pIsActive, int pInvitorID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_PrivateModuleInvitations_Actions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Type", pActionType);
                sqlCmd.Parameters.AddWithValue("@InvationID", pInvationID);
                sqlCmd.Parameters.AddWithValue("@IsActive", pIsActive);
                sqlCmd.Parameters.AddWithValue("@InviterID", pInvitorID);
                return Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetInviters(int pPID, int pGroupID)
        {
            DataTable dtInviers = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInviters", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@GroupID", pGroupID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtInviers);

                return dtInviers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int Insert_Update_Invitation(int pInvitatorUserID, string pStatus, string pDeviceID, string pUniqueID, string pOTP,
             string pDeviceType, int pInvitationID, int pUserModuleID, int pPID, string pMobileNumber, string pButtonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_Invitations", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InvatorID", pInvitatorUserID);
                sqlCmd.Parameters.AddWithValue("@Status", pStatus);
                sqlCmd.Parameters.AddWithValue("@DeviceID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", pUniqueID);
                sqlCmd.Parameters.AddWithValue("@OTP", pOTP);
                sqlCmd.Parameters.AddWithValue("@DeviceType", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@InviationID", pInvitationID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", pMobileNumber);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                return Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetInvitationsByInvitorID(int pinvitatorID)
        {
            DataTable dtInvitaion = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvitationsByInvitorID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InvitorID", pinvitatorID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtInvitaion);

                return dtInvitaion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }//

        public static int Insert_Update_Invitees(string pFirstName, string pLastname, string pEmailID, int pPID, int pUserModuleID, int pContactID, string pButtonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_Invitees", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", pFirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", pLastname);
                sqlCmd.Parameters.AddWithValue("@EmailID", pEmailID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@ContactID", pContactID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                return Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetAppDisplayName(int pPID)
        {
            DataTable dtAppDisplayName = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppDisplayNames", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAppDisplayName);

                return dtAppDisplayName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

    }
}
