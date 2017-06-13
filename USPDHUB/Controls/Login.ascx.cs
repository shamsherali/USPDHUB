using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Data.SqlClient;


public partial class Controls_Login : System.Web.UI.UserControl
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
    CommonBLL objCommon = new CommonBLL();
    BusinessUpdatesBLL adminobjs = new BusinessUpdatesBLL();
    BulletinBLL objBulletin = new BulletinBLL();
    EventCalendarBLL eventobj = new EventCalendarBLL();
    public int Flag = 0;
    public string DomainName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // *** Isssue 1390 *** //
        Label lblParent = (Label)Parent.FindControl("lblError");
        lblParent.Text = "";
        // *** Start to read the Cookie for the username to prepapulate ***
        HttpCookie myCookie = new HttpCookie("wowzzyUserID");
        myCookie = Request.Cookies["wowzzyUserID"];
        if (myCookie != null)
        {
            if (email.Text.Length > 0)
            {
                LoginCokValue = email.Text;
            }
            else
            {
                email.Text = myCookie.Values["email"];
                // password.Attributes.Add("value", EncryptDecrypt.DESDecrypt(myCookie.Values["password"]));
                password.Attributes.Add("value", myCookie.Values["password"]);
            }
        }
        if (Session["VerticalDomain"] == null)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            objCommon.CreateDomainUrl(url);
        }
        DomainName = Session["VerticalDomain"].ToString();
        // End of the Cookie reading logic
        if (!IsPostBack)
        {
            Session["Free"] = null;
            Session["Renewal"] = null;
            Session["Tools"] = null;
            Session["PackageSubscriptions"] = null;
            // *** when user click on  Member Login link in the Email: Registration , Change Password and Forgot password ***

            if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "") //roles & permissions
            {
                Session.Abandon();
                Session.Clear();
            }

            if (Request.QueryString["UID"] != null)
            {
                UserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["UID"].ToString()));
                DataTable dtuserdetails = new DataTable();
                dtuserdetails = busobj.GetUserDtlsByUserID(UserID);
                if (dtuserdetails.Rows.Count > 0)
                {
                    string username = dtuserdetails.Rows[0]["Username"].ToString();
                    email.Text = username;
                }
                if (Request.QueryString["flag"] != null && Request.QueryString["flag"] != "")
                {
                    if (Request.QueryString["flag"] == "1")
                    {
                        password.Attributes.Add("value", EncryptDecrypt.DESDecrypt(dtuserdetails.Rows[0]["password"].ToString()));
                        login(EncryptDecrypt.DESDecrypt(dtuserdetails.Rows[0]["password"].ToString()));
                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                    }
                }
            }

            if (Request.QueryString["ID"] == null)
            {
                //Check this user is already login.. If so... continue the corresponding page....
                Tmpvarpath = Request.Url.ToString();
                # region user logged or not

                if (Session["UserID"] != null)
                {
                    if (Session["ProfileID"] == null)
                    {
                        Session["UserID"] = null;
                        Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                    }
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    Urlinfo = Session["RootPath"].ToString();
                    if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                    {
                        //Populate the profile details
                        DataTable bustabobj = new DataTable();
                        bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                        if (bustabobj.Rows.Count == 0)
                        {
                            Redirectflag = false;
                            if (Session["UserID"] == null)
                            {
                                lblmsg.Text = "<font face=arial color=red size=2> Your previous registration attempt was incomplete, please <a href='ClearBusinessAccount.aspx?userid=" + UserID + "'>click here</a> to begin a new registration process.";
                            }
                        }
                        else if (bustabobj.Rows.Count == 1)
                        {
                            // Get the ProfileID for further propogations
                            ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                            Session["ProfileID"] = ProfileID;
                            Session["UserLogin"] = "1";
                            Urlinfo = Urlinfo + "/Business/MyAccount/Default.aspx";
                        }
                        else
                        {
                            lblmsg.Text = "<font face=arial color=red size=2>This User has multiple Profiles Exists. Please contact customer support (support@uspdhub.com). </font>";
                        }
                    }
                    else
                    {
                        Redirectflag = false;
                    }
                    if (Redirectflag)
                    {


                        // Previous url came from the Forums please redirect this user to forums back.
                        if (Htprefval.Contains("/Forum/") == true)
                        {
                            String retval = Page.ResolveClientUrl("~" + Htprefval);
                            Response.Redirect(retval);
                        }
                        else
                        {
                            Response.Redirect(Urlinfo);
                        }
                    }
                }
                #endregion
            }
            email.Focus();
        }
    }
    # region For Different User login
    //  Different user login
    protected void lnkDifferentUser_Click(object sender, EventArgs e)
    {

        HttpCookie HttpCookieobj = new HttpCookie("wowzzyUserId");
        HttpCookieobj = Request.Cookies["wowzzyUserID"];
        if (HttpCookieobj != null)
        {
            if (HttpCookieobj.Values["email"] != string.Empty || HttpCookieobj.Values["password"] != string.Empty)
            {
                HttpCookieobj.Values["email"] = string.Empty;
                HttpCookieobj.Values["password"] = string.Empty;
                HttpCookieobj.Expires = DateTime.Now;
                Response.Cookies.Add(HttpCookieobj);
                email.Text = "";
                password.Text = "";
                HttpContext.Current.Response.Cookies.Set(HttpCookieobj);
                Urlinfo = Page.ResolveClientUrl("~");
                Response.Redirect(Urlinfo + "login.aspx");
                HttpCookieCollection objcoll = new HttpCookieCollection();
                objcoll.Clear();
            }
        }
        else
        {
            email.Text = "";
            password.Text = "";
            lblmsg.Text = "";
        }
    }
    # endregion

    # region for user login
    //user normal login
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string username = string.Empty;
        string passcode = string.Empty;
        username = email.Text;
        passcode = password.Text;
        int roleID = 0;
        if (username == ConfigurationManager.AppSettings.Get("AdminUserID").ToString() && passcode == ConfigurationManager.AppSettings.Get("AdminPassword").ToString())
        {
            //Check for userID  And password is it admin type..
            lblmsg.Text = "<font face=arial color=red size=2>Invalid login name & password, please try again </font>";

        }
        else
        {
            Session["HelpCheck"] = "1";
            bool IsSameDomain = true;
            int countUser;
            countUser = busobj.CheckUserNameandDomainForUpgradeUser(username, DomainName, "");
            if (countUser > 0)
            {
                IsSameDomain = false;

                int loginMemberID = countUser;
                string domain = "";
                domain = objCommon.GetDomainNameByCountry(loginMemberID);
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                string userRootpath = "";
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                        {
                            userRootpath = row[1].ToString();
                            break;
                        }
                    }
                }

                string urlinforforroot = userRootpath + "/login.aspx?UID=" + EncryptDecrypt.DESEncrypt(loginMemberID.ToString()) + "&flag=1";
                Response.Redirect(urlinforforroot);
            }


            dtobj = conobj.GetUserDetails(username, DomainName);
            if (dtobj != null)
            {
                DataTable dtAssociate = new DataTable();
                Session["C_USER_ID"] = null;
                int associateId = 0;
                if (dtobj.Rows.Count == 0)
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
                        //Populate the profile details
                        DataTable bustabobj = new DataTable();
                        bustabobj = busobj.GetBusinessProfileByUserID(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                        if (bustabobj.Rows.Count == 1)
                        {
                            string domainVertical = "";
                            domainVertical = objCommon.GetDomainNameByCountryVertical(bustabobj.Rows[0]["Vertical_Name"].ToString(), bustabobj.Rows[0]["Profile_County"].ToString());
                            if (Session["VerticalDomain"].ToString() == domainVertical)
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

                                if (code == 0) //added by venkat
                                {
                                    // Save the username in Cookie
                                    if (wowzzyID.Checked)
                                    {
                                        HttpCookie cookie = new HttpCookie("wowzzyID");
                                        cookie.Name = "wowzzyUserID";
                                        cookie.Values["email"] = email.Text;
                                        cookie.Values["password"] = passcode;
                                        cookie.Expires = DateTime.Now.AddDays(15);
                                        Response.Cookies.Add(cookie);

                                    }

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

                                    Urlinfo = Session["RootPath"].ToString();
                                    # region For Business User
                                    if (roleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                    {
                                        // Get the ProfileID for further propogations         
                                        ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                        Session["UserID"] = UserID.ToString();
                                        Session["UserLogin"] = "1";
                                        Session["ProfileID"] = ProfileID.ToString();
                                        Session["Generaltab"] = "";
                                        Session["firstname"] = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.
                                        //Start get business type
                                        Session["BusinessType"] = "Agency";
                                        // End get business type
                                        // Get User Subscription Details
                                        DataTable DtSubscriptionDetails = new DataTable();
                                        DtSubscriptionDetails = busobj.Getorderidbyuserid(UserID);
                                        if (DtSubscriptionDetails.Rows.Count > 0)
                                        {
                                            DateTime RenewalDate;
                                            string OrderID = string.Empty;
                                            OrderID = DtSubscriptionDetails.Rows[0]["order_id"].ToString();
                                            RenewalDate = Convert.ToDateTime(DtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                            if (RenewalDate.Date > DateTime.Now.Date)
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
                                                Response.Redirect(Urlinfo + "/Business/MyAccount/Default.aspx");
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
                                    # endregion
                                    else if (roleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Consumer)
                                    {
                                        lblmsg.Text = "<font face='arial' color='red' size='2'>Invalid login name. Please check your login name.</font>";
                                    }
                                    else
                                    {
                                        lblmsg.Text = "<font face=arial color=red size=2>Can not Recognize User. Please contact Customer support.</font>";
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
                                                    lblmsg.Text = "<font face=arial color=red size=2>You do not have permission to approve or reject event/update/bulletin.</font>";
                                                    Flag = 1;
                                                }
                                            }
                                        }
                                    }
                                    // ends here..
                                }
                                else
                                    lblmsg.Text = "<font face=arial color=red size=2>Invalid password; please try again.</font>";
                            }
                            else
                                lblmsg.Text = "<font face=arial color=red size=2>Invalid login name or password, please try again.</font>";
                        }
                        else
                        {
                            lblmsg.Text = "<font face=arial color=red size=2>This User has multiple Profiles Exists. Please contact customer support. </font>";
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                        {
                            string activationCode = string.Empty;
                            activationCode = busobj.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                            if (activationCode != "")
                            {
                                lblmsg.Text = "<font face=arial color=red size=2> Your account is not yet activated. Please check your email (<b style='color:Green'> " + dtobj.Rows[0]["username"].ToString() + "</b> ) to activate your USPDhub<sup style=\"font-size:12px;\">&reg;</sup> Account.";
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
                                    lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='" + System.Configuration.ConfigurationManager.AppSettings.Get("SecurePath") + "/Enhance.aspx?SPID=" + encreID + "'>click here</a> to complete your Registration.";
                                }
                                else
                                {
                                    Session["ProfileID"] = null;
                                    Session["UserID"] = null;
                                    lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                                }
                            }
                        }
                        else
                        {
                            lblmsg.Text = "<font face='arial' color='red' size='2'>Invalid login name. Please check your login name.</font>";
                        }
                    }
                }
                else
                    lblmsg.Text = "<font face=arial color=red size=2>Invalid login name or password, please try again.</font>";
            }
            else
            {
                lblmsg.Text = "<font face=arial color=red size=2>Invalid Login Name & Password</font>";
            }

        }//Admin If-Else close
    }
    # endregion
    private void CreateWebSite()
    {
        DataTable DtProfileDetails = new DataTable();
        DtProfileDetails = busobj.GetProfileDetailsByProfileID(ProfileID);
        ProfileState = DtProfileDetails.Rows[0]["Profile_State"].ToString();
        ProfileCity = DtProfileDetails.Rows[0]["Profile_City"].ToString();
        StateCode = busobj.GetStateCodeForStateName(ProfileState);
        Session["StateCode"] = StateCode;

    }
    private void GenerateWebSite(string NewSite)
    {
        string UrlInfo = Page.ResolveClientUrl("~/Profiles/Default.aspx?PID=" + ProfileID);
        StringBuilder strWebSite = new StringBuilder();
        strWebSite.Append("<%@ Page Language='C#' %>");
        strWebSite.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
        strWebSite.Append("<script language='C#' runat='server'>");
        strWebSite.Append("protected void Page_Load(object sender, EventArgs e)");
        strWebSite.Append("{");
        strWebSite.Append("Response.Redirect(\"" + UrlInfo + "\");");
        strWebSite.Append("}");
        strWebSite.Append("</script>");
        strWebSite.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
        strWebSite.Append("<head runat='server'></head>");
        strWebSite.Append("<body>");
        strWebSite.Append("<form id='form1' runat='server'>");
        strWebSite.Append("<div>");
        strWebSite.Append("</div>");
        strWebSite.Append("</form>");
        strWebSite.Append("</body>");
        strWebSite.Append("</html>");
        string hmtlfileurl = NewSite + "\\Default.aspx";
        StreamWriter textwriter = new StreamWriter(hmtlfileurl);
        textwriter.Write(strWebSite);
        textwriter.Close();
    }
    private void GetFreeUserDetails()
    {
        // Check For Free User
        string username = email.Text;
        dtobj = busobj.GetUserDetailsByUserID(UserID);
        if (dtobj.Rows.Count > 0)
        {
            if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
            {
                Session["Free"] = "1";
            }
            if (Renew == "1")
                Session["Renewal"] = "1";
            if (dtobj.Rows[0]["Password_Changed"].ToString() != "")
            {
                Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
                Response.Redirect(Urlinfo);
            }
            else
            {
                Urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Changepassword.aspx?CPD=ActivateUser");
                Response.Redirect(Urlinfo);
            }
        }
        CheckRenewalValue = 1;
        int ListingProfileID = 0;
        ListingProfileID = busobj.GetProfileIDByUserID(UserID);
        if (ListingProfileID > 0)
        {
            string encreID = EncryptDecrypt.DESEncrypt(ListingProfileID.ToString());
            Session["ProfileID"] = null;
            Session["UserID"] = null;
            lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='" + System.Configuration.ConfigurationManager.AppSettings.Get("SecurePath") + "/Enhance.aspx?SPID=" + encreID + "'>click here</a> to complete your Registration.";
        }
        else
        {
            Session["ProfileID"] = null;
            Session["UserID"] = null;
            lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
        }
    }

    private void login(string password)
    {
        string username = string.Empty;
        string passcode = string.Empty;
        username = email.Text;
        passcode = password;
        int RoleID = 0;
        if (username == ConfigurationManager.AppSettings.Get("AdminUserID").ToString() && passcode == ConfigurationManager.AppSettings.Get("AdminPassword").ToString())
        {
            //Check for userID  And password is it admin type..
            lblmsg.Text = "<font face=arial color=red size=2>Invalid login name & password, please try again </font>";

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

                        if (code == 0) //added by venkat
                        {
                            // Save the username in Cookie
                            if (wowzzyID.Checked)
                            {
                                HttpCookie cookie = new HttpCookie("wowzzyID");
                                cookie.Name = "wowzzyUserID";
                                cookie.Values["email"] = email.Text;
                                cookie.Values["password"] = passcode;
                                cookie.Expires = DateTime.Now.AddDays(15);
                                Response.Cookies.Add(cookie);
                            }

                            //Assign to Session variables 
                            Session["UserID"] = dtobj.Rows[0]["User_ID"].ToString();
                            UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                            if (associateId == 0)
                                associateId = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                            Session["username"] = dtobj.Rows[0]["Username"].ToString(); //added by venkat
                            Session["Name"] = dtobj.Rows[0]["firstname"].ToString();
                            Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                            RoleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);

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
                            if (Request.QueryString["al"] == null)
                                busobj.Usertracking(associateId, ipaddress, time, "", date, "", 1, userLoginBrowser, userBrowserVer);

                            # endregion

                            Urlinfo = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath");
                            # region For Business User
                            if (RoleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                            {
                                //Populate the profile details
                                DataTable bustabobj = new DataTable();
                                bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                                if (bustabobj.Rows.Count == 0)
                                {
                                    Session["ProfileID"] = null;
                                    Session["UserID"] = null;
                                    Session["BusinessType"] = null;
                                    lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                                }
                                else if (bustabobj.Rows.Count == 1)
                                {
                                    // Get the ProfileID for further propogations         
                                    ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                    Session["ProfileID"] = ProfileID.ToString();
                                    Session["Generaltab"] = "";
                                    Session["UserLogin"] = "1";
                                    Session["firstname"] = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.
                                    //Start get business type
                                    Session["BusinessType"] = "Agency";
                                    // End get business type
                                    // Get User Subscription Details
                                    DataTable DtSubscriptionDetails = new DataTable();
                                    DtSubscriptionDetails = busobj.Getorderidbyuserid(UserID);
                                    if (DtSubscriptionDetails.Rows.Count > 0)
                                    {
                                        DateTime RenewalDate;
                                        string OrderID = string.Empty;
                                        OrderID = DtSubscriptionDetails.Rows[0]["order_id"].ToString();
                                        RenewalDate = Convert.ToDateTime(DtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                        if (RenewalDate.Date > DateTime.Now.Date)
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
                                            Urlinfo = Urlinfo + "/Business/MyAccount/Default.aspx";
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
                                    lblmsg.Text = "<font face=arial color=red size=2>This User has multiple Profiles Exists. Please contact customer support (support@uspdhub.com). </font>";
                                }
                            }
                            # endregion
                            else
                            {
                                lblmsg.Text = "<font face=arial color=red size=2>Can not Recognize User. Please contact Customer support.</font>";
                            }
                            //  if user user renewal date is greater than today date
                            if (CheckRenewalValue == 0)
                            {
                                if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                {
                                    Session["UserID"] = UserID.ToString();
                                    Session["ProfileID"] = ProfileID.ToString();
                                    Session["UserLogin"] = "1";
                                    string urlinforforroot = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
                                    Response.Redirect(urlinforforroot);
                                }
                            }
                        }
                        else
                            lblmsg.Text = "<font face=arial color=red size=2>Invalid password; please try again.</font>";
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                        {
                            string activationCode = string.Empty;
                            activationCode = busobj.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                            if (activationCode != "")
                            {
                                lblmsg.Text = "<font face=arial color=red size=2> Your account is not yet activated. Please check your email (<b style='color:Green'> " + dtobj.Rows[0]["username"].ToString() + "</b> ) to activate your USPDhub<sup style=\"font-size:12px;\">&reg;</sup> Account.";
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
                                    lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='" + System.Configuration.ConfigurationManager.AppSettings.Get("SecurePath") + "/Enhance.aspx?SPID=" + encreID + "'>click here</a> to complete your Registration.";
                                }
                                else
                                {
                                    Session["ProfileID"] = null;
                                    Session["UserID"] = null;
                                    lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                                }
                            }
                        }
                        else
                        {
                            lblmsg.Text = "<font face='arial' color='red' size='2'>Invalid login name. Please check your login name.</font>";
                        }
                    }
                }
                else
                    lblmsg.Text = "<font face=arial color=red size=2>Invalid login name or password, please try again </font>";
            }
            else
            {
                lblmsg.Text = "<font face=arial color=red size=2>Invalid Login Name & Password</font>";
            }

        }//Admin If-Else close
    }

    private int GetDetails(DataTable dtpermissions)
    {
        int returnval = 0;
        for (int i = 0; i < dtpermissions.Rows.Count; i++)
        {
            if (dtpermissions.Rows[i]["Permission_Type"].ToString() == "P")
            {
                int Permission_Value = Convert.ToInt32(dtpermissions.Rows[i]["Permission_Values"].ToString());
                if (Convert.ToBoolean(Permission_Value & Constants.BULLETINS) && Session["Type"].ToString() == PageNames.BULLETIN)
                    returnval = 0;
                else if (Convert.ToBoolean(Permission_Value & Constants.UPDATES) && Session["Type"].ToString() == PageNames.UPDATE)
                    returnval = 0;
                else if (Convert.ToBoolean(Permission_Value & Constants.EVENTS) && Session["Type"].ToString() == PageNames.EVENT)
                    returnval = 0;
                else
                    returnval = returnval + 1;
            }
            else
                returnval = returnval + 1;
        }
        return returnval;
    }
}
