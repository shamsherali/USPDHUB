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
    public partial class SurveyReport2 : System.Web.UI.Page
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
                    AutoDataBind2();
                }
            }
            catch (Exception ex)
            {
                InsertExceptionDetails("DEMOPOll", "surveyreport.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        private void AutoDataBind2()
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

                if (i == 1)
                {
                    /*** Getting Survey Details ***/
                    DataTable dtSurvey = SurveyDAL.GetSurveyDetailsByID(SurveyID);
                    lblTitle2.Text = dtSurvey.Rows[0]["Name"].ToString();

                    //  InsertExceptionDetails("DEMOPOll", " LOG3 ", "Page_Load", "dtSurvey: " + dtSurvey.Rows.Count, "i:" + i, "", "");


                    /*** Getting Questions Details ***/
                    DataTable dtQuestion = SurveyDAL.GetQuestionsBySurveyID(SurveyID);

                    /*** Getting How many members answered counts ***/
                    DataTable dtAnswers = SurveyDAL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[0]["Question_ID"]));
                    lblCount2.Text = dtAnswers.Rows.Count.ToString();
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
                    literal2.Text = Str.ToString();

                    break;
                }//if

            }//for
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            AutoDataBind2();
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

    }
}