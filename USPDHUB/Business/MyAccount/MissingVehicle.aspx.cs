using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using USPDHUBBLL;
using System.Xml.Linq;
using System.Text;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using Aurigma.GraphicsMill.Transforms;
using System.Text.RegularExpressions;

namespace USPDHUB.Business.MyAccount
{
    public partial class MissingVehicle : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";
        public string BulletinXML = string.Empty;
        string BulletinHtml = string.Empty;
        public int BulletinID = 0;
        public int BulletinCheckID = 0;
        public int TemplateBID = 0;
        public string BulletinName = string.Empty;
        public string urlinfo = string.Empty;
        public int C_UserID = 0;
        bool IsPhoneNumber = true;
        bool IsContatUs = true;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        StringBuilder strPrintHtml;
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingVehicle.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                if (Session["userid"] == null || Session["ProfileID"] == null)
                {
                    urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                {
                    BulletinID = Convert.ToInt32(Session["BulletinID"]);
                    BulletinCheckID = Convert.ToInt32(Session["BulletinID"]);
                }
                else
                {
                    urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
                }
                if (Session["TemplateBID"] != null)
                    TemplateBID = Convert.ToInt32(Session["TemplateBID"]);
                if (Session["BulletinName"] != null)
                    BulletinName = Session["BulletinName"].ToString();
                /*** Store Module Functionality ***/
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduleEmails = true;
                }
                if (!IsPostBack)
                {
                    //USPD-1113 Auto populate current date
                    CommonBLL objCommon = new CommonBLL();
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    txtBulletinDate.Text = dtNow.ToShortDateString();
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel3.Visible = true;
                            UpdatePanel2.Visible = UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create content.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here

                    LoadDefaultData();
                    if (BulletinID > 0)
                        LoadFormData();
                    GetAutoShareRecordStatus();
                }
                lblPublish.Text = hdnPublishTitle.Value;
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayImage();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            try
            {
                if (BulletinID > 0)
                {
                    DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("Bulletin", BulletinID, BulletinName);
                    for (int i = 0; i < dtShareRecords.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Facebook")
                            hdnFacebook.Value = "true";

                        if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Twitter")
                            hdnTwitter.Value = "true";
                    }
                }
                if (hdnFacebook.Value != "false")
                {
                    DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
                    if (dtExistingFbUsersData.Rows.Count > 0)
                    {
                        chkFbAutoPost.Visible = true;
                        for (int i = 0; i < 1; i++) // To Share on Facebook Timeline
                        {
                            if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["IsAutoShare"].ToString()) == true)
                            {
                                chkFbAutoPost.Checked = true;
                            }
                        }
                    }
                    else
                        hdnFacebook.Value = "false";
                }
                if (hdnTwitter.Value != "false")
                {
                    DataTable dtExistingTwrUserData = smb.GetTwitterDataByUserID(ProfileID);
                    if (dtExistingTwrUserData.Rows.Count > 0)
                    {
                        chkTwrAutoPost.Visible = true;
                        for (int j = 0; j < dtExistingTwrUserData.Rows.Count; j++)
                        {
                            if (Convert.ToBoolean(dtExistingTwrUserData.Rows[j]["IsAutoPost"].ToString()) == true)
                            {
                                chkTwrAutoPost.Checked = true;
                            }
                        }
                    }
                    else
                        hdnTwitter.Value = "false";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingVehicle.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtColors = objInBuiltData.GetBulletinLabelData();
                DataRow[] drColors = dtColors.Select("Type='Color'");
                foreach (DataRow row in drColors)
                {
                    ddlColors.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }
                ddlColors.Items.Insert(0, new ListItem("Select", ""));
                DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID);
                if (dtCategories.Rows.Count > 0)
                {
                    ddlCategories.DataSource = dtCategories;
                    ddlCategories.DataTextField = "Category_Name";
                    ddlCategories.DataValueField = "Category_Name";
                    ddlCategories.DataBind();

                    if (Session["BulletinCategoryName"] != null)
                    {
                        ddlCategories.SelectedValue = Session["BulletinCategoryName"].ToString();
                    }
                }
                //body style
                DataRow[] drBodyStyle = dtColors.Select("Type='BodyStyle'");
                foreach (DataRow row in drBodyStyle)
                {
                    ddlBodyStyles.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }

                ddlBodyStyles.Items.Insert(0, new ListItem("Select", ""));
                // ddlBodyStyles.SelectedValue = "Pickup";

                // *** Checking Global mobile app settings *** //
                DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                if (dtSelectedTools.Rows.Count > 0)
                {
                    string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                    var XMLTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                    IsPhoneNumber = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("PhoneNumber").Value);
                    IsContatUs = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value);
                    if (IsPhoneNumber)
                    {
                        divSettings.Visible = true;
                    }
                    else
                    {
                        divSettings.Visible = false;
                        chkCall.Checked = false;
                    }
                    if (IsContatUs)
                        divContactUs.Visible = true;
                    else
                    {
                        divContactUs.Visible = false;
                        chkContact.Checked = false;
                    }
                }
                else
                {
                    divCall.Visible = false;
                    chkCall.Checked = false;
                    divContactUs.Visible = false;
                    chkContact.Checked = false;
                }
                hdnArchive.Value = "false";
                //DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                //if (dtProfile.Rows.Count > 0)
                //{
                //    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()))
                //        lblLogo.Text = objInBuiltData.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, ProfileID);

                //}
                //lblHeaderAddress.Text = objCommon.GetBulletinFormHeader(UserID, ProfileID);
                lblLogoHeader.Text = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "LoadDefaultData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingVehicle.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                if (dtFormData.Rows.Count > 0)
                {
                    BulletinID = Convert.ToInt32(dtFormData.Rows[0]["Bulletin_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
                    BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                    var XMLForm = XElement.Parse(BulletinXML, LoadOptions.PreserveWhitespace);

                    if (XMLForm.Element("Bulletin").Attribute("IsCleared") != null)
                        chkCleared.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsCleared").Value);

                    hdnMissingVeh.Value = XMLForm.Element("Bulletin").Attribute("Vehicle").Value;
                    if (XMLForm.Element("Bulletin").Attribute("VehicleLink") != null)
                        hdnMissingVehLink.Value = XMLForm.Element("Bulletin").Attribute("VehicleLink").Value;
                    txtMake.Text = XMLForm.Element("Bulletin").Attribute("Make").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtModel.Text = XMLForm.Element("Bulletin").Attribute("Model").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    ddlBodyStyles.SelectedValue = XMLForm.Element("Bulletin").Attribute("Style").Value.Replace("&apos;", "'");
                    txtMfdYear.Text = XMLForm.Element("Bulletin").Attribute("Year").Value;
                    ddlColors.SelectedValue = XMLForm.Element("Bulletin").Attribute("Color").Value;
                    ddlState.SelectedValue = XMLForm.Element("Bulletin").Attribute("State").Value;
                    txtLcsPlate.Text = XMLForm.Element("Bulletin").Attribute("LcsPlate").Value.Replace("&apos;", "'");
                    txtMarks.Text = XMLForm.Element("Bulletin").Attribute("Marks").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtLSD.Text = XMLForm.Element("Bulletin").Attribute("LastSeenDate").Value;
                    txtRemarks.Text = XMLForm.Element("Bulletin").Attribute("Remarks").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");

                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Expiration_Date"].ToString()))
                    {
                        txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                    }
                    else
                    {
                        txtExHours.Enabled = false;
                        txtExMinutes.Enabled = false;
                        ddlExSS.Enabled = false;
                    }

                    txtExHours.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExHours").Value);
                    txtExMinutes.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExMinutes").Value);
                    ddlExSS.SelectedValue = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExSS").Value);

                    if (XMLForm.Element("Bulletin").Attribute("BulletinDate") != null)
                    {
                        txtBulletinDate.Text = XMLForm.Element("Bulletin").Attribute("BulletinDate").Value;
                    }

                    rbPrivate.Checked = true;
                    if (Convert.ToBoolean(dtFormData.Rows[0]["IsPrivate"].ToString()) == false)
                    {
                        rbPublic.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }
                    hdnArchive.Value = dtFormData.Rows[0]["IsArchive"].ToString();
                    if (!File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + BulletinID.ToString() + ".jpg"))
                    {
                        objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
                    }
                    chkCall.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsCall"].ToString());
                    chkContact.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsContactUs"].ToString());
                    if (IsPhoneNumber == false)
                        chkCall.Checked = false;
                    if (IsContatUs == false)
                        chkContact.Checked = false;
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Publish_Date"].ToString()))
                    {
                        DateTime dtPublish = Convert.ToDateTime(dtFormData.Rows[0]["Publish_Date"]);
                        if (DateTime.Compare(dtPublish, dtNow) < 0)
                            txtPublishDate.Text = dtNow.ToShortDateString();
                        else
                            txtPublishDate.Text = dtPublish.ToShortDateString();
                    }
                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Bulletin_Category"].ToString()))
                        ddlCategories.SelectedValue = dtFormData.Rows[0]["Bulletin_Category"].ToString();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "LoadFormData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveSession();
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingVehicle.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                string LSMonth = string.Empty;
                string LSDay = string.Empty;
                string LSYear = string.Empty;
                bool addflag = true;
                DateTime? dateExpires;
                DateTime? datePublish;
                DateTime? dateBulletin;
                dateExpires = null;
                datePublish = null;
                dateBulletin = null;

                string ExHour = "";
                string ExMin = "";
                string ExSS = "AM";
                var ExTime = "";
                bool IsPublish = true;
                bool IsPrivate = true;
                int? id = null;
                if (rbPublic.Checked)
                {
                    IsPublish = false;
                    publishValue = "2";
                }
                if (rbPrivate.Checked)
                    IsPrivate = false;
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtBulletinDate.Text.Trim() != "")
                {
                    dateBulletin = Convert.ToDateTime(txtBulletinDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtBulletinDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && BulletinID == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate.Replace("Expiration", "Bulletin") + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                }
                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && BulletinID == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                }
                if (txtExpires.Text.Trim() != "")
                {
                    string ExpDateTime = "";
                    if (!string.IsNullOrEmpty(txtExpires.Text.Trim()))
                    {
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                        if (!string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " " + txtExHours.Text + ":" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (!string.IsNullOrEmpty(txtExHours.Text) && string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " " + txtExHours.Text + ":00:00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " 12:" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " 12:00:00 AM";
                        }
                    }
                    if (Convert.ToDateTime(ExpDateTime) < dtToday)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                    else
                    {
                        if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
                        {
                            ExHour = txtExHours.Text;
                            if (ExHour == "")
                                ExHour = "12";
                            ExMin = txtExMinutes.Text;
                            if (ExMin == "")
                                ExMin = "00";
                            ExSS = ddlExSS.SelectedValue.ToString();

                            ExTime = ExHour + ":" + ExMin + ":00 " + ExSS;
                        }
                        else
                        {
                            ExHour = "12";
                            ExMin = "00";
                            ExSS = "AM";

                            ExTime = ExHour + ":" + ExMin + ":00 " + ExSS;
                        }
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + ExTime);
                    }
                }
                if (txtLSD.Text.Trim() != "")
                {
                    DateTime LSDate = Convert.ToDateTime(txtLSD.Text.Trim());
                    LSMonth = LSDate.Month.ToString();
                    LSDay = LSDate.Date.ToString();
                    LSYear = LSDate.Year.ToString();
                    if (DateTime.Compare(LSDate, Convert.ToDateTime(dtToday.ToShortDateString())) == 1)
                    {
                        lblerror.Text = lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.LastSeenDate + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                }
                if (txtMfdYear.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtMfdYear.Text.Trim()) > dtToday.Year)
                    {
                        lblerror.Text = lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.Manufacturedyear + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                }
                if (addflag)
                {

                    Image objImgage = new Image();
                    objImgage.ImageUrl =
                    BulletinXML = "<Bulletin Vehicle='" + hdnMissingVeh.Value + "' VehicleLink='" + hdnMissingVehLink.Value + "' Make='" + txtMake.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'  Model='" + txtModel.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'  Style='" + ddlBodyStyles.SelectedValue.ToString() + "'  Year='" + txtMfdYear.Text.Trim() + "' Color='" + ddlColors.SelectedValue + "' State='" + ddlState.SelectedValue.ToString() + "'" +
                                    "  LcsPlate='" + txtLcsPlate.Text.Trim().Replace("'", "&apos;") + "'  Marks='" + txtMarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'  LSMonth='" + LSMonth + "' LSDay='" + LSDay + "' LSYear='" + LSYear + "' LastSeenDate='" + txtLSD.Text.Trim() + "'" +
                                    "  Remarks='" + txtRemarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' IsCleared='" + chkCleared.Checked + "' BulletinDate='" + txtBulletinDate.Text + "'" +
                                    " ExHours='" + ExHour + "' ExMinutes='" + ExMin + "' ExSS='" + ExSS + "'   />";
                    BulletinXML = "<Bulletins>" + BulletinXML + "</Bulletins>";
                    BulletinHtml = BuildHTML();
                    BulletinHtml = BuildLocatedImage(BulletinHtml);

                    string customFormHeader = objCommon.GetCustomFormHeader(UserID);
                    string printerHtml = strPrintHtml.ToString().Replace("###CustomFormHeader###", customFormHeader);

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //A for author
                        {
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID,
                                C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish,
                                dateExpires, datePublish, ddlCategories.SelectedValue, false, id, printerHtml);
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), BulletinID, PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.SVEHICLE, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            if (IsPrivate == true)
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                    C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                    IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml);
                            else
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                    C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                    IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, id, printerHtml);
                        }
                    }
                    else
                    {
                        if (IsPrivate == true)
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml,
                                BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false,
                                chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml);
                        else
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, id, printerHtml);
                    }

                    /************************************ Auto Share ***************************************/
                    if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                    {
                        if (IsPrivate)
                        {
                            if (chkFbAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("Bulletin", BulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, C_UserID, BulletinName);
                            if (chkTwrAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("Bulletin", BulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, C_UserID, BulletinName);
                        }
                    }
                    if (BulletinCheckID > 0)
                    {
                        if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                            objCommon.UpdateSentFlag(BulletinID, 2, 0, "Bulletin");
                    }
                    /****** Auto Share Completed ******/

                    objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    RemoveSession();
                    urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
        }

        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
            Session.Remove("TemplateBID");
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                lblbulletinamme.Text = BulletinName;
                string plainHtmlStr = BuildHTML();
                plainHtmlStr = BuildLocatedImage(plainHtmlStr);

                string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", plainHtmlStr.Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));
                lblPreview.Text = htmlString;
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingVehicle.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);

                StringBuilder strHtml = new StringBuilder();

                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; text-align:left;\">");
                //strPrintHtml.Append("###CustomFormHeader###");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">Stolen Vehicle</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");

                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;\">");

                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Stolen Vehicle</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px;  text-align:left;'>");
                //*** Image Binding
                if (hdnMissingVeh.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    if (hdnMissingVehLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnMissingVeh.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"font-weight: bold;  text-align:center; float: left; margin-right: 10px; margin-top: 5px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><img src=\"" + hdnMissingVeh.Value + "\" /></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnMissingVehLink.Value + "' target='_blank'><img src='" + hdnMissingVeh.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"font-weight: bold;  text-align:center; float: left; margin-right: 10px; margin-top: 5px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><a href='" + hdnMissingVehLink.Value + "' target='_blank'><img src='" + hdnMissingVeh.Value + "'/></a></div>");
                    }
                    strHtml.Append("</td></tr>");
                }

                if (hdnMissingVeh.Value == "" && chkCleared.Checked == true)
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    strHtml.Append("<img src=\"" + RootPath + "/images/located.png\"/>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + RootPath + "/images/located.png\"/></div>");

                }

                //*** Bulletin Date
                if (txtBulletinDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td width='48%' style='page-break-inside: avoid; padding: 4px;'>Date :</td>");
                    strHtml.Append("<td width='52%' style='page-break-inside: avoid; color: #353535;'>" + txtBulletinDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Date :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtBulletinDate.Text.Trim() + "</div>");
                }

                //*** Make
                if (txtMake.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Make : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtMake.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Make :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtMake.Text.Trim() + "</div>");
                }
                //*** Model
                if (txtModel.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Model : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtModel.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Model :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtModel.Text.Trim() + "</div>");
                }
                //*** Body Styles
                if (ddlBodyStyles.SelectedValue.ToString() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; page-break-inside: avoid; padding: 4px;'>Body Style : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; page-break-inside: avoid; color: #353535;'>" + ddlBodyStyles.SelectedValue.ToString() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Body Style :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + ddlBodyStyles.SelectedValue.ToString() + "</div>");
                }
                //*** Year
                if (txtMfdYear.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Year : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtMfdYear.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Year :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtMfdYear.Text.Trim() + "</div>");
                }
                //*** Colors
                if (ddlColors.SelectedValue.ToString() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Color : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlColors.SelectedValue.ToString() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Color :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + ddlColors.SelectedValue.ToString() + "</div>");
                }
                //***  State
                if (ddlState.SelectedValue.ToString() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>State : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlState.SelectedValue.ToString() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">State :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + ddlState.SelectedValue.ToString() + "</div>");
                }
                //*** License Number
                if (txtLcsPlate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>License Number : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtLcsPlate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">License Number :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtLcsPlate.Text.Trim() + "</div>");
                }
                //*** Distingushing Marks
                if (txtMarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Distinguishing Marks :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Distinguishing Marks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                //*** Date Last Seen
                if (txtLSD.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Date Last Seen : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + Convert.ToDateTime(txtLSD.Text.Trim()).ToString("MMMM dd, yyyy") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Date Last Seen :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + Convert.ToDateTime(txtLSD.Text.Trim()).ToString("MMMM dd, yyyy") + "</div>");
                }
                //*** Additional Information
                if (txtRemarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: red; padding: 6px 4px 0px 4px;'>Remarks :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtRemarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; color:red; font-weight: bold; float: left; width: 156px; margin-right: 10px; margin-top: 5px;\">Remarks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 444px; margin-top: 5px;\">" + txtRemarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");

                }
                strHtml.Append("</table></div>");
                BulletinHtml = strHtml.ToString().Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);

                // PDF Print HTML
                strPrintHtml.Append("</div>");
                strPrintHtml.Append("</div>");

                return BulletinHtml;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;

            }
        }

        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingVehicle.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);

                string strHeader = "";
                string strfilepath = Server.MapPath("~") + "\\BulletinPreview\\CommonHeader.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    strHeader = strHeader + input;
                }
                re.Close();
                re.Dispose();
                strHeader = strHeader.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfile.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()))
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    else
                        strHeader = strHeader.Replace("#BusinessProfileName#", "");
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()))
                        strHeader = strHeader.Replace("#HeaderLogo#", objInBuiltData.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, ProfileID));
                    else
                        strHeader = strHeader.Replace("#HeaderLogo#", "");
                    strHeader = strHeader.Replace("#EmergencyNumber#", "");
                }
                else
                {
                    strHeader = strHeader.Replace("#HeaderLogo#", "").Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "");
                }
                return strHeader;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        private string BuildLocatedImage(string htmlString)
        {
            try
            {
                if (chkCleared.Checked == true)
                {
                    string imagePath = "";
                    string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                    MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (Match m in matchesImgSrc)
                    {
                        imagePath = m.Groups[1].Value;
                        if (imagePath.ToLower().Contains("images/located.png") || imagePath.ToLower().Contains("images/cleared.png"))
                        {
                            imagePath = "";
                        }
                        else
                        { break; }
                    }

                    // Without image time Means Only Text
                    if (imagePath.Trim() == string.Empty)
                    {

                    }
                    else
                    {
                        string uspdUploadFolderPath = HttpContext.Current.Server.MapPath("~/upload");
                        string imgName = Path.GetFileName(imagePath);
                        string imgExt = Path.GetExtension(imgName).ToLower();
                        string filenameWithoutExt = Path.GetFileNameWithoutExtension(imagePath);

                        string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                        FOlderPath = FOlderPath.Replace("upload", "");
                        string olgImgPath = uspdUploadFolderPath + FOlderPath;
                        string newImgPath = olgImgPath.Replace(filenameWithoutExt.ToLower(), filenameWithoutExt.ToLower() + "_located");
                        if (!File.Exists(newImgPath))
                        {
                            string locatedImage = HttpContext.Current.Server.MapPath("~/images");
                            locatedImage = locatedImage + "\\located" + ".png";

                            //Load background image
                            Aurigma.GraphicsMill.Bitmap bitmap =
                                new Aurigma.GraphicsMill.Bitmap(olgImgPath);

                            //Load small image (foreground image)
                            Aurigma.GraphicsMill.Bitmap smallBitmap =
                                new Aurigma.GraphicsMill.Bitmap(locatedImage);

                            //Draw foreground image on background with transparency
                            bitmap.Draw(smallBitmap, 30, bitmap.Height - smallBitmap.Height - 10,
                               smallBitmap.Width, smallBitmap.Height,
                                Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, ResizeInterpolationMode.High);

                            bitmap.Save(newImgPath);

                            /*
                            int Height = 158;
                            int Width = 60;
                            if (imgExt == ".png")
                            {
                                PngImageWritter(olgImgPath, locatedImage, newImgPath, Width, 0);
                            }
                            else if (imgExt == ".jpg" || imgExt == ".jpeg")
                            {
                                JpegImageWritter(olgImgPath, locatedImage, newImgPath, Width, 0);
                            }
                            else if (imgExt == ".bmp")
                            { BmpImageWritter(olgImgPath, locatedImage, newImgPath, Width, 0); }
                            */
                        }

                        htmlString = htmlString.Replace(filenameWithoutExt, filenameWithoutExt + "_located");
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "BuildLocatedImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return htmlString;
        }

        private void PngImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            try
            {
                using (var reader = new JpegReader(generatedImgpath))
                using (var watermark = new PngReader(uploadedfilepath))
                using (var combiner = new Combiner())
                using (var writer = new PngWriter(filepath))
                {
                    var overlay = new Aurigma.GraphicsMill.Pipeline();
                    overlay.Add(watermark);
                    overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                    combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                    combiner.TopImage = overlay;
                    combiner.X = originX;
                    combiner.Y = originY;
                    combiner.AutoDisposeTopImage = true;
                    Pipeline.Run(reader + combiner + writer);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "PngImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void JpegImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            try
            {
                using (var reader = new JpegReader(generatedImgpath))
                using (var watermark = new JpegReader(uploadedfilepath))
                using (var combiner = new Combiner())
                using (var writer = new JpegWriter(filepath))
                {
                    var overlay = new Aurigma.GraphicsMill.Pipeline();
                    overlay.Add(watermark);
                    overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                    combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                    combiner.TopImage = overlay;
                    combiner.X = originX;
                    combiner.Y = originY;
                    combiner.AutoDisposeTopImage = true;
                    Pipeline.Run(reader + combiner + writer);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "JpegImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BmpImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            try
            {
                using (var reader = new JpegReader(generatedImgpath))
                using (var watermark = new BmpReader(uploadedfilepath))
                using (var combiner = new Combiner())
                using (var writer = new BmpWriter(filepath))
                {
                    var overlay = new Aurigma.GraphicsMill.Pipeline();
                    overlay.Add(watermark);
                    overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                    combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                    combiner.TopImage = overlay;
                    combiner.X = originX;
                    combiner.Y = originY;
                    combiner.AutoDisposeTopImage = true;
                    Pipeline.Run(reader + combiner + writer);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingVehicle.aspx.cs", "BmpImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


    }
}