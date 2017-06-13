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

namespace UserForms
{
    public partial class MissingKid : BaseWeb
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
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingKid.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

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
                    //urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    //Response.Redirect(urlinfo);
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
                    //Auto populate current date
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
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit content.</font>";
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
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetAutoShareRecordStatus()
        {
            try
            {
                DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
                if (dtExistingFbUsersData.Rows.Count > 0)
                {
                    for (int i = 0; i < 1; i++) // To Share on Facebook Timeline
                    {
                        if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["IsAutoShare"].ToString()) == true)
                            chkFbAutoPost.Checked = true;
                    }
                }
                else
                    hdnFacebook.Value = "false";
                DataTable dtExistingTwrUserData = smb.GetTwitterDataByUserID(ProfileID);
                if (dtExistingTwrUserData.Rows.Count > 0)
                {
                    for (int j = 0; j < dtExistingTwrUserData.Rows.Count; j++)
                    {
                        if (Convert.ToBoolean(dtExistingTwrUserData.Rows[j]["IsAutoPost"].ToString()) == true)
                            chkTwrAutoPost.Checked = true;
                    }
                }
                else
                    hdnTwitter.Value = "false";
                if (BulletinID > 0 && (hdnFacebook.Value == "" || hdnTwitter.Value == ""))
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "GetAutoShareRecordStatus", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingKid.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
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

                IOrderedEnumerable<DataRow> result;
                result = dtLabelData.Select("Type='Race'").OrderBy(row => row["Item"]);
                foreach (DataRow row in result)
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
                DataTable dtStates = objUtilities.GetAllShortStatesByCountry("USA");
                ddlStates.DataSource = dtStates;
                ddlStates.DataTextField = "State_Code";
                ddlStates.DataValueField = "State_Code";
                ddlStates.DataBind();
                ddlStates.Items.Insert(0, new ListItem("Select", ""));
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
                DataTable dtprofile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtprofile.Rows[0]["Profile_Phone1"] != null)
                    txtKidsPhone.Text = dtprofile.Rows[0]["Profile_Phone1"].ToString();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingKid.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingKid.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);


                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                if (dtFormData.Rows.Count > 0)
                {
                    BulletinID = Convert.ToInt32(dtFormData.Rows[0]["Bulletin_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
                    BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                    var XMLForm = XElement.Parse(BulletinXML, LoadOptions.PreserveWhitespace);
                    if (XMLForm.Element("Bulletin").Attribute("BulletinDate") != null)
                        txtBulletinDate.Text = XMLForm.Element("Bulletin").Attribute("BulletinDate").Value;
                    txtFirstName.Text = XMLForm.Element("Bulletin").Attribute("FirstName").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtLastName.Text = XMLForm.Element("Bulletin").Attribute("LastName").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtCity.Text = XMLForm.Element("Bulletin").Attribute("City").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    ddlStates.SelectedValue = XMLForm.Element("Bulletin").Attribute("State").Value;
                    hdnDefaultPerson.Value = XMLForm.Element("Bulletin").Attribute("DefaultImg").Value;
                    if (XMLForm.Element("Bulletin").Attribute("DefaultImgLink") != null)
                        hdnDPLink.Value = XMLForm.Element("Bulletin").Attribute("DefaultImgLink").Value;
                    txtCaption.Text = XMLForm.Element("Bulletin").Attribute("DefaultCaption").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtLCD.Text = XMLForm.Element("Bulletin").Attribute("LastContactDate").Value;
                    txtLastSeenSpec.Text = XMLForm.Element("Bulletin").Attribute("LastSeenSpecifications").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    ddlGender.SelectedValue = XMLForm.Element("Bulletin").Attribute("Gender").Value;
                    txtAge.Text = XMLForm.Element("Bulletin").Attribute("Age").Value.Replace("&apos;", "'");
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
                    txtWeight.Text = XMLForm.Element("Bulletin").Attribute("Weight").Value.Replace("&apos;", "'");
                    ddlHair.SelectedValue = XMLForm.Element("Bulletin").Attribute("Hair").Value;
                    ddlEyes.SelectedValue = XMLForm.Element("Bulletin").Attribute("Eyes").Value;
                    ddlRace.SelectedValue = XMLForm.Element("Bulletin").Attribute("Race").Value;
                    txtIdentityMarks.Text = XMLForm.Element("Bulletin").Attribute("IdentificationMarks").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtBriefDesc.Text = XMLForm.Element("Bulletin").Attribute("BriefDescription").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    hdnAnotherImg.Value = XMLForm.Element("Bulletin").Attribute("AnotherImg").Value;
                    if (XMLForm.Element("Bulletin").Attribute("AnotherImgLink") != null)
                        hdnAnotherImgLink.Value = XMLForm.Element("Bulletin").Attribute("AnotherImgLink").Value;
                    txtAnotherCaption.Text = XMLForm.Element("Bulletin").Attribute("AnotherImgCaption").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    hdnAnother1Img.Value = XMLForm.Element("Bulletin").Attribute("Another1Img").Value;
                    if (XMLForm.Element("Bulletin").Attribute("Another1ImgLink") != null)
                        hdnAnother1ImgLink.Value = XMLForm.Element("Bulletin").Attribute("Another1ImgLink").Value;
                    txtAnother1Caption.Text = XMLForm.Element("Bulletin").Attribute("Another1ImgCaption").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtKidsCase.Text = XMLForm.Element("Bulletin").Attribute("Case").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtPDDept.Text = XMLForm.Element("Bulletin").Attribute("PDDepartment").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtPDPhone.Text = XMLForm.Element("Bulletin").Attribute("PDPhone").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    txtKidsDesc.Text = XMLForm.Element("Bulletin").Attribute("KidsDescription").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtKidsPhone.Text = XMLForm.Element("Bulletin").Attribute("KidsPhone").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                    //Changes
                    if (XMLForm.Element("Bulletin").Attribute("MissingChildTypes") != null)
                    {
                        ddlMissingChildTypes.SelectedValue = XMLForm.Element("Bulletin").Attribute("MissingChildTypes").Value;
                    }

                    if (XMLForm.Element("Bulletin").Attribute("IsCleared") != null)
                    {
                        chkCleared.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsCleared").Value);
                    }
                    if (XMLForm.Element("Bulletin").Attribute("DateOfBirth") != null)
                        txtDOB.Text = XMLForm.Element("Bulletin").Attribute("DateOfBirth").Value;

                    if (Convert.ToString(dtFormData.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        DateTime expiryTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]);

                        ExpiryTimeControl1.Enabled = true;
                        try
                        {
                            ExpiryTimeControl1.SelectedTime = expiryTime.ToShortTimeString();
                        }
                        catch (Exception ex)
                        {
                        }

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

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingKid.aspx.cs", "LoadFormData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveSession();
            string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
            Response.Redirect(Page.ResolveClientUrl(urlPath));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingKid.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

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
                        addflag = false;
                    }
                    else
                    {
                        var exTime = ExpiryTimeControl1.SelectedTime;
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + exTime);

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
                    BulletinXML = "<Bulletin BulletinDate='" + txtBulletinDate.Text.Trim() + "' FirstName='" + txtFirstName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' LastName='" + txtLastName.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " City='" + txtCity.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' State='" + ddlStates.SelectedValue + "'" +
                                   " DefaultImg='" + hdnDefaultPerson.Value + "' DefaultImgLink='" + hdnDPLink.Value + "' DefaultCaption='" + txtCaption.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " LCMonth='" + LCMonth + "' LCDay='" + LCDay + "' LCYear='" + LCYear + "' LastContactDate='" + txtLCD.Text.Trim().Replace("'", "&apos;") + "'" +
                                   " LastSeenSpecifications='" + txtLastSeenSpec.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' Gender='" + ddlGender.SelectedValue + "'" +
                                   " Age='" + txtAge.Text.Trim().Replace("'", "&apos;") + "' Height='" + Height.Replace(" ft", "") + "' HeightFeet='" + ddlFeet.SelectedValue + "' HeightInches='" + ddlInches.SelectedValue + "'" +
                                   " Weight='" + txtWeight.Text.Trim().Replace("'", "&apos;") + "' Hair='" + ddlHair.SelectedValue + "' Eyes='" + ddlEyes.SelectedValue + "' Race='" + ddlRace.SelectedValue + "'" +
                                   " IdentificationMarks='" + txtIdentityMarks.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' BriefDescription='" + txtBriefDesc.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " AnotherImg='" + hdnAnotherImg.Value + "' AnotherImgLink='" + hdnAnotherImgLink.Value + "' AnotherImgCaption='" + txtAnotherCaption.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " Another1Img='" + hdnAnother1Img.Value + "' Another1ImgLink='" + hdnAnother1ImgLink.Value + "' Another1ImgCaption='" + txtAnother1Caption.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " Case='" + txtKidsCase.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " PDDepartment='" + txtPDDept.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' PDPhone='" + txtPDPhone.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " KidsDescription='" + txtKidsDesc.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' KidsPhone='" + txtKidsPhone.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                   " MissingChildTypes='" + ddlMissingChildTypes.SelectedValue.ToString() + "' " +
                                   " DOBMonth='" + DOBMonth + "' DOBDay='" + DOBDay + "' DOBYear='" + DOBYear + "' DateOfBirth='" + txtDOB.Text.Trim() + "'" +
                                   " IsCleared='" + chkCleared.Checked + "' ExHours='" + ExHour + "' ExMinutes='" + ExMin + "' ExSS='" + ExSS + "'/>";
                    BulletinXML = "<Bulletins>" + BulletinXML + "</Bulletins>";
                    BulletinHtml = BuildHTML();

                    string customFormHeader = objCommon.GetCustomFormHeader(UserID);
                    string printerHtml = strPrintHtml.ToString().Replace("###CustomFormHeader###", customFormHeader);

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))  //A for author
                        {
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked,
                                false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, false, id, printerHtml);
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), BulletinID, PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.MPERSON, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            if (IsPrivate == true)
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID,
                                    C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish,
                                    dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml);
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
                    objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    RemoveSession();
                    string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
                    Response.Redirect(Page.ResolveClientUrl(urlPath));
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "btnSave_Click", ex.Message,
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
            string Height = "0 ft";
            if (ddlFeet.SelectedValue != "")
                Height = ddlFeet.SelectedValue + " ft";
            if (ddlInches.SelectedValue != "")
                Height = Height + " " + ddlInches.SelectedValue + " in";
            return Height;
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingKid.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                lblbulletinamme.Text = BulletinName;
                string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", BuildHTML().Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));
                lblPreview.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingKid.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                objInBuiltData.ErrorHandling("LOG", "MissingKid.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);
                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px;  text-align:left;\">");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">Missing Kid</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 19px; font-weight: normal; margin-left:50px;\">");

                if (chkCleared.Checked)
                {
                    strHtml.Append("<div align='center' style='color: black; font-weight:bold; position: absolute; z-index: 99999; " +
                    "text-align: center; padding-top: 100px; padding-left: 50px; '>  <span><img src='" + Session["RootPath"].ToString() + "/images/located.png' /></span> </div>");
                    strHtml.Append("<div style=\"background: #fff; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 0px 0px; text-align:left; font-size: 14px;  \">");

                    //Print HTML
                    strPrintHtml.Append("<div align='center' style='color: black; font-weight:bold;'>" +
                    " <span><img src='" + Session["RootPath"].ToString() + "/images/located.png' style=\"position: absolute; margin-top: 100px; margin-left: 90px; \" /></span> </div>");
                }
                else
                {
                    strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; font-size: 14px; margin: 0px; padding: 15px 0px 0px 0px; text-align:left; \">");
                }
                strHtml.Append("<div style=\"text-align: center; font-size: 26px; width:300px; line-height: 28px; border-bottom: 1px dashed #d1d1d1; padding-bottom:5px; font-weight: normal; color: #f15b29;\">Missing Kid</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='font-size:14px; font-family: Arial, Helvetica, sans-serif; background: #fffdfb; width: 300px; margin: 0px; padding: 0px; text-align: left;'>");
                // *** For first name *** //
                if (txtFirstName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>First Name :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtFirstName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">First Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtFirstName.Text.Trim() + "</div>");
                }
                // *** For last name *** //
                if (txtLastName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Last Name : </td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtLastName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Last Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtLastName.Text.Trim() + "</div>");
                }
                // *** For City *** //
                if (txtCity.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>City :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtCity.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">City :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtCity.Text.Trim() + "</div>");
                }
                // *** For State *** //
                if (ddlStates.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>State :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + ddlStates.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">State :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + ddlStates.SelectedValue + "</div>");
                }
                // *** If uploaded default image *** //
                if (hdnDefaultPerson.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='margin: 20px auto; padding: 0px;'>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:left; margin-bottom: 5px; padding: 0px; width:100%; \">");
                    if (hdnDPLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnDefaultPerson.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<img src=\"" + hdnDefaultPerson.Value + "\"/>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnDPLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<a href='" + hdnDPLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a></div>");
                    }
                    if (txtCaption.Text.Trim() != "")
                    {
                        strHtml.Append("<br /><div style=\"float:left; text-align: left; vertical-align:top; padding:0px; padding-left: 4px;\">" + txtCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                        strPrintHtml.Append("<br /><span style=\"float:left; text-align: left;\">" + txtCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</span>");
                    }
                    strHtml.Append("</td></tr>");
                    strPrintHtml.Append("</div>");
                }
                else if (txtCaption.Text.Trim() != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='text-align:left; padding-left: 4px; margin: 20px auto; padding: 0px; padding-bottom:10px; width:100%;'>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:left; margin-bottom: 5px; padding: 0px; padding-bottom:10px; width:100%; \">");
                    strHtml.Append("<br />" + txtCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
                    strPrintHtml.Append("<br />" + txtCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
                    strHtml.Append("</td></tr>");
                    strPrintHtml.Append("</div>");
                }
                strHtml.Append("</table>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='font-size:14px; font-family: Arial, Helvetica, sans-serif; background: #fffdfb; width: 300px; margin: 0px; padding: 0px; text-align: left;'>");
                // *** For Date Missing *** //               
                if (txtLCD.Text.Trim() != "")
                {
                    strHtml.Append("<tr><td style='padding: 6px 4px 0px 4px; font-weight: bold; width: 112px;'>Date Missing :</td>");
                    strHtml.Append("<td style='color: #353535; padding-top: 5px;'>" + txtLCD.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date Missing :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtLCD.Text.Trim() + "</div>");

                }
                strHtml.Append("</table>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='font-size:14px; font-family: Arial, Helvetica, sans-serif; background: #fffdfb; width: 300px; margin: 0px; padding: 0px; text-align: left;'>");
                if (txtLastSeenSpec.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='padding: 6px 4px 0px 4px; font-weight: bold;'>Location Last Seen :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='color: #353535; padding-left: 8px;'>" + txtLastSeenSpec.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Location Last Seen :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtLastSeenSpec.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                strHtml.Append("</table>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='font-size:14px; font-family: Arial, Helvetica, sans-serif; background: #fffdfb; width: 300px; margin: 0px; padding: 0px; text-align: left;'>");
                // *** For Last Seen Specification *** //

                // *** For Gender *** //
                if (ddlGender.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; padding-top: 8px; width: 112px;'>Gender :</td>");
                    strHtml.Append("<td style='color: #353535; padding-top: 8px;'>" + ddlGender.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Gender :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + ddlGender.SelectedValue + "</div>");
                }
                // *** For age *** //
                if (txtAge.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Age :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtAge.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Age :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtAge.Text.Trim() + "</div>");
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
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Height :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + height + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Height :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + height + "</div>");
                }
                // *** For Weight *** //
                if (txtWeight.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Weight :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtWeight.Text.Trim() + " Pounds</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Weight :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtWeight.Text.Trim() + " Pounds</div>");
                }
                // *** For Hair *** //
                if (ddlHair.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Hair :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + ddlHair.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Hair :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + ddlHair.SelectedValue + "</div>");
                }
                // *** For Eyes *** //
                if (ddlEyes.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Eyes :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + ddlEyes.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Eyes :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + ddlEyes.SelectedValue + "</div>");
                }
                // *** For Race *** //
                if (ddlRace.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>Race :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + ddlRace.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Race :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + ddlRace.SelectedValue + "</div>");
                }
                strHtml.Append("</table>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='font-size:14px; font-family: Arial, Helvetica, sans-serif; background: #fffdfb; width: 300px; margin: 0px; padding: 0px; text-align: left;'>");
                // *** For Identification Marks *** //
                if (txtIdentityMarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='padding: 8px 4px 0px 4px; font-weight: bold;'>Identifying Marks :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='color: #353535; padding-left: 8px;'>" + txtIdentityMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Identifying Marks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtIdentityMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For Brief Description *** //
                if (txtBriefDesc.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='padding: 8px 4px 0px 4px; font-weight: bold;'>Description of Circumstances, Clothing, etc.</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='color: #353535; padding-left: 8px;'>" + txtBriefDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-bottom: 5px; line-height:16px;\">Description of Circumstances, Clothing, etc. :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtBriefDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For another image *** //
                if (hdnAnotherImg.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='margin: 20px auto; padding: 0px; padding-top: 10px;'>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:left; margin-bottom: 5px; padding: 0px; width:100%; \">");
                    if (hdnAnotherImgLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAnotherImg.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<img src=\"" + hdnAnotherImg.Value + "\"/>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a></div>");
                    }
                    if (txtAnotherCaption.Text.Trim() != "")
                    {
                        strHtml.Append("<br /><div style=\"float:left; text-align:left; vertical-align:top; padding:0px; padding-left: 4px; \">" + txtAnotherCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                        strPrintHtml.Append("<br /><span style=\"float:left; text-align:left;\">" + txtAnotherCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</span>");
                    }
                    strHtml.Append("</td></tr>");
                    strPrintHtml.Append("</div>");
                }
                else if (txtAnotherCaption.Text.Trim() != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='text-align:left; padding-left: 4px; margin: 20px auto; padding: 0px; padding-bottom:10px; width:100%;'>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:left; margin-bottom: 5px; padding: 0px; padding-bottom:10px; width:100%; \">");
                    strHtml.Append("<br />" + txtAnotherCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
                    strPrintHtml.Append("<br />" + txtAnotherCaption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
                    strHtml.Append("</td></tr>");
                    strPrintHtml.Append("</div>");
                }
                // *** For another image *** //
                if (hdnAnother1Img.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='margin: 20px auto; padding: 0px; padding-top:10px;'>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:left; margin-bottom: 5px; padding: 0px; width:100%; \">");
                    if (hdnAnother1ImgLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAnother1Img.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<img src=\"" + hdnAnother1Img.Value + "\"/>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnAnother1ImgLink.Value + "' target='_blank'><img src='" + hdnAnother1Img.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<a href='" + hdnAnother1ImgLink.Value + "' target='_blank'><img src='" + hdnAnother1Img.Value + "'/></a></div>");
                    }
                    if (txtAnother1Caption.Text.Trim() != "")
                    {
                        strHtml.Append("<br /><div style=\"float:left; text-align:left; vertical-align:top; padding:0px; padding-left: 4px;\">" + txtAnother1Caption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                        strPrintHtml.Append("<br /><span style=\"float:left; text-align:left;\">" + txtAnother1Caption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</span>");
                    }
                    strHtml.Append("</td></tr>");
                    strPrintHtml.Append("</div>");
                }
                else if (txtAnother1Caption.Text.Trim() != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='text-align:left; padding-left: 4px; margin: 20px auto; padding: 0px; padding-bottom:10px;'>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:left; margin-bottom: 5px; padding: 0px; padding-bottom:10px; width:100%; \">");
                    strHtml.Append("<br />" + txtAnother1Caption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
                    strPrintHtml.Append("<br />" + txtAnother1Caption.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
                    strHtml.Append("</td></tr>");
                    strPrintHtml.Append("</div>");
                }
                if (txtPDDept.Text.Trim() != "" || txtPDPhone.Text.Trim() != "" || txtKidsDesc.Text.Trim() != "" || txtKidsPhone.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='padding: 6px 4px 0px 4px; font-weight: bold;'>Call With Information :</td></tr>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Call with Information :</div>");
                }
                if (txtPDDept.Text.Trim() != "" || txtPDPhone.Text.Trim() != "")
                {
                    strHtml.Append("<tr><td colspan='2' style='color: #353535; padding-left: 8px;'>" + txtPDDept.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + (txtPDDept.Text.Trim() != "" ? "<br/>" : "") + txtPDPhone.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtBriefDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + (txtPDDept.Text.Trim() != "" ? "<br/>" : "") + txtPDPhone.Text.Trim() + "</div>");
                }
                if (txtKidsDesc.Text.Trim() != "" || txtKidsPhone.Text.Trim() != "")
                {
                    strHtml.Append("<tr><td colspan='2' style='color: #353535; padding-left: 8px;'>" + txtKidsDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + (txtKidsDesc.Text.Trim() != "" ? "<br/>" : "") + txtKidsPhone.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtKidsDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + (txtKidsDesc.Text.Trim() != "" ? "<br/>" : "") + txtKidsPhone.Text.Trim() + "</div>");
                }
                strHtml.Append("</table>");
                // *** For case Number *** //
                if (txtKidsCase.Text.Trim() != "")
                {
                    strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='font-size:14px; font-family: Arial, Helvetica, sans-serif; background: #fffdfb; width: 300px; margin: 0px; padding: 0px; text-align: left;'><tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold; width: 112px;'>KlaasKIDS Case # :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtKidsCase.Text.Trim() + "</td></tr></table>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">KlaasKIDS Case # :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtKidsCase.Text.Trim() + "</div>");
                }
                // *** For Date of Birth *** //
                if (txtDOB.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='padding: 4px; font-weight: bold;'>Date of Birth :</td>");
                    strHtml.Append("<td style='color: #353535;'>" + txtDOB.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px;\">Date of Birth :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-bottom: 5px;\">" + txtDOB.Text.Trim() + "</div>");
                }
                strHtml.Append("</div>");
                strHtml.Replace("<table></table>", "");
                BulletinHtml = strHtml.ToString().Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);

                // PDF Print HTML
                strPrintHtml.Append("</div>");
                strPrintHtml.Append("</div>");

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MissingKid.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }

            return BulletinHtml;
        }
    }
}