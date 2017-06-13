using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFormsBLL;
using System.Data;
using System.Xml.Linq;
using System.Collections;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml;

namespace UserForms
{
    public partial class PropertyListing : BaseWeb
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public string RootPath = "";
        public string DomainName = "";
        public string urlinfo = string.Empty;
        public int CUserID = 0;
        public int BulletinID = 0;
        public int BulletinCheckID = 0;
        public int TemplateBID = 0;
        public string BulletinName = string.Empty;
        bool IsPhoneNumber = true;
        bool IsContatUs = true;
        StringBuilder strPrintHtml;
        public string BulletinHtml = string.Empty;
        public string CustomXml = string.Empty;
        DateTime dtToday;
        CommonBLL objCommon = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        BusinessBLL objBus = new BusinessBLL();
        BulletinBLL objBulletin = new BulletinBLL();
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
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                CUserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                {
                    BulletinID = Convert.ToInt32(Session["BulletinID"]);
                    BulletinCheckID = Convert.ToInt32(Session["BulletinID"]);
                }
                else
                {
                    //string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx";
                    //urlinfo = Page.ResolveClientUrl(urlPath);
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
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
                hdnBulletinHeader.Value = preview;
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayImage();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PropertyListing.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PropertyListing.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadFormData()
        {
            try
            {
                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                if (dtFormData.Rows.Count > 0)
                {
                    BulletinID = Convert.ToInt32(dtFormData.Rows[0]["Bulletin_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
                    hdnEditHTML.Value = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]).Replace("undefined", "").Replace("id=\"trheader", "class=\"trheader\" id=\"trheader");
                    lblEditText.Text = hdnEditHTML.Value;
                    string previewHtml = Convert.ToString(dtFormData.Rows[0]["Bulletin_HTML"]);
                    hdnPreviewHTML.Value = previewHtml;
                    lbldummy.Text = previewHtml;
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
                    if (!File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + BulletinID.ToString() + ".jpg"))
                    {
                        objInBuiltData.CreateImage(ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
                    }
                    if (!string.IsNullOrEmpty(txtExpires.Text.Trim()))
                    {
                        //txtExHours.Enabled = true;
                        //txtExMinutes.Enabled = true;
                        //ddlExSS.Enabled = true;
                        ExpiryTimeControl1.Enabled = true;
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false;
                        //txtExHours.Enabled = false;
                        //txtExMinutes.Enabled = false;
                        //ddlExSS.Enabled = false;
                    }
                    if (Convert.ToString(dtFormData.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        ExpiryTimeControl1.SelectedTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortTimeString();
                        ExpiryTimeControl1.Enabled = true;
                        //txtExHours.Enabled = true;
                        //txtExMinutes.Enabled = true;
                        //ddlExSS.Enabled = true;
                        //DateTime expiryTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]);
                        //if (expiryTime.ToString().Contains("PM"))
                        //{
                        //    if (expiryTime.Hour > 12)
                        //    {
                        //        txtExHours.Text = (expiryTime.Hour - 12).ToString();
                        //    }
                        //    else
                        //    {
                        //        txtExHours.Text = (expiryTime.Hour).ToString();
                        //    }
                        //    ddlExSS.SelectedValue = "PM";
                        //}
                        //else
                        //{
                        //    if (expiryTime.Hour == 0)
                        //    {
                        //        txtExHours.Text = "12";
                        //    }
                        //    else
                        //    {
                        //        txtExHours.Text = (expiryTime.Hour).ToString();
                        //    }
                        //    ddlExSS.SelectedValue = "AM";
                        //}
                        //txtExMinutes.Text = expiryTime.Minute.ToString();
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false;
                        //txtExHours.Enabled = false;
                        //txtExMinutes.Enabled = false;
                        //ddlExSS.Enabled = false;
                    }
                    chkCall.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsCall"].ToString());
                    chkContact.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsContactUs"].ToString());
                    if (IsPhoneNumber == false)
                        chkCall.Checked = false;
                    if (IsContatUs == false)
                        chkContact.Checked = false;

                    CustomXml = Convert.ToString(dtFormData.Rows[0]["Custom_XML"]);
                    hdnEditXML.Value = CustomXml;
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(CustomXml);
                    if (hdnEditXML.Value.Trim() != "")
                    {
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@DefaultImg") != null)
                            hdnDefaultProperty.Value = xmldoc.SelectSingleNode("Bulletins/Details/@DefaultImg").Value;
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@DefaultImgLink") != null)
                            hdnDPLink.Value = xmldoc.SelectSingleNode("Bulletins/Details/@DefaultImgLink").Value;
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Address") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Address").Value.ToString()))
                                txtAddress.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Address").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Details1") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Details1").Value.ToString()))
                                txtAddDetails1.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Details1").Value.Replace("&apos;", "'").Replace("&amp;", "&").ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Price") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Price").Value.ToString()))
                                txtPrice.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Price").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@SquareFeet") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@SquareFeet").Value.ToString()))
                                txtFeet.Text = xmldoc.SelectSingleNode("Bulletins/Details/@SquareFeet").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Bedrooms") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Bedrooms").Value.ToString()))
                                txtBedrooms.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Bedrooms").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Bathrooms") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Bathrooms").Value.ToString()))
                                txtBathrooms.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Bathrooms").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Status") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Status").Value.ToString()))
                                txtStatus.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Status").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Details2") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Details2").Value.ToString()))
                                txtAddDetails2.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Details2").Value.Replace("&apos;", "'").Replace("&amp;", "&").ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@WebLink") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@WebLink").Value.ToString()))
                                txtWeb.Text = xmldoc.SelectSingleNode("Bulletins/Details/@WebLink").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@ContentCall") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@ContentCall").Value.ToString()))
                                txtContentPhone.Text = xmldoc.SelectSingleNode("Bulletins/Details/@ContentCall").Value.ToString();
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "LoadData();", true);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PropertyListing.aspx.cs", "LoadFormData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            RemoveSession();
            Response.Redirect(Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageBulletins.aspx"));
        }
        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
            Session.Remove("TemplateBID");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePublishDate())
                {
                    Save_Update_Details();
                    Session["msgSave"] = "Content has been saved successfully.";
                    string urlPath = RootPath + "/Business/MyAccount/ManageBulletins.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["msgSave"].ToString());
                    string urlinfo = Page.ResolveClientUrl(urlPath);
                    Response.Redirect(urlinfo);
                }

                lblEditText.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PropertyListing.aspx.cs", "BtnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private bool ValidatePublishDate()
        {
            try
            {
                bool addflag = true;
                dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtPublishDate.Text.Trim() != "")
                {
                    DateTime publishDate = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        addflag = false;
                    }
                }
                if (txtExpires.Text.Trim() != "")
                {
                    string ExpDateTime = "";
                    if (!string.IsNullOrEmpty(txtExpires.Text.Trim()))
                    {
                        ExpDateTime = txtExpires.Text + " " + ExpiryTimeControl1.SelectedTime;
                        ExpiryTimeControl1.Enabled = true;
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
                        addflag = false;
                    }
                }
                return addflag;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PropertyListing.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }
        private bool Save_Update_Details()
        {
            bool isSuccess = true;
            try
            {
                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                string editHtmlText = hdnEditHTML.Value.ToString().Replace("class=\"trheader\" id=\"trheader", "id=\"trheader");
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
                bool isCall = chkCall.Checked; ;
                bool isPhotoCapture = false;
                bool isContactUs = chkContact.Checked;
                int? id = null;
                bool isPublish = false;

                if (hdnPrivate.Value.ToString().Trim() != string.Empty)
                {
                    isPublish = Convert.ToBoolean(hdnPrivate.Value.ToString().Trim());
                }
                string printHTML = hdnPrintHTML.Value;
                string CategoryName = ddlCategories.SelectedValue;// "Property Listing";

                if (rbPublic.Checked)
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }
                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                //var exTime = "";
                var exTime = ExpiryTimeControl1.SelectedTime;
                bool isPrivate = true;
                if (rbPrivate.Checked)
                {
                    isPrivate = false;
                    // isPublish = false;
                }
                int bulletinCheckID = 0;
                if (exDate == string.Empty)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, false, id, printHTML, customXML);
                            if (isPrivate == true)
                                objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, PageNames.BULLETIN, userID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                        }
                    }
                }
                else
                {
                    //if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
                    //{
                    //    exHour = txtExHours.Text;
                    //    if (exHour == "")
                    //        exHour = "12";
                    //    exMin = txtExMinutes.Text;
                    //    if (exMin == "")
                    //        exMin = "00";
                    //    exSS = ddlExSS.SelectedValue.ToString();

                    //    exTime = exHour + ":" + exMin + ":00 " + exSS;
                    //}
                    //else
                    //{
                    //    exHour = "12";
                    //    exMin = "00";
                    //    exSS = "AM";

                    //    exTime = exHour + ":" + exMin + ":00 " + exSS;
                    //}


                    DateTime expiryDate = Convert.ToDateTime(txtExpires.Text.Trim() + " " + exTime);
                    bulletinCheckID = bulletinID;
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
                objInBuiltData.CreateImage(ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\Upload\\Bulletins\\", profileID, userID, Convert.ToInt32(bulletinID), previewHtml);

                /************************************ Auto Share ***************************************/
                if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                {
                    if (isPrivate)
                    {
                        if (txtPublishDate.Text == "")
                        { txtPublishDate.Text = dtToday.ToShortDateString(); }


                        if (chkFbAutoPost.Checked)
                            objCommon.InsertUpdateAutoShareDetails("Bulletin", bulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, CUserID, bulletinTitle);
                        if (chkTwrAutoPost.Checked)
                            objCommon.InsertUpdateAutoShareDetails("Bulletin", bulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, CUserID, bulletinTitle);
                    }
                }
                if (bulletinCheckID > 0)
                {
                    if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                        objCommon.UpdateSentFlag(bulletinID, 2, 0, "Bulletin");
                }
                /****** Auto Share Completed ******/

                //Messages
                if (Convert.ToInt32(Session["BulletinID"]) == 0)
                {
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                else
                {
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                Session["BulletinID"] = bulletinID;
            }
            catch (Exception ex)
            {
                //Error 
                isSuccess = false;
                objInBuiltData.ErrorHandling("ERROR", "PropertyListing.aspx.cs", "Save_Update_Details", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return isSuccess;
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