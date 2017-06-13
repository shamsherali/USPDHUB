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

namespace USPDHUB.Business.MyAccount
{
    public partial class CMSheriffCrimeHighlights : BaseWeb
    {
        USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
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

        static BulletinBLL objBulletin = new BulletinBLL();
        Consumer objConsumer = new Consumer();
        DataTable dtAssociates = new DataTable();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        DataTable dtOfficerTypes = new DataTable();
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMCMSheriffCrimeHighlights.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();

                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["CustomModuleID"] != null && Session["FormID"] != null)
                {
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
                    ModuleID = Convert.ToInt32(Session["FormID"].ToString());
                }
                else
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");

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
                    if (Session["msgSave"] != null)
                    {
                        lblmess.Text = Convert.ToString(Session["msgSave"]);
                        Session["msgSave"] = "";
                    }
                    LoadDefaultData();
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CustomModuleId, "ContentModule");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            //UpdatePanel3.Visible = true;
                            UpdatePanel2.Visible = UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit app content.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here


                    #region Checking Global mobile app settings

                    // *** Checking Global mobile app settings *** //
                    DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                        var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                        IsCall = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                        IsContatUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                        if (IsCall) { }
                        //divCall.Visible = true;
                        else
                        {
                            //divCall.Visible = false;
                            //chkCall.Checked = false;
                        }
                        if (IsContatUs) { }
                        //divContactUs.Visible = true;
                        else
                        {
                            //divContactUs.Visible = false;
                            //chkContact.Checked = false;
                        }
                    }
                    else
                    {
                        //divCall.Visible = false;
                        //chkCall.Checked = false;
                        //divContactUs.Visible = false;
                        //chkContact.Checked = false;
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
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, true);
                hdnBulletinHeader.Value = preview;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMCMCMSheriffCrimeHighlights.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
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
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMCMCMSheriffCrimeHighlights.aspx.cs", "GetAutoShareRecordStatus", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {

            try
            {
                #region Fill Bulletin Categories
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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMCMCMSheriffCrimeHighlights.aspx.cs", "LoadDefaultData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private bool ValidatePublishDate()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSheriffCrimeHighlights.aspx.cs", "ValidatePublishDate", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);

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
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                        if (!string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " " + txtExHours.Text + ":" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (!string.IsNullOrEmpty(txtExHours.Text) && string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " " + txtExHours.Text + ":00:00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " 12:" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " 12:00:00 AM";
                        }
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
                objInBuiltData.ErrorHandling("ERROR", "CMSheriffCrimeHighlights.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }

        private void GetBulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrimeHighlights.aspx.cs", "GetBulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Edit Bulletin
                DataTable dtBulletinDetails = objAddOn.GetCustomModuleByID(CustomID);

                if (dtBulletinDetails.Rows.Count > 0)
                {
                    Session["BulletinName"] = BulletinName = dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString();

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
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;

                        DateTime expiryTime = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]);

                        if (expiryTime.ToString().Contains("PM"))
                        {
                            if (expiryTime.Hour > 12)
                            {
                                txtExHours.Text = (expiryTime.Hour - 12).ToString();
                            }
                            else
                            {
                                txtExHours.Text = (expiryTime.Hour).ToString();
                            }
                            ddlExSS.SelectedValue = "PM";
                        }
                        else
                        {
                            if (expiryTime.Hour == 0)
                            {
                                txtExHours.Text = "12";
                            }
                            else
                            {
                                txtExHours.Text = (expiryTime.Hour).ToString();
                            }
                            ddlExSS.SelectedValue = "AM";
                        }
                        txtExMinutes.Text = expiryTime.Minute.ToString();

                    }
                    else
                    {
                        txtExHours.Enabled = false;
                        txtExMinutes.Enabled = false;
                        ddlExSS.Enabled = false;
                    }

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


                    if (Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsPublished"]) == true)
                    {
                        rbPublish.Checked = true;
                        rbUnPublish.Checked = false;
                        hdnIsAlreadyPublished.Value = "1";
                    }
                    else
                    { rbUnPublish.Checked = true; rbPublish.Checked = false; }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "LoadData();", true);
                    //Create Bulletin Image
                    string bulletinImgPath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\CustomModules\\" + Convert.ToString(Session["ProfileID"]) + "\\" + Convert.ToString(Session["BulletinID"]) + ".jpg";
                    if (!File.Exists(bulletinImgPath))
                    {
                        objInBuiltData.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\CustomModules\\", Convert.ToInt32(Session["ProfileID"]),
                            UserID, Convert.ToInt32(Session["BulletinID"]), previewHtml);
                    }

                }


            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CrimeHighlights.aspx.cs", "GetBulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDashboard_OnClick(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSheriffCrimeHighlights.aspx.cs", "btnDashboard_OnClick", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublish.Checked)
                    publishValue = "2";
                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();

                    //
                    string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/default.aspx");
                    HttpContext.Current.Response.Redirect(urlinfo);
                }

                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSheriffCrimeHighlights.aspx.cs", "btnDashboard_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Dashboard button", "ShowPublishSave('" + publishValue + "');", true);
        }

        private void Save_Update_BulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CrimeHighlights.aspx.cs", "Save_Update_BulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                string editHtmlText = hdnEditHTML.Value.ToString().Replace("class=\"trheader\" id=\"trheader", "id=\"trheader");
                string previewHtml = hdnPreviewHTML.Value.ToString();
                string exDate = hdnExDate.Value.ToString();
                string customXML = hdnEditXML.Value;

                DateTime? datePublish;
                datePublish = null;
                if (rbPublish.Checked)
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }
                IsPublish = Convert.ToBoolean(hdnPublish.Value);

                string ListDescription = Convert.ToString(hdnDescription.Value);
                string CategoryName = ddlCategories.SelectedValue;
                int? id = null;
                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";
                string printerHtml = "";

                DateTime? expiryDate;
                expiryDate = null;

                if (txtExDate.Text != "")
                {
                    expiryDate = Convert.ToDateTime(txtExDate.Text.Trim());
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
                        expiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
                    }
                    else
                    {
                        exHour = "12";
                        exMin = "00";
                        exSS = "AM";

                        exTime = exHour + ":" + exMin + ":00 " + exSS;
                        expiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
                    }
                }


                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    string returnvalue = string.Empty;
                    if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, previewHtml, editHtmlText, IsArchive,
                            false, false, false, expiryDate, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printerHtml, customXML);
                    }
                    else   // for author
                    {
                        CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, previewHtml, editHtmlText, IsArchive,
                             false, false, false, expiryDate, false, datePublish, id, ddlCategories.SelectedValue, printerHtml, customXML);
                        if (IsPublish)
                            returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), CustomID, PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.MPERSON, DomainName);
                    }

                }
                else
                {
                    CustomID = objAddOn.AddUpdateItem(ProfileID, UserID, C_UserID, CustomID, CustomModuleId, ModuleID, BulletinName, previewHtml, editHtmlText, IsArchive,
                            false, false, false, expiryDate, IsPublish, datePublish, IsPublish == false ? id : C_UserID, ddlCategories.SelectedValue, printerHtml, customXML);
                }

                //Create Bulletin Image
                objInBuiltData.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\CustomModules\\", ProfileID, UserID, CustomID, previewHtml);


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

                //Messages
                if (Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                }
                else
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                }

                System.Web.HttpContext.Current.Session["BulletinID"] = CustomID;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSheriffCrimeHighlights.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSheriffCrimeHighlights.aspx.cs", "BtnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();
                    ////Getting Bulletin Details
                    //GetBulletinDetails();
                    //lblmess.Text = "Content saved successfully.";

                    Session["msgSave"] = "Content has been saved successfully.";
                    lblmess.Text = "";

                    string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/CMSheriffCrimeHighlights.aspx");
                    Response.Redirect(urlinfo);
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSheriffCrimeHighlights.aspx.cs", "BtnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSheriffCrimeHighlights.aspx.cs", "BtnPublish_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublish.Checked)
                    publishValue = "2";
                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();

                    Session["msgSave"] = "";
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
                objInBuiltData.ErrorHandling("ERROR", "CMSheriffCrimeHighlights.aspx.cs", "BtnPublish_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublishSave('" + publishValue + "');", true);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CMSheriffCrimeHighlights.aspx.cs", "BtnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx");
                HttpContext.Current.Response.Redirect(urlinfo);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CMSheriffCrimeHighlights.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [System.Web.Services.WebMethod]
        public static string ReplaceShortURltoHmlString(string htmlString)
        {
            try
            {
                CommonBLL objCommonBll = new CommonBLL();
                htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);
            }
            catch (Exception ex)
            {
                //Error 
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CMCMCMSheriffCrimeHighlights.aspx.cs", "ReplaceShortURltoHmlString", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return htmlString;
        }
    }
}