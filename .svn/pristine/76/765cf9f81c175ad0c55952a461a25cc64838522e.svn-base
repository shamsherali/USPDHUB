using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;

namespace USPDHUBBLL
{
    public class SurveyBLL
    {
        /// <summary>
        /// Get Survey Types
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSurveyTypes()
        {
            return SurveyDAL.GetSurveyTypes();
        }

        /// <summary>
        /// Get Question Types
        /// </summary>
        /// <param name="pSType">pSType</param>
        /// <returns>DataTable</returns>
        public DataTable GetQuestionTypes(string pSType = "Survey")
        {
            return SurveyDAL.GetQuestionTypes(pSType);
        }

        /// <summary>
        /// Insert and Update Survey
        /// </summary>
        /// <param name="pSurveyID">pSurveyID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pSurveyName">pSurveyName</param>
        /// <param name="pDescription">pDescription</param>
        /// <param name="pSurveyTypeID">pSurveyTypeID</param>
        /// <param name="pThanksMessage">pThanksMessage</param>
        /// <param name="pExDate">pExDate</param>
        /// <param name="pIsPrivate">pIsPrivate</param>
        /// <param name="pPublishDate">pPublishDate</param>
        /// <param name="pPublishBy">pPublishBy</param>
        /// <param name="pIsPublish">pIsPublish</param>
        /// <param name="cUserId">cUserId</param>
        /// <returns>Int</returns>
        public int Insert_Update_Survey(int pSurveyID, int pProfileID, int pUserID, string pSurveyName, string pDescription, int pSurveyTypeID,
            string pThanksMessage, DateTime? pExDate, bool pIsPrivate, DateTime? pPublishDate, int? pPublishBy, bool pIsPublish, int cUserId)
        {
            return SurveyDAL.Insert_Update_Survey(pSurveyID, pProfileID, pUserID, pSurveyName, pDescription, pSurveyTypeID,
                pThanksMessage, pExDate, pIsPrivate, pPublishDate, pPublishBy, pIsPublish, cUserId);
        }

        /// <summary>
        /// Get Survey Details By ID
        /// </summary>
        /// <param name="pSurveyID">pSurveyID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSurveyDetailsByID(int pSurveyID)
        {
            return SurveyDAL.GetSurveyDetailsByID(pSurveyID);
        }

        /// <summary>
        /// Get Manage Surveys
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageSurveys(int pProfileID)
        {
            return SurveyDAL.GetManageSurveys(pProfileID);
        }

        /// <summary>
        /// Delete Survey
        /// </summary>
        /// <param name="pSurveyID">pSurveyID</param>
        public void DeleteSurvey(int pSurveyID)
        {
            SurveyDAL.DeleteSurvey(pSurveyID);
        }

        /// <summary>
        /// Get Survey Type Max Questions Count
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>Int</returns>
        public int GetSurveyTypeMaxQuestionsCount(int pProfileID)
        {
            return SurveyDAL.GetSurveyTypeMaxQuestionsCount(pProfileID);
        }

        // QUESTIONS OPTIONS
        /// <summary>
        /// Insert and Update Questions
        /// </summary>
        /// <param name="pQuestionID">pQuestionID</param>
        /// <param name="pQuestionText">pQuestionText</param>
        /// <param name="pQuestionTypeID">pQuestionTypeID</param>
        /// <param name="pSurveyID">pSurveyID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pIsRequired">pIsRequired</param>
        /// <param name="pErrorMessage">pErrorMessage</param>
        /// <param name="pAnswerCheckType">pAnswerCheckType</param>
        /// <param name="pAnswerCheckCount">pAnswerCheckCount</param>
        /// <returns>Int</returns>
        public int Insert_Update_Questions(int pQuestionID, string pQuestionText, int pQuestionTypeID, int pSurveyID, int pUserID,
            bool pIsRequired, string pErrorMessage, string pAnswerCheckType, string pAnswerCheckCount)
        {
            return SurveyDAL.Insert_Update_Questions(pQuestionID, pQuestionText, pQuestionTypeID, pSurveyID, pUserID,
                pIsRequired, pErrorMessage, pAnswerCheckType, pAnswerCheckCount);
        }

        /// <summary>
        /// Delete Quesion Options
        /// </summary>
        /// <param name="QID">QID</param>
        public void DeleteQuesionOptions(int QID)
        {
            SurveyDAL.DeleteQuestionOptions(QID);
        }

        /// <summary>
        /// Insert Answer Options
        /// </summary>
        /// <param name="pQuestionID">pQuestionID</param>
        /// <param name="pSurveyID">pSurveyID</param>
        /// <param name="pAnswerOption">pAnswerOption</param>
        /// <param name="pOrderNo">pOrderNo</param>
        /// <param name="pUserID">pUserID</param>
        public void InsertAnswerOptions(int pQuestionID, int pSurveyID, string pAnswerOption, int pOrderNo, int pUserID)
        {
            SurveyDAL.InsertAnswerOptions(pQuestionID, pSurveyID, pAnswerOption, pOrderNo, pUserID);
        }

        /// <summary>
        /// Get Questions By SurveyID
        /// </summary>
        /// <param name="pSurveyID">pSurveyID</param>
        /// <returns>DataTable</returns>
        public DataTable GetQuestionsBySurveyID(int pSurveyID)
        {
            return SurveyDAL.GetQuestionsBySurveyID(pSurveyID);
        }

        /// <summary>
        /// Get Question Options By QuestionID
        /// </summary>
        /// <param name="pQID">pQID</param>
        /// <returns>DataTable</returns>
        public DataTable GetQuestionOptionsByQID(int pQID)
        {
            return SurveyDAL.GetQuestionOptionsByQID(pQID);
        }

        /// <summary>
        /// Get Survey Answers By QuestionID
        /// </summary>
        /// <param name="pQID">pQID</param>
        /// <param name="pQuestionType">pQuestionType</param>
        /// <returns>DataTable</returns>
        public DataTable GetSurveyAnswersByQID(int pQID, string pQuestionType = "")
        {
            return SurveyDAL.GetSurveyAnswersByQID(pQID, pQuestionType);
        }

        /// <summary>
        /// Get Answers By OptionID
        /// </summary>
        /// <param name="pOptionID">pOptionID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAnswersByOptionID(int pOptionID)
        {
            return SurveyDAL.GetAnswersByOptionID(pOptionID);
        }

        /// <summary>
        /// Copy Survey
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="SurveyID">SurveyID</param>
        /// <param name="SurveyName">SurveyName</param>
        /// <returns>Int</returns>
        public int Copy_Survey(int UserID, int SurveyID, string SurveyName)
        {
            return SurveyDAL.Copy_Survey(UserID, SurveyID, SurveyName);
        }

        /// <summary>
        /// Copy Survey Questions
        /// </summary>
        /// <param name="SurveyID">SurveyID</param>
        /// <param name="InsertedSurveyID">InsertedSurveyID</param>
        /// <returns>DataTable</returns>
        public DataTable CopySurveyQuestions(int SurveyID, int InsertedSurveyID)
        {
            return SurveyDAL.CopySurveyQuestions(SurveyID, InsertedSurveyID);
        }

        /// <summary>
        /// Copy Survey Questions Options
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="InsertedSurveyID">InsertedSurveyID</param>
        /// <param name="SurveyID">SurveyID</param>
        /// <param name="QuestionID">QuestionID</param>
        /// <param name="CopyQuestionID">CopyQuestionID</param>
        public void CopySurveyQuestionsOptions(int UserID, int InsertedSurveyID, int SurveyID, int QuestionID, int CopyQuestionID)
        {
            SurveyDAL.CopySurveyQuestionsOptions(UserID, InsertedSurveyID, SurveyID, QuestionID, CopyQuestionID);
        }

        /// <summary>
        /// Copy Survey
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="oldSureveyID">oldSureveyID</param>
        /// <param name="newSurveyName">newSurveyName</param>
        /// <returns>Int</returns>
        public int CopySurvey(int userID, int createdUser, int oldSureveyID, string newSurveyName)
        {
            return SurveyDAL.CopySurvey(userID, createdUser, oldSureveyID, newSurveyName);
        }

        /// <summary>
        /// Get Answers Skip Count
        /// </summary>
        /// <param name="pSID">pSID</param>
        /// <returns>DataTable</returns>
        public DataTable  GetAnswersSkipCount(int pSID)
        {
            return SurveyDAL.GetAnswersSkipCount(pSID);
        }

        /// <summary>
        /// Delete Question
        /// </summary>
        /// <param name="pQID">pQID</param>
        public void DeleteQuestion(int pQID)
        {
            SurveyDAL.DeleteQuestion(pQID);
        }

        /// <summary>
        /// Survey Publish/Unpublish
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="mUserID">mUserID</param>
        /// <param name="SID">SID</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="isPublished">isPublished</param>
        public void SurveyPublish_Unpublish(bool flag, int userID, int mUserID, int SID, DateTime? publishDate, bool isPublished)
        {
            SurveyDAL.SurveyPublish_Unpublish(flag, userID, mUserID, SID, publishDate, isPublished);
        }

        /// <summary>
        /// Get Device Count By PID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetDeviceCountByPID(int pProfileID)
        {
            return SurveyDAL.GetDeviceCountByPID(pProfileID);
        }
        /// <summary>
        /// Get Survey Answers Count
        /// </summary>
        /// <param name="surveyID">surveyID</param>
        /// <returns>Int</returns>
        public int GetSurveyAnswersCount(int surveyID)
        {
            return SurveyDAL.GetSurveyAnswersCount(surveyID);
        }

        /// <summary>
        /// Get Completed Answers Count By SurveyID
        /// </summary>
        /// <param name="SurveyID">SurveyID</param>
        /// <returns>DataTable</returns>
        public DataTable  GetCompletedAnswersCountBySurveyID(int SurveyID)
        {
            return SurveyDAL.GetCompletedAnswersCountBySurveyID(SurveyID);
        }

        /// <summary>
        /// Get Surveys by UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetSurveys(int UserId)
        {
            return SurveyDAL.GetSurveys(UserId);
        }

        /// <summary>
        /// Update Surveys Order
        /// </summary>
        /// <param name="SurveyID">SurveyID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="ID">ID</param>
        /// <returns>Int</returns>
        public int UpdateSurveysOrder(int SurveyID, int OrderNo, int ID)
        {
            return SurveyDAL.UpdateSurveysOrder(SurveyID, OrderNo, ID);
        }
    }
}
