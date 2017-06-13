using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Configuration;
using System.Data;

namespace USPDHUB.Admin
{
    public partial class ManageRequestCustomForms : System.Web.UI.Page
    {
        DataTable dtRequestCustomForms = new DataTable();
        BusinessBLL objBusinessBLL = new BusinessBLL();
        public string RootPath = "";

        AdminBLL objAdmin = new AdminBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";

                RootPath = Session["RootPath"].ToString();
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!IsPostBack)
                {
                    FillData();
                    if (Request.QueryString["MSG"] != null)
                    {
                        if (Convert.ToString(Request.QueryString["MSG"]) != string.Empty)
                        {
                            lblmsg.Text = "<font color='green' ><b>Requested details have been updated successfully.</b></font>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageRequestCustomForms.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FillData()
        {
            try
            {
                dtRequestCustomForms = objBusinessBLL.GetAllRFPCustomForm();
                grdRequests.DataSource = dtRequestCustomForms;
                grdRequests.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageRequestCustomForms.aspx.cs", "FillData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkPreview = (LinkButton)sender as LinkButton;
                int RFPID = Convert.ToInt32(lnkPreview.CommandArgument);
                DataTable dtRFPDetails = objBusinessBLL.GetRFP_CustomDetailsByID(RFPID);



                string previewHTML = Convert.ToString(dtRFPDetails.Rows[0]["Request_HTML"]);
                //10006 for Request Custom Module
                if (dtRFPDetails.Rows[0]["Request_Type"].ToString() == "10006")
                { previewHTML = previewHTML = previewHTML.Replace("Request Custom Form", "Request Custom Module"); }


                var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(dtRFPDetails.Rows[0]["ProfileID"]));
                previewHTML = previewHTML.Replace("#ProfileName#", Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"]));
                lblspreview.Text = previewHTML;
                popupPreview.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageRequestCustomForms.aspx.cs", "btnPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                CommonBLL objCommon = new CommonBLL();
                LinkButton lnkEdit = (LinkButton)sender as LinkButton;

                string[] commandArgs = lnkEdit.CommandArgument.ToString().Split(new char[] { ',' });
                int RFPID = Convert.ToInt32(commandArgs[0]);
                int SubcriptionID = Convert.ToInt32(commandArgs[1]);

                if (RFPID > 0)
                {
                    string adminDomainName = objCommon.CreateAdminDomain(HttpContext.Current.Request.Url.AbsoluteUri);
                    string rootPath = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath");
                    string redirectUrl = rootPath + "/RedirectPage.aspx?RFPID=" + EncryptDecrypt.DESEncrypt(RFPID.ToString()) + "&SCID=" + EncryptDecrypt.DESEncrypt(SubcriptionID.ToString()) + "&AVC=" + EncryptDecrypt.DESEncrypt(adminDomainName);
                    Response.Redirect(redirectUrl);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageRequestCustomForms.aspx.cs", "btnEdit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void grdRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRequests.PageIndex = e.NewPageIndex;
            FillData();
        }

    }
}