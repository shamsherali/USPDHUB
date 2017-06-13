using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.Linq;
using UserFormsBLL;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill;
using System.Text.RegularExpressions;
using System.Drawing;

using Aurigma.GraphicsMill.AdvancedDrawing;
using Aurigma.GraphicsMill.AdvancedDrawing.Art;


namespace UserForms
{
    public partial class CMMissingPerson : BaseWeb
    {
        Utilities objUtility = new Utilities();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        public int UserID = 0;
        public int ProfileID = 0;

        public string RootPath = "";
        public string DomainName = "";

        public string BulletinXML = string.Empty;
        public string BulletinHtml = string.Empty;

        public int CustomID = 0;
        public int BulletinCheckID = 0;
        public string BulletinName = string.Empty;
        public string urlinfo = string.Empty;

        public int C_UserID = 0;

        bool IsPhoneNumber = true;
        bool IsContatUs = true;

        public static DataTable dtpermissions = new DataTable();

        public int CustomModuleId = 0;
        StringBuilder strPrintHtml;
        public int ModuleID = 0;
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMMissingPerson.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);


                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["CustomModuleID"] != null && Session["FormID"] != null)
                {
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
                    ModuleID = Convert.ToInt32(Session["FormID"].ToString());
                }
                else
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                {
                    CustomID = Convert.ToInt32(Session["BulletinID"]);
                    BulletinCheckID = Convert.ToInt32(Session["BulletinID"]);
                }
                else
                {
                    //urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageAddOns.aspx");
                    //Response.Redirect(urlinfo);
                }
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
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CustomModuleId, "ContentModule");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel3.Visible = true;
                            UpdatePanel2.Visible = UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit app content.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here

                    LoadDefaultData();
                    if (CustomID > 0)
                        LoadFormData();
                    GetAutoShareRecordStatus();
                }
                lblPublish.Text = hdnPublishTitle.Value;
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayImage();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMMissingPerson.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            if (CustomID > 0)
            {
                DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("ContentModule", CustomID, BulletinName);
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveSession();
            Response.Redirect(Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageAddOns.aspx"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMMissingPerson.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

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
                string ExHour = "";
                string ExMin = "";
                string ExSS = "AM";
                var ExTime = ExpiryTimeControl1.SelectedTime;
                bool IsPublish = false;
                int? id = null;
                if (rbPublic.Checked)
                {
                    IsPublish = true;
                    publishValue = "2";
                }
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && CustomID == 0)
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
                        ExpDateTime = txtExpires.Text.Trim() + " " + ExTime;
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
                if (txtLCD.Text.Trim() != "")
                {

                    DateTime dateLC = Convert.ToDateTime(txtLCD.Text.Trim());
                    LCMonth = dateLC.Month.ToString();
                    LCDay = dateLC.Day.ToString();
                    LCYear = dateLC.Year.ToString();
                    if (DateTime.Compare(dateLC, Convert.ToDateTime(dtToday.ToShortDateString())) > 0)
                    {
                        addflag = false;
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.LastContactCurrentDate + "</font>";
                        txt.Focus();
                    }
                    else if (txtDOB.Text.Trim() != "")
                    {
                        DateTime DOBDate = Convert.ToDateTime(txtDOB.Text.Trim());
                        DOBMonth = DOBDate.Month.ToString();
                        DOBDay = DOBDate.Day.ToString();
                        DOBYear = DOBDate.Year.ToString();
                        if (DateTime.Compare(DOBDate, dateLC) > 0)
                        {
                            addflag = false;
                            lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.LastContactDate + "</font>";
                            txt.Focus();
                        }
                    }
                }
                if (txtDOB.Text.Trim() != "" && addflag)
                {
                    DateTime DOBDate = Convert.ToDateTime(txtDOB.Text.Trim());
                    if (DateTime.Compare(DOBDate, Convert.ToDateTime(dtToday.ToShortDateString())) > 0)
                    {
                        addflag = false;
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.DateofBirth + "</font>";
                        txt.Focus();
                    }
                }
                if (addflag)
                {
                    string Height = "";
                    Height = GetTotalHeight();

                    BulletinXML = "<Bulletin DefaultImg='" + hdnDefaultPerson.Value + "' DefaultImgLink='" + hdnDPLink.Value + "' FirstName='" + txtFirstName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' LastName='" + txtLastName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' NickName='" + txtNickname.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' DOBMonth='" + DOBMonth + "' DOBDay='" + DOBDay + "' DOBYear='" + DOBYear + "' DateOfBirth='" + txtDOB.Text.Trim() + "' Age='" + txtAge.Text.Trim().Replace("'", "&apos;") + "' Gender='" + ddlGender.SelectedValue + "'" +
                                   " Height='" + Height.Replace(" ft", "") + "' HeightFeet='" + ddlFeet.SelectedValue + "' HeightInches='" + ddlInches.SelectedValue + "' Weight='" + txtWeight.Text.Trim().Replace("'", "&apos;") + "' Eyes='" + ddlEyes.SelectedValue + "' Hair='" + ddlHair.SelectedValue + "' Complexion='" + ddlCompletion.SelectedValue + "' Race='" + ddlRace.SelectedValue + "' Nationality='" + txtNationality.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' Marks='" + txtMarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' LCMonth='" + LCMonth + "' LCDay='" + LCDay + "' LCYear='" + LCYear + "' LastContactDate='" + txtLCD.Text.Trim().Replace("'", "&apos;") + "'" +
                                   " AnotherImg='" + hdnAnotherImg.Value + "' AnotherImgLink='" + hdnAnotherImgLink.Value + "' AddInfo='" + txtAddInfo.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' " +
                                   " Remarks='" + txtRemarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' MissingPersonTypes='" + ddlMissingPersonTypes.SelectedValue.ToString() + "' " +
                                   " BulletinDate='" + txtBulletinDate.Text.Trim() + "'  IsAdult='" + chkAdult.Checked + "' IsJuvenile='" + chkJuvenile.Checked + "' " +
                                   " IsAmberAlert='" + chkAmberAlert.Checked + "' IsStranger='" + chkStranger.Checked + "' IsOther1='" + chkOther1.Checked + "' Other1='" + txtOther1.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' " +
                                   " IsAtRisk='" + chkAtRisk.Checked + "' AtRisk='" + txtAtRisk.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' IsDependentAdult='" + chkDependAdult.Checked + "' " +
                                   " IsOther2='" + chkOther2.Checked + "' Other2='" + txtOther2.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' IsSilver='" + chkSilverAlert.Checked + "' IsSuspicious='" + chkSuspicious.Checked + "' " +
                                   " IsLocated='" + chkLocated.Checked + "'" + " ExHours='" + ExHour + "' ExMinutes='" + ExMin + "' ExSS='" + ExSS + "' Apprehended='" + txtApprehend.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' ContentCall='" + txtContentPhone.Text.Trim() + "' />";
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
                        if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXML, Convert.ToBoolean(hdnArchive.Value),
                                chkCall.Checked, false, chkContact.Checked, dateExpires, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printerHtml);
                        }
                        else   // for author
                        {
                            CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXML, Convert.ToBoolean(hdnArchive.Value),
                                 chkCall.Checked, false, chkContact.Checked, dateExpires, false, datePublish, id, ddlCategories.SelectedValue, printerHtml);
                            if (IsPublish)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), CustomID, PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.CustomModule, DomainName);
                        }

                    }
                    else
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXML, Convert.ToBoolean(hdnArchive.Value),
                                chkCall.Checked, false, chkContact.Checked, dateExpires, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printerHtml);
                    }
                    /************************************ Auto Share ***************************************/
                    if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                    {
                        if (IsPublish)
                        {
                            if (chkFbAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("ContentModule", CustomID, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, C_UserID, BulletinName);
                            if (chkTwrAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("ContentModule", CustomID, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, C_UserID, BulletinName);
                        }
                    }
                    if (BulletinCheckID > 0)
                    {
                        if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                            objCommon.UpdateSentFlag(CustomID, 2, 0, "ContentModule");
                    }
                    /****** Auto Share Completed ******/
                    objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    RemoveSession();
                    string urlPath = RootPath + "/Business/MyAccount/ManageAddOns.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
                    Response.Redirect(Page.ResolveClientUrl(urlPath));
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMMissingPerson.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
        }
        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMMissingPerson.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
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
                objInBuiltData.ErrorHandling("ERROR", "CMMissingPerson.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMMissingPerson.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);
                //Fill the Categories
                DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID, true);
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
                lblLogoHeader.Text = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMMissingPerson.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMMissingPerson.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);


                DataTable dtFormData = objAddOn.GetCustomModuleByID(CustomID);
                if (dtFormData.Rows.Count > 0)
                {
                    CustomID = Convert.ToInt32(dtFormData.Rows[0]["Custom_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                    var XMLForm = XElement.Parse(BulletinXML, LoadOptions.PreserveWhitespace);
                    hdnDefaultPerson.Value = XMLForm.Element("Bulletin").Attribute("DefaultImg").Value;
                    if (XMLForm.Element("Bulletin").Attribute("DefaultImgLink") != null)
                        hdnDPLink.Value = XMLForm.Element("Bulletin").Attribute("DefaultImgLink").Value;
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

                    //Changes
                    if (XMLForm.Element("Bulletin").Attribute("MissingPersonTypes") != null)
                    {
                        ddlMissingPersonTypes.SelectedValue = XMLForm.Element("Bulletin").Attribute("MissingPersonTypes").Value;
                    }
                    if (XMLForm.Element("Bulletin").Attribute("BulletinDate") != null)
                    {
                        txtBulletinDate.Text = XMLForm.Element("Bulletin").Attribute("BulletinDate").Value;
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsAdult") != null)
                    {
                        chkAdult.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsAdult").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsJuvenile") != null)
                    {
                        chkJuvenile.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsJuvenile").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsAmberAlert") != null)
                    {
                        chkAmberAlert.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsAmberAlert").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsStranger") != null)
                    {
                        chkStranger.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsStranger").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsOther1") != null)
                    {
                        chkOther1.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsOther1").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("Other1") != null)
                    {
                        txtOther1.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("Other1").Value.Replace("&apos;", "'").Replace("&amp;", "&"));
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsAtRisk") != null)
                    {
                        chkAtRisk.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsAtRisk").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("AtRisk") != null)
                    {
                        txtAtRisk.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("AtRisk").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n"));
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsDependentAdult") != null)
                    {
                        chkDependAdult.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsDependentAdult").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsOther2") != null)
                    {
                        chkOther2.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsOther2").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("Other2") != null)
                    {
                        txtOther2.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("Other2").Value.Replace("&apos;", "'").Replace("&amp;", "&"));
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsSilver") != null)
                    {
                        chkSilverAlert.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsSilver").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("IsSuspicious") != null)
                    {
                        chkSuspicious.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsSuspicious").Value);
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
                    txtLCD.Text = XMLForm.Element("Bulletin").Attribute("LastContactDate").Value;
                    hdnAnotherImg.Value = XMLForm.Element("Bulletin").Attribute("AnotherImg").Value;
                    if (XMLForm.Element("Bulletin").Attribute("AnotherImgLink") != null)
                        hdnAnotherImgLink.Value = XMLForm.Element("Bulletin").Attribute("AnotherImgLink").Value;
                    txtAddInfo.Text = XMLForm.Element("Bulletin").Attribute("AddInfo").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtRemarks.Text = XMLForm.Element("Bulletin").Attribute("Remarks").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");

                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Expiration_Date"].ToString()))
                    {
                        txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        ExpiryTimeControl1.Enabled = true;
                        ExpiryTimeControl1.SelectedTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortTimeString();
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false; 
                    }
                    if (XMLForm.Element("Bulletin").Attribute("ContentCall") != null)
                    {
                        txtContentPhone.Text = XMLForm.Element("Bulletin").Attribute("ContentCall").Value.Replace("&apos;", "'").Replace("&amp;", "&");
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
                    if (txtPublishDate.Text != "")
                    {
                        rbPublic.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }
                    hdnArchive.Value = dtFormData.Rows[0]["IsArchive"].ToString();
                    if (!File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + CustomID.ToString() + ".jpg"))
                    {
                        objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
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
                objInBuiltData.ErrorHandling("ERROR", "CMMissingPerson.aspx.cs", "LoadFormData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
        }
        public string GetTotalHeight()
        {
            string Height = "0 ft";
            if (ddlFeet.SelectedValue != "")
                Height = ddlFeet.SelectedValue + " ft";
            if (ddlInches.SelectedValue != "")
                Height = Height + " " + ddlInches.SelectedValue + " in";
            return Height;
        }
        private string BuildHTML()
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);


                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; text-align:left;\">");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">" + ddlMissingPersonTypes.SelectedValue + "</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");

                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 0px 0px;\">");

                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">" + ddlMissingPersonTypes.SelectedValue + "</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 0px 0px; text-align:left;'>");
                if (txtBulletinDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td width='48%' style='padding: 4px;'>Date :</td>");
                    strHtml.Append("<td width='52%' style='color: #353535;'>" + txtBulletinDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date :</div>");
                    strPrintHtml.Append("<div style=\"float: left; width: 438px;\">" + txtBulletinDate.Text.Trim() + "</div>");
                }
                if (chkAdult.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkAdult.Text + " </strong></td><td style='page-break-inside: avoid;'>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkAdult.Text + " </strong></div>");
                }
                if (chkDependAdult.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkDependAdult.Text + " </strong></td><td style='page-break-inside: avoid;'>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkDependAdult.Text + " </strong></div>");
                }
                if (chkJuvenile.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkJuvenile.Text + " </strong></td><td style='page-break-inside: avoid;'>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkJuvenile.Text + " </strong></div>");
                }
                if (chkOther2.Checked == true && txtOther2.Text != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'><strong>" + chkOther2.Text + "</strong>  : </td></tr><tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'> <strong>" + txtOther2.Text + " </strong></td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\"> <strong>" + chkOther2.Text + "  </strong>:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\"> <strong>" + txtOther2.Text.Trim() + " </strong></div>");
                }
                if (chkAmberAlert.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkAmberAlert.Text + " </strong></td><td style='page-break-inside: avoid;'>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkAmberAlert.Text + " </strong></div>");
                }
                if (chkSilverAlert.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkSilverAlert.Text + " </strong></td><td style='page-break-inside: avoid;'>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkSilverAlert.Text + " </strong></div>");
                }
                if (chkStranger.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkStranger.Text + " </strong></td><td style='page-break-inside: avoid;'>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkStranger.Text + " </strong></div>");
                }
                if (chkSuspicious.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkSuspicious.Text + " </strong></td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px;\"> <strong>" + chkSuspicious.Text + " </strong></div>");
                }
                if (chkOther1.Checked == true && txtOther1.Text != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'><strong>" + chkOther1.Text + "</strong > : </td></tr><tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'> <strong>" + txtOther1.Text.Trim() + " </strong></td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\"> <strong>" + chkOther1.Text + "  </strong>:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\"> <strong>" + txtOther1.Text.Trim() + " </strong></div>");
                }
                if (chkAtRisk.Checked == true && txtAtRisk.Text != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'><strong>" + chkAtRisk.Text + "</strong > : </td></tr><tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'> <strong>" + txtAtRisk.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + " </strong></td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\"> <strong>" + chkAtRisk.Text + "  </strong>:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\"> <strong>" + txtAtRisk.Text.Trim() + " </strong></div>");
                }
                // *** If uploaded the image *** //
                if (hdnDefaultPerson.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd; padding: 0px; width:100%;'>");
                    if (hdnDPLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnDefaultPerson.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd; padding: 0px; width:100%; \"><img src=\"" + hdnDefaultPerson.Value + "\"/></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnDPLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd; padding: 0px; width:100%; \"><a href='" + hdnDPLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a></div>");
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
                    //// PDF Print HTML
                    //strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + RootPath + "/images/located.png\"/></div>");

                }

                // *** For last name *** //
                if (txtLastName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Last Name : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtLastName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Last Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtLastName.Text.Trim() + "</div>");
                }
                // *** For first name *** //
                if (txtFirstName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>First Name :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtFirstName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">First Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtFirstName.Text.Trim() + "</div>");
                }
                // *** For nick name *** //
                if (txtNickname.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Nickname :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtNickname.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Nickname :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtNickname.Text.Trim() + "</div>");
                }
                // *** For Date of Birth *** //
                if (txtDOB.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Date of Birth :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtDOB.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date of Birth :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtDOB.Text.Trim() + "</div>");
                }
                // *** For age *** //
                if (txtAge.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Age :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtAge.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Age :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtAge.Text.Trim() + "</div>");
                }
                // *** For Gender *** //
                if (ddlGender.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Gender/Race :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + ddlGender.SelectedValue + "</td></tr>");

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
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + height + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Height :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + height + "</div>");
                }
                // *** For Weight *** //
                if (txtWeight.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Weight :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtWeight.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Weight :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtWeight.Text.Trim() + "</div>");
                }
                // *** For Eyes *** //
                if (ddlEyes.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Eyes :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + ddlEyes.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Eyes :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlEyes.SelectedValue + "</div>");
                }
                // *** For Hair *** //
                if (ddlHair.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Hair :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + ddlHair.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Hair :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlHair.SelectedValue + "</div>");
                }
                // *** For Complexion *** //
                if (ddlCompletion.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Complexion :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + ddlCompletion.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Complexion :</div>");
                    strPrintHtml.Append("<div style=\"float: left; width: 438px;\">" + ddlCompletion.SelectedValue + "</div>");
                }
                // *** For Race *** //
                if (ddlRace.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Race :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + ddlRace.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Race :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + ddlRace.SelectedValue + "</div>");
                }
                // *** For Nationality *** //
                if (txtNationality.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Nationality :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding-top:0px; color: #353535;'>" + txtNationality.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Nationality :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtNationality.Text.Trim() + "</div>");
                }
                // *** For Distinguised Marks *** //
                if (txtMarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Distinguishing Marks :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Distinguishing Marks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For Last Contact Date *** //
                if (txtLCD.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 6px 4px 8px 4px;'>Date of Last Contact :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtLCD.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date of Last Contact :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px;\">" + txtLCD.Text.Trim() + "</div>");

                }
                // *** For another image *** //
                if (hdnAnotherImg.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; border: 1px solid #dddddd; padding: 0px; width:100%;'>");
                    if (hdnAnotherImgLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAnotherImg.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold;  text-align:center; float: left; margin-right: 10px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><img src=\"" + hdnAnotherImg.Value + "\" /></div>");
                    }
                    else
                    {
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold;  text-align:center; float: left; margin-right: 10px; border: 1px solid #dddddd; padding: 0px; width:100%; \"><a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a></div>");
                        strHtml.Append("<a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a>");
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
                    strPrintHtml.Append("<div style=\"color: red; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Additional Information :</div>");
                    strPrintHtml.Append("<div style=\"float: left; width: 438px;\">" + txtAddInfo.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
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

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMMissingPerson.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }

            return BulletinHtml;
        }

        private string BuildLocatedImage(string htmlString)
        {
            if (chkLocated.Checked == true)
            {
                string strHtml = objUtility.BuildLocatedImage(htmlString, hdnTextImage.Value);
                htmlString = strHtml;

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