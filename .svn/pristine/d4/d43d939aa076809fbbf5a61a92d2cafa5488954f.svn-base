using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.IO;

namespace USPDHubClientLogin
{
    public partial class Login : Form
    {
        DataTable dtobj = new DataTable();

        public int UserID;
        public string username;
        public string Name;
        public string RoleID;
        public string urlinfo;


        public int ProfileID;
        public string BusinessType;
        public string ganeraltb;
        public string firstname;

        public string C_USER_ID;
        public string C_USER_NAME;
        public string C_FIRST_NAME;
        public string C_LAST_NAME;

        public int CheckRenewalValue;
        public string Renew;
        public int flag = 0;

        public string Generaltab;

        public int passwordchanged;

        public string Free = "";
        public string Renewal = "";

        public string HelpCheck = "";



        string ClientServicURL = ConfigurationManager.AppSettings.Get("ClientServiceURL");
        ClientService.ClientServiceSoapClient objService = new ClientService.ClientServiceSoapClient();

        string countryVertival = ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString();

        public string UserName { get; set; }
        public string Password { get; set; }

        ContextMenu contextMenu1;

        public int i = 0;

        Thread st;

        public Login()
        {
            InitializeComponent();
            //objService.Endpoint.Address = new System.ServiceModel.EndpointAddress(ClientServicURL);

            contextMenu1 = new System.Windows.Forms.ContextMenu();
            //Context Menu
            MenuItem exitMenu = new MenuItem();
            exitMenu.Text = "Exit";
            exitMenu.Click += new EventHandler(exitMenu_Click);
            contextMenu1.MenuItems.Add(exitMenu);

            notifyIcon1.ContextMenu = contextMenu1;
            Load += new EventHandler(Form1_Load);



        }


        void exitMenu_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Close();
            Application.Exit();
            Application.ExitThread();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                string iconPath = "icons\\" + countryVertival + "\\shortcuturl.ico";
                iconPath = Path.GetFullPath(iconPath);
                //E:\USPDHub\USPDHub\USPDShortcutURL\USPDHubClientLogin\bin\Debug\twoviecom\shortcuturl.ico
                if (iconPath.ToLower().Contains("bin\\debug"))
                {
                    iconPath = iconPath.ToLower().Replace("\\bin\\debug", "");
                }
                if (iconPath.ToLower().Contains("bin\\release"))
                {
                    iconPath = iconPath.ToLower().Replace("\\bin\\release", "");
                }
                System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
                this.Icon = ico;

                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;

                notifyIcon1.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("NotifyIconTitle"));
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = ico;

                if (Properties.Settings.Default.UserName.Trim() != "")
                {
                    UserName = Properties.Settings.Default.UserName;
                    Password = EncryptDecrypt.DESDecrypt(Properties.Settings.Default.Password.ToString());

                    txtUsername.Text = UserName;
                    txtPassword.Text = Password;
                    chkRememberme.Checked = true;

                    LoginChecking(UserName.Trim(), Password.Trim());

                    this.Hide();
                    notifyIcon1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "Login.cs", "Form1_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Desktop ShortCut");
            }
        }

        private void LoginChecking(string username, string passcode)
        {
            int RoleID = 0;

            if (username == ConfigurationManager.AppSettings.Get("AdminUserID").ToString() && passcode == ConfigurationManager.AppSettings.Get("AdminPassword").ToString())
            {
                //Check for userID  And password is it admin type..
                lblErrorMessage.Text = "Invalid login name & password, please try again";

            }
            else
            {
                HelpCheck = "1";

                dtobj = objService.GetUserDetails(username, ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString());
                if (dtobj != null)
                {
                    /*** Start Checking with Associate Logins ***/
                    DataTable dtAssociate = new DataTable();
                    C_USER_ID = "";

                    int associateId = 0;
                    if (dtobj.Rows.Count == 0)
                    {
                        dtAssociate = objService.GetAssociateUserDetails(username, countryVertival);
                        if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                        {
                            C_USER_ID = dtAssociate.Rows[0]["User_ID"].ToString();
                            associateId = Convert.ToInt32(dtAssociate.Rows[0]["User_ID"].ToString());
                            dtobj = objService.GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                        }
                        else
                            C_USER_ID = "";
                    } /*** END Checking with Associate Logins ***/


                    if (dtobj.Rows.Count == 1)
                    {
                        if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                        {
                            //Populate the profile details
                            DataTable bustabobj = new DataTable();
                            bustabobj = objService.GetBusinessProfileByUserID(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                            if (bustabobj.Rows.Count == 1)
                            {
                                string domainVertical = "";
                                domainVertical = objService.GetDomainNameByCountryVertical(bustabobj.Rows[0]["Vertical_Name"].ToString(), bustabobj.Rows[0]["Profile_County"].ToString());
                                if (countryVertival == domainVertical)
                                {
                                    int code = 1;
                                    string passcod = string.Empty;
                                    if (C_USER_ID != string.Empty)  
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
                                        bool redirectflag = true;
                                        //Assign to Session variables 
                                        UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                        username = dtobj.Rows[0]["Username"].ToString();
                                        Name = dtobj.Rows[0]["firstname"].ToString();
                                        RoleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);


                                        urlinfo = ConfigurationManager.AppSettings.Get("SRootPath");
                                        # region For Business User
                                        if (RoleID == (int)RoleTypes.Business)
                                        {
                                            if (bustabobj.Rows.Count == 0)
                                            {
                                                redirectflag = false;
                                                ProfileID = 0;
                                                UserID = 0;
                                                BusinessType = null;


                                                lblErrorMessage.Text = "Your Account Registration is incomplete. Please click here to start new Registration...!";
                                            }
                                            else if (bustabobj.Rows.Count == 1)
                                            {
                                                // Get the ProfileID for further propogations         
                                                ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                                //UserID = UserID;
                                                //ProfileID = ProfileID;
                                                Generaltab = "";
                                                firstname = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.
                                                //Start get business type
                                                BusinessType = "Agency";
                                                // End get business type
                                                // Get User Subscription Details
                                                DataTable DtSubscriptionDetails = new DataTable();
                                                DtSubscriptionDetails = objService.Getorderidbyuserid(UserID);
                                                if (DtSubscriptionDetails.Rows.Count > 0)
                                                {
                                                    DateTime RenewalDate;
                                                    string OrderID = string.Empty;
                                                    OrderID = DtSubscriptionDetails.Rows[0]["order_id"].ToString();
                                                    RenewalDate = Convert.ToDateTime(DtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                                    if (RenewalDate.Date > DateTime.Now.Date)
                                                    {
                                                        //Start Check Password is changed or not at first time.
                                                        if (C_USER_ID == null || C_USER_ID.ToString() == "")
                                                        {
                                                            DataTable dtobjforpasswprd = new DataTable();
                                                            dtobjforpasswprd = objService.GetUserDetailsByID(UserID);
                                                            if (dtobjforpasswprd.Rows.Count > 0)
                                                            {
                                                                if (dtobjforpasswprd.Rows[0]["Password_Changed"].ToString().Length > 0)
                                                                {
                                                                    passwordchanged = Convert.ToInt32(dtobjforpasswprd.Rows[0]["Password_Changed"].ToString());
                                                                    // Zeroindicates password is not changed by user, So we force to him for changing password.
                                                                    if (passwordchanged == 0)
                                                                    {
                                                                        OpenWebsiteBrowser();
                                                                    }

                                                                }
                                                            }
                                                        }
                                                        urlinfo = urlinfo + "/Business/MyAccount/Default.aspx";
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
                                                redirectflag = false;


                                                lblErrorMessage.Text = "This User has multiple Profiles Exists. Please contact customer support (support@uspdhub.com).";
                                            }
                                        }
                                        # endregion
                                        else if (RoleID == (int)RoleTypes.Consumer)
                                        {

                                            lblErrorMessage.Text = "Hurry, Now USPDhub offering FOREVER FREE LISTING, Please click here to start new Registration...!";
                                        }
                                        else
                                        {

                                            redirectflag = false;
                                            lblErrorMessage.Text = "Can not Recognize User. Please contact Customer support.";
                                        }
                                        // ends here..

                                        //  if user user renewal date is greater than today date
                                        if (CheckRenewalValue == 0 && flag == 0)
                                        {
                                            if (Convert.ToInt32(RoleID) == (int)RoleTypes.Business)
                                            {
                                                OpenWebsiteBrowser();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblErrorMessage.Text = "Invalid password; please try again.";
                                    }
                                }
                                else
                                    lblErrorMessage.Text = "<font face=arial color=red size=2>Invalid login name or password, please try again.</font>";
                            }
                            else
                            {
                                lblErrorMessage.Text = "<font face=arial color=red size=2>This User has multiple Profiles Exists. Please contact customer support. </font>";
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(RoleID) == (int)RoleTypes.Business)
                            {
                                string ActivationCode = string.Empty;
                                ActivationCode = objService.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                                if (ActivationCode != "")
                                {

                                    lblErrorMessage.Text = "Your account is not yet activated. Please check your email (" + dtobj.Rows[0]["username"].ToString() + ") to activate your USPDhub Account.";
                                }
                                else
                                {
                                    int ListingProfileID = 0;
                                    ListingProfileID = objService.GetProfileIDByUserID(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                                    if (ListingProfileID > 0)
                                    {
                                        ProfileID = 0;
                                        UserID = 0;
                                        string encreID = EncryptDecrypt.DESEncrypt(ListingProfileID.ToString());

                                        lblErrorMessage.Text = "Your Account Registration is incomplete. Please click here to complete your Registration.";
                                    }
                                    else
                                    {
                                        ProfileID = 0;
                                        UserID = 0;

                                        lblErrorMessage.Text = "Your Account Registration is incomplete. Please click here to start new Registration...!";
                                    }
                                }
                            }
                            else
                            {

                                lblErrorMessage.Text = "Hurry, Now USPDhub offering FOREVER FREE LISTING, Please click here to start new Registration...!";
                            }
                        }
                    }
                    else
                    {

                        lblErrorMessage.Text = "Invalid login name or password, please try again.";
                    }
                }
                else
                {

                    lblErrorMessage.Text = "Invalid Login Name & Password";
                }

            }//Admin If-Else close
        }

        private void OpenWebsiteBrowser()
        {
            #region remember me
            try
            {
                if (chkRememberme.Checked)
                {
                    Properties.Settings.Default.UserName = txtUsername.Text.Trim();
                    Properties.Settings.Default.Password = EncryptDecrypt.DESEncrypt(txtPassword.Text.Trim());
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "Login.cs", "OpenWebsiteBrowser", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Desktop ShortCut");
            }
            #endregion


            string rootPath = objService.GetConfigSettingByPID(ProfileID.ToString(), "Paths", "RootPath");

            urlinfo = rootPath + "/Business/MyAccount/DesktopLogin.aspx?username=" + EncryptDecrypt.DESEncrypt(UserName) + "&pwd=" + EncryptDecrypt.DESEncrypt(Password);
            System.Diagnostics.Process.Start(urlinfo);

            this.Close();

        }

        private void GetFreeUserDetails()
        {
            // Check For Free User
            string username = txtUsername.Text.Trim();
            dtobj = objService.GetUserDetailsByUserID(UserID);
            if (dtobj.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
                {
                    Free = "1";
                }
                if (Renew == "1")
                {
                    Free = "1";
                    Renewal = "1";
                }
                if (dtobj.Rows[0]["Password_Changed"].ToString() != "")
                {
                    OpenWebsiteBrowser();
                }
                else
                {
                    OpenWebsiteBrowser();
                }
            }
            CheckRenewalValue = 1;
            int ListingProfileID = 0;
            ListingProfileID = objService.GetProfileIDByUserID(UserID);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = txtUsername.Text.Trim();
                Password = txtPassword.Text.Trim();

                this.Cursor = Cursors.WaitCursor;
                LoginChecking(UserName, Password);
                this.Cursor = Cursors.Default;

                //notifyIcon1.Visible = false;
            }
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "Login.cs", "btnLogin_Click", Convert.ToString(ex.Message),
                                  Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Desktop ShortCut");
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
