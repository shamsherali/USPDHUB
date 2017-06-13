using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using USPDHUBBLL;
using System.Text;
using System.Data;
using USPDHUBDAL;

namespace USPDHUB.Admin
{
    public partial class AdditionalBrandedRequests : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public string DomainName = "";
        public int BrandedApp_OrderId;
        public int BrandedApp_RequestID = 0;
        AdminBLL objAdminBLL = new AdminBLL();
        BusinessBLL objBusinessBLL = new BusinessBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        DataTable dtBrandedAppDetails = new DataTable();
        DataTable dtBrandedAppRequest = new DataTable();
        public DataTable dtConfigs = new DataTable("configsettings");

        public string folderPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath");
        string divAction = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                DomainName = Session["VerticalDomain"].ToString();

                if (Session["BrandedApp_OrderId"] == null)
                    Response.Redirect("ManageBrandedAppProcessStatus.aspx");

                BrandedApp_OrderId = Convert.ToInt32(Session["BrandedApp_OrderId"].ToString());
                dtBrandedAppDetails = objBusinessBLL.GetBrandedAppOrderStatusDetails(BrandedApp_OrderId);

                if (dtBrandedAppDetails.Rows.Count > 0)
                {
                    UserID = Convert.ToInt32(dtBrandedAppDetails.Rows[0]["UserID"].ToString());
                    ProfileID = Convert.ToInt32(dtBrandedAppDetails.Rows[0]["ProfileID"].ToString());
                    hdnProfileId.Value = ProfileID.ToString();
                }


                if (Request.QueryString["BRID"] != null)
                {
                    BrandedApp_RequestID = Convert.ToInt32(Request.QueryString["BRID"].ToString());
                }

                if (!IsPostBack)
                {

                    FillStatus();
                    if (Request.QueryString["BRID"] != null)
                    {

                        hdnIsEdit.Value = "1";

                        dtBrandedAppRequest = objAdminBLL.GetBrandedAppRequestByRequestID(BrandedApp_RequestID);
                        if (dtBrandedAppRequest.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["App_DisplayName"].ToString()))
                            {
                                txtAppName.Text = dtBrandedAppRequest.Rows[0]["App_DisplayName"].ToString();
                                txtAppNameNotes.Text = dtBrandedAppRequest.Rows[0]["AppNameNotes"].ToString();

                                divAction = divAction + ",divAppName";

                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divAppName')</script>", false);
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "<script type=text/javascript>$(window).load(function() { document.getElementById('divAppName').style.display='block';});</script>", true);
                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["SplashContent"].ToString()))
                            {
                                txtSplashContent.Text = dtBrandedAppRequest.Rows[0]["SplashContent"].ToString();
                                txtSplashNotes.Text = dtBrandedAppRequest.Rows[0]["SplashNotes"].ToString();
                                // divSlpashContent.Style.Add("display", "block");
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divSlpashContent')</script>", false);
                                divAction = divAction + ",divSlpashContent";
                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["App_ShortDescription"].ToString()))
                            {
                                txtShortDesc.Text = dtBrandedAppRequest.Rows[0]["App_ShortDescription"].ToString();
                                txtShortDescNotes.Text = dtBrandedAppRequest.Rows[0]["ShortDescNotes"].ToString();

                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divShortDesc')</script>", false);

                                divAction = divAction + ",divShortDesc";
                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["App_Description"].ToString()))
                            {
                                txtDescription.Text = dtBrandedAppRequest.Rows[0]["App_Description"].ToString();
                                txtDescNotes.Text = dtBrandedAppRequest.Rows[0]["DescNotes"].ToString();

                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divDesc')</script>", false);

                                divAction = divAction + ",divDesc";
                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["App_Keywords"].ToString()))
                            {
                                txtKeywords.Text = dtBrandedAppRequest.Rows[0]["App_Keywords"].ToString();
                                txtKeywordNotes.Text = dtBrandedAppRequest.Rows[0]["KeywordsNotes"].ToString();

                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divKeyWords')</script>", false);
                                divAction = divAction + ",divKeyWords";
                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["AppUpdate_Notes"].ToString()))
                            {
                                txtAppUpdate.Text = dtBrandedAppRequest.Rows[0]["AppUpdate_Notes"].ToString();
                                txtAppUpdateNotes.Text = dtBrandedAppRequest.Rows[0]["AppUpdate_PreviousNotes"].ToString();
                                divAction = divAction + ",divAppUpdate";
                            }
                            ddlStatus.SelectedValue = dtBrandedAppRequest.Rows[0]["StatusID"].ToString();

                            string rootPath = objCommonBLL.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["Logo"].ToString()))
                            {
                                ViewState["Logo"] = dtBrandedAppRequest.Rows[0]["Logo"];
                                if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + hdnProfileId.Value + "\\" + ViewState["Logo"]))
                                {
                                    string LogoPath = rootPath + "/Upload/BrandedAppRequestLogos/" + hdnProfileId.Value + "/" + ViewState["Logo"];
                                    lblLogo.Text = "<img src='" + LogoPath + "' width='100px' height='100px' />";
                                }

                                divAction = divAction + ",divLogo";
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divLogo')</script>", false);

                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["App_Icon"].ToString()))
                            {
                                ViewState["AppIcon"] = dtBrandedAppRequest.Rows[0]["App_Icon"];
                                if (Convert.ToString(ViewState["AppIcon"]) != string.Empty)
                                {
                                    string imgFullPath = folderPath + "\\AdditionalBrandedAppRequestIcons\\" + hdnProfileId.Value + "\\" + ViewState["AppIcon"];

                                    if (File.Exists(imgFullPath))
                                    {
                                        string AppIconPath = rootPath + "/Upload/AdditionalBrandedAppRequestIcons/" + hdnProfileId.Value + "/" + ViewState["AppIcon"];
                                        lblAppIcon.Text = "<img src='" + AppIconPath + "' width='100px' height='100px' />";

                                        btnDownloadAppIcon.CommandArgument = imgFullPath;
                                    }
                                }
                                if (lblAppIcon.Text.Trim() == string.Empty)
                                {
                                    btnDownloadAppIcon.Visible = false;
                                }

                                divAction = divAction + ",divAppIcon";
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divAppIcon')</script>", false);

                            }
                            if (!string.IsNullOrEmpty(dtBrandedAppRequest.Rows[0]["Background_Icon"].ToString()))
                            {
                                ViewState["BackIcon"] = dtBrandedAppRequest.Rows[0]["Background_Icon"];
                                if (Convert.ToString(ViewState["BackIcon"]) != string.Empty)
                                {
                                    string imgFullPath = folderPath + "\\AdditionalBrandedAppRequestIcons\\" + hdnProfileId.Value + "\\" + ViewState["BackIcon"];
                                    if (File.Exists(imgFullPath))
                                    {
                                        string AppBackPath = rootPath + "/Upload/AdditionalBrandedAppRequestIcons/" + hdnProfileId.Value + "/" + ViewState["BackIcon"];
                                        lblBackground.Text = "<img src='" + AppBackPath + "' width='100px' height='100px' />";

                                        btnDownloadBackground.CommandArgument = imgFullPath;
                                    }
                                }
                                if (lblBackground.Text.Trim() == string.Empty)
                                {
                                    btnDownloadBackground.Visible = false;
                                }

                                divAction = divAction + ",divBackIcon";
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divBackIcon')</script>", false);
                            }

                            if (divAction.StartsWith(","))
                            {
                                divAction = divAction.Substring(1);
                            }
                            if (divAction.EndsWith(","))
                            {
                                divAction = divAction.Remove(divAction.Length - 1);
                            }
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('" + divAction + "')</script>", false);

                        }// END IF
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FillStatus()
        {
            try
            {

                DataTable dtStatus = objBusinessBLL.GetAppOrderStatusByBrandedAppRequestID(BrandedApp_RequestID);
                ddlStatus.DataSource = dtStatus;
                ddlStatus.DataTextField = "Status_Name";
                ddlStatus.DataValueField = "Status_ID";
                ddlStatus.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "FillStatus", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/ManageBrandedAppProcessStatus.aspx");
            Response.Redirect(urlinfo);
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedItem.Text == "New")
                {
                    int validCount = 0;
                    int attemptsCount = 0;
                    if (fileLogo.HasFile == true)
                    {
                        attemptsCount += 1;
                        #region Logo Uploading
                        var Extension = Path.GetExtension(fileLogo.FileName);
                        if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                            || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                        {

                            string LogoPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + hdnProfileId.Value;

                            if (!Directory.Exists(LogoPath))
                            {
                                Directory.CreateDirectory(LogoPath);
                            }
                            var LogoFileName = fileLogo.FileName;
                            LogoFileName = LogoFileName.Replace(" ", "");

                            // Delete Previous Logo
                            if (File.Exists(LogoPath + "\\" + ViewState["Logo"]))
                            {
                                File.Delete(LogoPath + "\\" + ViewState["Logo"]);
                            }

                            LogoPath = LogoPath + "\\" + LogoFileName;
                            fileLogo.SaveAs(LogoPath);
                            ViewState["Logo"] = LogoFileName;
                            validCount += 1;
                        }
                        else
                        {
                            lblMsg.Text = "<font color='red'>Your logo is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                            return;
                        }
                        #endregion
                    }
                    if (FileAppIcon.HasFile == true)
                    {
                        attemptsCount += 1;
                        System.Drawing.Image myImage = System.Drawing.Image.FromStream(FileAppIcon.PostedFile.InputStream);
                        if ((myImage.Height > 1024) || (myImage.Width > 1024))
                        {
                            lblMsg.Text = "<font color='red'>Your app icon size less than or equal to 1024px X 1024px.</font>";
                            return;
                        }
                        else
                        {
                            #region App Icon Uploading
                            if (FileAppIcon.HasFile == true)
                            {
                                var Extension = Path.GetExtension(FileAppIcon.FileName);
                                if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                                    || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                                {
                                    string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\AdditionalBrandedAppRequestIcons\\" + hdnProfileId.Value;

                                    if (!Directory.Exists(IconPath))
                                    {
                                        Directory.CreateDirectory(IconPath);
                                    }
                                    var IconFileName = FileAppIcon.FileName;
                                    IconFileName = IconFileName.Replace(" ", "");


                                    ViewState["AppIcon"] = IconFileName;
                                    // Delete Previous Logo
                                    if (File.Exists(IconPath + "\\" + ViewState["AppIcon"]))
                                    {
                                        File.Delete(IconPath + "\\" + ViewState["AppIcon"]);
                                    }
                                    IconPath = IconPath + "\\" + IconFileName;
                                    FileAppIcon.SaveAs(IconPath);

                                    validCount += 1;
                                }
                                else
                                {
                                    lblMsg.Text = "<font color='red'>Your app icon is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                                    return;
                                }
                            }
                            #endregion
                        }
                    }
                    if (FileBackground.HasFile == true)
                    {
                        attemptsCount += 1;
                        System.Drawing.Image myImage = System.Drawing.Image.FromStream(FileBackground.PostedFile.InputStream);
                        if ((myImage.Height > 165) || (myImage.Width > 640))
                        {
                            lblMsg.Text = "<font color='red'>Your background icon size less than or equal to 640px X 165px.</font>";
                            return;
                        }
                        else
                        {
                            #region Background Icon Uploading
                            if (FileBackground.HasFile == true)
                            {
                                var Extension = Path.GetExtension(FileBackground.FileName);
                                if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                                    || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                                {
                                    string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\AdditionalBrandedAppRequestIcons\\" + hdnProfileId.Value;

                                    if (!Directory.Exists(IconPath))
                                    {
                                        Directory.CreateDirectory(IconPath);
                                    }
                                    var IconFileName = FileBackground.FileName;
                                    IconFileName = IconFileName.Replace(" ", "");

                                    ViewState["BackIcon"] = IconFileName;
                                    // Delete Previous Logo
                                    if (File.Exists(IconPath + "\\" + ViewState["BackIcon"]))
                                    {
                                        File.Delete(IconPath + "\\" + ViewState["BackIcon"]);
                                    }
                                    IconPath = IconPath + "\\" + IconFileName;
                                    FileBackground.SaveAs(IconPath);

                                    validCount += 1;
                                }
                                else
                                {
                                    lblMsg.Text = "<font color='red'>Your app icon is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                                    return;
                                }
                            }
                            #endregion
                        }
                    }
                    if (txtAppName.Text.Trim().Length > 0)
                    {
                        attemptsCount += 1;
                        validCount += 1;
                        divAction = divAction + ",divAppName";
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divAppName')</script>", false);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBlock", "ShowAddRequestBlock(divAppName)", true);
                    }
                    if (txtSplashContent.Text.Trim().Length > 0)
                    {
                        attemptsCount += 1;
                        validCount += 1;
                        divAction = divAction + ",divSlpashContent";
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBlock", "ShowAddRequestBlock(divSlpashContent)", true);
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divSlpashContent')</script>", false);
                        //enable this control realted div
                    }
                    if (txtShortDesc.Text.Trim().Length > 0)
                    {
                        attemptsCount += 1;
                        validCount += 1;
                        divAction = divAction + ",divShortDesc";
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBlock", "ShowAddRequestBlock(divShortDesc)", true);
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divShortDesc')</script>", false);
                    }
                    if (txtDescription.Text.Trim().Length > 0)
                    {
                        attemptsCount += 1;
                        validCount += 1;
                        divAction = divAction + ",divDesc";
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBlock", "ShowAddRequestBlock(divDesc)", true);
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divDesc')</script>", false);
                    }
                    if (txtKeywords.Text.Trim().Length > 0)
                    {
                        attemptsCount += 1;
                        validCount += 1;
                        divAction = divAction + ",divKeyWords";
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBlock", "ShowAddRequestBlock(divKeyWords)", true);
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('divKeyWords')</script>", false);

                    }
                    if (txtAppUpdate.Text.Trim().Length > 0)
                    {
                        attemptsCount += 1;
                        validCount += 1;
                        divAction = divAction + ",divAppUpdate";
                    }

                    if (attemptsCount > 0 && attemptsCount == validCount)
                    {
                        objBusinessBLL.InsertUpdateBrandedAppRequest(BrandedApp_RequestID, BrandedApp_OrderId, UserID, ProfileID,
                            Convert.ToString(ViewState["Logo"]), Convert.ToString(ViewState["AppIcon"]),
                            txtDescription.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                            txtSplashContent.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                            txtShortDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"), txtAppName.Text.Trim(), txtKeywords.Text.Trim(),txtAppUpdate.Text.Trim(),
                            Convert.ToInt32(ddlStatus.SelectedValue), null, ddlActions.SelectedValue.ToString(),
                            "", txtAppNameNotes.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                            txtSplashNotes.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"), txtShortDescNotes.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                            txtDescNotes.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"), txtKeywordNotes.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                             txtAppUpdateNotes.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                            "", "", Convert.ToString(ViewState["BackIcon"]));
                        // *** send email to dovelopers *** //
                        SendEmailDeveloper(ProfileID, DomainName);

                        RedirectPage();
                    }

                    if (divAction.StartsWith(","))
                    {
                        divAction = divAction.Substring(1);
                    }
                    if (divAction.EndsWith(","))
                    {
                        divAction = divAction.Remove(divAction.Length - 1);
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ShowAddRequestBlock11('" + divAction + "')</script>", false);
                }
                else if (ddlStatus.SelectedItem.Text == "Completed")
                {
                    // Just Updated Status COlumn Only by Branded App OrderID here
                    objBusinessBLL.usp_Insert_Update_BrandedAppAdditionalStatus(Convert.ToInt32(Session["BrandedApp_OrderId"]), Convert.ToInt32(ddlStatus.SelectedValue), BrandedApp_RequestID);


                    // *** Send Email to customer service person *** //
                    SendEmailToCustomerService(ProfileID, DomainName);


                    objBusinessBLL.Insert_Update_CheckedAppProcessStatus(chkReplaceAppNameData.Checked, chkReplaceSlashData.Checked, chkReplaceShortDescData.Checked, chkReplaceDescData.Checked, chkReplaceKeyWordsData.Checked, chkLogo.Checked, chkAppIcon.Checked, chkBackIcon.Checked, chkReplaceAppUpdate.Checked, txtAppName.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                         txtKeywords.Text.Trim(), txtDescription.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                        txtSplashContent.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"), txtShortDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"), txtAppUpdate.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                        Convert.ToString(ViewState["Logo"]), Convert.ToString(ViewState["AppIcon"]), Convert.ToString(ViewState["BackIcon"]),
                        Convert.ToInt32(Session["BrandedApp_OrderId"]));


                    if (chkAppIcon.Checked)
                    {
                        string appIconPath_original = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\AdditionalBrandedAppRequestIcons\\" + ProfileID + "\\" + Convert.ToString(ViewState["AppIcon"]);

                        var IconFileName = Convert.ToString(ViewState["AppIcon"]);
                        IconFileName = IconFileName.Replace(" ", "");


                        string appIconPath_copy = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ProfileID + "\\" + Convert.ToString(ViewState["AppIcon"]);

                        if (!Directory.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ProfileID))
                            Directory.CreateDirectory(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ProfileID);


                        FileInfo fisave = new FileInfo(appIconPath_original);
                        fisave.CopyTo(appIconPath_copy, true);

                    }

                    if (chkBackIcon.Checked)
                    {
                        string appIconPath_original = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\AdditionalBrandedAppRequestIcons\\" + ProfileID + "\\" + Convert.ToString(ViewState["BackIcon"]);

                        var bgIconFileName = Convert.ToString(ViewState["BackIcon"]);
                        bgIconFileName = bgIconFileName.Replace(" ", "");


                        string BGappIconPath_copy = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ProfileID + "\\" + Convert.ToString(ViewState["BackIcon"]);

                        if (!Directory.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ProfileID))
                            Directory.CreateDirectory(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ProfileID);

                        FileInfo fisave = new FileInfo(appIconPath_original);
                        fisave.CopyTo(BGappIconPath_copy, true);

                    }


                    RedirectPage();

                }
                else
                {
                    // Just Updated Status COlumn Only by Branded App OrderID here
                    objBusinessBLL.usp_Insert_Update_BrandedAppAdditionalStatus(Convert.ToInt32(Session["BrandedApp_OrderId"]), Convert.ToInt32(ddlStatus.SelectedValue), BrandedApp_RequestID);

                    RedirectPage();

                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "lnkSave_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void RedirectPage()
        {
            try
            {
                if (BrandedApp_RequestID > 0)
                    Session["Msg"] = "<span style='color:green;'>App additional request status has been updated successfully.</span>";
                else
                    Session["Msg"] = "<span style='color:green;'>App additional request has been created successfully.</span>";

                //Session["TabType"]
                string urlinfo = Page.ResolveClientUrl("~/Admin/ManageBrandedAppProcessStatus.aspx");
                Response.Redirect(urlinfo);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "RedirectPage", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendEmailDeveloper(int ProfileID, string DomainName)
        {
            try
            {
                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(hdnProfileId.Value));
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                string RootPath = ConfigurationManager.AppSettings["RootPath"];

                #region Mail Body
                StreamReader re = File.OpenText(strfilepath + "BrandedAppOrderStatus.txt");
                string emailmessage = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    emailmessage = emailmessage + content + "<BR>";
                }

                re.Close();
                re.Dispose();

                emailmessage = emailmessage.Replace("##ProfileName##", dtProfileDetails.Rows[0]["Profile_name"].ToString());
                emailmessage = emailmessage.Replace("##UserID##", dtProfileDetails.Rows[0]["User_ID"].ToString());


                #endregion

                #region Mail Header

                StreamReader re1 = File.OpenText(strfilepath + "CommonNotes.txt");
                string emailmessage1 = string.Empty;
                string content1 = string.Empty;

                while ((content1 = re1.ReadLine()) != null)
                {
                    emailmessage1 = emailmessage1 + content1;
                }
                emailmessage1 = emailmessage1.Replace("#msgBody#", emailmessage);



                #endregion

                DataTable dtConfigs = objCommonBLL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                string FromEmailsupport = "";
                re1 = File.OpenText(strfilepath + "BrandedAppDeveloperIDs.txt");
                string ToEMailID = string.Empty;
                while ((content1 = re1.ReadLine()) != null)
                {
                    ToEMailID = ToEMailID + content1;
                }
                re1.Close();
                re1.Dispose();
                // string Subject = "Branded App Order Status";

                string Subject = "Branded App Additional Request Status - Development";

                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "EmailInfo")
                    {
                        FromEmailsupport = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                        break;
                    }
                }
                objCommonBLL.SendWowzzyEmail(FromEmailsupport, ToEMailID, Subject, emailmessage1, string.Empty, "", DomainName, ProfileID.ToString(), "");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "SendEmailDeveloper", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendEmailToCustomerService(int ProfileID, string DomainName)
        {
            try
            {
                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(hdnProfileId.Value));
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                string RootPath = ConfigurationManager.AppSettings["RootPath"];

                #region Mail Body
                StreamReader re = File.OpenText(strfilepath + "BrandedAppAdditionalRequestCompleted.txt");
                string emailmessage = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    emailmessage = emailmessage + content + "<BR>";
                }

                re.Close();
                re.Dispose();

                emailmessage = emailmessage.Replace("##ProfileName##", dtProfileDetails.Rows[0]["Profile_name"].ToString());
                emailmessage = emailmessage.Replace("##UserID##", dtProfileDetails.Rows[0]["User_ID"].ToString());


                #endregion

                #region Mail Header

                StreamReader re1 = File.OpenText(strfilepath + "CommonNotes.txt");
                string emailmessage1 = string.Empty;
                string content1 = string.Empty;

                while ((content1 = re1.ReadLine()) != null)
                {
                    emailmessage1 = emailmessage1 + content1;
                }
                emailmessage1 = emailmessage1.Replace("#msgBody#", emailmessage);



                #endregion

                DataTable dtConfigs = objCommonBLL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                string FromEmailsupport = "";
                re1 = File.OpenText(strfilepath + "BrandedAppAdditionalRequestCompleted_DevIDs.txt");
                string ToEMailID = string.Empty;
                while ((content1 = re1.ReadLine()) != null)
                {
                    ToEMailID = ToEMailID + content1;
                }
                re1.Close();
                re1.Dispose();
                string Subject = "Branded App Additional Request Status - Completed";

                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "EmailInfo")
                    {
                        FromEmailsupport = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                        break;
                    }
                }
                objCommonBLL.SendWowzzyEmail(FromEmailsupport, ToEMailID, Subject, emailmessage1, string.Empty, "", DomainName, ProfileID.ToString(), "");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "SendEmailToCustomerService", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDownloadAppIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                string imgDownloaPath = btnDownloadAppIcon.CommandArgument;
                string imgName = Path.GetFileName(imgDownloaPath);

                Response.ContentType = "image/jpg";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + imgName + "\"");
                Response.TransmitFile(imgDownloaPath);
                Response.End();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "btnDownloadAppIcon_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDownloadBackground_OnClick(object sender, EventArgs e)
        {
            try
            {
                string imgDownloaPath = btnDownloadBackground.CommandArgument;
                string imgName = Path.GetFileName(imgDownloaPath);

                Response.ContentType = "image/jpg";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + imgName + "\"");
                Response.TransmitFile(imgDownloaPath);
                Response.End();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalBrandedRequests.aspx.cs", "btnDownloadBackground_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


    }
}