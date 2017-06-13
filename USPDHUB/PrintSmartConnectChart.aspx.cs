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
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using iTextSharp;

namespace USPDHUB
{
    public partial class PrintSmartConnectChart : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable dtGraph = (DataTable)Session["PrintChart"];

                    BindChart(dtGraph);
                }
                catch (Exception ex)
                {
                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    /*** Error Log ***/
                    objInBuiltData.ErrorHandling("ERROR", "PrintSmartConnectChart.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
        }
        private void BindChart(DataTable dtGraph)
        {
            try
            {
                DataView dv = new DataView(dtGraph);
                dv.RowFilter = "MessageCount>0";
                dtGraph = dv.ToTable();
                Series series = new Series();
                //chartAppUsage.Titles.Add("SmartConnect Messages");

                DataTable ChartData = dtGraph;

                //storing total rows count to loop on each Record  
                string[] XPointMember = new string[ChartData.Rows.Count];
                int[] YPointMember = new int[ChartData.Rows.Count];
                int TotalMessagesCount = 0;

                for (int count = 0; count < ChartData.Rows.Count; count++)
                {
                    //storing Values for X axis  
                    XPointMember[count] = ChartData.Rows[count]["CategoryName"].ToString();
                    //storing values for Y Axis  
                    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["MessageCount"]);
                    series.Palette = ChartColorPalette.BrightPastel;
                    series.LabelForeColor = Color.Black;

                    TotalMessagesCount = TotalMessagesCount + Convert.ToInt32(ChartData.Rows[count]["MessageCount"]);
                }

                lblTotalCount.Text = TotalMessagesCount.ToString();

                series.Points.DataBindXY(XPointMember, YPointMember);
                chartAppUsage.Series.Add(series);

                // Set the PieLabelStyle custom attribute to the value of "Outside"
                chartAppUsage.Series[0]["PieLabelStyle"] = "Outside";

                // By default, the callout lines will not be drawn unless you set a color for the series border
                chartAppUsage.Series[0].BorderWidth = 1;
                chartAppUsage.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                chartAppUsage.Series[0].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);

                //setting Chart type   
                chartAppUsage.Series[0].ChartType = SeriesChartType.Pie;

                foreach (Series charts in chartAppUsage.Series)
                {
                    foreach (DataPoint point in charts.Points)
                    {
                        point.Label = string.Format("{1} - {0:0}({2})", point.YValues[0], point.AxisLabel, "#PERCENT{P0}");
                    }
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PrintSmartConnectChart.aspx.cs", "BindChart", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
    }
}