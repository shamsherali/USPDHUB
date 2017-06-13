using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFormsBLL;
using System.Data;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;
using System.Web.Services;

namespace UserForms
{
    public partial class CrisisCallLog : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;

        BusinessBLL objBus = new BusinessBLL();
        UserFormsBLL.MobileAppSettings objMobileApp = new UserFormsBLL.MobileAppSettings();
        CommonBLL objCommon = new CommonBLL();
        public DataTable Dtpermissions = new DataTable();

        public int CUserID = 0;
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        static BulletinBLL objBulletin = new BulletinBLL();

        Consumer objConsumer = new Consumer();

        DataTable dtAssociates = new DataTable();
        DateTime dtToday;
        public string RootPath = "";
        public string DomainName = "";
        public string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                int saveProcessID = 0;

                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                /*** Store Module Functionality ***/
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduleEmails = true;
                }
                if (!IsPostBack)
                {
                    LoadDefaultData();

                    if (Request.QueryString["BulletinID"] != null)
                    {
                        Session["BulletinID"] = Request.QueryString["BulletinID"];
                    }

                    if (Convert.ToInt32(Session["BulletinID"]) == 0 || Session["BulletinID"] == null || Session["BulletinID"].ToString() == "")
                    {
                        //New Bulletin
                        lblBulletinName.Text = Convert.ToString(Session["BulletinName"]);
                        txtbulletinName.Text = Convert.ToString(Session["BulletinName"]);

                        DataTable dtBulletin = objBulletin.CheckBulletin(UserID, string.Empty, Convert.ToInt32(Session["TemplateBID"]), string.Empty);
                        Session["TemplateName"] = Convert.ToString(dtBulletin.Rows[0]["Template_Name"]);
                    }
                    else
                    {
                        GetBulletinDetails();
                        saveProcessID++;
                    }

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel1.Visible = true;
                            //UpdatePanel3.Visible = UpdatePanel2.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit contents.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here



                    string preview = string.Empty;
                    preview = objCommon.GetHeaderForBulletins(UserID, ProfileID);
                    hdnBulletinHeader.Value = preview;

                    //Load System Time
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    txtlogoutDate.Text = dtToday.ToShortDateString();
                    ddllogouthour.SelectedValue = dtToday.ToString("hh");
                    txtlogoutmin.Text = dtToday.Minute.ToString();
                    if (dtToday.TimeOfDay.Hours >= 12)
                    {
                        ddllogoutsection.SelectedValue = "PM";
                    }
                    else
                    {
                        ddllogoutsection.SelectedValue = "AM";
                    }

                }

                lblPublish.Text = hdnPublishTitle.Value;


            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "BtnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx";

                string urlinfo = Page.ResolveClientUrl(urlPath);
                HttpContext.Current.Response.Redirect(urlinfo);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidatePublishDate())
            {
                //Save & Update Bulletins
                Save_Update_BulletinDetails();
                //Getting Bulletin Details
                GetBulletinDetails();
                //
                BuildHeader();

                lblmess.Text = "Content saved successfully.";
            }

            MPEProgress.Hide();
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "BtnPublish_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublic.Checked)
                    publishValue = "2";
                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();


                    string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx";
                    string urlinfo = Page.ResolveClientUrl(urlPath);
                    HttpContext.Current.Response.Redirect(urlinfo);
                }

                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "BtnPublish_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublishSave('" + publishValue + "');", true);
        }

        private bool ValidatePublishDate()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "ValidatePublishDate", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtPublishDate.Text.Trim() != "")
                {
                    DateTime publishDate = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        // txt.Focus();
                        addflag = false;
                    }
                }
                if (txtExDate.Text.Trim() != "")
                {
                    string ExpDateTime = "";
                    if (!string.IsNullOrEmpty(txtExDate.Text.Trim()))
                    {
                        ExpiryTimeControl1.Enabled = true;

                        ExpDateTime = txtExDate.Text.Trim() + " " + ExpiryTimeControl1.SelectedTime;
                    }

                    if (Convert.ToDateTime(ExpDateTime) < dtToday)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        addflag = false;
                    }
                }

                return addflag;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }

        private void GetBulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "GetBulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Edit Bulletin
                DataTable dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(Session["BulletinID"]));

                if (dtBulletinDetails.Rows.Count > 0)
                {
                    Session["BulletinName"] = dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString();

                    lblBulletinName.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_Title"]);

                    hdnEditHTML.Value = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]).Replace("undefined", "");
                    lblBulletinedit.Text = hdnEditHTML.Value;

                    #region Custom XML

                    hdnEditXML.Value = Convert.ToString(dtBulletinDetails.Rows[0]["Custom_XML"]);
                    XmlDocument xmldoc = new XmlDocument();
                    if (hdnEditXML.Value.Trim() != "")
                    {
                        string xml = hdnEditXML.Value;

                        //xml = xml.Replace("&", "&amp");
                        //xml = xml.Replace("&amp;amp;", "&amp");

                        xmldoc.LoadXml(xml);

                        txtbulletinName.Text = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@BulletinName").Value;
                        ddlloginhour.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LoginHour").Value;
                        txtloginMins.Text = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LoginMin").Value;
                        ddlloginsection.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LoginSection").Value;
                        txtlogindate.Text = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LoginDate").Value;

                        txtlogoutDate.Text = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LogOutDate").Value;
                        ddllogouthour.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LogOutHour").Value;
                        txtlogoutmin.Text = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LogOutMin").Value;
                        ddllogoutsection.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@LogOutSection").Value;

                        if (xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@Associate1") != null)
                        {
                            ddlAssociates1.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@Associate1").Value;
                        }
                        ddlAssociates2.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CallLogDetails/@TransferredPhoneTo").Value;
                    }

                    #endregion

                    string previewHtml = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);
                    hdnPreviewHTML.Value = previewHtml;

                    lbldummy.Text = previewHtml;

                    if (Convert.ToString(dtBulletinDetails.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExDate.Text = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]).ToShortDateString();
                        ExpiryTimeControl1.Enabled = true;
                        ExpiryTimeControl1.SelectedTime = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]).ToShortTimeString();
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false;
                    }

                    Session["TemplateName"] = Convert.ToString(dtBulletinDetails.Rows[0]["Template_Name"]);

                    bool isPrivate = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsPrivate"]);

                    if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Bulletin_Category"].ToString()))
                        ddlCategories.SelectedValue = dtBulletinDetails.Rows[0]["Bulletin_Category"].ToString();
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Publish_Date"].ToString()))
                    {
                        DateTime dtPublish = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Publish_Date"]);
                        if (DateTime.Compare(dtPublish, dtNow) < 0)
                            txtPublishDate.Text = dtNow.ToShortDateString();
                        else
                            txtPublishDate.Text = dtPublish.ToShortDateString();
                    }

                    rbPrivate.Checked = true;
                    if (Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsPrivate"].ToString()) == false)
                        rbPublic.Checked = true;

                    //Create Bulletin Image
                    string bulletinImgPath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + Convert.ToString(Session["ProfileID"]) + "\\" + Convert.ToString(Session["BulletinID"]) + ".jpg";
                    if (!File.Exists(bulletinImgPath))
                    {
                        objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", Convert.ToInt32(Session["ProfileID"]),
                            UserID, Convert.ToInt32(Session["BulletinID"]), previewHtml);
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "LoadData();", true);
                }


            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "GetBulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Save_Update_BulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "Save_Update_BulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                string editHtmlText = hdnEditHTML.Value.ToString();
                string previewHtml = hdnPreviewHTML.Value.ToString();
                string exDate = hdnExDate.Value.ToString();
                string customXML = hdnEditXML.Value;

                DateTime? datePublish;
                datePublish = null;

                int bulletinID = Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]);
                int templateBid = Convert.ToInt32(System.Web.HttpContext.Current.Session["TemplateBID"]);
                string bulletinTitle = Convert.ToString(System.Web.HttpContext.Current.Session["BulletinName"]);
                int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                bool isArchive = false;
                int profileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                bool isCall = false;
                bool isPhotoCapture = false;
                bool isContactUs = false;
                int? id = null;
                bool isPublish = Convert.ToBoolean(hdnPrivate.Value);
                //bool isPublish = true;

                string printHTML = "";

                string CategoryName = ddlCategories.SelectedValue;

                //if (txtPublishDate.Text.Trim() != "")
                //{
                //    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                //}

                if (rbPublic.Checked)
                {
                    datePublish = dtToday;
                }

                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";

                bool isPrivate = true;
                if (rbPrivate.Checked)
                {
                    isPrivate = false;
                    // isPublish = false;
                }

                if (exDate == string.Empty)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, false, id, printHTML, customXML);
                            if (isPrivate == true)
                                objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, PageNames.BULLETIN, userID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                        }
                    }
                }
                else
                {

                    exTime = ExpiryTimeControl1.SelectedTime;
                    DateTime expiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
                    //                    DateTime expiryDate = Convert.ToDateTime(exDate);

                    //Insert & Update Bulletin Details
                    //BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinTitle, previewHTML,
                    //     editHTMLText, UserID, UserID, IsArchive, UserID, ProfileID, IsCall, IsPhotoCapture, IsContactUs, IsPublish, expiryDate, datePublish, ddlCategories.SelectedValue);

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, false, id, printHTML, customXML);
                            if (isPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, "Bulletin", userID, Session["username"].ToString(), "Bulletin", DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                        }
                    }
                }

                //Create Bulletin Image
                objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", profileID, userID, Convert.ToInt32(bulletinID), previewHtml);

                //Messages
                if (Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                else
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", bulletinTitle);
                }

                System.Web.HttpContext.Current.Session["BulletinID"] = bulletinID;
                string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
                Response.Redirect(Page.ResolveClientUrl(urlPath));

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrisisCallLog.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);


                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                int ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                string appSettings = string.Empty;

                bool IsBName = false;
                bool IsLogo = false;
                bool IsEmergencyNumber = false;
                string EmergencyPhoneNumber = "";

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

                //Getting Business Details
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                //Getting Mobile App Settings
                DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    appSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var XMLTools = XElement.Parse(appSettings, LoadOptions.PreserveWhitespace);

                    IsBName = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("BName").Value);
                    IsLogo = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("Logo").Value);
                    IsEmergencyNumber = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEmergencyNumber").Value);

                    EmergencyPhoneNumber = Convert.ToString(XMLTools.Element("Tools").Attribute("EmergencyNumber").Value);
                }
                //

                if (dtProfile.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()) && IsBName == true)
                    {
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    }
                    else
                    {
                        strHeader = strHeader.Replace("#BusinessProfileName#", "");
                    }

                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && IsLogo == true)
                    {
                        strHeader = strHeader.Replace("#HeaderLogo#", objInBuiltData.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, ProfileID));
                    }
                    else
                    {
                        strHeader = strHeader.Replace("#HeaderLogo#", "");
                    }
                    if (EmergencyPhoneNumber != string.Empty && IsEmergencyNumber == true)
                    {
                        strHeader = strHeader.Replace("#EmergencyNumber#", EmergencyPhoneNumber);
                    }
                    else
                    {
                        strHeader = strHeader.Replace("#EmergencyNumber#", "");
                    }
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
                objInBuiltData.ErrorHandling("ERROR", "CrisisCallLog.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        private void LoadDefaultData()
        {
            #region Fill Bulletin Categories

            //DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
            //DataRow[] drCategories = dtLabelData.Select("Type='BulletinCategories'");
            //foreach (DataRow row in drCategories)
            //{
            //    ddlCategories.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
            //}
            //ddlCategories.SelectedValue = "Low";


            DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID);
            if (dtCategories.Rows.Count > 0)
            {
                ddlCategories.DataSource = dtCategories;
                ddlCategories.DataTextField = "Category_Name";
                ddlCategories.DataValueField = "Category_Name";
                ddlCategories.DataBind();
                if (Session["BulletinCategoryName"] != null)
                    ddlCategories.SelectedValue = Session["BulletinCategoryName"].ToString();
            }


            #endregion

            /*
            //string GetData = "select distinct User_ID,Firstname,Lastname,Username,Active_flag,Password,SuperAdmin_ID, CASE WHEN IsTipsAdmin = 1 THEN 'Yes' ELSE 'No' END AS IsTipsAdmin from T_Users a left outer join dbo.T_Associate_Permissions b on a.User_ID=b.Associate_ID where SuperAdmin_ID is not null and Active_flag=1 and SuperAdmin_ID=" + UserID + " ORDER BY User_ID desc";
            string GetData = "select distinct User_ID,Firstname,Lastname,Username,Active_flag,Password,SuperAdmin_ID, CASE WHEN IsTipsAdmin = 1 THEN 'Yes' ELSE 'No' END AS IsTipsAdmin from T_Users a left outer join dbo.T_Associate_Permissions b on a.User_ID=b.Associate_ID where Active_flag=1 and SuperAdmin_ID=" + UserID + " OR User_ID=" + UserID + " ORDER BY User_ID desc";
            SqlConnection sqlCon = UserFormsDAL.ConnectionManager.Instance.GetSQLConnection();
            SqlCommand sqlCmd = new SqlCommand(GetData, sqlCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            da.Fill(dtAssociates);
            UserFormsDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            */

            dtAssociates = objConsumer.GetActiveAssociates(Convert.ToInt32(UserID));

            ddlAssociates1.DataSource = dtAssociates;
            ddlAssociates1.DataTextField = "Firstname";
            ddlAssociates1.DataValueField = "Firstname";
            ddlAssociates1.DataBind();
            ddlAssociates1.SelectedIndex = 0;

            ddlAssociates2.DataSource = dtAssociates;
            ddlAssociates2.DataTextField = "Firstname";
            ddlAssociates2.DataValueField = "Firstname";
            ddlAssociates2.DataBind();
            ddlAssociates2.SelectedIndex = 0;


            //DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
            //if (dtProfile.Rows.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()))
            //        lblLogo.Text = objInBuiltData.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, ProfileID);

            //}
            //lblHeaderAddress.Text = objCommon.GetBulletinFormHeader(UserID, ProfileID);
            lblLogoHeader.Text = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath);
        }

        [WebMethod]
        public static string GetCallertypeAgency()
        {
            string Agencystring = "";

            DataTable dtAgency = objBulletin.GetCallerAgencyByPID(Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]));
            for (int i = 0; i < dtAgency.Rows.Count; i++)
            {
                Agencystring = Agencystring + dtAgency.Rows[i]["Agency_Name"] + ",";
            }

            if (Agencystring.EndsWith(","))
            {
                Agencystring = Agencystring.Remove(Agencystring.Length - 1);
            }
            return Agencystring;
        }

        [WebMethod]
        public static string GetCallerTypeRegions()
        {
            string returnString = "";

            DataTable dtAgency = objBulletin.GetAllRegionsByPID(Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]), "CallerType");
            for (int i = 0; i < dtAgency.Rows.Count; i++)
            {
                returnString = returnString + dtAgency.Rows[i]["Region_Name"] + ",";
            }

            if (returnString.EndsWith(","))
            {
                returnString = returnString.Remove(returnString.Length - 1);
            }
            return returnString;
        }

        [WebMethod]
        public static string GetCallerRequestRegions()
        {
            string returnString = "";

            DataTable dtAgency = objBulletin.GetAllRegionsByPID(Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]), "CallerRequest");
            for (int i = 0; i < dtAgency.Rows.Count; i++)
            {
                returnString = returnString + dtAgency.Rows[i]["Region_Name"] + ",";
            }

            if (returnString.EndsWith(","))
            {
                returnString = returnString.Remove(returnString.Length - 1);
            }
            return returnString;
        }

        [WebMethod]
        public static string GetOfficers(string regionName)
        {
            string returnString = "";

            DataTable dtofficers = objBulletin.GetOfficersByRegionName(regionName);
            for (int i = 0; i < dtofficers.Rows.Count; i++)
            {
                returnString = returnString + dtofficers.Rows[i]["Officer_Name"] + ",";
            }

            if (returnString.EndsWith(","))
            {
                returnString = returnString.Remove(returnString.Length - 1);
            }
            return returnString;

        }

        [WebMethod]
        public static IList<string> GetBulletinAutoCompleteData(string bulletinName)
        {
            List<string> result = new List<string>();
            SqlConnection sqlCon = UserFormsDAL.ConnectionManager.Instance.GetSQLConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("select DISTINCT Bulletin_Title from T_Manage_Bulletins where Profile_ID=" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]) + " AND Bulletin_Title LIKE '%" + bulletinName + "%'", sqlCon))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["Bulletin_Title"].ToString());
                    }
                }
                return result;
            }
            catch (Exception /*ex*/)
            {
                return result;
            }
            finally
            {
                UserFormsDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        [System.Web.Services.WebMethod]
        public static string ReplaceShortURltoHmlString(string htmlString)
        {
            CommonBLL objCommonBll = new CommonBLL();
            htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);

            return htmlString;
        }
    }

}