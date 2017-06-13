using System;
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
    public partial class AppUsageReports : System.Web.UI.Page
    {
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        StringBuilder str = new StringBuilder();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBranded = false;
        public int C_UserID = 0;
        public DataTable dtUserDetails = new DataTable();
        public bool IsBlockedSendAccess = true;
        public string RootPath = "";
        public string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();


                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                    IsParent = false;
                if (Convert.ToBoolean(dtProfiles.Rows[0]["IsBranded_App"].ToString()))
                    IsBranded = true;

                if (!IsPostBack)
                {
                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                        string val = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.AppStatistics.ToString());
                        if (val != "P")
                            Response.Redirect("Default.aspx");
                    }
                    if (dtProfiles.Rows.Count > 0)
                    {
                        DateTime signUpDate = Convert.ToDateTime(dtProfiles.Rows[0]["CREATED_DT"]);
                        txtStartDate.Text = signUpDate.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        txtStartDate.Text = (DateTime.Now.Date.Month).ToString() + "/" + "01/" + DateTime.Now.Date.Year.ToString();
                    }

                    txtEndDate.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
                    BindChart();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppUsageReports.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private int BindChart()
        {
            int count = 0;
            //int openCount = 0;
            try
            {
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime endDate = Convert.ToDateTime(txtEndDate.Text).AddDays(1);
                lblTitle.Text = "";
                //lblAppOpenTitle.Text = "";
                lblTotalCount.Text = "";
                //lblAppOpenCount.Text = "";
                btnPrint.Visible = false;
                //#region User Sing Up Date wise Count
                //DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                //DateTime signUpDate = Convert.ToDateTime(dtProfiles.Rows[0]["CREATED_DT"]);
                //int singupCount;
                //DataTable dtPieChart1 = objBus.GetPieChartData(ProfileID, signUpDate, DateTime.Now, out totalDownloads);
                //int iphoneDownloads1 = Convert.ToInt32(dtPieChart1.Rows[0]["Iphone_Downloads"].ToString());
                //int androidDownloads1 = Convert.ToInt32(dtPieChart1.Rows[0]["Android_Downloads"].ToString());
                //int windowsDownloads1 = Convert.ToInt32(dtPieChart1.Rows[0]["Windows_Downloads"].ToString());
                //singupCount = iphoneDownloads1 + androidDownloads1 + windowsDownloads1;
                //#endregion
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
                if (count > 0) // || openCount > 0
                {
                    btnPrint.Visible = true;
                }
                List<PieChart> listPieChart = new List<PieChart>();
                if (count > 0)
                {
                    lblTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageReportTitle.Replace("#StartDate#", txtStartDate.Text).Replace("#EndDate#", txtEndDate.Text).Replace("#Count#", count.ToString()) + "</b>";
                   
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
                //    lblAppOpenTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppOpenTitle.Replace("#StartDate#", txtStartDate.Text).Replace("#EndDate#", txtEndDate.Text).Replace("#Count#", openCount.ToString()) + "</b>";

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
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppUsageReports.aspx.cs", "BindChart", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return (count); //  + openCount
        }

        protected void btnchart_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                int count = BindChart();
                if (count == 0)
                    lblMessage.Text = Resources.LabelMessages.NoUsageResult.Replace("#StartDate#", txtStartDate.Text).Replace("#EndDate#", txtEndDate.Text);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppUsageReports.aspx.cs", "btnchart_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                string url = RootPath + "/PrintAppUsageReport.aspx?sDate=" + EncryptDecrypt.DESEncrypt(txtStartDate.Text) + "&eDate=" + EncryptDecrypt.DESEncrypt(txtEndDate.Text) + "&PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString());
                ScriptManager.RegisterClientScriptBlock(this.btnPrint, this.GetType(), "Print", "window.open('" + url + "');", true);
                BindChart();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppUsageReports.aspx.cs", "btnPrint_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public class PieChart
        {
            public string PlatForms { get; set; }
            public int Downloads { get; set; }
        }
    }
}