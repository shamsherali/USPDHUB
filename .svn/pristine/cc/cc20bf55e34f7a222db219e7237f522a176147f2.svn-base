using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using UserFormsBLL;
using System.Configuration;
using System.IO;
using System.Data;
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
    public partial class CMSchoolNotification : BaseWeb
    {
        Utilities objUtility = new Utilities();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();

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

        public int CustomModuleId = 0;
        public int ModuleID = 0;
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
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                UserID = Convert.ToInt32(Session["UserID"].ToString());
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
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create app content.</font>";
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
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayComplete();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);
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
                int timeslot = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSlot"]);

                DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();

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
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "LoadDefaultData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtFormData = objAddOn.GetCustomModuleByID(CustomID);
                Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(BulletinXML);

                //txtRemarks.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Remarks").Value.Replace("&apos;", "'");
                txtBulletinDate.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@BulletinDate").Value;
                chkEvacuation.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsEvacuation").Value);
                chkLockdown.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsLockDown").Value);
                chkLockDrill.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsLockDrill").Value);
                txtLocation.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Location").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                txtEvacuation.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@EvacuationInfor").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                chkClosureDate.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsClosureDate").Value);
                txtClosureDate.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@ClosureDate").Value;

                if (!string.IsNullOrEmpty(txtClosureDate.Text))
                {
                    txtFromHours.Enabled = true;
                    txtFromMinutes.Enabled = true;
                    ddlFromSS.Enabled = true;
                    txtToHours.Enabled = true;
                    txtToMinutes.Enabled = true;
                    ddlToSS.Enabled = true;
                }
                else
                {
                    txtFromHours.Enabled = false;
                    txtFromMinutes.Enabled = false;
                    ddlFromSS.Enabled = false;
                    txtToHours.Enabled = false;
                    txtToMinutes.Enabled = false;
                    ddlToSS.Enabled = false;
                }


                chkClosureTime.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsClosureTime").Value);

                txtFromHours.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@FromHours").Value);
                txtFromMinutes.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@FromMinutes").Value);
                ddlFromSS.SelectedValue = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@FromSS").Value);
                txtToHours.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@ToHours").Value);
                txtToMinutes.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@ToMinutes").Value);
                ddlToSS.SelectedValue = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@ToSS").Value);

                chk1.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsCheck1").Value);
                chk2.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsCheck2").Value);
                chk3.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsCheck3").Value);
                chkCleared.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsCleared").Value);
                txtCleared.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@Cleared").Value);

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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "LoadFormData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                DateTime? dateExpires;
                DateTime? datePublish;
                DateTime? dateBulletin;
                DateTime? dateClosureDate;

                dateExpires = null;
                datePublish = null;
                dateBulletin = null;
                dateClosureDate = null;

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
                if (txtBulletinDate.Text.Trim() != string.Empty)
                {
                    dateBulletin = Convert.ToDateTime(txtBulletinDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtBulletinDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && CustomID == 0)
                    {
                        //"Expiration date should be later than current date."

                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate.Replace("Expiration", "Content") + "</font>";
                        txtBulletinDate.Focus();
                        addflag = false;
                    }
                }
                if ((chkClosureDate.Checked == true && chkClosureTime.Checked == true) || txtClosureDate.Text.Trim() != "")
                {
                    var fromTime = (txtFromHours.Text + ":" + txtFromMinutes.Text + ":00 " + ddlFromSS.SelectedValue.ToString());
                    var toTime = (txtToHours.Text + ":" + txtToMinutes.Text + ":00 " + ddlToSS.SelectedValue.ToString());

                    if (fromTime == toTime && txtFromHours.Text != "" && txtToHours.Text != "")
                    {
                        lblerror.Text = "<font size='2' color='red'>" + "The from and to times cannot be the same. Please try again." + "</font>"; ;
                        addflag = false;
                        txtFromHours.Enabled = true;
                        txtFromMinutes.Enabled = true;
                        ddlFromSS.Enabled = true;
                        txtToHours.Enabled = true;
                        txtToMinutes.Enabled = true;
                        ddlToSS.Enabled = true;
                    }
                    else if (!ValidationTime(fromTime, toTime) && txtFromHours.Text != "" && txtToHours.Text != "")
                    {
                        lblerror.Text = "<font size='2' color='red'>" + "Your end time should be later than your start time." + "</font>"; ;
                        addflag = false;
                        txtFromHours.Enabled = true;
                        txtFromMinutes.Enabled = true;
                        ddlFromSS.Enabled = true;
                        txtToHours.Enabled = true;
                        txtToMinutes.Enabled = true;
                        ddlToSS.Enabled = true;
                    }
                }

                if (txtClosureDate.Text.Trim() != string.Empty)
                {
                    dateClosureDate = Convert.ToDateTime(txtClosureDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtClosureDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && CustomID == 0)
                    {
                        //"Expiration date should be later than current date."

                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate.Replace("Expiration", "Closure") + "</font>";
                        txtBulletinDate.Focus();
                        addflag = false;
                    }
                }
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
                        ExpDateTime = txtExpires.Text.Trim() + " " + ExTime; ;
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
                if (addflag)
                {

                    #region XML String

                    BulletinXML = "<Bulletins><Bulletin    ";
                    //BulletinXML = BulletinXML + " Remarks='" + txtRemarks.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXML = BulletinXML + " BulletinDate='" + txtBulletinDate.Text.Trim() + "'";
                    BulletinXML = BulletinXML + " IsEvacuation='" + chkEvacuation.Checked + "'";
                    BulletinXML = BulletinXML + " IsLockDown='" + chkLockdown.Checked + "'";
                    BulletinXML = BulletinXML + " IsLockDrill='" + chkLockDrill.Checked + "'";
                    BulletinXML = BulletinXML + " Location='" + txtLocation.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXML = BulletinXML + " EvacuationInfor='" + txtEvacuation.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXML = BulletinXML + " IsClosureDate='" + chkClosureDate.Checked + "'";
                    BulletinXML = BulletinXML + " ClosureDate='" + txtClosureDate.Text.Trim() + "'";
                    BulletinXML = BulletinXML + " IsClosureTime='" + chkClosureTime.Checked + "'";

                    BulletinXML = BulletinXML + "  FromHours='" + txtFromHours.Text + "'";
                    BulletinXML = BulletinXML + "  FromMinutes='" + txtFromMinutes.Text + "'";
                    BulletinXML = BulletinXML + "  FromSS='" + ddlFromSS.SelectedValue.ToString() + "'";
                    BulletinXML = BulletinXML + "  ToHours='" + txtToHours.Text + "'";
                    BulletinXML = BulletinXML + "  ToMinutes='" + txtToMinutes.Text + "'";
                    BulletinXML = BulletinXML + "  ToSS='" + ddlToSS.SelectedValue.ToString() + "'";

                    BulletinXML = BulletinXML + " IsCheck1='" + chk1.Checked + "'";
                    BulletinXML = BulletinXML + " IsCheck2='" + chk2.Checked + "'";
                    BulletinXML = BulletinXML + " IsCheck3='" + chk3.Checked + "'";
                    BulletinXML = BulletinXML + " IsCleared='" + chkCleared.Checked + "'";
                    BulletinXML = BulletinXML + " Cleared='" + txtCleared.Text + "'";

                    BulletinXML = BulletinXML + "  ExHours='" + ExHour + "'";
                    BulletinXML = BulletinXML + "  ExMinutes='" + ExMin + "'";
                    BulletinXML = BulletinXML + "  ExSS='" + ExSS + "'";

                    BulletinXML = BulletinXML + "></Bulletin></Bulletins>";

                    #endregion

                    BulletinHtml = BuildHTML();
                    //hdnTextImage.Value = objUtility.DrawRotatedTextWatermark(txtCleared.Text.Trim());
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
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (!string.IsNullOrEmpty(txtClosureDate.Text))
                {
                    txtFromHours.Enabled = true;
                    txtFromMinutes.Enabled = true;
                    ddlFromSS.Enabled = true;
                    txtToHours.Enabled = true;
                    txtToMinutes.Enabled = true;
                    ddlToSS.Enabled = true;
                }
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
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);

                StringBuilder strHtml = new StringBuilder();

                // PDF Print HTML
                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; text-align:left;\">");
                //strPrintHtml.Append("###CustomFormHeader###");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">School Notification</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");


                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;\">");



                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">School Notification</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px;  text-align:left;'>");

                if (chkCleared.Checked == true)
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    hdnTextImage.Value = "";
                    hdnTextImage.Value = objUtility.DrawRotatedTextWatermark(txtCleared.Text);
                    string imgSrc = HttpContext.Current.Session["RootPath"].ToString() + "/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]) + "/" + hdnTextImage.Value;
                    strHtml.Append("<img src=\"" + imgSrc + "\"/>");


                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + imgSrc + "\"/></div>");

                    //    strHtml.Append("<img src=\"" + RootPath + "/images/cleared.png\"/>");
                    //    // PDF Print HTML
                    //    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + RootPath + "/images/cleared.png\"/></div>");
                }

                if (txtBulletinDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td width='48%' style='padding: 4px;'>Date :</td>");
                    strHtml.Append("<td width='52%' style='color: #353535;'>" + txtBulletinDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"font-weight: bold; float: left; width: 206px; margin-right: 10px; margin-bottom: 10px;\">Date :</div>");
                    strPrintHtml.Append("<div style=\"float: left; width: 394px; margin-bottom: 10px;\">" + txtBulletinDate.Text.Trim() + "</div>");
                }
                if (chkEvacuation.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkEvacuation.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkEvacuation.Text + "</div>");
                }
                if (chkLockdown.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkLockdown.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkLockdown.Text + "</div>");
                }
                if (chkLockDrill.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkLockDrill.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkLockDrill.Text + "</div>");
                }
                if (txtLocation.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Location :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtLocation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 206px; margin-right: 10px; margin-bottom: 10px;\">Location :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 394px; margin-bottom: 10px;\">" + txtLocation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                if (txtEvacuation.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Information :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtEvacuation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 206px; margin-right: 10px; margin-bottom: 10px;\">Information :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 394px; margin-bottom: 10px;\">" + txtEvacuation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                if (txtClosureDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Evacuation / Lockdown Date :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtClosureDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 206px; margin-right: 10px; margin-bottom: 10px;\">Evacuation / Lockdown Date :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 394px; margin-bottom: 10px;\">" + txtClosureDate.Text.Trim() + "</div>");
                }
                if (chkClosureTime.Checked == true && (txtFromHours.Text.Trim() != "" && txtToHours.Text.Trim() != "")) //ddlFrom.SelectedValue.ToString() != "" && ddlTo.SelectedValue.ToString() != "")
                {
                    var fromTime = "";
                    var toTime = "";
                    if (txtFromHours.Text.Trim() != "" && txtToHours.Text.Trim() != "")
                    {
                        if (txtFromMinutes.Text.Trim() == "")
                        {
                            txtFromMinutes.Text = "00";
                        }
                        if (txtToMinutes.Text.Trim() == "")
                        {
                            txtToMinutes.Text = "00";
                        }
                        fromTime = (txtFromHours.Text + ":" + txtFromMinutes.Text + ":00 " + ddlFromSS.SelectedValue.ToString());
                        toTime = (txtToHours.Text + ":" + txtToMinutes.Text + ":00 " + ddlToSS.SelectedValue.ToString());
                    }
                    else
                    {
                        txtFromHours.Text = "";
                        txtToHours.Text = "";
                        txtFromMinutes.Text = "";
                        txtToMinutes.Text = "";
                        fromTime = "";
                        toTime = "";
                    }
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Expected Evacuation / Lockdown Time :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'><span style='margin: 0px 0px 0px 25px;'>From " + fromTime + "</span> &nbsp;<span style='padding-left:0px;'> To " + toTime + "</span></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 206px; margin-right: 10px; margin-bottom: 10px;\">Evacuation / Lockdown Time :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 394px; margin-bottom: 10px;\"><span style='margin: 0px 0px 0px 0px;'>From " + fromTime + "</span> &nbsp;<span style='padding-left:0px;'> To " + toTime + "</span></div>");
                }
                if (chk1.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'><strong>The Police Department recommends that parents do not respond  to the school area as this can delay emergency response to the incident.</strong></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"><strong>The Police Department recommends that parents do not respond  to the school area as this can delay emergency response to the incident.</strong></div>");
                }
                if (chk2.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'><strong>Updates will be made available from the school district and/or  the police department. </strong></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"><strong>Updates will be made available from the school district and/or  the police department.</strong></div>");
                }
                if (chk3.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'><strong>Please limit phone calls.</strong></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"><strong> Please limit phone calls. </strong></div>");
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
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return "";
            }
        }

        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
        }

        protected bool ValidationTime(string starttime1, string endtime1)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSchoolNotification.aspx.cs", "ValidationTime", string.Empty, string.Empty, string.Empty, string.Empty);

                int value = 0;

                char[] splitter = { ':' };
                string[] strvals = starttime1.Split(splitter);
                string[] strend = endtime1.Split(splitter);

                if (strvals[2].ToString().IndexOf("PM") > 0 && strend[2].ToString().IndexOf("AM") > 0)
                {
                    value = value + 1;
                }
                else if (strvals[2].ToString().IndexOf("AM") > 0 && strend[2].ToString().IndexOf("AM") > 0)
                {
                    if (Convert.ToInt32(strvals[0].ToString()) < Convert.ToInt32(strend[0].ToString()) && Convert.ToInt32(strend[0].ToString()) != 12)
                    {

                    }
                    else if (Convert.ToInt32(strvals[0].ToString()) == Convert.ToInt32(strend[0].ToString()))
                    {
                        if (string.IsNullOrEmpty(strvals[1].ToString()))
                        {
                            strvals[1] = "00";
                        }
                        if (string.IsNullOrEmpty(strend[1].ToString()))
                        {
                            strend[1] = "00";
                        }
                        if (Convert.ToInt32(strvals[1].ToString()) < Convert.ToInt32(strend[1].ToString()))
                        {

                        }
                        else
                        {
                            value = value + 1;
                        }
                    }
                    else if (Convert.ToInt32(strvals[0].ToString()) > Convert.ToInt32(strend[0].ToString()) && strvals[0].ToString() == "12")
                    {

                    }
                    else
                    {
                        value = value + 1;
                    }
                }
                else if (strvals[2].ToString().IndexOf("PM") > 0 && strend[2].ToString().IndexOf("PM") > 0)
                {
                    if (Convert.ToInt32(strvals[0].ToString()) < Convert.ToInt32(strend[0].ToString()) && Convert.ToInt32(strend[0].ToString()) != 12)
                    {

                    }
                    else if (Convert.ToInt32(strvals[0].ToString()) == Convert.ToInt32(strend[0].ToString()))
                    {
                        if (string.IsNullOrEmpty(strvals[1].ToString()))
                        {
                            strvals[1] = "00";
                        }
                        if (string.IsNullOrEmpty(strend[1].ToString()))
                        {
                            strend[1] = "00";
                        }
                        if (Convert.ToInt32(strvals[1].ToString()) < Convert.ToInt32(strend[1].ToString()))
                        {

                        }
                        else
                        {
                            value = value + 1;
                        }
                    }
                    else if (Convert.ToInt32(strvals[0].ToString()) > Convert.ToInt32(strend[0].ToString()) && strvals[0].ToString() == "12")
                    {

                    }
                    else
                    {
                        value = value + 1;
                    }
                }


                if (value > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSchoolNotification.aspx.cs", "ValidationTime", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }

        private string BuildLocatedImage(string htmlString)
        {
            if (chkCleared.Checked == true)
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