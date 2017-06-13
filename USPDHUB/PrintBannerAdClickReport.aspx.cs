using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Web.UI.DataVisualization.Charting;

namespace USPDHUB
{
    public partial class PrintBannerAdClickReport : System.Web.UI.Page
    {
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var startDate = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["sDate"]));
                    var endDate = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["eDate"]));
                    ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["PID"])));
                    BindChart(startDate, endDate);
                }
                catch (Exception ex)
                {
                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    /*** Error Log ***/
                    objInBuiltData.ErrorHandling("ERROR", "PrintBannerAdClickReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
        }
        private int BindChart(string pstartDate, string pendDate)
        {
            int totalDownloads = 0;
            int count = 0;
            try
            {
                DateTime startDate = Convert.ToDateTime(pstartDate);
                DateTime endDate = Convert.ToDateTime(pendDate).AddDays(1);
                lblTitle.Text = "";
                lblTotalCount.Text = "";
                DataSet dsBannerId = objBus.GetPieChartDataForBannerAdReport(ProfileID, startDate, endDate, 0, out totalDownloads);

                DataTable dt = new DataTable();
                dt.Columns.Add("Ads", Type.GetType("System.String"));
                dt.Columns.Add("IPhone", Type.GetType("System.Int32"));
                dt.Columns.Add("Android", Type.GetType("System.Int32"));
                dt.Columns.Add("Windows", Type.GetType("System.Int32"));
                List<int> lsClicks = new List<int>();
                if (dsBannerId.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsBannerId.Tables[0].Rows.Count; i++)
                    {
                        int BannerId = Convert.ToInt32(dsBannerId.Tables[0].Rows[i]["BannerAd_Id"].ToString());
                        DataSet dsBarChart = objBus.GetPieChartDataForBannerAdReport(ProfileID, startDate, endDate, BannerId, out totalDownloads);
                        int iphoneDownloads = Convert.ToInt32(dsBarChart.Tables[1].Rows[0]["Iphone_Downloads"].ToString());
                        int androidDownloads = Convert.ToInt32(dsBarChart.Tables[1].Rows[0]["Android_Downloads"].ToString());
                        int windowsDownloads = Convert.ToInt32(dsBarChart.Tables[1].Rows[0]["Windows_Downloads"].ToString());

                        lsClicks.Add(iphoneDownloads);
                        lsClicks.Add(androidDownloads);
                        lsClicks.Add(windowsDownloads);

                        DataRow dr = dt.NewRow();
                        dr["Ads"] = "Ad" + (Convert.ToString(dsBannerId.Tables[0].Rows[i]["Order_No"]));
                        dr["IPhone"] = iphoneDownloads;
                        dr["Android"] = androidDownloads;
                        dr["Windows"] = windowsDownloads;
                        dt.Rows.Add(dr);
                        count = count + iphoneDownloads + androidDownloads + windowsDownloads;
                    }

                    LoadChartData(dt);

                }
                string isSponserAd = Request.QueryString["isSponserAd"];
                if (Convert.ToBoolean(isSponserAd))
                {
                    lblTotalCount.Text = "<b>Total Sponsor Ad Click Count To Date:" + count.ToString() + "</b";
                    lblTitle.Text = "<b>Sponsor Ad Click Count between " + pstartDate + " and " + pendDate + " - " + count.ToString() + "</b";
                    this.Title = "Online Sponsor Ad Click Report";
                }
                else
                {
                    lblTotalCount.Text = "<b>Total Banner Ad Click Count To Date:" + count.ToString() + "</b";
                    lblTitle.Text = "<b>Banner Ad Click Count between " + pstartDate + " and " + pendDate + " - " + count.ToString() + "</b";
                }
                //lblTotalCount.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppDownloads.Replace("#TotalDownloads#", totalDownloads.ToString()) + "</b>";
                //lblTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageReportTitle.Replace("#StartDate#", pstartDate).Replace("#EndDate#", pendDate).Replace("#Count#", totalDownloads.ToString()) + "</b>";


                int interval = 1;
                if (lsClicks.Count > 0)
                    interval = lsClicks.Max() / 5;

                chartAppUsage.ChartAreas["UsageChartArea"].AxisY.Interval = interval;
                //Hide or show chart back GridLines  
                chartAppUsage.ChartAreas["UsageChartArea"].AxisX.MajorGrid.Enabled = false;
                chartAppUsage.ChartAreas["UsageChartArea"].AxisY.MajorGrid.Enabled = false;

                chartAppUsage.Series["Series1"].Name = "Apple";
                chartAppUsage.Series["Series2"].Name = "Android";
                chartAppUsage.Series["Series3"].Name = "Windows";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "PrintBannerAdClickReport.aspx.cs", "BindChart", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return totalDownloads;
        }
        private void LoadChartData(DataTable initialDataSource)
        {
            try{
            for (int i = 1; i < initialDataSource.Columns.Count; i++)
            {
                Series series = new Series();
                foreach (DataRow dr in initialDataSource.Rows)
                {
                    int y = (int)dr[i];
                    series.Points.AddXY(dr["Ads"].ToString(), y);
                    if (y > 0)
                        series.IsValueShownAsLabel = true;
                }
                chartAppUsage.Series.Add(series);
            }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "PrintBannerAdClickReport.aspx.cs", "LoadChartData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}