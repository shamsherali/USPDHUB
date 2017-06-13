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
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml;

namespace UserForms
{
    public partial class CMMediaRelease : System.Web.UI.Page
    {
        Utilities objUtility = new Utilities();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        CommonBLL objCommon = new CommonBLL();
        AddOnBLL objAddOn = new AddOnBLL();

        BusinessBLL objBus = new BusinessBLL();

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
        public string CustomXml = string.Empty;
        DateTime dtToday;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
                hdnBulletinHeader.Value = preview;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMWanted.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
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
                objInBuiltData.ErrorHandling("ERROR", "CMMediaRelease.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadFormData()
        {
            try
            {
                DataTable dtFormData = objAddOn.GetCustomModuleByID(CustomID);
                if (dtFormData.Rows.Count > 0)
                {
                    CustomID = Convert.ToInt32(dtFormData.Rows[0]["Custom_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    
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
                    if (Convert.ToBoolean(dtFormData.Rows[0]["IsPublished"].ToString()) == true)
                    {
                        rbPublic.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }
                    if (!File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + CustomID.ToString() + ".jpg"))
                    {
                        objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
                    }
                 
                    if (Convert.ToString(dtFormData.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExpires.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        ExpiryTimeControl1.Enabled = true;
                        ExpiryTimeControl1.SelectedTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortTimeString();                        
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false; 
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
                        string str = null;
                        string[] strArr = null;
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Location") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Location").Value.ToString()))
                                txtLocation.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Location").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@CaseNumber") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@CaseNumber").Value.ToString()))
                            {
                                str = xmldoc.SelectSingleNode("Bulletins/Details/@CaseNumber").Value.ToString();
                                char[] splitchar = { '-' };
                                strArr = str.Split(splitchar);
                                txtStartIncidentNo.Text = strArr[0];
                                txtEndIncidentNo.Text = strArr[1];
                            }

                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@DateTime") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@DateTime").Value.ToString()))
                            {
                                if (xmldoc.SelectSingleNode("Bulletins/Details/@Date") != null)
                                {
                                    if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Date").Value.ToString()))
                                    {
                                        txtIncidentDate.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Date").Value.ToString();
                                    }

                                }
                                if (xmldoc.SelectSingleNode("Bulletins/Details/@Time") != null)
                                {
                                    if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Time").Value.ToString()))
                                    {
                                        txtIncidentTime.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Time").Value.ToString();
                                    }
                                }
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "LoadData();", true);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMMediaRelease.aspx.cs", "LoadFormData", ex.Message,
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
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePublishDate())
                {
                    Save_Update_Details();
                    Session["msgSave"] = "Content has been saved successfully.";
                    string urlPath = RootPath + "/Business/MyAccount/ManageAddOns.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
                    Response.Redirect(Page.ResolveClientUrl(urlPath));
                }
                lblEditText.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMMediaRelease.aspx.cs", "BtnSave_Click", ex.Message,
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
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && CustomID == 0)
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
                        ExpiryTimeControl1.Enabled = true;
                        ExpDateTime = txtExpires.Text.Trim() + " " + ExpiryTimeControl1.SelectedTime;
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
                objInBuiltData.ErrorHandling("ERROR", "CMMediaRelease.aspx.cs", "ValidatePublishDate", ex.Message,
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
                BulletinHtml = hdnPreviewHTML.Value.ToString();
                string exDate = hdnExDate.Value.ToString();
                string customXML = hdnEditXML.Value;
                BulletinXML = editHtmlText;

                DateTime? datePublish;
                datePublish = null;

                int bulletinID = Convert.ToInt32(Session["BulletinID"]);
                string bulletinTitle = Convert.ToString(Session["BulletinName"]);
                bool isCall = chkCall.Checked;
                bool isContactUs = chkContact.Checked;
                int? id = null;
                bool IsPublish = false;

               
                string printHTML = hdnPrintHTML.Value;
                string CategoryName = ddlCategories.SelectedValue; //"Media Release"

                if (rbPublic.Checked)
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    IsPublish = true;
                }
                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = ExpiryTimeControl1.SelectedTime;
                DateTime? dateExpires;
                dateExpires = null;
                if (exDate != "")
                { 
                    dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + exTime);
                }
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    string returnvalue = string.Empty;
                    if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXML, Convert.ToBoolean(hdnArchive.Value),
                            chkCall.Checked, false, chkContact.Checked, dateExpires, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printHTML, customXML);
                    }
                    else   // for author
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXML, Convert.ToBoolean(hdnArchive.Value),
                            chkCall.Checked, false, chkContact.Checked, dateExpires, false, datePublish, id, ddlCategories.SelectedValue, printHTML, customXML);
                        if (IsPublish)
                            returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), CustomID, PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.CustomModule, DomainName);
                    }

                }
                else
                {
                    CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, BulletinHtml, BulletinXML, Convert.ToBoolean(hdnArchive.Value),
                            chkCall.Checked, false, chkContact.Checked, dateExpires, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printHTML, customXML);
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
                        objCommon.UpdateSentFlag(bulletinID, 2, 0, "Bulletin");
                }
                /****** Auto Share Completed ******/
                //Create Bulletin Image
                objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, BulletinHtml);
                Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                if (BulletinCheckID > 0)
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                RemoveSession();
                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                isSuccess = false;
                objInBuiltData.ErrorHandling("ERROR", "CMMediaRelease.aspx.cs", "Save_Update_Details", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return isSuccess;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveSession();
            Response.Redirect(Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageAddOns.aspx"));
        }
        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
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