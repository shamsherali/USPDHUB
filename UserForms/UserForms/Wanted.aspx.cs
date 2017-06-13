using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using UserFormsBLL;
using System.Text;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill;
using System.Text.RegularExpressions;
using System.Drawing;

using Aurigma.GraphicsMill.AdvancedDrawing;
using Aurigma.GraphicsMill.AdvancedDrawing.Art;



namespace UserForms
{
    public partial class Wanted : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;

        Utilities objUtility = new Utilities();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        BusinessUpdatesBLL adminobj = new BusinessUpdatesBLL();
        public string RootPath = "";
        public string DomainName = "";

        public string BulletinXML = string.Empty;
        public string BulletinHtml = string.Empty;

        public int BulletinID = 0;
        public int BulletinCheckID = 0;
        public int TemplateBID = 0;

        public string BulletinName = string.Empty;
        public string urlinfo = string.Empty;
        public int C_UserID = 0;
        bool IsPhoneNumber = true;
        bool IsContatUs = true;

        public static DataTable dtpermissions = new DataTable();

        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        StringBuilder strPrintHtml;
        public string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                if (Session["userid"] == null || Session["ProfileID"] == null || Session["VerticalDomain"] == null)
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
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
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
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
                DataRow[] drGender = dtLabelData.Select("Type='Gender'");
                foreach (DataRow row in drGender)
                {
                    ddlGender.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
                }
                ddlGender.Items.Insert(0, new ListItem("Select", ""));

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

                    if (Session["BulletinCategoryName"] != null)
                    {
                        ddlCategories.SelectedValue = Session["BulletinCategoryName"].ToString();
                    }
                }
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
                DataTable dtSelectedTools = UserFormsDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
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
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "LoadDefaultData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                if (dtFormData.Rows.Count > 0)
                {
                    BulletinID = Convert.ToInt32(dtFormData.Rows[0]["Bulletin_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
                    BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                    var XMLForm = XElement.Parse(BulletinXML, LoadOptions.PreserveWhitespace);
                    hdnDefaultPerson.Value = XMLForm.Element("Bulletin").Attribute("DefaultImg").Value;
                    if (XMLForm.Element("Bulletin").Attribute("DefaultImgLink") != null)
                        hdnDPLink.Value = XMLForm.Element("Bulletin").Attribute("DefaultImgLink").Value;
                    txtReason.Text = XMLForm.Element("Bulletin").Attribute("Reason").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtBulletinDate.Text = XMLForm.Element("Bulletin").Attribute("BulletinDate").Value;
                    txtFirstName.Text = XMLForm.Element("Bulletin").Attribute("FirstName").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtLastName.Text = XMLForm.Element("Bulletin").Attribute("LastName").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtNickname.Text = XMLForm.Element("Bulletin").Attribute("NickName").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtDOB.Text = XMLForm.Element("Bulletin").Attribute("DateOfBirth").Value;
                    txtAge.Text = XMLForm.Element("Bulletin").Attribute("Age").Value.Replace("&apos;", "'");
                    ddlGender.SelectedValue = XMLForm.Element("Bulletin").Attribute("Gender").Value;
                    if (XMLForm.Element("Bulletin").Attribute("HeightFeet") != null && XMLForm.Element("Bulletin").Attribute("HeightInches") != null)
                    {
                        ddlFeet.SelectedValue = XMLForm.Element("Bulletin").Attribute("HeightFeet").Value;
                        ddlInches.SelectedValue = XMLForm.Element("Bulletin").Attribute("HeightInches").Value;
                    }
                    else
                    {
                        string Height = XMLForm.Element("Bulletin").Attribute("Height").Value;
                        if (Height != "")
                        {
                            Height = Height.Replace(" ft", "");
                            string[] totalHeight = Height.Split('.');
                            ddlFeet.SelectedValue = totalHeight[0];
                            if (totalHeight.Length == 2)
                                ddlInches.SelectedValue = totalHeight[1];
                        }
                    }

                    if (XMLForm.Element("Bulletin").Attribute("IsLocated") != null)
                    {
                        chkLocated.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsLocated").Value);

                    }
                    if (XMLForm.Element("Bulletin").Attribute("Apprehended") != null)
                        txtApprehend.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("Apprehended").Value);

                    txtWeight.Text = XMLForm.Element("Bulletin").Attribute("Weight").Value.Replace("&apos;", "'");
                    ddlEyes.SelectedValue = XMLForm.Element("Bulletin").Attribute("Eyes").Value;
                    ddlHair.SelectedValue = XMLForm.Element("Bulletin").Attribute("Hair").Value;
                    ddlCompletion.SelectedValue = XMLForm.Element("Bulletin").Attribute("Complexion").Value;
                    ddlRace.SelectedValue = XMLForm.Element("Bulletin").Attribute("Race").Value;
                    txtNationality.Text = XMLForm.Element("Bulletin").Attribute("Nationality").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtMarks.Text = XMLForm.Element("Bulletin").Attribute("Marks").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    hdnAnotherImg.Value = XMLForm.Element("Bulletin").Attribute("AnotherImg").Value;
                    if (XMLForm.Element("Bulletin").Attribute("AnotherImgLink") != null)
                        hdnAnotherImgLink.Value = XMLForm.Element("Bulletin").Attribute("AnotherImgLink").Value;
                    txtAddInfo.Text = XMLForm.Element("Bulletin").Attribute("AddInfo").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtRemarks.Text = XMLForm.Element("Bulletin").Attribute("Remarks").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");

                    if (XMLForm.Element("Bulletin").Attribute("MiddleName") != null)
                    {
                        txtMiddleName.Text = XMLForm.Element("Bulletin").Attribute("MiddleName").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    }
                    if (XMLForm.Element("Bulletin").Attribute("ContentCall") != null)
                    {
                        txtContentPhone.Text = XMLForm.Element("Bulletin").Attribute("ContentCall").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    }

                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Expiration_Date"].ToString()))
                    {
                        txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        ExpiryTimeControl1.SelectedTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortTimeString();
                        ExpiryTimeControl1.Enabled = true;
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false;
                    }
                    

                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Publish_Date"].ToString()))
                    {
                        DateTime dtPublish = Convert.ToDateTime(dtFormData.Rows[0]["Publish_Date"]);
                        if (DateTime.Compare(dtPublish, dtNow) < 0)
                            txtPublishDate.Text = dtNow.ToShortDateString();
                        else
                            txtPublishDate.Text = dtPublish.ToShortDateString();
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
                        objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "LoadFormData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "btnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                RemoveSession();
                Response.Redirect(Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageBulletins.aspx"));

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "btnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

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

                string ExHour = "0";
                string ExMin = "0";
                string ExSS = "AM";
                var ExTime = ExpiryTimeControl1.SelectedTime;
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
                        ExpiryTimeControl1.Enabled = true;
                        ExpDateTime = txtExpires.Text.Trim() + " " + ExpiryTimeControl1.SelectedTime;
                    }
                    if (Convert.ToDateTime(ExpDateTime) < dtToday)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                    else
                    {
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + ExTime);
                    }
                }
                if (txtDOB.Text.Trim() != "")
                {
                    DateTime DOBDate = Convert.ToDateTime(txtDOB.Text.Trim());
                    DOBMonth = DOBDate.Month.ToString();
                    DOBDay = DOBDate.Day.ToString();
                    DOBYear = DOBDate.Year.ToString();
                }
                if (addflag)
                {
                    string Height = "";
                    Height = GetTotalHeight();
                    BulletinXML = "<Bulletin DefaultImg='" + hdnDefaultPerson.Value + "' DefaultImgLink='" + hdnDPLink.Value + "' FirstName='" + txtFirstName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' LastName='" + txtLastName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' " +
                                    " NickName='" + txtNickname.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' DOBMonth='" + DOBMonth + "' DOBDay='" + DOBDay + "' DOBYear='" + DOBYear + "' DateOfBirth='" + txtDOB.Text.Trim() + "' Age='" + txtAge.Text.Trim().Replace("'", "&apos;") + "' Gender='" + ddlGender.SelectedValue + "'" +
                                   " Height='" + Height.Replace(" ft", "") + "' HeightFeet='" + ddlFeet.SelectedValue + "' HeightInches='" + ddlInches.SelectedValue + "' Weight='" + txtWeight.Text.Trim().Replace("'", "&apos;") + "' Eyes='" + ddlEyes.SelectedValue + "' " +
                                   " Hair='" + ddlHair.SelectedValue + "' Complexion='" + ddlCompletion.SelectedValue + "' Race='" + ddlRace.SelectedValue + "' Nationality='" + txtNationality.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' Marks='" + txtMarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' LCMonth='" + LCMonth + "' LCDay='" + LCDay + "' LCYear='" + LCYear + "'  Reason='" + txtReason.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' BulletinDate='" + txtBulletinDate.Text.Trim().Replace("'", "&apos;") + "'" +
                                   " AnotherImg='" + hdnAnotherImg.Value + "' AnotherImgLink='" + hdnAnotherImgLink.Value + "' AddInfo='" + txtAddInfo.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' Remarks='" + txtRemarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' IsLocated='" + chkLocated.Checked + "' " +
                                   " ExHours='" + ExHour + "' ExMinutes='" + ExMin + "' ExSS='" + ExSS + "'  MiddleName='" + txtMiddleName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' Apprehended='" + txtApprehend.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' ContentCall='" + txtContentPhone.Text.Trim() + "' />";
                    BulletinXML = "<Bulletins>" + BulletinXML + "</Bulletins>";
                    BulletinHtml = BuildHTML();
                    //hdnTextImage.Value = objUtility.DrawRotatedTextWatermark(txtApprehend.Text.Trim());
                    BulletinHtml = BuildLocatedImage(BulletinHtml);

                    string customFormHeader = objCommon.GetCustomFormHeader(UserID);
                    string printerHtml = strPrintHtml.ToString().Replace("###CustomFormHeader###", customFormHeader);
                    printerHtml = BuildLocatedImage(printerHtml);

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false,
                                chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, false, id, printerHtml);
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), BulletinID, PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.WANTED, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
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
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml);
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
                    objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    //RemoveSession();

                    string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
                    Response.Redirect(Page.ResolveClientUrl(urlPath));
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "btnSave_Click", ex.Message,
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

        public string GetTotalHeight()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "GetTotalHeight", string.Empty, string.Empty, string.Empty, string.Empty);

                string Height = "0 ft";
                if (ddlFeet.SelectedValue != "")
                    Height = ddlFeet.SelectedValue + " ft";
                if (ddlInches.SelectedValue != "")
                    Height = Height + " " + ddlInches.SelectedValue + " in";
                return Height;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "GetTotalHeight", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return "";
            }
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                lblbulletinamme.Text = BulletinName;
                string plainHtmlStr = BuildHTML();

                plainHtmlStr = BuildLocatedImage(plainHtmlStr);

                string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", plainHtmlStr.Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));
                lblPreview.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);

                StringBuilder strHtml = new StringBuilder();

                // PDF Print HTML
                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; text-align:left;\">");
                //strPrintHtml.Append("###CustomFormHeader###");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">Wanted</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");
                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;\">");

                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Wanted</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px;  text-align:left;'>");
                // *** Bulletin *** //
                if (txtBulletinDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px;'>Date :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtBulletinDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date :</div>");
                    strPrintHtml.Append("<div style=\"float: left; width: 438px;\">" + txtBulletinDate.Text.Trim() + "</div>");
                }
                if (txtReason.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Reason :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtReason.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Reason :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtReason.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                if (hdnDefaultPerson.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    if (hdnDPLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnDefaultPerson.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + hdnDefaultPerson.Value + "\"/></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnDPLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><a href='" + hdnDPLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a></div>");
                    }
                    strHtml.Append("</td></tr>");
                }

                if (chkLocated.Checked == true)
                {
                    hdnTextImage.Value = "";
                    hdnTextImage.Value = objUtility.DrawRotatedTextWatermark(txtApprehend.Text);
                }
                if (hdnDefaultPerson.Value == "" && hdnAnotherImg.Value == string.Empty && chkLocated.Checked == true)
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");

                    //hdnTextImage.Value = "";
                    //hdnTextImage.Value = objUtility.DrawRotatedTextWatermark(txtApprehend.Text);
                    string imgSrc = HttpContext.Current.Session["RootPath"].ToString() + "/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]) + "/" + hdnTextImage.Value;
                    strHtml.Append("<img src=\"" + imgSrc + "\"/>");


                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + imgSrc + "\"/></div>");



                    //strHtml.Append("<img src=\"" + RootPath + "/images/located.png\"/>");
                    // PDF Print HTML

                    //strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + RootPath + "/images/located.png\"/></div>");

                }
                // *** For last name *** //
                if (txtLastName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Last Name : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtLastName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Last Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtLastName.Text.Trim() + "</div>");
                }

                // *** For middle t name *** //
                if (txtMiddleName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Middle Name : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtMiddleName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Middle Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtMiddleName.Text.Trim() + "</div>");
                }


                // *** For first name *** //
                if (txtFirstName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>First Name :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtFirstName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">First Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtFirstName.Text.Trim() + "</div>");
                }
                // *** For nick name *** //
                if (txtNickname.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Nickname :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtNickname.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Nickname :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtNickname.Text.Trim() + "</div>");
                }
                // *** For Date of Birth *** //
                if (txtDOB.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Date of Birth :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtDOB.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date of Birth :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtDOB.Text.Trim() + "</div>");
                }
                // *** For age *** //
                if (txtAge.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Age :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtAge.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Age :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtAge.Text.Trim() + "</div>");
                }
                // *** For Gender *** //
                if (ddlGender.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Gender/Race :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlGender.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Gender/Race :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlGender.SelectedValue + "</div>");
                }
                // *** For Height *** //
                string height = "";
                if ((ddlInches.SelectedValue == "" && (ddlFeet.SelectedValue == "0" || ddlFeet.SelectedValue == "")) || (ddlInches.SelectedValue == "0" && (ddlFeet.SelectedValue == "0" || ddlFeet.SelectedValue == "")))
                { }
                else
                    height = GetTotalHeight();
                if (height != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Height :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + height + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Height :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + height + "</div>");
                }

                // *** For Weight *** //
                if (txtWeight.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Weight :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtWeight.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Weight :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtWeight.Text.Trim() + "</div>");
                }
                // *** For Eyes *** //
                if (ddlEyes.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Eyes :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlEyes.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Eyes :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlEyes.SelectedValue + "</div>");
                }
                // *** For Hair *** //
                if (ddlHair.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Hair :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlHair.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Hair :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlHair.SelectedValue + "</div>");
                }
                // *** For Complexion *** //
                if (ddlCompletion.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Complexion :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlCompletion.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Complexion :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlCompletion.SelectedValue + "</div>");
                }
                // *** For Race *** //
                if (ddlRace.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Race :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlRace.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Race :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlRace.SelectedValue + "</div>");
                }
                // *** For Distinguishing Marks *** //
                if (txtMarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Distinguishing Marks :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Distinguishing Marks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }

                // *** For another image *** //
                if (hdnAnotherImg.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='border: 1px solid #dddddd; padding: 0px; width:100%;'>");
                    if (hdnAnotherImgLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAnotherImg.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"font-weight: bold;  text-align:center; float: left; margin-right: 10px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><img src=\"" + hdnAnotherImg.Value + "\" /></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"font-weight: bold;  text-align:center; float: left; margin-right: 10px; border: 1px solid #dddddd; padding: 0px; width:100%; \"><a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a></div>");
                    }
                    strHtml.Append("</td></tr>");
                }
                // *** For Additional Information *** //
                if (txtAddInfo.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: red; padding: 8px 4px 0px 4px;'>Additional Information :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtAddInfo.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; color: red; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Additional Information :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtAddInfo.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For Remarks *** //
                if (txtRemarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: red; padding: 6px 4px 0px 4px;'>Remarks :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtRemarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; color: red; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Remarks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtRemarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For Content Call *** //
                if (txtContentPhone.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding-top:2px;' colspan='2'><a href='tel:" + txtContentPhone.Text.Trim() + "' style='text-decoration:none;'><img style=\"vertical-align:middle\" src='" + RootPath + "/Images/content_call.png'/> " + txtContentPhone.Text.Trim() + "</a></td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px;\"><a href='tel:" + txtContentPhone.Text.Trim() + "'><img src='" + RootPath + "/Images/content_call.png'/> " + txtContentPhone.Text.Trim() + "</a></div>");
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
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }


        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);

                string strHeader = "";
                string strfilepath = uspdVirtualFolder + "\\BulletinPreview\\CommonHeader.txt";
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
                objInBuiltData.ErrorHandling("ERROR", "Wanted.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        private string BuildLocatedImage(string htmlString)
        {
            if (chkLocated.Checked == true)
            {

                string strHtml = objUtility.BuildLocatedImage(htmlString, hdnTextImage.Value);
                htmlString = strHtml;
                //string imagePath = "";

                //string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                //MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                //foreach (Match m in matchesImgSrc)
                //{
                //    imagePath = m.Groups[1].Value;

                //    if (imagePath.ToLower().Contains("images/" + hdnTextImage.Value))
                //    {
                //        imagePath = "";
                //    }
                //    else
                //    {
                //        string uspdUploadFolderPath = uspdVirtualFolder + "\\Upload";
                //        string imgName = System.IO.Path.GetFileName(imagePath);
                //        string imgExt = System.IO.Path.GetExtension(imgName).ToLower();
                //        string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(imagePath);

                //        string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                //        FOlderPath = FOlderPath.Replace("upload", "");
                //        string olgImgPath = uspdUploadFolderPath + FOlderPath;
                //        string newImgPath = olgImgPath.Replace(filenameWithoutExt.ToLower(), filenameWithoutExt.ToLower() + "_text");
                //        if (!File.Exists(newImgPath))
                //        {
                //            string locatedImage = uspdVirtualFolder + "\\Images\\";
                //            locatedImage = locatedImage + hdnTextImage.Value;

                //            //Load background image
                //            Aurigma.GraphicsMill.Bitmap bitmap =
                //                new Aurigma.GraphicsMill.Bitmap(olgImgPath);

                //            //Load small image (foreground image)
                //            Aurigma.GraphicsMill.Bitmap smallBitmap =
                //                new Aurigma.GraphicsMill.Bitmap(locatedImage);

                //            //Draw foreground image on background with transparency
                //            bitmap.Draw(smallBitmap, 30, bitmap.Height - smallBitmap.Height - 10,
                //               smallBitmap.Width, smallBitmap.Height,
                //                Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, ResizeInterpolationMode.High);


                //            bitmap.Save(newImgPath);
                //        }
                //        htmlString = htmlString.Replace(filenameWithoutExt, filenameWithoutExt + "_text");
                //    }
                //    //if (imagePath.ToLower().Contains("images/located.png") || imagePath.ToLower().Contains("images/cleared.png"))
                //    //{
                //    //    imagePath = "";
                //    //}
                //    //else
                //    //{ break; }

                //}

                // Without image time Means Only Text
                //if (imagePath.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    string uspdUploadFolderPath = uspdVirtualFolder + "\\Upload";
                //    string imgName = Path.GetFileName(imagePath);
                //    string imgExt = Path.GetExtension(imgName).ToLower();
                //    string filenameWithoutExt = Path.GetFileNameWithoutExtension(imagePath);

                //    string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                //    FOlderPath = FOlderPath.Replace("upload", "");
                //    string olgImgPath = uspdUploadFolderPath + FOlderPath;
                //    string newImgPath = olgImgPath.Replace(filenameWithoutExt.ToLower(), filenameWithoutExt.ToLower() + "_located");
                //    if (!File.Exists(newImgPath))
                //    {
                //        string locatedImage = uspdVirtualFolder + "\\Images";
                //        locatedImage = locatedImage + "\\located" + ".png";

                //        //Load background image
                //        Aurigma.GraphicsMill.Bitmap bitmap =
                //            new Aurigma.GraphicsMill.Bitmap(olgImgPath);

                //        //Load small image (foreground image)
                //        Aurigma.GraphicsMill.Bitmap smallBitmap =
                //            new Aurigma.GraphicsMill.Bitmap(locatedImage);

                //        //Draw foreground image on background with transparency
                //        bitmap.Draw(smallBitmap, 30, bitmap.Height - smallBitmap.Height - 10,
                //           smallBitmap.Width, smallBitmap.Height,
                //            Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, ResizeInterpolationMode.High);

                //        bitmap.Save(newImgPath);

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
                //    }

                //    htmlString = htmlString.Replace(filenameWithoutExt, filenameWithoutExt + "_located");
                //}
            }
            return htmlString;
        }

        private void PngImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
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
        private void JpegImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
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
        private void BmpImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
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

    }
}