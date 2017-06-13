using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class MissingPersonRisk : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string BulletinXML = string.Empty;
        public string BulletinHtml = string.Empty;
        public int BulletinID = 0;
        public int TemplateBID = 0;
        public string BulletinName = string.Empty;
        public string urlinfo = string.Empty;
        public int C_UserID = 0;
        bool IsPhoneNumber = true;
        bool IsContatUs = true;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null || Session["ProfileID"] == null)
                {
                    urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
                // *** Get Domain Name *** //
                RootPath = Session["RootPath"].ToString();
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                    BulletinID = Convert.ToInt32(Session["BulletinID"]);
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
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel3.Visible = true;
                            UpdatePanel2.Visible = UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You have no pervilages to create or edit app bulletin.</font>";
                        }
                    }
                    //ends here

                    LoadDefaultData();
                    if (BulletinID > 0)
                        LoadFormData();
                    GetAutoShareRecordStatus();
                }
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayImage();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "Page_Load", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
                DataRow[] drGender = dtLabelData.Select("Type='Gender'");
                foreach (DataRow row in drGender)
                {
                    ddlGender.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }

                DataRow[] drEyes = dtLabelData.Select("Type='Eyes'");
                foreach (DataRow row in drEyes)
                {
                    ddlEyes.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }
                ddlEyes.Items.Insert(0, new ListItem("Select", ""));

                DataRow[] drHair = dtLabelData.Select("Type='Hair'");
                foreach (DataRow row in drHair)
                {
                    ddlHair.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }
                ddlHair.Items.Insert(0, new ListItem("Select", ""));

                DataRow[] drComplexion = dtLabelData.Select("Type='Complexion'");
                foreach (DataRow row in drComplexion)
                {
                    ddlCompletion.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }
                ddlCompletion.Items.Insert(0, new ListItem("Select", ""));

                DataRow[] drRace = dtLabelData.Select("Type='Race'");
                foreach (DataRow row in drRace)
                {
                    ddlRace.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }
                DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID);
                if (dtCategories.Rows.Count > 0)
                {
                    ddlCategories.DataSource = dtCategories;
                    ddlCategories.DataTextField = "Category_Name";
                    ddlCategories.DataValueField = "Category_Name";
                    ddlCategories.DataBind();
                }
                ddlRace.Items.Insert(0, new ListItem("Select", ""));
                ddlRace.Items.Insert(0, new ListItem("Select", ""));
                ddlFeet.DataSource = objInBuiltData.GetHeightFeet();
                ddlFeet.DataTextField = "Text";
                ddlFeet.DataValueField = "Value";
                ddlFeet.DataBind();
                ddlInches.DataSource = objInBuiltData.GetHeightInches();
                ddlInches.DataTextField = "Text";
                ddlInches.DataValueField = "Value";
                ddlInches.DataBind();
                // *** Checking Global mobile app settings *** //
                DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                if (dtSelectedTools.Rows.Count > 0)
                {
                    string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                    var XMLTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                    IsPhoneNumber = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("PhoneNumber").Value);
                    IsContatUs = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value);
                    if (IsPhoneNumber)
                        divCall.Visible = true;
                    else
                    {
                        divCall.Visible = false;
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
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "LoadDefaultData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LoadFormData()
        {
            try
            {
                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
                BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(BulletinXML);
                hdnDefaultPerson.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Photopath").Value;
                txtLastName.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@LName").Value.Replace("&apos;", "'");
                txtFirstName.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@FName").Value.Replace("&apos;", "'");
                txtNickName.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@NName").Value.Replace("&apos;", "'");
                txtDOB.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@DateOfBirth").Value;
                txtAge.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Age").Value.Replace("&apos;", "'");
                ddlGender.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Gender").Value;
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@HeightFeet") != null && xmldoc.SelectSingleNode("Bulletins/Bulletin/@HeightInches") != null)
                {
                    ddlFeet.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@HeightFeet").Value;
                    ddlInches.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@HeightInches").Value;
                }
                else
                {
                    string Height = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Height").Value;
                    if (Height != "")
                    {
                        Height = Height.Replace(" ft", "");
                        string[] totalHeight = Height.Split('.');
                        ddlFeet.SelectedValue = totalHeight[0];
                        if (totalHeight.Length == 2)
                            ddlInches.SelectedValue = totalHeight[1];
                    }
                }
                txtWeight.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Weight").Value.Replace("&apos;", "'");
                ddlEyes.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Eyes").Value;
                ddlHair.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Hair").Value;
                ddlCompletion.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Complexion").Value;
                ddlRace.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Race").Value;
                txtNationality.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Nationality").Value.Replace("&apos;", "'");
                txtDistinguishing_Marks.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Dist_Marks").Value.Replace("&apos;", "'");
                txtLCD.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@LastContactDate").Value;
                txtRemarks.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Remarks").Value.Replace("&apos;", "'");
                if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Expiration_Date"].ToString()))
                    txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Publish_Date"].ToString()))
                {
                    DateTime dtPublish = Convert.ToDateTime(dtFormData.Rows[0]["Publish_Date"]);
                    if (DateTime.Compare(dtPublish, dtNow) < 0)
                        txtPublishDate.Text = dtNow.ToShortDateString();
                    else
                        txtPublishDate.Text = dtPublish.ToShortDateString();
                }
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@ImageLink") != null)
                {
                    hdnLink.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@ImageLink").Value;
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
                if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Bulletin_Category"].ToString()))
                    ddlCategories.SelectedValue = dtFormData.Rows[0]["Bulletin_Category"].ToString();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "LoadFormData", ex.Message,
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
            try
            {
                string DOBMonth = string.Empty;
                string DOBDay = string.Empty;
                string DOBYear = string.Empty;
                string LCMonth = string.Empty;
                string LCDay = string.Empty;
                string LCYear = string.Empty;
                bool addflag = true;
                DateTime? dateExpires;
                DateTime? datePublish;
                dateExpires = null;
                datePublish = null;
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
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
                    if (DateTime.Compare(Convert.ToDateTime(txtExpires.Text.Trim()), DateTime.Today) < 1)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                    else
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim());
                }
                if (txtDOB.Text.Trim() != "" && txtLCD.Text.Trim() != "")
                {
                    DateTime DOBDate = Convert.ToDateTime(txtDOB.Text.Trim());
                    DateTime dateLC = Convert.ToDateTime(txtLCD.Text.Trim());
                    DOBMonth = DOBDate.Month.ToString();
                    DOBDay = DOBDate.Day.ToString();
                    DOBYear = DOBDate.Year.ToString();
                    LCMonth = dateLC.Month.ToString();
                    LCDay = dateLC.Day.ToString();
                    LCYear = dateLC.Year.ToString();
                    if (DateTime.Compare(dateLC, DateTime.Today) > 0)
                    {
                        addflag = false;
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.LastContactCurrentDate + "</font>";
                        txt.Focus();
                    }
                    else if (DateTime.Compare(DOBDate, dateLC) > 0)
                    {
                        addflag = false;
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.LastContactDate + "</font>";
                        txt.Focus();
                    }
                }
                if (addflag)
                {
                    string Height = "";
                    Height = GetTotalHeight();
                    bool IsPublish = true;
                    bool IsPrivate = true;
                    if (rbPublic.Checked)
                        IsPublish = false;
                    if (rbPrivate.Checked)
                        IsPrivate = false;
                    #region XML String
                    BulletinXML = "<Bulletins><Bulletin  Photopath='" + hdnDefaultPerson.Value + "'  ";
                    BulletinXML = BulletinXML + " " + "ImageLink='" + hdnLink.Value + "'";
                    BulletinXML = BulletinXML + " " + "LName='" + txtLastName.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " " + "FName='" + txtFirstName.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " " + "NName='" + txtNickName.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " DOBMonth='" + DOBMonth + "' DOBDay='" + DOBDay + "' DOBYear='" + DOBYear + "'";
                    BulletinXML = BulletinXML + " DateOfBirth='" + txtDOB.Text.Trim() + "'";
                    BulletinXML = BulletinXML + " " + "Age='" + txtAge.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " Gender='" + ddlGender.SelectedValue + "'";
                    BulletinXML = BulletinXML + " Height='" + Height.Replace(" ft", "") + "'";
                    BulletinXML = BulletinXML + " HeightFeet='" + ddlFeet.SelectedValue + "'";
                    BulletinXML = BulletinXML + " HeightInches='" + ddlInches.SelectedValue + "'";
                    BulletinXML = BulletinXML + " Weight='" + txtWeight.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " Eyes='" + ddlEyes.SelectedValue + "'";
                    BulletinXML = BulletinXML + " Hair='" + ddlHair.SelectedValue + "'";
                    BulletinXML = BulletinXML + " Complexion='" + ddlCompletion.SelectedValue + "'";
                    BulletinXML = BulletinXML + " Race='" + ddlRace.SelectedValue + "'";
                    BulletinXML = BulletinXML + " Nationality='" + txtNationality.Text.Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " Dist_Marks='" + txtDistinguishing_Marks.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " LCMonth='" + LCMonth + "' LCDay='" + LCDay + "' LCYear='" + LCYear + "'";
                    BulletinXML = BulletinXML + " LastContactDate='" + txtLCD.Text.Trim() + "'";
                    BulletinXML = BulletinXML + " Remarks='" + txtRemarks.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + "></Bulletin></Bulletins>";
                    #endregion
                    BulletinHtml = BuildHTML();
                    int bulletinCheckID = BulletinID;
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, false, 0);
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (IsPrivate == true)
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID);
                            else
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, 0);
                        }
                    }
                    else
                    {
                        // BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue);
                        if (IsPrivate == true)
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID);
                        else
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, 0);
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
                    if (bulletinCheckID > 0)
                    {
                        if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                            objCommon.UpdateSentFlag(BulletinID, 2, 0, "Bulletin");
                    }
                    /****** Auto Share Completed ******/
                    objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    RemoveSession();
                    if (BulletinID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string Height = "";
                Height = GetTotalHeight();
                string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", BuildHTML());
                lblPreview.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string BuildHTML()
        {
            string strfilepath = Server.MapPath("~") + "\\BulletinPreview\\MissingPersonRisk.txt";
            StreamReader re = File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                BulletinHtml = BulletinHtml + input;
            }
            re.Close();
            re.Dispose();
            if (hdnDefaultPerson.Value != "")
                if (hdnLink.Value.ToString() == string.Empty)
                {
                    BulletinHtml = BulletinHtml.Replace("#DefaultImage#", "<img src=\"" + hdnDefaultPerson.Value + "\"/>");
                }
                else
                {
                    string linkImage = "<a href='" + hdnLink.Value.ToString() + "' target='_blank'><img style='vertical-align:bottom;' src='" + hdnDefaultPerson.Value + "' border='0' /></a>";
                    BulletinHtml = BulletinHtml.Replace("#DefaultImage#", linkImage);
                }
            else
                BulletinHtml = BulletinHtml.Replace("#DefaultImage#", "");
            string height = "";
            if ((ddlInches.SelectedValue == "" && (ddlFeet.SelectedValue == "0" || ddlFeet.SelectedValue == "")) || (ddlInches.SelectedValue == "0" && (ddlFeet.SelectedValue == "0" || ddlFeet.SelectedValue == "")))
            { }
            else
                height = GetTotalHeight();
            BulletinHtml = BulletinHtml.Replace("#FirstName#", txtFirstName.Text.Trim()).Replace("#LastName#", txtLastName.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#NickName#", txtNickName.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#DateofBirth#", txtDOB.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#Age#", txtAge.Text.Trim()).Replace("#Gender#", ddlGender.SelectedValue).Replace("#Hieght#", height);
            BulletinHtml = BulletinHtml.Replace("#Weight#", txtWeight.Text.Trim() + " pounds").Replace("#Eyes#", ddlEyes.SelectedValue);
            BulletinHtml = BulletinHtml.Replace("#Hair#", ddlHair.SelectedValue).Replace("#Complexion#", ddlCompletion.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#Race#", ddlRace.SelectedValue).Replace("#Nationality#", txtNationality.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#Marks#", txtDistinguishing_Marks.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#LastContact#", txtLCD.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#Remarks#", txtRemarks.Text.Trim()).Replace("#Expires#", txtExpires.Text.Trim());
            BulletinHtml = BulletinHtml.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            return BulletinHtml;
        }
        private string BuildHeader()
        {
            string strHeader = "";
            try
            {
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPersonRisk.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return strHeader;
        }
        public string GetTotalHeight()
        {
            string Height = Height = "0 ft";
            if (ddlFeet.SelectedValue != "")
                Height = ddlFeet.SelectedValue + " ft";
            if (ddlInches.SelectedValue != "")
                Height = Height + " " + ddlInches.SelectedValue + " in";
            return Height;
        }
        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
            Session.Remove("TemplateBID");
        }
    }
}