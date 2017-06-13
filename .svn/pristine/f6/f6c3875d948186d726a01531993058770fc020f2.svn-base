using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LeadsModels;

namespace LeadsDAL
{
    public class InquiryDAL
    {
        public static int SaveResellerInquiry(Inquiry objInquiry)
        {
            int inquiryId = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SaveLeadsInquiry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ResellerId", objInquiry.ResellerId);
                sqlCmd.Parameters.AddWithValue("@ReferralURL", objInquiry.ReferralURL);
                sqlCmd.Parameters.AddWithValue("@Name", objInquiry.Name);
                sqlCmd.Parameters.AddWithValue("@BusinessName", objInquiry.BusinessName);
                sqlCmd.Parameters.AddWithValue("@PhoneNumer", objInquiry.PhoneNumer);
                sqlCmd.Parameters.AddWithValue("@EmailAddress", objInquiry.EmailAddress);
                sqlCmd.Parameters.AddWithValue("@City", objInquiry.City);
                sqlCmd.Parameters.AddWithValue("@State", objInquiry.State);
                sqlCmd.Parameters.AddWithValue("@BestDayTime", objInquiry.BestDayTime);

                inquiryId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return inquiryId;
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
        public static DataTable GetResellerInfo(string retrieveName)
        {
            DataTable dtResellerInfo = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetResellerInfo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RetrieveName", retrieveName);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtResellerInfo);
                return dtResellerInfo;
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
