using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
using Winnovative.HtmlToPdfClient;
using System.Configuration;


namespace USPDHUB.Business.MyAccount
{
    public partial class SurveyReport : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";

        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        SurveyBLL objSurveyBLL = new SurveyBLL();

        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();

        DataTable dtSurveys = new DataTable();

        public int SurveyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                lblmess.Text = "";
                if (Request.QueryString["SurveyID"] != null)
                {
                    SurveyID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["SurveyID"].ToString()));

                }
                else
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx"));
                }
                if (!IsPostBack)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Surveys");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel2.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to survey report.</font>";
                        }
                    }
                    GenerateSurveyReports();
                    DataTable dttab = USPDHUBDAL.BusinessDAL.GetTabDetailsByModule("Surveys", 0, UserID);
                    if (dttab.Rows.Count == 1)
                    {
                        hdnTabName.Value = dttab.Rows[0]["TabName"].ToString();
                    }
                }
                DataTable dtSurvey = objSurveyBLL.GetSurveyDetailsByID(SurveyID);
                string surveyName = dtSurvey.Rows[0]["Name"].ToString();
                lblSurveyName.Text = surveyName;
                if (Convert.ToString(dtSurvey.Rows[0]["Expiration_Date"]).Trim() != string.Empty)
                {
                    lblExDate.Text = Convert.ToDateTime(dtSurvey.Rows[0]["Expiration_Date"]).ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SurveyReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GenerateSurveyReports()
        {
            try
            {
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

                int IOS_All = 0;
                int Android_All = 0;
                int Windows_All = 0;

                int IOS_Answered = 0;
                int Android_Answered = 0;
                int Windows_Answered = 0;

                int IOS_Completed = 0;
                int Android_Completed = 0;
                int Windows_Completed = 0;

                int completedusers = 0;
                int newusers = 0;
                int inprogusers = 0;
                DataTable dtDevicesCount = objSurveyBLL.GetDeviceCountByPID(ProfileID);
                int deviceCountByPID = 0;
                if (dtDevicesCount.Rows.Count > 0)
                {
                    deviceCountByPID = Convert.ToInt32(dtDevicesCount.Rows[0]["TotalCount"]);

                    IOS_All = Convert.ToInt32(dtDevicesCount.Rows[0]["IPhoneCount"]);
                    Android_All = Convert.ToInt32(dtDevicesCount.Rows[0]["AndroidCount"]);
                    Windows_All = Convert.ToInt32(dtDevicesCount.Rows[0]["WindowsCount"]);
                }
                lblTotalFavourites.Text = deviceCountByPID.ToString();

                DataTable dtAnswerSkips = objSurveyBLL.GetAnswersSkipCount(SurveyID);
                int TotalAnswerCount = 0;
                if (dtAnswerSkips.Rows.Count > 0)
                {
                    TotalAnswerCount = Convert.ToInt32(dtAnswerSkips.Rows[0]["TotalUsersCount"]);

                    IOS_Answered = Convert.ToInt32(dtAnswerSkips.Rows[0]["IOSCount"]);
                    Android_Answered = Convert.ToInt32(dtAnswerSkips.Rows[0]["AndroidCount"]);
                    Windows_Answered = Convert.ToInt32(dtAnswerSkips.Rows[0]["WindowsCount"]);
                }

                DataTable dtCompletedAnswersCount = objSurveyBLL.GetCompletedAnswersCountBySurveyID(SurveyID);
                completedusers = 0;
                if (dtCompletedAnswersCount.Rows.Count > 0)
                {
                    completedusers = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["TotalCompletedAnswerCount"]);

                    IOS_Completed = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["IOSCount"]);
                    Android_Completed = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["AndroidCount"]);
                    Windows_Completed = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["WindowsCount"]);
                }

                if (deviceCountByPID > TotalAnswerCount)
                {
                    newusers = deviceCountByPID - TotalAnswerCount;
                }
                inprogusers = TotalAnswerCount - completedusers;
                lblNew.Text = newusers.ToString();
                lblInprog.Text = inprogusers.ToString();
                lblCompleted.Text = completedusers.ToString();


                lblIPhoneUsers.Text = ((IOS_Answered - IOS_Completed) + IOS_Completed).ToString();
                lblAndroidUsers.Text = ((Android_Answered - Android_Completed) + Android_Completed).ToString();
                lblWindowsUsers.Text = ((Windows_Answered - Windows_Completed) + Windows_Completed).ToString(); ;

                string[] xAxis = { "In Progress", "Completed" }; // "Not Started",  // ***  USPD-1259 *** //
                int[] yAxis = { inprogusers, completedusers }; // newusers, 
                Chart1.ChartAreas[0].AxisY.Maximum = inprogusers + completedusers; //  newusers + 
                Chart1.Series["Legend"].LegendText = "#AXISLABEL";
                Chart1.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
                // Values are Bind to Chart
                //Chart1.ChartAreas[0].AxisX.Title = "Progress";
                //Chart1.ChartAreas[0].AxisY.Title = "Total";
                Chart1.Series["Legend"].IsVisibleInLegend = true;
                Chart1.Series["Legend"].Points.DataBindXY(xAxis, yAxis);
                foreach (System.Web.UI.DataVisualization.Charting.DataPoint dp in Chart1.Series["Legend"].Points)
                    dp.IsEmpty = (dp.YValues[0] == 0) ? true : false;
                //Chart1.Series["Legend"].Points[0].Color = System.Drawing.ColorTranslator.FromHtml("#3366cc");
                Chart1.Series["Legend"].Points[0].Color = System.Drawing.ColorTranslator.FromHtml("#dc3912");
                Chart1.Series["Legend"].Points[1].Color = System.Drawing.ColorTranslator.FromHtml("#ff9900");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SurveyReport.aspx.cs", "GenerateSurveyReports", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx"));
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                String serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                //create a PDF document
                Document document = new Document();
                document.Port = serverPort;
                document.Server = serverIP;

                document.CompressionLevel = PdfCompressionLevel.Normal;
                document.Margins = new PdfMargins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.ViewerPreferences.HideToolbar = false;
                document.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");


                float xLocation = 5;
                float yLocation = 5;
                float width = -1;
                float height = -1;


                HtmlToPdfElement addResult;
                PdfPage pageSummary = document.AddPage(PdfPageSize.A4, new PdfMargins(0, 0, 70, 0), PdfPageOrientation.Portrait);


                string ReportHTML = "";

                #region Getting Rooth Path

                string RootPath = "";
                string verticalCode = USPDHUBDAL.MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(Session["ProfileID"]));
                DataTable dtProfileDetails = USPDHUBDAL.BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(Session["ProfileID"]));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                string domain = objCommon.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    for (int k = 0; k < dtConfigs.Rows.Count; k++)
                    {
                        if (Convert.ToString(dtConfigs.Rows[k]["Name"]).ToLower() == "RootPath".ToLower())
                        {
                            RootPath = Convert.ToString(dtConfigs.Rows[k]["Value"]).Trim();
                            break;
                        }
                    }
                }
                #endregion


                #region Delete Previous Survey Report Images

                DeleteReportTempImages();

                #endregion

                #region Report Summary Images

                GenerateSurveyReports();

                string ReportSummaryIMGtag = "";

                string summaryImgName = SurveyID + "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                    + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".jpg";
                string summaryIMGFullPath = Server.MapPath("~/Upload/ReportsHTML/") + summaryImgName;


                // Save image.
                Chart1.SaveImage(summaryIMGFullPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Jpeg);

                ReportSummaryIMGtag = "<img src='" + RootPath + "/Upload/ReportsHTML/" + summaryImgName + "' />";

                #endregion

                DataTable dtSurvey = objSurveyBLL.GetSurveyDetailsByID(SurveyID);
                string surveyName = dtSurvey.Rows[0]["Name"].ToString();
                // Generate Report
                DataTable dtQuestion = objSurveyBLL.GetQuestionsBySurveyID(SurveyID);
                if (dtQuestion.Rows.Count > 0)
                {
                    //getting Report HTML
                    string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ReportsHTML\\";
                    //Survey nam Header
                    StreamReader re = File.OpenText(strfilepath + "SurveyReport2.htm");
                    string htmlStr = string.Empty;
                    string content = string.Empty;
                    while ((content = re.ReadLine()) != null)
                    {
                        htmlStr = htmlStr + content;
                    }
                    re.Close();
                    re.Dispose();
                    // Child Table
                    string strfilepath2 = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ReportsHTML\\";
                    StreamReader re2 = File.OpenText(strfilepath2 + "SurveyReport1.htm");
                    string htmlStr2 = string.Empty;
                    string content2 = string.Empty;
                    while ((content2 = re2.ReadLine()) != null)
                    {
                        htmlStr2 = htmlStr2 + content2;
                    }
                    re2.Close();
                    re2.Dispose();

                    DataTable dtAnswerSkips = objSurveyBLL.GetAnswersSkipCount(SurveyID);
                    int answersSkipCount = 0;
                    if (dtAnswerSkips.Rows.Count > 0)
                    {
                        answersSkipCount = Convert.ToInt32(dtAnswerSkips.Rows[0]["TotalUsersCount"]);
                    }
                    //int answersSkipCount = objSurveyBLL.GetAnswersSkipCount(SurveyID);

                    // 1: Checkboxes
                    // 2: Radio Buttons
                    // 3: Free TextBoxes
                    for (int i = 0; i < dtQuestion.Rows.Count; i++)
                    {
                        #region 3: Free TextBoxes -- 2: Radio Buttons --  1: Checkboxes

                        var subHTML = "";
                        if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "3")
                        {
                            subHTML = htmlStr;

                            subHTML = subHTML.Replace("#SURVEY_NAME#", surveyName);
                            subHTML = subHTML.Replace("#QUESTION_NO#", "Q" + (i + 1));
                            subHTML = subHTML.Replace("#QUESTION_NAME#", Convert.ToString(dtQuestion.Rows[i]["Text"]));
                            //Get Correct ANswers by QID (Responses)
                            DataTable dtAnswers = objSurveyBLL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                            subHTML = subHTML.Replace("#ANSWER_COUNT#", "Answered: " + dtAnswers.Rows.Count + "&nbsp; Skipped: " + (answersSkipCount - dtAnswers.Rows.Count));
                            subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                            if (dtAnswers.Rows.Count > 0)
                            {
                                string AnswersString = @"<table width='100%' border='0' cellpadding='3' cellspacing='0' style='font-size: 12px; border-top: solid 2 #C5C5C5; border-bottom: solid 2 #C5C5C5;'>
                                                     <colgroup>
                                                       <col width='7%' />
                                                       <col width='*' />
                                                       <col width='25%' />
                                                    </colgroup>
                            <tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                            <td style='text-align: left; padding-left: 5px; border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5;'>
                                #
                            </td>
                            <td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;' >
                                Responses
                            </td>
                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                Date
                            </td>
                            </tr>";

                                var rows = "";
                                for (int j = 0; j < dtAnswers.Rows.Count; j++)
                                {
                                    rows = rows + @"<tr>
                                                    <td  style='text-align: left; padding-left: 5px; border-left: solid 2 #C5C5C5; border-right: solid 2# C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                        " + (j + 1) + @"
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                        " + Convert.ToString(dtAnswers.Rows[j]["Answer"]) + @"
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-top: solid 2 #D0C6B1; border-right: solid 2 #C5C5C5; font-size: 11px;'>
                                                        " + Convert.ToString(dtAnswers.Rows[j]["Created_Date"]) + @"
                                                    </td>
                                                </tr>";
                                }
                                AnswersString = AnswersString + rows + "</table>";
                                subHTML = subHTML.Replace("#ANSWERS#", AnswersString);
                            }
                            else
                            {
                                subHTML = subHTML.Replace("#ANSWERS#", "");
                            }
                        }
                        else if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "2")
                        {
                            subHTML = htmlStr;

                            subHTML = subHTML.Replace("#SURVEY_NAME#", surveyName);
                            subHTML = subHTML.Replace("#QUESTION_NO#", "Q" + (i + 1));
                            subHTML = subHTML.Replace("#QUESTION_NAME#", Convert.ToString(dtQuestion.Rows[i]["Text"]));

                            //Get Correct ANswers by QID (Responses)
                            DataTable dtOptions = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                            DataTable mainANswers = objSurveyBLL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));

                            subHTML = subHTML.Replace("#ANSWER_COUNT#", "Answered: " + mainANswers.Rows.Count + "&nbsp; Skipped: " + (answersSkipCount - mainANswers.Rows.Count));

                            string[] xAxis = new string[dtOptions.Rows.Count];
                            int[] yAxis = new int[dtOptions.Rows.Count];

                            if (mainANswers.Rows.Count > 0)
                            {
                                var row = "";
                                for (int j = 0; j < dtOptions.Rows.Count; j++)
                                {
                                    DataTable dtAnswers = objSurveyBLL.GetAnswersByOptionID(Convert.ToInt32(dtOptions.Rows[j]["Option_ID"]));
                                    xAxis[j] = Convert.ToString(dtOptions.Rows[j]["Answer_Option"]);
                                    int value = dtAnswers.Rows.Count;   // *100 / answersSkipCount;
                                    //if (value == 66)
                                    //{ value = 67; }
                                    yAxis[j] = value;
                                    Chart1.ChartAreas[0].AxisY.Maximum = mainANswers.Rows.Count;

                                    var responseValue = decimal.Round(Convert.ToDecimal(value * 100 / mainANswers.Rows.Count)).ToString();
                                    if (responseValue.Contains("66"))
                                    {
                                        responseValue = "67";
                                    }
                                    row = row + @"<tr>
                                                    <td  style='text-align: left; padding-left: 5px;  border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + Convert.ToString(dtOptions.Rows[j]["Answer_Option"]) + @"
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + responseValue + @"%
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;  border-right: solid 2 #C5C5C5;'>
                                                        " + value + @"
                                                    </td>
                                                </tr>";
                                }
                                #region Save Report as Img

                                // Save Image
                                Chart1.Width = 750;
                                Chart1.ChartAreas[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                                Chart1.Series["Legend"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                                Chart1.Series["Legend"].IsVisibleInLegend = false;
                                Chart1.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
                                Chart1.Series["Legend"].LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                                Chart1.ChartAreas[0].AxisX.Title = "Answers";
                                Chart1.ChartAreas[0].AxisY.Title = "Total Answered";
                                Chart1.Series["Legend"].Points.DataBindXY(xAxis.Reverse().ToList(), yAxis.Reverse().ToList());
                                string[] colors = { "#3399FF", "#FF9900", "#E86850", "#587058", "#587498", "#097054", "#829F53", "#9CCF31", "#D8DE1A", "#663399" };
                                foreach (System.Web.UI.DataVisualization.Charting.Series series in Chart1.Series)
                                {
                                    foreach (System.Web.UI.DataVisualization.Charting.DataPoint point in series.Points)
                                    {
                                        //Set color for the bar
                                        point.Color = System.Drawing.ColorTranslator.FromHtml(colors[series.Points.IndexOf(point)]);
                                    }
                                }

                                // Export FileName
                                string imgName = SurveyID + "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                                     + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".jpg";
                                string imgFullPath = Server.MapPath("~/Upload/ReportsHTML/") + imgName;
                                // Save image.
                                Chart1.SaveImage(imgFullPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Jpeg);

                                #endregion

                                string radioButtonHTML = @"<table width='100%' border='0' cellpadding='3' cellspacing='0' style='font-size: 12px; border-top: solid 2 #C5C5C5; border-bottom: solid 2 #C5C5C5;'>
                                                            <colgroup>
                                                            <col width='40%' />
                                                            <col width='*' />
                                                            <col width='20%' />
                                                            </colgroup>
                                                        <tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td  style='text-align: left; padding-left: 5px;  border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5;'>
                                                                Answer Choices
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                                                Responses
                                                            </td>
                                                            <td style='text-align: left; padding-left: 5px;  border-right: solid 2 #C5C5C5;'>
                                                                &nbsp;
                                                            </td>
                                                        </tr>" + row + @"<tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td  style='text-align: left; padding-left: 5px;  border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                                Total
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                            &nbsp;
                                                            </td>
                                                            <td style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;  border-right: solid 2 #C5C5C5;'>
                                                                " + (mainANswers.Rows.Count) + @"
                                                            </td>
                                                        </tr>
                                                    </table>";



                                string reportImgTag = "<img src='" + RootPath + "/Upload/ReportsHTML/" + imgName + "' />";
                                subHTML = subHTML.Replace("#REPORT_IMAGE#", reportImgTag);
                                //subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                                subHTML = subHTML.Replace("#ANSWERS#", radioButtonHTML);
                            }
                            else
                            {
                                subHTML = subHTML.Replace("#ANSWERS#", "");
                                subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                            }

                        }
                        else if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "1")
                        {
                            subHTML = htmlStr;

                            subHTML = subHTML.Replace("#SURVEY_NAME#", surveyName);
                            subHTML = subHTML.Replace("#QUESTION_NO#", "Q" + (i + 1));
                            subHTML = subHTML.Replace("#QUESTION_NAME#", Convert.ToString(dtQuestion.Rows[i]["Text"]));

                            //Get Correct ANswers by QID (Responses)
                            DataTable dtOptions = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                            DataTable mainANswers = objSurveyBLL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));

                            subHTML = subHTML.Replace("#ANSWER_COUNT#", "Answered: " + mainANswers.Rows.Count + "&nbsp; Skipped: " + (answersSkipCount - mainANswers.Rows.Count));

                            string[] xAxis = new string[dtOptions.Rows.Count];
                            int[] yAxis = new int[dtOptions.Rows.Count];

                            if (mainANswers.Rows.Count > 0)
                            {
                                var row = "";
                                for (int j = 0; j < dtOptions.Rows.Count; j++)
                                {
                                    DataTable dtAnswers = objSurveyBLL.GetAnswersByOptionID(Convert.ToInt32(dtOptions.Rows[j]["Option_ID"]));
                                    xAxis[j] = Convert.ToString(dtOptions.Rows[j]["Answer_Option"]);
                                    int value = dtAnswers.Rows.Count;   // *100 / answersSkipCount;
                                    //if (value == 66)
                                    //{ value = 67; }
                                    yAxis[j] = value;
                                    Chart1.ChartAreas[0].AxisY.Maximum = mainANswers.Rows.Count;

                                    var responseValue = decimal.Round(Convert.ToDecimal(value * 100 / mainANswers.Rows.Count)).ToString();
                                    if (responseValue.Contains("66"))
                                    {
                                        responseValue = "67";
                                    }
                                    row = row + @"<tr>
                                                    <td  style='text-align: left; padding-left: 5px;  border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + Convert.ToString(dtOptions.Rows[j]["Answer_Option"]) + @"
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + responseValue + @"%
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;  border-right: solid 2 #C5C5C5;'>
                                                        " + value + @"
                                                    </td>
                                                </tr>";
                                }
                                #region Save Report as Img

                                // Save Image
                                Chart1.Width = 750;
                                Chart1.ChartAreas[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                                Chart1.Series["Legend"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                                Chart1.Series["Legend"].IsVisibleInLegend = false;
                                Chart1.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
                                Chart1.Series["Legend"].LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                                Chart1.ChartAreas[0].AxisX.Title = "Answers";
                                Chart1.ChartAreas[0].AxisY.Title = "Total Answered";
                                Chart1.Series["Legend"].Points.DataBindXY(xAxis.Reverse().ToList(), yAxis.Reverse().ToList());
                                string[] colors = { "#3399FF", "#FF9900", "#E86850", "#587058", "#587498", "#097054", "#829F53", "#9CCF31", "#D8DE1A", "#663399" };
                                foreach (System.Web.UI.DataVisualization.Charting.Series series in Chart1.Series)
                                {
                                    foreach (System.Web.UI.DataVisualization.Charting.DataPoint point in series.Points)
                                    {
                                        //Set color for the bar
                                        point.Color = System.Drawing.ColorTranslator.FromHtml(colors[series.Points.IndexOf(point)]);
                                    }
                                }

                                // Export FileName
                                string imgName = SurveyID + "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                                     + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".jpg";
                                string imgFullPath = Server.MapPath("~/Upload/ReportsHTML/") + imgName;
                                // Save image.
                                Chart1.SaveImage(imgFullPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Jpeg);

                                #endregion

                                string radioButtonHTML = @"<table width='100%' border='0' cellpadding='3' cellspacing='0' style='font-size: 12px; border-top: solid 2 #C5C5C5; border-bottom: solid 2 #C5C5C5;'>
                                                            <colgroup>
                                                            <col width='40%' />
                                                            <col width='*' />
                                                            <col width='20%' />
                                                            </colgroup>
                                                        <tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td  style='text-align: left; padding-left: 5px;  border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5;'>
                                                                Answer Choices
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                                                Responses
                                                            </td>
                                                            <td style='text-align: left; padding-left: 5px;  border-right: solid 2 #C5C5C5;'>
                                                                &nbsp;
                                                            </td>
                                                        </tr>" + row + @"<tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td  style='text-align: left; padding-left: 5px;  border-left: solid 2 #C5C5C5; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                                Total
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                            &nbsp;
                                                            </td>
                                                            <td style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;  border-right: solid 2 #C5C5C5;'>
                                                                " + (mainANswers.Rows.Count) + @"
                                                            </td>
                                                        </tr>
                                                    </table>";



                                string reportImgTag = "<img src='" + RootPath + "/Upload/ReportsHTML/" + imgName + "' />";
                                subHTML = subHTML.Replace("#REPORT_IMAGE#", reportImgTag);
                                //subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                                subHTML = subHTML.Replace("#ANSWERS#", radioButtonHTML);
                            }
                            else
                            {
                                subHTML = subHTML.Replace("#ANSWERS#", "");
                                subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                            }
                        }


                        #endregion
                        // Loop Conditions closed

                        // Total Question Append
                        ReportHTML = ReportHTML + "" + subHTML;


                        subHTML = @"<table width='793px' cellpadding='0' cellspacing='2' style='font-family: Arial; font-size: 20px;'>" +
                            "<tr style='page-break-inside: avoid;'>" +
                            "<td align='center'>" +
                            "<span style='margin: 0; padding: 0;'>" + surveyName + "</span>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td>" +
                            "&nbsp;" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td>" +
                            "&nbsp;" +
                            "</td>" +
                            "</tr>" +
                            "</table>" + "" + subHTML;

                        // END IF ELse
                        PdfPage page = document.AddPage(PdfPageSize.A4, new PdfMargins(10, 10, 10, 10), PdfPageOrientation.Portrait);
                        HtmlToPdfElement htmlToPdfElement;
                        htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, subHTML.ToString(), null);
                        htmlToPdfElement.HtmlViewerWidth = 793;
                        page.AddElement(htmlToPdfElement);


                    }

                    // Report Summary ++ Survey Name(HEADING)
                    #region Report Summary + Detailed HTML Survey Name(HEADING)

                    // Survey Heading
                    htmlStr2 = htmlStr2.Replace("#SURVEY_NAME#", surveyName);
                    // Report Summary HTML Tags
                    htmlStr2 = htmlStr2.Replace("#SURVEYNAME#", surveyName);
                    htmlStr2 = htmlStr2.Replace("#EXDATE#", lblExDate.Text);
                    htmlStr2 = htmlStr2.Replace("#TOTALUSERS#", lblTotalFavourites.Text);
                    htmlStr2 = htmlStr2.Replace("#IPhone#", lblIPhoneUsers.Text);
                    htmlStr2 = htmlStr2.Replace("#Android#", lblAndroidUsers.Text);
                    htmlStr2 = htmlStr2.Replace("#Windows#", lblWindowsUsers.Text);

                    htmlStr2 = htmlStr2.Replace("#NEW#", lblNew.Text);
                    htmlStr2 = htmlStr2.Replace("#INPROGRESS#", lblInprog.Text);
                    htmlStr2 = htmlStr2.Replace("#COMPLETED#", lblCompleted.Text);
                    htmlStr2 = htmlStr2.Replace("#ReportSummaryImage#", ReportSummaryIMGtag);

                    #endregion

                    ReportHTML = @"<table width='793px' cellpadding='0' cellspacing='2' style='font-family: Arial; font-size: 20px;'>" +
        "<tr style='page-break-inside: avoid;'>" +
            "<td align='center'>" +
                "<span style='margin: 0; padding: 0;'>" + surveyName + "</span>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td>" +
                "&nbsp;" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td>" +
                "&nbsp;" +
            "</td>" +
        "</tr>" +
    "</table>" + "" + ReportHTML;
                    ReportHTML = ReportHTML.Replace("<br>", "");


                    HtmlToPdfElement htmlToPdfElementSummary;
                    htmlToPdfElementSummary = new HtmlToPdfElement(xLocation, yLocation, width, height, htmlStr2.ToString(), null);
                    htmlToPdfElementSummary.ConversionDelay = 0;

                    surveyName = objCommon.MakeValidFileName(surveyName);
                    string pdfilenameval = surveyName + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                        + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf"; ;
                    // add theHTML to PDF converter element to page               
                    htmlToPdfElementSummary.HtmlViewerWidth = 793;
                    pageSummary.AddElement(htmlToPdfElementSummary);

                    string savelocation = Server.MapPath("~/Upload/").ToString() + pdfilenameval;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    document.Save(savelocation);

                    string VirtualPath = savelocation;
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + pdfilenameval);
                    Response.TransmitFile(VirtualPath);
                }

            }
            catch (Exception ex)
            {   //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyReport.aspx.cs", "btnReport_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void DeleteReportTempImages()
        {
            try
            {
                string ImagesPath = Server.MapPath("~") + "/Upload/ReportsHTML/";
                // We'll read all files from Images subfolder
                DirectoryInfo diFiles = new DirectoryInfo(ImagesPath);
                FileInfo[] fi = diFiles.GetFiles();
                foreach (FileInfo f in fi)
                {
                    if (f.CreationTime != DateTime.Now)
                    {
                        if (!f.Name.Contains("SurveyReport"))
                        {
                            f.Delete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SurveyReport.aspx.cs", "DeleteReportTempImages", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GenerateHTMLtoPDF(string reportHTML, string surveyID, string surveyName, string summaryHTML)
        {
            //set the license key
            //LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

            ////create a PDF document
            //Document document = new Document();
            //document.CompressionLevel = CompressionLevel.NormalCompression;
            //document.Margins = new Margins(10, 10, 0, 0);
            //document.Security.CanPrint = true;
            //document.Security.UserPassword = "";
            //document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
            //document.ViewerPreferences.HideToolbar = false;

            //PdfPage pageSummary = document.Pages.AddNewPage(PageSize.A4, new Margins(0, 0, 70, 0), PageOrientation.Portrait);


            ////PageSize.A4, new Margins(0, 0, 0, 0), PageOrientation.Portrait
            //PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 10, 10), PageOrientation.Portrait);


            ////PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Arial"), 14, System.Drawing.GraphicsUnit.Point));
            //AddElementResult addResult;

            //float xLocation = 5;
            //float yLocation = 5;
            //float width = -1;
            //float height = -1;

            //// convert HTML to PDF
            //HtmlToPdfElement htmlToPdfElement;
            //HtmlToPdfElement htmlToPdfElementSummary;

            //htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, reportHTML.ToString(), null);
            //htmlToPdfElementSummary = new HtmlToPdfElement(xLocation, yLocation, width, height, summaryHTML.ToString(), null);

            //string pdfilenameval = surveyName + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
            //    + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf"; ;
            //// add theHTML to PDF converter element to page
            //htmlToPdfElement.HtmlViewerWidth = 793;
            //htmlToPdfElementSummary.HtmlViewerWidth = 793;

            //addResult = page.AddElement(htmlToPdfElement);
            //addResult = pageSummary.AddElement(htmlToPdfElementSummary);




            //string savelocation = Server.MapPath("~/Upload/").ToString() + pdfilenameval;
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            //document.Save(Response, false, pdfilenameval);

            //string VirtualPath = savelocation;
            //Response.ContentType = "application/octet-stream";
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + pdfilenameval);
            //Response.TransmitFile(VirtualPath);

        }

    
    }
}