using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Drawing;
using System.Text;

namespace USPDHUB.Admin
{
    public class UniqueDevices
    {
        public int ProfileID { get; set; }
        public string Platform { get; set; }
        public int DeviceCount { get; set; }

    }
    public class MyDevices
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DeviceType { get; set; }
        public string ProfileName { get; set; }
        public bool IsActive { get; set; }
    }

    public partial class AppStatisticsReportNew : System.Web.UI.Page
    {
        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnAppReports);
                lblerror.Text = "";
                ltrlDisplayData.Text = "";
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!IsPostBack)
                {
                    filldata();
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReportNew.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void filldata()
        {
            // *** Gettting Active Verticals *** //
            try
            {
                DataTable dtverticals = agencyobj.GetActiveVerticals();
                chkVerticals.DataSource = dtverticals;
                chkVerticals.DataTextField = "Vertical_Name";
                chkVerticals.DataValueField = "Vertical_Value";
                chkVerticals.DataBind();

            }
            catch (Exception filldataEx)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReportNew.aspx.cs", "Page_Load", filldataEx.Message, Convert.ToString(filldataEx.StackTrace),
                    Convert.ToString(filldataEx.InnerException), Convert.ToString(filldataEx.Data));

                throw new Exception(filldataEx.Message);
            }
        }
        private int DisplayData()
        {
            DataTable dt = new DataTable();
            DataTable dtUnique = new DataTable();
            try
            {
                string criteria = string.Empty;
                string criteriaType = string.Empty;
                string dateHeader = string.Empty;
                string userType = string.Empty;
                DateTime startDate;
                DateTime endDate;
                int monthSpan = 0;
                bool isGenericApps = false;
                bool isDisplayDelta = false;
                List<DateTime> lstWeekStartDays = new List<DateTime>();
                string dateStartHeader = string.Empty;
                string dateEndHeader = string.Empty;

                foreach (ListItem objItem in chkVerticals.Items)
                {
                    if (objItem.Selected)
                        criteria += objItem.Value + ",";
                }
                if (criteria != "")
                    criteria = criteria.Remove(criteria.Length - 1, 1);
                criteriaType = "Verticals";
                if (!string.IsNullOrEmpty(txtUserId.Text))
                {
                    criteria = txtUserId.Text;
                    criteriaType = "UserID";
                }

                userType = ddlUser.SelectedItem.Text;
                startDate = Convert.ToDateTime(txtStartDate.Text);
                endDate = Convert.ToDateTime(txtEndDate.Text);
                monthSpan = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;

                lstWeekStartDays.Add(startDate);
                lstWeekStartDays.Add(endDate.AddDays(1));


                if (startDate <= endDate)
                {
                    if (chkGenericApps.Checked == true)
                        isGenericApps = true;

                    if (chkDelta.Checked)
                        isDisplayDelta = true;

                    //Start of Get Data from DB
                    dt = objBus.GetProfileDetails(criteria, criteriaType, userType, isGenericApps, startDate, endDate);
                    //End of getting Data

                    if (dt.Rows.Count > 0)
                    {
                        StringBuilder reportBuilder = new StringBuilder();
                        int tableWidth = 0;

                        // LINQ 
                        IList<MyDevices> deviceList = new List<MyDevices>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            deviceList.Add(new MyDevices
                            {
                                ProfileID = Convert.ToInt32(dt.Rows[i]["ProfileID"]),
                                UserID = Convert.ToInt32(dt.Rows[i]["UserID"]),
                                CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]),
                                DeviceType = Convert.ToString(dt.Rows[i]["DeviceType"]),
                                ProfileName = Convert.ToString(dt.Rows[i]["ProfileName"])
                            });
                        }

                        #region Unique Device List
                        dtUnique = objBus.GetUniqueProfileID();
                        IList<UniqueDevices> uniqueDeviceList = new List<UniqueDevices>();
                        for (int i = 0; i < dtUnique.Rows.Count; i++)
                        {
                            uniqueDeviceList.Add(new UniqueDevices
                            {
                                ProfileID = Convert.ToInt32(dtUnique.Rows[i]["Profile_ID"]),
                                Platform = dtUnique.Rows[i]["Vertical_Name"].ToString(),
                                DeviceCount = Convert.ToInt32(dtUnique.Rows[i]["ToalDownloads"])

                            });
                        }
                        #endregion

                        //Get Distinct Users From DataTable
                        DataTable uniqueCols = dt.DefaultView.ToTable(true, "UserID", "ProfileID", "ProfileName");

                        //Table Construction Starts Here
                        int totalDataColumns = Convert.ToInt32(lstWeekStartDays.Count) * 3;
                        tableWidth = 100 * (totalDataColumns) + 875;
                        if (isDisplayDelta)
                            tableWidth += 100;
                        reportBuilder.Append("<table border='0px' cellpadding='2px' cellspacing='2px' width='" + tableWidth + "'>");
                        #region Colgroup Start
                        reportBuilder.Append("<colgroup><col width='125px'/><col width='350px'/>");
                        for (int i = 0; i < lstWeekStartDays.Count * 3; i++)
                            reportBuilder.Append("<col width='100px'/>");
                        if (isDisplayDelta)
                            reportBuilder.Append("<col width='100px'/>");
                        reportBuilder.Append("<col width='125px'/><col width='125px'/><col width='150px'/>");
                        reportBuilder.Append("</colgroup>");
                        #endregion Colgroup Ends

                        #region Table Columns Headings starts here
                        for (int j = 0; j < lstWeekStartDays.Count; j++)    // DateTime Dates in lstWeekStartDays
                        {
                            if (j == 0)
                                dateHeader = lstWeekStartDays[j].ToString("MM/dd/yy");
                            else if (j == lstWeekStartDays.Count - 1)
                            {
                                string endCheckDate = lstWeekStartDays[j].AddDays(-1).ToString("MM/dd/yy");
                                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == lstWeekStartDays[j].AddDays(-1))
                                    endCheckDate = DateTime.Now.ToString("MM/dd/yy");
                                dateHeader = endCheckDate;
                            }
                            else
                                dateHeader = lstWeekStartDays[j].ToString("MM/dd/yy");
                            if (string.IsNullOrEmpty(dateStartHeader))
                                dateStartHeader = dateHeader;
                            else
                                dateEndHeader = dateHeader;
                        }
                        reportBuilder.Append("<tr><td colspan='2' style='font-size:13pt; text-align:center;'><b>Period " + dateStartHeader + " - " + dateEndHeader + "</b></td>");
                        reportBuilder.Append("<td style='text-align:center;' colspan='" + (isDisplayDelta ? (totalDataColumns + 2) : (totalDataColumns + 1)) + "' style='font-size:13pt;'><b>Download Report</b></td>");
                        reportBuilder.Append("<td style='font-size:13pt; text-align:center;'><b>" + DateTime.Now.ToString("MM/dd/yy hh:mm tt") + "</b></td>");
                        reportBuilder.Append("<td style='font-size:13pt;'></td>");
                        reportBuilder.Append("</tr>");
                        reportBuilder.Append("<tr><td style='font-size:12pt; text-align:center;'><b>ID Number</b></td>");
                        reportBuilder.Append("<td style='font-size:12pt; text-align:center;'><b>Member Name</b></td>");
                        reportBuilder.Append("<td colspan='" + lstWeekStartDays.Count + "' style='font-size:12pt; text-align:center; background-color:#8ED2C9;'><b>Android</b></td>");
                        reportBuilder.Append("<td colspan='" + lstWeekStartDays.Count + "' style='font-size:12pt; text-align:center; background-color:#7B8D8E;'><b>iOS</b></td>");
                        reportBuilder.Append("<td colspan='" + lstWeekStartDays.Count + "' style='font-size:12pt; text-align:center; background-color:#FFB85F;'><b>Windows</b></td>");
                        if (isDisplayDelta)
                            reportBuilder.Append("<td style='font-size:12pt; text-align:center; background-color:#BEF0CC;'><b>Delta</b></td>");
                        reportBuilder.Append("<td style='font-size:12pt;  text-align:center;'><b>PeriodTotal</b></td>");
                        reportBuilder.Append("<td style='font-size:12pt; text-align:center;'><b>YTD Total</b></td>");
                        reportBuilder.Append("<td style='font-size:12pt;  text-align:center;'><b>Platform</b></td>");
                        reportBuilder.Append("</tr>");
                        #endregion Table Columns Headings ends here
                        #region Table Data
                        string totalRow = "";
                        int android1Total = 0;
                        int android2Total = 0;
                        int ios1Total = 0;
                        int ios2Total = 0;
                        int windows1Total = 0;
                        int windows2Total = 0;
                        int deltaTotal = 0;
                        int periodTotal = 0;
                        int ytdTotal = 0;
                        string platform = "";
                        for (int i = 0; i < uniqueCols.Rows.Count; i++)
                        {
                            reportBuilder.Append("<tr>");
                            reportBuilder.Append("<td style='font-size:12pt; padding:4px;  text-align:center;'>" + uniqueCols.Rows[i]["UserID"] + "</td><td align='left' style='font-size:12pt; padding:4px;'>" + uniqueCols.Rows[i]["ProfileName"] + "</td>");


                            var android1Count = (from row in deviceList
                                                 where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                     row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[0]) &&
                                                     row.DeviceType.ToLower() == "android"
                                                 select row).ToList().Count;
                            var android2Count = (from row in deviceList
                                                 where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                     row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[lstWeekStartDays.Count - 1]) &&
                                                     row.DeviceType.ToLower() == "android"
                                                 select row).ToList().Count;
                            var win1Count = (from row in deviceList
                                             where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                 row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[0]) &&
                                                 (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                             select row).ToList().Count;
                            var win2Count = (from row in deviceList
                                             where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                 row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[lstWeekStartDays.Count - 1]) &&
                                                 (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                             select row).ToList().Count;
                            var ios1Count = (from row in deviceList
                                             where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                 row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[0]) &&
                                                 (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                             select row).ToList().Count;
                            var ios2Count = (from row in deviceList
                                             where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                 row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[lstWeekStartDays.Count - 1]) &&
                                                 (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                             select row).ToList().Count;

                            //YTDCount and Platform Columns

                            var ytdCount = (from row in uniqueDeviceList
                                            where row.ProfileID == Convert.ToInt32(uniqueCols.Rows[i]["ProfileID"])

                                            select row.DeviceCount).FirstOrDefault();
                            ytdTotal += ytdCount;

                            var x = (from row in uniqueDeviceList
                                     where row.ProfileID == Convert.ToInt32(uniqueCols.Rows[i]["ProfileID"])
                                     select row.Platform).ToList();
                            platform = x[0];

                            var periodCount = android2Count + win2Count + ios2Count;
                            periodTotal += periodCount;
                            var deltaCount = periodCount - (android1Count + win1Count + ios1Count);
                            android1Total += android1Count; android2Total += android2Count;
                            ios1Total += ios1Count; ios2Total += ios2Count;
                            windows1Total += win1Count; windows2Total += win2Count;
                            deltaTotal += deltaCount;
                            reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + android1Count + "</td><td style='font-size:10pt; text-align:right;'>" + android2Count + "</td>");
                            reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + ios1Count + "</td><td style='font-size:10pt; text-align:right;'>" + ios2Count + "</td>");
                            reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + win1Count + "</td><td style='font-size:10pt; text-align:right;'>" + win2Count + "</td>");
                            totalRow = "<td style='font-size:10pt;' align='right'>" + periodCount + "</td>";


                            if (isDisplayDelta)
                                reportBuilder.Append("<td style = 'font-size:10pt; background-color:#BEF0CC; text-align:right;'>" + deltaCount + "</td>");
                            reportBuilder.Append(totalRow);

                            reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + ytdCount + "</td>");

                            reportBuilder.Append("<td style='font-size:12pt;'>" + platform + "</td>");
                            reportBuilder.Append("</tr>");

                        }
                        #endregion
                        reportBuilder.Append("<tr><td style='background-color:#FFEB94;' colspan='" + (isDisplayDelta ? (totalDataColumns + 5) : (totalDataColumns + 4)) + "'</td><td>&nbsp;</td>");
                        reportBuilder.Append("<tr><td>&nbsp;</td><td align='center'>TOTAL</td>");
                        reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + android1Total + "</td><td style='font-size:10pt; text-align:right;'>" + android2Total + "</td>");
                        reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + ios1Total + "</td><td style='font-size:10pt; text-align:right;'>" + ios2Total + "</td>");
                        reportBuilder.Append("<td style='font-size:10pt; text-align:right;'>" + windows1Total + "</td><td style='font-size:10pt; text-align:right;'>" + windows2Total + "</td>");
                        if (isDisplayDelta)
                            reportBuilder.Append("<td style = 'font-size:10pt; background-color:#BEF0CC; text-align:right;'>" + deltaTotal + "</td>");
                        reportBuilder.Append("<td style='font-size:10pt;' align='right'>" + periodTotal + "</td>");
                        reportBuilder.Append("</tr>");
                        reportBuilder.Append("<td>&nbsp;</td><td align='center'>Percent of Total</td>");
                        reportBuilder.Append("<td>&nbsp;</td><td align='center'>" + ((int)Math.Round((double)(100 * android2Total) / periodTotal)) + "%</td>");
                        reportBuilder.Append("<td>&nbsp;</td><td align='center'>" + ((int)Math.Round((double)(100 * ios2Total) / periodTotal)) + "%</td>");
                        reportBuilder.Append("<td>&nbsp;</td><td align='center'>" + ((int)Math.Round((double)(100 * windows2Total) / periodTotal)) + "%</td>");
                        if (isDisplayDelta)
                            reportBuilder.Append("<td style = 'font-size:10pt; background-color:#BEF0CC; text-align:right;'>&nbsp;</td>");
                        reportBuilder.Append("<td style='font-size:10pt;' align='right'>100%</td>");
                        reportBuilder.Append("<td style='font-size:10pt;' align='right'>" + ytdTotal + "</td>");
                        reportBuilder.Append("<td style='font-size:10pt;' align='right'>&nbsp</td>");
                        reportBuilder.Append("</tr>");
                        reportBuilder.Append("</table>");
                        ltrlDisplayData.Text = reportBuilder.ToString();
                        return 0;
                    }
                    else
                        return 1;
                }
                else
                    return 2;
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReportNew.aspx.cs", "DisplayData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                throw new Exception(ex.Message);
            }
        }
        protected void btnAppReports_Click(object sender, EventArgs e)
        {
            try
            {
                //Export to excel
                if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text))
                {
                    int retVal = DisplayData();
                    if (retVal == 0)
                    {
                        Response.Clear();
                        Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                        Response.Write("<head>");
                        Response.Write("<!--[if gte mso 9]><xml>");
                        Response.Write("<x:ExcelWorkbook>");
                        Response.Write("<x:ExcelWorksheets>");
                        Response.Write("<x:ExcelWorksheet>");
                        Response.Write("<x:Name>App Downloads</x:Name>");
                        Response.Write("<x:WorksheetOptions>");
                        Response.Write("<x:Print>");
                        Response.Write("<x:ValidPrinterInfo/>");
                        Response.Write("</x:Print>");
                        Response.Write("</x:WorksheetOptions>");
                        Response.Write("</x:ExcelWorksheet>");
                        Response.Write("</x:ExcelWorksheets>");
                        Response.Write("</x:ExcelWorkbook>");
                        Response.Write("</xml>");
                        Response.Write("<![endif]--> ");
                        Response.Write("</head>");
                        Response.Write("<body>");
                        Response.Write(ltrlDisplayData.Text.ToString());
                        Response.AddHeader("content-disposition", "attachment; filename=" + txtStartDate.Text.Trim() + " - " + txtEndDate.Text.Trim() + " - AppReport.xls");
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = "application/vnd.xls";
                        Response.Write("</body>");
                        Response.Write("</html>");
                        Response.End();
                    }
                    else if (retVal == 1)
                        lblerror.Text = "<span style='color:red; font-size:12px;'>There are no reports available.</span>";
                    else
                        lblerror.Text = "<span style='color:red; font-size:12px;'>To Date should be later than or equal to From Date.</span>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReportNew.aspx.cs", "btnAppReports_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text))
                {
                    int retVal = DisplayData();
                    if (retVal == 0)
                    {

                    }
                    else if (retVal == 1)
                        lblerror.Text = "<span style='color:red; font-size:12px;'>There are no reports available.</span>";
                    else
                        lblerror.Text = "<span style='color:red; font-size:12px;'>To Date should be later than or equal to From Date.</span>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReportNew.aspx.cs", "btnDisplay_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}