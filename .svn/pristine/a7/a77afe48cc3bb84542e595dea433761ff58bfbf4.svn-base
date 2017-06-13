using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class PrintAppUsageReport : System.Web.UI.Page
    {
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //BindChart
                    var startDate = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["sDate"]));
                    var endDate = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["eDate"]));
                    ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["PID"])));

                    BindChart(startDate, endDate);
                }
                catch (Exception ex)
                {
                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    /*** Error Log ***/
                    objInBuiltData.ErrorHandling("ERROR", "PrintAppUsageReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }


        }
        private int BindChart(string pstartDate, string pendDate)
        {
            //int count = 0;
            //try
            //{
            //    DateTime startDate = Convert.ToDateTime(pstartDate);
            //    DateTime endDate = Convert.ToDateTime(pendDate).AddDays(1); 
            //    lblTitle.Text = "";
            //    int totalDownloads = 0;
            //    DataTable dtPieChart = objBus.GetPieChartData(ProfileID, startDate, endDate, out totalDownloads);
            //    int iphoneDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Iphone_Downloads"].ToString());
            //    int androidDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Android_Downloads"].ToString());
            //    int windowsDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Windows_Downloads"].ToString());
            //    count = iphoneDownloads + androidDownloads + windowsDownloads;
            //    List<PieChart> listPieChart = new List<PieChart>();
            //    lblTotalCount.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppDownloads.Replace("#TotalDownloads#", totalDownloads.ToString()) + "</b>";
            //    lblTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageReportTitle.Replace("#StartDate#", pstartDate).Replace("#EndDate#", pendDate).Replace("#Count#", count.ToString()) + "</b>";
            //    listPieChart.Add(new PieChart
            //    {
            //        PlatForms = "Apple",
            //        Downloads = iphoneDownloads
            //    });
            //    listPieChart.Add(new PieChart
            //    {
            //        PlatForms = "Android",
            //        Downloads = androidDownloads
            //    });
            //    listPieChart.Add(new PieChart
            //    {
            //        PlatForms = "Windows",
            //        Downloads = windowsDownloads
            //    }); 

            //    chartAppUsage.DataSource = listPieChart;
            //    chartAppUsage.Series["Legend"].XValueMember = "PlatForms";
            //    chartAppUsage.Series["Legend"].YValueMembers = "Downloads";
            //    chartAppUsage.DataBind();
            //    chartAppUsage.Series["Legend"].LegendText = "#AXISLABEL";
            //    chartAppUsage.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
            //    foreach (System.Web.UI.DataVisualization.Charting.DataPoint dp in chartAppUsage.Series["Legend"].Points)
            //        dp.IsEmpty = (dp.YValues[0] == 0) ? true : false;

            //}
            //catch (Exception /*ex*/)
            //{

            //}
            //return count;
            int count = 0;
            //int openCount = 0;
            try
            {
                DateTime startDate = Convert.ToDateTime(pstartDate);
                DateTime endDate = Convert.ToDateTime(pendDate).AddDays(1);
                lblTitle.Text = "";
                //lblAppOpenTitle.Text = "";
                lblTotalCount.Text = "";
                //lblAppOpenCount.Text = "";

                int totalDownloads = 0;
                //int totalAppOpenCount = 0;
                DataTable dtPieChart = objBus.GetPieChartData(ProfileID, startDate, endDate, out totalDownloads);
                int iphoneDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Iphone_Downloads"].ToString());
                int androidDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Android_Downloads"].ToString());
                int windowsDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Windows_Downloads"].ToString());
                count = iphoneDownloads + androidDownloads + windowsDownloads;
                lblTotalCount.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppDownloads.Replace("#TotalDownloads#", totalDownloads.ToString()) + "</b>";

                //DataTable dtPieChartOpen = objBus.GetPieChartDataForOpenReport(ProfileID, startDate, endDate, out totalAppOpenCount);
                //int iphoneOpen = Convert.ToInt32(dtPieChartOpen.Rows[0]["Iphone_Downloads"].ToString());
                //int androidOpen = Convert.ToInt32(dtPieChartOpen.Rows[0]["Android_Downloads"].ToString());
                //int windowsOpen = Convert.ToInt32(dtPieChartOpen.Rows[0]["Windows_Downloads"].ToString());
                //openCount = iphoneOpen + androidOpen + windowsOpen;
                //lblAppOpenCount.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppOpen.Replace("#TotalDownloads#", totalAppOpenCount.ToString()) + "</b>";

                List<PieChart> listPieChart = new List<PieChart>();
                if (count > 0)
                {
                    lblTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageReportTitle.Replace("#StartDate#", pstartDate).Replace("#EndDate#", pendDate).Replace("#Count#", count.ToString()) + "</b>";

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

                chartAppUsage.DataSource = listPieChart;
                chartAppUsage.Series["Legend"].XValueMember = "PlatForms";
                chartAppUsage.Series["Legend"].YValueMembers = "Downloads";
                chartAppUsage.DataBind();
                chartAppUsage.Series["Legend"].LegendText = "#AXISLABEL";
                chartAppUsage.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
                foreach (System.Web.UI.DataVisualization.Charting.DataPoint dp in chartAppUsage.Series["Legend"].Points)
                    dp.IsEmpty = (dp.YValues[0] == 0) ? true : false;

                //List<PieChart> listPieChartOpen = new List<PieChart>();
                //if (openCount > 0)
                //{
                //    lblAppOpenTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppOpenTitle.Replace("#StartDate#", pstartDate).Replace("#EndDate#", pendDate).Replace("#Count#", openCount.ToString()) + "</b>";

                //    listPieChartOpen.Add(new PieChart
                //    {
                //        PlatForms = "Apple",
                //        Downloads = iphoneOpen
                //    });
                //    listPieChartOpen.Add(new PieChart
                //    {
                //        PlatForms = "Android",
                //        Downloads = androidOpen
                //    });
                //    listPieChartOpen.Add(new PieChart
                //    {
                //        PlatForms = "Windows",
                //        Downloads = windowsOpen
                //    });
                //}

                //chartAppOpen.DataSource = listPieChartOpen;
                //chartAppOpen.Series["Legend"].XValueMember = "PlatForms";
                //chartAppOpen.Series["Legend"].YValueMembers = "Downloads";
                //chartAppOpen.DataBind();
                //chartAppOpen.Series["Legend"].LegendText = "#AXISLABEL";
                //chartAppOpen.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
                //foreach (System.Web.UI.DataVisualization.Charting.DataPoint dp in chartAppOpen.Series["Legend"].Points)
                //    dp.IsEmpty = (dp.YValues[0] == 0) ? true : false;

            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "PrintAppUsageReport.aspx.cs", "BindChart", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return (count); //  + openCount
        }
    }
    public class PieChart
    {
        public string PlatForms { get; set; }
        public int Downloads { get; set; }
    }
}