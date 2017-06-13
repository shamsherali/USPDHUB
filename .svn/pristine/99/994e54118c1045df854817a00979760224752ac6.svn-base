using System;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.Data.SqlClient;
using System.Web;

namespace USPDHUB.Business.MyAccount
{
    public partial class DesktopTipsManager : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CheckRenewalValue = 0;
        public string Tmpvarpath = string.Empty;
        public string Htprefval = string.Empty;
        public int Passwordchanged = 3;
        public string LoginCokValue = string.Empty;
        public string Urlinfo = string.Empty;
        BusinessBLL busobj = new BusinessBLL();
        Consumer conobj = new USPDHUBBLL.Consumer();
        AdminBLL adminobj = new AdminBLL();
        public bool Redirectflag = true;
        public string ProfileState = string.Empty;
        public string ChangeName = string.Empty;
        public string ProfileCity = string.Empty;
        public string ProfileStateCode = string.Empty;
        public string StateCode = string.Empty;
        public string ProfileCodeChek;
        public string NewSite = string.Empty;
        public string Browserses = string.Empty;
        public string Renew = string.Empty;
        DataTable dtobj = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        BusinessUpdatesBLL adminobjs = new BusinessUpdatesBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        EventCalendarBLL eventobj = new EventCalendarBLL();
        CommonBLL objCommon = new CommonBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public int Flag = 0;

        public string ErrorMessage = "";
        public string RootPath = "";
        public string DomainName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
                // *** Get Domain Name *** //
                RootPath = Session["RootPath"].ToString();
                DomainName = Session["VerticalDomain"].ToString();
                if (!IsPostBack)
                {
                    if (Request.QueryString["username"] != null)
                    {
                        CallfromClientSide();
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DesktopTipsManager.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string FormPosting()
        {
            string returnMessage = "SUCCESS";
            try
            {
                string username = string.Empty;
                string passcode = string.Empty;
                username = Request.QueryString["email"].ToString();
                passcode = Request.QueryString["pwd"].ToString();

                int roleID = 0;
                if (username == ConfigurationManager.AppSettings.Get("AdminUserID").ToString() && passcode == ConfigurationManager.AppSettings.Get("AdminPassword").ToString())
                {
                    //Check for userID  And password is it admin type..
                    ErrorMessage = "<font face=arial color=red size=2>Invalid login name & password, please try again </font>";

                }
                else
                {
                    Session["HelpCheck"] = "1";

                    dtobj = conobj.GetUserDetails(username, DomainName);
                    if (dtobj != null)
                    {
                        DataTable dtAssociate = new DataTable();
                        Session["C_USER_ID"] = null;
                        int associateId = 0;
                        if (dtobj.Rows.Count == 0)  //added by venkat
                        {
                            dtAssociate = conobj.GetAssociateUserDetails(username, DomainName);
                            if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                            {
                                Session["C_USER_ID"] = dtAssociate.Rows[0]["User_ID"].ToString();
                                associateId = Convert.ToInt32(dtAssociate.Rows[0]["User_ID"].ToString());
                                Session["C_USER_NAME"] = username.ToString();
                                Session["C_FIRST_NAME"] = dtAssociate.Rows[0]["Firstname"].ToString();
                                Session["C_LAST_NAME"] = dtAssociate.Rows[0]["Lastname"].ToString();
                                dtobj = conobj.GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                            }
                            else
                                Session["C_USER_NAME"] = Session["C_USER_ID"] = null;
                        } //Ends here...

                        if (dtobj.Rows.Count == 1)
                        {
                            if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                            {
                                int code = 1;
                                string passcod = string.Empty;
                                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") //added by venkat
                                {
                                    passcod = EncryptDecrypt.DESDecrypt(dtAssociate.Rows[0]["Password"].ToString());
                                    code = passcode.CompareTo(passcod.ToString());
                                }
                                else
                                {
                                    passcod = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                                    code = passcode.CompareTo(passcod.ToString());
                                }

                                if (code == 0)
                                {
                                    //Assign to Session variables 
                                    Session["UserID"] = dtobj.Rows[0]["User_ID"].ToString();
                                    UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                    Session["username"] = dtobj.Rows[0]["Username"].ToString(); //added by venkat
                                    Session["Name"] = dtobj.Rows[0]["firstname"].ToString();
                                    Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                                    roleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);

                                    #  region user tracking
                                    // user tracking 
                                    string date = string.Empty;
                                    string time = string.Empty;
                                    date = System.DateTime.Now.ToShortDateString();
                                    time = System.DateTime.Now.ToShortTimeString();
                                    string ipaddress = Request.Params["REMOTE_ADDR"].ToString();
                                    // *** Issue 1106 *** //
                                    string userLoginBrowser = Request.Browser.Browser.ToString();
                                    string userBrowserVer = Request.Browser.Version.ToString();

                                    if (Session["C_USER_ID"] == null)
                                        associateId = UserID;
                                    busobj.Usertracking(associateId, ipaddress, time, "", date, "", 1, userLoginBrowser, userBrowserVer);
                                    # endregion

                                    Urlinfo = RootPath;
                                    # region For Business User
                                    if (roleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                    {
                                        //Populate the profile details
                                        DataTable bustabobj = new DataTable();
                                        bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                                        if (bustabobj.Rows.Count == 0)
                                        {
                                            Redirectflag = false;
                                            Session["ProfileID"] = null;
                                            Session["UserID"] = null;
                                            Session["BusinessType"] = null;
                                            ErrorMessage = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                                        }
                                        else if (bustabobj.Rows.Count == 1)
                                        {
                                            // Get the ProfileID for further propogations         
                                            ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                            Session["UserID"] = UserID.ToString();
                                            Session["ProfileID"] = ProfileID.ToString();
                                            Session["Generaltab"] = "";
                                            Session["UserLogin"] = "1";
                                            Session["firstname"] = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.
                                            //Start get business type
                                            Session["BusinessType"] = "Agency";
                                            // End get business type
                                            // Get User Subscription Details
                                            DataTable dtSubscriptionDetails = new DataTable();
                                            dtSubscriptionDetails = busobj.Getorderidbyuserid(UserID);
                                            if (dtSubscriptionDetails.Rows.Count > 0)
                                            {
                                                DateTime renewalDate;
                                                renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                                if (renewalDate.Date > DateTime.Now.Date)
                                                {
                                                    //Start Check Password is changed or not at first time.
                                                    if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")  // added by venkat
                                                    {
                                                        DataTable dtobjforpasswprd = new DataTable();
                                                        dtobjforpasswprd = conobj.GetUserDetailsByID(UserID);
                                                        if (dtobjforpasswprd.Rows.Count > 0)
                                                        {
                                                            if (dtobjforpasswprd.Rows[0]["Password_Changed"].ToString().Length > 0)
                                                            {
                                                                Passwordchanged = Convert.ToInt32(dtobjforpasswprd.Rows[0]["Password_Changed"].ToString());
                                                                // Zeroindicates password is not changed by user, So we force to him for changing password.
                                                                if (Passwordchanged == 0)
                                                                {
                                                                    Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Changepassword.aspx?CPD=ActivateUser");
                                                                    //Response.Redirect(urlinfo);
                                                                }

                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Renew = "1";
                                                    GetFreeUserDetails();
                                                }
                                            }
                                            else
                                            {
                                                GetFreeUserDetails();
                                            }
                                        }
                                        else
                                        {
                                            Redirectflag = false;
                                        }
                                    }
                                    # endregion
                                    else
                                    {
                                        Redirectflag = false;
                                        ErrorMessage = "<font face=arial color=red size=2>Can not Recognize User. Please contact Customer support.</font>";
                                    }

                                    if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "") //roles & permissions
                                    {
                                        if (Request.QueryString["Type"] != null && Request.QueryString["Type"] != "")
                                        {
                                            if (Request.QueryString["PName"] != null && Request.QueryString["PName"] != "")
                                            {
                                                int count = 0;
                                                string pagename = EncryptDecrypt.DESDecrypt(Request.QueryString["PName"].ToString());
                                                Session["PageName"] = pagename;
                                                Session["Type"] = EncryptDecrypt.DESDecrypt(Request.QueryString["Type"].ToString());
                                                Session["BulletinID"] = EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString());
                                                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                                                {
                                                    DataTable dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"].ToString()));
                                                    if (dtpermissions.Rows.Count > 0)
                                                    {
                                                        if (Session["Type"].ToString() == PageNames.BULLETIN || Session["Type"].ToString() == PageNames.UPDATE || Session["Type"].ToString() == PageNames.EVENT)
                                                            count = GetDetails(dtpermissions);
                                                    }
                                                    else
                                                        count = count + 1;
                                                }
                                                if (count == 0)
                                                {
                                                    if (Session["Type"].ToString() == PageNames.BULLETIN)
                                                    {
                                                        if (pagename.ToLower().ToString() == PageNames.MPERSON)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/MissingPerson.aspx"));
                                                        else if (pagename.ToLower().ToString() == PageNames.SVEHICLE)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/MissingVehicle.aspx"));
                                                        else if (pagename.ToLower().ToString() == PageNames.CHMESSAGE)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ChiefsMessageForm.aspx"));
                                                        else if (pagename.ToLower().ToString() == PageNames.PACTIVITY)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/PoliceActivity.aspx"));
                                                        else if (pagename.ToLower().ToString() == PageNames.TALERT)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/TrafficAlert.aspx"));
                                                        else if (pagename.ToLower().ToString() == PageNames.SNOTIFICATION)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SchoolNotification.aspx"));
                                                        else if (pagename.ToLower().ToString() == PageNames.WANTED)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Wanted.aspx"));
                                                        else if (pagename.ToString() == PageNames.BULLETIN)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin.aspx?BulletinID=" + Session["BulletinID"].ToString()));
                                                        else
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ApproveAndRejectForms.aspx"));
                                                    }
                                                    else if (Session["Type"].ToString() == PageNames.UPDATE)
                                                    {
                                                        if (pagename.ToString() == PageNames.UPDATE)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + Session["BulletinID"].ToString()));
                                                        else
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ApproveAndRejectForms.aspx"));
                                                    }
                                                    else if (Session["Type"].ToString() == PageNames.EVENT)
                                                    {
                                                        if (pagename.ToString() == PageNames.EVENT)
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + Session["BulletinID"].ToString()));
                                                        else
                                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ApproveAndRejectForms.aspx"));
                                                    }
                                                    else
                                                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ApproveAndRejectForms.aspx"));
                                                }
                                                else
                                                {
                                                    ErrorMessage = "<font face=arial color=red size=2>You do not have permission to approve or reject event/update/bulletin.</font>";
                                                    Flag = 1;
                                                }
                                            }
                                        }
                                    }

                                    // ends here..

                                    //  if user user renewal date is greater than today date
                                    if (CheckRenewalValue == 0 && Flag == 0)
                                    {
                                        if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                        {
                                            Session["UserID"] = UserID.ToString();
                                            Session["ProfileID"] = ProfileID.ToString();
                                            Session["UserLogin"] = "1";
                                        }
                                    }
                                }
                                else
                                    ErrorMessage = "<font face=arial color=red size=2>Invalid password; please try again.</font>";
                            }
                            else
                            {
                                if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                {
                                    string activationCode = string.Empty;
                                    activationCode = busobj.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                                    if (activationCode != "")
                                    {
                                        ErrorMessage = "<font face=arial color=red size=2>Your account is not yet activated. Please check your email (<b style='color:Green'> " + dtobj.Rows[0]["username"].ToString() + "</b> ) to activate your account.";
                                    }
                                    else
                                    {
                                        int listingProfileID = 0;
                                        listingProfileID = busobj.GetProfileIDByUserID(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                                        if (listingProfileID > 0)
                                        {
                                            Session["ProfileID"] = null;
                                            Session["UserID"] = null;
                                            string encreID = EncryptDecrypt.DESEncrypt(listingProfileID.ToString());
                                        }
                                        else
                                        {
                                            Session["ProfileID"] = null;
                                            Session["UserID"] = null;
                                            ErrorMessage = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                                        }
                                    }
                                }
                            }
                        }
                        else
                            ErrorMessage = "<font face=arial color=red size=2>Invalid login name or password, please try again.</font>";
                    }
                    else
                    {
                        ErrorMessage = "<font face=arial color=red size=2>Invalid Login Name & Password</font>";
                    }

                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DesktopTipsManager.aspx.cs", "FormPosting", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnMessage;
        }

        private void CallfromClientSide()
        {
            try
            {
                string username = EncryptDecrypt.DESDecrypt(Request.QueryString["username"].ToString());
                string passcode = EncryptDecrypt.DESDecrypt(Request.QueryString["pwd"].ToString());
                int roleID = 0;

                dtobj = conobj.GetUserDetails(username, DomainName);
                if (dtobj != null)
                {
                    DataTable dtAssociate = new DataTable();
                    Session["C_USER_ID"] = null;
                    int associateId = 0;
                    if (dtobj.Rows.Count == 0)  //added by venkat
                    {
                        dtAssociate = conobj.GetAssociateUserDetails(username, DomainName);
                        if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                        {
                            Session["C_USER_ID"] = dtAssociate.Rows[0]["User_ID"].ToString();
                            associateId = Convert.ToInt32(dtAssociate.Rows[0]["User_ID"].ToString());
                            Session["C_USER_NAME"] = username.ToString();
                            Session["C_FIRST_NAME"] = dtAssociate.Rows[0]["Firstname"].ToString();
                            Session["C_LAST_NAME"] = dtAssociate.Rows[0]["Lastname"].ToString();
                            dtobj = conobj.GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                        }
                        else
                            Session["C_USER_NAME"] = Session["C_USER_ID"] = null;
                    } //Ends here...

                    if (dtobj.Rows.Count == 1)
                    {
                        if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                        {
                            int code = 1;
                            string passcod = string.Empty;
                            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") //added by venkat
                            {
                                passcod = EncryptDecrypt.DESDecrypt(dtAssociate.Rows[0]["Password"].ToString());
                                code = passcode.CompareTo(passcod.ToString());
                            }
                            else
                            {
                                passcod = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                                code = passcode.CompareTo(passcod.ToString());
                            }

                            if (code == 0)
                            {
                                //Assign to Session variables 
                                Session["UserID"] = dtobj.Rows[0]["User_ID"].ToString();
                                UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                if (associateId == 0)
                                    associateId = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                Session["username"] = dtobj.Rows[0]["Username"].ToString();
                                Session["Name"] = dtobj.Rows[0]["firstname"].ToString();
                                Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                                roleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);

                                #  region user tracking
                                // user tracking
                                string date = string.Empty;
                                string time = string.Empty;
                                date = System.DateTime.Now.ToShortDateString();
                                time = System.DateTime.Now.ToShortTimeString();
                                string ipaddress = Request.Params["REMOTE_ADDR"].ToString();
                                // *** Issue 1106 *** //
                                string userLoginBrowser = Request.Browser.Browser.ToString();
                                string userBrowserVer = Request.Browser.Version.ToString();
                                busobj.Usertracking(associateId, ipaddress, time, "", date, "", 1, userLoginBrowser, userBrowserVer);

                                # endregion

                                Urlinfo = RootPath;
                                # region For Business User
                                if (roleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                {
                                    //Populate the profile details
                                    DataTable bustabobj = new DataTable();
                                    bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                                    if (bustabobj.Rows.Count == 0)
                                    {
                                        Redirectflag = false;
                                        Session["ProfileID"] = null;
                                        Session["UserID"] = null;
                                        Session["BusinessType"] = null;
                                    }
                                    else if (bustabobj.Rows.Count == 1)
                                    {
                                        // Get the ProfileID for further propogations         
                                        ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                        Session["UserID"] = UserID.ToString();
                                        Session["ProfileID"] = ProfileID.ToString();
                                        Session["Generaltab"] = "";
                                        Session["UserLogin"] = "1";
                                        Session["firstname"] = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.
                                        //Start get business type
                                        Session["BusinessType"] = "Agency";
                                        // End get business type
                                        // Get User Subscription Details
                                        DataTable dtSubscriptionDetails = new DataTable();
                                        dtSubscriptionDetails = busobj.Getorderidbyuserid(UserID);
                                        if (dtSubscriptionDetails.Rows.Count > 0)
                                        {
                                            DateTime renewalDate;
                                            renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                            if (renewalDate.Date > DateTime.Now.Date)
                                            {
                                                //Start Check Password is changed or not at first time.
                                                if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")  // added by venkat
                                                {
                                                    DataTable dtobjforpasswprd = new DataTable();
                                                    dtobjforpasswprd = conobj.GetUserDetailsByID(UserID);
                                                    if (dtobjforpasswprd.Rows.Count > 0)
                                                    {
                                                        if (dtobjforpasswprd.Rows[0]["Password_Changed"].ToString().Length > 0)
                                                        {
                                                            Passwordchanged = Convert.ToInt32(dtobjforpasswprd.Rows[0]["Password_Changed"].ToString());
                                                            // Zeroindicates password is not changed by user, So we force to him for changing password.
                                                            if (Passwordchanged == 0)
                                                            {
                                                                Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Changepassword.aspx?CPD=ActivateUser");
                                                                Response.Redirect(Urlinfo);
                                                            }

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Renew = "1";
                                                GetFreeUserDetails();
                                            }
                                        }
                                        else
                                        {
                                            GetFreeUserDetails();
                                        }
                                    }
                                }
                                # endregion

                                //  if user user renewal date is greater than today date
                                if (CheckRenewalValue == 0 && Flag == 0)
                                {
                                    if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                    {
                                        Session["UserID"] = UserID.ToString();
                                        Session["ProfileID"] = ProfileID.ToString();
                                        Session["UserLogin"] = "1";
                                        string urlinforforroot = Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx");
                                        Response.Redirect(urlinforforroot);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DesktopTipsManager.aspx.cs", "CallfromClientSide", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetFreeUserDetails()
        {
            try
            {
                // Check For Free User
                string username = EncryptDecrypt.DESDecrypt(Request.QueryString["username"].ToString());
                dtobj = busobj.GetUserDetailsByUserID(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
                    {
                        Session["Free"] = "1";
                    }
                    if (Renew == "1")
                    {
                        Session["Free"] = "1";
                        Session["Renewal"] = "1";
                    }
                    if (dtobj.Rows[0]["Password_Changed"].ToString() != "")
                    {
                        Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx");
                        Response.Redirect(Urlinfo);
                    }
                    else
                    {
                        Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Changepassword.aspx?CPD=ActivateUser");
                        Response.Redirect(Urlinfo);
                    }
                }
                CheckRenewalValue = 1;
                int listingProfileID = 0;
                listingProfileID = busobj.GetProfileIDByUserID(UserID);
                if (listingProfileID > 0)
                {
                    string encreID = EncryptDecrypt.DESEncrypt(listingProfileID.ToString());
                    Session["ProfileID"] = null;
                    Session["UserID"] = null;
                }
                else
                {
                    Session["ProfileID"] = null;
                    Session["UserID"] = null;
                    ErrorMessage = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DesktopTipsManager.aspx.cs", "GetFreeUserDetails", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private int GetDetails(DataTable dtpermissions)
        {
            int returnval = 0;
            try
            {
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "P")
                    {
                        int permissionValue = Convert.ToInt32(dtpermissions.Rows[i]["Permission_Values"].ToString());
                        if (Convert.ToBoolean(permissionValue & Constants.BULLETINS) && Session["Type"].ToString() == PageNames.BULLETIN)
                            returnval = 0;
                        else if (Convert.ToBoolean(permissionValue & Constants.UPDATES) && Session["Type"].ToString() == PageNames.UPDATE)
                            returnval = 0;
                        else if (Convert.ToBoolean(permissionValue & Constants.EVENTS) && Session["Type"].ToString() == PageNames.EVENT)
                            returnval = 0;
                        else
                            returnval = returnval + 1;
                    }
                    else
                        returnval = returnval + 1;
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DesktopTipsManager.aspx.cs", "GetDetails", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnval;
        }
    }
}