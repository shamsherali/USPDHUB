using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Polls.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Polls
{
    public partial class SurveyResults : System.Web.UI.Page
    {
        public string RootPath = "";
        public string DomainName = "";
        public int ProfileID = 0;
        public string Surveys_IDs = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var ss = EncryptDecrypt.DESEncrypt("10319");
                ss = EncryptDecrypt.DESEncrypt("10001");

                if (Request.QueryString["PID"] != null)
                {
                    ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["PID"]).Replace("irhmalli", "=").Replace("irhPASS", "+")));
                }
                if (Request.QueryString["SID"] != null)
                {
                    Surveys_IDs = Convert.ToString(Request.QueryString["SID"]);
                }
                if (!IsPostBack)
                {
                    if (Request.QueryString["CT"] != null)
                    {
                        hdnCounter.Value = Convert.ToString(Request.QueryString["CT"]);
                    }
                    if (Request.QueryString["CType"] != null)
                    {
                        hdnChartType.Value = Convert.ToString(Request.QueryString["CType"]);
                    }
                    AutoDataBind();
                    
                }
            }
            catch (Exception ex)
            {
                InsertExceptionDetails("DEMOPOll", "surveyreport.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void AutoDataBind()
        {
            if (Surveys_IDs != string.Empty)
            {
                int surveyID = Convert.ToInt32(Surveys_IDs);
                DataTable dtSurvey = SurveyDAL.GetSurveyDetailsByID(surveyID);
                /*** Getting Questions Details ***/
                DataTable dtQuestion = SurveyDAL.GetQuestionsBySurveyID(surveyID);
                lblTitle.Text = Convert.ToString(dtSurvey.Rows[0]["Name"]) + " - " + Convert.ToString(dtQuestion.Rows[0]["Text"]);                
            }
        }
        public static void InsertExceptionDetails(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertErrorLogDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Type", errorType);
                sqlCmd.Parameters.AddWithValue("@PageName", pPageName);
                sqlCmd.Parameters.AddWithValue("@MethodName", methodName);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@StackTrace", strackTrace);
                sqlCmd.Parameters.AddWithValue("@InnerExeception", innerException);
                sqlCmd.Parameters.AddWithValue("@Data", data);
                sqlCmd.Parameters.AddWithValue("@ProjectSource", "Web");
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
        public class PollResult
        {
            public string PollOption { get; set; }
            public int TotalAnswers { get; set; }
            public PollResult(string columnName, int value)
            {
                PollOption = columnName;
                TotalAnswers = value;
            }
        }
        [WebMethod]
        public static List<PollResult> GetChartData(string surveysID)
        {
            List<PollResult> chartData = new List<PollResult>();           
            if (surveysID != string.Empty)
            {
                int surveyID = Convert.ToInt32(surveysID);
                DataTable dtQuestion = SurveyDAL.GetQuestionsBySurveyID(surveyID);
                if (dtQuestion.Rows.Count > 0)
                {
                    DataTable dtOptions = SurveyDAL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[0]["Question_ID"]));
                    for (int j = 0; j < dtOptions.Rows.Count; j++)
                    {
                        chartData.Add(new PollResult(Convert.ToString(dtOptions.Rows[j]["Answer_Option"]), SurveyDAL.GetAnswersByOptionID(Convert.ToInt32(dtOptions.Rows[j]["Option_ID"])).Rows.Count));
                    }
                }
            }
            return chartData;
        }
        [WebMethod]
        public static string GetTopPolls(string pProfileID)
        {
            try
            {
                pProfileID = EncryptDecrypt.DESDecrypt(pProfileID.Replace("irhmalli", "=").Replace("irhPASS", "+"));
                string Surveys_IDs = "";
                DataTable dt = SurveyDAL.GetLatestTop2Polls(Convert.ToInt32(pProfileID));
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    Surveys_IDs = Surveys_IDs + "," + dt.Rows[k]["Survey_ID"];
                }
                Surveys_IDs = Surveys_IDs.TrimStart(",".ToCharArray());
                return Surveys_IDs;

            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }
    }
}