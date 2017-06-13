using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Polls.DAL;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace Polls
{
    public partial class SurveyReport : System.Web.UI.Page
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
                    ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["PID"]));
                }
                if (Request.QueryString["SID"] != null)
                {
                    Surveys_IDs = Convert.ToString(Request.QueryString["SID"]);
                }

                if (!IsPostBack)
                {
                    AutoDataBind();
                }
            }
            catch (Exception ex)
            {
                InsertExceptionDetails("DEMOPOll", "surveyreport.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            AutoDataBind();
        }
        private void AutoDataBind()
        {
            if (Request.QueryString["SID"] == null)
            {
                DataTable dt = SurveyDAL.GetLatestTop2Polls(ProfileID);
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    Surveys_IDs = Surveys_IDs + "," + dt.Rows[k]["Survey_ID"];
                }

            }

            if (Surveys_IDs.StartsWith(","))
                Surveys_IDs = Surveys_IDs.Substring(1);

            //InsertExceptionDetails("DEMOPOll", " LOG1 ", "Page_Load", "ProfileID: " + ProfileID, "Surveys_IDs:" + Surveys_IDs, "", "");

            var ids = Surveys_IDs.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                int SurveyID = Convert.ToInt32(ids[i]);

                //InsertExceptionDetails("DEMOPOll", " LOG2 ", "Page_Load", "SurveyID: " + SurveyID, "i:" + i, "", "");

                if (i == 0)
                {
                    /*** Getting Survey Details ***/
                    DataTable dtSurvey = SurveyDAL.GetSurveyDetailsByID(SurveyID);
                    lblTitle1.Text = dtSurvey.Rows[0]["Name"].ToString();

                    //InsertExceptionDetails("DEMOPOll", " LOG3 ", "Page_Load", "dtSurvey: " + dtSurvey.Rows.Count, "i:" + i, "", "");


                    /*** Getting Questions Details ***/
                    DataTable dtQuestion = SurveyDAL.GetQuestionsBySurveyID(SurveyID);

                    /*** Getting How many members answered counts ***/
                    DataTable dtAnswers = SurveyDAL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[0]["Question_ID"]));
                    lblCount1.Text = dtAnswers.Rows.Count.ToString();
                    StringBuilder Str = new StringBuilder();


                    /*** Getting Options By ***/
                    DataTable dtOptions = SurveyDAL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[0]["Question_ID"]));

                    Series series = new Series();
                    string[] XPointMember = new string[dtOptions.Rows.Count];
                    int[] YPointMember = new int[dtOptions.Rows.Count];
                    for (int j = 0; j < dtOptions.Rows.Count; j++)
                    {
                        //storing Values for X axis  
                        XPointMember[j] = dtOptions.Rows[j]["Answer_Option"].ToString();

                        DataTable dt = SurveyDAL.GetAnswersByOptionID(Convert.ToInt32(dtOptions.Rows[j]["Option_ID"]));
                        //storing values for Y Axis  
                        YPointMember[j] = Convert.ToInt32(dt.Rows.Count);
                        series.Palette = ChartColorPalette.BrightPastel;
                        series.LabelForeColor = Color.Black;
                    }
                    series.Points.DataBindXY(XPointMember, YPointMember);
                    chartAppUsage.Series.Add(series);
                    // Set the PieLabelStyle custom attribute to the value of "Outside"
                    //chartAppUsage.Series[0]["PieLabelStyle"] = "Outside";

                    // By default, the callout lines will not be drawn unless you set a color for the series border
                    chartAppUsage.Series[0].BorderWidth = 1;
                    chartAppUsage.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                    chartAppUsage.Series[0].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);
                    //setting Chart type   
                    chartAppUsage.Series[0].ChartType = SeriesChartType.Pie;
                    foreach (Series charts in chartAppUsage.Series)
                    {
                        foreach (DataPoint point in charts.Points)
                        {
                            point.Label = string.Format("{0:0}({1})", point.YValues[0], "#PERCENT{P0}");
                            point.ToolTip = string.Format("{1} - {0:0}({2})", point.YValues[0], point.AxisLabel, "#PERCENT{P0}");
                        }
                    }

                    if (dtAnswers.Rows.Count > 0)
                    {
                        Str.Append("<table class=\"responses\" cellspacing=\"0\" style=\"Width:100%;\">");
                        for (int j = 0; j < dtAnswers.Rows.Count; j++)
                        {
                            if (j % 2 == 0)
                                Str.Append("<tr><td>Someone Participated at " + Convert.ToDateTime(dtAnswers.Rows[(dtAnswers.Rows.Count - 1) - j]["Created_Date"]).ToString("MM/dd/yyyy hh:mm tt") + "</td></tr>");
                            else
                                Str.Append("<tr><td>Someone Participated at " + Convert.ToDateTime(dtAnswers.Rows[(dtAnswers.Rows.Count - 1) - j]["Created_Date"]).ToString("MM/dd/yyyy hh:mm tt") + "</td></tr>");
                            if (j == 5)
                                break;
                        }
                        Str.Append("</table>");
                    }
                    literal1.Text = Str.ToString();

                    break;
                }//if

            }//for



        }



        [WebMethod]
        public static BusinessProfiles GetProfileDetailsByPID(string pProfileID)
        {
            try
            {
                pProfileID = EncryptDecrypt.DESDecrypt(pProfileID.Replace("irhmalli", "=").Replace("irhPASS", "+"));

                BusinessProfiles objProfileDetails = new BusinessProfiles();


                DataTable dtProfileDetails = GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                if (dtProfileDetails.Rows.Count > 0)
                {
                    string logourl = dtProfileDetails.Rows[0]["Profile_logo_path"].ToString();

                    string originalfilename = logourl;
                    string extension = System.IO.Path.GetExtension(originalfilename);

                    string junk = ".";
                    string[] ret = originalfilename.Split(junk.ToCharArray());
                    string thumbimg1 = ret[0];
                    thumbimg1 = thumbimg1 + "_thumb" + extension;

                    string imageDisID = Guid.NewGuid().ToString();
                    string RootPath = GetConfigSettings(pProfileID, "Paths", "RootPath");


                    objProfileDetails.ProfileID = Convert.ToInt32(pProfileID);
                    objProfileDetails.ProfileName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"]);
                    objProfileDetails.Logo = RootPath + "/Upload/Logos/" + pProfileID + "/" + thumbimg1 + "?Guid=" + imageDisID;
                    objProfileDetails.IsShortLogo = Convert.ToBoolean(dtProfileDetails.Rows[0]["IsShortLogo"]);
                }
                return objProfileDetails;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
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
        [WebMethod]
        public static Polls[] GetAllPolls(string pProfileID)
        {
            try
            {
                pProfileID = EncryptDecrypt.DESDecrypt(pProfileID.Replace("irhmalli", "=").Replace("irhPASS", "+"));


                IList<Polls> pollsList = new List<Polls>();

                DataTable dtSurveys = GetManageSurveys(Convert.ToInt32(pProfileID));
                DataRow[] rows = dtSurveys.Select("STypeID=2 AND IsPublished=1");
                if (rows.Length > 0)
                    dtSurveys = rows.CopyToDataTable();
                else
                    dtSurveys = new DataTable();

                for (int i = 0; i < dtSurveys.Rows.Count; i++)
                {
                    Polls objPolls = new Polls();
                    objPolls.SurveyID = Convert.ToInt32(dtSurveys.Rows[i]["Survey_ID"]);
                    objPolls.Title = Convert.ToString(dtSurveys.Rows[i]["Name"]);
                    //objPolls.CreatedDate = Convert.ToDateTime(dtSurveys.Rows[i]["Created_Date"]);
                    objPolls.ThanksMessage = Convert.ToString(dtSurveys.Rows[i]["Thanks_Message"]);
                    objPolls.Description = Convert.ToString(dtSurveys.Rows[i]["Description"]);

                    pollsList.Add(objPolls);
                }
                return pollsList.ToArray();

                //return new JavaScriptSerializer().Serialize(pollsList);

            }
            catch (Exception ex)
            {

                return null;
            }
        }





        public static void InsertExceptionDetails(string errorType, string pPageName, string methodName, string message, string strackTrace,
          string innerException, string data)
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
















        public static string GetConfigSettings(string pProfileID, string pType, string pConfigName)
        {
            string returnValue = "";
            pProfileID = pProfileID.Replace("irhmalli", "=").Replace("irhPASS", "+");
            string verticalCode = GetVerticalNameByProfileID(Convert.ToInt32(pProfileID));

            DataTable dtProfileDetails = GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
            string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);

            string domain = GetDomainNameByCountryVertical(verticalCode, countryName.Trim());

            var dtConfigs = GetVerticalConfigsByType(domain, pType);
            if (dtConfigs.Rows.Count > 0)
            {
                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]).ToLower() == pConfigName.ToLower())
                    {
                        returnValue = Convert.ToString(dtConfigs.Rows[i]["Value"]).Trim();
                        break;
                    }
                }
            }
            return returnValue;
        }
        public static DataTable GetVerticalConfigsByType(string verticalDomain, string type)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDomainConfigsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", verticalDomain);
                sqlCmd.Parameters.AddWithValue("@Type", type);
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

        public static string GetVerticalNameByProfileID(int pProfileID)
        {
            string verticalName = "USPD";
            DataTable vtable = new DataTable("getverticalname");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetVerticalNameByPID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                if (vtable.Rows.Count > 0)
                {
                    verticalName = Convert.ToString(vtable.Rows[0]["Vertical_Name"]);
                }
                return verticalName;
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
        public static string GetDomainNameByCountryVertical(string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDomainNameByCountryVertical", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                string formHeader = Convert.ToString(sqlCmd.ExecuteScalar());
                return formHeader;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        [WebMethod]
        public static yourDataPoints[] LoadPollChart(string ProfileID)
        {
            int PID = Convert.ToInt32(ProfileID);
            DataTable dtPolls = SurveyDAL.GetLatestTop2Polls(PID);
            List<yourDataPoints> details = new List<yourDataPoints>();
            if (dtPolls.Rows.Count > 0)
            {
                for (int s = 0; s < dtPolls.Rows.Count; s++)
                {
                    int SurveyID = Convert.ToInt32(dtPolls.Rows[s]["Survey_ID"].ToString());
                    DataTable dtSurvey = SurveyDAL.GetSurveyDetailsByID(SurveyID);
                    //string surveyName = dtSurvey.Rows[0]["Name"].ToString();
                    // Generate Report
                    DataTable dtQuestion = SurveyDAL.GetQuestionsBySurveyID(SurveyID);
                    if (dtQuestion.Rows.Count > 0)
                    {

                        //DataTable dtAnswerSkips = SurveyDAL.GetAnswersSkipCount(SurveyID);
                        //int answersSkipCount = 0;
                        //if (dtAnswerSkips.Rows.Count > 0)
                        //{
                        //    answersSkipCount = Convert.ToInt32(dtAnswerSkips.Rows[0]["TotalUsersCount"]);
                        //}

                        for (int i = 0; i < dtQuestion.Rows.Count; i++)
                        {

                            if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "2" || Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "1")
                            {


                                //Get Correct ANswers by QID (Responses)
                                DataTable dtOptions = SurveyDAL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                                DataTable mainANswers = SurveyDAL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));

                                string[] xAxis = new string[dtOptions.Rows.Count];
                                int[] yAxis = new int[dtOptions.Rows.Count];

                                if (mainANswers.Rows.Count > 0)
                                {

                                    for (int j = 0; j < dtOptions.Rows.Count; j++)
                                    {


                                        DataTable dtAnswers = SurveyDAL.GetAnswersByOptionID(Convert.ToInt32(dtOptions.Rows[j]["Option_ID"]));
                                        xAxis[j] = Convert.ToString(dtOptions.Rows[j]["Answer_Option"]);
                                        int value = dtAnswers.Rows.Count;   // *100 / answersSkipCount;
                                        //if (value == 66)
                                        //{ value = 67; }
                                        yAxis[j] = value;
                                        //Chart1.ChartAreas[0].AxisY.Maximum = mainANswers.Rows.Count;

                                        var responseValue = decimal.Round(Convert.ToDecimal(value * 100 / mainANswers.Rows.Count)).ToString();
                                        if (responseValue.Contains("66"))
                                        {
                                            responseValue = "67";
                                        }

                                        yourDataPoints dataPoints = new yourDataPoints();
                                        dataPoints.x = xAxis[j];
                                        dataPoints.y = yAxis[j].ToString();
                                        dataPoints.label = responseValue;
                                        details.Add(dataPoints);

                                    }

                                }



                            }

                        }

                    }
                }
            }


            return details.ToArray();

        }
        public class yourDataPoints
        {
            public string x { get; set; }
            public string y { get; set; }
            public string label { get; set; }
        }
        public class Polls
        {
            public int SurveyID { get; set; }
            public string Title { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime PublishDate { get; set; }
            public int TotalParticipants { get; set; }
            public int ProfileID { get; set; }
            public string ThanksMessage { get; set; }
            public string Description { get; set; }
        }

        public class Polls_Questions
        {
            public int Question_ID { get; set; }
            public string Text { get; set; }
            public int SurveyID { get; set; }
        }

        public class Polls_Options
        {
            public int Option_ID { get; set; }
            public int QuestionID { get; set; }
            public int SurveyID { get; set; }
            public string Answer_Option { get; set; }
        }

        public class BusinessProfiles
        {
            public int ProfileID { get; set; }
            public string ProfileName { get; set; }
            public string Logo { get; set; }
            public bool IsShortLogo { get; set; }
        }


    }
}