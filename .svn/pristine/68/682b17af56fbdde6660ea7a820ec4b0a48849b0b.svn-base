using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageSubAppsInvitations : System.Web.UI.Page
    {

        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string DomainName = "";
        DataTable dtSubApps = new DataTable();
        public int SortDir = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

            DomainName = Session["VerticalDomain"].ToString();

            if (!IsPostBack)
            {
                BindAffialiates();
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
            }
        }
        private void BindAffialiates()
        {
            int totalAffiliates = 0;
            string searchTag = txtSearch.Text.Trim();
            dtSubApps = objBus.GetSubAppsByParentID(ProfileID, searchTag, out totalAffiliates);
            grdSubApps.DataSource = dtSubApps;
            grdSubApps.DataBind();
            Session["ManageAffiliates"] = dtSubApps;
            if (totalAffiliates > 0)
                pnlSearch.Visible = true;
            else
                pnlSearch.Visible = false;
            /*** Based on domain Header text change ***/
            if (DomainName.ToLower().Contains("uspd"))
            {
                grdSubApps.Columns[0].HeaderText = "Agency Name";
            }
            else if (DomainName.ToLower().Contains("twovie"))
            {
                grdSubApps.Columns[0].HeaderText = "Organization Name";
            }
            else if (DomainName.ToLower().Contains("inschool"))
            {
                grdSubApps.Columns[0].HeaderText = "School Name";
            }
            else if (DomainName.ToLower().Contains("myyouth"))
            {
                grdSubApps.Columns[0].HeaderText = "Organization Name";
            }
            else
            {
                grdSubApps.Columns[0].HeaderText = "Agency Name";
            }
            if (searchTag != string.Empty)
                btnClear.Visible = true;
            else
                btnClear.Visible = false;
        }
        protected void grdSubApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                if (lblStatus.Text == "Accepted")
                {
                    lblStatus.CssClass = "AcceptedStatusClass";
                }
                else if (lblStatus.Text == "Declined")
                {
                    lblStatus.CssClass = "DeclinedStatusClass";
                }
                else if (lblStatus.Text == "Pending")
                {
                    lblStatus.CssClass = "PendingStatusClass";
                }
            }
        }
        protected void grdSubApps_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSubApps.PageIndex = e.NewPageIndex;
            grdSubApps.DataSource = (DataTable)Session["ManageAffiliates"];
            grdSubApps.DataBind();
        }
        protected void grdSubApps_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtSubApps = (DataTable)Session["ManageAffiliates"];
            if (hdnsortdire.Value != "")
            {
                if (hdnsortdire.Value != SortExp)
                {
                    hdnsortdire.Value = SortExp;
                    SortDir = 0;
                    hdnsortcount.Value = "0";
                }
            }
            else
            {
                hdnsortdire.Value = SortExp;
            }
            DataView Dv = new DataView(dtSubApps);
            if (SortDir == 0)
            {

                if (SortExp == "FullAddress")
                {
                    Dv.Sort = "FullAddress desc";
                }
                else if (SortExp == "Created_Date")
                {
                    Dv.Sort = "Created_Date desc";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "Status desc";
                }
                else if (SortExp == "EmailID")
                {
                    Dv.Sort = "Email_Address desc";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "FullAddress")
                {
                    Dv.Sort = "FullAddress ASC";
                }
                else if (SortExp == "Created_Date")
                {
                    Dv.Sort = "Created_Date ASC";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "Status asc";
                }
                else if (SortExp == "EmailID")
                {
                    Dv.Sort = "Email_Address asc";
                }
                hdnsortcount.Value = "0";
            }
            Session["ManageAffiliates"] = Dv.ToTable();
            grdSubApps.DataSource = Dv;
            grdSubApps.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != string.Empty)
                BindAffialiates();
            else
                lblmess.Text = "<font color=red face=arial size=2>" + Resources.LabelMessages.SubappsEmptySearch + "</font>";
        }
        protected void btnbtnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindAffialiates();
        }
    }
}