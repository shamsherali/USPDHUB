using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUB.Business.MyAccount
{
    public partial class SetExistingUserPermissions : System.Web.UI.Page
    {
        public int ParentUserID = 0;
        public int ProfileID = 0;
        AgencyBLL agencyobj = new AgencyBLL();
        public int C_UserID = 0;
        public int associateID = 0;
        public static DataTable dtpermissions = new DataTable();
        public static DataTable dtuserdetails = new DataTable();
        public int PermissionCnt = 0;
        public int gridPageIndex = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsSuperAdmin = true;
        BusinessBLL objBus = new BusinessBLL();
        Consumer objConsumer = new Consumer();

        bool chkMessageAuthor = false;
        bool chkPushAuthor = false;
        bool chkMButtonsAuthor = false;
        bool chkASettingsAuthor = false;
        bool chkAuthorContacts = false;
        bool chkToolTip = false;
        bool chkDownloads = false;

        bool chkBulletinsAuthor = false;
        bool chkEventsAuthor = false;
        bool chkSurveyAuthor = false;

        bool chkBulletinsPublisher = false;
        bool chkEventsPublisher = false;
        bool chkSurveyPublisher = false;

        string chkMessageAuthorText = " Manage Message Receipt";
        string chkPushAuthorText = " Push Notifications";
        string chkMButtonsAuthorText = " Manage Buttons";
        string chkASettingsAuthorText = " App Settings";
        string chkAuthorContactsText = " Contacts";
        string chkToolTipText = " Receive Feedback/Tips";
        string chkDownloadsText = " Downloads";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }
        private void BindDropDown()
        {
            try
            {
                //Get Parent Details Here.
                DataTable dtParentUsers = objBus.GetAllParentDetails();
                ddlParentUsers.DataSource = dtParentUsers;
                ddlParentUsers.DataTextField = "Username";
                ddlParentUsers.DataValueField = "User_ID";
                ddlParentUsers.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetExistingUserPermissions.aspx.cs", "BindDropDown", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public DataTable getdata(int UserID)
        {
            DataTable ds = new DataTable();
            try
            {
                string s = "SELECT Firstname,Lastname,Username FROM T_Users WHERE User_ID=" + UserID + " and Active_flag=1";
                SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCmd;

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetExistingUserPermissions.aspx.cs", "getdata", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return ds;
        }
        protected void btnInsertPerms_Click(object sender, EventArgs e)
        {
            try
            {
                int totalAssociates=0;
                Consumer objConsumer = new Consumer();
                int ParentUserID = Convert.ToInt32(ddlParentUsers.SelectedValue);
                DataTable dtAllAssociates = objConsumer.GetManageAssociates(ParentUserID, string.Empty, out totalAssociates);
                DataTable dtDetails = objBus.GetBusinessDeatilsByUserID(ParentUserID);
                ProfileID = Convert.ToInt32(dtDetails.Rows[0]["Profile_ID"].ToString());
                if (dtAllAssociates.Rows.Count > 0)
                {
                    for (int j = 0; j < dtAllAssociates.Rows.Count; j++)
                    {
                        associateID = Convert.ToInt32(dtAllAssociates.Rows[j]["User_ID"].ToString());
                        dtpermissions = agencyobj.SaveUserPermissionsById(associateID);
                        dtuserdetails = getdata(associateID);

                        if (dtpermissions.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtpermissions.Rows.Count; i++)
                            {
                                if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "A")  // "A" for author
                                {
                                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_Values"].ToString())))
                                    {
                                        int Permission_Value = Convert.ToInt32(dtpermissions.Rows[i]["Permission_Values"].ToString());

                                        if (Convert.ToBoolean(Permission_Value & Constants.BULLETINS))
                                            chkBulletinsAuthor = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.EVENTS))
                                            chkEventsAuthor = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.SURVEYS))
                                            chkSurveyAuthor = true;
                                    }
                                }

                                else if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "P")  // "P" for publisher
                                {
                                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_Values"].ToString())))
                                    {
                                        int Permission_Value = Convert.ToInt32(dtpermissions.Rows[i]["Permission_Values"].ToString());

                                        if (Convert.ToBoolean(Permission_Value & Constants.BULLETINS))
                                            chkBulletinsPublisher = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.EVENTS))
                                            chkEventsPublisher = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.SURVEYS))
                                            chkSurveyPublisher = true;
                                    }
                                }
                            }
                            //Insert Mddules
                            List<AllModules> ListModules = new List<AllModules>();
                            DataTable dtCustomModules = objBus.DashboardIcons(ParentUserID);
                            string filterQuery = string.Empty;
                            filterQuery = "ButtonType='Call' or ButtonType='Contact' or ButtonType='Directions' or ButtonType='Tips' or Buttontype='SubApps' or Buttontype='Updates'";
                            DataRow[] dRRemove = dtCustomModules.Select(filterQuery);
                            if (dRRemove != null)
                            {
                                for (int i = 0; i < dRRemove.Length; i++)
                                {
                                    dtCustomModules.Rows.Remove(dRRemove[i]);
                                }
                            }
                            for (int k = 0; k < dtCustomModules.Rows.Count; k++)
                            {
                                if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == "Bulletins"))
                                {
                                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                                        chkBulletinsAuthor, chkBulletinsPublisher, chkBulletinsPublisher, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), 0);
                                }
                                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == "EventCalendar"))
                                {
                                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                                        chkEventsAuthor, chkEventsPublisher, chkEventsPublisher, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), 0);
                                }
                                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == "Surveys"))
                                {
                                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                                        chkSurveyAuthor, chkSurveyPublisher, chkSurveyPublisher, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), 0);
                                }
                                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == WebConstants.Tab_ContentAddOns))
                                {
                                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                                        chkBulletinsAuthor, chkBulletinsPublisher, chkBulletinsPublisher, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), 0);
                                }
                                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == WebConstants.Tab_CalendarAddOns))
                                {
                                    agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                                        chkEventsAuthor, chkEventsPublisher, chkEventsPublisher, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), 0);
                                }
                            }
                            //End Insert Modules

                            if (!string.IsNullOrEmpty((dtpermissions.Rows[0]["IsTipsAdmin"].ToString())))
                                chkToolTip = Convert.ToBoolean((dtpermissions.Rows[0]["IsTipsAdmin"].ToString()));
                            #region
                            if (!string.IsNullOrEmpty((dtpermissions.Rows[0]["Permission_Values"].ToString()))) // For Other privileges...
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.NOTIFICATIONS))
                                    chkPushAuthor = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.MBUTTONS))
                                    chkMButtonsAuthor = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.APPSETTINGS))
                                    chkASettingsAuthor = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.CONTACTS))
                                    chkAuthorContacts = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.BLOCKEDSENDERS))
                                    chkMessageAuthor = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.DOWNLOADS))
                                    chkDownloads = true;
                            }
                            #endregion
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkMessageAuthor, chkMessageAuthor, chkMessageAuthor, associateID, chkMessageAuthorText, 0);
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkPushAuthor, chkPushAuthor, chkPushAuthor, associateID, chkPushAuthorText, 0);
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkMButtonsAuthor, chkMButtonsAuthor, chkMButtonsAuthor, associateID, chkMButtonsAuthorText, 0);
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkASettingsAuthor, chkASettingsAuthor, chkASettingsAuthor, associateID, chkASettingsAuthorText, 0);
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkAuthorContacts, chkAuthorContacts, chkAuthorContacts, associateID, chkAuthorContactsText, 0);
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkToolTip, chkToolTip, chkToolTip, associateID, chkToolTipText, 0);
                            agencyobj.InsertUpdateUserPermissions(ProfileID, ParentUserID, null, chkDownloads, chkDownloads, chkDownloads, associateID, chkDownloadsText, 0);
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetExistingUserPermissions.aspx.cs", "btnInsertPerms_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}