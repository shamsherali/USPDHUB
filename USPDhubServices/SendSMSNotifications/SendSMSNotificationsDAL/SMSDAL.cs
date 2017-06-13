using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SendSMSNotificationsDAL
{
    public class SMSDAL
    {
        public string Conn = ConfigurationSettings.AppSettings["USPDhubDevServer"].ToString();

        public DataTable GetProfileDetailsByProfileID(int profileID)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            DataTable vtable = new DataTable("validate");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessProfileByID", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
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
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }


        public int AddLogInDetails(DateTime LogDate, DateTime LogTime)
        {
            int LogID;
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_AddSchSMSLogin_Details", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Log_Date", LogDate);
                sqlCmd.Parameters.AddWithValue("@LogIn_Time", LogTime);
                LogID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();
                return LogID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public void AddLogOutDetails(int LogID, DateTime LogOutTime)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_AddSchSMSLogOut_Details", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Log_ID", LogID);
                sqlCmd.Parameters.AddWithValue("@LogOut_Time", LogOutTime);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public DataTable GetSheduledSMSNotifications()
        {
            DataTable schNotifications = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetSheduledSMSNotifications", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(schNotifications);
                return schNotifications;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public void UpdateSMSSentStatus(int smsId)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_UpdateSMSSentStatus", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SMSId", smsId);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        public void InsertExceptionDetails(string dataTablename, string errorMessage, string innerException, string data, string typeOfService)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Azure_InsertExceptionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@dataTablename", dataTablename);
                sqlCmd.Parameters.AddWithValue("@errorMessage", errorMessage);
                sqlCmd.Parameters.AddWithValue("@innerException", innerException);
                sqlCmd.Parameters.AddWithValue("@data", data);
                sqlCmd.Parameters.AddWithValue("@typeOfService", typeOfService);
                sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }

        }
    }
}
