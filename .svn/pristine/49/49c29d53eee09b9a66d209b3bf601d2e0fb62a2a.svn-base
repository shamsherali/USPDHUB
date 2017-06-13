using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFormsBLL;
using System.Data;
using System.IO;
using System.Configuration;
using System.Xml;


namespace UserForms
{
    public partial class OfficeClosure : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        static BulletinBLL objBulletin = new BulletinBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBus = new BusinessBLL();

        CommonBLL objCommon = new CommonBLL();
        public DataTable Dtpermissions = new DataTable();

        public string PermissionType = string.Empty;
        public int PermissionValue = 0;
        public int CUserID = 0;
        DateTime dtToday;
        public string RootPath = "";
        public string DomainName = "";
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "OfficeClosure.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                hdnRootPath.Value = RootPath;

                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);


                int saveProcessID = 0;
                /*** Store Module Functionality ***/
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduleEmails = true;
                }


                if (!IsPostBack)
                {
                    if (Request.QueryString["BID"] != null)
                    {
                        Session["BulletinID"] = Request.QueryString["BID"];
                        hdnBulletinID.Value = Request.QueryString["BID"].ToString();
                    }

                    if (Convert.ToInt32(Session["BulletinID"]) == 0 || Session["BulletinID"] == null || Session["BulletinID"].ToString() == "")
                    {
                        //New Bulletin
                        lblBulletinName.Text = Convert.ToString(Session["BulletinName"]);
                        DataTable dtBulletin = objBulletin.CheckBulletin(UserID, string.Empty, Convert.ToInt32(Session["TemplateBID"]), string.Empty);
                        Session["TemplateName"] = Convert.ToString(dtBulletin.Rows[0]["Template_Name"]);
                    }
                    else
                    {
                        GetBulletinDetails();
                        saveProcessID++;
                    }



                    #region Fill Bulletin Categories


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


                    #endregion

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel1.Visible = true;
                            UpdatePanel3.Visible = UpdatePanel2.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit content flyers.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here
                    GetAutoShareRecordStatus();
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    //Font-Family Profile Base
                    DataTable dtProfileAddress = new DataTable();
                    dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                    {
                        hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                    }
                }


                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                lblPublish.Text = hdnPublishTitle.Value;
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID);
                hdnBulletinHeader.Value = preview;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "Page_Load", ex.Message,
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
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "OfficeClosure.aspx.cs", "BtnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                string urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/ManageBulletins.aspx");
                HttpContext.Current.Response.Redirect(urlinfo);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "OfficeClosure.aspx.cs", "BtnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                if (ValidatePublishDate() && ValidateMeridian())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();
                    //Getting Bulletin Details
                    GetBulletinDetails();
                    lblmess.Text = "Content saved successfully.";
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "BtnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "OfficeClosure.aspx.cs", "BtnPublish_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublic.Checked)
                    publishValue = "2";
                if (ValidatePublishDate() && ValidateMeridian())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();

                    //
                    string urlinfo = Page.ResolveClientUrl(RootPath + "/Business/MyAccount/managebulletins.aspx");
                    HttpContext.Current.Response.Redirect(urlinfo);
                }

                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
                if (!ValidateMeridian())
                {
                    ddlEndExSS.Enabled = true;
                    txtEndExMinutes.Enabled = true;
                    lblerror.Text = Resources.LabelMessages.MeridianAlert;
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "BtnPublish_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublishSave('" + publishValue + "');", true);
        }

        private void GetBulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "OfficeClosure.aspx.cs", "GetBulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Edit Bulletin
                DataTable dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(Session["BulletinID"]));

                if (dtBulletinDetails.Rows.Count > 0)
                {
                    Session["BulletinName"] = lblBulletinName.Text = dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString();

                    lblBulletinName.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_Title"]);
                    lblBulletinedit.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]);
                    hdnEditHTML.Value = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]);
                    string previewHtml = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);

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

                    //chkCall.Checked = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsCall"].ToString());
                    //chkContact.Checked = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsContactUs"].ToString());
                    //if (isPhoneNumber == false)
                    //    chkCall.Checked = false;
                    //if (isContatUs == false)
                    //    chkContact.Checked = false;

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

                    //Create Bulletin Image
                    string bulletinImgPath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + Convert.ToString(Session["ProfileID"]) + "\\" + Convert.ToString(Session["BulletinID"]) + ".jpg";
                    if (!File.Exists(bulletinImgPath))
                    {
                        objInBuiltData.CreateImage(uspdVirtualFolder + "\\Upload\\Bulletins\\", Convert.ToInt32(Session["ProfileID"]),
                            UserID, Convert.ToInt32(Session["BulletinID"]), previewHtml);
                    }
                    string CustomXml = Convert.ToString(dtBulletinDetails.Rows[0]["Custom_XML"]);
                    hdnEditHTML.Value = CustomXml;
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(CustomXml);
                    if (hdnEditHTML.Value.Trim() != "")
                    {
                        string str = null;

                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Location") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Location").Value.ToString()))
                                txtLocation.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Location").Value.ToString();
                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@StartTime") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@StartTime").Value.ToString()))
                            {
                                txtStartExMinutes.Enabled = true;
                                ddlStartExSS.Enabled = true;
                                str = xmldoc.SelectSingleNode("Bulletins/Details/@StartTime").Value.ToString();
                                string[] result = str.Split(':', ' ');
                                txtStartExHours.Text = result[0];
                                txtStartExMinutes.Text = result[1];
                                ddlStartExSS.SelectedValue = result[3];
                                txtEndExHours.Enabled = true;
                            }

                        }

                        if (xmldoc.SelectSingleNode("Bulletins/Details/@EndTime") != null)
                        {
                                                  
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@EndTime").Value.ToString()))
                            {
                                txtEndExMinutes.Enabled = true;
                                ddlEndExSS.Enabled = true;
                                str = xmldoc.SelectSingleNode("Bulletins/Details/@EndTime").Value.ToString();
                                string[] result = str.Split(':', ' ');
                                txtEndExHours.Text = result[0];
                                txtEndExMinutes.Text = result[1];
                                ddlEndExSS.SelectedValue = result[3];
                            }

                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Date") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Date").Value.ToString()))
                            {
                                txtAnnounceDate.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Date").Value.ToString();
                            }

                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@PhoneNumber") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@PhoneNumber").Value.ToString()))
                            {
                                txtPhoneNumber.Text = xmldoc.SelectSingleNode("Bulletins/Details/@PhoneNumber").Value.ToString();
                            }

                        }
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Email") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Email").Value.ToString()))
                            {
                                txtContactEmail.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Email").Value.ToString();
                            }

                        }



                    }
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "GetBulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Save_Update_BulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "OfficeClosure.aspx.cs", "Save_Update_BulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);
                string StartTime = "";
                string EndTime = "";
                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                if (txtStartExHours.Text.Trim() != "")
                {
                    if (!string.IsNullOrEmpty(txtStartExHours.Text.Trim()))
                    {
                        txtStartExMinutes.Enabled = true;
                        ddlStartExSS.Enabled = true;
                        if (!string.IsNullOrEmpty(txtStartExHours.Text) && !string.IsNullOrEmpty(txtStartExMinutes.Text))
                        {
                            StartTime = txtStartExHours.Text + ":" + txtStartExMinutes.Text + ":00" + " " + ddlStartExSS.SelectedValue.ToString();
                        }
                        else if (!string.IsNullOrEmpty(txtStartExHours.Text) && string.IsNullOrEmpty(txtStartExMinutes.Text))
                        {
                            StartTime = txtStartExHours.Text + ":00:00" + " " + ddlStartExSS.SelectedValue.ToString();
                        }
                        else if (string.IsNullOrEmpty(txtStartExHours.Text) && !string.IsNullOrEmpty(txtStartExMinutes.Text))
                        {
                            StartTime = " 12:" + txtStartExMinutes.Text + ":00" + " " + ddlStartExSS.SelectedValue.ToString();
                        }
                        else
                        {
                            StartTime = " 00:00:00 AM";
                        }
                    }
                }
                if (txtEndExHours.Text.Trim() != "")
                {
                    if (!string.IsNullOrEmpty(txtEndExHours.Text.Trim()))
                    {
                        txtEndExMinutes.Enabled = true;
                        ddlEndExSS.Enabled = true;
                        if (!string.IsNullOrEmpty(txtEndExHours.Text) && !string.IsNullOrEmpty(txtEndExMinutes.Text))
                        {
                            EndTime = txtEndExHours.Text + ":" + txtEndExMinutes.Text + ":00" + " " + ddlEndExSS.SelectedValue.ToString();
                        }
                        else if (!string.IsNullOrEmpty(txtStartExHours.Text) && string.IsNullOrEmpty(txtStartExMinutes.Text))
                        {
                            EndTime = txtEndExHours.Text + ":00:00" + " " + ddlEndExSS.SelectedValue.ToString();
                        }
                        else if (string.IsNullOrEmpty(txtEndExHours.Text) && !string.IsNullOrEmpty(txtEndExMinutes.Text))
                        {
                            EndTime = " 12:" + txtEndExMinutes.Text + ":00" + " " + ddlEndExSS.SelectedValue.ToString();
                        }
                        else
                        {
                            EndTime = " 00:00:00 AM";
                        }
                    }
                }

                string editHtmlText = hdnEditHTML.Value.ToString();
                string previewHtml = hdnPreviewHTML.Value.ToString();
                string customXML = "";
                customXML = "<Bulletins><Details  Date='" + txtAnnounceDate.Text + "' StartTime='" + StartTime +
                "' EndTime='" + EndTime + "' Location='" + txtLocation.Text.Trim() + "' Email='" + txtContactEmail.Text.Trim() + "' PhoneNumber='" + txtPhoneNumber.Text.Trim() + "' /> </Bulletins>";
                string exDate = hdnExDate.Value.ToString();
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

                string ListDescription = Convert.ToString(hdnDescription.Value);

                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }
                int bulletinCheckID = 0;
                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                DateTime? dateExpires;
                dateExpires = null;
                var exTime = ExpiryTimeControl1.SelectedTime;
                bulletinCheckID = bulletinID;
                bool isPrivate = true;
                if (rbPrivate.Checked)
                    isPrivate = false;

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
                        editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish,
                        ddlCategories.SelectedValue, false, id, "", customXML, ListDescription);
                        if (isPrivate == true)
                            objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, PageNames.BULLETIN, userID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                    }
                    else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires,
                            datePublish, ddlCategories.SelectedValue, isPrivate, CUserID, "", customXML, ListDescription);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires,
                            datePublish, ddlCategories.SelectedValue, isPrivate, id, "", customXML, ListDescription);
                        }
                    }
                }
                else
                {
                    if (isPrivate == true)
                    {
                        bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                        editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish,
                        ddlCategories.SelectedValue, isPrivate, CUserID, "", customXML, ListDescription);
                    }
                    else
                    {
                        bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                        editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, dateExpires, datePublish,
                        ddlCategories.SelectedValue, isPrivate, id, "", customXML, ListDescription);
                    }
                }



                /************************************ Auto Share ***************************************/
                if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                {
                    if (isPrivate)
                    {
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
            }

            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private bool ValidatePublishDate()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "ValidatePublishDate", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                int ProfilID = ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                dtToday = objCommon.ConvertToUserTimeZone(ProfilID);
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
                objInBuiltData.ErrorHandling("ERROR", "OfficeClosure.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }

        private bool ValidateMeridian()
        {
            bool flag = true;
            int startMeridaian = ddlStartExSS.SelectedValue == "PM" ? 1 : 0;
            int EndMeridian = ddlEndExSS.SelectedValue == "PM" ? 1 : 0;
            if (startMeridaian > EndMeridian)
            {
                flag = false;
            }
            return flag;
        }
    }
}