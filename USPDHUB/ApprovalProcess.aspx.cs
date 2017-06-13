using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class ApprovalProcess : System.Web.UI.Page
    {
        public int EventId = 0;
        EventCalendarBLL adminobj = new EventCalendarBLL();
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        public int BusinessUpdateID = 0;
        BusinessUpdatesBLL ObjUpdate = new BusinessUpdatesBLL();
        BusinessBLL busObj = new BusinessBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        BusinessBLL bus = new BusinessBLL();
        public int BulletinID = 0;
        public int CustomID = 0;
        BulletinBLL objBulletin = new BulletinBLL();
        Consumer conObj = new Consumer();
        AddOnBLL objAddOn = new AddOnBLL();
        SqlConnection sqlCon;
        SqlCommand sqlCmd = new SqlCommand();
        string Uid;
        int ProfileId;
        string Modified_Date = (System.DateTime.Now).ToString();

        public int surveyID = 0;

        CommonBLL objCommon = new CommonBLL();

        public string RootPath = "";
        public string DomainName = "";

        public int C_UserID = 0;
        public bool IsShowAutoPost = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["VerticalDomain"] == null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    objCommon.CreateDomainUrl(url);
                }

                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();


                pnlBulletin.Visible = false;
                pnlEvent.Visible = false;
                pnlUpdate.Visible = false;
                pnlSurvey.Visible = false;
                pnlShowButtons.Visible = false;


                if (Request.QueryString["UID"] != null)
                {
                    Uid = EncryptDecrypt.DESDecrypt(Request.QueryString["UID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+"));

                }
                if (Request.QueryString["CUserID"] != null)
                {
                    C_UserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["CUserID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));
                }
                DataTable dtobj = conObj.GetUserDetailsByID(Convert.ToInt32(Uid));
                ProfileId = Convert.ToInt32(dtobj.Rows[0]["Profile_ID"].ToString());

                if (!IsPostBack)
                {

                }


                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].ToString() == "ET")
                    {
                        pnlEvent.Visible = true;
                        try
                        {
                            if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                                EventId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));

                            if (!IsPostBack)
                            {
                                if (EventId > 0)
                                {
                                    DataTable DtBulletin = adminobj.GetCalendarEventDetails(EventId);
                                    if (DtBulletin.Rows.Count > 0)
                                    {
                                        DateTime StartDate = DateTime.Parse(DtBulletin.Rows[0]["EventStartDate"].ToString());
                                        DateTime EndDate = DateTime.Parse(DtBulletin.Rows[0]["EventEndDate"].ToString());
                                        lbleventName.Text = DtBulletin.Rows[0]["EventTitle"].ToString();
                                        lblstartdate.Text = StartDate.ToString("MMM dd yyyy hh:mm tt");
                                        lbleventEndDate.Text = EndDate.ToString("MMM dd yyyy hh:mm tt");
                                        lblEventDesc.Text = DtBulletin.Rows[0]["EventDesc"].ToString();
                                        if (string.IsNullOrEmpty(DtBulletin.Rows[0]["Published_By"].ToString()) && string.IsNullOrEmpty(DtBulletin.Rows[0]["Rejected_By"].ToString()))
                                            pnlShowButtons.Visible = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblbulletin.Text = ex.Message;
                        }
                    }
                    if (Request.QueryString["Type"].ToString() == "CA")
                    {
                        pnlEvent.Visible = true;
                        try
                        {
                            if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                                EventId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));

                            if (!IsPostBack)
                            {
                                if (EventId > 0)
                                {
                                    DataTable DtBulletin = objCalendarAddOn.GetCalendarAddOnDetails(EventId);
                                    if (DtBulletin.Rows.Count > 0)
                                    {
                                        DateTime StartDate = DateTime.Parse(DtBulletin.Rows[0]["EventStartDate"].ToString());
                                        DateTime EndDate = DateTime.Parse(DtBulletin.Rows[0]["EventEndDate"].ToString());
                                        lbleventName.Text = DtBulletin.Rows[0]["EventTitle"].ToString();
                                        lblstartdate.Text = StartDate.ToString("MMM dd yyyy hh:mm tt");
                                        lbleventEndDate.Text = EndDate.ToString("MMM dd yyyy hh:mm tt");
                                        lblEventDesc.Text = DtBulletin.Rows[0]["EventDesc"].ToString();
                                        if (string.IsNullOrEmpty(DtBulletin.Rows[0]["Published_By"].ToString()) && string.IsNullOrEmpty(DtBulletin.Rows[0]["Rejected_By"].ToString()))
                                            pnlShowButtons.Visible = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblbulletin.Text = ex.Message;
                        }
                    }
                    else if (Request.QueryString["Type"].ToString() == "BU")
                    {
                        try
                        {
                            if (Request.QueryString["BID"] != null)
                            {
                                if (Request.QueryString["BID"].ToString() != "")
                                {
                                    string BusinessID = Request.QueryString["BID"].ToString().Replace(" ", "+");
                                    BusinessID = BusinessID.Replace("irhmalli", "=").Replace("irhPASS", "+");
                                    int length = BusinessID.Length;
                                    if (BusinessID[length - 1] != '=')
                                    {
                                        BusinessID += '=';
                                    }
                                    BusinessID = EncryptDecrypt.DESDecrypt(BusinessID);
                                    BusinessUpdateID = Convert.ToInt32(BusinessID);
                                }
                            }
                            else
                            {
                                if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                                    BusinessUpdateID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));
                            }
                            Session["OnlineUpdate"] = "1";
                            if (BusinessUpdateID > 0)
                            {
                                pnlUpdate.Visible = true;
                                DataTable DtBusinessUpdate = new DataTable();
                                DtBusinessUpdate = ObjUpdate.UpdateBusinessUpdateDetails(BusinessUpdateID);
                                if (DtBusinessUpdate.Rows.Count > 0)
                                {
                                    string title = DtBusinessUpdate.Rows[0]["UpdateTitle"].ToString();
                                    int Profile_ID = Convert.ToInt32(DtBusinessUpdate.Rows[0]["ProfileID"]);
                                    DataTable dtbus = new DataTable();
                                    dtbus = bus.GetProfileDetailsByProfileID(Profile_ID);
                                    if (dtbus.Rows.Count > 0)
                                    {
                                        lbl_businessname.Text = "Online Content from " + "<br/><font  align='center' >" + dtbus.Rows[0]["Profile_name"].ToString() + "</font>";
                                    }
                                    if (title.ToString().Length > 0)
                                    {
                                        Lbl_Updatetitle.Text = title.ToString();
                                    }
                                    else
                                    {
                                        Lbl_Updatetitle.Text = "";
                                    }
                                    string HTMLString = string.Empty;
                                    HTMLString = DtBusinessUpdate.Rows[0]["UpdatedText"].ToString();
                                    lblBusinessUpdate.Text = HTMLString;
                                    if (string.IsNullOrEmpty(DtBusinessUpdate.Rows[0]["Published_By"].ToString()) && string.IsNullOrEmpty(DtBusinessUpdate.Rows[0]["Rejected_By"].ToString()))
                                        pnlShowButtons.Visible = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblBusinessUpdate.Text = ex.Message;
                        }
                    }
                    else if (Request.QueryString["Type"].ToString() == "BL")
                    {
                        try
                        {
                            if (Request.QueryString["BLID"] != null && Request.QueryString["BLID"] != "")
                            {
                                string BLID = Request.QueryString["BLID"].ToString().Replace(" ", "+");
                                BLID = BLID.Replace("irhmalli", "=").Replace("irhPASS", "+");
                                int length = BLID.Length;
                                if (BLID[length - 1] != '=')
                                {
                                    BLID += '=';
                                }
                                BLID = EncryptDecrypt.DESDecrypt(BLID);
                                BulletinID = Convert.ToInt32(BLID);

                            }
                            else
                            {
                                if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                                    BulletinID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));
                            }
                            if (BulletinID > 0)
                            {
                                DataTable DtBulletin = objBulletin.GetBulletinDetailsByID(BulletinID);
                                if (DtBulletin.Rows.Count > 0)
                                {
                                    pnlBulletin.Visible = true;
                                    lblbulletin.Text = DtBulletin.Rows[0]["Bulletin_HTML"].ToString();
                                    if (string.IsNullOrEmpty(DtBulletin.Rows[0]["Published_By"].ToString()) && string.IsNullOrEmpty(DtBulletin.Rows[0]["Rejected_By"].ToString()))
                                        pnlShowButtons.Visible = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblbulletin.Text = ex.Message;
                        }
                    }
                    else if (Request.QueryString["Type"].ToString() == "CM")
                    {
                        try
                        {
                            if (Request.QueryString["CMID"] != null && Request.QueryString["CMID"] != "")
                            {
                                string BLID = Request.QueryString["CMID"].ToString().Replace(" ", "+");
                                BLID = BLID.Replace("irhmalli", "=").Replace("irhPASS", "+");
                                int length = BLID.Length;
                                if (BLID[length - 1] != '=')
                                {
                                    BLID += '=';
                                }
                                BLID = EncryptDecrypt.DESDecrypt(BLID);
                                CustomID = Convert.ToInt32(BLID);

                            }
                            else
                            {
                                if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                                    CustomID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));
                            }
                            if (CustomID > 0)
                            {
                                DataTable DtAddOn = objAddOn.GetCustomModuleByID(CustomID);
                                if (DtAddOn.Rows.Count > 0)
                                {
                                    pnlBulletin.Visible = true;
                                    lblbulletin.Text = DtAddOn.Rows[0]["Bulletin_HTML"].ToString();
                                    if (string.IsNullOrEmpty(DtAddOn.Rows[0]["Published_By"].ToString()) && string.IsNullOrEmpty(DtAddOn.Rows[0]["Rejected_By"].ToString()))
                                        pnlShowButtons.Visible = true;
                                    if (Convert.ToString(DtAddOn.Rows[0]["ButtonType"]) == WebConstants.Tab_PrivateContentAddOns)
                                        IsShowAutoPost = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblbulletin.Text = ex.Message;
                        }
                    }
                    else if (Request.QueryString["Type"].ToString() == "SU")
                    {
                        try
                        {
                            IsShowAutoPost = false;
                            if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                                surveyID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString().Replace(" ", "+").Replace("irhmalli", "=").Replace("irhPASS", "+")));

                            if (surveyID > 0)
                            {
                                SurveyBLL objSurveyBLL = new SurveyBLL();
                                DataTable dtSurveyDetails = objSurveyBLL.GetSurveyDetailsByID(surveyID);
                                if (dtSurveyDetails.Rows.Count > 0)
                                {
                                    pnlSurvey.Visible = true;
                                    lblSurveyName.Text = dtSurveyDetails.Rows[0]["Name"].ToString();
                                    lblSurveyType.Text = dtSurveyDetails.Rows[0]["Type_Name"].ToString();
                                    lblSurveyDescription.Text = Convert.ToString(dtSurveyDetails.Rows[0]["Description"]);
                                    string previewHtml_Questions = objCommon.BuildSurveyPreview(Convert.ToInt32(surveyID));
                                    lblQuestions.Text = previewHtml_Questions;

                                    if (string.IsNullOrEmpty(dtSurveyDetails.Rows[0]["Published_By"].ToString()) && string.IsNullOrEmpty(dtSurveyDetails.Rows[0]["Rejected_By"].ToString()))
                                        pnlShowButtons.Visible = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblbulletin.Text = ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ApprovalProcess.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void EnableAutoShare()
        {
            if (IsShowAutoPost)
            {
                DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileId);
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
                    chkFbAutoPost.Visible = false;
                DataTable dtExistingTwrUserData = smb.GetTwitterDataByUserID(ProfileId);
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
                    chkTwrAutoPost.Visible = false;
            }
            else
            {
                chkFbAutoPost.Visible = false;
                chkTwrAutoPost.Visible = false;
                chkFbAutoPost.Checked = false;
                chkTwrAutoPost.Checked = false;
            }
        }
        protected void imgApprove_Click(object sender, EventArgs e)
        {
            lblRemarks.Text = "Remarks";
            if (busObj.CheckModulePermission(WebConstants.Purchase_SocialMediaAutoPostSetup, ProfileId))
            {
                EnableAutoShare();
            }
            else
            {
                chkFbAutoPost.Visible = false;
                chkTwrAutoPost.Visible = false;
                chkFbAutoPost.Checked = false;
                chkTwrAutoPost.Checked = false;
            }

            ModalPopupExtender1.Show();
            hdnProcess.Value = "1";
        }
        protected void imgReject_Click(object sender, EventArgs e)
        {
            lblRemarks.Text = "Reason";
            chkFbAutoPost.Checked = false;
            chkTwrAutoPost.Checked = false;
            chkFbAutoPost.Visible = false;
            chkTwrAutoPost.Visible = false;
            ModalPopupExtender1.Show();
            hdnProcess.Value = "2";
        }
        protected void imgclse_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            hdnProcess.Value = "";
            txtInitials.Text = "";
            TxtRemarks.Text = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int? UserID = null;
                int pUserID = 0;
                string ss = string.Empty;
                int val = 0;

                txtInitials.Text = txtInitials.Text.Replace("'", "''");
                TxtRemarks.Text = TxtRemarks.Text.Replace("'", "''");

                if (Uid == "")
                    Uid = txtInitials.Text.Trim();
                else
                {
                    UserID = pUserID = Convert.ToInt32(Uid);
                }
                DataTable dt = new DataTable();
                string remarks = "";
                DateTime dtPublishDate = DateTime.Today;
                DateTime dtCurrentDate = DateTime.Today;

                DataTable dtuserDetails = new DataTable();
                string userName = "";
                string resultmsg = "";
                if (Uid != "")
                {
                    dtuserDetails = bus.GetUserDtlsByUserID(Convert.ToInt32(Uid));
                    if (!string.IsNullOrEmpty(dtuserDetails.Rows[0]["SuperAdmin_ID"].ToString()))
                        pUserID = Convert.ToInt32(dtuserDetails.Rows[0]["SuperAdmin_ID"].ToString());
                    userName = Convert.ToString(dtuserDetails.Rows[0]["Username"]);
                }
                int approvedType = Convert.ToInt32(ApprovalProcessTypes.Approved);

                /*** Bulletins ***/
                if (BulletinID > 0)
                {
                    dt = objBulletin.GetBulletinDetailsByID(BulletinID);
                    string Modified_Date = (System.DateTime.Now).ToString();
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Publish_Date"].ToString()))
                        {
                            dtPublishDate = Convert.ToDateTime(dt.Rows[0]["Publish_Date"].ToString());
                            if (dtPublishDate.ToShortDateString() == dtCurrentDate.ToShortDateString())
                                dtPublishDate = DateTime.Now;
                        }
                        if (string.IsNullOrEmpty(dt.Rows[0]["Remarks"].ToString()))
                            remarks = txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                        else
                            remarks = dt.Rows[0]["Remarks"].ToString() + "##Separator" + txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                    }

                    if (hdnProcess.Value == "1")
                    {
                        //ss = "Update T_Manage_Bulletins set  Remarks='" + remarks + "', IsPublished='true',Publish_Date='" + dtPublishDate + "', Published_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',Modified_Date='" + System.DateTime.Now + "'";
                        //if (UserID != null)
                        //    ss = ss + ", Modified_User=" + UserID;
                        //ss = ss + " where Bulletin_ID=" + BulletinID + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "Bulletins", 0, 0, 0, "", BulletinID);

                        resultmsg = "Content has been approved successfully.";
                        int ProfileID = busObj.GetProfileIDByUserID(pUserID);
                        busObj.Insert_SilentPushMessages(ProfileID, dtPublishDate, false, BulletinID, "Bulletins", "Publish");
                    }
                    else if (hdnProcess.Value == "2")
                    {
                        //ss = "Update T_Manage_Bulletins set Remarks='" + remarks + "', Rejected_By='" + Uid + "', IsPublished='false',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',Modified_Date='" + System.DateTime.Now + "',Publish_Date=null,IsPrivate='true',Published_By=null";
                        //if (UserID != null)
                        //    ss = ss + ", Modified_User=" + UserID;
                        //ss = ss + " where Bulletin_ID=" + BulletinID + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "Bulletins", 0, 0, 0, "", BulletinID);

                        resultmsg = "Content has been rejected successfully.";
                        approvedType = Convert.ToInt32(ApprovalProcessTypes.Rejected);
                    }
                    //Sending Mail to Author and Assicoates         
                    objCommon.SendApproveEmailToAuthor(Convert.ToString(userName), Convert.ToInt32(BulletinID), PageNames.BULLETIN.ToString(),
                        Convert.ToInt32(Uid), pUserID, PageNames.BULLETIN.ToString(), DomainName, Convert.ToString(dt.Rows[0]["Bulletin_Title"]), TxtRemarks.Text, txtInitials.Text.Trim(), approvedType, C_UserID);
                }

                /*** Content Module ***/
                if (CustomID > 0)
                {
                    dt = objAddOn.GetCustomModuleByID(CustomID);
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Publish_Date"].ToString()))
                        {
                            dtPublishDate = Convert.ToDateTime(dt.Rows[0]["Publish_Date"].ToString());
                            if (dtPublishDate.ToShortDateString() == dtCurrentDate.ToShortDateString())
                                dtPublishDate = DateTime.Now;
                        }
                        if (string.IsNullOrEmpty(dt.Rows[0]["Remarks"].ToString()))
                            remarks = txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                        else
                            remarks = dt.Rows[0]["Remarks"].ToString() + "##Separator" + txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                    }
                    if (hdnProcess.Value == "1")
                    {
                        //ss = "Update T_Manage_CustomModule set  Remarks='" + remarks + "', IsPublished='true',Publish_Date='" + dtPublishDate + "', Published_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',Modified_Date='" + System.DateTime.Now + "'";
                        //if (UserID != null)
                        //    ss = ss + ", Modified_User=" + UserID;
                        //ss = ss + " where Custom_ID=" + CustomID + "";
                        //val = InsertDetails(ss);

                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "ContentModule", 0, 0, CustomID, "", 0);
                        resultmsg = "Content has been approved successfully.";
                        int ProfileID = busObj.GetProfileIDByUserID(pUserID);
                        busObj.Insert_SilentPushMessages(ProfileID, dtPublishDate, false, CustomID, "ContentModule", "Publish");
                    }
                    else if (hdnProcess.Value == "2")
                    {
                        //ss = "Update T_Manage_CustomModule set Remarks='" + remarks + "', Rejected_By='" + Uid + "', IsPublished='false',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',Modified_Date='" + System.DateTime.Now + "',Publish_Date=null,Published_By=null";
                        //if (UserID != null)
                        //    ss = ss + ", Modified_User=" + UserID;
                        //ss = ss + " where Custom_ID=" + CustomID + "";
                        // val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "ContentModule", 0, 0, CustomID, "", 0);

                        resultmsg = "Content has been rejected successfully.";
                        approvedType = Convert.ToInt32(ApprovalProcessTypes.Rejected);
                    }
                    //Sending Mail to Author and Assicoates         
                    objCommon.SendApproveEmailToAuthor(Convert.ToString(userName), Convert.ToInt32(CustomID), PageNames.CustomModule.ToString(),
                        Convert.ToInt32(Uid), pUserID, PageNames.CustomModule.ToString(), DomainName, Convert.ToString(dt.Rows[0]["Bulletin_Title"]), TxtRemarks.Text, txtInitials.Text.Trim(), approvedType, C_UserID);
                }
                /*** Events ***/
                else if (EventId > 0)
                {

                    string CalendarType = "ET";
                    if (Request.QueryString["Type"].ToString() == "CA")
                        CalendarType = "CA";
                    if (CalendarType == "ET")
                        dt = adminobj.GetCalendarEventDetails(EventId);
                    else
                        dt = objCalendarAddOn.GetCalendarAddOnDetails(EventId);
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Publish_Date"].ToString()))
                        {
                            dtPublishDate = Convert.ToDateTime(dt.Rows[0]["Publish_Date"].ToString());
                            if (dtPublishDate.ToShortDateString() == dtCurrentDate.ToShortDateString())
                                dtPublishDate = DateTime.Now;
                        }
                        if (string.IsNullOrEmpty(dt.Rows[0]["Remarks"].ToString()))
                            remarks = txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                        else
                            remarks = dt.Rows[0]["Remarks"].ToString() + "##Separator" + txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                    }

                    if (hdnProcess.Value == "1")
                    {
                        //ss = "Update " + (CalendarType == "ET" ? "T_EventsCalendar" : "T_ManageCalendarAddons") + " set Remarks='" + remarks + "', IsPublished='true',Publish_Date='" + dtPublishDate + "', Published_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "', " + (CalendarType == "ET" ? "ModifyDate" : "Modified_Date") + "='" + System.DateTime.Now + "'";
                        //if (UserID != null)
                        //    ss = ss + ", ModifiedUser=" + UserID;
                        //ss = ss + " where " + (CalendarType == "ET" ? "EventId=" : "CalendarId") + EventId + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "EventCalendar", 0, EventId, 0, CalendarType, 0);
                        resultmsg = "Event has been approved successfully.";
                        int ProfileID = busObj.GetProfileIDByUserID(pUserID);
                        busObj.Insert_SilentPushMessages(ProfileID, dtPublishDate, false, EventId, "EventCalendar", "Publish");
                    }
                    else if (hdnProcess.Value == "2")
                    {

                        //ss = "Update " + (CalendarType == "ET" ? "T_EventsCalendar" : "T_ManageCalendarAddons") + " set Remarks='" + remarks + "', Rejected_By='" + Uid + "', IsPublished='false',APRJProcess_Initials='" + txtInitials.Text.Trim() + "', " + (CalendarType == "ET" ? "IsPublic='false',ModifyDate" : "Modified_Date") + "='" + System.DateTime.Now + "',Publish_Date=null,Published_By=null";
                        //if (UserID != null)
                        //    ss = ss + ", ModifiedUser=" + UserID;
                        //ss = ss + " where " + (CalendarType == "ET" ? "EventId=" : "CalendarId") + EventId + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "EventCalendar", 0, EventId, 0, CalendarType, 0);
                        resultmsg = "Event has been rejected successfully.";
                        approvedType = Convert.ToInt32(ApprovalProcessTypes.Rejected);
                    }
                    //Sending Mail to Author and Assicoates         
                    objCommon.SendApproveEmailToAuthor(Convert.ToString(userName), Convert.ToInt32(EventId), CalendarType == "ET" ? PageNames.EVENT.ToString() : PageNames.CALENDARADDON.ToString(),
                        Convert.ToInt32(Uid), pUserID, CalendarType == "ET" ? PageNames.EVENT.ToString() : PageNames.CALENDARADDON.ToString(), DomainName, Convert.ToString(dt.Rows[0]["EventTitle"]), TxtRemarks.Text, txtInitials.Text.Trim(), approvedType, C_UserID);
                }/*** Business Updates ***/
                else if (BusinessUpdateID > 0)
                {
                    dt = ObjUpdate.UpdateBusinessUpdateDetails(BusinessUpdateID);
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Publish_Date"].ToString()))
                        {
                            dtPublishDate = Convert.ToDateTime(dt.Rows[0]["Publish_Date"].ToString());
                            if (dtPublishDate.ToShortDateString() == dtCurrentDate.ToShortDateString())
                                dtPublishDate = DateTime.Now;
                        }
                        if (string.IsNullOrEmpty(dt.Rows[0]["Remarks"].ToString()))
                            remarks = txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                        else
                            remarks = dt.Rows[0]["Remarks"].ToString() + "##Separator" + txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                    }
                    if (hdnProcess.Value == "1")
                    {
                        resultmsg = "Content has been approved successfully.";
                        //ss = "Update T_BusinessUpdates set Remarks='" + remarks + "', IsPublished='true',Publish_Date='" + dtPublishDate + "', Published_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',MODIFIED_DATE='" + System.DateTime.Now + "'";
                        //if (UserID != null)
                        //    ss = ss + ", MODIFIED_USER='" + UserID.ToString() + "'";
                        //ss = ss + " where UpdateId=" + BusinessUpdateID + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "BusinessUpdate", BusinessUpdateID, 0, 0, "", 0);
                    }
                    else if (hdnProcess.Value == "2")
                    {
                        //ss = "Update T_BusinessUpdates set Remarks='" + remarks + "', Rejected_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "', IsPublished='false',MODIFIED_DATE='" + System.DateTime.Now + "',Publish_Date=null,IsPublic='false',Published_By=null";
                        //if (UserID != null)
                        //    ss = ss + ", MODIFIED_USER='" + UserID.ToString() + "'";
                        //ss = ss + " where UpdateId=" + BusinessUpdateID + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, 0, hdnProcess.Value, "BusinessUpdate", BusinessUpdateID, 0, 0, "", 0);
                        resultmsg = "Content has been rejected successfully.";
                        approvedType = Convert.ToInt32(ApprovalProcessTypes.Rejected);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        //Sending Mail to Author and Assicoates         
                        objCommon.SendApproveEmailToAuthor(Convert.ToString(userName), Convert.ToInt32(BusinessUpdateID), PageNames.UPDATE.ToString(),
                            Convert.ToInt32(Uid), pUserID, PageNames.UPDATE.ToString(), DomainName, Convert.ToString(dt.Rows[0]["UpdateTitle"]), TxtRemarks.Text, txtInitials.Text.Trim(), approvedType, C_UserID);
                    }
                }/*** Surveys ***/
                else if (surveyID > 0)
                {
                    SurveyBLL objSurveyBLL = new SurveyBLL();
                    dt = objSurveyBLL.GetSurveyDetailsByID(surveyID);

                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Publish_Date"].ToString()))
                        {
                            dtPublishDate = Convert.ToDateTime(dt.Rows[0]["Publish_Date"].ToString());
                            if (dtPublishDate.ToShortDateString() == dtCurrentDate.ToShortDateString())
                                dtPublishDate = DateTime.Now;
                        }
                        if (string.IsNullOrEmpty(dt.Rows[0]["Remarks"].ToString()))
                            remarks = txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                        else
                            remarks = dt.Rows[0]["Remarks"].ToString() + "##Separator" + txtInitials.Text.Trim() + " ##IN " + TxtRemarks.Text;
                    }
                    if (hdnProcess.Value == "1")
                    {
                        resultmsg = "Survey has been approved successfully.";
                        //ss = "Update T_Manage_Surveys set Remarks='" + remarks + "', IsPublished='true',Publish_Date='" + dtPublishDate + "', Published_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',MODIFIED_DATE='" + System.DateTime.Now + "'";
                        //if (UserID != null)
                        //    ss = ss + ", MODIFIED_USER='" + UserID.ToString() + "'";
                        //ss = ss + " where Survey_ID=" + surveyID + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, surveyID, hdnProcess.Value, "Surveys", 0, 0, 0, "", 0);
                        int ProfileID = busObj.GetProfileIDByUserID(pUserID);
                        busObj.Insert_SilentPushMessages(ProfileID, dtPublishDate, false, surveyID, "Surveys", "Publish");
                    }
                    else if (hdnProcess.Value == "2")
                    {
                        //ss = "Update T_Manage_Surveys set Remarks='" + remarks + "', Rejected_By='" + Uid + "',APRJProcess_Initials='" + txtInitials.Text.Trim() + "',MODIFIED_DATE='" + System.DateTime.Now + "',Publish_Date=null,IsPublished='false',Published_By=null";
                        //if (UserID != null)
                        //    ss = ss + ", MODIFIED_USER='" + UserID.ToString() + "'";
                        //ss = ss + " where Survey_ID=" + surveyID + "";
                        //val = InsertDetails(ss);
                        busObj.InsertApprovalProccessDetails(remarks, dtPublishDate, Convert.ToInt32(Uid), txtInitials.Text.Trim(), UserID, surveyID, hdnProcess.Value, "Surveys", 0, 0, 0, "", 0);

                        resultmsg = "Survey has been rejected successfully.";
                        approvedType = Convert.ToInt32(ApprovalProcessTypes.Rejected);
                    }
                    //Sending Mail to Author and Assicoates
                    objCommon.SendApproveEmailToAuthor(Convert.ToString(userName), Convert.ToInt32(surveyID), PageNames.SURVEY.ToString(),
                        Convert.ToInt32(Uid), pUserID, PageNames.SURVEY.ToString(), DomainName, Convert.ToString(dt.Rows[0]["Name"]), TxtRemarks.Text, txtInitials.Text.Trim(), approvedType, C_UserID);
                }
                AutoShare(pUserID, dtPublishDate);
                lblMessage.Text = resultmsg;
                ModalPopupExtender1.Hide();
                pnlShowButtons.Visible = false;
                hdnProcess.Value = "";
                txtInitials.Text = "";
                TxtRemarks.Text = "";

            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ApprovalProcess.aspx.cs", "btnSubmit_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public int InsertDetails(string query)
        {
            int returnval = 0;
            sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
            sqlCmd = new SqlCommand(query, sqlCon);
            returnval = sqlCmd.ExecuteNonQuery();
            USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            return returnval;
        }
        private void AutoShare(int pUserId, DateTime dtPublishDate)
        {
            try
            {
                string type = string.Empty;
                string title = string.Empty;
                int typeID = 0;
                if (Request.QueryString["Type"].ToString() == "ET")
                {
                    type = WebConstants.Tab_EventCalendar;
                    typeID = EventId;
                    if (EventId > 0)
                    {
                        DataTable DtEvents = adminobj.GetCalendarEventDetails(EventId);
                        if (DtEvents.Rows.Count > 0)
                            title = DtEvents.Rows[0]["EventTitle"].ToString();
                    }
                }
                else if (Request.QueryString["Type"].ToString() == "CA")
                {
                    type = WebConstants.Tab_CalendarAddOns;
                    typeID = EventId;
                    if (EventId > 0)
                    {
                        DataTable DtEvents = objCalendarAddOn.GetCalendarAddOnDetails(EventId);
                        if (DtEvents.Rows.Count > 0)
                            title = DtEvents.Rows[0]["EventTitle"].ToString();
                    }
                }
                else if (Request.QueryString["Type"].ToString() == "CM")
                {
                    type = "ContentModule";
                    typeID = CustomID;
                    if (CustomID > 0)
                    {
                        DataTable DtCustomModule = objAddOn.GetCustomModuleByID(CustomID);
                        if (DtCustomModule.Rows.Count > 0)
                            title = DtCustomModule.Rows[0]["Bulletin_Title"].ToString();
                    }
                }
                else if (Request.QueryString["Type"].ToString() == "BL")
                {
                    type = "Bulletin";
                    typeID = BulletinID;
                    if (BulletinID > 0)
                    {
                        DataTable DtBulletin = objBulletin.GetBulletinDetailsByID(BulletinID);
                        if (DtBulletin.Rows.Count > 0)
                            title = DtBulletin.Rows[0]["Bulletin_Title"].ToString();
                    }
                }
                else if (Request.QueryString["Type"].ToString() == "BU")
                {
                    type = "Updates";
                    typeID = BusinessUpdateID;
                    if (BusinessUpdateID > 0)
                    {
                        DataTable DtUpdates = ObjUpdate.UpdateBusinessUpdateDetails(BusinessUpdateID);
                        if (DtUpdates.Rows.Count > 0)
                            title = DtUpdates.Rows[0]["UpdateTitle"].ToString();
                    }
                }
                if (chkFbAutoPost.Visible == true)
                {
                    if (chkFbAutoPost.Checked)
                        adminobj.InsertUpdateAutoShareDetails(type, typeID, 0, dtPublishDate, "Facebook", pUserId, Convert.ToInt32(Uid), title);
                }
                if (chkTwrAutoPost.Visible == true)
                {
                    if (chkTwrAutoPost.Checked)
                        adminobj.InsertUpdateAutoShareDetails(type, typeID, 0, dtPublishDate, "Twitter", pUserId, Convert.ToInt32(Uid), title);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ApprovalProcess.aspx.cs", "AutoShare", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}