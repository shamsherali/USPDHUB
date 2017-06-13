using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class SelectBulletin : BaseWeb
    {
        public string RootPath = "";
        public int UserID = 0;
        public int CUserID = 0;
        public int ProfileID = 0;
        BulletinBLL objBulletin = new BulletinBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmess.Text = "";
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                RootPath = Session["RootPath"].ToString();
                if (!IsPostBack)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel2.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create content.</font>";
                        }
                    }
                    //ends here
                    hdnrow.Value = "111";
                    hdnrowindex.Value = "1";
                    CommonBLL objCommonBll = new CommonBLL();
                    DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(Session["VerticalDomain"].ToString(), "EmailAccounts");
                    if (dtConfigs.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigs.Rows)
                        {
                            if (row[0].ToString() == "EmailSupport")
                                hdnSupport.Value = row[1].ToString();
                        }
                    }
                    FillCategoryTemplate("111");
                    ShowRemoveFavorites();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void FillCategoryGrid()
        {
            try
            {
                DataTable dtFavCategories = new DataTable();
                dtFavCategories = objBulletin.GetFavoriteCategories(UserID);
                dtFavCategories.Clear();
                DataRow Dr = dtFavCategories.NewRow();
                Dr["Category"] = "All Categories";
                Dr["Category_ID"] = "0";
                dtFavCategories.Rows.InsertAt(Dr, 0);
                //For all Categories maintain categoryId as 0 and MyFavorites maintain categoryId as 111
                DataRow Dr1 = dtFavCategories.NewRow();
                Dr1["Category"] = "My Favorites";
                Dr1["Category_ID"] = "111";
                dtFavCategories.Rows.InsertAt(Dr1, 111);
                GrdCategory.DataSource = dtFavCategories;
                GrdCategory.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "FillCategoryGrid", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void FillCategoryTemplate(string CategoryID)
        {
            try
            {
                if (CategoryID == "0")
                {
                    DLAllCategory.Style.Add("display", "block");
                    DLMyFavorites.Style.Add("display", "none");
                    DataSet dsBulletins = new DataSet();
                    dsBulletins = objBulletin.GetAllCategoryTemplates(UserID);
                    if (dsBulletins.Tables[0].Rows.Count > 0)
                    {
                        dsBulletins.Tables[0].TableName = "Categories";
                        dsBulletins.Tables[1].TableName = "Templates";
                        dsBulletins.Relations.Add("children", dsBulletins.Tables["Categories"].Columns["Category_ID"], dsBulletins.Tables["Templates"].Columns["Category_ID"], true);
                        DLAllCategory.DataSource = dsBulletins;
                        DLAllCategory.DataBind();
                    }
                }
                else if (CategoryID == "111")
                {
                    DLMyFavorites.Style.Add("display", "block");
                    DLAllCategory.Style.Add("display", "none");
                    DataTable dtMyFav = new DataTable();
                    dtMyFav = objBulletin.GetFavoriteBulletins(UserID, 0);
                    if (dtMyFav.Rows.Count == 0)
                    {
                        DataTable dtBlankTemplate = new DataTable();
                        dtBlankTemplate = objBulletin.GetBulletinBlankTemplateDetails(ProfileID.ToString());
                        int blankTempID = Convert.ToInt32(dtBlankTemplate.Rows[0]["Template_BID"].ToString());
                        objBulletin.AddFavoriteTemplate(ProfileID, UserID, CUserID, blankTempID, "");
                        dtMyFav = objBulletin.GetFavoriteBulletins(UserID, 1);
                    }

                    DLMyFavorites.DataSource = dtMyFav;
                    DLMyFavorites.DataBind();
                }
                FillCategoryGrid();
                if (GrdCategory.Rows.Count > 0)
                {
                    RadioButton rb = (RadioButton)GrdCategory.Rows[Convert.ToInt32(hdnrowindex.Value)].FindControl("rbBulletin");
                    rb.Checked = true;
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "FillCategoryTemplate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowRemoveFavorites()
        {
            try
            {
                hdnIsRemove.Value = "false";
                DataSet dtCategorires = objBulletin.GetRemoveFavoritesList(UserID);
                if (dtCategorires.Tables[0].Rows.Count > 0)
                {
                    hdnIsRemove.Value = "true";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "ShowRemoveFavorites", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DLAllCategory_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList formDataList = e.Item.FindControl("rptTest") as DataList;
                if (formDataList != null)
                {
                    formDataList.DataSource = drv.CreateChildView("children");
                    formDataList.DataBind();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "DLAllCategory_ItemDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnktemplatename_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)lnk.NamingContainer;
            hdnrowindex.Value = row.RowIndex.ToString();
            hdnrow.Value = lnk.CommandArgument;
            lnk.ForeColor = System.Drawing.Color.Green;
            FillCategoryTemplate(lnk.CommandArgument);
        }
        protected void GrdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkbtn = e.Row.FindControl("lnktemplatename") as LinkButton;
                    if (lnkbtn.CommandArgument == hdnrow.Value)
                    {
                        e.Row.CssClass = "Llink";
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "GrdCategory_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void rbBulletin_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            hdnrowindex.Value = row.RowIndex.ToString();
            LinkButton lnk = (LinkButton)row.FindControl("lnktemplatename");
            hdnrow.Value = lnk.CommandArgument;
            FillCategoryTemplate(lnk.CommandArgument);
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnSelect = sender as LinkButton;
                if (Txttemplatename.Text.Trim() != "")
                {
                    DataTable dtBulletin = objBulletin.CheckBulletin(UserID, Txttemplatename.Text.Trim(), Convert.ToInt32(btnSelect.CommandArgument.ToString()), "Check"); // *** Check means user tries to create new bulletin *** //
                    if (dtBulletin.Rows.Count > 0)
                    {
                        string RedirectUrl = string.Empty;
                        Session["TemplateBID"] = btnSelect.CommandArgument.ToString();
                        Session["BulletinName"] = Txttemplatename.Text.Trim();
                        Session["BulletinID"] = "0";
                        Session["BulletinCategoryName"] = dtBulletin.Rows[0]["BulletinCategoryName"];

                        bool IsUserForms = false;
                        if (String.Equals(Convert.ToString(dtBulletin.Rows[0]["IsUserForms"]), "true", StringComparison.OrdinalIgnoreCase))
                        {
                            IsUserForms = true;
                        }
                        string userFormsUrl = "";
                        if (IsUserForms)
                        {
                            if (RootPath.ToLower().Contains("localhost"))
                            {
                                //For Local RootPath
                                userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                    + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&TempID=" + EncryptDecrypt.DESEncrypt(btnSelect.CommandArgument.ToString()) + "&BName=" + EncryptDecrypt.DESEncrypt(Session["BulletinName"].ToString()) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                            }
                            else
                            {
                                //For Test RootPath
                                userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                 + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&TempID=" + EncryptDecrypt.DESEncrypt(btnSelect.CommandArgument.ToString()) + "&BName=" + EncryptDecrypt.DESEncrypt(Session["BulletinName"].ToString()) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                            }

                            RedirectUrl = Page.ResolveClientUrl(userFormsUrl);
                        }
                        else
                        {
                            if (Convert.ToBoolean(dtBulletin.Rows[0]["IsUrl"].ToString()))
                                RedirectUrl = Page.ResolveClientUrl("~" + dtBulletin.Rows[0]["Template"].ToString());
                            else
                                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin2.aspx?BulletinID=0");
                        }
                        Response.Redirect(RedirectUrl);
                    }
                    else
                        lblmess.Text = "Sorry, you already have a bulletin with this name; please enter another name.";
                }
                else
                    lblmess.Text = Resources.LabelMessages.ItemTitleEmpty;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "btnSelect_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
        }
        protected void lnkAddFavourite_Click(object sebder, EventArgs e)
        {
            ShowAvailableFavorites();
        }
        private void ShowAvailableFavorites()
        {
            try
            {
                hdnSelItems.Value = "";
                DataSet dtCategorires = objBulletin.GetAvailableFavorites(UserID);
                if (dtCategorires.Tables[0].Rows.Count > 0)
                {
                    dtCategorires.Tables[0].TableName = "Categories";
                    dtCategorires.Tables[1].TableName = "Templates";
                    lblHeading.Text = "Add Favorites";
                    btnAddFavorites.Text = "Add";
                    MPETemplates.Show();
                    dtCategorires.Relations.Add("children", dtCategorires.Tables["Categories"].Columns["Category_ID"], dtCategorires.Tables["Templates"].Columns["Category_ID"], true);
                    DLFavCategories.DataSource = dtCategorires;
                    DLFavCategories.DataBind();
                }
                else
                    lblerrormessage.Text = Resources.LabelMessages.NoAddFavoritesAvailable;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "ShowAvailableFavorites", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DLFavCategories_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            DataList formDataList = e.Item.FindControl("DLFavourites") as DataList;
            if (formDataList != null)
            {
                formDataList.DataSource = drv.CreateChildView("children");
                formDataList.DataBind();
            }
        }
        protected void btnAddFavorites_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnSelItems.Value.Trim() != "")
                {
                    string selfavorites = hdnSelItems.Value.Trim().TrimEnd(',');
                    string[] strFavTempId = selfavorites.Split(',');
                    if (btnAddFavorites.Text == "Add")
                    {
                        for (int i = 0; i < strFavTempId.Length; i++)
                        {
                            objBulletin.AddFavoriteTemplate(ProfileID, UserID, CUserID, Convert.ToInt32(strFavTempId[i]), "");
                        }
                        lblmess.Text = Resources.LabelMessages.AddFavoriteSuccess;
                    }
                    if (btnAddFavorites.Text == "Remove")
                    {
                        for (int i = 0; i < strFavTempId.Length; i++)
                        {
                            objBulletin.RemoveFavoriteTemplate(Convert.ToInt32(strFavTempId[i]));
                        }
                        lblmess.Text = Resources.LabelMessages.RemoveFavoriteSuccess;
                    }
                    ShowRemoveFavorites();
                }
                hdnrowindex.Value = "1";
                hdnrow.Value = "111";
                MPETemplates.Hide();
                FillCategoryTemplate("111");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "btnAddFavorites_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkRemoveFavourite_Click(object sebder, EventArgs e)
        {
            ShowRemoveFavoritesList();
        }
        private void ShowRemoveFavoritesList()
        {
            try
            {
                hdnSelItems.Value = "";
                DataSet dtCategorires = objBulletin.GetRemoveFavoritesList(UserID);
                if (dtCategorires.Tables[0].Rows.Count > 0)
                {
                    dtCategorires.Tables[0].TableName = "Categories";
                    dtCategorires.Tables[1].TableName = "Templates";
                    lblHeading.Text = "Remove Favorites";
                    btnAddFavorites.Text = "Remove";
                    MPETemplates.Show();
                    dtCategorires.Relations.Add("children", dtCategorires.Tables["Categories"].Columns["Category_ID"], dtCategorires.Tables["Templates"].Columns["Category_ID"], true);
                    DLFavCategories.DataSource = dtCategorires;
                    DLFavCategories.DataBind();
                }
                else
                    lblmess.Text = Resources.LabelMessages.NoRemoveFavoritesAvailable;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletin.aspx.cs", "ShowRemoveFavoritesList", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}