﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Web.Services;

namespace USPDHUB.Business.MyAccount
{
    public partial class AppUsageReport : System.Web.UI.Page
    {
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        StringBuilder str = new StringBuilder();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBranded = false;
        public int C_UserID = 0;
        public DataTable dtUserDetails = new DataTable();
        public bool IsBlockedSendAccess = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (!IsPostBack)
                {
                    DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        IsParent = false;
                    if (Convert.ToBoolean(dtProfiles.Rows[0]["IsBranded_App"].ToString()))
                        IsBranded = true;
                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                    }
                    txtStartDate.Text = (DateTime.Now.Date.Month).ToString() + "/" + "01/" + DateTime.Now.Date.Year.ToString();
                    txtEndDate.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
                    try
                    {
                        int totalDownloads = 0;
                        DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                        DateTime endDate = Convert.ToDateTime(txtEndDate.Text).AddDays(1);
                        DataTable dtPieChart = objBus.GetPieChartData(ProfileID, startDate, endDate, out totalDownloads);
                        int iphoneDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Iphone_Downloads"].ToString());
                        int androidDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Android_Downloads"].ToString());
                        int windowsDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Windows_Downloads"].ToString());
                        if (iphoneDownloads > 0 || androidDownloads > 0 || windowsDownloads > 0)
                        {
                            str.Append(@"<script type=text/javascript>  google.load('visualization', '1', {'packages':['corechart']});
                     google.setOnLoadCallback(drawChart);
                     function drawChart() {
                     var data = new google.visualization.DataTable();");
                            // but m changing  only below line
                            // (" data.addColumn('string'(datatype), 'student_name'(column name));");
                            // str.Append(" data.addColumn('number'(datatype), 'average_marks'(column name));");
                            // my data that will come from the sql server
                            str.Append(" data.addColumn('string', 'Plat_Form');");
                            str.Append(" data.addColumn('number', 'Downloads');");
                            str.Append(" data.addRows([");
                            // here i am declairing the variable i in int32 for the looping statement

                            // here i am fill the string builder with the value from the database
                            str.Append("['Apple'," + iphoneDownloads + "],");
                            str.Append("['Android'," + androidDownloads + "],");
                            str.Append("['Windows'," + windowsDownloads + "]");

                            // other all string is fill according to the javascript code
                            str.Append("]);");
                            str.Append(" var chart = new google.visualization.PieChart(document.getElementById('chart_div'));");
                            str.Append("chart.draw(data, {width: 600, height: 350,title: 'App Downloads between " + txtStartDate.Text + " and " + txtEndDate.Text + " - " + (iphoneDownloads + androidDownloads + windowsDownloads) + "'});}");
                            str.Append("</script>");
                            // here am using literal conrol to display the complete graph
                            ltrChart.Text = str.ToString().TrimEnd(',');
                        }
                    }
                    catch (Exception /*ex*/)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppUsageReport.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnchart_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception /*ex*/)
            {

            }
        }
        public class PieChart
        {
            public string PlatForms { get; set; }
            public int Downloads { get; set; }
        }
        [WebMethod]
        public static List<PieChart> ServerSidefill(string stratDt, string endDt)
        {
            List<PieChart> listPieChart = new List<PieChart>();
            try
            {
                int totalDownloads = 0;
                BusinessBLL objBus = new BusinessBLL();
                DateTime startDate = Convert.ToDateTime(stratDt);
                DateTime endDate = Convert.ToDateTime(endDt).AddDays(1);
                DataTable dtRows = objBus.GetPieChartData(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), startDate, endDate, out totalDownloads);
                int iphoneDownloads = Convert.ToInt32(dtRows.Rows[0]["Iphone_Downloads"].ToString());
                int androidDownloads = Convert.ToInt32(dtRows.Rows[0]["Android_Downloads"].ToString());
                int windowsDownloads = Convert.ToInt32(dtRows.Rows[0]["Windows_Downloads"].ToString());

                if (iphoneDownloads > 0 || androidDownloads > 0 || windowsDownloads > 0)
                {
                    listPieChart.Add(new PieChart
                    {
                        PlatForms = "Apple",
                        Downloads = iphoneDownloads
                    });
                    listPieChart.Add(new PieChart
                    {
                        PlatForms = "Android",
                        Downloads = androidDownloads
                    });
                    listPieChart.Add(new PieChart
                    {
                        PlatForms = "Windows",
                        Downloads = windowsDownloads
                    });
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppUsageReport.aspx.cs", "ServerSidefill", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return listPieChart;

        }
    }
}