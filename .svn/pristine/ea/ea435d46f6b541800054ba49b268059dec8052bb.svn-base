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
using System.Web.UI.DataVisualization.Charting;

namespace USPDHUB.Business.MyAccount
{
    public partial class BannerAdClickCountReport : BaseWeb
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

        public string RootPath = "";
        public string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();

            try
            {
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
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
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
                objInBuiltData.ErrorHandling("ERROR", "BannerAdClickCountReport.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private int BindChart()
        {
            int totalDownloads = 0;
            int count = 0;
            try
            {
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime endDate = Convert.ToDateTime(txtEndDate.Text).AddDays(1);
                lblTitle.Text = "";
                lblTotalCount.Text = "";
                DataSet dsBannerId = objBus.GetPieChartDataForBannerAdReport(ProfileID, startDate, endDate, 0, out totalDownloads);

                DataTable dt = new DataTable();
                dt.Columns.Add("Ads", Type.GetType("System.String"));
                dt.Columns.Add("IPhone", Type.GetType("System.Int32"));
                dt.Columns.Add("Android", Type.GetType("System.Int32"));
                dt.Columns.Add("Windows", Type.GetType("System.Int32"));
                //dt.Columns.Add("Image", Type.GetType("System.String"));
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
                        //if (i == 0)
                        //    dr["Image"] = "http://www.uspdhub.com/Upload/BannerAds/10319/20151026234216_320x480.png?id=dd221fc4-9f6f-4a28-9dcc-3bd4c4db93cb";
                        //else if (i == 1)
                        //    dr["Image"] = "http://www.uspdhub.com/Upload/BannerAds/10319/20150819021439_320x480.png?id=170efb8a-abac-4271-a528-6518aa7fbf59";
                        //else if (i == 2)
                        //    dr["Image"] = "http://www.uspdhub.com/Upload/BannerAds/10319/20150819021546_320x480.png?id=9281999e-c9d0-4dba-b2a9-cd571daf866d";
                        //else if (i == 3)
                        //    dr["Image"] = "http://www.uspdhub.com/Upload/BannerAds/10319/20151013225644_320x480.png?id=72f7b425-091c-44c4-b0ac-d8538572abe7";
                        //else if (i == 4)
                        //    dr["Image"] = "";
                        //else if (i == 5)
                        //    dr["Image"] = "http://www.uspdhub.com/Upload/BannerAds/10319/20151022033245_320x480.png?id=1c127923-89e3-4aa5-bafd-2774bcedb3e2";
                        dt.Rows.Add(dr);
                        count = count + iphoneDownloads + androidDownloads + windowsDownloads;
                    }

                    LoadChartData(dt);

                    btnPrint.Visible = true;
                }
                else
                {
                    btnPrint.Visible = false;
                }
                lblTotalCount.Text = "<b>Total Banner Ad Click Count To Date:" + count.ToString() + "</b";
                lblTitle.Text = "<b>Banner Ad Click Count between " + txtStartDate.Text + " and " + txtEndDate.Text + " - " + count.ToString() + "</b";
                //lblTotalCount.Text = "<b>" + Resources.ProfileAccessMessages.UsageAppDownloads.Replace("#TotalDownloads#", totalDownloads.ToString()) + "</b>";
                //lblTitle.Text = "<b>" + Resources.ProfileAccessMessages.UsageReportTitle.Replace("#StartDate#", txtStartDate.Text).Replace("#EndDate#", txtEndDate.Text).Replace("#Count#", totalDownloads.ToString()) + "</b>";
                int interval = 1;
                if (lsClicks.Count > 0)
                    interval = lsClicks.Max() / 5;
                chartAppUsage.ChartAreas["UsageChartArea"].AxisY.Interval = interval;
                //Hide or show chart back GridLines  
                chartAppUsage.ChartAreas["UsageChartArea"].AxisX.MajorGrid.Enabled = false;
                chartAppUsage.ChartAreas["UsageChartArea"].AxisY.MajorGrid.Enabled = false;

                //chartAppUsage.Series["Series1"]["DrawingStyle"] = "Cylinder";
                //chartAppUsage.Series["Series2"]["DrawingStyle"] = "Cylinder";
                //chartAppUsage.Series["Series3"]["DrawingStyle"] = "Cylinder";

                //chartAppUsage.Series["Series1"].Color = System.Drawing.Color.LightBlue;
                //chartAppUsage.Series["Series2"].Color = System.Drawing.Color.LightYellow;
                //chartAppUsage.Series["Series3"].Color = System.Drawing.Color.LightCyan;



                chartAppUsage.Series["Series1"].Name = "Apple";
                chartAppUsage.Series["Series2"].Name = "Android";
                chartAppUsage.Series["Series3"].Name = "Windows";

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdClickCountReport.aspx.cs", "BindChart", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return totalDownloads;
        }


        private void LoadChartData(DataTable initialDataSource)
        {
            try
            {
                for (int i = 1; i <= initialDataSource.Columns.Count - 1; i++)
                {
                    Series series = new Series();
                    //int rowIndex = 0;
                    foreach (DataRow dr in initialDataSource.Rows)
                    {
                        int y = (int)dr[i];
                        series.Points.AddXY(dr["Ads"].ToString(), y);
                        //if (Convert.ToString(dr["Image"]) != "")
                        //    series.Points[rowIndex].MapAreaAttributes = "onmouseover=\"showTooltip('" + Convert.ToString(dr["Image"]) + "',event);\"";
                        if (y > 0)
                            series.IsValueShownAsLabel = true;
                        //rowIndex++;
                    }
                    chartAppUsage.Series.Add(series);
                    chartAppUsage.Attributes.Add("onmouseover", "return hide()");
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdClickCountReport.aspx.cs", "LoadChartData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnchart_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                int count = BindChart();
                if (count == 0)
                    lblMessage.Text = Resources.LabelMessages.NoClickUsageResult.Replace("#StartDate#", txtStartDate.Text).Replace("#EndDate#", txtEndDate.Text);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdClickCountReport.aspx.cs", "btnchart_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Business/MyAccount/BannerAdsPreview.aspx");
        }

        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                string url = RootPath + "/PrintBannerAdClickReport.aspx?sDate=" + EncryptDecrypt.DESEncrypt(txtStartDate.Text) + "&eDate=" + EncryptDecrypt.DESEncrypt(txtEndDate.Text) + "&PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString());
                ScriptManager.RegisterClientScriptBlock(this.btnPrint, this.GetType(), "Print", "window.open('" + url + "');", true);
                BindChart();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdClickCountReport.aspx.cs", "btnPrint_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

    }
}