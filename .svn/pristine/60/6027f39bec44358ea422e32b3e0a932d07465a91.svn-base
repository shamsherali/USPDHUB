using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFormsBLL;
using System.Configuration;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Text;


namespace UserForms
{
    public partial class CMChiefsMessage : BaseWeb
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();

        public int UserID = 0;
        public int ProfileID = 0;

        public string BulletinXml = string.Empty;
        public string BulletinHtml = string.Empty;
        public int CustomID = 0;
        public int BulletinCheckID = 0;
        public string BulletinName = string.Empty;
        public string Urlinfo = string.Empty;
        bool isPhoneNumber = true;
        bool isContatUs = true;
        public int CUserID = 0;
        public string RootPath = "";
        public string DomainName = "";
        public int CustomModuleId = 0;
        public int ModuleID = 0;
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public DataTable Dtpermissions = new DataTable();

        StringBuilder strPrintHtml;

        public string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["CustomModuleID"] != null && Session["FormID"] != null)
                {
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
                    ModuleID = Convert.ToInt32(Session["FormID"].ToString());
                }
                else
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");

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
                    //Urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageAddOns.aspx");
                    //Response.Redirect(Urlinfo);
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
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Image", "DisplayImage();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
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
        private void LoadDefaultData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "LoadDefaultData", string.Empty, string.Empty, string.Empty, string.Empty);
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
                DataTable dtSelectedTools = UserFormsDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                if (dtSelectedTools.Rows.Count > 0)
                {
                    string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                    isPhoneNumber = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                    isContatUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                    if (isPhoneNumber)
                        divCall.Visible = true;
                    else
                    {
                        divCall.Visible = false;
                        chkCall.Checked = false;
                    }
                    if (isContatUs)
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
                DataTable dtProfileAccTypes = objCommon.GetProfileAccessTypes(ProfileID, Resources.ProfileAccessMessages.ChiefHeaderTitleName);
                if (dtProfileAccTypes.Rows.Count > 0)
                    txtChiefName.Text = Convert.ToString(dtProfileAccTypes.Rows[0]["Message"]);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LoadFormData()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "LoadFormData", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtFormData = objAddOn.GetCustomModuleByID(CustomID);
                Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                BulletinXml = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(BulletinXml);
                hdnDefaultPerson.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@Photopath").Value;


                txtadditionalText.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@AdditionalText").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("<br/>", "\n").Replace("##NewLineSeparator##", "\n");
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@BulletinDate") != null)
                {
                    txtBulletinDate.Text = xmldoc.SelectSingleNode("Bulletins/Bulletin/@BulletinDate").Value;
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
                if (xmldoc.SelectSingleNode("Bulletins/Bulletin/@ImageLink") != null)
                {
                    hdnLink.Value = xmldoc.SelectSingleNode("Bulletins/Bulletin/@ImageLink").Value;
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
                if (isPhoneNumber == false)
                    chkCall.Checked = false;
                if (isContatUs == false)
                    chkContact.Checked = false;
                if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Bulletin_Category"].ToString()))
                    ddlCategories.SelectedValue = dtFormData.Rows[0]["Bulletin_Category"].ToString();


            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "LoadFormData", ex.Message,
                            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                DateTime? dateExpires;
                DateTime? datePublish;
                dateExpires = null;
                datePublish = null;
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
                objCommon.AddProfileAccessTypes(txtChiefName.Text.Trim(), Resources.ProfileAccessMessages.ChiefHeaderTitleName, UserID, ProfileID, CUserID);
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtBulletinDate.Text.Trim() != "")
                {
                    if (DateTime.Compare(Convert.ToDateTime(txtBulletinDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && CustomID == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate.Replace("Expiration", "Bulletin") + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                }

                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtNow.ToShortDateString())) < 0 && CustomID == 0)
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
                        exTime = ExpiryTimeControl1.SelectedTime;
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + exTime);
                    }
                }

                if (addflag)
                {


                    #region XML String

                    BulletinXml = "<Bulletins><Bulletin  Photopath='" + hdnDefaultPerson.Value + "'  ";
                    BulletinXml = BulletinXml + " " + "ImageLink='" + hdnLink.Value + "'";
                    BulletinXml = BulletinXml + " " + "ChiefName='" + txtChiefName.Text.Trim() + "'";
                    BulletinXml = BulletinXml + " " + "BulletinDate='" + txtBulletinDate.Text + "'";
                    BulletinXml = BulletinXml + " AdditionalText='" + txtadditionalText.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'";
                    BulletinXml = BulletinXml + "  ExHours='" + exHour + "'";
                    BulletinXml = BulletinXml + "  ExMinutes='" + exMin + "'";
                    BulletinXml = BulletinXml + "  ExSS='" + exSS + "'";
                    BulletinXml = BulletinXml + "></Bulletin></Bulletins>";

                    #endregion

                    BulletinHtml = BuildHtml();

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
                    objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
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
                    RemoveSession();
                    string urlPath = RootPath + "/Business/MyAccount/ManageAddOns.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinSuccess"].ToString());
                    Response.Redirect(Page.ResolveClientUrl(urlPath));

                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);

            MPEProgress.Hide();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "btnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                RemoveSession();
                Response.Redirect(Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageAddOns.aspx"));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "btnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "lnkPreview_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                lblbulletinamme.Text = BulletinName;
                string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", BuildHtml());
                lblPreview.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
                ModalPopupExtender1.Show();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHtml()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "BuildHTML", string.Empty, string.Empty, string.Empty, string.Empty);
                StringBuilder strHtml = new StringBuilder();
                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 15px 0px 40px 0px;\">");
                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">" + lblChiefStart.Text + txtChiefName.Text.Trim() + "</div>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px;  text-align:left;'>");

                // Print HTML
                strPrintHtml = new StringBuilder();
                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 670px; margin: 0 auto; padding: 10px; padding-bottom:0px; text-align:left;\">");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">" + lblChiefStart.Text + txtChiefName.Text.Trim() + "</h1>");
                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");

                //*** Image Binding
                if (hdnDefaultPerson.Value != "")
                {
                    strHtml.Append("<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>");
                    if (hdnLink.Value == "")
                    {
                        strHtml.Append("<img src=\"" + hdnDefaultPerson.Value + "\"/>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"font-weight: bold;  text-align:center; float: left; margin-right: 10px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><img src=\"" + hdnDefaultPerson.Value + "\" /></div>");
                    }
                    else
                    {
                        strHtml.Append("<a href='" + hdnLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a>");
                        // PDF Print HTML
                        strPrintHtml.Append("<div style=\"font-weight: bold;  text-align:center; float: left; margin-right: 10px; border: 1px solid #dddddd; padding: 0px; width:100%;\"><a href='" + hdnLink.Value + "' target='_blank'><img src='" + hdnDefaultPerson.Value + "'/></a></div>");
                    }
                    strHtml.Append("</td></tr>");
                }
                //*** Additional Information
                if (txtadditionalText.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<tr><td colspan='2' style='page-break-inside: avoid; color: #353535;'>" + txtadditionalText.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");// padding-left: 8px;

                    // PDF Print HTML
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 470px; margin-top: 5px;\">" + txtadditionalText.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");

                }

                strHtml.Append("</table>");
                strHtml.Append("</div>");
                BulletinHtml = strHtml.ToString().Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);

                // PDF Print HTML
                strPrintHtml.Append("</div>");
                strPrintHtml.Append("</div>");

                return BulletinHtml;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMChiefsMessage.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);

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
                objInBuiltData.ErrorHandling("ERROR", "CMChiefsMessage.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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