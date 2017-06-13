using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using USPDHUBBLL;
using System.Configuration;
using System.IO;
using System.Data;
using System.Text;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill;
using System.Text.RegularExpressions;

namespace USPDHUB.Business.MyAccount
{
    public partial class SchoolNotification : System.Web.UI.Page
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
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

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
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayComplete();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "Page_Load", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);

                int timeslot = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSlot"]);
                /*
                DateTime dtStartTime = Convert.ToDateTime("12:00 AM");
                DateTime dtEndTime = dtStartTime.AddDays(1);
                TimeSpan ts = dtEndTime - dtStartTime;
                int totalMins = Convert.ToInt32(ts.TotalMinutes);
                int totalinterval = totalMins / timeslot;
                List<TimeIntervals> objTimeIntervals = new List<TimeIntervals>();
                for (int i = 0; i < totalinterval; i++)
                {
                    DateTime dtTime = Convert.ToDateTime(dtToday.ToShortDateString()).AddMinutes(i * timeslot);
                    objTimeIntervals.Add(new TimeIntervals { Text = dtTime.ToShortTimeString(), Value = dtTime.ToShortTimeString() });
                }
                */
                //ddlFrom.DataSource = objTimeIntervals;
                //ddlFrom.DataTextField = "Text";
                //ddlFrom.DataValueField = "Value";
                //ddlFrom.DataBind();

                //ddlTo.DataSource = objTimeIntervals;
                //ddlTo.DataTextField = "Text";
                //ddlTo.DataValueField = "Value";
                //ddlTo.DataBind();


                DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "LoadDefaultData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
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

                //ddlFrom.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@FromTime").Value;
                //ddlTo.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@ToTime").Value;

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

                txtExHours.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@ExHours").Value);
                txtExMinutes.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@ExMinutes").Value);
                ddlExSS.SelectedValue = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@ExSS").Value);

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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "LoadFormData", ex.Message,
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
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

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
                if (txtBulletinDate.Text.Trim() != string.Empty)
                {
                    dateBulletin = Convert.ToDateTime(txtBulletinDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtBulletinDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && BulletinID == 0)
                    {
                        //"Expiration date should be later than current date."

                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate.Replace("Expiration", "Bulletin") + "</font>";
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
                    if (DateTime.Compare(Convert.ToDateTime(txtClosureDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && BulletinID == 0)
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

                    //BulletinXML = BulletinXML + " FromTime='" + ddlFrom.SelectedValue.ToString() + "'";
                    //BulletinXML = BulletinXML + " ToTime='" + ddlTo.SelectedValue.ToString() + "'";

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

                    BulletinXML = BulletinXML + "  ExHours='" + ExHour + "'";
                    BulletinXML = BulletinXML + "  ExMinutes='" + ExMin + "'";
                    BulletinXML = BulletinXML + "  ExSS='" + ExSS + "'";

                    BulletinXML = BulletinXML + "></Bulletin></Bulletins>";

                    #endregion

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
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, false, id, printerHtml);
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), BulletinID, PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.SNOTIFICATION, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            if (IsPrivate == true)
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml,
                                    BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false,
                                    chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml);
                            else
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml,
                                    BulletinXML, C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked,
                                    false, chkContact.Checked, IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, id, printerHtml);
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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);

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
                    strHtml.Append("<img src=\"" + RootPath + "/images/cleared.png\"/>");
                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + RootPath + "/images/cleared.png\"/></div>");

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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return "";
            }
        }

        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
            Session.Remove("TemplateBID");
        }

        protected bool ValidationTime(string starttime1, string endtime1)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SchoolNotification.aspx.cs", "ValidationTime", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "ValidationTime", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
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
                    string newImgPath = olgImgPath.Replace(filenameWithoutExt.ToLower(), filenameWithoutExt.ToLower() + "_cleared");
                    if (!File.Exists(newImgPath))
                    {
                        string locatedImage = HttpContext.Current.Server.MapPath("~/images");
                        locatedImage = locatedImage + "\\cleared" + ".png";

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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "PngImageWritter", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "JpegImageWritter", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "SchoolNotification.aspx.cs", "BmpImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


    }
}
