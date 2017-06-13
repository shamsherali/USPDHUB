using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.Admin
{
    public partial class CSNotesReport : System.Web.UI.Page
    {
        public string Userid = string.Empty;
        AdminBLL objAdminBLL = new AdminBLL();
        DataTable dtsales = new DataTable();
        public double subamt = 0;
        public double billamt = 0;
        public int SortStrigCount = 0;
        public string SortString = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!IsPostBack)
                {
                    pnlcategory.Visible = false;
                }
                lblmsg.Text = "";
                lblerr.Text = "";
                pnlgrid.Visible = false;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0) || (txtcategory.Text.Trim().Length > 0 && drpcategory.SelectedIndex > 0))
                {
                    if (txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0)
                    {

                        DateTime fromdate = Convert.ToDateTime(txtDTFrom.Text);
                        DateTime todate = Convert.ToDateTime(txttodate.Text);
                        if (todate > DateTime.Now.Date || fromdate > DateTime.Now.Date)
                        {
                            lblerr.Text = "To Date and From Date must be less than current date.";
                        }
                        else
                        {
                            if (fromdate <= todate)
                            {
                                if ((txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0) && (txtcategory.Text.Trim().Length > 0 && drpcategory.SelectedIndex > 0))
                                {
                                    lblmsg.Text = "<font color=red face=arial size=2>Please enter either From & To Dates OR First/Last/Profile Names.</font>";
                                    dtsales.Rows.Clear();
                                }
                                else
                                {
                                    filldata();
                                }
                            }
                            else
                            {
                                lblerr.Text = "To Date must be greater than From Date.";
                            }
                        }
                    }
                    else
                    {
                        if ((txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0) && (txtcategory.Text.Trim().Length > 0 && drpcategory.SelectedIndex > 0))
                        {
                            lblmsg.Text = "<font color=red face=arial size=2>Please enter either From & To Dates OR First/Last/Profile Names.</font>";
                            dtsales.Rows.Clear();
                        }
                        else
                        {
                            filldata();
                        }
                    }
                }
                else
                {
                    lblmsg.Text = "<font color=red face=arial size=2>Please enter either From & To Dates OR First/Last/Profile Names.</font>";
                }
            }
            catch (Exception ex)
            {
                lblvaliddate.Text = "";
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "btn_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void filldata()
        {
            try
            {
                //string Query = BuildSqlquery();
                //DataTable dtsales = new DataTable();
                //dtsales = objAdminBLL.Getsalesdetails(Query);
                dtsales = BuildSqlquery();
                pnlgrid.Visible = true;

                if (dtsales.Rows.Count > 0)
                {
                    grdlogin.PageIndex = 0;
                    grdlogin.Visible = true;
                    grdlogin.DataSource = dtsales;
                    grdlogin.DataBind();
                }
                else
                {
                    lblmsg.Text = "No Records found";
                    grdlogin.Visible = false;
                    pnlgrid.Visible = false;
                }
                Session["Profiledetails"] = dtsales;
            }
            catch (Exception ex)
            {               
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "filldata", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void btndashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        protected void grdlogin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                BusinessBLL busobj = new BusinessBLL();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    /*
                    Label lblprofileid = e.Row.FindControl("lblprofileid") as Label;
                    Label lblbusinessname = e.Row.FindControl("lblbusinessname") as Label; 
                    */

                    Label lblUserID = e.Row.FindControl("lblUserID") as Label;
                    string userID = lblUserID.Text;
                    DataTable dtobj = objAdminBLL.GetCustomerDeskNotesDetailsByUser_ID(Int32.Parse(userID));

                    Label lblNotes = e.Row.FindControl("lblNotes") as Label;
                    string notesStrHtml = "";
                    for (int i = 0; i < dtobj.Rows.Count; i++)
                    {
                        notesStrHtml = notesStrHtml + "<tr><td  style='border-bottom:0px solid gray; '>" + Convert.ToString(dtobj.Rows[i]["Notes"]) + "</td></tr><tr><td  align='right' ><b>" + Convert.ToString(dtobj.Rows[i]["Notes_By"]) + "</b></td></tr>";
                    }

                    notesStrHtml = "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='white-space: normal;' >" + notesStrHtml + "</table>";

                    lblNotes.Text = notesStrHtml;

                }// END If
            }
            catch (Exception ex)
            {                
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "grdlogin_RowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdlogin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                pnlgrid.Visible = true;
                grdlogin.PageIndex = e.NewPageIndex;
                grdlogin.DataSource = (DataTable)Session["Profiledetails"];
                grdlogin.DataBind();
            }
            catch (Exception ex)
            {                
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "grdlogin_PageIndexChanging", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void drpcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpcategory.SelectedValue != "0")
            {
                pnlcategory.Visible = true;
            }
            else
            {
                pnlcategory.Visible = false;
            }
        }

        public DataTable BuildSqlquery()
        {
            string categoryID = string.Empty;
            string categoryname = string.Empty;
            string SQLQuery = string.Empty;
            categoryID = drpcategory.SelectedValue.ToString();
            categoryname = txtcategory.Text.Trim();
            if (txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0)
            {
                DateTime fromdate = Convert.ToDateTime(txtDTFrom.Text.Trim());
                DateTime todate = Convert.ToDateTime(txttodate.Text.Trim());

                return objAdminBLL.GetCSNotesReportData("0", "", fromdate, todate);
            }

            return objAdminBLL.GetCSNotesReportData(categoryID.Trim(), categoryname.Trim(), DateTime.Now, DateTime.Now);


            /*
           string categoryID = string.Empty;
           string categoryname = string.Empty;
           string SQLQuery = string.Empty;
           categoryID = drpcategory.SelectedValue.ToString();
           categoryname = txtcategory.Text.Trim();
           SQLQuery = @" SELECT     T_Users.User_ID, T_Users.Firstname, T_Users.Lastname, T_Users.Username,
                           T_Business_Profiles.Profile_name, T_Business_Profiles.Profile_ID
                       FROM    T_Business_Profiles INNER JOIN   T_Users ON T_Business_Profiles.User_ID = T_Users.User_ID
                       WHERE  ";
 
           if (txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0)
           {
               DateTime fromdate = Convert.ToDateTime(txtDTFrom.Text.Trim());
               DateTime todate = Convert.ToDateTime(txttodate.Text.Trim());
                
               SQLQuery = SQLQuery + "T_Users.User_ID in (select User_ID from T_CustomerDeskNotes WHERE CAST(Created_Dt as datetime) >= cast(\'" + fromdate + "\' as datetime) ";
               SQLQuery = SQLQuery + " AND CAST(Created_Dt as datetime) <= cast(\'" + todate + "\' as datetime) )";
                

               return objAdminBLL.GetCSNotesReportData("0", "", fromdate, todate);
           }

           return objAdminBLL.GetCSNotesReportData(categoryID.Trim(), categoryname.Trim(), DateTime.Now, DateTime.Now);

           
           if (categoryID == "1")
           {
               if (categoryname.Trim().Length > 0)
               {
                   SQLQuery = SQLQuery + " T_Users.FirstName like '%" + categoryname.Trim() + "%'";
               }
           }
           if (categoryID == "2")
           {
               if (categoryname.Trim().Length > 0)
               {
                   SQLQuery = SQLQuery + " T_Users.LastName like '%" + categoryname.Trim() + "%'";
               }
           }
           if (categoryID == "3")
           {
               if (categoryname.Trim().Length > 0)
               {
                   SQLQuery = SQLQuery + " T_Business_Profiles.Profile_name like '%" + categoryname.Trim() + "%'";
               }
           }

           return SQLQuery;
           */
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                grdreport.DataSource = (DataTable)Session["Profiledetails"];
                grdreport.DataBind();
                GridViewExportUtil.Export("CSNotesReport.xls", grdreport);
            }
            catch (Exception ex)
            {                
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "btnReport_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdreport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try{
            BusinessBLL busobj = new BusinessBLL();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*
                Label lblprofileid = e.Row.FindControl("lblprofileid") as Label;
                Label lblbusinessname = e.Row.FindControl("lblbusinessname") as Label; 
                */

                Label lblUserID = e.Row.FindControl("lblUserID") as Label;
                string userID = lblUserID.Text;
                DataTable dtobj = objAdminBLL.GetCustomerDeskNotesDetailsByUser_ID(Int32.Parse(userID));

                Label lblNotes = e.Row.FindControl("lblNotes") as Label;
                string notesStrHtml = "";
                for (int i = 0; i < dtobj.Rows.Count; i++)
                {
                    notesStrHtml = notesStrHtml + "<tr><td style='border-bottom:0px solid gray;'>" + Convert.ToString(dtobj.Rows[i]["Notes"]) + "</td></tr><tr><td style='border-bottom:0px solid gray;' align='right' ><b>" + Convert.ToString(dtobj.Rows[i]["Notes_By"]) + "</b></td></tr>";
                }

                notesStrHtml = "<table  border='0' cellpadding='0' cellspacing='0' width='100%' style='white-space: normal;' >" + notesStrHtml + "</table>";

                lblNotes.Text = notesStrHtml;

            }// END If
            }
            catch (Exception ex)
            {               
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CSNotesReport.aspx.cs", "grdreport_RowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

    }
}