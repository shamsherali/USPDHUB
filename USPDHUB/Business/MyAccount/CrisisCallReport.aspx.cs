using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Data;

namespace USPDHUB.Business.MyAccount
{
    public partial class CrisisCallReport : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string RootPath = "";
        BulletinBLL objBulletin = new BulletinBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallReport.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                RootPath = Session["RootPath"].ToString();

                if (!IsPostBack)
                {
                    UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                    ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);

                    //GetCrisisLogDownloads();

                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void GetCrisisLogDownloads()
        {
            try
            {
                DataTable dtCrisisLogDownloads = objBulletin.GetCrisisLogDownloads(UserID);
                grdDownloads.DataSource = dtCrisisLogDownloads;
                grdDownloads.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "GetCrisisLogDownloads", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            /*
            string fileName1 = "182013_2882013.xls";

            string VirtualPath = Server.MapPath("~/Upload/CrisisLogDownloads/" + fileName1);
            if (File.Exists(VirtualPath))
            {
                try
                {
                    Response.ContentType = "application/vnd.xls";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName1);
                    Response.TransmitFile(VirtualPath);
                }
                catch (Exception ex)
                { }
            }
            */

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

                    DataTable dtBulletinDetails = objBulletin.GetBulletinDetailsByDates(fromDate, toDate, ProfileID);
                    if (dtBulletinDetails.Rows.Count > 0)
                    {
                        //Save Reports details in DB
                        // int value = objBulletin.InsertCrisisLogDownloads(dtFromTime, dtToTime, true, UserID);

                        // After downloading excel then getting data from DB
                        // GetCrisisLogDownloads();

                        DataTable dtexportCrisis = new DataTable();
                        dtexportCrisis.Columns.Add("Report Title", typeof(string));
                        dtexportCrisis.Columns.Add("Associate", typeof(string));
                        dtexportCrisis.Columns.Add("Log In Date", typeof(string));
                        dtexportCrisis.Columns.Add("Log In Time", typeof(string));
                        dtexportCrisis.Columns.Add("AM / PM", typeof(string));
                        dtexportCrisis.Columns.Add("Log Out Date", typeof(string));
                        dtexportCrisis.Columns.Add("Log Out Time", typeof(string));
                        dtexportCrisis.Columns.Add("AM / PM ", typeof(string));
                        dtexportCrisis.Columns.Add("Transfer To", typeof(string));
                        dtexportCrisis.Columns.Add("Call Number", typeof(string));
                        dtexportCrisis.Columns.Add("Call Time", typeof(string));
                        dtexportCrisis.Columns.Add("AM / PM  ", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Type", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Type Agency Name", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Type Law Region Name", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request Agency", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request Counceling", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request Legal", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request Shelter", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request Social Work", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request Other", typeof(string));
                        dtexportCrisis.Columns.Add("Caller Request DVRT", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Request CPS", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Kids on Scene", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Kids in Household", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Request Follow Up", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Request Hospital", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Request Scene", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Request Other", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Request Law", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Law Region", typeof(string));
                        dtexportCrisis.Columns.Add("DVRT Law Personnel", typeof(string));


                        for (int i = 0; i < dtBulletinDetails.Rows.Count; i++)
                        {
                            objInBuiltData.ErrorHandling("LOG", "CrisisCallReport.aspx.cs", "btnDownload_Click==============" + dtBulletinDetails.Rows[i]["Custom_XML"], string.Empty, string.Empty, string.Empty, string.Empty);

                            if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[i]["Custom_XML"].ToString()))
                            {
                                string xml = Convert.ToString(dtBulletinDetails.Rows[i]["Custom_XML"]);

                                if (xml.Contains("<CallLogDetails"))
                                {
                                    string reportTitle = "";
                                    string associate = "";
                                    string logInDate = "";
                                    string logInTime = "";
                                    string logInTimeNoon = "";
                                    string logOutDate = "";
                                    string logOutTime = "";
                                    string logOutTimeNoon = "";
                                    string transferTo = "";


                                    XmlDocument doc = new XmlDocument();
                                    doc.LoadXml(xml);
                                    XmlNode xmlCall = doc.SelectNodes("/Bulletins/CallLogDetails").Item(0);
                                    if (xmlCall.Attributes["BulletinName"] != null)
                                    {
                                        reportTitle = xmlCall.Attributes["BulletinName"].Value;
                                    }
                                    objInBuiltData.ErrorHandling("LOG", "CrisisCallReport.aspx.cs", "btnDownload_Click==============" + xmlCall.Attributes["Associate1"].Value, string.Empty, string.Empty, string.Empty, string.Empty);
                                    associate = xmlCall.Attributes["Associate1"].Value;
                                    logInDate = xmlCall.Attributes["LoginDate"].Value;
                                    logInTime = xmlCall.Attributes["LoginHour"].Value + ":" + xmlCall.Attributes["LoginMin"].Value;
                                    logInTimeNoon = xmlCall.Attributes["LoginSection"].Value;
                                    logOutDate = xmlCall.Attributes["LogOutDate"].Value;
                                    logOutTime = xmlCall.Attributes["LogOutHour"].Value + ":" + xmlCall.Attributes["LogOutMin"].Value;
                                    logOutTimeNoon = xmlCall.Attributes["LogOutSection"].Value;
                                    transferTo = xmlCall.Attributes["TransferredPhoneTo"].Value;
                                    XmlNodeList xnList = doc.SelectNodes("/Bulletins/ChildCallerDetails");
                                    foreach (XmlNode xn in xnList)
                                    {
                                        DataRow dr = dtexportCrisis.NewRow();
                                        dr["Report Title"] = reportTitle;
                                        dr["Associate"] = associate;
                                        dr["Log In Date"] = logInDate;
                                        dr["Log In Time"] = logInTime;
                                        dr["AM / PM"] = logInTimeNoon;
                                        dr["Log Out Date"] = logOutDate;
                                        dr["Log Out Time"] = logOutTime;
                                        dr["AM / PM "] = logOutTimeNoon;
                                        dr["Transfer To"] = transferTo;
                                        dr["Call Number"] = xn.Attributes["PhoneNumber"].Value;
                                        dr["Call Time"] = xn.Attributes["CallHour"].Value + ":" + xn.Attributes["CallMin"].Value;
                                        dr["AM / PM  "] = xn.Attributes["CallSection"].Value;
                                        
                                        if (xn.Attributes["CPSIsChildrenScene"] != null)
                                        {
                                            dr["DVRT Kids on Scene"] = Convert.ToBoolean(xn.Attributes["CPSIsChildrenScene"].Value) == true ? "Yes" : "";
                                        }
                                        
                                        if (xn.Attributes["CPSIsChildrenHouseHold"] != null)
                                        {
                                            dr["DVRT Kids in Household"] = Convert.ToBoolean(xn.Attributes["CPSIsChildrenHouseHold"].Value) == true ? "Yes" : "";
                                        }
                                        string callertType = xn.Attributes["CallerType"].Value;
                                        if (callertType != "")
                                        {
                                            string[] strCTypes = callertType.Split(':');
                                            dr["Caller Type"] = strCTypes[0].ToString();
                                            if (strCTypes.Length > 1)
                                            {
                                                if (strCTypes[0].ToString().Contains("Law"))
                                                    dr["Caller Type Law Region Name"] = strCTypes[1].ToString();
                                                else
                                                    dr["Caller Type Agency Name"] = strCTypes[1].ToString();
                                            }
                                        }
                                        string requestType = xn.Attributes["CallRequest"].Value;
                                        if (requestType != "")
                                        {
                                            string[] reqTypes = requestType.Split(',');
                                            foreach (var item in reqTypes)
                                            {
                                                if (item.ToString().Contains("DVRT"))
                                                {
                                                    dr["Caller Request DVRT"] = "Yes";
                                                    string[] reqDVRT = item.ToString().Replace("DVRT:", "").Split('|');
                                                    foreach (var dvrtitem in reqDVRT)
                                                    {
                                                        if (dvrtitem.ToString() == "CPS")
                                                            dr["DVRT Request CPS"] = "Yes";
                                                        if (dvrtitem.ToString().ToLower().Contains("follow up"))
                                                            dr["DVRT Request Follow Up"] = "Yes";
                                                        if (dvrtitem.ToString().ToLower().Contains("hospital"))
                                                            dr["DVRT Request Hospital"] = "Yes";
                                                        if (dvrtitem.ToString() == "Scene")
                                                            dr["DVRT Request Scene"] = "Yes";
                                                        if (dvrtitem.ToString().ToLower().Contains("other:"))
                                                            dr["DVRT Request Other"] = dvrtitem.ToString().Replace("Other:", "");
                                                        if (dvrtitem.ToString().ToLower().Contains("law enforcement"))
                                                        {
                                                            dr["DVRT Request Law"] = "Yes";
                                                            string[] dvrtReqLaw = dvrtitem.ToString().Split(':');
                                                            dr["DVRT Law Region"] = dvrtReqLaw[1].ToString();
                                                            dr["DVRT Law Personnel"] = dvrtReqLaw[2].ToString();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (item.ToString().ToLower().Contains("agency"))
                                                        dr["Caller Request Agency"] = "Yes";
                                                    if (item.ToString().ToLower().Contains("counseling"))
                                                        dr["Caller Request Counceling"] = "Yes";
                                                    if (item.ToString().ToLower().Contains("legal"))
                                                        dr["Caller Request Legal"] = "Yes";
                                                    if (item.ToString().ToLower().Contains("shelter"))
                                                        dr["Caller Request Shelter"] = "Yes";
                                                    if (item.ToString().ToLower().Contains("social worker"))
                                                        dr["Caller Request Social Work"] = "Yes";
                                                    if (item.ToString().ToLower().Contains("other"))
                                                        dr["Caller Request Other"] = "Yes";
                                                }

                                            }
                                        }
                                        dtexportCrisis.Rows.Add(dr);
                                    }
                                }
                            }
                        }

                        string attachment = "attachment; filename=" + fileName.ToString().Replace(" ", "") + ".xls";
                        System.Web.UI.WebControls.GridView grid = new GridView();
                        grid.AutoGenerateColumns = true;
                        grid.RowStyle.Wrap = true;
                        grid.AlternatingRowStyle.Wrap = true;
                        grid.DataSource = dtexportCrisis;
                        grid.DataBind();
                        grid.HeaderRow.Font.Bold = true;
                        grid.HeaderRow.ForeColor = Color.White;
                        grid.HeaderRow.BackColor = Color.FromName("#657383");
                        try
                        {
                            Response.Clear();
                            Response.AddHeader("content-disposition", attachment);
                            Response.ContentType = "application/vnd.ms-excel";

                            StringWriter stw = new StringWriter();
                            HtmlTextWriter htextw = new HtmlTextWriter(stw);
                            grid.RenderControl(htextw);


                            /*
                            #region Save Crisis Log Reports in folder & DB

                            // Save Excel Report to FOlder
                            string filePath = Server.MapPath("~") + "/Upload/CrisisLogDownloads/";
                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                            }

                            filePath = filePath + fileName.ToString().Replace(" ", "") + ".xls";
                            File.WriteAllText(filePath, stw.ToString());


                            #endregion

                            */

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
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "btnDownload_Click", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkDownload = sender as LinkButton;
                GridViewRow Grow = (GridViewRow)lnkDownload.NamingContainer;
                Label lblstartDate = (Label)Grow.FindControl("lblFromDate");
                Label lblEndDate = (Label)Grow.FindControl("lblEndDate");

                DateTime fromDate = Convert.ToDateTime(lblstartDate.Text);
                DateTime endDate = Convert.ToDateTime(lblEndDate.Text);
                string fileName = fromDate.Day + "" + fromDate.Month + "" + fromDate.Year + "_" + endDate.Day + "" + endDate.Month + "" + endDate.Year + ".xls";

                string VirtualPath = Server.MapPath("~/Upload/CrisisLogDownloads/" + fileName);
                if (File.Exists(VirtualPath))
                {
                    try
                    {
                        Response.ContentType = "application/vnd.xls";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
                        Response.TransmitFile(VirtualPath);
                    }
                    catch (Exception /*ex*/)
                    { }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "lnkDownload_Click", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
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