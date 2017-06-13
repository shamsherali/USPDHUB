using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Configuration;

namespace USPDHUB.Admin
{
    public partial class ManageActivityLog : System.Web.UI.Page
    {
        BusinessBLL objBus = new BusinessBLL();
        AdminBLL objAdmin = new AdminBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        string DomainName = "";
        public int SortDir = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnsortcount.Value = "0";
                if (!IsPostBack)
                {
                    BindVerticals();
                    BindActivityData();
                   

                }

            }
            catch
            {
            }
        }

        private void BindActivityData()
        {
            if (ddlDomainName.SelectedItem.Text == "All Verticals")
                DomainName = string.Empty;
            else
                DomainName = ddlDomainName.SelectedItem.Text;
            DataTable dtActivity = new DataTable();
            dtActivity = objBus.GetManageLogByActivityID(0, DomainName);
            gvActivity.DataSource = dtActivity;
            gvActivity.DataBind();
        }
        protected void gvActivity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvActivity.PageIndex = e.NewPageIndex;
            gvActivity.DataBind();
            BindActivityData();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;

            Response.Redirect("~/Admin/ActivityLog.aspx?AID=" + EncryptDecrypt.DESEncrypt(lnk.CommandArgument));

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int activityID = Convert.ToInt32(lnk.CommandArgument);
            objAdmin.DeleteActivityLog(activityID);
            lblmsg.Text = "Content deleted successfully";
            BindActivityData();
        }
        protected void btnAddActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ActivityLog.aspx");
        }
        public void BindVerticals()
        {
            DataTable dtverticals = agencyobj.GetActiveVerticals();
            ddlDomainName.DataSource = dtverticals;
            ddlDomainName.DataTextField = "Vertical_Name";
            ddlDomainName.DataValueField = "Vertical_Value";
            ddlDomainName.DataBind();
            ddlDomainName.Items.Insert(0, new ListItem("All Verticals", ""));
        }

        protected void ddlDomainName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindActivityData();
        }

        protected void gvActivity_Sorting(object sender, GridViewSortEventArgs e)
        {

            string SortExp = e.SortExpression.ToString();
            BindActivityData();
            DataTable dt = gvActivity.DataSource as DataTable;
            SortDir = Convert.ToInt32(hdnsortcount.Value);
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
            DataView dv = new DataView(dt);
            if (SortDir == 0)
            {
                dv.Sort = "CreatedDate ASC";
                hdnsortcount.Value = "1";
            }
            else
            {
                dv.Sort = "CreatedDate DESC";
                hdnsortcount.Value = "0";
            }

            gvActivity.DataSource = dv;
            gvActivity.DataBind();

        }
    }
}