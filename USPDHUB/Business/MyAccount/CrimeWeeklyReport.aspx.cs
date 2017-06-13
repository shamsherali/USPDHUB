using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml.Linq;

namespace USPDHUB.Business.MyAccount
{
    //For Rocklin PD only
    public partial class CrimeWeeklyReport : System.Web.UI.Page
    {

        public int UserID = 0;
        public int ProfileID = 0;
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string RootPath = "";
        BulletinBLL objBulletinBLL = new BulletinBLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrimeWeeklyReport.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                RootPath = Session["RootPath"].ToString();

                if (!IsPostBack)
                {
                    UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                    ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                }
            }

            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrimeWeeklyReport.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrormessage.Text = "";

                string fromDate = txtStartDate.Text.Trim();
                string toDate = txtEndDate.Text.Trim();
                ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);

                DateTime dtFromTime = Convert.ToDateTime(fromDate);
                DateTime dtToTime = Convert.ToDateTime(toDate);

                if (dtFromTime > dtToTime)
                {
                    lblerrormessage.Text = "To Date should be later than or equal to From Date.";
                }
                else
                {
                    string fileName = dtFromTime.Day + "" + dtFromTime.Month + "" + dtFromTime.Year + "_" + dtToTime.Day + "" + dtToTime.Month + "" + dtToTime.Year;

                    DataTable dtCrimeDetailsReports = objBulletinBLL.GetCrimeWeeklyReportsDetailsByDates(dtFromTime, dtToTime, ProfileID, chkIncludePrivate.Checked);


                    DataTable dt2 = new DataTable();
                    for (int i = 0; i <= dtCrimeDetailsReports.Rows.Count; i++)
                    {
                        dt2.Columns.Add();
                    }
                    for (int i = 0; i < dtCrimeDetailsReports.Columns.Count; i++)
                    {
                        dt2.Rows.Add();
                        dt2.Rows[i][0] = dtCrimeDetailsReports.Columns[i].ColumnName;
                    }
                    for (int i = 0; i < dtCrimeDetailsReports.Columns.Count; i++)
                    {
                        for (int j = 0; j < dtCrimeDetailsReports.Rows.Count; j++)
                        {
                            dt2.Rows[i][j + 1] = dtCrimeDetailsReports.Rows[j][i];
                        }
                    }


                    if (dt2.Rows.Count > 0)
                    {
                        grdDownloads.ShowHeader = false;
                        grdDownloads.DataSource = dt2;
                        grdDownloads.DataBind();


                        string xmlFileName = Server.MapPath("~/BulletinPreview/CrimeReportColumnNames.xml");
                        string xmlString = File.ReadAllText(xmlFileName);
                        var xmlValues = XElement.Parse(xmlString, LoadOptions.PreserveWhitespace);


                        foreach (GridViewRow row in grdDownloads.Rows)
                        {
                            row.Cells[0].Font.Bold = true;
                            row.Cells[0].BackColor = Color.FromName("#657383");
                            if (row.Cells[0].Text == "FromDate")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("FromDate").Value);
                            }
                            else if (row.Cells[0].Text == "TotalIncidents")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("TotalIncidents").Value);
                            }
                            else if (row.Cells[0].Text == "OfficerInitiatedActivity")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("OfficerInitiatedActivity").Value);
                            }
                            else if (row.Cells[0].Text == "CallsforService")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("CallsforService").Value);
                            }
                            else if (row.Cells[0].Text == "ArrestsMisdemeanor")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("ArrestsMisdemeanor").Value);
                            }
                            else if (row.Cells[0].Text == "ArrestsFelony")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("ArrestsFelony").Value);
                            }
                            else if (row.Cells[0].Text == "CasesWritten")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("CasesWritten").Value);
                            }
                            else if (row.Cells[0].Text == "TrafficStops")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("TrafficStops").Value);
                            }
                            else if (row.Cells[0].Text == "Citations")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("Citations").Value);
                            }
                            else if (row.Cells[0].Text == "DUIArrests")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("DUIArrests").Value);
                            }
                            else if (row.Cells[0].Text == "Accidents")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("Accidents").Value);
                            }
                            else if (row.Cells[0].Text == "AccidentCriminal")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("AccidentCriminal").Value);
                            }
                            else if (row.Cells[0].Text == "ToDate")
                            {
                                row.Cells[0].Text = Convert.ToString(xmlValues.Element("ColumnNames").Attribute("ToDate").Value);
                            }
                        }



                        //grdDownloads.DataSource = null;
                        //grdDownloads.DataSource = dtCrimeDetailsReports;
                        //grdDownloads.DataBind();

                        string attachment = "attachment; filename=" + fileName.ToString().Replace(" ", "") + ".xls";
                        //System.Web.UI.WebControls.GridView grid = new GridView();
                        //grid.ShowHeader = false;
                        //grid.AutoGenerateColumns = true;
                        //grid.RowStyle.Wrap = true;
                        //grid.AlternatingRowStyle.Wrap = true;
                        //grid.DataSource = dt2;
                        //grid.DataBind();
                        ////grid.HeaderRow.Font.Bold = true;
                        ////grid.HeaderRow.ForeColor = Color.White;
                        ////grid.HeaderRow.BackColor = Color.FromName("#657383");
                        //foreach (GridViewRow row in grid.Rows)
                        //{
                        //    row.Cells[0].Font.Bold = true;
                        //    row.Cells[0].BackColor = Color.FromName("#657383");
                        //}

                        try
                        {
                            Response.Clear();
                            Response.AddHeader("content-disposition", attachment);
                            Response.ContentType = "application/vnd.ms-excel";

                            StringWriter stw = new StringWriter();
                            HtmlTextWriter htextw = new HtmlTextWriter(stw);
                            grdDownloads.RenderControl(htextw);

                            //Excel Export
                            Response.Write(stw.ToString());
                            Response.End();


                        }
                        catch (Exception ex)
                        {
                            objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "btnDownload_Click", Convert.ToString(ex.Message),
                            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                        }
                    }
                    else
                    {
                        lblerrormessage.Text = "There are no records between these dates.";
                    }

                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CrimeWeeklyReport.aspx.cs", "btnDownload_Click", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/BUsiness/MyAccount/SelectBulletin.aspx"));
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/BUsiness/MyAccount/ManageBulletins.aspx"));
        }
    }
}