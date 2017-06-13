using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Web.Services;
using System.Xml.Linq;
using System.Text;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageAppButtons : BaseWeb
    {

        // hdnSelectedTab.Value
        //1 Means Default Tab
        //2 Means Private Call Tab

        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        public string DomainName = "";
        public bool IsHasPrivilege = true;
        public string RootPath = "";
        USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblstatusmessage.Text = "";
            UserID = Convert.ToInt32(Session["UserID"]);
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
            ProfileID = Convert.ToInt32(Session["ProfileID"]);
            if (!IsPostBack)
            {
                if (Request.QueryString["stab"] != null)
                { hdnSelectedTab.Value = Request.QueryString["stab"].ToString(); }

                pnlAppButtons.Visible = false;

                #region  roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageButtons");
                    if (hdnPermissionType.Value == "A")
                    {
                        IsHasPrivilege = false;
                        lblstatusmessage.Text = "<font face=arial size=2 color=red>You do not have permission to update mobile app buttons.</font>";
                    }
                }
                #endregion
                if (IsHasPrivilege)
                    LoadCustomModules(false, false);
                if (Session["AppButtonSuccess"] != null)
                {
                    lblstatusmessage.Text = Convert.ToString(Session["AppButtonSuccess"]);
                    Session["AppButtonSuccess"] = null;
                }
            }
        }
        public void LoadCustomModules(bool addMobile, bool checkSettings)
        {
            try
            {
                // *** checkSettings parameter is used to update the settings only and no need to bind data when it is 'True' because it is not clearing data properly. So we are redirecting it again to this page *** //
                lvCustomModule.Items.Clear();
                lvCustomModule.DataSource = null;
                lvCustomModule.DataBind();

                lstPrivateCallButtons.Items.Clear();
                lstPrivateCallButtons.DataSource = null;
                lstPrivateCallButtons.DataBind();

                DataSet dtAddOns = new DataSet();
                dtAddOns = objAddOn.GetManageAddOns(UserID, null);
                if (checkSettings == false)
                {
                    pnlAppButtons.Visible = true;
                    if (hdnSelectedTab.Value == "1")
                    {
                        string filterQuery = "ButtonType='" + WebConstants.Tab_BannerAds + "' OR ButtonType='" + WebConstants.Tab_PrivateCallAddOns + "'";
                        DataRow[] dRRemove = dtAddOns.Tables[0].Select(filterQuery);

                        string filterQueryRel = "";
                        if (dRRemove.Length > 0)
                        {
                            for (int i = 0; i < dRRemove.Length; i++)
                            {
                                if (Convert.ToString(dRRemove[i]["ButtonType"]) == WebConstants.Tab_PrivateCallAddOns)
                                {
                                    if (filterQueryRel == "")
                                        filterQueryRel = "UserModuleID=" + Convert.ToString(dRRemove[i]["UserModuleID"]);
                                    else
                                        filterQueryRel += " OR UserModuleID=" + Convert.ToString(dRRemove[i]["UserModuleID"]);


                                    //dtPrivateCallAddOns.Tables[0].ImportRow(dRRemove[i]);
                                }
                                dtAddOns.Tables[0].Rows.Remove(dRRemove[i]);
                            }
                        }

                        if (filterQueryRel != string.Empty)
                        {
                            DataRow[] dRRemoveRel = dtAddOns.Tables[1].Select(filterQueryRel);

                            if (dRRemoveRel.Length > 0)
                            {
                                for (int i = 0; i < dRRemoveRel.Length; i++)
                                {
                                    dtAddOns.Tables[1].Rows.Remove(dRRemoveRel[i]);
                                }
                            }
                        }

                        if (dtAddOns.Tables.Count > 0 && dtAddOns.Tables[0].Rows.Count > 0)
                        {
                            DataRelation relation;
                            DataColumn table1Column;
                            DataColumn table2Column;
                            //retrieve column 
                            table1Column = dtAddOns.Tables[0].Columns["UserModuleID"];
                            table2Column = dtAddOns.Tables[1].Columns["UserModuleID"];
                            //relating tables 
                            relation = new DataRelation("relation", table1Column, table2Column, true);
                            //assign relation to dataset 
                            dtAddOns.Relations.Add(relation);

                            lvCustomModule.DataSource = dtAddOns;
                            lvCustomModule.DataBind();


                        }
                        else
                            lblstatusmessage.Text = "<font face=arial size=2 color=red>Currently you have no buttons to manage.</font>";
                    }
                    else
                    {
                        DataSet dtPrivateCallAddOns = new DataSet();
                        dtPrivateCallAddOns = objAddOn.GetPrivateCallAddOnsButtons(UserID);

                        /*
                        DataRelation relation1;
                        DataColumn table1Column1;
                        DataColumn table2Column1;
                        //retrieve column 
                        table1Column1 = dtPrivateCallAddOns.Tables[0].Columns["UserModuleID"];
                        table2Column1 = dtPrivateCallAddOns.Tables[1].Columns["UserModuleID"];
                        //relating tables 
                        relation1 = new DataRelation("relation", table1Column1, table2Column1, true);
                        //assign relation to dataset  
                        dtPrivateCallAddOns.Relations.Add(relation1);
                        */

                        lstPrivateCallButtons.DataSource = dtPrivateCallAddOns;
                        lstPrivateCallButtons.DataBind();
                    }

                    // Loading Tabs
                    LoadTabs();

                    DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
                    if (dtMobileAppSettings.Rows.Count > 0)
                    {
                        string xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                        Session["SettingID"] = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                        var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                        bool isMainPH = false;
                        //CONTACT DETAILS           
                        if (xmlTools.Element("Tools").Attribute("IsMainPH") != null)
                            isMainPH = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsMainPH").Value);
                        DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(ProfileID);
                        if (dtProfileDetails.Rows.Count > 0)
                        {
                            if (isMainPH)
                                hdnCall.Value = Convert.ToString(dtProfileDetails.Rows[0]["Profile_Phone1"]);
                            else
                                hdnCall.Value = Convert.ToString(dtProfileDetails.Rows[0]["Alternate_Phone"]);
                        }

                    }
                }
                if (addMobile)
                    AddMobileSttings(dtAddOns.Tables[0]);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAppButtons.aspx.cs", "LoadCustomModules()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }
        private void AddMobileSttings(DataTable dtAddOn)
        {
            // *** Adding follwing to update setting xml for 1.9.5 ***//
            DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
            string xmlSettings = string.Empty;
            bool isAboutUs = false; bool isUpdates = false; bool isSocialMedia = false; bool isPhotoAlbum = false;
            bool isEvents = false; bool isSurveys = false; bool isBulletins = false; bool isContactUs = false;
            bool isWebLinks = false; bool isSubmitTip = false; bool isNotificaton = false; bool isPhone = false;
            string aboutUsTabName = "";
            string updatesTabName = "";
            string galleryTabName = "";
            string eventsTabName = "";
            string bulletinsTabName = "";
            string weblinksTabName = "";
            string socialMediaTabName = "";
            string surveysTabName = "";
            string notification = "";
            string submitTip = "";
            for (int i = 0; i < dtAddOn.Rows.Count; i++)
            {
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Contact")
                {
                    isContactUs = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Call")
                {
                    isPhone = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "AboutUs")
                {
                    isAboutUs = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    aboutUsTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Updates")
                {
                    isUpdates = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    updatesTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Gallery")
                {
                    isPhotoAlbum = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    galleryTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "EventCalendar")
                {
                    isEvents = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    eventsTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Bulletins")
                {
                    isBulletins = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    bulletinsTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "WebLinks")
                {
                    isWebLinks = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    weblinksTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "SocialMedia")
                {
                    isSocialMedia = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    socialMediaTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Surveys")
                {
                    isSurveys = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    surveysTabName = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Notifications")
                {
                    isNotificaton = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    notification = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
                if (Convert.ToString(dtAddOn.Rows[i]["ButtonType"]) == "Tips")
                {
                    isSubmitTip = Convert.ToBoolean(dtAddOn.Rows[i]["IsVisible"]);
                    submitTip = Convert.ToString(dtAddOn.Rows[i]["TabName"]);
                }
            }
            bool isEnableMobileApp = true;
            bool isEmergencyNumber = false;
            bool isPhotoCapture = false;
            bool isGeoLocation = false;
            bool IsMainPH = false;
            bool isAnonymous = false;
            bool isSharing = false;
            string emergency = "";
            string altPhone = "";
            BusinessBLL objBus = new BusinessBLL();
            DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(ProfileID);
            if (dtProfileDetails.Rows.Count > 0)
            {
                if (Convert.ToString(dtProfileDetails.Rows[0]["EnableMobileApp"]) != "")
                    isEnableMobileApp = Convert.ToBoolean(dtProfileDetails.Rows[0]["EnableMobileApp"]);
                altPhone = Convert.ToString(dtProfileDetails.Rows[0]["Alternate_Phone"]);
            }
            int settingID = 0;
            if (dtMobileAppSettings.Rows.Count > 0)
            {
                settingID = Convert.ToInt32(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                Session["SettingID"] = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                    isEmergencyNumber = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value);
                if (xmlTools.Element("Tools").Attribute("IsPhotoCapture") != null)
                    isPhotoCapture = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsPhotoCapture").Value);
                if (xmlTools.Element("Tools").Attribute("IsGeoLocation") != null)
                    isGeoLocation = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsGeoLocation").Value);
                if (xmlTools.Element("Tools").Attribute("IsMainPH") != null)
                    IsMainPH = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsMainPH").Value);
                if (xmlTools.Element("Tools").Attribute("IsAnonymous") != null)
                    isAnonymous = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsAnonymous").Value);
                if (xmlTools.Element("Tools").Attribute("IsSharing") != null)
                    isSharing = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsSharing").Value);
                if (xmlTools.Element("Tools").Attribute("EmergencyNumber") != null)
                    emergency = Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value);

                StringBuilder mobileSettings = new StringBuilder();
                // *** Header section *** //
                mobileSettings.Append("<Tools BName='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value) + "' Logo='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) + "' ");
                mobileSettings.Append("Address='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value) + "' City='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value) + "' ");
                mobileSettings.Append("State='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value) + "' Country='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Country").Value) + "' ");
                mobileSettings.Append("ZipCode='" + Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value) + "' ");
                mobileSettings.Append("IsEmergencyNumber='" + isEmergencyNumber + "' EmergencyNumber='" + emergency + "' ");

                // *** Tabs section ***//
                mobileSettings.Append("HomeTabName='Home' ContactUsTabName='Contact Us' ");
                mobileSettings.Append("IsNotificaton='" + isNotificaton + "' NotificationTabName='" + notification + "' AboutUs='" + isAboutUs + "' AboutUsTabName='" + aboutUsTabName + "' ");
                mobileSettings.Append("Updates='" + isUpdates + "' UpdatesTabName='" + updatesTabName + "' Photos='" + isPhotoAlbum + "' MediaTabName='" + galleryTabName + "' ");
                mobileSettings.Append("Events='" + isEvents + "' EventsTabName='" + eventsTabName + "' IsBulletins='" + isBulletins + "' BulletinsTabName='" + bulletinsTabName + "' ");
                mobileSettings.Append("IsWebLinks='" + isWebLinks + "' WeblinksTabName='" + weblinksTabName + "' Social='" + isSocialMedia + "' SocialMediaTabName='" + socialMediaTabName + "' ");
                mobileSettings.Append("IsSurveys='" + isSurveys + "' SurveysTabName='" + surveysTabName + "' IsSubmitTip='" + isSubmitTip + "' SubmitTipName='" + submitTip + "' ");
                // *** Dispaly action section *** /
                mobileSettings.Append("PhoneNumber='" + isPhone + "' IsMainPH='" + IsMainPH + "' ");
                mobileSettings.Append("IsContatUs='" + isContactUs + "' ");

                mobileSettings.Append("IsPhotoCapture='" + isPhotoCapture + "' IsGeoLocation='" + isGeoLocation + "' ");
                mobileSettings.Append("IsSharing='" + isSharing + "'  IsAnonymous='" + isAnonymous + "'/>");

                xmlSettings = "<SubTools>" + mobileSettings.ToString() + "</SubTools>";
                if (settingID > 0)
                    objMobileApp.InsertMobileAppSettings(settingID, xmlSettings, UserID, isEnableMobileApp, CUserID, "", altPhone);
            }
            // *** End adding follwing to update setting xml for 1.9.5 ***//
        }
        protected void lvCustomModule_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList formDataList = e.Item.FindControl("dlCMForms") as DataList;
                if (formDataList != null)
                {
                    formDataList.DataSource = drv.CreateChildView("relation");
                    formDataList.DataBind();
                }
                PlaceHolder placeHolder = e.Item.FindControl("CategoryPlaceHolder") as PlaceHolder;
                Label lblType = e.Item.FindControl("lblType") as Label;
                switch (lblType.Text)
                {
                    case "PrivateAddOn":
                        lblType.Text = "Private Module";
                        placeHolder.Visible = false;
                        break;
                    case "PrivateCallAddOns":
                        lblType.Text = "Private Call Module";
                        placeHolder.Visible = false;
                        break;
                    case "PublicCallAddOns":
                        lblType.Text = "SmartConnect Module";
                        placeHolder.Visible = false;
                        break;
                    case "PrivateSmartConnectAddOns":
                        lblType.Text = "Private QR Connect";
                        placeHolder.Visible = false;
                        break;
                    default:
                        //placeHolder.Visible = true;
                        lblType.Text = "";
                        break;
                }

            }
        }
        protected void lnkChange_Click(object sender, EventArgs e)
        {
            LinkButton lnkModify = sender as LinkButton;
            int userModuleID = Convert.ToInt32(lnkModify.CommandArgument);
            DataTable dtAddOn = objAddOn.GetAddOnById(userModuleID);
            DataTable dtCustomModuleAppIcons = new DataTable("dtCustomModuleAppIcons");
            if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns || dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateCallAddOns)
            {
                dtCustomModuleAppIcons = objAgency.GetCustomModuleAppIcons(userModuleID, DomainName, true);
            }
            else
            {
                dtCustomModuleAppIcons = objAgency.GetCustomModuleAppIcons(userModuleID, DomainName, false);
            }
            hdnModuleTemplateID.Value = userModuleID.ToString();

            DataTable dtCustomModule = objAddOn.GetUserCustomModuleById(userModuleID);
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
        protected void lnkDeactivate_Click(object sender, EventArgs e)
        {
            LinkButton lnkDeacticate = sender as LinkButton;
            int userModuleID = Convert.ToInt32(lnkDeacticate.CommandArgument);
            hdnUserModuleID.Value = userModuleID.ToString();
            DataTable dtActiveForms = objAddOn.GetActiveForms(userModuleID, null);
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
                }
                if (hasActives == false)
                    lblstatusmessage.Text = "<font face=arial size=2 color=red>Currently there are no active forms to remove.</font>";
            }
        }
        protected void lnkDeactivateForms_Click(object sender, EventArgs e)
        {
            if (dlDeactivate.Items.Count > 0)
            {
                foreach (DataListItem item in dlDeactivate.Items)
                {
                    CheckBox chkDeactivate = item.FindControl("chkDeactivate") as CheckBox;
                    if (chkDeactivate.Checked)
                    {
                        int formID = Convert.ToInt32(dlDeactivate.DataKeys[item.ItemIndex]);
                        objAddOn.InsertPurchasedForms(formID, Convert.ToInt32(hdnUserModuleID.Value), 0, CUserID, false);
                    }
                }
            }
            lblstatusmessage.Text = "<font face=arial size=2 color=green>Selected forms have been removed successfully for " + hdnTabName.Value + " button.</font>";
            LoadCustomModules(false, false);
        }
        protected void lnkAddMore_Click(object sender, EventArgs e)
        {
            LinkButton lnkAddMore = sender as LinkButton;
            int userModuleID = Convert.ToInt32(lnkAddMore.CommandArgument);
            hdnUserModuleID.Value = userModuleID.ToString();
            DataTable dtRemaining = objAddOn.GetRemainingForms(userModuleID, DomainName, UserID);
            if (dtRemaining.Rows.Count > 0)
            {
                hdnTabName.Value = Convert.ToString(dtRemaining.Rows[0]["TabName"]);
                dlRemaingForms.DataSource = dtRemaining;
                dlRemaingForms.DataBind();
                ModalRemaing.Show();
            }
            else
                lblstatusmessage.Text = "<font face=arial size=2 color=red>Currently there are no active forms to add to " + hdnTabName.Value + " button.</font>";
        }
        protected void lnkAddMoreForms_Click(object sender, EventArgs e)
        {
            if (dlRemaingForms.Items.Count > 0)
            {
                foreach (DataListItem item in dlRemaingForms.Items)
                {
                    CheckBox chkRemaining = item.FindControl("chkRemaining") as CheckBox;
                    if (chkRemaining.Checked)
                    {
                        int moduleID = Convert.ToInt32(dlRemaingForms.DataKeys[item.ItemIndex]);
                        objAddOn.InsertPurchasedForms(0, Convert.ToInt32(hdnUserModuleID.Value), moduleID, CUserID, true);
                    }
                }
            }
            lblstatusmessage.Text = "<font face=arial size=2 color=green>Selected forms have been added successfully for " + hdnTabName.Value + " button.</font>";
            LoadCustomModules(false, false);
        }
        protected void btncancelupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            objAddOn.UpdateCustomModuleIcon(Convert.ToInt32(hdnModuleTemplateID.Value), chkIndVisible.Checked, txtAppButtonName.Text, hdnModuleAppButton.Value, false, CUserID);
            lblstatusmessage.Text = "<font face=arial size=2 color=green>Your selections have been saved successfully.</font>";
            objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "MobileAppButtons", "MobileAppButtonChanging");
            hdnModuleAppButton.Value = "";
            hdnModuleTemplateID.Value = "";
            LoadCustomModules(true, false);
            ModalCustomModule.Hide();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ListView savelstivewdata = new ListView();
            if (hdnSelectedTab.Value == "1")
            {
                savelstivewdata = lvCustomModule;

            }
            else
            {
                savelstivewdata = lstPrivateCallButtons;
            }

            if (savelstivewdata.Items.Count > 0)
            {
                foreach (ListViewDataItem item in savelstivewdata.Items)
                {
                    CheckBox chkVisible = item.FindControl("chkVisible") as CheckBox;
                    LinkButton lnkChange = item.FindControl("lnkChange") as LinkButton;
                    objAddOn.UpdateCustomModuleIcon(Convert.ToInt32(lnkChange.CommandArgument), chkVisible.Checked, "", "", true, CUserID);
                }
                Session["AppButtonSuccess"] = "<font face=arial size=2 color=green>Your selections have been saved successfully.</font>";
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "MobileAppButtons", "OrderNumberChange");
            }

            LoadCustomModules(true, true); // *** adding send parameter to update mobile app settings only *** //

            Response.Redirect(RootPath + "/Business/MyAccount/ManageAppButtons.aspx?stab=" + hdnSelectedTab.Value);
        }
        protected void lnkCall_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyProfileDetails.aspx?App=2");
        }
        protected void lnkInvitations_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Session["CustomModuleID"] = lnk.CommandArgument;
            Response.Redirect(RootPath + "/Business/MyAccount/SetupInvitation.aspx");
        }
        [WebMethod]
        public static string UpdateItemsOrder(string itemOrder)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            string _result = "failed";
            try
            {
                AddOnBLL objAddOn = new AddOnBLL();
                if (itemOrder.Length > 0)
                {
                    if (HttpContext.Current.Session["UserID"] != null)
                    {
                        int CUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                        if (HttpContext.Current.Session["C_USER_ID"] != null && HttpContext.Current.Session["C_USER_ID"].ToString() != "")
                            CUserID = Convert.ToInt32(HttpContext.Current.Session["C_USER_ID"]);
                        string[] strBulletinOrder = itemOrder.Split(',');
                        for (int i = 0; i < strBulletinOrder.Length; i++)
                        {
                            objAddOn.UpdateAppButtnOrder(Convert.ToInt32(strBulletinOrder[i]), i + 1, CUserID);
                        }
                    }

                }
                _result = "success";
            }
            catch (Exception ex)
            {
                //Error 
                _result = ex.Message;
                objInBuiltData.ErrorHandling("ERROR", "ManageAppButtons.aspx.cs", "UpdateItemsOrder", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return _result;
        }

        protected void lnkDefault_OnClick(object sender, EventArgs e)
        {
            hdnSelectedTab.Value = "1";
            if (IsHasPrivilege)
                LoadCustomModules(false, false);
        }

        protected void lnkPirvateCall_OnClick(object sender, EventArgs e)
        {
            hdnSelectedTab.Value = "2";
            if (IsHasPrivilege)
                LoadCustomModules(false, false);
        }

        private void LoadTabs()
        {
            if (hdnSelectedTab.Value == "1")
            {
                pnlDefaultButtons.Visible = true;
                pnlPrivateCallButtons.Visible = false;

                lnkDefault.Text = "<img src='../../Images/Dashboard/Default_h.png'  border='0'/>";
                lnkPirvateCall.Text = "<img src='../../Images/Dashboard/PrivateCall.png'  border='0'/>";
            }
            else
            {
                pnlDefaultButtons.Visible = false;
                pnlPrivateCallButtons.Visible = true;

                lnkDefault.Text = "<img src='../../Images/Dashboard/Default.png'  border='0'/>";
                lnkPirvateCall.Text = "<img src='../../Images/Dashboard/PrivateCall_h.png'  border='0'/>";
            }
        }

    }
}