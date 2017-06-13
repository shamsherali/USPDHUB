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
    public class MyDevicesOld
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DeviceType { get; set; }
        public string ProfileName { get; set; }
        public bool IsActive { get; set; }
    }
    public partial class AppStatisticsReport : System.Web.UI.Page
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
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
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
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReport.aspx.cs", "filldata", filldataEx.Message, Convert.ToString(filldataEx.StackTrace),
                    Convert.ToString(filldataEx.InnerException), Convert.ToString(filldataEx.Data));
                throw new Exception(filldataEx.Message);
            }
        }
        private int DisplayData()
        {
            DataTable dt = new DataTable();
            try
            {
                string criteria = string.Empty;
                string criteriaType = string.Empty;
                string dateHeader = string.Empty;
                string userType = string.Empty;
                DateTime startDate;
                DateTime endDate;
                DateTime monthStartDate;
                int monthSpan = 0;
                bool isGenericApps = false;
                bool isDisplayDelta = false;
                List<DateTime> lstWeekStartDays = new List<DateTime>();

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

                if (1 < monthSpan)
                {
                    lstWeekStartDays.Add(startDate);
                    monthStartDate = startDate;
                    for (int i = 1; i <= monthSpan - 1; i++)
                    {
                        monthStartDate = startDate.AddMonths(i);
                        monthStartDate = Convert.ToDateTime(monthStartDate.Month + "/01/" + monthStartDate.Year);
                        lstWeekStartDays.Add(monthStartDate);
                    }
                    lstWeekStartDays.Add(endDate.AddDays(1));
                }
                else
                {
                    lstWeekStartDays.Add(startDate);
                    lstWeekStartDays.Add(endDate.AddDays(1));
                }


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
                        IList<MyDevicesOld> deviceList = new List<MyDevicesOld>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            deviceList.Add(new MyDevicesOld
                            {
                                ProfileID = Convert.ToInt32(dt.Rows[i]["ProfileID"]),
                                UserID = Convert.ToInt32(dt.Rows[i]["UserID"]),
                                CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]),
                                DeviceType = Convert.ToString(dt.Rows[i]["DeviceType"]),
                                ProfileName = Convert.ToString(dt.Rows[i]["ProfileName"])
                            });
                        }

                        //Get Distinct Users From DataTable
                        DataTable uniqueCols = dt.DefaultView.ToTable(true, "UserID", "ProfileID", "ProfileName");

                        //Table Construction Starts Here
                        tableWidth = 100 * (Convert.ToInt32(lstWeekStartDays.Count) + 5);
                        reportBuilder.Append("<table border='0px' cellpadding='2px' cellspacing='2px' width='" + tableWidth + "'>");
                        #region Colgroup Start
                        reportBuilder.Append("<colgroup><col width='125px'/><col width='350px'/>");
                        for (int i = 0; i < lstWeekStartDays.Count; i++)
                            reportBuilder.Append("<col width='100px'/>");
                        reportBuilder.Append("</colgroup>");
                        #endregion Colgroup Ends

                        #region Table Columns Headings starts here
                        reportBuilder.Append("<tr style='background-color:#99CC00;' color:#FCFCFC;'><td style='font-size:16pt;'>Member ID</td><td style='font-size:16pt;'>Name</td>");
                        reportBuilder.Append("<td colspan= " + Convert.ToInt32(lstWeekStartDays.Count) + " style='font-size:16pt;'>Dates</td></tr>");
                        reportBuilder.Append("<tr><td></td><td></td>");
                        for (int j = 0; j < lstWeekStartDays.Count; j++)    // DateTime Dates in lstWeekStartDays
                        {
                            if (j == 0)
                                dateHeader = lstWeekStartDays[j].ToString("MMM dd yyyy");
                            else if (j == lstWeekStartDays.Count - 1)
                            {
                                string endCheckDate = lstWeekStartDays[j].AddDays(-1).ToString("MMM dd yyyy");
                                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == lstWeekStartDays[j].AddDays(-1))
                                    endCheckDate = DateTime.Now.ToString("MMM dd yyyy hh:mm tt");
                                dateHeader = endCheckDate;
                            }
                            else
                                dateHeader = lstWeekStartDays[j].ToString("MMM dd yyyy");
                            reportBuilder.Append("<td style='font-size:12pt; padding:4px;'>" + dateHeader + "</td>");
                        }
                        reportBuilder.Append("</tr>");

                        #endregion Table Columns Headings ends here
                        var pastWeekAndroidCount = 0;
                        var pastWeekWinCount = 0;
                        var pastWeekIosCount = 0;
                        for (int i = 0; i < uniqueCols.Rows.Count; i++)
                        {
                            reportBuilder.Append("<tr>");
                            reportBuilder.Append("<td style='font-size:12pt; padding:4px;'>" + uniqueCols.Rows[i]["UserID"] + "</td><td align='left' style='font-size:12pt; padding:4px;'>" + uniqueCols.Rows[i]["ProfileName"] + "</td>");
                            reportBuilder.Append("<td colspan= " + Convert.ToInt32(lstWeekStartDays.Count) + " style='font-size:16pt;'></td>");
                            reportBuilder.Append("</tr>");

                            #region Android
                            string androidRow = "<tr><td></td><td align='right' style='font-size:12pt;'>Android</td>";
                            string winRow = "<tr><td></td><td align='right' style='font-size:12pt;'>Windows</td>";
                            string iosRow = "<tr><td></td><td align='right' style='font-size:12pt;'>iOS</td>";
                            string totalRow = "<tr><td></td><td align='right' style='font-size:12pt;'><b>Total</b></td>";
                            string deltaRow = "<tr><td></td><td align='right' style='font-size:12pt;background-color:yellow;'><b>Period Delta</b></td><td></td>";
                            for (int j = 0; j < lstWeekStartDays.Count; j++)
                            {
                                var androidCount = (from row in deviceList
                                                    where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                        row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                        row.DeviceType.ToLower() == "android"
                                                    select row).ToList().Count;
                                var winCount = (from row in deviceList
                                                where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                    row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                    (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                                select row).ToList().Count;
                                var iosCount = (from row in deviceList
                                                where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                    row.CreatedDate < Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                    (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                                select row).ToList().Count;
                                androidRow += "<td style='font-size:10pt;' align='center'>" + androidCount + "</td>";
                                winRow += "<td style='font-size:10pt;' align='center'>" + winCount + "</td>";
                                iosRow += "<td style='font-size:10pt;' align='center'>" + iosCount + "</td>";
                                totalRow += "<td style='font-size:10pt;' align='center'>" + (androidCount + winCount + iosCount) + "</td>";
                                if (j >= 1)
                                    deltaRow += "<td style='font-size:10pt;background-color:yellow;' align='center'>" + Convert.ToInt32((androidCount + winCount + iosCount) - (pastWeekAndroidCount + pastWeekWinCount + pastWeekIosCount)) + "</td>";
                                pastWeekAndroidCount = androidCount;
                                pastWeekWinCount = winCount;
                                pastWeekIosCount = iosCount;
                            }
                            androidRow += "</tr>";
                            winRow += "</tr>";
                            iosRow += "</tr>";
                            totalRow += "</tr>";
                            deltaRow += "</tr>";
                            reportBuilder.Append(androidRow);
                            reportBuilder.Append(winRow);
                            reportBuilder.Append(iosRow);
                            reportBuilder.Append(totalRow);
                            if (isDisplayDelta)
                                reportBuilder.Append(deltaRow);
                            #endregion
                        }

                        //Grand total
                        #region Grand Total
                        reportBuilder.Append("<tr>");
                        reportBuilder.Append("<td></td><td style='font-size:16pt;' align='center'>Report Summary</td><td colspan=" + Convert.ToInt32(lstWeekStartDays.Count) + "></td>");
                        reportBuilder.Append("</tr>");
                        reportBuilder.Append("<tr>");
                        reportBuilder.Append("<td></td><td style='font-size:14pt;background-color:yellow;' align='center'>Period End Total Downloads</td><td colspan=" + Convert.ToInt32(lstWeekStartDays.Count) + "></td>");
                        reportBuilder.Append("</tr>");
                        reportBuilder.Append("<tr>");

                        string androidTotalRow = "<tr><td></td><td align='right' style='font-size:12pt;background-color:yellow;'>Android</td>";
                        string wintotalRow = "<tr><td></td><td align='right' style='font-size:12pt;background-color:yellow;'>Windows</td>";
                        string iosTotalRow = "<tr><td></td><td align='right' style='font-size:12pt;background-color:yellow;'>iOS</td>";
                        string grandTotalRow = "<tr><td></td><td align='right' style='font-size:12pt;background-color:yellow;'><b>Total Downloads All Platforms</b></td>";
                        string totalDeltaRow = "<tr><td></td><td align='right' style='font-size:12pt; background-color:yellow;'>Period Delta</td><td></td>";

                        for (int j = 0; j < lstWeekStartDays.Count; j++)
                        {
                            int totalAndroidCount = 0;
                            int totalWinCount = 0;
                            int totalIosCount = 0;

                            int lastMonthTotalAndroidCount = 0;
                            int lastMonthTotalWinCount = 0;
                            int lastMonthTotalIosCount = 0;

                            totalAndroidCount = (from row in deviceList
                                                 where row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) && (row.DeviceType.ToLower() == "android")
                                                 select row).ToList().Count;

                            totalWinCount = (from row in deviceList
                                             where row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) && (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                             select row).ToList().Count;

                            totalIosCount = (from row in deviceList
                                             where row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) && (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                             select row).ToList().Count;


                            androidTotalRow += "<td style='font-size:10pt;background-color:yellow;' align='center'>" + totalAndroidCount + "</td>";
                            wintotalRow += "<td style='font-size:10pt;background-color:yellow;' align='center'>" + totalWinCount + "</td>";
                            iosTotalRow += "<td style='font-size:10pt;background-color:yellow;' align='center'>" + totalIosCount + "</td>";
                            grandTotalRow += "<td style='font-size:10pt;' align='center'>" + (totalAndroidCount + totalWinCount + totalIosCount) + "</td>";

                            if (j >= 1)
                            {
                                lastMonthTotalAndroidCount = (from row in deviceList
                                                              where row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j - 1]) && (row.DeviceType.ToLower() == "android")
                                                              select row).ToList().Count;
                                lastMonthTotalWinCount = (from row in deviceList
                                                          where row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j - 1]) && (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                                          select row).ToList().Count;
                                lastMonthTotalIosCount = (from row in deviceList
                                                          where row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j - 1]) && (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                                          select row).ToList().Count;
                                totalDeltaRow += "<td style='font-size:10pt;background-color:yellow;' align='center'>" + Convert.ToInt32((totalAndroidCount + totalWinCount + totalIosCount) - (lastMonthTotalAndroidCount + lastMonthTotalWinCount + lastMonthTotalIosCount)) + "</td>";
                            }
                        }
                        androidTotalRow += "</tr>";
                        wintotalRow += "</tr>";
                        iosTotalRow += "</tr>";
                        grandTotalRow += "</tr>";
                        totalDeltaRow += "</tr>";

                        reportBuilder.Append(androidTotalRow);
                        reportBuilder.Append(wintotalRow);
                        reportBuilder.Append(iosTotalRow);
                        reportBuilder.Append("<tr><td colspan= " + Convert.ToInt32(lstWeekStartDays.Count) + 2 + "></td></tr>");
                        reportBuilder.Append(grandTotalRow);
                        if (isDisplayDelta)
                            reportBuilder.Append(totalDeltaRow);
                        reportBuilder.Append("</tr>");
                        #endregion

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
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReport.aspx.cs", "DisplayData", ex.Message, Convert.ToString(ex.StackTrace),
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
                        Response.AddHeader("content-disposition", "attachment; filename=" + txtStartDate.Text.Trim() + " - " + txtEndDate.Text.Trim() + " - AppReport.xlsx");
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        //Response.ContentType = "application/vnd.xls";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
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
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReport.aspx.cs", "btnAppReports_Click", ex.Message, Convert.ToString(ex.StackTrace),
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
                objInBuiltData.ErrorHandling("ERROR", "AppStatisticsReport.aspx.cs", "btnDisplay_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}