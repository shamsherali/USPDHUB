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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;


namespace USPDHUB.Business.MyAccount
{
    public partial class UserPermissionsNew : BaseWeb
    {
        public int ParentUserID = 0;
        public int ProfileID = 0;
        AgencyBLL agencyobj = new AgencyBLL();
        public int C_UserID = 0;
        public int associateID = 0;
        public static DataTable dtpermissions = new DataTable();
        public static DataTable dtuserdetails = new DataTable();
        public int PermissionCnt = 0;
        public int gridPageIndex = 0;
        public bool IsManageLogins = true;
        BusinessBLL objBus = new BusinessBLL();
        Consumer objConsumer = new Consumer();
        CommonBLL objCommonBll = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsSmart = false;
        public bool IsManageLogin = false;
        public bool IsPrivateCall = false;
        public bool IsPushNotification = false;
        public bool IsGallery = false;
        public bool IsWebLinks = false;
        public bool IsSocialMedia = false;
        public bool IsBannerAds = false;
        public bool IsContacts = false;
        public bool IsSmartCategory = false;

        public bool IsSmartConnectAviable = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                hdnIsLiteVersion.Value = Convert.ToString(Session["IsLiteVersion"]);
                ParentUserID = Convert.ToInt32(Session["UserID"]);
                ProfileID = Convert.ToInt32(Session["ProfileID"]);
                if (Session["C_USER_ID"] != null)
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = ParentUserID;

                //For Associate UserID from ManageAssociate.aspx Editing....
                if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
                {
                    associateID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"]));
                }
                //Store Module Permission Functionality
                //Permission for SmartConnect Categories
                if (objBus.CheckModulePermission(WebConstants.Tab_PublicCallAddOns, ProfileID))
                {
                    IsSmart = true;
                    IsSmartCategory = true;
                }
                else
                {
                    chkSmartConnect.Checked = false;
                    chkSmartConnect.Enabled = false;
                    chkSmartConnect.CssClass = "chkcolor";
                    //chkSmartConnect.Style.Add("display", "none");
                    chkSmartConnectCategory.Checked = false;
                    chkSmartConnectCategory.Enabled = false;
                    chkSmartConnectCategory.CssClass = "chkcolor";
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_ManageLoginsSetup, ProfileID))
                {
                    IsManageLogin = true;
                }
                else
                {
                    chkManageLogins.Checked = false;
                    chkManageLogins.Enabled = false;
                    chkManageLogins.CssClass = "chkcolor";
                    //chkManageLogins.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_PrivateCallAddOns, ProfileID))
                {
                    IsPrivateCall = true;
                }
                else
                {
                    chkPrivateAddOnInvs.Checked = false;
                    chkPrivateAddOnInvs.Enabled = false;
                    chkPrivateAddOnInvs.CssClass = "chkcolor";
                    //chkPrivateAddOnInvs.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Tab_Notifications, ProfileID))
                {
                    IsPushNotification = true;
                }
                else
                {
                    chkPushAuthor.Checked = false;
                    chkPushAuthor.Enabled = false;
                    chkPushAuthor.CssClass = "chkcolor";
                    //chkPushAuthor.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_ImageGalleryAddOns, ProfileID))
                {
                    IsGallery = true;
                }
                else
                {
                    chkGallery.Checked = false;
                    chkGallery.Enabled = false;
                    chkGallery.CssClass = "chkcolor";
                    //chkGallery.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_WebLinksSetup, ProfileID))
                {
                    IsWebLinks = true;
                }
                else
                {
                    chkLinks.Checked = false;
                    chkLinks.Enabled = false;
                    chkLinks.CssClass = "chkcolor";
                    //chkLinks.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_SocialMedia, ProfileID))
                {
                    IsSocialMedia = true;
                }
                else
                {
                    chkSocial.Checked = false;
                    chkSocial.Enabled = false;
                    chkSocial.CssClass = "chkcolor";
                    //chkSocial.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_BannerAds, ProfileID))
                {
                    IsBannerAds = true;
                }
                else
                {
                    chkBannerAds.Checked = false;
                    chkBannerAds.Enabled = false;
                    chkBannerAds.CssClass = "chkcolor";
                    //chkBannerAds.Style.Add("display", "none");
                }

                if (objBus.CheckModulePermission(WebConstants.Purchase_ContactUs_BlockSenderSetup, ProfileID))
                {
                    IsContacts = true;
                }
                else
                {
                    chkAuthorContacts.Checked = false;
                    chkAuthorContacts.Enabled = false;
                    chkAuthorContacts.CssClass = "chkcolor";
                    //chkAuthorContacts.Style.Add("display", "none");
                }
                if (IsSmart == true && IsSmartCategory == true && IsManageLogin == true && IsPrivateCall == true && IsPushNotification == true
                    && IsGallery == true && IsWebLinks == true && IsSocialMedia == true && IsBannerAds == true && IsContacts == true)
                {
                    divNote.Style.Add("display", "none");
                }


                DataTable dtModules = objBus.CheckingModuleExists(ProfileID, ButtonTypes.SmartConnect);
                if (dtModules.Rows.Count > 0)
                    IsSmartConnectAviable = true;

                if (!IsPostBack)
                {
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        IsManageLogins = objCommonBll.returnUserPermission(C_UserID, 0, CommonModules.ManageAssociates) == "P" ? true : false;
                    if (IsManageLogins == false)
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to access user permissions.</font>";
                    }
                    else if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
                    {
                        dtpermissions = agencyobj.GetPermissionsByAssociateId(associateID);

                        DataTable dtPrivateCallButtons = dtpermissions.Clone();
                        var drRows = dtpermissions.Select("ButtonType='PrivateCallAddOns'");
                        var drRows1 = dtpermissions.Select("ButtonType='PublicCallAddOns'");
                        if (drRows.Length > 0)
                            dtPrivateCallButtons = dtpermissions.Select("ButtonType='PrivateCallAddOns'").CopyToDataTable();

                        string filterQuery1 = "ButtonType='" + WebConstants.Tab_PrivateCallAddOns + "'";
                        DataRow[] dRRemove = dtpermissions.Select(filterQuery1);
                        if (dRRemove.Length > 0)
                        {
                            for (int i = 0; i < dRRemove.Length; i++)
                            {
                                dtpermissions.Rows.Remove(dRRemove[i]);
                            }
                        }

                        //Private SmartConnect
                        DataTable dtPSC = dtpermissions.Clone();
                        var drRowsPSC = dtpermissions.Select("ButtonType='PrivateSmartConnectAddOns'");
                        if (drRowsPSC.Length > 0)
                            dtPSC = dtpermissions.Select("ButtonType='PrivateSmartConnectAddOns'").CopyToDataTable();
                        string filterQuery2 = "ButtonType='" + WebConstants.Tab_PrivateSmartConnectAddOns + "'";
                        DataRow[] dRRemove1 = dtpermissions.Select(filterQuery2);
                        if (dRRemove1.Length > 0)
                        {
                            for (int i = 0; i < dRRemove1.Length; i++)
                            {
                                dtpermissions.Rows.Remove(dRRemove1[i]);
                            }
                        }

                        //string filterQuery2 = "ButtonType='" + WebConstants.Tab_PublicCallAddOns + "'";
                        //DataRow[] dRRemove1 = dtpermissions.Select(filterQuery2);
                        //if (dRRemove1.Length > 0)
                        //{
                        //    for (int i = 0; i < dRRemove1.Length; i++)
                        //    {
                        //        dtpermissions.Rows.Remove(dRRemove1[i]);
                        //    }
                        //}


                        dtuserdetails = getdata(associateID);
                        if (dtuserdetails.Rows.Count > 0)
                            hdnuserflag.Value = dtuserdetails.Rows[0]["Username"].ToString();
                        if (dtpermissions.Rows.Count > 0)
                        {
                            var results = from myRow in dtpermissions.AsEnumerable()
                                          where myRow.Field<Int32?>("UserModuleId") != null & myRow.Field<string>("ButtonType") != WebConstants.Purchase_BannerAds & myRow.Field<string>("ButtonType") != WebConstants.Tab_PublicCallAddOns & myRow.Field<string>("AccessType") == "Button"
                                          select new
                                          {

                                              ModuleName = myRow.Field<string>("ModuleName"),
                                              UserModuleId = myRow.Field<Int32>("UserModuleId"),
                                              IsAuthor = myRow.Field<bool?>("IsAuthor"),
                                              IsPublisher = myRow.Field<bool?>("IsPublisher"),
                                              IsReviewer = myRow.Field<bool?>("IsReviewer"),
                                              ButtonType = myRow.Field<string>("ButtonType")
                                          };
                            DataRow[] dtRows = dtpermissions.Select("ButtonType='" + WebConstants.Purchase_BannerAds + "'");
                            if (dtRows.Length > 0)
                            {
                                Session["BannerAds"] = dtRows.CopyToDataTable();
                                //hdnHasBannerAds.Value = "true";
                            }

                            hdnHasBannerAds.Value = "true";

                            Repeater1.DataSource = results;
                            //if (Convert.ToBoolean(Session["IsLiteVersion"]))
                            //{
                            //    Repeater1.Visible = false;
                            //}
                            //else
                            //{
                            Repeater1.DataBind();

                            //USPD-1107 and USPD-1116 Permission related Changes
                            for (int i = 0; i < dtpermissions.Rows.Count; i++)
                            {
                                if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.ManageMessageReceipt.ToString())
                                    chkMessageAuthor.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.PrivateAddOnInvs.ToString())
                                    chkPrivateAddOnInvs.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.AppSettings.ToString())
                                    chkASettingsAuthor.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.Contacts.ToString())
                                    chkAuthorContacts.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.Downloads.ToString())
                                    chkDownloads.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.ManageButtons.ToString())
                                    chkMButtonsAuthor.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.ReceiveFeedbackTips.ToString())
                                    chkToolTip.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.PushNotifications.ToString())
                                {
                                    chkPushAuthor.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                }
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.AccessMarketPlace.ToString())
                                    chkMarketPlace.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.ManageAssociates.ToString())
                                    chkManageLogins.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.AppBackgroundImage.ToString())
                                    chkAppBG.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.BannerAds.ToString())
                                    chkBannerAds.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.Home.ToString())
                                    chkHome.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.AboutUs.ToString())
                                    chkMission.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.WebLinks.ToString())
                                    chkLinks.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.SocialMedia.ToString())
                                    chkSocial.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.ReceiveTips.ToString())
                                    chkTips.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.Gallery.ToString())
                                    chkGallery.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.BillingHistory.ToString())
                                    chkBilling.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.ReleaseHistory.ToString())
                                    chkRelease.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.AppStatistics.ToString())
                                    chkAppsStats.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.PublicCallAddOns.ToString())
                                    chkSmartConnect.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                                else if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == CommonModules.SmartConnectCategories.ToString())
                                    chkSmartConnectCategory.Checked = Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString());
                            }

                            #region Checkboxes dynamically names

                            DataTable dtCustomModules = objBus.DashboardIcons(ParentUserID);
                            for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                            {
                                if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Notifications")
                                {
                                    chkPushAuthor.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Home")
                                {
                                    chkHome.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "WebLinks")
                                {
                                    chkLinks.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Gallery")
                                {
                                    chkGallery.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "AboutUs")
                                {
                                    chkMission.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "SocialMedia")
                                {
                                    chkSocial.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Contact")
                                {
                                    chkToolTip.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Tips")
                                {
                                    chkTips.Text = " " + Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                                else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "PublicCallAddOns")
                                {
                                    lblPublicalButtonName.Text = Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                                }
                            }


                            #endregion

                            #region Private SmartConnect
                            List<AllPSCModules> ListPSC1 = new List<AllPSCModules>();

                            for (int i = 0; i < dtPSC.Rows.Count; i++)
                            {
                                ListPSC1.Add(new AllPSCModules
                                        {
                                            ModuleName = dtPSC.Rows[i]["TabName"].ToString(),
                                            UserModuleId = Convert.ToInt32(dtPSC.Rows[i]["UserModuleId"].ToString()),
                                            IsCategory = Convert.ToBoolean(dtPSC.Rows[i]["IsReviewer"].ToString()),
                                            IsPublisher = Convert.ToBoolean(dtPSC.Rows[i]["IsPublisher"].ToString()),
                                            ButtonType = dtPSC.Rows[i]["ButtonType"].ToString()
                                        });
                            }


                            Repeater2.DataSource = ListPSC1;
                            Repeater2.DataBind();
                            #endregion
                        }
                        else
                        {
                            List<AllModules> lstModuleNames = GetModuleData();
                            Repeater1.DataSource = lstModuleNames;
                            Repeater1.DataBind();
                        }

                        //Private Call Add Ons

                        if (dtPrivateCallButtons.Rows.Count > 0)
                        {
                            pnlPrivateCallAddOns.Style.Add("display", "block");
                            chkPrivateCallAddOnsList.DataSource = dtPrivateCallButtons;
                            chkPrivateCallAddOnsList.DataValueField = "UserModuleId";
                            chkPrivateCallAddOnsList.DataTextField = "ModuleName";
                            chkPrivateCallAddOnsList.DataBind();
                            for (int i = 0; i < dtPrivateCallButtons.Rows.Count; i++)
                            {
                                chkPrivateCallAddOnsList.Items[i].Selected = Convert.ToBoolean(dtPrivateCallButtons.Rows[i]["IsPublisher"]);
                            }

                        }
                        else
                        {
                            pnlPrivateCallAddOns.Style.Add("display", "none");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UserPermissionsNew.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            //if (Convert.ToBoolean(Session["IsLiteVersion"]))
            //{ 
            //   chkMessageAuthor.Visible=false;
            //   chkASettingsAuthor.Visible=false;
            //   chkAuthorContacts.Visible=false;
            //   chkMarketPlace.Visible=false;
            //   chkAppBG.Visible=false;
            //  chkBannerAds.Visible=false;
            //  chkAppsStats.Visible=false;
            //  chkRelease.Visible=false;
            //  chkBilling.Visible=false;
            //  chkGallery.Visible=false;
            //  chkSocial.Visible=false;
            //  chkLinks.Visible=false;
            //  chkHome.Visible = false;
            //  chkMButtonsAuthor.Visible = false;

            //}
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                object moduleName = null;
                object createOnly = null;
                object publishOnly = null;
                object reviewerOnly = null;
                object moduleId = null;
                object moduleNamePSC = null;
                object publishOnlyPSC = null;
                object categoryOnlyPSC = null;
                object moduleIdPSC = null;
                DataTable dtPermissionsMsg = agencyobj.GetPermissionsByAssociateId(associateID);
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.Item)
                    {
                        moduleName = (Label)item.FindControl("lblModuleName1");
                        createOnly = (CheckBox)item.FindControl("chkCreate1");
                        publishOnly = (CheckBox)item.FindControl("chkPublisher1");
                        reviewerOnly = (CheckBox)item.FindControl("chkReviewer1");
                        moduleId = (Label)item.FindControl("lblModuleId1");
                    }
                    else
                    {
                        moduleName = (Label)item.FindControl("lblModuleName2");
                        createOnly = (CheckBox)item.FindControl("chkCreate2");
                        publishOnly = (CheckBox)item.FindControl("chkPublisher2");
                        reviewerOnly = (CheckBox)item.FindControl("chkReviewer2");
                        moduleId = (Label)item.FindControl("lblModuleId2");
                    }
                    moduleName = ((Label)(moduleName)).Text;
                    createOnly = ((CheckBox)(createOnly)).Checked;
                    publishOnly = ((CheckBox)(publishOnly)).Checked;
                    reviewerOnly = ((CheckBox)(reviewerOnly)).Checked;
                    moduleId = ((Label)(moduleId)).Text;
                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(moduleId), Convert.ToBoolean(createOnly), Convert.ToBoolean(publishOnly), Convert.ToBoolean(reviewerOnly), associateID, Convert.ToString(moduleName), C_UserID);
                }
                #region Private SmartConnect

                foreach (RepeaterItem item in Repeater2.Items)
                {
                    if (item.ItemType == ListItemType.Item)
                    {
                        moduleNamePSC = (Label)item.FindControl("lblPSCModuleName1");
                        publishOnlyPSC = (CheckBox)item.FindControl("chkPSCPublisher1");
                        categoryOnlyPSC = (CheckBox)item.FindControl("chkCategory1");
                        moduleIdPSC = (Label)item.FindControl("lblPSCModuleId1");
                    }
                    else
                    {
                        moduleNamePSC = (Label)item.FindControl("lblPSCModuleName2");
                        publishOnlyPSC = (CheckBox)item.FindControl("chkPSCPublisher2");
                        categoryOnlyPSC = (CheckBox)item.FindControl("chkCategory2");
                        moduleIdPSC = (Label)item.FindControl("lblPSCModuleId2");
                    }

                    moduleNamePSC = ((Label)(moduleNamePSC)).Text;
                    publishOnlyPSC = ((CheckBox)(publishOnlyPSC)).Checked;
                    categoryOnlyPSC = ((CheckBox)(categoryOnlyPSC)).Checked;
                    moduleIdPSC = ((Label)(moduleIdPSC)).Text;

                    //IsCategory(categoryOnlyPSC) as IsReviewer
                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(moduleIdPSC), Convert.ToBoolean(publishOnlyPSC),
                        Convert.ToBoolean(publishOnlyPSC), Convert.ToBoolean(categoryOnlyPSC), associateID, WebConstants.Tab_PrivateSmartConnectAddOns, C_UserID);
 

                }

                #endregion
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkMessageAuthor.Checked, chkMessageAuthor.Checked, chkMessageAuthor.Checked, associateID, CommonModules.ManageMessageReceipt.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkPrivateAddOnInvs.Checked, chkPrivateAddOnInvs.Checked, chkPrivateAddOnInvs.Checked, associateID, CommonModules.PrivateAddOnInvs.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkPushAuthor.Checked, chkPushAuthor.Checked, chkPushAuthor.Checked, associateID, CommonModules.PushNotifications.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkMButtonsAuthor.Checked, chkMButtonsAuthor.Checked, chkMButtonsAuthor.Checked, associateID, CommonModules.ManageButtons.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkASettingsAuthor.Checked, chkASettingsAuthor.Checked, chkASettingsAuthor.Checked, associateID, CommonModules.AppSettings.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkAuthorContacts.Checked, chkAuthorContacts.Checked, chkAuthorContacts.Checked, associateID, CommonModules.Contacts.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkToolTip.Checked, chkToolTip.Checked, chkToolTip.Checked, associateID, CommonModules.ReceiveFeedbackTips.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkDownloads.Checked, chkDownloads.Checked, chkDownloads.Checked, associateID, CommonModules.Downloads.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkMarketPlace.Checked, chkMarketPlace.Checked, chkMarketPlace.Checked, associateID, CommonModules.AccessMarketPlace.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkManageLogins.Checked, chkManageLogins.Checked, chkManageLogins.Checked, associateID, CommonModules.ManageAssociates.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkAppBG.Checked, chkAppBG.Checked, chkAppBG.Checked, associateID, CommonModules.AppBackgroundImage.ToString(), C_UserID);
                //USPD-1107 and USPD-1116 Permission related Changes
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkHome.Checked, chkHome.Checked, chkHome.Checked, associateID, CommonModules.Home.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkMission.Checked, chkMission.Checked, chkMission.Checked, associateID, CommonModules.AboutUs.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkLinks.Checked, chkLinks.Checked, chkLinks.Checked, associateID, CommonModules.WebLinks.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkSocial.Checked, chkSocial.Checked, chkSocial.Checked, associateID, CommonModules.SocialMedia.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkTips.Checked, chkTips.Checked, chkTips.Checked, associateID, CommonModules.ReceiveTips.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkGallery.Checked, chkGallery.Checked, chkGallery.Checked, associateID, CommonModules.Gallery.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkBilling.Checked, chkBilling.Checked, chkBilling.Checked, associateID, CommonModules.BillingHistory.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkRelease.Checked, chkRelease.Checked, chkRelease.Checked, associateID, CommonModules.ReleaseHistory.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkAppsStats.Checked, chkAppsStats.Checked, chkAppsStats.Checked, associateID, CommonModules.AppStatistics.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToString(dtpermissions.Rows[0]["UserModuleId"]) == "" ? (int?)null : Convert.ToInt32(dtpermissions.Rows[0]["UserModuleId"]), chkSmartConnect.Checked, chkSmartConnect.Checked, chkSmartConnect.Checked, associateID, CommonModules.PublicCallAddOns.ToString(), C_UserID);
                agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkSmartConnectCategory.Checked, chkSmartConnectCategory.Checked, chkSmartConnectCategory.Checked, associateID, CommonModules.SmartConnectCategories.ToString(), C_UserID);

                if (Convert.ToBoolean(hdnHasBannerAds.Value))
                {
                    if (Session["BannerAds"] != null)
                    {
                        DataTable dtBannerAd = (DataTable)Session["BannerAds"];
                        agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToString(dtBannerAd.Rows[0]["UserModuleId"]) == "" ? (int?)null : Convert.ToInt32(dtBannerAd.Rows[0]["UserModuleId"]), chkBannerAds.Checked, chkBannerAds.Checked, chkBannerAds.Checked, associateID, CommonModules.BannerAds.ToString(), C_UserID);
                    }
                    else
                    {

                        agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, Convert.ToBoolean(createOnly), Convert.ToBoolean(publishOnly), Convert.ToBoolean(reviewerOnly), associateID, Convert.ToString(moduleName), C_UserID);
                    }
                }
                //Private Call AddOns
                for (int i = 0; i < chkPrivateCallAddOnsList.Items.Count; i++)
                {
                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(chkPrivateCallAddOnsList.Items[i].Value), chkPrivateCallAddOnsList.Items[i].Selected, chkPrivateCallAddOnsList.Items[i].Selected, chkPrivateCallAddOnsList.Items[i].Selected, associateID, chkPrivateCallAddOnsList.Items[i].Text, C_UserID);
                }

                if (dtPermissionsMsg.Rows.Count > 0)
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?count=4&page=" + GetGridPage()));
                else
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?count=3&page=" + GetGridPage()));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UserPermissionsNew.aspx.cs", "lnkSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?page=" + GetGridPage()));
        }
        protected void rptMyRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        private int GetGridPage()
        {
            if (Request.QueryString["index"] != "" && Request.QueryString["index"] != null)
                gridPageIndex = Convert.ToInt32(Request.QueryString["index"]);
            return gridPageIndex;
        }
        public DataTable getdata(int UserID)
        {
            DataTable dtUserData = objBus.GetUserDtlsByUserID(UserID);
            return dtUserData;
        }
        private List<AllModules> GetModuleData()
        {
            List<AllModules> ListModules = new List<AllModules>();
            try
            {
                DataTable dtCustomModules = objBus.DashboardIcons(ParentUserID);
                string filterQuery = string.Empty;
                filterQuery = "ButtonType='Call' or ButtonType='Contact' or ButtonType='Directions' or ButtonType='Tips' or Buttontype='SubApps' or Buttontype='Updates'";
                DataRow[] dRRemove = dtCustomModules.Select(filterQuery);
                if (dRRemove != null)
                {
                    for (int i = 0; i < dRRemove.Length; i++)
                    {
                        dtCustomModules.Rows.Remove(dRRemove[i]);
                    }
                }
                for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                {
                    if (
                            (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Bulletins") ||
                            (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Surveys") ||
                            (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "EventCalendar") ||
                            (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_ContentAddOns) ||
                            (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_CalendarAddOns) ||
                            (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_PrivateContentAddOns)
                        )
                        ListModules.Add(new AllModules
                                {
                                    ModuleName = dtCustomModules.Rows[i]["TabName"].ToString(),
                                    UserModuleId = Convert.ToInt32(dtCustomModules.Rows[i]["UserModuleID"].ToString()),
                                    IsAuthor = false,
                                    IsPublisher = false,
                                    ButtonType = dtCustomModules.Rows[i]["ButtonType"].ToString()
                                });
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UserPermissionsNew.aspx.cs", "GetModuleData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }


            return ListModules;
        }
    }
    public class AllModules
    {
        public string ModuleName { get; set; }
        public int UserModuleId { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsPublisher { get; set; }
        public string ButtonType { get; set; }
        public bool IsCategory { get; set; }
    }
    public class AllPSCModules
    {
        public string ModuleName { get; set; }
        public int UserModuleId { get; set; }
        public bool IsCategory { get; set; }
        public bool IsPublisher { get; set; }
        public string ButtonType { get; set; }

    }
}