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

namespace USPDHUB.Business.MyAccount
{
    public partial class CMTrafficAlert : BaseWeb
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        AgencyBLL agencyobj = new AgencyBLL();

        public int UserID = 0;
        public int ProfileID = 0;

        public string RootPath = "";
        public string DomainName = "";

        public string BulletinXml = string.Empty;
        public string BulletinHtml = string.Empty;
        public int CustomID = 0;
        public int BulletinCheckID = 0;

        public string BulletinName = string.Empty;
        public string Urlinfo = string.Empty;
        public int CUserID = 0;

        public bool IsPhoneNumber = true;
        public bool IsContatUs = true;

        public int CustomModuleId = 0;
        public int ModuleID = 0;
        public DataTable Dtpermissions = new DataTable();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        StringBuilder strPrintHtml;
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "CMCMTraffic.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

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
                CUserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                {
                    CustomID = Convert.ToInt32(Session["BulletinID"]);
                    BulletinCheckID = Convert.ToInt32(Session["BulletinID"]);
                }
                else
                {
                    Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx");
                    Response.Redirect(Urlinfo);
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
                objInBuiltData.ErrorHandling("ERROR", "CMCMTraffic.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            try
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
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CMCMTraffic.aspx.cs", "GetAutoShareRecordStatus", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "CMTraffic.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);
#if fixme
                /*
                int timeslot = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSlot"]);
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
                ddlFrom.DataSource = objTimeIntervals;
                ddlFrom.DataTextField = "Text";
                ddlFrom.DataValueField = "Value";
                ddlFrom.DataBind();

                ddlTo.DataSource = objTimeIntervals;
                ddlTo.DataTextField = "Text";
                ddlTo.DataValueField = "Value";
                ddlTo.DataBind();
                */

#endif

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

                // *** Checking Global mobile app settings *** //
                DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                if (dtSelectedTools.Rows.Count > 0)
                {
                    string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                    IsPhoneNumber = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                    IsContatUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
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
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMTraffic.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtFormData = objAddOn.GetCustomModuleByID(CustomID);
                Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                BulletinXml = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(BulletinXml);

                ddlTrafficTypes.SelectedValue = xmldoc.SelectSingleNode("Bulletins/Bulletin/@TrafficType").Value.Replace("&apos;", "'");
                //lbltitle.Text = ddlTrafficTypes.SelectedValue;
                txtBulletinDate.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@BulletinDate").Value;

                chkAccident.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsAccident").Value);
                chkSpeicalEvent.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsSpecialEvent").Value);
                chkRoadClosure.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsRoadClosure").Value);
                chkHazMat.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsHazMat").Value);
                chkConstruction.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsConstruction").Value);
                chkOther.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsOther").Value);
                txtOther.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@Other").Value).Replace("&apos;", "'").Replace("&amp;", "&");
                chkWeather.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsWeather").Value);
                chkChains.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsChainsRequired").Value);
                chkSnowLevel.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsSnowLevel").Value);
                txtSnowLevel.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@SnowLevel").Value).Replace("&apos;", "'").Replace("&amp;", "&");

                chkTuneRadio.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsTuneRadio").Value);
                txtAM.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@AM").Value);
                txtFM.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@FM").Value);
                chkForRoadCondition.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsRoadConditionCall").Value);
                txtConditionsCall.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Bulletin/@RoadConditionCall").Value).Replace("&apos;", "'").Replace("&amp;", "&");
                chkSaveFutureRef.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsSaveforFuture").Value);

                txtLocation.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Location").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                txtCity.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@City").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                txtzipcode.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Zipcode").Value.Replace("&apos;", "'").Replace("&amp;", "&");
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage1") != null)
                    hdnAddImg1.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage1").Value;
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage1Link") != null)
                    hdnAddImg1Link.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage1Link").Value;
                txtInformation.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Information").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage2") != null)
                    hdnAddImg2.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage2").Value;
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage2Link") != null)
                    hdnAddImg2Link.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@AddImage2Link").Value;
                chkWhenDate.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsWhenDates").Value);
                txtFromDate.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@FromDate").Value;
                if (!string.IsNullOrEmpty(txtFromDate.Text))
                {
                    txtFromHours.Enabled = true;
                    txtFromMinutes.Enabled = true;
                    ddlFromSS.Enabled = true;
                }
                else
                {
                    txtFromHours.Enabled = false;
                    txtFromMinutes.Enabled = false;
                    ddlFromSS.Enabled = false;
                }


                txtToDate.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@ToDate").Value;
                if (!string.IsNullOrEmpty(txtToDate.Text))
                {
                    txtToHours.Enabled = true;
                    txtToMinutes.Enabled = true;
                    ddlToSS.Enabled = true;
                }
                else
                {
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

                chkPleaseLimit.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Bulletin/@IsPleaseLimit").Value);
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
                if (txtPublishDate.Text != "")
                {
                    rbPublic.Checked = true;
                    hdnIsAlreadyPublished.Value = "1";
                }
                hdnArchive.Value = dtFormData.Rows[0]["IsArchive"].ToString();
                if (!File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + CustomID.ToString() + ".jpg"))
                {
                    objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
                }

                chkCall.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsCall"].ToString());
                chkContact.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsContactUs"].ToString());

                if (IsPhoneNumber == false)
                    chkCall.Checked = false;
                if (IsContatUs == false)
                    chkContact.Checked = false;

                if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Bulletin_Category"].ToString()))
                    ddlCategories.SelectedValue = dtFormData.Rows[0]["Bulletin_Category"].ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowDatesBoxes();", true);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "LoadFormData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "CMTraffic.aspx.cs", "btnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                RemoveSession();
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx"));
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "btnCancel_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "CMTraffic.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (!string.IsNullOrEmpty(txtFromDate.Text))
                {
                    txtFromHours.Enabled = true;
                    txtFromMinutes.Enabled = true;
                    ddlFromSS.Enabled = true;
                }
                if (!string.IsNullOrEmpty(txtToDate.Text))
                {
                    txtToHours.Enabled = true;
                    txtToMinutes.Enabled = true;
                    ddlToSS.Enabled = true;
                }
                lblbulletinamme.Text = BulletinName;
                string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", BuildHTML().Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));
                lblPreview.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "lnkPreview_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            try
            {
                StringBuilder strHtml = new StringBuilder();
                // PDF Print HTML
                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; text-align:left;\">");
                //strPrintHtml.Append("###CustomFormHeader###");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">" + ddlTrafficTypes.SelectedValue.ToString() + "</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");

                if (chkCleared.Checked)
                {
                    strHtml.Append("<div align='center' style='color: black; font-weight:bold; position: absolute; z-index: 99999; " +
                    "text-align: center; padding-top: 100px; padding-left: 50px; '>  <span><img src='" + Session["RootPath"].ToString() + "/images/cleared.png' /></span> </div>");
                    strHtml.Append("<div style=\"background: #fff; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;  \">");

                    //Print HTML
                    strPrintHtml.Append("<div align='center' style='color: black; font-weight:bold; " +
                    " '>  <span><img src='" + Session["RootPath"].ToString() + "/images/cleared.png' style=\"position: absolute; margin-top: 100px; margin-left: 90px; \" /></span> </div>");
                }
                else
                {
                    strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;\">");
                }
                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">" + ddlTrafficTypes.SelectedValue.ToString() + "</div>");

                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px;  text-align:left;'>");
                //
                if (txtBulletinDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td width='48%' style='page-break-inside: avoid; padding: 4px;'>Date :</td>");
                    strHtml.Append("<td width='52%' style='page-break-inside: avoid; color: #353535;'>" + txtBulletinDate.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">Date :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\">" + txtBulletinDate.Text.Trim() + "</div>");
                }
                if (chkAccident.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkAccident.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkAccident.Text + "</div>");
                }
                if (chkRoadClosure.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkRoadClosure.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkRoadClosure.Text + "</div>");
                }
                if (chkConstruction.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkConstruction.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkConstruction.Text + "</div>");
                }
                if (chkWeather.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkWeather.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkWeather.Text + "</div>");
                }
                if (chkChains.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkChains.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkChains.Text + "</div>");
                }
                if (chkSnowLevel.Checked == true && txtSnowLevel.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style=page-break-inside: avoid; 'margin: 6px 4px 0px 4px;padding: 4px;'><strong>" + chkSnowLevel.Text + "</strong >:  " + txtSnowLevel.Text + "</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"><strong>" + chkSnowLevel.Text + "</strong >:  " + txtSnowLevel.Text + "</div>");
                }
                if (chkSpeicalEvent.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkSpeicalEvent.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkSpeicalEvent.Text + "</div>");
                }
                if (chkHazMat.Checked)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535; padding: 4px;'>" + chkHazMat.Text + "</td><td>&nbsp;</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\">" + chkHazMat.Text + "</div>");
                }
                if (chkOther.Checked == true && txtOther.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; margin: 6px 4px 0px 4px; padding: 4px;'><strong>" + chkOther.Text + "</strong >:  " + txtOther.Text + "</td>");
                    strHtml.Append("</tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"><strong>" + chkOther.Text + "</strong >:  " + txtOther.Text + "</div>");

                }
                if (chkTuneRadio.Checked == true && txtAM.Text.Trim() != "" && txtFM.Text.Trim() != "" && chkForRoadCondition.Checked == true && txtConditionsCall.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 6px 0px 10px; border:1px solid black; width:255px;'>" + chkTuneRadio.Text + "<br /><span style='padding-left: 15px;'> AM " + txtAM.Text + "</span><br /><span style='padding-left: 15px;'> FM " + txtFM.Text + "</span><br /><span style='padding-left: 15px;'> Road Conditions Call " + txtConditionsCall.Text + "</span></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"> <div style=\"border: 1px solid black; width:255px; padding: 8px 6px 0px 10px;\">" + chkTuneRadio.Text + "<br /><span style='padding-left: 15px;'> AM " + txtAM.Text + "</span><br /><span style='padding-left: 15px;'> FM " + txtFM.Text + "</span><br /><span style='padding-left: 15px;'> Road Conditions Call " + txtConditionsCall.Text + "</span></div></div>");

                }
                else if (chkTuneRadio.Checked == true && txtAM.Text.Trim() != "" && chkForRoadCondition.Checked == true && txtConditionsCall.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 6px 0px 10px; border:1px solid black; width:255px;'>" + chkTuneRadio.Text + "<br /><span style='padding-left: 15px;'> AM " + txtAM.Text + "</span><br /><span style='padding-left: 15px;'> Road Conditions Call " + txtConditionsCall.Text + "</span></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"> <div style=\"border: 1px solid black; width:255px; padding: 8px 6px 0px 10px;\">" + chkTuneRadio.Text + "<br /><span style='padding-left: 15px;'> AM " + txtAM.Text + "</span><br /><span style='padding-left: 15px;'> Road Conditions Call " + txtConditionsCall.Text + "</span></div></div>");
                }
                else if (chkTuneRadio.Checked == true && txtFM.Text.Trim() != "" && chkForRoadCondition.Checked == true && txtConditionsCall.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 6px 0px 10px; border:1px solid black; width:255px;'>" + chkTuneRadio.Text + "<br /><span style='padding-left: 15px;'> FM " + txtFM.Text + "</span><br /><span style='padding-left: 15px;'> Road Conditions Call " + txtConditionsCall.Text + "</span></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"> <div style=\"border: 1px solid black; width:255px; padding: 8px 6px 0px 10px;\">" + chkTuneRadio.Text + "<br /><span style='padding-left: 15px;'> FM " + txtFM.Text + "</span><br /><span style='padding-left: 15px;'> Road Conditions Call " + txtConditionsCall.Text + "</span></div></div>");
                }
                if (txtLocation.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Location :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtLocation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">Location :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\">" + txtLocation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                if (txtCity.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>City :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtCity.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">City :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\">" + txtCity.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                if (txtzipcode.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td style='page-break-inside: avoid; padding: 4px;'>Zip code :</td>");
                    strHtml.Append("<td style='page-break-inside: avoid; color: #353535;'>" + txtzipcode.Text.Trim() + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">Zip code :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\">" + txtzipcode.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** If uploaded the image *** //
                if (hdnAddImg1.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin-top: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    if (hdnAddImg1Link.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAddImg1.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; page-break-inside: avoid; float: left; text-align:center; margin-top: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + hdnAddImg1.Value + "\"/></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnAddImg1Link.Value + "' target='_blank'><img src='" + hdnAddImg1.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; page-break-inside: avoid; float: left; text-align:center; margin-top: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><a href='" + hdnAddImg1Link.Value + "' target='_blank'><img src='" + hdnAddImg1.Value + "'/></a></div>");
                    }
                    strHtml.Append("</td></tr>");
                }
                if (txtInformation.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Information :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtInformation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">Information :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\">" + txtInformation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                // *** If uploaded the image *** //
                if (hdnAddImg2.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin-top: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    if (hdnAddImg2Link.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnAddImg2.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; page-break-inside: avoid; float: left; text-align:center; margin-top: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + hdnAddImg2.Value + "\"/></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnAddImg2Link.Value + "' target='_blank'><img src='" + hdnAddImg2.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"page-break-inside: avoid; page-break-inside: avoid; float: left; text-align:center; margin-top: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><a href='" + hdnAddImg2Link.Value + "' target='_blank'><img src='" + hdnAddImg2.Value + "'/></a></div>");
                    }
                    strHtml.Append("</td></tr>");
                }
                if (chkWhenDate.Checked == true && txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 4px;'>When :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 20px;'><span style='margin-left:15px;'>From " + txtFromDate.Text + "</span> <br/> <span style='margin-left:25px;'>To " + txtToDate.Text + "</span></td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">When :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\"><span style='margin-left:0px;'>From " + txtFromDate.Text + "</span>  &nbsp;  <span style='margin-left:5px;'>To " + txtToDate.Text + "</span></div>");
                }
                if (chkClosureTime.Checked == true && (txtFromHours.Text.Trim() != "" && txtToHours.Text.Trim() != ""))
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
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 8px 4px 0px 4px;'>Expected Delay/Closure Time :</td></tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>From " + fromTime + "  &nbsp; To " + toTime + "</td></tr>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 215px; margin-right: 10px; margin-bottom: 10px;\">Expected Delay/Closure Time :</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 385px; margin-bottom: 10px;\">From " + fromTime + "  &nbsp; To " + toTime + "</div>");
                }
                strHtml.Append("</table>");
                if (chkPleaseLimit.Checked)
                {
                    strHtml.Append("<div style=\"overflow: hidden; float: left;\">");
                    strHtml.Append("<div style=\"float: left; text-align: center; width: 255px; padding: 3px 0px 0px 0px; margin: 2px 5px 0px 10px;\"><strong>Please limit phone calls. </strong></div></div>");

                    // PDF Print HTML 
                    strPrintHtml.Append("<div style=\"float: left; width: 600px; margin-right: 10px; margin-bottom: 10px;\"><strong>Please limit phone calls. </strong></div>");
                }

                strHtml.Append("</div>");
                BulletinHtml = strHtml.ToString().Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);

                // PDF Print HTML
                strPrintHtml.Append("</div>");
                strPrintHtml.Append("</div>");

                return BulletinHtml;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "BuildHTML", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                // Log 
                objInBuiltData.ErrorHandling("LOG", "CMTraffic.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);


                bool addflag = true;
                DateTime? dateExpires;
                DateTime? datePublish;
                DateTime? dateBulletin;

                dateExpires = null;
                datePublish = null;
                dateBulletin = null;

                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";
                bool isPublish = false;
                int? id = null;
                if (rbPublic.Checked)
                {
                    isPublish = true;
                    publishValue = "2";
                }
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);

                dateBulletin = Convert.ToDateTime(txtBulletinDate.Text.Trim());
                if (DateTime.Compare(Convert.ToDateTime(txtBulletinDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && CustomID == 0)
                {
                    lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate.Replace("Expiration", "Content") + "</font>";
                    txtBulletinDate.Focus();
                    addflag = false;
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
                            exHour = txtExHours.Text;
                            if (exHour == "")
                                exHour = "12";
                            exMin = txtExMinutes.Text;
                            if (exMin == "")
                                exMin = "00";
                            exSS = ddlExSS.SelectedValue.ToString();

                            exTime = exHour + ":" + exMin + ":00 " + exSS;
                        }
                        else
                        {
                            exHour = "12";
                            exMin = "00";
                            exSS = "AM";

                            exTime = exHour + ":" + exMin + ":00 " + exSS;
                        }
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + exTime);
                    }
                }
                if (addflag)
                {

                    #region XML String

                    BulletinXml = "<Bulletins><Bulletin    ";
                    //BulletinXML = BulletinXML + " Remarks='" + txtRemarks.Text.Trim().Replace("'", "&apos;") + "'";
                    BulletinXml = BulletinXml + " TrafficType='" + ddlTrafficTypes.SelectedValue.ToString() + "'";
                    BulletinXml = BulletinXml + " BulletinDate='" + txtBulletinDate.Text.Trim() + "'";
                    BulletinXml = BulletinXml + "  IsAccident='" + chkAccident.Checked + "'";
                    BulletinXml = BulletinXml + "  IsSpecialEvent='" + chkSpeicalEvent.Checked + "'";
                    BulletinXml = BulletinXml + "  IsRoadClosure='" + chkRoadClosure.Checked + "'";
                    BulletinXml = BulletinXml + "  IsHazMat='" + chkHazMat.Checked + "'";
                    BulletinXml = BulletinXml + "  IsConstruction='" + chkConstruction.Checked + "'";
                    BulletinXml = BulletinXml + "  IsOther='" + chkOther.Checked + "'";
                    BulletinXml = BulletinXml + "  Other='" + txtOther.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  IsWeather='" + chkWeather.Checked + "'";
                    BulletinXml = BulletinXml + "  IsChainsRequired='" + chkChains.Checked + "'";
                    BulletinXml = BulletinXml + "  IsSnowLevel='" + chkSnowLevel.Checked + "'";
                    BulletinXml = BulletinXml + "  SnowLevel='" + txtSnowLevel.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  IsTuneRadio='" + chkTuneRadio.Checked + "'";
                    BulletinXml = BulletinXml + "  AM='" + txtAM.Text.Trim() + "'";
                    BulletinXml = BulletinXml + "  FM='" + txtFM.Text.Trim() + "'";
                    BulletinXml = BulletinXml + "  IsRoadConditionCall='" + chkForRoadCondition.Checked + "'";
                    BulletinXml = BulletinXml + "  RoadConditionCall='" + txtConditionsCall.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  IsSaveforFuture='" + chkSaveFutureRef.Checked + "'";
                    BulletinXml = BulletinXml + "  Location='" + txtLocation.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  City='" + txtCity.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  Zipcode='" + txtzipcode.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  AddImage1='" + hdnAddImg1.Value + "'";
                    BulletinXml = BulletinXml + "  AddImage1Link='" + hdnAddImg1Link.Value + "'";
                    BulletinXml = BulletinXml + "  Information='" + txtInformation.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  AddImage2='" + hdnAddImg2.Value + "'";
                    BulletinXml = BulletinXml + "  AddImage2Link='" + hdnAddImg2Link.Value + "'";
                    BulletinXml = BulletinXml + "  IsWhenDates='" + chkWhenDate.Checked + "'";
                    BulletinXml = BulletinXml + "  FromDate='" + txtFromDate.Text.Trim() + "'";
                    BulletinXml = BulletinXml + "  ToDate='" + txtToDate.Text.Trim() + "'";
                    BulletinXml = BulletinXml + "  IsClosureTime='" + chkClosureTime.Checked + "'";

                    //BulletinXML = BulletinXML + "  FromTime='" + ddlFrom.SelectedValue.ToString() + "'";
                    //BulletinXML = BulletinXML + "  ToTime='" + ddlTo.SelectedValue.ToString() + "'";
                    BulletinXml = BulletinXml + "  FromHours='" + txtFromHours.Text + "'";
                    BulletinXml = BulletinXml + "  FromMinutes='" + txtFromMinutes.Text + "'";
                    BulletinXml = BulletinXml + "  FromSS='" + ddlFromSS.SelectedValue.ToString() + "'";
                    BulletinXml = BulletinXml + "  ToHours='" + txtToHours.Text + "'";
                    BulletinXml = BulletinXml + "  ToMinutes='" + txtToMinutes.Text + "'";
                    BulletinXml = BulletinXml + "  ToSS='" + ddlToSS.SelectedValue.ToString() + "'";

                    BulletinXml = BulletinXml + "  ExHours='" + exHour + "'";
                    BulletinXml = BulletinXml + "  ExMinutes='" + exMin + "'";
                    BulletinXml = BulletinXml + "  ExSS='" + exSS + "'";

                    BulletinXml = BulletinXml + "  IsPleaseLimit='" + chkPleaseLimit.Checked + "'";
                    BulletinXml = BulletinXml + "  IsCleared='" + chkCleared.Checked + "'";


                    BulletinXml = BulletinXml + "></Bulletin></Bulletins>";

                    #endregion

                    BulletinHtml = BuildHTML();

                    string customFormHeader = objCommon.GetCustomFormHeader(UserID);
                    string printerHtml = strPrintHtml.ToString().Replace("###CustomFormHeader###", customFormHeader);

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, CUserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXml, Convert.ToBoolean(hdnArchive.Value),
                                chkCall.Checked, false, chkContact.Checked, dateExpires, isPublish, datePublish, isPublish == false ? id : CUserID, ddlCategories.SelectedValue, printerHtml);
                        }
                        else   // for author
                        {
                            CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, CUserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXml, Convert.ToBoolean(hdnArchive.Value),
                                 chkCall.Checked, false, chkContact.Checked, dateExpires, false, datePublish, id, ddlCategories.SelectedValue, printerHtml);
                            if (isPublish)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), CustomID, PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.CustomModule, DomainName);
                        }
                    }
                    else
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, CUserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXml, Convert.ToBoolean(hdnArchive.Value),
                                chkCall.Checked, false, chkContact.Checked, dateExpires, isPublish, datePublish, isPublish == false ? id : CUserID, ddlCategories.SelectedValue, printerHtml);
                    }
                    /************************************ Auto Share ***************************************/
                    if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                    {
                        if (isPublish)
                        {
                            if (chkFbAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("ContentModule", CustomID, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, CUserID, BulletinName);
                            if (chkTwrAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("ContentModule", CustomID, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, CUserID, BulletinName);
                        }
                    }
                    if (BulletinCheckID > 0)
                    {
                        if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                            objCommon.UpdateSentFlag(CustomID, 2, 0, "ContentModule");
                    }
                    /****** Auto Share Completed ******/
                    objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    RemoveSession();
                    Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx");
                    Response.Redirect(Urlinfo);
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                // Error 
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "btnSave_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
        }

        private string BuildHeader()
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "CMTraffic.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("ERROR", "CMTraffic.aspx.cs", "BuildHeader", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }

        }

        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
        }
    }
}