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
    public partial class PrintAppOpenReport : System.Web.UI.Page
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
                    objInBuiltData.ErrorHandling("ERROR", "PrintAppOpenReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
        }
        private int BindChart(string pstartDate, string pendDate)
        {
            int count = 0;
            try
            {
                DateTime startDate = Convert.ToDateTime(pstartDate);
                DateTime endDate = Convert.ToDateTime(pendDate).AddDays(1);
                lblTitle.Text = "";
                int totalDownloads = 0;
                DataTable dtPieChart = objBus.GetPieChartDataForOpenReport(ProfileID, startDate, endDate, out totalDownloads);
                int iphoneDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Iphone_Downloads"].ToString());
                int androidDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Android_Downloads"].ToString());
                int windowsDownloads = Convert.ToInt32(dtPieChart.Rows[0]["Windows_Downloads"].ToString());
                count = iphoneDownloads + androidDownloads + windowsDownloads;
                List<PieChart> listPieChart = new List<PieChart>();
                lblTotalCount.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppOpen.Replace("#TotalDownloads#", totalDownloads.ToString()) + "</b>";
                if (count > 0)
                {
                    lblTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppOpenTitle.Replace("#StartDate#", pstartDate).Replace("#EndDate#", pendDate).Replace("#Count#", count.ToString()) + "</b>";
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
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "PrintAppOpenReport.aspx.cs", "BindChart", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return count;
        }
        public class PieChart
        {
            public string PlatForms { get; set; }
            public int Downloads { get; set; }
        }
    }

}