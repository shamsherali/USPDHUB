using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class DashboardLoginReport : System.Web.UI.Page
    {
        public string Userid = string.Empty;
        AdminBLL objAdmin = new AdminBLL();
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
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
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
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "btn_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void filldata()
        {
            try
            {
                string Query = BuildSqlquery();
                DataTable dtdetails = new DataTable();
                dtdetails = objAdmin.Getsalesdetails(Query);

                dtdetails.Columns.Add("Nooftimes", typeof(string));
                dtdetails.Columns.Add("LastloginDate", typeof(string));
                for (int i = 0; i < dtdetails.Rows.Count; i++)
                {
                    DataTable dtlogindetails = new DataTable();
                    string Userid = dtdetails.Rows[i]["User_ID"].ToString();
                    dtlogindetails = objAdmin.GetLoginDetailsbyUserID(Convert.ToInt32(Userid), txtDTFrom.Text, txttodate.Text);
                    if (dtlogindetails.Rows.Count > 0)
                    {
                        string count = dtlogindetails.Rows.Count.ToString();
                        string lastlogin = Convert.ToDateTime(dtlogindetails.Rows[0]["User_LastLoginDate"].ToString() + " " + dtlogindetails.Rows[0]["User_LastLoginTime"].ToString()).ToString();
                        dtdetails.Rows[i]["Nooftimes"] = count;
                        dtdetails.Rows[i]["LastloginDate"] = lastlogin.ToString();

                    }
                    else
                    {
                        dtdetails.Rows[i]["Nooftimes"] = "0";
                        dtdetails.Rows[i]["LastloginDate"] = "";
                    }
                }
                DataTable dtTable = new DataTable();
                DataView SortDt = new DataView(dtdetails);
                SortDt.Sort = "LastloginDate ASC";
                dtTable = SortDt.ToTable();
                dtsales = dtTable;

                pnlgrid.Visible = true;

                if (dtsales != null)
                {
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
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "filldata", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void btndashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void grdlogin_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataView dataView = new DataView((DataTable)Session["Profiledetails"]);
                string Sortdir = string.Empty;

                if (SortString == e.SortExpression)
                {
                    if (SortStrigCount == 0)
                    {
                        Sortdir = "ASC";
                        SortStrigCount = 1;
                    }
                    else
                    {
                        Sortdir = "DESC";
                        SortStrigCount = 0;
                    }
                    SortString = e.SortExpression;
                }
                else
                {
                    Sortdir = "ASC";
                    SortStrigCount = 1;
                    SortString = e.SortExpression;
                }



                dataView.Sort = e.SortExpression + " " + Sortdir;
                pnlgrid.Visible = true;
                Session["Profiledetails"] = dataView.ToTable();
                grdlogin.DataSource = dataView;
                grdlogin.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "grdlogin_Sorting", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdlogin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                BusinessBLL busobj = new BusinessBLL();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblprofileid = e.Row.FindControl("lblprofileid") as Label;
                    Label lblbusinessname = e.Row.FindControl("lblbusinessname") as Label;
                    Label lblphone = e.Row.FindControl("lblPhone") as Label;
                    string phonenum = lblphone.Text;
                    UtilitiesBLL utlobj = new UtilitiesBLL();
                    phonenum = utlobj.FormatPhonenumber(phonenum);
                    lblphone.Text = phonenum;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "grdlogin_RowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
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
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "grdlogin_PageIndexChanging", ex.Message, Convert.ToString(ex.StackTrace),
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
        public string BuildSqlquery()
        {

            string categoryID = string.Empty;
            string categoryname = string.Empty;
            string SQLQuery = string.Empty;
            categoryID = drpcategory.SelectedValue.ToString();
            categoryname = txtcategory.Text.Trim();
            SQLQuery = "SELECT DISTINCT (VUP.User_ID), VUP.Firstname,VUP.Lastname,VUP.Username,VUP.Profile_ID,VUP.Profile_StreetAddress1,VUP.Profile_Phone1,";
            SQLQuery = SQLQuery + " VUP.Profile_name,VUP.Profile_City, VUP.Profile_State,VUP.Profile_County, VUP.ID FROM View_UserProfiles VUP, T_UserTrack UT WHERE UT.User_ID=VUP.User_ID AND ";
            //SQLQuery = SQLQuery + " and (TS.Subscription_amount > 0.00 or TS.Extracities_Cost > 0 or TS.ExtraIndus_Cost > 0)";

            if (txtDTFrom.Text.Trim().Length > 0 && txttodate.Text.Trim().Length > 0)
            {
                SQLQuery = "SELECT DISTINCT UT.User_ID as UTUser_ID,(VUP.User_ID), VUP.Firstname,VUP.Lastname,VUP.Username,VUP.Profile_ID,VUP.Profile_StreetAddress1,VUP.Profile_Phone1, VUP.Profile_name,VUP.Profile_City, VUP.Profile_State,VUP.Profile_County, VUP.ID  from T_UserTrack UT,View_UserProfiles VUP WHERE  UT.User_ID=VUP.User_ID ";
                DateTime fromdate = Convert.ToDateTime(txtDTFrom.Text.Trim());
                DateTime todate = Convert.ToDateTime(txttodate.Text.Trim());
                SQLQuery = SQLQuery + " AND CAST(UT.User_LastLoginDate as datetime) >= cast(\'" + fromdate + "\' as datetime) ";
                SQLQuery = SQLQuery + " AND CAST(UT.User_LastLoginDate as datetime) <= cast(\'" + todate + "\' as datetime) ";

            }

            if (categoryID == "1")
            {
                if (categoryname.Trim().Length > 0)
                {
                    SQLQuery = SQLQuery + " VUP.FirstName like '%" + categoryname.Trim() + "%'";
                }
            }
            if (categoryID == "2")
            {
                if (categoryname.Trim().Length > 0)
                {
                    SQLQuery = SQLQuery + " VUP.LastName like '%" + categoryname.Trim() + "%'";
                }
            }
            if (categoryID == "3")
            {
                if (categoryname.Trim().Length > 0)
                {
                    SQLQuery = SQLQuery + " VUP.Profile_name like '%" + categoryname.Trim() + "%'";
                }
            }
            SQLQuery = SQLQuery + " Order by VUP.ID asc";
            return SQLQuery;
        }


        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                grdreport.DataSource = (DataTable)Session["Profiledetails"];
                grdreport.DataBind();
                GridViewExportUtil.Export("LoginReport.xls", grdreport);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "btnReport_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdreport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                BusinessBLL busobj = new BusinessBLL();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblphone = e.Row.FindControl("lblPhone") as Label;
                    string phonenum = lblphone.Text;
                    UtilitiesBLL utlobj = new UtilitiesBLL();
                    phonenum = utlobj.FormatPhonenumber(phonenum);
                    lblphone.Text = phonenum;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DashboardLoginReport.aspx.cs", "grdreport_RowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
    }
}