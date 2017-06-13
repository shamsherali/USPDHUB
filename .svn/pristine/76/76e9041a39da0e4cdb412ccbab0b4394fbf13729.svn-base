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
    public partial class SelectItem : BaseWeb
    {
        public string RootPath = "";
        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        BulletinBLL objBulletin = new BulletinBLL();
        public static DataTable dtpermissions = new DataTable();
        AddOnBLL objAddOn = new AddOnBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public int CustomModuleId = 0;
        public string DomainName = string.Empty;
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
                DomainName = Session["VerticalDomain"].ToString();
                if (Session["CustomModuleID"] == null)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"), false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
                RootPath = Session["RootPath"].ToString();
                if (!IsPostBack)
                {
                    DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
                    if (dtAddOn.Rows.Count == 1)
                    {
                        hdnTabName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                    }

                    if (dtAddOn.Rows.Count > 0)
                    {
                        if (Convert.ToString(dtAddOn.Rows[0]["ButtonType"]) == "PrivateAddOn")
                        {
                            lnkAddMore.Visible = false;
                        }
                        else
                        {
                            lnkAddMore.Visible = true;
                        }
                    }

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CustomModuleId, "ContentModule");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel2.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create " + hdnTabName.Value + ".</font>";
                        }
                    }
                    GetActiveForms();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetActiveForms()
        {
            try
            {
                DataTable dtBulletins = new DataTable();
                int? customID = null;
                dtBulletins = objAddOn.GetActiveForms(CustomModuleId, customID);
                if (dtBulletins.Rows.Count > 0)
                    Session["AllForms"] = dtBulletins;
                if (dtBulletins.Rows.Count > 1)
                    hdnIsRemove.Value = "true";
                else
                    hdnIsRemove.Value = "false";
                rptTest.DataSource = dtBulletins;
                rptTest.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "GetActiveForms", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnSelect = sender as LinkButton;
                DataTable dtBulletins = (DataTable)Session["AllForms"];
                string filterRows = "ModuleID='" + btnSelect.CommandArgument.ToString() + "'";
                if (Txttemplatename.Text.Trim() != "")
                {
                    DataRow[] drr = dtBulletins.Select(filterRows);
                    if (drr.Count() > 0)
                    {
                        string RedirectUrl = string.Empty;
                        Session["FormID"] = btnSelect.CommandArgument.ToString();
                        Session["BulletinName"] = Txttemplatename.Text.Trim();
                        Session["BulletinID"] = "0";
                        Session["BulletinCategoryName"] = dtBulletins.Rows[0]["CategoryName"];
                        bool IsUserForms = false;
                        if (String.Equals(Convert.ToString(drr[0]["IsUserForms"]), "true", StringComparison.OrdinalIgnoreCase))
                        {
                            IsUserForms = true;
                        }
                        if (IsUserForms)
                        {
                            string userFormsUrl = "";
                            if (RootPath.ToLower().Contains("localhost"))
                            {
                                //For Local RootPath
                                userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                 + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString())
                                 + "&BName=" + EncryptDecrypt.DESEncrypt(Session["BulletinName"].ToString())
                                  + "&TempID=" + EncryptDecrypt.DESEncrypt(btnSelect.CommandArgument.ToString())
                                  + "&CMID=" + EncryptDecrypt.DESEncrypt(Session["CustomModuleID"].ToString()) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                            }
                            else
                            {
                                //For Test RootPath
                                userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                              + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString())
                              + "&BName=" + EncryptDecrypt.DESEncrypt(Session["BulletinName"].ToString())
                               + "&TempID=" + EncryptDecrypt.DESEncrypt(btnSelect.CommandArgument.ToString())
                               + "&CMID=" + EncryptDecrypt.DESEncrypt(Session["CustomModuleID"].ToString()) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                            }

                            RedirectUrl = Page.ResolveClientUrl(userFormsUrl);
                        }
                        else
                        {
                            RedirectUrl = Page.ResolveClientUrl("~" + drr[0]["NavigationUrl"].ToString());
                        }
                        Response.Redirect(RedirectUrl);
                    }
                }
                else
                    lblerrormessage.Text = "<font face=arial size=2>" + Resources.LabelMessages.ItemTitleEmpty + "</font>";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "btnSelect_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx"));
        }
        protected void lnkAddMore_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRemaining = objAddOn.GetRemainingForms(CustomModuleId, DomainName, UserID);
                if (dtRemaining.Rows.Count > 0)
                {
                    hdnTabName.Value = Convert.ToString(dtRemaining.Rows[0]["TabName"]);
                    dlRemaingForms.DataSource = dtRemaining;
                    dlRemaingForms.DataBind();
                    ModalRemaing.Show();
                }
                else
                    lblmsg.Text = "<font face=arial size=2 color=red>Currently there are no active forms to add to " + hdnTabName.Value + " button.</font>";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "lnkAddMore_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkAddMoreForms_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                bool IsAdded = false;
                if (dlRemaingForms.Items.Count > 0)
                {
                    foreach (DataListItem item in dlRemaingForms.Items)
                    {
                        CheckBox chkRemaining = item.FindControl("chkRemaining") as CheckBox;
                        if (chkRemaining.Checked)
                        {
                            IsAdded = true;
                            int moduleID = Convert.ToInt32(dlRemaingForms.DataKeys[item.ItemIndex]);
                            objAddOn.InsertPurchasedForms(0, CustomModuleId, moduleID, CUserID, true);
                        }
                    }
                }
                if (IsAdded)
                    lblmsg.Text = "<font face=arial size=2 color=green>Selected form(s) have been added successfully for " + hdnTabName.Value + " button.</font>";

                GetActiveForms();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "lnkAddMoreForms_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                DataTable dtActiveForms = objAddOn.GetActiveForms(CustomModuleId, null);
                bool hasActives = false;
                if (dtActiveForms.Rows.Count > 0)
                {
                    string filterRows = "IsDefault<>False OR IsDefault<>0";
                    DataRow[] dractive = dtActiveForms.Select(filterRows);
                    if (dractive != null)
                    {
                        for (int i = 0; i < dractive.Length; i++)
                        {
                            dtActiveForms.Rows.Remove(dractive[i]);
                        }
                    }
                    if (dtActiveForms.Rows.Count > 0)
                    {
                        hdnTabName.Value = Convert.ToString(dtActiveForms.Rows[0]["TabName"]);
                        dlDeactivate.DataSource = dtActiveForms;
                        dlDeactivate.DataBind();
                        ModalDeactivate.Show();
                        hasActives = true;
                        hdnSelItems.Value = "";
                    }
                }
                if (hasActives == false)
                    lblmsg.Text = "<font face=arial size=2 color=red>Currently there are no active forms to remove.</font>";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "lnkDeactivate_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkDeactivateForms_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                bool IsAdded = false;
                if (dlDeactivate.Items.Count > 0)
                {
                    foreach (DataListItem item in dlDeactivate.Items)
                    {
                        CheckBox chkDeactivate = item.FindControl("chkDeactivate") as CheckBox;
                        if (chkDeactivate.Checked)
                        {
                            IsAdded = true;
                            int formID = Convert.ToInt32(dlDeactivate.DataKeys[item.ItemIndex]);
                            objAddOn.InsertPurchasedForms(formID, CustomModuleId, 0, CUserID, false);
                        }
                    }
                }

                if (IsAdded)
                    lblmsg.Text = "<font face=arial size=2 color=green>Selected form(s) have been removed successfully for " + hdnTabName.Value + " button.</font>";

                GetActiveForms();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SelectItem.aspx.cs", "lnkDeactivateForms_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}