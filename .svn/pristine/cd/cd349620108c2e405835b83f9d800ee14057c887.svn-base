using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class SurveyDAL
    {
        public static DataTable GetSurveyTypes()
        {
            DataTable dtSurveyType = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSurveyTypes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtSurveyType);

                return dtSurveyType;
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

        public static DataTable GetQuestionTypes(string pSType)
        {
            DataTable dtSurveyType = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetQuestionTypes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SType", pSType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtSurveyType);

                return dtSurveyType;
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

        public static int Insert_Update_Survey(int pSurveyID, int pProfileID, int pUserID, string pSurveyName, string pDescription, int pSurveyTypeID,
            string pThanksMessage, DateTime? pExDate, bool pIsPrivate, DateTime? pPublishDate, int? pPublishBy, bool pIsPublish, int cUserId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_Suvery", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@Name", pSurveyName);
                sqlCmd.Parameters.AddWithValue("@Description", pDescription);
                sqlCmd.Parameters.AddWithValue("@SurveyTypeID", pSurveyTypeID);
                sqlCmd.Parameters.AddWithValue("@ThankseMSG", pThanksMessage);
                sqlCmd.Parameters.AddWithValue("@Expiration_Date", pExDate);
                sqlCmd.Parameters.AddWithValue("@IsPrivate", pIsPrivate);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", pPublishDate);
                sqlCmd.Parameters.AddWithValue("@Published_By", pPublishBy);
                sqlCmd.Parameters.AddWithValue("@IsPublished", pIsPublish);
                sqlCmd.Parameters.AddWithValue("@CUserId", cUserId);
                pSurveyID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return pSurveyID;
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

        public static DataTable GetSurveyDetailsByID(int pSurveyID)
        {
            DataTable dtSurveyDetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSurveyDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtSurveyDetails);
                return dtSurveyDetails;
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

        public static DataTable GetManageSurveys(int pProfileID)
        {
            DataTable dtManageSurvey = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMangeSurveys", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtManageSurvey);
                return dtManageSurvey;
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

        public static void DeleteSurvey(int pSurveyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteSurvey", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                sqlCmd.ExecuteNonQuery();
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

        public static int GetSurveyTypeMaxQuestionsCount(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int MaxCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSurveyTypeMaxQuestions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                MaxCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return MaxCount;
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

        public static int Insert_Update_Questions(int pQuestionID, string pQuestionText, int pQuestionTypeID, int pSurveyID, int pUserID,
            bool pIsRequired, string pErrorMessage, string pAnswerCheckType, string pAnswerCheckCount)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                if (pAnswerCheckCount == "")
                {
                    pAnswerCheckCount = "0";
                }

                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_Question", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Question_ID", pQuestionID);
                sqlCmd.Parameters.AddWithValue("@QuestionText", pQuestionText);
                sqlCmd.Parameters.AddWithValue("@QuestionType", pQuestionTypeID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@IsRequired", pIsRequired);
                sqlCmd.Parameters.AddWithValue("@Error_Message", pErrorMessage);
                sqlCmd.Parameters.AddWithValue("@Answers_CheckType", pAnswerCheckType);
                sqlCmd.Parameters.AddWithValue("@Answers_CheckCount", Convert.ToInt32(pAnswerCheckCount));
                pQuestionID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return pQuestionID;
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

        public static int Copy_Survey(int UserID, int SurveyID, string SurveyName)
        {
            int currentSurveyID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CopyManageSurveys", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Sender_UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", SurveyID);
                sqlCmd.Parameters.AddWithValue("@SurveyName", SurveyName);
                currentSurveyID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return currentSurveyID;
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

        public static void DeleteQuestionOptions(int pQID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Delete_QuestionOptions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Question_ID", pQID);
                sqlCmd.ExecuteNonQuery();
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

        public static void CopySurveyQuestionsOptions(int UserID, int InsertedSurveyID, int SurveyID, int QuestionID, int CopyQuestionID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CopyQuestionsOptions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@InsertedSurveyID", InsertedSurveyID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", SurveyID);
                sqlCmd.Parameters.AddWithValue("@Question_ID", QuestionID);
                sqlCmd.Parameters.AddWithValue("@CopyQuestion_ID", CopyQuestionID);
                sqlCmd.ExecuteNonQuery();
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

        public static void InsertAnswerOptions(int pQuestionID, int pSurveyID, string pAnswerOption, int pOrderNo, int pUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_QuestionOptions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Question_ID", pQuestionID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                sqlCmd.Parameters.AddWithValue("@Answer_Option", pAnswerOption);
                sqlCmd.Parameters.AddWithValue("@Order_No", pOrderNo);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.ExecuteNonQuery();
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

        public static DataTable CopySurveyQuestions(int SurveyID, int InsertedSurveyID)
        {
            DataTable dtQuestions = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CopySurveyQuestionsBySurveyID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", SurveyID);
                sqlCmd.Parameters.AddWithValue("@InsertedSurveyID", InsertedSurveyID);
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

        public static DataTable GetSurveyAnswersByQID(int pQID, string pQuestionType = "")
        {
            DataTable dtAnswers = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSurveyAnswersByQID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QuestionID", pQID);
                sqlCmd.Parameters.AddWithValue("@QuestionType", pQuestionType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAnswers);
                return dtAnswers;
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
        public static DataTable GetAnswersByOptionID(int pOptionID)
        {
            DataTable dtAnswers = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAnswersByOptionID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OptionID", pOptionID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAnswers);
                return dtAnswers;
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
        public static int CopySurvey(int userID, int createdUser, int oldSureveyID, string newSurveyName)
        {
            int newSuveryID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CopySurvey", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CreatedUserID", createdUser);
                sqlCmd.Parameters.AddWithValue("@OldSurveyID", oldSureveyID);
                sqlCmd.Parameters.AddWithValue("@NewSurveyName", newSurveyName);
                newSuveryID = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return newSuveryID;
        }
        public static DataTable GetAnswersSkipCount(int pSID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAnswerSkips = new DataTable("dtAnswerSkips");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAnswersSkipCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SID", pSID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAnswerSkips);
                return dtAnswerSkips;
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
        public static void DeleteQuestion(int pQID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteQuestion", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QID", pQID);
                sqlCmd.ExecuteNonQuery();
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
        public static void SurveyPublish_Unpublish(bool flag, int userID, int mUserID, int SID, DateTime? publishDate, bool isPublished)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Survey_Publish_Unpublish", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserID", mUserID);
                sqlCmd.Parameters.AddWithValue("@SID", SID);
                sqlCmd.Parameters.AddWithValue("@PublishDate", publishDate);
                sqlCmd.Parameters.AddWithValue("@IsPublished", isPublished);
                sqlCmd.ExecuteNonQuery();
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
        public static DataTable GetDeviceCountByPID(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDeviceCounts = new DataTable("dtDeviceCounts");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeviceCountByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDeviceCounts);
                return dtDeviceCounts;
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
        public static int GetSurveyAnswersCount(int surveyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSurveyAnswersCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", surveyID);
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
        public static DataTable  GetCompletedAnswersCountBySurveyID(int surveyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtCompletedAnswers = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCompletedAnswersCountBySurveyID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", surveyID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtCompletedAnswers);
                return dtCompletedAnswers;

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
        public static DataTable GetSurveys(int userID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSurveys", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        public static int UpdateSurveysOrder(int SurveyID, int orderNo, int id)
        {
            int cnt = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSurveysOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", SurveyID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                cnt = sqlCmd.ExecuteNonQuery();
                return cnt;
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
