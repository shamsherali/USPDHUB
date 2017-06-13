using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Data.SqlClient;

public partial class Business_MyAccount_AssociateLogin : BaseWeb
{

    public int UserID = 0;
    public int C_UserID = 0;
    public int ProfileID = 0;
    public int associateID = 0;
    AgencyBLL agencyobj = new AgencyBLL();
    public static DataTable Dtgroups = new DataTable();
    public static DataTable Dtpermissions = new DataTable();
    public string PermissionType = string.Empty;
    public int PermissionValue = 0;
    public string RootPath = "";
    public string DomainName = "";
    public int gridPageIndex = 0;

    CommonBLL objCommon = new CommonBLL();
    BusinessBLL objBus = new BusinessBLL();
    Consumer objConsumer = new Consumer();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public bool isEdit = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null && Session["UserID"].ToString() != "")
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                C_UserID = UserID;
                if (Session["ProfileID"] != null)
                {
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                }
            }
            else
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            if (Request.QueryString["AID"] != null && EncryptDecrypt.DESDecrypt(Request.QueryString["AID"].ToString()) != "")
            {
                isEdit = true;
                associateID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["AID"]));
            }

            if (Request.QueryString["index"] != "" && Request.QueryString["index"] != null)
                gridPageIndex = Convert.ToInt32(Request.QueryString["index"]);

            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (Session["C_USER_ID"] != null)
            {
                C_UserID = Convert.ToInt32(Session["C_USER_ID"].ToString());
            }
            if (!IsPostBack)
            {
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                hdnVertical.Value = dtProfile.Rows[0]["Vertical_Name"].ToString();
                hdnCountry.Value = dtProfile.Rows[0]["Profile_County"].ToString();
                DataTable dtUser = objBus.GetUserDtlsByUserID(associateID);
                if (dtUser.Rows.Count > 0 && associateID > 0)
                {
                    txtFirstName.Text = dtUser.Rows[0]["Firstname"].ToString();
                    txtLastName.Text = dtUser.Rows[0]["Lastname"].ToString();
                    hdnPwd.Value = EncryptDecrypt.DESDecrypt(dtUser.Rows[0]["Password"].ToString());
                    txtPassword.Attributes.Add("value", EncryptDecrypt.DESDecrypt(dtUser.Rows[0]["Password"].ToString()));
                    txtConfirmPwd.Attributes.Add("value", EncryptDecrypt.DESDecrypt(dtUser.Rows[0]["Password"].ToString()));
                    txtEmail.Text = dtUser.Rows[0]["Username"].ToString();
                    txtEmail.Enabled = false;
                    if (dtUser.Rows[0]["IsAssociate_SuperAdmin"] != null)
                        chkIsSuperAdmin.Checked = Convert.ToBoolean(dtUser.Rows[0]["IsAssociate_SuperAdmin"].ToString());
                    hdnIsSuperAdmin.Value = dtUser.Rows[0]["IsAssociate_SuperAdmin"].ToString();
                    if (Session["C_USER_ID"] != null)
                    {
                        if (Session["C_USER_ID"].ToString() != associateID.ToString())
                        {
                            chkIsSuperAdmin.Enabled = true;
                        }
                        else
                        {
                            chkIsSuperAdmin.Enabled = false;
                        }
                    }
                }
                else
                {
                    if (isEdit)
                        Response.Redirect("ManageAssociates.aspx");
                }

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                    if (hdnPermissionType.Value == "A")
                    {
                        UpdatePanel1.Visible = false;
                        UpdatePanel2.Visible = true;
                        lblerrormessage.Text = "<font face=arial size=2 color=red>You do not have permission to update agency information.</font>";
                    }
                }
                //ends here
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AssociateLogin.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        txtFirstName.Focus();
    }

    [WebMethod]
    public static string ServerSidefill(string emid, string vertical, string country)
    {
        string typevalue = "";
        try
        {
            BusinessBLL objWow = new BusinessBLL();
           
            if (emid.Length > 0)
            {
                Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!rEMail.IsMatch(emid))
                {
                    typevalue = "3";
                }
                else
                {
                    try
                    {
                        int countUser;
                        countUser = objWow.CheckUserNameandPasswordForVaildUser(emid, vertical, country);
                        if (countUser == 0)
                        {
                            typevalue = "1";
                        }
                        else
                        {
                            typevalue = "2";
                        }
                    }
                    catch
                    {
                        typevalue = "3";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AssociateLogin.aspx.cs", "ServerSidefill", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return typevalue;

    }

    private string GenerateRandomPassword()
    {
        string s = "";
        try
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //string alphabets = "012345678";
            StringBuilder randomText = new StringBuilder();
            Random r = new Random();
            for (int j = 0; j < 6; j++)
            {

                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }


            for (int i = 0; i < 10; i++)
                s = randomText.ToString();
        }
        catch (Exception ex)
        {
            
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AssociateLogin.aspx.cs", "GenerateRandomPassword", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return s;
    }

    public string SendregistrationEmail(string name, string email1, string password)
    {
        string emailInfo = "";
        string returnval = string.Empty;
        try
        {
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        emailInfo = row[1].ToString();
                }
            }
            string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
            StreamReader re = File.OpenText(strfilepath + "AssociateActivation.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }

            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR/>";
            }
            msgbody = msgbody.Replace("#RootUrl#", RootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Link#", "<a href='" + RootPath + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target=_new>Login</a>");
            msgbody = msgbody.Replace("#AddLink#", RootPath + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()));
            msgbody = msgbody.Replace("#Email#", email1);
            msgbody = msgbody.Replace("#Password#", password);
            re.Close();
            re.Dispose();
            string ccemail = string.Empty;
           
            USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
            returnval = utlobj.SendWowzzyEmail(emailInfo, email1, "Auto email for Associate Registration Details", msgbody, ccemail, "", DomainName);
            reDeclaimer.Close();
            reDeclaimer.Dispose();
        }
        catch (Exception ex)
        {
          
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AssociateLogin.aspx.cs", "SendregistrationEmail", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return returnval;
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                if (txtEmail.Text.Length > 0)
                {

                    Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    if (rEMail.IsMatch(txtEmail.Text))
                    {
                        if (txtPassword.Text.Trim() == txtConfirmPwd.Text.Trim())
                        {
                            if (associateID == 0)
                            {
                                int checkUser = objBus.CheckUserNameandPasswordForVaildUser(txtEmail.Text.Trim(), hdnVertical.Value, hdnCountry.Value);
                                if (checkUser == 0)
                                {
                                    string password = txtPassword.Text.Trim();
                                    int count = objConsumer.Insert_Update_AssociateLogin(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmail.Text.Trim(),
                                        EncryptDecrypt.DESEncrypt(txtPassword.Text.Trim()), USPDHUBBLL.UtilitiesBLL.Statuses.Active.ToString(), C_UserID, UserID, Convert.ToBoolean(chkIsSuperAdmin.Checked), 0);
                                    if (count > 0)
                                    {
                                        SendregistrationEmail(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim(), txtEmail.Text.Trim(), password);
                                        ScriptManager.RegisterClientScriptBlock(lnkSave, this.GetType(), "Alert", "<font color=green face=arial size=2><b>Associate details have been saved successfully. An email has been sent with username and password.</b></font>", true);
                                        if (chkIsSuperAdmin.Checked)
                                        {
                                            // Insert Permissions  
                                            InsertAssociatePermissions(count);
                                            Session["AssociateMsg"] = "<font color=green face=arial size=2><b>Associate details have been saved successfully. An email has been sent to <font color=red face=arial size=2>" + txtEmail.Text.Trim() + "</font> with username and password.</b></font>";
                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?page=" + gridPageIndex));
                                        }
                                        else
                                        {
                                            Session["AssociateMsg"] = "An email has been sent to <font color=red face=arial size=2>" + txtEmail.Text.Trim() + "</font> with username and password.";
                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/UserPermissionsNew.aspx?ID=" + EncryptDecrypt.DESEncrypt(count.ToString())));
                                        }
                                    }
                                }
                                else
                                {
                                    lblUserNameCheck.Text = "<font color=red face=arial size=2>This email address is already in use, please enter different email address.</font>";
                                }
                            }
                            else
                            {

                                string password = txtPassword.Text.Trim();
                                int count = objConsumer.Insert_Update_AssociateLogin(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmail.Text.Trim(),
                                        EncryptDecrypt.DESEncrypt(txtPassword.Text.Trim()), USPDHUBBLL.UtilitiesBLL.Statuses.Active.ToString(), C_UserID, UserID, Convert.ToBoolean(chkIsSuperAdmin.Checked), associateID);
                                if (count > 0)
                                {
                                    string associatemsg = "<font color=green face=arial size=2><b>Associate details have been updated successfully.";
                                    if (hdnPwd.Value.ToString() != password.ToString())
                                    {
                                        associatemsg += " An email has been sent to <font color=red face=arial size=2>" + txtEmail.Text.Trim() + "</font> with username and password.</b></font>";
                                        Session["AssociateMsg"] = associatemsg;
                                        SendregistrationEmail(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim(), txtEmail.Text.Trim(), password);
                                    }
                                    else
                                    {
                                        Session["AssociateMsg"] = associatemsg;
                                    }
                                    if (Convert.ToBoolean(hdnIsSuperAdmin.Value) == true && chkIsSuperAdmin.Checked == false)
                                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/UserPermissionsNew.aspx?ID=" + EncryptDecrypt.DESEncrypt(associateID.ToString()) + "&index=" + gridPageIndex));
                                    if (Convert.ToBoolean(hdnIsSuperAdmin.Value) == false && chkIsSuperAdmin.Checked)
                                        InsertAssociatePermissions(count);
                                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?page=" + gridPageIndex));
                                }
                            }
                        }
                        else
                        {
                            lblerror.Text = "<font color=red face=arial size=2>Confirm Password must match Password.</font>";
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }

    private void DeleteAssociatePermissions(int C_UserID)
    {
        string authorID = "0";
        string publisherID = "0";
        try
        {
            DataTable dtpermissions = agencyobj.GetPermissionsById(C_UserID);

            

            for (int i = 0; i < dtpermissions.Rows.Count; i++)
            {
                if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "A")  // "A" for author
                {
                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_ID"].ToString())))
                        authorID = dtpermissions.Rows[i]["Permission_ID"].ToString();
                }

                else if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "P")  // "P" for publisher
                {
                    if (!string.IsNullOrEmpty((dtpermissions.Rows[i]["Permission_ID"].ToString())))
                        publisherID = dtpermissions.Rows[i]["Permission_ID"].ToString();
                }
            }
        }
        catch (Exception ex)
        {

            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AssociateLogin.aspx.cs", "DeleteAssociatePermissions", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        //Delete Author Permissions
        agencyobj.DeletePermissions(Convert.ToInt32(authorID));

        //Delete Publisher Permissions
        agencyobj.DeletePermissions(Convert.ToInt32(publisherID));
    }

    private void InsertAssociatePermissions(int associateID)
    {
        string chkMessageAuthorText = "Manage Message Receipt";
        string chkPushAuthorText = "Push Notifications";
        string chkMButtonsAuthorText = "Manage Buttons";
        string chkASettingsAuthorText = "App Settings";
        string chkAuthorContactsText = "Contacts";
        string chkToolTipText = "Receive Feedback/Tips";
        string chkDownloadsText = "Downloads";
        try
        {

            DataTable dtPermissionsMsg = agencyobj.GetPermissionsByAssociateId(associateID);
            //Delete all records based on User before inserting.
            if (dtPermissionsMsg.Rows.Count > 0)
                agencyobj.DeletePermissionsByAssociate(associateID);

            DataTable dtCustomModules = objBus.DashboardIcons(UserID);
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
                    agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                        true, true, true, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), C_UserID);
                }
                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == "EventCalendar"))
                {
                    agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                        true, true, true, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), C_UserID);
                }
                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == "Surveys"))
                {
                    agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                        true, true, true, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), C_UserID);
                }
                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == WebConstants.Tab_ContentAddOns))
                {
                    agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                        true, true, true, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), C_UserID);
                }
                else if ((Convert.ToString(dtCustomModules.Rows[k]["ButtonType"]) == WebConstants.Tab_CalendarAddOns))
                {
                    agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, Convert.ToInt32(dtCustomModules.Rows[k]["UserModuleID"].ToString()),
                        true, true, true, associateID, dtCustomModules.Rows[k]["TabName"].ToString(), C_UserID);
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "AssociateLogin.aspx.cs", "InsertAssociatePermissions", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkMessageAuthorText, C_UserID);
        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkPushAuthorText, C_UserID);
        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkMButtonsAuthorText, C_UserID);
        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkASettingsAuthorText, C_UserID);
        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkAuthorContactsText, C_UserID);
        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkToolTipText, C_UserID);
        agencyobj.InsertUpdateUserPermissions(ProfileID, UserID, null, true, true, true, associateID, chkDownloadsText, C_UserID);
    }

    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx?page=" + gridPageIndex));
    }
}
