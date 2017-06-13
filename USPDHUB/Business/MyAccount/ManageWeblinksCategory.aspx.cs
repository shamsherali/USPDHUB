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
    public partial class ManageWeblinksCategory : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";
        public int SortDir = 0;

        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();

        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string Permission_Type = string.Empty;
        public int Permission_Value = 0;

        public DataTable dtWeblinksCategories = new DataTable();

        DataTable DtWebLinks = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                lblmess.Text = "";
                lblerrormessage.Text = "";
                if (!IsPostBack)
                {
                    //  Hdn control for Sorting
                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";

                    GetManageWeblinksCategories();

                    if (Session["Success"] != null)
                    {
                        lblmess.Text = Session["Success"].ToString();
                        Session.Remove("Success");
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetManageWeblinksCategories()
        {
            try
            {
                hdnCommandArg.Value = "";
                dtWeblinksCategories = objBus.GetManageWeblinkCategories(ProfileID);
                GrdWeblinksCategories.DataSource = dtWeblinksCategories;
                GrdWeblinksCategories.DataBind();

                Session["dtWeblinksCategories"] = dtWeblinksCategories;
                hdnShowButtons.Value = "1";

                if (dtWeblinksCategories.Rows.Count == 0)
                    hdnShowButtons.Value = "";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "GetManageWeblinksCategories", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdWeblinksCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtWeblinksCategories = (DataTable)Session["dtWeblinksCategories"];
                GrdWeblinksCategories.PageIndex = e.NewPageIndex;
                GrdWeblinksCategories.DataSource = dtWeblinksCategories;
                GrdWeblinksCategories.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "GrdWeblinksCategories_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdWeblinksCategories_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtWeblinksCategories = (DataTable)Session["dtWeblinksCategories"];
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
                DataView Dv = new DataView(dtWeblinksCategories);
                if (SortDir == 0)
                {
                    if (SortExp == "Category_Name")
                    {
                        Dv.Sort = "Category_Name desc";
                    }
                    else if (SortExp == "Created_Date")
                    {
                        Dv.Sort = "Created_Date desc";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "Category_Name")
                    {
                        Dv.Sort = "Category_Name ASC";
                    }
                    else if (SortExp == "Created_Date")
                    {
                        Dv.Sort = "Created_Date ASC";
                    }
                    hdnsortcount.Value = "0";
                }
                Session["dtWeblinksCategories"] = Dv.ToTable();
                GrdWeblinksCategories.DataSource = Dv;
                GrdWeblinksCategories.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "GrdWeblinksCategories_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageWebLinks.aspx"));
        }

        protected void rbWeblinkCategory_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnkTitle = (LinkButton)row.FindControl("lnkName");
            hdnCommandArg.Value = lnkTitle.CommandArgument;
        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        { //Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/EditWeblinkCategory.aspx"));
            lblmess.Text = "";
            hdnCommandArg.Value = "0";
            txtCategoryName.Text = "";
            lbleditext.Text = "";
            mpeWebLink.Show();
        }

        protected void lnkName_Click(object sender, EventArgs e)
        {
            LinkButton lnkWeblinkCategory = sender as LinkButton;
            LoadWebLinks(lnkWeblinkCategory.CommandArgument);
            MPECategory.Show();
            //ShowPreview(lnkTitle.CommandArgument, lnkTitle.Text);
        }

        private void LoadWebLinks(string lnkWeblinkCategory)
        {
            try
            {
                int lnkWeblinkCategory_ID = Convert.ToInt32(lnkWeblinkCategory);
                DtWebLinks = objBus.GetWebLinksByCategoryID(lnkWeblinkCategory_ID);
                Session["DtWebLinks"] = DtWebLinks;
                WebLinkGrid.DataSource = DtWebLinks;
                WebLinkGrid.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "LoadWebLinks", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                GetWeblinkCategoryDetails();
                //string RedirectUrl = string.Empty;
                //RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditWeblinkCategory.aspx?ID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value));
                //Response.Redirect(RedirectUrl);
            }
        }

        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            try
            {
                objBus.DeleteWeblinkCategory(Convert.ToInt32(hdnCommandArg.Value));

                hdnCommandArg.Value = "";
                GetManageWeblinksCategories();
                lblmess.Text = "<font size='3'>Your category has been deleted successfully.</font>";
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinksCategory", "Delete");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "lnkdelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        // Modal Popup Events


        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                lbleditext.Text = "";

                int result = objBus.Insert_Update_WeblinksCategory(Convert.ToInt32(hdnCommandArg.Value), txtCategoryName.Text.Trim(), UserID, ProfileID);

                if (result == -1)
                {
                    lbleditext.Text = "Sorry, you already have a web link category with this name; please enter another name.";
                    mpeWebLink.Show();
                }
                else
                {
                    if (Convert.ToInt32(hdnCommandArg.Value) == 0)
                    {
                        lblmess.Text = "Web link category has been saved successfully.";
                        objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinksCategory", "Create");
                    }
                    else
                    {
                        lblmess.Text = "Web link category has been updated successfully.";
                        objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinksCategory", "Update");
                    }
                    GetManageWeblinksCategories();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "btnSumbit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            //Session["UpdateSuccess"] = "Update has been updated successfully.";
        }

        private void GetWeblinkCategoryDetails()
        {
            try
            {
                lblmess.Text = "";
                lbleditext.Text = "";

                mpeWebLink.Show();
                var dtDetails = objBus.GetWeblinkCategoryDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
                txtCategoryName.Text = Convert.ToString(dtDetails.Rows[0]["Category_Name"]);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "GetWeblinkCategoryDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ImcloseClick(object sender, ImageClickEventArgs e)
        {

        }
    }
}