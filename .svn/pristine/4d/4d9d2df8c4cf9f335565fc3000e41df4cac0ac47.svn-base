using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class SurveyDAL
    {
        /// <summary>
        /// retrieve questionsby survey id
        /// </summary>
        /// <param name="pSurveyID">SurveyID</param>
        /// <returns>data table</returns>
        public static DataTable GetQuestionsBySurveyID(int pSurveyID)
        {
            DataTable dtQuestions = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetQuestionsBySurveyID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtQuestions);
                return dtQuestions;
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
        /// get options for the questions by question id
        /// </summary>
        /// <param name="pQID">questionid</param>
        /// <returns>datatble</returns>
        public static DataTable GetQuestionOptionsByQID(int pQID)
        {
            DataTable dtQuestion = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetQuestionOptionsByQuestionID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QuestionID", pQID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtQuestion);
                return dtQuestion;
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
