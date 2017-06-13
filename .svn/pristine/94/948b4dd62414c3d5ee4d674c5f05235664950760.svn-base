using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class BusinessDAL
    {
        /// <summary>
        /// retreiving profile details by profile id
        /// </summary>
        /// <param name="profileID">profile id</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileDetailsByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessProfileByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
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
        /// <summary>
        /// for retrievig user details by user id 
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetUserDetailsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
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
        /// <summary>
        /// for retrieving business details by userid
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetBusinessDetailsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
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
        /// <summary>
        /// for retrieving user details by userid
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetUserDetailsByID(int userID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(user);

                return user;
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
        /// <summary>
        /// for retrieving permissions by associate id
        /// </summary>
        /// <param name="associateID">associateid</param>
        /// <returns>datatable</returns>
        public static DataTable GetPermissionsById(int associateID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtPermission");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPermissionsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssociateID", associateID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                return dt;
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
        /// <summary>
        /// for retrieving selected tools by userid
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetSelectedToolsByUserID(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSelectedToolsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                return dt;
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
        /// <summary>
        /// for retrieving menu links for lite version.
        /// </summary>
        /// <param name="packageNumber">package number</param>
        /// <param name="isLiteVersion">isliteVersion</param>
        /// <returns>datatable</returns>
        public static DataTable GetPackageMenuLinks(int packageNumber, bool isLiteVersion)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPackageMenuLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PackageNumber", packageNumber);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

                return dt;
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
        /// <summary>
        /// for retrieving permissions by associate id
        /// </summary>
        /// <param name="associateID">associateid</param>
        /// <returns>datatable</returns>
        public static DataTable GetPermissionsByAssociateId(int associateUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAudio = new DataTable("dtAssociatePermission");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAssociatePermission", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssocUserID", associateUserID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtAudio);
                return dtAudio;
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
        /// <summary>
        /// retrieving all publishers of an item.
        /// </summary>
        /// <param name="userID">userid</param>
        /// <param name="itemType">itemtype</param>
        /// <returns>datatable</returns>
        public static DataTable GetAllPublishersofItem(int userID, string itemType, int customId)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllPublishersofItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ItemType", itemType);
                sqlCmd.Parameters.AddWithValue("@CustomID", customId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                return vtable;
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
        /// <summary>
        /// for getting tab details by module
        /// </summary>
        /// <param name="moduleType">moduletype</param>
        /// <param name="moduleID">moduleid</param>
        /// <param name="userID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetTabDetailsByModule(string moduleType, int moduleID, int userID)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetTabDetailsByModule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@ModuleType", moduleType);
                sqlCmd.Parameters.AddWithValue("@ManageID", moduleID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtinv);
                return dtinv;
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
        /// <summary>
        /// for getting default tab details by domain name
        /// </summary>
        /// <param name="DomainName">domain name</param>
        /// <returns>data table</returns>
        public static DataTable GetDefaultProfileTabNames(string DomainName)
        {
            DataTable dtDefaultProfileTabs = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDefaultProfileTabs", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DomainName", DomainName);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDefaultProfileTabs);

                return dtDefaultProfileTabs;
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
        /// <summary>
        /// for retrieving dashboard icons by userid
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>datatable</returns>
        public static DataTable DashboardIcons(int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDashboardIcons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
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
        public static DataTable GetUserDtlsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDtlsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
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

        #region Store Module Functionality
        public static bool CheckModulePermission(string ButtonType, int ProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckModulePermission", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ButtonType", ButtonType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                return Convert.ToBoolean(sqlCmd.ExecuteScalar());
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
        #endregion
    }
}
