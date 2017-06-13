using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using USPDHUBBLL;

namespace USPDHUB.Business
{
    public partial class SelectBulletinOld : BaseWeb
    {
        public string RootPath = "";
        public int UserID = 0;
        public int ProfileID = 0;
        BulletinBLL objBulletin = new BulletinBLL();
        CommonBLL objCommon = new CommonBLL();
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmess.Text = "";
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
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

                    hdnrow.Value = "0";
                    hdnrowindex.Value = "0";
                    GetBulletins("0"); // *** 0 means get all bulletins *** //
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
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void FillCategoryGrid()
        {
            try
            {
                DataTable DtBulletinCategory = new DataTable();
                DtBulletinCategory = objBulletin.GetBulletinCategories(UserID, "");
                DataRow[] customforms = DtBulletinCategory.Select("IsCustom='true'");
                if (customforms.Length == 0)
                {
                    DataRow drCustom = DtBulletinCategory.NewRow();
                    drCustom["Category"] = "Custom Forms";
                    drCustom["Category_ID"] = "3";
                    DtBulletinCategory.Rows.Add(drCustom);
                }
                if (DtBulletinCategory.Rows.Count > 1)
                {
                    DataRow Dr = DtBulletinCategory.NewRow();
                    Dr["Category"] = "All Categories";
                    Dr["Category_ID"] = "0";
                    DtBulletinCategory.Rows.InsertAt(Dr, 0);
                }

                GrdCategory.DataSource = DtBulletinCategory;
                GrdCategory.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "FillCategoryGrid", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnktemplatename_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = sender as LinkButton;
                GridViewRow row = (GridViewRow)lnk.NamingContainer;
                hdnrowindex.Value = row.RowIndex.ToString();
                hdnrow.Value = lnk.CommandArgument;
                lnk.ForeColor = System.Drawing.Color.Green;
                GetBulletins(lnk.CommandArgument);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "lnktemplatename_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
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
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "GrdCategory_RowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void rbBulletin_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = (RadioButton)sender;
                GridViewRow row = (GridViewRow)rb.NamingContainer;
                hdnrowindex.Value = row.RowIndex.ToString();
                LinkButton lnk = (LinkButton)row.FindControl("lnktemplatename");
                hdnrow.Value = lnk.CommandArgument;
                GetBulletins(lnk.CommandArgument);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "rbBulletin_CheckedChanged", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetBulletins(string CategoryID)
        {
            try
            {

                DataTable DtBulletins = new DataTable();
                DtBulletins = objBulletin.GetBulletins(UserID, Convert.ToInt32(CategoryID), "");
                rptTest.DataSource = DtBulletins;
                rptTest.DataBind();
                FillCategoryGrid();
                if (CategoryID == "3" && DtBulletins.Rows.Count == 0)
                    pnlCustom.Visible = true;
                else if (CategoryID == "3" && DtBulletins.Rows.Count > 0)
                    pnlCustomLeft.Visible = true;
                else
                {
                    pnlCustom.Visible = false;
                    pnlCustomLeft.Visible = false;
                }
                RadioButton rb = (RadioButton)GrdCategory.Rows[Convert.ToInt32(hdnrowindex.Value)].FindControl("rbBulletin");
                rb.Checked = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "GetBulletins", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnSelect = sender as LinkButton;
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

                    if (IsUserForms)
                    {
                        //For Test RootPath
                        string userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                           + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))
                           + "&TempID=" + EncryptDecrypt.DESEncrypt(btnSelect.CommandArgument.ToString()) + "&BName=" + EncryptDecrypt.DESEncrypt(Session["BulletinName"].ToString());

                        //For Local RootPath
                        //string userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                        //  + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))
                        //  + "&TempID=" + EncryptDecrypt.DESEncrypt(btnSelect.CommandArgument.ToString()) + "&BName=" + EncryptDecrypt.DESEncrypt(Session["BulletinName"].ToString());


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
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SelectBulletinOld.aspx.cs", "btnSelect_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
        }
    }
}