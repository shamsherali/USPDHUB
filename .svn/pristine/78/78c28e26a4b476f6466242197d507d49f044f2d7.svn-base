using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFormsBLL;
using System.Data;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Configuration;

namespace UserForms
{
    public partial class SheriffCrimeHighlights : BaseWeb
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
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        DataTable dtOfficerTypes = new DataTable();

        public string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
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
                    if (Session["msgSave"] != null)
                    {
                        lblmess.Text = Convert.ToString(Session["msgSave"]);
                        Session["msgSave"] = "";
                    }


                    LoadDefaultData();

                    if (Request.QueryString["BulletinID"] != null)
                    {
                        Session["BulletinID"] = Request.QueryString["BulletinID"];
                    }

                    if (Convert.ToInt32(Session["BulletinID"]) == 0 || Session["BulletinID"] == null || Session["BulletinID"].ToString() == "")
                    {
                        //New Bulletin
                        lblBulletinName.Text = Convert.ToString(Session["BulletinName"]);
                        //txtbulletinName.Text = Convert.ToString(Session["BulletinName"]);

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

                    //Load System Time
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    lblPublish.Text = hdnPublishTitle.Value;
                    GetAutoShareRecordStatus();
                }
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, true);
                hdnBulletinHeader.Value = preview;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            int bulletinID = 0;
            if (Session["BulletinID"] != null && Convert.ToString(Session["BulletinID"]) != "")
                bulletinID = Convert.ToInt32(Session["BulletinID"]);
            if (bulletinID > 0)
            {
                DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("Bulletin", bulletinID, lblBulletinName.Text);
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
            #region Fill Bulletin Categories

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


            #endregion

            // Associates

            dtAssociates = objConsumer.GetActiveAssociates(Convert.ToInt32(UserID));

            ddlAssociates1.DataSource = ddlAssociates2.DataSource = ddlAssociates3.DataSource = ddlAssociates4.DataSource = ddlAssociates5.DataSource = ddlAssociates6.DataSource = ddlContactName.DataSource = dtAssociates;
            ddlAssociates1.DataTextField = ddlAssociates2.DataTextField = ddlAssociates3.DataTextField = ddlAssociates4.DataTextField = ddlAssociates5.DataTextField = ddlAssociates6.DataTextField = ddlContactName.DataTextField = "AssociateName";
            ddlAssociates1.DataValueField = ddlAssociates2.DataValueField = ddlAssociates3.DataValueField = ddlAssociates4.DataValueField = ddlAssociates5.DataValueField = ddlAssociates6.DataValueField = ddlContactName.DataValueField = "AssociateName";

            ddlAssociates1.DataBind();
            ddlAssociates2.DataBind();
            ddlAssociates3.DataBind();
            ddlAssociates4.DataBind();
            ddlAssociates5.DataBind();
            ddlAssociates6.DataBind();
            ddlContactName.DataBind();

            //Additional Logo
            string additionalLogoPath = RootPath + "/Upload/AdditionalLogos/" + ProfileID + "/" + ProfileID + ".jpg";

            string folderPath = Server.MapPath("/Upload/AdditionalLogos/" + ProfileID + "/" + ProfileID + ".jpg");
            if (File.Exists(folderPath))
            {
                lblAdditionalLogo.Text = "<img src='" + additionalLogoPath + "' border='0'  />";
            }
            else
            {
                lblAdditionalLogo.Text = "";
            }


            //lblHeaderAddress.Text = objCommon.GetBulletinFormHeader(UserID, ProfileID);
            lblLogoHeader.Text = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath);

            // Officer Types
            dtOfficerTypes = objBulletin.GetOfficerTypes(ProfileID, "Sheriff");

            ddlSubmitBy1.DataSource = ddlSubmitBy2.DataSource = ddlSubmitBy3.DataSource = ddlSubmitBy4.DataSource = ddlSubmitBy5.DataSource = ddlSubmitBy6.DataSource = ddlContactTitle.DataSource = dtOfficerTypes;
            ddlSubmitBy1.DataTextField = ddlSubmitBy2.DataTextField = ddlSubmitBy3.DataTextField = ddlSubmitBy4.DataTextField = ddlSubmitBy5.DataTextField = ddlSubmitBy6.DataTextField = ddlContactTitle.DataTextField = "OfficerTypeName";
            ddlSubmitBy1.DataValueField = ddlSubmitBy2.DataValueField = ddlSubmitBy3.DataValueField = ddlSubmitBy4.DataValueField = ddlSubmitBy5.DataValueField = ddlSubmitBy6.DataValueField = ddlContactTitle.DataValueField = "OfficerTypeName";

            ddlSubmitBy1.DataBind();
            ddlSubmitBy2.DataBind();
            ddlSubmitBy3.DataBind();
            ddlSubmitBy4.DataBind();
            ddlSubmitBy5.DataBind();
            ddlSubmitBy6.DataBind();
            ddlContactTitle.DataBind();

            ListItem objListItem = new ListItem { Text = "", Value = "" };
            ddlSubmitBy1.Items.Insert(0, objListItem);
            ddlSubmitBy2.Items.Insert(0, objListItem);
            ddlSubmitBy3.Items.Insert(0, objListItem);
            ddlSubmitBy4.Items.Insert(0, objListItem);
            ddlSubmitBy5.Items.Insert(0, objListItem);
            ddlSubmitBy6.Items.Insert(0, objListItem);

            ddlAssociates1.Items.Insert(0, objListItem);
            ddlAssociates2.Items.Insert(0, objListItem);
            ddlAssociates3.Items.Insert(0, objListItem);
            ddlAssociates4.Items.Insert(0, objListItem);
            ddlAssociates5.Items.Insert(0, objListItem);
            ddlAssociates6.Items.Insert(0, objListItem);

            objListItem = new ListItem { Text = "", Value = "0" };
            ddlContactTitle.Items.Insert(0, objListItem);

            objListItem = new ListItem { Text = "", Value = "0" };
            ddlContactName.Items.Insert(0, objListItem);


        }

        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);


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

                //Additional Logo
                string additionalLogoPath = RootPath + "/Upload/AdditionalLogos/" + ProfileID + "/" + ProfileID + ".jpg";

                string folderPath = Server.MapPath("/Upload/AdditionalLogos/" + ProfileID + "/" + ProfileID + ".jpg");
                if (File.Exists(folderPath))
                {
                    strHeader = strHeader.Replace("#AdditionalLogo#", "<img src='" + additionalLogoPath + "' border='0'  />");
                }
                else
                {
                    strHeader = strHeader.Replace("#AdditionalLogo#", "");
                }

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
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "BtnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                string urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/managebulletins.aspx");
                HttpContext.Current.Response.Redirect(urlinfo);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidatePublishDate())
            {
                //Save & Update Bulletins
                Save_Update_BulletinDetails();


                Session["msgSave"] = "Content has been saved successfully.";
                lblmess.Text = "";

                string urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/SheriffCrimeHighlights.aspx");
                Response.Redirect(urlinfo);
            }

            MPEProgress.Hide();
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "BtnPublish_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (ValidatePublishDate())
                {
                    Save_Update_BulletinDetails();
                    Session["msgSave"] = "";
                    string urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
                }
                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "BtnPublish_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private bool ValidatePublishDate()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "ValidatePublishDate", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                dtToday = objCommon.ConvertToUserTimeZone(ProfileID);

                if (Convert.ToDateTime(txtFromDate.Text) > Convert.ToDateTime(txtToDate.Text))
                {
                    lblerror.Text = "<font color='red'>" + "End Date should be later than or equal to Start Date." + "</font>";
                    // txt.Focus();
                    addflag = false;
                }

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
                        //txtExHours.Enabled = true;
                        //txtExMinutes.Enabled = true;
                        //ddlExSS.Enabled = true;
                        //if (!string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        //{
                        //    ExpDateTime = txtExDate.Text.Trim() + " " + txtExHours.Text + ":" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        //}
                        //else if (!string.IsNullOrEmpty(txtExHours.Text) && string.IsNullOrEmpty(txtExMinutes.Text))
                        //{
                        //    ExpDateTime = txtExDate.Text.Trim() + " " + txtExHours.Text + ":00:00" + " " + ddlExSS.SelectedValue.ToString();
                        //}
                        //else if (string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        //{
                        //    ExpDateTime = txtExDate.Text.Trim() + " 12:" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    ExpDateTime = txtExDate.Text.Trim() + " 12:00:00 AM";
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
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }

        private void GetBulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "GetBulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Edit Bulletin
                DataTable dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(Session["BulletinID"]));

                if (dtBulletinDetails.Rows.Count > 0)
                {
                    Session["BulletinName"] = dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString();

                    lblBulletinName.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_Title"]);

                    hdnEditHTML.Value = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]).Replace("undefined", "").Replace("id=\"trheader", "class=\"trheader\" id=\"trheader");
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

                        txtFromDate.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@FromDate").Value;
                        txtToDate.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ToDate").Value;

                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer1").Value.ToString()))
                        {
                            ddlSubmitBy1.ClearSelection();
                            ddlSubmitBy1.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer1").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer2").Value.ToString()))
                        {
                            ddlSubmitBy2.ClearSelection();
                            ddlSubmitBy2.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer2").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer3").Value.ToString()))
                        {
                            ddlSubmitBy3.ClearSelection();
                            ddlSubmitBy3.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer3").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer4").Value.ToString()))
                        {
                            ddlSubmitBy4.ClearSelection();
                            ddlSubmitBy4.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer4").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer5").Value.ToString()))
                        {
                            ddlSubmitBy5.ClearSelection();
                            ddlSubmitBy5.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer5").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer6").Value.ToString()))
                        {
                            ddlSubmitBy6.ClearSelection();
                            ddlSubmitBy6.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Officer6").Value;
                        }
                        // Associates
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates1").Value.ToString()))
                        {
                            ddlAssociates1.ClearSelection();
                            ddlAssociates1.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates1").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates2").Value.ToString()))
                        {
                            ddlAssociates2.ClearSelection();
                            ddlAssociates2.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates2").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates3").Value.ToString()))
                        {
                            ddlAssociates3.ClearSelection();
                            ddlAssociates3.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates3").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates4").Value.ToString()))
                        {
                            ddlAssociates4.ClearSelection();
                            ddlAssociates4.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates4").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates5").Value.ToString()))
                        {
                            ddlAssociates5.ClearSelection();
                            ddlAssociates5.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates5").Value;
                        }
                        if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates6").Value.ToString()))
                        {
                            ddlAssociates6.ClearSelection();
                            ddlAssociates6.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Associates6").Value;
                        }
                        //

                        // Contact Details
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ContactTitle") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ContactTitle").Value.ToString()))
                            {
                                ddlContactTitle.ClearSelection();
                                ddlContactTitle.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ContactTitle").Value.ToString();
                            }
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ContactTitle") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ContactName").Value.ToString()))
                            {
                                ddlContactName.ClearSelection();
                                ddlContactName.SelectedValue = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ContactName").Value.ToString();
                            }
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@EmailID") != null)
                        {
                            txtEmailID.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@EmailID").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@PhoneNumber") != null)
                        {
                            txtPhone.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@PhoneNumber").Value.ToString();
                        }


                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@TotalIncidents") != null)
                        {
                            txtTotalIncidents.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@TotalIncidents").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@OfficerInitiatedActivity") != null)
                        {
                            txtOfficerInitiatedActivity.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@OfficerInitiatedActivity").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@CallsforService") != null)
                        {
                            txtCallsforService.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@CallsforService").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ArrestsMisdemeanor") != null)
                        {
                            txtArrestsMisdemeanor.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ArrestsMisdemeanor").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ArrestsFelony") != null)
                        {
                            txtArrestsFelony.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@ArrestsFelony").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@CasesWritten") != null)
                        {
                            txtCasesWritten.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@CasesWritten").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@TrafficStops") != null)
                        {
                            txtTrafficStops.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@TrafficStops").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Citations") != null)
                        {
                            txtCitations.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Citations").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@DUIArrests") != null)
                        {
                            txtDUIArrests.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@DUIArrests").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Accidents") != null)
                        {
                            txtAccidents.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@Accidents").Value;
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@AccidentCriminal") != null)
                        {
                            txtAccidentCriminal.Text = xmldoc.SelectSingleNode("Bulletins/CrimeDetails/@AccidentCriminal").Value;
                        }


                    }

                    #endregion

                    string previewHtml = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);
                    hdnPreviewHTML.Value = previewHtml;

                    lbldummy.Text = previewHtml;

                    if (Convert.ToString(dtBulletinDetails.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExDate.Text = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]).ToShortDateString();
                        //txtExHours.Enabled = true;
                        //txtExMinutes.Enabled = true;
                        //ddlExSS.Enabled = true;

                        DateTime expiryTime = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]);
                        ExpiryTimeControl1.Enabled = true;
                        ExpiryTimeControl1.SelectedTime = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]).ToShortTimeString();
                    }
                    else
                    {
                        ExpiryTimeControl1.Enabled = false;
                        //txtExHours.Enabled = false;
                        //txtExMinutes.Enabled = false;
                        //ddlExSS.Enabled = false;
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
                    {
                        rbPublic.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "LoadData();", true);
                    //Create Bulletin Image
                    string bulletinImgPath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + Convert.ToString(Session["ProfileID"]) + "\\" + Convert.ToString(Session["BulletinID"]) + ".jpg";
                    if (!File.Exists(bulletinImgPath))
                    {
                        objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", Convert.ToInt32(Session["ProfileID"]),
                            UserID, Convert.ToInt32(Session["BulletinID"]), previewHtml);
                    }
                }


            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "GetBulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Save_Update_BulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "Save_Update_BulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

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
                bool isCall = false;
                bool isPhotoCapture = false;
                bool isContactUs = false;
                int? id = null;
                bool isPublish = false;

                if (hdnPrivate.Value.ToString().Trim() != string.Empty)
                {
                    isPublish = Convert.ToBoolean(hdnPrivate.Value.ToString().Trim());
                }

                string printHTML = "";
                string CategoryName = ddlCategories.SelectedValue;

                if (rbPublic.Checked)
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }

                DateTime? dateExpires;
                dateExpires = null;
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
                        txt.Focus();
                        //addflag = false;
                    }
                    else
                    {
                        dateExpires = Convert.ToDateTime(txtExDate.Text.Trim() + " " + ExpiryTimeControl1.SelectedTime);
                    }
                }
                
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish, CategoryName, false, id, printHTML, customXML);
                            if (isPrivate == true)
                                objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, PageNames.BULLETIN, userID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                        }
                    }
                             
              

                //Create Bulletin Image
                objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", profileID, userID, Convert.ToInt32(bulletinID), previewHtml);

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
                if (Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                else
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", bulletinTitle);
                }

                System.Web.HttpContext.Current.Session["BulletinID"] = bulletinID;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDashboard_OnClick(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SheriffCrimeHighlights.aspx.cs", "btnDashboard_OnClick", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublic.Checked)
                    publishValue = "2";
                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();

                    //
                    string urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/default.aspx");
                    HttpContext.Current.Response.Redirect(urlinfo);
                }

                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SheriffCrimeHighlights.aspx.cs", "btnDashboard_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Dashboard button", "ShowPublishSave('" + publishValue + "');", true);
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