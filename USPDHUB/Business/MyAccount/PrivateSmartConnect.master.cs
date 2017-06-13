using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class PrivateSmartConnect : System.Web.UI.MasterPage
    {
        public DataTable dtButtons = new DataTable();
        public AddOnBLL objAddOnBLL = new AddOnBLL();
        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        PrivateSmartConnectBLL objPSC = new PrivateSmartConnectBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";

        public int CustomModuleId = 0;
        public static DataTable dtpermissions = new DataTable();
        AddOnBLL objAddOn = new AddOnBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        DataTable dtAddOn = new DataTable();

        public string rowID = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            lblstatusmessage.Text = "";
            if (Session["CustomModuleID"] != null)
                CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
          
            if (!IsPostBack)
            {
                if (Session["rowid"] != null)
                    hdnIndexValue.Value = Session["rowid"].ToString();
                else
                    Session["rowid"] = hdnIndexValue.Value = "0";
                LoadCallDirectoryButtons();
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfile.Rows.Count > 0)
                    hdnIsLiteVersion.Value = Convert.ToString(dtProfile.Rows[0]["IsLiteVersion"]);
            }
        }

        private void LoadCallDirectoryButtons()
        {
            dtButtons = objPSC.GetPSCCallIndex_Buttons(ProfileID, Convert.ToInt32(Session["CustomModuleID"]));
            DLButtons.DataSource = dtButtons;
            DLButtons.DataBind();
            if (dtButtons.Rows.Count > 0)
            {
                DataRow[] result = dtButtons.Select("UserModuleID >= '" + Convert.ToString(Session["CustomModuleID"]) + "'");
                if (result.Length > 0)
                {
                    int SelectedIndex = dtButtons.Rows.IndexOf(result[0]);
                    Session["rowid"] = hdnIndexValue.Value = SelectedIndex.ToString();
                }
                if (Request.CurrentExecutionFilePath.ToString().ToLower().Contains("Managepsccallindexaddons") == true)
                    LoadSelectedButton_Grid();
            }
            else
                Session["rowid"] = hdnIndexValue.Value = "0";
            CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
            dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count > 0)
            {
                Literal1.Text = "<img style='width:auto; height:auto; vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtAddOn.Rows[0]["AppIcon"].ToString() + ".png'/>";
                hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();

                bool IsVisible = Convert.ToBoolean(dtAddOn.Rows[0]["IsVisible"]);
                if (IsVisible)
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }
                else
                {
                    lblOff.Visible = true;
                    lblOn.Visible = false;
                }
                RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, hdnAddOnName.Value, Convert.ToInt32(Session["CustomModuleID"].ToString()));

            }
        }

        private void LoadSelectedButton_Grid(string rowID = "0")
        {
            ContentPlaceHolder placeholder = cphUser1 as ContentPlaceHolder;
            CustomModuleId = Convert.ToInt32(Session["CustomModuleID"]);

            dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count > 0)
            {
                Literal1.Text = "<img style='width:auto; height:auto; vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtAddOn.Rows[0]["AppIcon"].ToString() + ".png'/>";
                hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                Session["CustomModuleID"] = CustomModuleId;
            }

            if (Request.CurrentExecutionFilePath.ToString().ToLower().Contains("Managepsccallindexaddons"))
            {
                HiddenField AddOns_hdnAddOnName = placeholder.FindControl("hdnAddOnName") as HiddenField;
                AddOns_hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();

                HiddenField hdnCommandArg = placeholder.FindControl("hdnCommandArg") as HiddenField;
                hdnCommandArg.Value = "";

                HiddenField hdnarchive = placeholder.FindControl("hdnCommandArg") as HiddenField;
                DataTable dtCallIndexDetails = objPSC.GetAllManagePSCCallIndexAddOns(UserID, CustomModuleId);

                GridView GrdCallIndex = placeholder.FindControl("GrdCallIndex") as GridView;


                HiddenField hdnShowButtons = placeholder.FindControl("hdnCommandArg") as HiddenField;
                Session["dtCallIndexDetails"] = dtCallIndexDetails;
                hdnShowButtons.Value = "1";

                GrdCallIndex.DataSource = dtCallIndexDetails;
                GrdCallIndex.DataBind();


            }

            else if (Request.CurrentExecutionFilePath.ToString().Contains("Managepsccontacts"))
            {
                string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/ManagePSCContacts.aspx?tt=" + DateTime.Now.Second + "&rowid=" + rowID);
                Response.Redirect(RedirectUrl);
            }


            bool IsVisible = Convert.ToBoolean(dtAddOn.Rows[0]["IsVisible"]);
            if (IsVisible)
            {
                lblOn.Visible = true;
                lblOff.Visible = false;
            }
            else
            {
                lblOff.Visible = true;
                lblOn.Visible = false;
            }
            RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, hdnAddOnName.Value, Convert.ToInt32(Session["CustomModuleID"].ToString()));


        }
        protected void lnkEditButtonName_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkModify = sender as LinkButton;
            CustomModuleId = Convert.ToInt32(lnkModify.CommandArgument);
            Session["CustomModuleID"] = lnkModify.CommandArgument;
            DataTable dtAddOn = objAddOnBLL.GetAddOnById(CustomModuleId);
            DataTable dtCustomModuleAppIcons = new DataTable("dtCustomModuleAppIcons");
            dtCustomModuleAppIcons = objAgency.GetCustomModuleAppIcons(CustomModuleId, DomainName, true);
            hdnModuleTemplateID.Value = CustomModuleId.ToString();

            DataTable dtCustomModule = objAddOnBLL.GetUserCustomModuleById(CustomModuleId);
            if (dtCustomModule.Rows.Count > 0)
            {
                txtAppButtonName.Text = Convert.ToString(dtCustomModule.Rows[0]["TabName"]);
                chkIndVisible.Checked = Convert.ToBoolean(dtCustomModule.Rows[0]["IsVisible"]);
                string selappicon = Convert.ToString(dtCustomModule.Rows[0]["AppIcon"]);
                string customAppIcons = "";
                string appIcon = "";
                string iconClass = "icon";
                hdnModuleAppButton.Value = selappicon;
                for (int i = 0; i < dtCustomModuleAppIcons.Rows.Count; i++)
                {
                    appIcon = Convert.ToString(dtCustomModuleAppIcons.Rows[i]["AppIcon"]);
                    string appIconPath = RootPath + "/Images/CustomModulesAppIcons/" + appIcon + ".png";
                    iconClass = selappicon == appIcon ? "iconselect" : "icon";
                    customAppIcons = customAppIcons + "<li class='" + iconClass + "'><img src='" + appIconPath + "'id='img" + appIcon + "' alt='' class='pad' onclick='javascript:GetSelectAppButton(\"" + appIcon + "\")' /></li>";
                }
                ltrlCustomAppIcons.Text = customAppIcons;
                ModalCustomModule.Show();
            }
        }
        protected void lnkSelectButton_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkSelectButton = sender as LinkButton;
            Session["CustomModuleID"] = lnkSelectButton.CommandArgument;

            DataListItem gvr = (DataListItem)lnkSelectButton.NamingContainer;
            Session["rowid"] = hdnIndexValue.Value = rowID = gvr.ItemIndex.ToString();
            if (Request.CurrentExecutionFilePath.ToString().ToLower().Contains("managepsccallindexaddons"))
                LoadSelectedButton_Grid(rowID);
            else
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/managepsccallindexaddons.aspx"));

        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            objAddOnBLL.UpdateCustomModuleIcon(Convert.ToInt32(hdnModuleTemplateID.Value), chkIndVisible.Checked, txtAppButtonName.Text, hdnModuleAppButton.Value, false, C_UserID);
            lblstatusmessage.Text = "<font face=arial size=2 color=green>Your selections have been saved successfully.</font>";
            objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "MobileAppButtons", "MobileAppButtonChanging");
            hdnModuleAppButton.Value = "";
            hdnModuleTemplateID.Value = "";
            LoadCallDirectoryButtons();
            ModalCustomModule.Hide();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder place = cphUser1 as ContentPlaceHolder;
            HiddenField hdnCommandArg = place.FindControl("hdnCommandArg") as HiddenField;

            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count == 1)
                ModuleName = dtAddOn.Rows[0]["TabName"].ToString();

            #region You don't have permission to edit Content without UserID -- code comment
            //if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            //{
            //    dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
            //    if (dtpermissions.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dtpermissions.Rows.Count; i++)
            //        {
            //            if (dtpermissions.Rows[i]["ModuleName"].ToString() == ModuleName)
            //            {
            //                if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
            //                    authorPermission = "A";
            //                if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
            //                    pubPermission = "P";
            //                break;
            //            }
            //        }
            //    }
            //}

            //if ((hdnCommandArg.Value != "" && ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))) || (Convert.ToString(Session["C_USER_ID"]) == "" || Session["C_USER_ID"] == null))
            //{
            //    string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PublicCallIndexAutoMessage.aspx?CustomID=" + hdnCommandArg.Value);
            //    Response.Redirect(RedirectUrl);

            //}
            //else
            //{
            //    //lblmess.Text = "You don't have permission to edit Content.";
            //}
            #endregion

            //Accessing Permission for Edit SmartConnect Button to Associate Manager
            string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PSCAutoMessage.aspx?CustomID=" + hdnCommandArg.Value);
            Response.Redirect(RedirectUrl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder place = cphUser1 as ContentPlaceHolder;
            GridView GrdCallIndex = place.FindControl("GrdCallIndex") as GridView;

            //Identify CheckBox is checked or not
            foreach (GridViewRow row in GrdCallIndex.Rows)
            {
                if (((CheckBox)row.FindControl("chkCurrentTabCustomID")).Checked)
                {
                    string itemID = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                    string bulletinTitle = ((LinkButton)(row.FindControl("lnkTitle"))).Text;
                    // Save User Activity Log
                    objCommon.InsertUserActivityLog("has deleted a custom module named <b>" + bulletinTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                    objAddOn.DeletePublicCallIndexItem(Convert.ToInt32(itemID), UserID);
                }
            }



            DataTable dtCallIndexDetails = objPSC.GetAllManagePSCCallIndexAddOns(UserID, CustomModuleId);
            Session["dtCallIndexDetails"] = dtCallIndexDetails;
            GrdCallIndex.DataSource = dtCallIndexDetails;
            GrdCallIndex.DataBind();
            lblMessage.Text = "<font size='3'>Your selection has been deleted successfully.</font>";
        }
        protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedOrderType = Convert.ToInt32(RBAppOrder.SelectedValue);

            if (Session["CustomModuleID"] != null)
                objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"].ToString()), selectedOrderType, "AddOn");



            SetSelectedButtonExpand(rowID);
        }
        private void SetSelectedButtonExpand(string rowID)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadExpandsEvents(" + rowID + ")</script>", false);
        }
        protected void lnkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtobj = new DataTable();
                lbl2.Text = string.Empty;
                dtobj = objPSC.GetAllPSCCallIndexAddOnsByOrder(CustomModuleId);
                if (dtobj.Rows.Count > 0)
                {
                    OrderListView.DataSource = null;
                    OrderListView.DataSource = dtobj;
                    OrderListView.DataBind();
                    ModalPopupImgOrderNo.Show();
                    ScriptManager.RegisterStartupScript(UpdatePanelCall, UpdatePanelCall.GetType(), "JavaScipt", "ShowOrderScript();", true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        protected void OrderListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblOrderThumb;
            Label lblKey;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                lblOrderThumb = (Label)e.Item.FindControl("lblOrderThumb");
                lblKey = (Label)e.Item.FindControl("lblKey");
                string ImageDisID = Guid.NewGuid().ToString();
                if (File.Exists(Server.MapPath("~") + "\\Upload\\AppThumbs\\PrivateSmartConnectModule\\" + ProfileID.ToString() + "\\" + lblKey.Text + ".jpg"))
                    lblOrderThumb.Text = "<img src='" + RootPath + "/Upload/AppThumbs/PrivateSmartConnectModule/" + ProfileID.ToString() + "/" + lblKey.Text + ".jpg?Guid=" + ImageDisID + "' width='50' height='20' />";
                else
                    lblOrderThumb.Text = "";
            }
        }
        protected void lnkDummmy_Click(object sender, EventArgs e)
        {
            string ddlCategory, RedirectUrl;
            ContentPlaceHolder place = cphUser1 as ContentPlaceHolder;
            if (Request.CurrentExecutionFilePath.ToString().ToLower().Contains("managepsccallindexaddons"))
            {
                ddlCategory = ((DropDownList)(place.FindControl("ddlCategories"))).SelectedValue;
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PSCAutoMessage.aspx?CategoryID=" + EncryptDecrypt.DESEncrypt(ddlCategory));
            }
            else
            {
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PSCAutoMessage.aspx");
            }
            Response.Redirect(RedirectUrl);
            
        }
    }
}