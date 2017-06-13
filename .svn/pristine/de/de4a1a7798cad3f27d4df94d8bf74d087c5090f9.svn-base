using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace USPDHUB.Business.MyAccount
{
    public partial class CMEditBulletin : BaseWeb
    {
        USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        public string RootPath = "";
        public string DomainName = "";
        public int CustomID = 0;
        public int BulletinCheckID = 0;
        public string BulletinName = string.Empty;
        public string urlinfo = string.Empty;
        public int C_UserID = 0;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public int CustomModuleId = 0;
        bool IsCall = true;
        bool IsContatUs = true;
        bool IsPublish = false;
        bool IsArchive = false;
        public int ModuleID = 0;
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public string ModuleName = string.Empty;
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMCMEditBulletin.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                //Session["BulletinID"] = 8;

                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["CustomModuleID"] != null && Session["FormID"] != null)
                {
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
                    ModuleID = Convert.ToInt32(Session["FormID"].ToString());
                }
                else
                {
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

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
                    //urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx");
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
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit app content.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here
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

                    #region Checking Global mobile app settings

                    // *** Checking Global mobile app settings *** //
                    DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                        var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                        IsCall = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                        IsContatUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                        if (IsCall)
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

                    #endregion


                    if (CustomID == 0)
                    {
                        //New Bulletin
                        lblBulletinName.Text = Convert.ToString(Session["BulletinName"]);

                    }
                    else
                    {
                        GetBulletinDetails();
                    }
                    GetAutoShareRecordStatus();
                }
                lblPublish.Text = hdnPublishTitle.Value;
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID);
                hdnBulletinHeader.Value = preview;

                //Font-Family Profile Base
                DataTable dtProfileAddress = new DataTable();
                dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                {
                    hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                }

                //Font-Family Drop Down
                Maintoolbar.Items[1].Text = hdnUserFont.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMCMEditBulletin.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            try
            {
                if (Session["IsPrivate"] == null)
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMCMEditBulletin.aspx.cs", "GetAutoShareRecordStatus", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx"));
        }

        private void GetBulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMEditBulletin.aspx.cs", "GetBulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Edit Bulletin
                DataTable dtBulletinDetails = objAddOn.GetCustomModuleByID(CustomID);

                if (dtBulletinDetails.Rows.Count > 0)
                {
                    Session["BulletinName"] = BulletinName = dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString();

                    lblBulletinName.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_Title"]);
                    lblBulletinedit.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]);
                    hdnEditHTML.Value = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]);
                    string previewHtml = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);
                    string customXML = Convert.ToString(dtBulletinDetails.Rows[0]["Custom_XML"]);

                    if (Convert.ToString(dtBulletinDetails.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExDate.Text = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]).ToShortDateString();
                        DateTime expiryTime = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]);

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

                    chkCall.Checked = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsCall"].ToString());
                    chkContact.Checked = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsContactUs"].ToString());
                    if (IsCall == false)
                        chkCall.Checked = false;
                    if (IsContatUs == false)
                        chkContact.Checked = false;

                    IsPublish = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsPublished"]);
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Publish_Date"].ToString()))
                    {
                        DateTime dtPublish = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Publish_Date"]);
                        if (DateTime.Compare(dtPublish, dtNow) < 0)
                            txtPublishDate.Text = dtNow.ToShortDateString();
                        else
                            txtPublishDate.Text = dtPublish.ToShortDateString();
                    }

                    if (txtPublishDate.Text != "")
                    {
                        rbPublish.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }

                    // Located Data
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(customXML);
                    if (xmldoc.SelectSingleNode("Bulletins/Details/@IsLocated") != null)
                    {
                        chkLocated.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("Bulletins/Details/@IsLocated").Value);
                    }
                    if (xmldoc.SelectSingleNode("Bulletins/Details/@LocatedText") != null)
                    {
                        txtLocated.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Details/@LocatedText").Value);
                    }
                    if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Bulletin_Category"].ToString()))
                        ddlCategories.SelectedValue = dtBulletinDetails.Rows[0]["Bulletin_Category"].ToString();
                    if (xmldoc.SelectSingleNode("Bulletins/Details/@ContentCall") != null)
                    {
                        txtContentPhone.Text = Convert.ToString(xmldoc.SelectSingleNode("Bulletins/Details/@ContentCall").Value);
                    }
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "GetBulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMEditBulletin.aspx.cs", "BtnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx"));

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMEditBulletin.aspx.cs", "BtnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();
                    //Getting Bulletin Details
                    GetBulletinDetails();
                    lblmess.Text = "Bulletin saved successfully.";
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "BtnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMEditBulletin.aspx.cs", "BtnPublish_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublish.Checked)
                    publishValue = "2";
                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();

                    //
                    string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx");
                    HttpContext.Current.Response.Redirect(urlinfo);
                }

                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "BtnPublish_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublishSave('" + publishValue + "');", true);
        }



        private void Save_Update_BulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMEditBulletin.aspx.cs", "Save_Update_BulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                string editHtmlText = hdnEditHTML.Value.ToString();
                string previewHtml = hdnPreviewHTML.Value.ToString();
                previewHtml = BuildWatermarkImage(previewHtml, txtLocated.Text.Trim(), chkLocated.Checked);
                string customXML = "";
                customXML = "<Bulletins><Details  IsLocated='" + chkLocated.Checked + "' LocatedText='" + txtLocated.Text.Trim() + "'  ContentCall='" + txtContentPhone.Text.Trim() + "'  /> </Bulletins>";


                string exDate = hdnExDate.Value.ToString();
                DateTime? datePublish;
                datePublish = null;

                string bulletinTitle = Convert.ToString(System.Web.HttpContext.Current.Session["BulletinName"]);
                int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);

                int profileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                IsCall = chkCall.Checked;
                IsContatUs = chkContact.Checked;
                int? id = null;
                IsPublish = Convert.ToBoolean(hdnPublish.Value);

                string ListDescription = Convert.ToString(hdnDescription.Value);

                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }

                DateTime? expiryDate;
                expiryDate = null;
                string printerHtml = "";


                if (txtExDate.Text != "")
                {
                    var exTime = ExpiryTimeControl1.SelectedTime;
                    expiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
                }

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    string returnvalue = string.Empty;
                    if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, previewHtml, editHtmlText, IsArchive,
                            chkCall.Checked, false, chkContact.Checked, expiryDate, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printerHtml, customXML, "");
                    }
                    else   // for author
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, previewHtml, editHtmlText, IsArchive,
                             chkCall.Checked, false, chkContact.Checked, expiryDate, false, datePublish, id, ddlCategories.SelectedValue, printerHtml, customXML, "");
                        if (IsPublish)
                            returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), CustomID, PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.MPERSON, DomainName);
                    }

                }
                else
                {
                    CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, previewHtml, editHtmlText, IsArchive,
                            chkCall.Checked, false, chkContact.Checked, expiryDate, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printerHtml, customXML, "");
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
                    if (rbUnPublish.Checked && hdnIsAlreadyPublished.Value == "1")
                        objCommon.UpdateSentFlag(CustomID, 2, 0, "ContentModule");
                }
                /****** Auto Share Completed ******/
                //Create Bulletin Image
                objInBuiltData.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\CustomModules\\", profileID, userID, CustomID, previewHtml);

                //Messages
                if (Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                else
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", bulletinTitle);
                }

                #region Save User Activity Log

                if (System.Web.HttpContext.Current.Session["BulletinSuccess"].ToString().Contains("created"))
                {
                    objCommon.InsertUserActivityLog("has created a bulletin titled <b>" + bulletinTitle + "</b>", string.Empty, userID, profileID, DateTime.Now, UserID);
                }
                else
                {
                    objCommon.InsertUserActivityLog("has updated a bulletin named <b>" + bulletinTitle + "</b>", string.Empty, userID, profileID, DateTime.Now, UserID);
                }

                #endregion

                System.Web.HttpContext.Current.Session["BulletinID"] = CustomID;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private bool ValidatePublishDate()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMEditBulletin.aspx.cs", "ValidatePublishDate", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                int ProfilID = ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfilID);
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
                        ExpDateTime = txtExDate.Text.Trim() + " " + ExpiryTimeControl1.SelectedTime; ;

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
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }

        [System.Web.Services.WebMethod]
        public static string ReplaceShortURltoHmlString(string htmlString, string locatedText, bool IsLocated)
        {
            CommonBLL objCommonBll = new CommonBLL();
            htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);

            htmlString = BuildWatermarkImage(htmlString, locatedText, IsLocated);
            return htmlString;
        }

        public static string BuildWatermarkImage(string htmlString, string locatedText, bool IsLocated)
        {
            try
            {
                if (IsLocated)
                {
                    using (var bitmap = new Aurigma.GraphicsMill.Bitmap(158, 161, Aurigma.GraphicsMill.PixelFormat.Format32bppArgb, Aurigma.GraphicsMill.RgbColor.Transparent))
                    using (var graphics = bitmap.GetAdvancedGraphics())
                    {
                        using (var m = new System.Drawing.Drawing2D.Matrix())
                        {
                            m.Rotate(-45);

                            Aurigma.GraphicsMill.AdvancedDrawing.Pen pen = new Aurigma.GraphicsMill.AdvancedDrawing.Pen(
                    Aurigma.GraphicsMill.RgbColor.White, 1);

                            var plainText = new Aurigma.GraphicsMill.AdvancedDrawing.PlainText(locatedText, graphics.CreateFont("Arial", "Bold", 26),
                                new Aurigma.GraphicsMill.AdvancedDrawing.SolidBrush(System.Drawing.Color.Red),
                                new System.Drawing.PointF(10, 125));
                            plainText.Transform = m;
                            plainText.Pen = pen;
                            plainText.Alignment = Aurigma.GraphicsMill.AdvancedDrawing.TextAlignment.Center;
                            graphics.DrawText(plainText);

                            string LocatedImageFolder = HttpContext.Current.Server.MapPath("~/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]));
                            if (!Directory.Exists(LocatedImageFolder))
                            {
                                Directory.CreateDirectory(LocatedImageFolder);
                            }

                            string locatedImgName = "located_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";

                            bitmap.Save(LocatedImageFolder + "\\" + locatedImgName);


                            string imgPath = HttpContext.Current.Session["RootPath"].ToString() + "/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]) + "/" + locatedImgName;
                            htmlString = htmlString.Replace("#LocatedImage#", imgPath);

                            htmlString = BuildLocatedImage_Dynamically(htmlString, locatedImgName);
                        }
                    }
                }//


                htmlString = htmlString.Replace("#LocatedImage#", "");
                //#LocatedImage#

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "BuildWatermarkImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }

            return htmlString;
        }

        public static string BuildLocatedImage_Dynamically(string htmlString, string imgname = "")
        {
            string newImgPath = "";
            string olgImgPath = "";

            try
            {
                string imagePath = "";
                string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in matchesImgSrc)
                {
                    imagePath = m.Groups[1].Value;
                    if (imagePath.ToLower().Contains(imgname))
                    {
                        imagePath = "";
                    }
                    else
                    {
                        if (!imagePath.ToLower().Contains("upload/logos"))
                            break;
                    }
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


                    string dateValue = DateTime.Now.ToString("yyyyMMddHHmmssffff");

                    string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                    FOlderPath = FOlderPath.Replace("upload", "");
                    olgImgPath = uspdUploadFolderPath + FOlderPath;
                    newImgPath = olgImgPath.Replace(filenameWithoutExt.ToLower(), filenameWithoutExt.ToLower() + "_" + dateValue);
                    try
                    {

                        if (File.Exists(newImgPath))
                        { File.Delete(newImgPath); }

                    }
                    catch
                    { }

                    if (!File.Exists(newImgPath))
                    {
                        string locatedImage = HttpContext.Current.Server.MapPath("~/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]));
                        locatedImage = locatedImage + "\\" + imgname;

                        //olgImgPath = @"C:\inetpub\wwwroot\staging.uspdhub.com\upload/logos/10151/10151_thumb.jpg?guid=6f2de607-0c1a-4829-8531-cacd49dd7939";
                        if (olgImgPath.Contains('?'))
                            olgImgPath = olgImgPath.Substring(0, olgImgPath.LastIndexOf('?'));


                        //Load background image
                        Aurigma.GraphicsMill.Bitmap bitmap =
                            new Aurigma.GraphicsMill.Bitmap(olgImgPath);
                        int orgImgWidth = bitmap.Width;
                        int orgImgHeight = bitmap.Height;
                        //Load small image (foreground image)
                        Aurigma.GraphicsMill.Bitmap smallBitmap =
                            new Aurigma.GraphicsMill.Bitmap(locatedImage);

                        int newImgWidth = smallBitmap.Width;
                        int newImgHeight = smallBitmap.Height;
                        int locatedX = (orgImgWidth - newImgWidth) / 2;
                        int locatedY = (orgImgHeight - newImgHeight) / 2;

                        //Draw foreground image on background with transparency
                        bitmap.Draw(smallBitmap, locatedX, locatedY,
                           smallBitmap.Width, smallBitmap.Height,
                            Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, Aurigma.GraphicsMill.Transforms.ResizeInterpolationMode.High);


                        if (newImgPath.Contains('?'))
                            newImgPath = newImgPath.Substring(0, newImgPath.LastIndexOf('?'));

                        bitmap.Save(newImgPath);

                        htmlString = htmlString.Replace(filenameWithoutExt, filenameWithoutExt + "_" + dateValue);
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMEditBulletin.aspx.cs", "BuildLocatedImage_Dynamically newImgPath:" + newImgPath
                    + " <> olgImgPath: " + olgImgPath, ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
            return htmlString;
        }
    }
}