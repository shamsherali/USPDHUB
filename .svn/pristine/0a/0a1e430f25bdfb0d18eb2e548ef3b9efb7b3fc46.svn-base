using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using System.Web.Services;
using System.Data.SqlClient;

public partial class Business_MyAccount_ManageAssociates : BaseWeb
{
    public bool IsLiteVersion = false;
    public int ProfileID = 0;
    public int UserID = 0;
    DataTable dtBusinessUpdates = new DataTable();
    public int SortDir = 0;
    public int C_UserID = 0;
    public int pageInd = 0;
    AgencyBLL agencyobj = new AgencyBLL();
    BusinessBLL objBus = new BusinessBLL();
    Consumer objConsumer = new Consumer();
    CommonBLL objCommon = new CommonBLL();
    public bool IsSuperAdmin = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        IsLiteVersion = Convert.ToBoolean(Session["IsLiteVersion"]);
        lblmess.Text = "";
        Session["Variables"] = null;

        ProfileID = Convert.ToInt32(Session["ProfileID"]);
        UserID = Convert.ToInt32(Session["UserID"].ToString());
        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
        else
            C_UserID = UserID;
        hdnUserID.Value = C_UserID.ToString();
        if (!IsPostBack)
        {
            if (Session["C_USER_ID"] != null)
            {
                IsSuperAdmin = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.ManageAssociates) == "P" ? true : false;
                if (!IsSuperAdmin)
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
            }
            if (Request.QueryString["page"] != "" && Request.QueryString["page"] != null)
            {
                pageInd = Convert.ToInt32(Request.QueryString["page"]);
                GrdbusinessUpdates.PageIndex = pageInd;
            }
            lnkCreate.Visible = GrdbusinessUpdates.Visible = true;
            hdnsortdire.Value = "";
            hdnsortcount.Value = "0";
            FillDatalist();
            string associatemsg = "";

            if (Request.QueryString["count"] != "" && Request.QueryString["count"] != null)
            {
                string pwdmsg = "";
                if (Session["AssociateMsg"] != null)
                    pwdmsg = Session["AssociateMsg"].ToString();
                if (Request.QueryString["count"].ToString() == "3")
                    associatemsg = "<font color=green face=arial size=2><b>User permission details have been saved successfully.</b></font>";
                else if (Request.QueryString["count"].ToString() == "5")
                    associatemsg = "<font color=green face=arial size=2><b>User haven't changed the permissions.</b></font>";
                else
                    associatemsg = "<font color=green face=arial size=2><b>User permission details have been updated successfully.</b></font>";
            }
            else if (Session["AssociateMsg"] != null)
                associatemsg = Session["AssociateMsg"].ToString();
            Session["AssociateMsg"] = null;
            lblmess.Text = associatemsg;
        }
    }

    public void FillDatalist()
    {
        int totalAssociates = 0;
        string searchTag = txtSearch.Text.Trim();
        DataTable dt = objConsumer.GetManageAssociates(Convert.ToInt32(UserID), searchTag, out totalAssociates);
        if (totalAssociates > 0)
            pnlSearch.Visible = true;
        else
            pnlSearch.Visible = false;
        if (dt.Rows.Count > 0)
            hdnShowButtons.Value = "1";
        else
            hdnShowButtons.Value = "";
        Session["DtGetBusinessUpdates"] = dt;
        GrdbusinessUpdates.DataSource = dt;
        GrdbusinessUpdates.DataBind();
        if (searchTag != string.Empty)
            btnClear.Visible = true;
        else
            btnClear.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim() != string.Empty)
            FillDatalist();
        else
            lblmess.Text = "<font color=red face=arial size=2>" + Resources.LabelMessages.AssociateEmptySearch + "</font>";
    }
    protected void btnbtnClear_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        FillDatalist();
    }
    protected void GrdbusinessUpdates_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        hdnShowButtons.Value = "1"; ;
        GrdbusinessUpdates.PageIndex = e.NewPageIndex;
        GrdbusinessUpdates.DataSource = (DataTable)Session["DtGetBusinessUpdates"];
        GrdbusinessUpdates.DataBind();
    }

    protected void GrdbusinessUpdates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }

        //if (IsLiteVersion)
        //{
        //     foreach (DataControlField col in GrdbusinessUpdates.Columns)
        //         {
        //            if (col.HeaderText == "Receive Feedback")
        //             {
        //                 col.Visible = false;
        //            }
        //            if (col.HeaderText == "Receive Tips")
        //                 {
        //                     col.Visible = false;
        //                 }

        //         }
        //}
    }

    protected void GrdbusinessUpdates_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortDir = Convert.ToInt32(hdnsortcount.Value);
        string SortExp = e.SortExpression.ToString();
        dtBusinessUpdates = (DataTable)Session["DtGetBusinessUpdates"];
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
        //USPD-1116 Receive Tips related Changes
        DataView Dv = new DataView(dtBusinessUpdates);
        if (SortDir == 0)
        {

            if (SortExp == "Firstname")
            {
                Dv.Sort = "Firstname desc";
            }
            else if (SortExp == "Lastname")
            {
                Dv.Sort = "Lastname desc";
            }
            else if (SortExp == "Username")
            {
                Dv.Sort = "Username desc";
            }
            else if (SortExp == "IsTipsAdmin")
            {
                Dv.Sort = "IsTipsAdmin desc";
            }
            else if (SortExp == "IsReceiveTips")
            {
                Dv.Sort = "IsReceiveTips desc";
            }
            //else if (SortExp == "Active_flag")
            //{
            //    Dv.Sort = "Active_flag desc";
            //}
            hdnsortcount.Value = "1";
        }
        else
        {
            if (SortExp == "Firstname")
            {
                Dv.Sort = "Firstname ASC";
            }
            else if (SortExp == "Lastname")
            {
                Dv.Sort = "Lastname ASC";
            }
            else if (SortExp == "Username")
            {
                Dv.Sort = "Username asc";
            }
            else if (SortExp == "IsTipsAdmin")
            {
                Dv.Sort = "IsTipsAdmin asc";

            }
            else if (SortExp == "IsReceiveTips")
            {
                Dv.Sort = "IsReceiveTips asc";
            }
            //else if (SortExp == "Active_flag")
            //{
            //    Dv.Sort = "Active_flag asc";
            //}
            hdnsortcount.Value = "0";
        }

        Session["DtGetBusinessUpdates"] = Dv.ToTable();
        GrdbusinessUpdates.DataSource = Dv;
        GrdbusinessUpdates.DataBind();
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        string[] data = new string[6];
        int pageIndex = GrdbusinessUpdates.PageIndex;
        if (hdnCommandArg.Value != null && hdnCommandArg.Value != "" && hdnCommandArg.Value != "0")
        {
            /*** Code Removed By Suneel ***/
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AssociateLogin.aspx?AID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value) + "&index=" + pageIndex));
        }
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        if (hdnCommandArg.Value != null && hdnCommandArg.Value != "" && hdnCommandArg.Value != "0")
        {
            string UpdateData = "update T_Users set Active_flag=0,User_Status='" + USPDHUBBLL.UtilitiesBLL.Statuses.InActive.ToString() + "' where User_ID=" + Convert.ToInt32(hdnCommandArg.Value) + "";
            SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
            SqlCommand sqlCmd = new SqlCommand(UpdateData, sqlCon);
            int count = sqlCmd.ExecuteNonQuery();
            if (count > 0)
            {
                lblmess.Text = "<font color=green face=arial size=2>Your associate has been deleted successfully.</font>";
                agencyobj.DeletePermissionsByAssociate(Convert.ToInt32(hdnCommandArg.Value));
                FillDatalist();
            }
        }
    }

    protected void rbUpdate_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        Label lnk = (Label)row.FindControl("lblid");
        hdnCommandArg.Value = lnk.Text;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AssociateLogin.aspx"));
    }

    protected void lnkPermissions_Click(object sender, EventArgs e)
    {
        int pageIndex = GrdbusinessUpdates.PageIndex;
        if (hdnCommandArg.Value != null && hdnCommandArg.Value != "" && hdnCommandArg.Value != "0")
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/UserPermissionsNew.aspx?ID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value) + "&index=" + pageIndex));
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
}
