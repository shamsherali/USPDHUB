using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Services;
using System.Data.SqlClient;

namespace USPDHUB.Business.MyAccount
{
    public partial class UserPermissions : BaseWeb
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

        public bool IsSuperAdmin = true;
        BusinessBLL objBus = new BusinessBLL();
        Consumer objConsumer = new Consumer();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
                {
                    associateID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"]));
                    dtpermissions = agencyobj.SaveUserPermissionsById(associateID);
                    dtuserdetails = getdata(associateID);
                    if (dtuserdetails.Rows.Count > 0)
                        hdnuserflag.Value = dtuserdetails.Rows[0]["Username"].ToString();
                    if (dtpermissions.Rows.Count > 0)
                        PermissionCnt = dtpermissions.Rows.Count;

                    if (Session["C_USER_ID"] != null)
                    {
                        DataTable dtUserDetails = objBus.GetUserDtlsByUserID(C_UserID);
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                    }
                }

                if (Request.QueryString["index"] != "" && Request.QueryString["index"] != null)
                    gridPageIndex = Convert.ToInt32(Request.QueryString["index"]);

                if (!IsPostBack)
                {
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && IsSuperAdmin == false) //user roles & permissions
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to access user permissions.</font>";
                    }
                    else if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
                    {
                        if (dtpermissions.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty((dtpermissions.Rows[0]["IsTipsAdmin"].ToString())))
                                chkToolTip.Checked = Convert.ToBoolean((dtpermissions.Rows[0]["IsTipsAdmin"].ToString()));

                            if (!string.IsNullOrEmpty((dtpermissions.Rows[0]["Permission_Values"].ToString()))) // For Other privileges...
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.NOTIFICATIONS))
                                    chkPushAuthor.Checked = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.MBUTTONS))
                                    chkMButtonsAuthor.Checked = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.APPSETTINGS))
                                    chkASettingsAuthor.Checked = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.CONTACTS))
                                    chkAuthorContacts.Checked = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.BLOCKEDSENDERS))
                                    chkMessageAuthor.Checked = true;
                                if (Convert.ToBoolean(Convert.ToInt32(dtpermissions.Rows[0]["Permission_Values"].ToString()) & Constants.DOWNLOADS))
                                    chkDownloads.Checked = true;
                            }

                            for (int i = 0; i < dtpermissions.Rows.Count; i++)
                            {
                                if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "A")  // "A" for author
                                {
                                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_ID"].ToString())))
                                        hdnPermissionAuthorId.Value = dtpermissions.Rows[i]["Permission_ID"].ToString();

                                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_Values"].ToString())))
                                    {
                                        int Permission_Value = Convert.ToInt32(dtpermissions.Rows[i]["Permission_Values"].ToString());

                                        if (Convert.ToBoolean(Permission_Value & Constants.BULLETINS))
                                            chkBulletinsAuthor.Checked = true;
                                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Removed Updates @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//
                                        //if (Convert.ToBoolean(Permission_Value & Constants.UPDATES))
                                        //    chkUpdatesAuthor.Checked = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.EVENTS))
                                            chkEventsAuthor.Checked = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.SURVEYS))
                                            chkSurveyAuthor.Checked = true;
                                    }
                                }

                                else if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "P")  // "P" for publisher
                                {
                                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_ID"].ToString())))
                                        hdnPermissionPublisherId.Value = dtpermissions.Rows[i]["Permission_ID"].ToString();

                                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_Values"].ToString())))
                                    {
                                        int Permission_Value = Convert.ToInt32(dtpermissions.Rows[i]["Permission_Values"].ToString());

                                        if (Convert.ToBoolean(Permission_Value & Constants.BULLETINS))
                                            chkBulletinsPublisher.Checked = true;
                                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Removed Updates @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//
                                        //if (Convert.ToBoolean(Permission_Value & Constants.UPDATES))
                                        //    chkUpdatesPublisher.Checked = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.EVENTS))
                                            chkEventsPublisher.Checked = true;
                                        if (Convert.ToBoolean(Permission_Value & Constants.SURVEYS))
                                            chkSurveyPublisher.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                    else  //user roles & permissions
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to access user permissions.</font>";
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UserPermissions.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                int TotalPermissions = 1 + 4 + 128 + 8 + 16 + 32 + 64 + 256 + 512;
                int Author = 0;
                int Publisher = 0;
                int OtherPrivileges = 0;
                if (chkBulletinsAuthor.Checked)  // Author
                    Author = 1;

                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Removed Updates @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//
                //if (chkUpdatesAuthor.Checked)
                //    Author = Author + 2;

                if (chkEventsAuthor.Checked)
                    Author = Author + 4;

                if (chkSurveyAuthor.Checked)
                    Author = Author + 128;

                if (chkBulletinsPublisher.Checked) // Publisher
                    Publisher = Publisher + 1;

                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Removed Updates @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//
                //if (chkUpdatesPublisher.Checked)
                //    Publisher = Publisher + 2;

                if (chkEventsPublisher.Checked)
                    Publisher = Publisher + 4;

                if (chkSurveyPublisher.Checked)
                    Publisher = Publisher + 128;

                if (chkPushAuthor.Checked)  // OtherPrivileges
                    OtherPrivileges = OtherPrivileges + 8;

                if (chkMButtonsAuthor.Checked)
                    OtherPrivileges = OtherPrivileges + 16;

                if (chkASettingsAuthor.Checked)
                    OtherPrivileges = OtherPrivileges + 32;

                if (chkAuthorContacts.Checked)
                    OtherPrivileges = OtherPrivileges + 64;

                if (chkMessageAuthor.Checked)
                    OtherPrivileges = OtherPrivileges + 256;

                if (chkDownloads.Checked)
                    OtherPrivileges = OtherPrivileges + 512;

                // "A" for Author and "P" for Publisher...
                int permissionAuthorID = 0;
                if (!string.IsNullOrEmpty(hdnPermissionAuthorId.Value))
                    permissionAuthorID = Convert.ToInt32(hdnPermissionAuthorId.Value);

                if (Author > 0 || OtherPrivileges > 0)  // Author
                {
                    Author = Author + OtherPrivileges;
                    hdnPermissionAuthorId.Value = Convert.ToString(agencyobj.InsertUserPermissionDetails(ParentUserID, "A", Author, permissionAuthorID, associateID, chkToolTip.Checked ? true : false, C_UserID));
                }
                else
                {
                    int cntvals = 0;
                    if (permissionAuthorID > 0)
                        cntvals = agencyobj.DeletePermissions(Convert.ToInt32(hdnPermissionAuthorId.Value));
                }

                int permissionPublisherID = 0;
                if (!string.IsNullOrEmpty(hdnPermissionPublisherId.Value))
                    permissionPublisherID = Convert.ToInt32(hdnPermissionPublisherId.Value);
                if (Publisher > 0 || OtherPrivileges > 0)  // Publisher
                {
                    Publisher = Publisher + OtherPrivileges;
                    hdnPermissionPublisherId.Value = Convert.ToString(agencyobj.InsertUserPermissionDetails(ParentUserID, "P", Publisher, permissionPublisherID, associateID, chkToolTip.Checked ? true : false, C_UserID));
                }
                else
                {
                    int val = 0;
                    if (permissionPublisherID > 0)
                        val = agencyobj.DeletePermissions(permissionPublisherID);
                }
                if ((Author + OtherPrivileges) != TotalPermissions || (Publisher + OtherPrivileges) != TotalPermissions || chkToolTip.Checked == false)
                {
                    int count = objConsumer.Insert_Update_AssociateLogin("", "", "", "", "", C_UserID, ParentUserID, false, associateID);
                }
                if (Author > 0 || Publisher > 0 || OtherPrivileges > 0)
                {
                    if (dtpermissions.Rows.Count == 0)
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?count=3&page=" + gridPageIndex));
                    else
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?count=4&page=" + gridPageIndex));
                }
                else
                {
                    if (dtpermissions.Rows.Count > 0)
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?count=4&page=" + gridPageIndex));
                    else
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?count=5&page=" + gridPageIndex));
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UserPermissions.aspx.cs", "lnkSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?page=" + gridPageIndex));
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
                objInBuiltData.ErrorHandling("ERROR", "UserPermissions.aspx.cs", "getdata", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return ds;
        }
    }
}