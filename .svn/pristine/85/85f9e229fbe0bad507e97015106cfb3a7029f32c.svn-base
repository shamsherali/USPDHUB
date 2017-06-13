using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using USPDHUBBLL;
using System.Data;
using System.IO;
using System.Web.Services;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageWebLinks : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public string eZSmartSiteURL = string.Empty;
        BusinessBLL busObj = new BusinessBLL();
        DataTable DtWebLinks = new DataTable();
        public int C_UserID = 0;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        public DataTable dtUserDetails = new DataTable();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBranded = false;
        public bool IsBlockedSendAccess = true;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string DomainName = "";
        public string titleName = "";
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();

        public int WebLinksCategoryID = 0;
        public DataTable dtWeblinksCategories = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Chcking for user session ***
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    UserID = Convert.ToInt32(Session["UserID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }

                DomainName = Session["VerticalDomain"].ToString();
                titleName = objApp.GetMobileAppSettingTabName(UserID, "WebLinks", DomainName);
                lblTitle.Text = titleName;

                if (!IsPostBack)
                {
                    lblOff.Visible = true;
                    if (objCommon.DisplayOn_OffSettingsContent(UserID, "WebLinks"))
                    {
                        lblOn.Visible = true;
                        lblOff.Visible = false;
                    }

                    //RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, "WebLinks");
                    RBAppOrder.SelectedValue = "2";

                    DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        IsParent = false;

                    if (Convert.ToBoolean(dtProfiles.Rows[0]["IsBranded_App"].ToString()))
                        IsBranded = true;



                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                    }
                    //roles & permissions..
                    //USPD-1107 Permission related Changes
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                        //hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                        hdnWebLinksPermission.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "WebLinks");
                        //if (hdnPermissionType.Value == "A" || string.IsNullOrEmpty(hdnPermissionType.Value))
                        if (string.IsNullOrEmpty(hdnWebLinksPermission.Value))
                        {
                            btnAddNew.Enabled = WebLinkGrid.Enabled = false;
                            lblSuccess.Text = "<font face=arial size=2 color=red>You do not have permission to access web links.</font>";
                        }
                    }
                    //ends here

                    LoadWebLinks();
                    LoadWeblinksCategories();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void LoadWebLinks()
        {
            try
            {
                DtWebLinks = busObj.GetWebLinks(ProfileID);
                Session["DtWebLinks"] = DtWebLinks;
                WebLinkGrid.DataSource = DtWebLinks;
                WebLinkGrid.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "LoadWebLinks", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void LoadWeblinksCategories()
        {
            try
            {
                dtWeblinksCategories = objBus.GetWeblinksCategories(ProfileID);
                ddlCategory.DataSource = dtWeblinksCategories;
                ddlCategory.DataValueField = "WeblinkCategory_ID";
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem { Text = "--Select--", Value = "0" });
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "LoadWeblinksCategories", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void WebLinkGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DtWebLinks = (DataTable)Session["DtWebLinks"];
                WebLinkGrid.PageIndex = e.NewPageIndex;
                WebLinkGrid.DataSource = DtWebLinks;
                WebLinkGrid.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "WebLinkGrid_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void WebLinkGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.CompareTo("Delete") == 0)//Update Process
                {
                    int LinkID = Convert.ToInt32(e.CommandArgument);
                    //Delete Process.
                    WebLinksCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    busObj.CreateWebLinks(LinkID, string.Empty, string.Empty, UserID, C_UserID, 1, ProfileID, WebLinksCategoryID);
                    lblSuccess.Text = "<font size='2' color='green'>Web link has been deleted successfully.</font>";
                    busObj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinks", "Delete");
                    LoadWebLinks();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "WebLinkGrid_RowCommand", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void WebLinkGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
                LinkButton lnkEdit = (LinkButton)sender as LinkButton;
                int SalePID = Convert.ToInt32(lnkEdit.CommandArgument);
                DataTable dtSP = busObj.GetWebLinksById(SalePID);
                if (dtSP.Rows.Count == 1)
                {
                    txtTitleName.Text = dtSP.Rows[0]["Link_Title"].ToString();
                    txtlinkUrl.Text = dtSP.Rows[0]["Link_Url"].ToString();
                    if (txtTitleName.Text.Length > 0)
                        lblLength.Text = Convert.ToString(30 - txtTitleName.Text.Length);
                    hdnSPID.Value = SalePID.ToString();
                    if (txtlinkUrl.Text == null || txtlinkUrl.Text == "")
                        txtlinkUrl.Text = "http://";
                    mpeWebLink.Show();
                    if (hdnSPID.Value != "")
                        btnSumbit.Text = "Update";
                    if (Convert.ToString(dtSP.Rows[0]["Category_ID"]) != string.Empty)
                    {
                        if (ddlCategory.Items.FindByValue(Convert.ToString(dtSP.Rows[0]["Category_ID"])) != null)
                        {
                            ddlCategory.SelectedValue = Convert.ToString(dtSP.Rows[0]["Category_ID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "lnkEdit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearValues();
            txtTitleName.Focus();
            txtlinkUrl.Text = "http://";
            lblLength.Text = "30";
            mpeWebLink.Show();
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitleName.Text.Trim() != "" && txtlinkUrl.Text.Trim() != "")
                {
                    WebLinksCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    string TitleName = txtTitleName.Text.Trim();
                    string linkUrl = txtlinkUrl.Text.Trim();
                    int ID = 0;
                    if (hdnSPID.Value != "")
                        ID = Convert.ToInt32(hdnSPID.Value);

                    int _id = busObj.CreateWebLinks(ID, TitleName, linkUrl, UserID, C_UserID, 0, ProfileID, WebLinksCategoryID);
                    if (_id > 0)
                    {
                        if (ID == 0)
                        {
                            lblSuccess.Text = "<font size='2' color='green'>Web link has been added successfully.</font>";
                            busObj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinks", "Create");
                        }
                        else
                        {
                            lblSuccess.Text = "<font size='2' color='green'>Web link has been updated successfully.</font>";
                            busObj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinks", "Update");
                        }
                        LoadWebLinks();
                        mpeWebLink.Hide();
                    }
                }
                else
                    mpeWebLink.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "btnSumbit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void ClearValues()
        {
            lblLength.Text = txtTitleName.Text = "";
            lblSuccess.Text = txtlinkUrl.Text = "";
            hdnSPID.Value = "0";
            btnSumbit.Text = "Add";
        }

        protected void WebLinkGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnEdit = e.Row.FindControl("lnkEdit") as ImageButton;
                ImageButton btnDelete = e.Row.FindControl("lnkDelete") as ImageButton;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    //if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    if (string.IsNullOrEmpty(hdnWebLinksPermission.Value))
                        btnEdit.Enabled = btnDelete.Enabled = false;
                }
            }
        }

        protected void btnWeblinkCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageWeblinksCategory.aspx"));
        }
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void btnChangeOrder_click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtobj = new DataTable();
                lbl2.Text = string.Empty;
                dtobj = busObj.GetWebLinksByUserID(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    OrderListView.DataSource = null;
                    OrderListView.DataSource = dtobj;
                    OrderListView.DataBind();
                    ModalPopupWebLinkOrderNo.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowOrderScript();", true);
                }
                else
                    lblSuccess.Text = "<font color=red face=arial size=2><b>You have no item(s) to change the order.</b></font>";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "btnChangeOrder_click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                throw new Exception(ex.Message);
            }
        }
        protected void btnUpdateImgOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (OrderListView.Items.Count > 0)
                {
                    for (int i = 0; i < OrderListView.Items.Count; i++)
                    {
                        Label lblKey = OrderListView.Items[i].FindControl("lblKey") as Label;
                        busObj.UpdateWebLinksOrder(Convert.ToInt32(lblKey.Text), i + 1, C_UserID);
                    }
                    lblSuccess.Text = "<font color=green face=arial size=2><b>The order has been updated successfully.</b></font>";
                    LoadWebLinks();
                    ModalPopupWebLinkOrderNo.Hide();

                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "btnUpdateImgOrderNumber_Click", ex.Message,
              Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                throw new Exception(ex.Message);
            }
        }
        protected void btnCancelImgOrderNumber_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
        }
        protected void OrderListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //Label lblOrderThumb;
            Label lblKey;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //lblOrderThumb = (Label)e.Item.FindControl("lblOrderThumb");
                lblKey = (Label)e.Item.FindControl("lblKey");

                //if (File.Exists(Server.MapPath("~") + "\\Upload\\Surveys\\" + ProfileID.ToString() + "\\" + lblKey.Text + ".jpg"))
                //    lblOrderThumb.Text = "<img src='" + RootPath + "/Upload/Surveys/" + ProfileID.ToString() + "/" + lblKey.Text + ".jpg?Guid=" + ImageDisID + "' border='1' width='50' height='20'/>";
                //else
                //    lblOrderThumb.Text = "";
            }
        }
        [WebMethod]
        public static string UpdateItemsOrder(string itemOrder)
        {
            string _result = "failed";
            try
            {
                BusinessBLL busObj = new BusinessBLL();
                if (itemOrder.Length > 0)
                {
                    if (HttpContext.Current.Session["UserID"] != null)
                    {
                        int CUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                        if (HttpContext.Current.Session["C_USER_ID"] != null && HttpContext.Current.Session["C_USER_ID"].ToString() != "")
                            CUserID = Convert.ToInt32(HttpContext.Current.Session["C_USER_ID"]);
                        string[] strWebLinksOrder = itemOrder.Split(',');
                        for (int i = 0; i < strWebLinksOrder.Length; i++)
                        {
                            busObj.UpdateWebLinksOrder(Convert.ToInt32(strWebLinksOrder[i]), i + 1, CUserID);
                        }
                    }

                }
                _result = "success";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "ManageWebLinks.aspx.cs", "UpdateItemsOrder", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return _result;
        }
        protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedOrderType = Convert.ToInt32(RBAppOrder.SelectedValue);

            //objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"]), selectedOrderType, "Bulletins");
            objCommon.UpdateDisplayOrderType(ProfileID, 0, selectedOrderType, "WebLinks");
        }

        protected void btnUpdateImgOrderNumber1_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "<font color=green face=arial size=2><b>The order has been updated successfully.</b></font>";
            busObj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "WebLinks", "ChangeOrderNumber");
            LoadWebLinks();
            ModalPopupWebLinkOrderNo.Hide();
        }
    }
}