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
using System.Data.SqlClient;
using USPDHUBDAL;

namespace USPDHUB.Admin
{

    public partial class ExcelDownload : System.Web.UI.Page
    {
        public AgencyBLL agencyobj = new AgencyBLL();
        public CommonBLL objCommon = new CommonBLL();
        public BusinessBLL objBus = new BusinessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnAppReports);
                lblerror.Text = "";
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
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExcelDownload.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void filldata()
        {
            try
            {
                // *** Gettting Active Verticals *** //
                DataTable dtverticals = agencyobj.GetActiveVerticals();
                ddlVerticals.DataSource = dtverticals;
                ddlVerticals.DataTextField = "Vertical_Name";
                ddlVerticals.DataValueField = "Vertical_Value";
                ddlVerticals.DataBind();
                ddlVerticals.Items.Insert(0, new ListItem("All", "0"));
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExcelDownload.aspx.cs", "filldata", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnAppReports_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            try
            {
                string vertical = ddlVerticals.SelectedItem.Text;
                string userType = ddlUser.SelectedItem.Text;
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime endDate = Convert.ToDateTime(txtEndDate.Text);

                //***************** My Code Goes Here ******************//


                //Get Week starting dates into an array In the range of start and end dates.
                int Days = 7;
                int weeks = (endDate - startDate).Days / 7;
                DateTime firstWeekStartDate = startDate;
                List<DateTime> lstWeekStartDays = new List<DateTime>();

                if (startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    #region Getting All Week Start Dates into List
                    for (int i = 0; i <= weeks; i++)
                    {
                        if (firstWeekStartDate <= endDate)
                        {
                            lstWeekStartDays.Add(firstWeekStartDate);
                            firstWeekStartDate = firstWeekStartDate.AddDays(Days);
                        }
                    }
                    #endregion
                }
                else
                {
                    lstWeekStartDays.Add(startDate);
                    string day = Convert.ToString(startDate.DayOfWeek);
                    #region Dictionary
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    dictionary.Add("Monday", 6);
                    dictionary.Add("Tuesday", 5);
                    dictionary.Add("Wednesday", 4);
                    dictionary.Add("Thursday", 3);
                    dictionary.Add("Friday", 2);
                    dictionary.Add("Saturday", 1);
                    #endregion
                    #region Finding Week StartDay
                    if (day == "Monday")
                    {
                        firstWeekStartDate = startDate.AddDays(dictionary["Monday"]);
                    }
                    else if (day == "Tuesday")
                    {
                        firstWeekStartDate = startDate.AddDays(dictionary["Tuesday"]);
                    }
                    else if (day == "Wednesday")
                    {
                        firstWeekStartDate = startDate.AddDays(dictionary["Wednesday"]);
                    }
                    else if (day == "Thursday")
                    {
                        firstWeekStartDate = startDate.AddDays(dictionary["Thursday"]);
                    }
                    else if (day == "Friday")
                    {
                        firstWeekStartDate = startDate.AddDays(dictionary["Friday"]);
                    }
                    else if (day == "Saturday")
                    {
                        firstWeekStartDate = startDate.AddDays(dictionary["Saturday"]);
                    }
                    #endregion
                    #region Getting All Week Start Dates into List
                    while (firstWeekStartDate < endDate)
                    {
                        if (firstWeekStartDate <= endDate)
                        {
                            lstWeekStartDays.Add(firstWeekStartDate);
                            firstWeekStartDate = firstWeekStartDate.AddDays(Days);
                        }
                    }
                    #endregion
                }
                lstWeekStartDays.Add(endDate);

                if (startDate <= endDate)
                {
                    //Start of Get Data from DB
                    DataTable dt = new DataTable();
                    SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
                    SqlCommand sqlCmd = new SqlCommand("usp_GetMobileAppDownloadReports", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                    sqlCmd.Parameters.AddWithValue("@UserType", userType);
                    sqlCmd.Parameters.AddWithValue("@startDate", startDate);
                    sqlCmd.Parameters.AddWithValue("@endDate", endDate);
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.Fill(dt);
                    ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);

                    //End of getting Data

                    if (dt.Rows.Count > 0)
                    {
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
                        //var ss = (from row in dt.Rows.Cast<DataRow>() where row["UserID"].ToString() == "125" select row).ToList();
                        //var list = (from row in deviceList where row.UserID == 125 && row.ProfileID == 10001 && row.DeviceType == "WindowsPhone" select row).ToList();
                        //LINQ

                        //Get Distinct Users From DataTable
                        DataTable uniqueCols = dt.DefaultView.ToTable(true, "UserID", "ProfileID", "ProfileName");

                        string reportBuilder = string.Empty;
                        reportBuilder = @"<table>
                        <tr>
                        <td style='font-size:14px';>Member ID</td>
                        <td style='font-size:14px';>Name</td>
                        <td colspan= " + (lstWeekStartDays.Count) + (lstWeekStartDays.Count - 1) + " style='font-size:14px';>Dates</td></tr>";

                        reportBuilder += "<tr><td></td><td></td>";
                        for (int j = 0; j < lstWeekStartDays.Count; j++)    // DateTime Dates in lstWeekStartDays
                        {
                            reportBuilder += "<td>" + lstWeekStartDays[j].ToShortDateString() + "</td>";
                            if (j >= 1)
                                reportBuilder += "<td> Δ </td>";
                        }
                        reportBuilder += "</tr>";

                        if (uniqueCols.Rows.Count > 0)
                        {
                            for (int i = 0; i < uniqueCols.Rows.Count; i++)
                            {
                                reportBuilder += "<tr>";
                                reportBuilder += "<td style='font-size:12px';>" + uniqueCols.Rows[i]["UserID"] + "</td><td align='left' style='font-size:12px';>" + uniqueCols.Rows[i]["ProfileName"] + "</td>";
                                reportBuilder += "<td colspan=" + (lstWeekStartDays.Count) + (lstWeekStartDays.Count - 1) + (-2) + "></td>";
                                reportBuilder += "</tr>";

                                //******* Display Count of Devices Here using UserID and Till Date *******//

                                //Android
                                #region Android
                                reportBuilder += "<tr>";
                                reportBuilder += "<td></td><td align='right' style='font-size:12px';>Android</td>";
                                for (int j = 0; j < lstWeekStartDays.Count; j++)
                                {
                                    var androidCount = (from row in deviceList
                                                        where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                            row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                            row.DeviceType.ToLower() == "android"
                                                        select row).ToList().Count;
                                    var androidPastWeekCount = (from row in deviceList
                                                                where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                                    row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]).AddDays(-7) &&
                                                                    row.DeviceType.ToLower() == "android"
                                                                select row).ToList().Count;

                                    reportBuilder += "<td style='font-size:10px';>" + androidCount + "</td>";
                                    if (j >= 1)
                                        reportBuilder += "<td style='font-size:10px';>" + (androidCount - androidPastWeekCount) + "</td>";
                                }
                                reportBuilder += "</tr>";
                                #endregion
                                //Android

                                //Windows
                                #region Windows
                                reportBuilder += "<tr>";
                                reportBuilder += "<td></td><td align='right' style='font-size:12px';>Windows</td>";
                                for (int j = 0; j < lstWeekStartDays.Count; j++)
                                {
                                    var winCount = (from row in deviceList
                                                    where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                        row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                        (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                                    select row).ToList().Count;

                                    var winPastWeekCount = (from row in deviceList
                                                            where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                                row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]).AddDays(-7) &&
                                                                (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                                            select row).ToList().Count;

                                    reportBuilder += "<td style='font-size:10px';>" + winCount + "</td>";
                                    if (j >= 1)
                                        reportBuilder += "<td style='font-size:10px';>" + (winCount - winPastWeekCount) + "</td>";
                                }
                                reportBuilder += "</tr>";
                                #endregion
                                //Windows

                                //IPhone
                                #region Iphone
                                reportBuilder += "<tr>";
                                reportBuilder += "<td></td><td align='right' style='font-size:12px';>iOS</td>";
                                for (int j = 0; j < lstWeekStartDays.Count; j++)
                                {
                                    var iosCount = (from row in deviceList
                                                    where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                        row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                        (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                                    select row).ToList().Count;
                                    var iosPastWeekCount = (from row in deviceList
                                                            where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                                row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]).AddDays(-7) &&
                                                                (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                                            select row).ToList().Count;

                                    reportBuilder += "<td style='font-size:10px';>" + iosCount + "</td>";
                                    if (j >= 1)
                                        reportBuilder += "<td style='font-size:10px';>" + (iosCount - iosPastWeekCount) + "</td>";
                                }
                                reportBuilder += "</tr>";
                                #endregion
                                //IPhone

                                //Total
                                #region Total
                                reportBuilder += "<tr>";
                                reportBuilder += "<td></td><td align='right' style='font-size:12px';><b>Total</b></td>";
                                for (int j = 0; j < lstWeekStartDays.Count; j++)
                                {
                                    int androidCount = 0;
                                    int winCount = 0;
                                    int iosCount = 0;

                                    int pastWeekAndroidCount = 0;
                                    int pastWeekWinCount = 0;
                                    int pastWeekIosCount = 0;

                                    androidCount = (from row in deviceList
                                                    where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                        row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                        row.DeviceType.ToLower() == "android"
                                                    select row).ToList().Count;

                                    winCount = (from row in deviceList
                                                where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                    row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                    (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                                select row).ToList().Count;

                                    iosCount = (from row in deviceList
                                                where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                    row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]) &&
                                                    (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                                select row).ToList().Count;

                                    pastWeekAndroidCount = (from row in deviceList
                                                            where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                                row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]).AddDays(-7) &&
                                                                row.DeviceType.ToLower() == "android"
                                                            select row).ToList().Count;

                                    pastWeekWinCount = (from row in deviceList
                                                        where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                            row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]).AddDays(-7) &&
                                                            (row.DeviceType.ToLower() == "windowsphone" || row.DeviceType.ToLower() == "windows")
                                                        select row).ToList().Count;

                                    pastWeekIosCount = (from row in deviceList
                                                        where row.UserID == Convert.ToInt32(uniqueCols.Rows[i]["UserID"]) &&
                                                            row.CreatedDate <= Convert.ToDateTime(lstWeekStartDays[j]).AddDays(-7) &&
                                                            (row.DeviceType.ToLower() == "iphone" || row.DeviceType.ToLower() == "ios")
                                                        select row).ToList().Count;

                                    reportBuilder += "<td style='font-size:10px';>" + (androidCount + winCount + iosCount) + "</td>";

                                    if (j >= 1)
                                        reportBuilder += "<td style='font-size:10px';>" + Convert.ToInt32((androidCount + winCount + iosCount) - (pastWeekAndroidCount + pastWeekWinCount + pastWeekIosCount)) + "</td>";
                                }
                                reportBuilder += "</tr>";
                                #endregion
                                //Total
                            }
                        }
                        Response.Clear();
                        Response.Charset = "";
                        Response.ContentType = "application/msexcel";
                        Response.AddHeader("Content-Disposition", "filename=ExcelFile.xls");
                        Response.Write(reportBuilder);
                        Response.Flush();
                        //Response.End();                        
                    }
                    else
                        lblerror.Text = "<span style='color:red; font-size:12px;'>There are no reports available.</span>";
                }
                else
                    lblerror.Text = "<span style='color:red; font-size:12px;'>To Date should be later than or equal to From Date.</span>";
            }
            catch (Exception ex)
            {                 
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExcelDownload.aspx.cs", "btnAppReports_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                throw new Exception(ex.Message);
            }
            //***************** My Code Ends Here ******************//
        }
    }
}