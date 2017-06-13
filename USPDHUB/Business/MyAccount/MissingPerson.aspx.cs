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
using USPDHUBBLL;
using System.Text.RegularExpressions;
using Aurigma.GraphicsMill;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill.Transforms;

namespace USPDHUB.Business.MyAccount
{
    public partial class MissingPerson : BaseWeb
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
        AgencyBLL agencyobj = new AgencyBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        StringBuilder strPrintHtml;
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);


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
                    if (XMLForm.Element("Bulletin").Attribute("IsCleared") != null)
                    {
                        chkCleared.Checked = Convert.ToBoolean(XMLForm.Element("Bulletin").Attribute("IsCleared").Value);
                    }

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

                    //txtExHours.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExHours").Value);
                    //txtExMinutes.Text = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExMinutes").Value);
                    //ddlExSS.SelectedValue = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExSS").Value);
                    hdnTimePicker.Value = Convert.ToString(XMLForm.Element("Bulletin").Attribute("ExpTime").Value);
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
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "LoadFormData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

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
                        ExpDateTime = txtExpires.Text.Trim() + " " + hdnTimePicker.Value;
                        //txtExHours.Enabled = true;
                        //txtExMinutes.Enabled = true;
                        //ddlExSS.Enabled = true;
                        //if (!string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        //{
                        //    ExpDateTime = txtExpires.Text.Trim() + " " + txtExHours.Text + ":" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        //}
                        //else if (!string.IsNullOrEmpty(txtExHours.Text) && string.IsNullOrEmpty(txtExMinutes.Text))
                        //{
                        //    ExpDateTime = txtExpires.Text.Trim() + " " + txtExHours.Text + ":00:00" + " " + ddlExSS.SelectedValue.ToString();
                        //}
                        //else if (string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        //{
                        //    ExpDateTime = txtExpires.Text.Trim() + " 12:" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    ExpDateTime = txtExpires.Text.Trim() + " 12:00:00 AM";
                        //}
                    }
                    if (Convert.ToDateTime(ExpDateTime) < dtToday)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                    else
                    {
                        if (hdnTimePicker.Value.Trim() != "")
                        {
                            ExTime = hdnTimePicker.Value;
                        }
                        else
                        {
                            ExTime = "12:00 AM";
                        }
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + ExTime);
                        //if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
                        //{
                        //    ExHour = txtExHours.Text;
                        //    if (ExHour == "")
                        //        ExHour = "12";
                        //    ExMin = txtExMinutes.Text;
                        //    if (ExMin == "")
                        //        ExMin = "00";
                        //    ExSS = ddlExSS.SelectedValue.ToString();

                        //    ExTime = ExHour + ":" + ExMin + ":00 " + ExSS;
                        //}
                        //else
                        //{
                        //    ExHour = "12";
                        //    ExMin = "00";
                        //    ExSS = "AM";

                        //    ExTime = ExHour + ":" + ExMin + ":00 " + ExSS;
                        //}
                        //dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + ExTime);
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
                                   " IsCleared='" + chkCleared.Checked + "'" +
                                   " ExpTime='" + hdnTimePicker.Value + "' />";
                    //" ExHours='" + ExHour + "' ExMinutes='" + ExMin + "' ExSS='" + ExSS + "' />";
                    BulletinXML = "<Bulletins>" + BulletinXML + "</Bulletins>";

                    BulletinHtml = BuildHTML();
                    BulletinHtml = BuildLocatedImage(BulletinHtml);

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
                    urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
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
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
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
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                objInBuiltData.ErrorHandling("LOG", "MissingPerson.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);
                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; text-align:left;\">");
                //strPrintHtml.Append("###CustomFormHeader###");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">" + ddlMissingPersonTypes.SelectedValue + "</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");

                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;\">");

                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">" + ddlMissingPersonTypes.SelectedValue + "</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px; text-align:left;'>");
                if (txtBulletinDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td width='48%' style='padding: 4px;'>Date :</td>");
                    strHtml.Append("<td width='52%' style='color: #353535;'>" + txtBulletinDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Date :</div>");
                    strPrintHtml.Append("<div style=\"float: left; width: 438px; margin-top: 5px;\">" + txtBulletinDate.Text.Trim() + "</div>");
                }
                if (chkAdult.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkAdult.Text + " </strong></td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkAdult.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"></div>");
                }
                if (chkDependAdult.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkDependAdult.Text + " </strong></td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkDependAdult.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"></div>");
                }
                if (chkJuvenile.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkJuvenile.Text + " </strong></td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkJuvenile.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"></div>");
                }
                if (chkOther2.Checked == true && txtOther2.Text != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'><strong>" + chkOther2.Text + "</strong>  : </td></tr><tr><td colspan='2' style='color: #353535; padding-left: 8px;'> <strong>" + txtOther2.Text + " </strong></td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkOther2.Text + "  </strong>:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"> <strong>" + txtOther2.Text.Trim() + " </strong></div>");
                }
                if (chkAmberAlert.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkAmberAlert.Text + " </strong></td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkAmberAlert.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"></div>");
                }
                if (chkSilverAlert.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkSilverAlert.Text + " </strong></td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkSilverAlert.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"></div>");
                }
                if (chkStranger.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkStranger.Text + " </strong></td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 200px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkStranger.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 400px; margin-top: 5px;\"></div>");
                }
                if (chkSuspicious.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding: 4px;'> <strong>" + chkSuspicious.Text + " </strong></td>");
                    strHtml.Append("</tr>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 200px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkSuspicious.Text + " </strong></div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 400px; margin-top: 5px;\"></div>");
                }
                if (chkOther1.Checked == true && txtOther1.Text != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'><strong>" + chkOther1.Text + "</strong > : </td></tr><tr><td colspan='2' style='color: #353535; padding-left: 8px;'> <strong>" + txtOther1.Text.Trim() + " </strong></td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkOther1.Text + "  </strong>:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"> <strong>" + txtOther1.Text.Trim() + " </strong></div>");
                }
                if (chkAtRisk.Checked == true && txtAtRisk.Text != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'><strong>" + chkAtRisk.Text + "</strong > : </td></tr><tr><td colspan='2' style='color: #353535; padding-left: 8px;'> <strong>" + txtAtRisk.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + " </strong></td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\"> <strong>" + chkAtRisk.Text + "  </strong>:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\"> <strong>" + txtAtRisk.Text.Trim() + " </strong></div>");
                }
                // *** If uploaded the image *** //
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
                if (hdnDefaultPerson.Value == "" && hdnAnotherImg.Value == string.Empty && chkCleared.Checked == true)
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    strHtml.Append("<img src=\"" + RootPath + "/images/located.png\"/>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + RootPath + "/images/located.png\"/></div>");

                }

                // *** For last name *** //
                if (txtLastName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Last Name : </td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtLastName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Last Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtLastName.Text.Trim() + "</div>");
                }
                // *** For first name *** //
                if (txtFirstName.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>First Name :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtFirstName.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">First Name :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtFirstName.Text.Trim() + "</div>");
                }
                // *** For nick name *** //
                if (txtNickname.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Nickname :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtNickname.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Nickname :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtNickname.Text.Trim() + "</div>");
                }
                // *** For Date of Birth *** //
                if (txtDOB.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Date of Birth :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtDOB.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Date of Birth :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtDOB.Text.Trim() + "</div>");
                }
                // *** For age *** //
                if (txtAge.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Age :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtAge.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Age :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtAge.Text.Trim() + "</div>");
                }
                // *** For Gender *** //
                if (ddlGender.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Gender/Race :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlGender.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Gender/Race :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + ddlGender.SelectedValue + "</div>");
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
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Height :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + height + "</div>");
                }
                // *** For Weight *** //
                if (txtWeight.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Weight :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtWeight.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Weight :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtWeight.Text.Trim() + "</div>");
                }
                // *** For Eyes *** //
                if (ddlEyes.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Eyes :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlEyes.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Eyes :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + ddlEyes.SelectedValue + "</div>");
                }
                // *** For Hair *** //
                if (ddlHair.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Hair :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlHair.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Hair :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + ddlHair.SelectedValue + "</div>");
                }
                // *** For Complexion *** //
                if (ddlCompletion.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Complexion :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlCompletion.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Complexion :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + ddlCompletion.SelectedValue + "</div>");
                }
                // *** For Race *** //
                if (ddlRace.SelectedValue != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Race :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + ddlRace.SelectedValue + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Race :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + ddlRace.SelectedValue + "</div>");
                }
                // *** For Nationality *** //
                if (txtNationality.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Nationality :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtNationality.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Nationality :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtNationality.Text.Trim() + "</div>");
                }
                // *** For Distinguised Marks *** //
                if (txtMarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Distinguishing Marks :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Distinguishing Marks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtMarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For Last Contact Date *** //
                if (txtLCD.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 6px 4px 8px 4px;'>Date of Last Contact :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtLCD.Text.Trim() + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Date of Last Contact :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtLCD.Text.Trim() + "</div>");

                }
                // *** For another image *** //
                if (hdnAnotherImg.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; border: 1px solid #dddddd; padding: 0px; width:100%;'>");
                    if (hdnAnotherImgLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAnotherImg.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold;  text-align:center; float: left; margin-right: 10px; margin-top: 5px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><img src=\"" + hdnAnotherImg.Value + "\" /></div>");
                    }
                    else
                    {
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold;  text-align:center; float: left; margin-right: 10px; margin-top: 5px; border: 1px solid #dddddd; padding: 0px; width:100%; \"><a href='" + hdnAnotherImgLink.Value + "' target='_blank'><img src='" + hdnAnotherImg.Value + "'/></a></div>");
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
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; color: red; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Additional Information :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtAddInfo.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** For Remarks *** //
                if (txtRemarks.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: red; padding: 6px 4px 0px 4px;'>Remarks :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtRemarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; color: red; font-weight: bold; float: left; width: 162px; margin-right: 10px; margin-top: 5px;\">Remarks :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 438px; margin-top: 5px;\">" + txtRemarks.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
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
                objInBuiltData.ErrorHandling("ERROR", "MissingPerson.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }

            return BulletinHtml;
        }

        private string BuildLocatedImage(string htmlString)
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

                        int Height = 158;
                        int Width = 60;

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