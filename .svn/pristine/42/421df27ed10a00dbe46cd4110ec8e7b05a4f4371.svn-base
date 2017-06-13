using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class EnquiryListings : System.Web.UI.Page
    {
        DataTable dtVerifyListings = new DataTable();
        DataTable dtInProgressListings = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public int SortDir = 0;
        public int pendingCount = 0;
        public int inProgressCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!IsPostBack)
                {
                    hdnsortcount.Value = "0";
                    hdnipsortcount.Value = "0";
                    filldata();
                    if (Session["Message"] != null)
                    {
                        lblmsg.Text = "<font size='3' color='green'>" + Session["Message"].ToString() + "<b></b><font>";
                        Session["Message"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdVerifyListings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVerifyListings.PageIndex = e.NewPageIndex;
            filldata();
        }
        protected void grdInProgressListings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInProgressListings.PageIndex = e.NewPageIndex;
            filldata();
        }
        protected void filldata()
        {
            try
            {
                pnlSerachPending.Visible = true;
                pnlSerachProgress.Visible = true;
                // *** Getting Unverfied listings *** //
                dtVerifyListings = agencyobj.GetVerifyListingDtls(0, "Unverified", ddlVerticalsPending.SelectedValue, ddlCountryPending.SelectedValue);
                pendingCount = dtVerifyListings.Rows.Count;
                if (pendingCount == 0 && ddlVerticalsPending.SelectedValue == "" && ddlCountryPending.SelectedValue == "")
                    pnlSerachPending.Visible = false;
                Session["dtVerifyListings"] = dtVerifyListings;
                grdVerifyListings.DataSource = dtVerifyListings;
                grdVerifyListings.DataBind();
                // *** Getting in progress listings *** //
                dtInProgressListings = agencyobj.GetVerifyListingDtls(0, "", ddlVerticalProgress.SelectedValue, ddlCountryProgress.SelectedValue);
                inProgressCount = dtInProgressListings.Rows.Count;
                if (inProgressCount == 0 && ddlVerticalProgress.SelectedValue == "" && ddlCountryProgress.SelectedValue == "")
                    pnlSerachProgress.Visible = false;
                Session["dtInProgressListings"] = dtInProgressListings;
                grdInProgressListings.DataSource = dtInProgressListings;
                grdInProgressListings.DataBind();

                // *** Gettting Active Verticals *** //
                DataTable dtverticals = agencyobj.GetActiveVerticals();
                ddlVerticalProgress.DataSource = ddlVerticalsPending.DataSource = dtverticals;
                ddlVerticalProgress.DataTextField = "Vertical_Name";
                ddlVerticalProgress.DataValueField = "Vertical_Value";
                ddlVerticalsPending.DataTextField = "Vertical_Name";
                ddlVerticalsPending.DataValueField = "Vertical_Value";
                ddlVerticalProgress.DataBind();
                ddlVerticalsPending.DataBind();
                ddlVerticalsPending.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlVerticalProgress.Items.Insert(0, new ListItem("-- Select --", ""));
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "filldata", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkEdit = (LinkButton)sender as LinkButton;
                int InquiryID = Convert.ToInt32(lnkEdit.CommandArgument);
                if (InquiryID > 0)
                {
                    string urlRedirect = "";
                    DataTable dtVerifyDetails = agencyobj.GetVerifyDetailsById(InquiryID);
                    if (!dtVerifyDetails.Rows[0]["Vertical_Name"].ToString().ToLower().Contains("uspd"))
                    {
                        string username = dtVerifyDetails.Rows[0]["Email_Address"].ToString();
                        string adminDomainName = objCommon.CreateAdminDomain(HttpContext.Current.Request.Url.AbsoluteUri);
                        string userDomainName = objCommon.GetDomainNameByCountryVertical(dtVerifyDetails.Rows[0]["Vertical_Name"].ToString(), dtVerifyDetails.Rows[0]["Country"].ToString());
                        urlRedirect = Page.ResolveClientUrl("~/Admin/CreateFreeAccount.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryID.ToString()));
                        //urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/Checkout/EnhanceSubcription.aspx?InqID=" + EncryptDecrypt.DESEncrypt(InquiryID.ToString()) + "&Type=" + EncryptDecrypt.DESEncrypt("10000") + "&VC=" + EncryptDecrypt.DESEncrypt(userDomainName) + "&Username=" + EncryptDecrypt.DESEncrypt(username) + "&AVC=" + EncryptDecrypt.DESEncrypt(adminDomainName);

                    }
                    else
                        urlRedirect = Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryID.ToString()));
                    Response.Redirect(urlRedirect);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "btnEdit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdVerifyListings_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtVerifyListings = (DataTable)Session["dtVerifyListings"];
                DataView Dv = new DataView(dtVerifyListings);
                if (SortDir == 0)
                {

                    if (SortExp == "CallDate")
                    {
                        Dv.Sort = "Call_Date desc";
                    }

                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "CallDate")
                    {
                        Dv.Sort = "Call_Date ASC";
                    }

                    hdnsortcount.Value = "0";
                }

                Session["dtVerifyListings"] = Dv.ToTable();
                grdVerifyListings.DataSource = Dv;
                grdVerifyListings.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "grdVerifyListings_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdInProgressListings_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnipsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtInProgressListings = (DataTable)Session["dtInProgressListings"];
                DataView Dv = new DataView(dtInProgressListings);
                if (SortDir == 0)
                {

                    if (SortExp == "CallDate")
                    {
                        Dv.Sort = "NextAction_Date desc";
                    }

                    hdnipsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "CallDate")
                    {
                        Dv.Sort = "NextAction_Date ASC";
                    }

                    hdnipsortcount.Value = "0";
                }

                Session["dtInProgressListings"] = Dv.ToTable();
                grdInProgressListings.DataSource = Dv;
                grdInProgressListings.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "grdInProgressListings_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkdel = sender as LinkButton;
                int listingID = Convert.ToInt32(lnkdel.CommandArgument.ToString());
                agencyobj.DeleteSelectedListing(listingID);
                lblmsg.Text = "<font size='3' color='green'>" + Resources.AdminResource.ListingDeleteSuccess + "<b></b><font>";
                filldata();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "<font size='3' color='red'>An error occured while deleting the selected listing. Please contact technical person.<b></b><font>";

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "lnkDelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnSearchProgress_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSerachProgress.Visible = true;
                // *** Getting in progress listings *** //
                dtInProgressListings = agencyobj.GetVerifyListingDtls(0, "", ddlVerticalProgress.SelectedValue, ddlCountryProgress.SelectedValue);
                inProgressCount = dtVerifyListings.Rows.Count;
                Session["dtInProgressListings"] = dtInProgressListings;
                grdInProgressListings.DataSource = dtInProgressListings;
                grdInProgressListings.DataBind();
                if (inProgressCount == 0)
                {
                    Label lblNoProgress = (Label)grdInProgressListings.Controls[0].Controls[0].FindControl("lblBUempty");
                    if (lblNoProgress != null)
                        lblNoProgress.Text = "There are no in progress verifications at this time for selected vertical and country.";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "btnSearchProgress_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSearchPending_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSerachPending.Visible = true;
                // *** Getting Unverfied listings *** //
                dtVerifyListings = agencyobj.GetVerifyListingDtls(0, "Unverified", ddlVerticalsPending.SelectedValue, ddlCountryPending.SelectedValue);
                pendingCount = dtVerifyListings.Rows.Count;
                Session["dtVerifyListings"] = dtVerifyListings;
                grdVerifyListings.DataSource = dtVerifyListings;
                grdVerifyListings.DataBind();
                if (pendingCount == 0)
                {
                    Label lblNoPending = (Label)grdVerifyListings.Controls[0].Controls[0].FindControl("lblBUempty");
                    if (lblNoPending != null)
                        lblNoPending.Text = "There are no pending verifications at this time for selected vertical and country.";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryListings.aspx.cs", "btnSearchPending_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
    }
}