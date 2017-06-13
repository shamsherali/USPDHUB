using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;


namespace USPDHUB.Admin
{
    public partial class AdditionalBrandedRequestsPopUp : System.Web.UI.Page
    {
        AdminBLL objAdmin = new AdminBLL();
        public string RootPath = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RootPath = Session["RootPath"].ToString();
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequestsPopUp.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        public void BindGrid()
        {
            try
            {
                int UserID = 0;
                int BrandedApp_OrderId = 0;
                if (Session["BrandedApp_OrderId"] != null)
                {
                    BrandedApp_OrderId = Convert.ToInt32(Session["BrandedApp_OrderId"].ToString());
                    DataTable dtAddRequests = objAdmin.GetBrandedAppAdditionalRequest(BrandedApp_OrderId);
                    if (dtAddRequests.Rows.Count > 0)
                    {
                        DataTable dtBrandedAppDetails = new DataTable();
                        BusinessBLL objBusinessBLL = new BusinessBLL();

                        dtBrandedAppDetails = objBusinessBLL.GetBrandedAppOrderStatusDetails(BrandedApp_OrderId);
                        if (dtBrandedAppDetails.Rows.Count > 0)
                        {
                            UserID = Convert.ToInt32(dtBrandedAppDetails.Rows[0]["UserID"].ToString());
                            AppName.Text = dtBrandedAppDetails.Rows[0]["App_DisplayName"].ToString();
                        }
                        grdDetails.DataSource = dtAddRequests;
                        grdDetails.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "redirect", "window.parent.location='AdditionalBrandedRequests.aspx'", true);
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequestsPopUp.aspx.cs", "BindGrid", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblreqDetails = e.Row.FindControl("lblreqDetails") as Label;
                    Label lblPID = e.Row.FindControl("lblPID") as Label;
                    int PID = Convert.ToInt32(lblPID.Text);
                    string requestDetails = lblreqDetails.Text;

                    Label lblAppIcon = e.Row.FindControl("lblAppIcon") as Label;
                    if (lblAppIcon.Text.Trim() != string.Empty)
                    {
                        string appIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\AdditionalBrandedAppRequestIcons\\" + PID + "\\" + lblAppIcon.Text;
                        if (File.Exists(appIconPath))
                        {
                            requestDetails = requestDetails.Replace("####", "<IMG width='100px' SRC='" + RootPath + "/Upload/AdditionalBrandedAppRequestIcons/" + PID + "/" + lblAppIcon.Text + "'  />");
                        }
                    }

                    Label lblBackgroundIcon = e.Row.FindControl("lblBackgroundIcon") as Label;
                    if (lblBackgroundIcon.Text.Trim() != string.Empty)
                    {
                        requestDetails = requestDetails.Replace("@@@@", "<IMG width='100px' SRC='" + RootPath + "/Upload/AdditionalBrandedAppRequestIcons/" + PID + "/" + lblBackgroundIcon.Text + "'  />");
                    }


                    requestDetails = requestDetails.Replace("####", "");
                    requestDetails = requestDetails.Replace("@@@@", "");

                    lblreqDetails.Text = requestDetails;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequestsPopUp.aspx.cs", "grdDetails_OnRowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdDetails_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdDetails.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequestsPopUp.aspx.cs", "grdDetails_PageIndexChanging", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}