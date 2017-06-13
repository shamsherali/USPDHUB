// Last Build Date Sep 18 2014
//
//



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using POC.POC_Utilities;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace POC
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        USPDhubClientService.ClientServiceSoapClient objService = null;

        public int UserID;


        public int CheckRenewalValue;
        public string Renew;
        public int flag = 0;
        public string Free = "";
        public string Renewal = "";

        public int ProfileID; 

        public Login()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Login_Loaded);
        }


        void Login_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.ToString();


                objService = new USPDhubClientService.ClientServiceSoapClient();
                string RootPath = "";
                if (objService.Endpoint.Address.Uri.ToString().Contains("localhost"))
                {
                    RootPath = "http://localhost:2107";
                }
                else if (objService.Endpoint.Address.Uri.ToString().Contains("http://test.uspdhub.com"))
                {
                    RootPath = "http://test.uspdhub.com";
                }
                else if (objService.Endpoint.Address.Uri.ToString().Contains("http://www.uspdhub.com"))
                {
                    RootPath = "http://www.uspdhub.com";
                }

                //string countryVertival = ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString();
                // string RootPath = objService.GetConfigSettingsByVertical(countryVertival, "Paths", "RootPath");
                //string iconPath = "icons/" + countryVertival + "/agencylogo.ico";
                string iconPath = RootPath + "/Images/POCDesktopIcons/" + ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString() + "/agencylogo.ico";
                // Set an icon using code
                Uri iconUri = new Uri(iconPath);
                this.Icon = BitmapFrame.Create(iconUri);

                txtUsername.Focus();

                if (Properties.Settings.Default.UserName.Trim() != "")
                {
                    if (App.IsLogOut == false)
                    {
                        txtUsername.Text = Properties.Settings.Default.UserName; ;
                        txtPassword.Password = EncryptDecrypt.DESDecrypt(Properties.Settings.Default.Password.ToString()); 
                        chkRememberme.IsChecked = true;

                        OnWorkerMethodStart();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string UserName = txtUsername.Text.Trim();
                string Password = txtPassword.Password.Trim();

                tbErrorMessage.Text = "";
                if (UserName == string.Empty)
                {
                    tbErrorMessage.Text = "Please enter the username.";
                }
                else if (Password == string.Empty)
                {
                    tbErrorMessage.Text = "Please enter the password.";
                }
                else
                {
                    OnWorkerMethodStart();
                }

            }
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "Login.cs", "btnLogin_Click", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");

                loading.Visibility = Visibility.Collapsed;

                //MessageBox.Show("oops! an exception has occurred while processing login request. Please close this window and try again.");
            }
        }

        private void LoginChecking(string Username, string Password)
        {
            try
            {
                //objService = new USPDhubClientService.ClientServiceSoapClient();
                var dtobj = objService.GetUserDetails(Username, ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString());
                if (dtobj != null)
                {
                    App.C_USER_ID = 0;
                    if (dtobj.Rows.Count == 0)
                    {
                        DataTable dtAssociate = objService.GetAssociateUserDetails(Username, ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString());
                        if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                        {
                            App.C_USER_ID = Convert.ToInt32(dtAssociate.Rows[0]["User_ID"]);
                            App.C_USER_NAME = Username;
                            dtobj = objService.GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                        }
                        else
                        {
                            App.C_USER_ID = 0;
                        }
                    } //Ends here...
                    if (dtobj.Rows.Count == 1)
                    {
                        if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                        {
                            int code = 1;
                            string passcod = string.Empty;

                            if (App.C_USER_ID != 0)
                            {
                                passcod = Password;
                                code = Password.CompareTo(passcod.ToString());
                            }
                            else
                            {
                                passcod = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                                code = Password.CompareTo(passcod.ToString());
                            }

                            if (code == 0)
                            {
                                //Assign to Session variables 
                                UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                //Name = dtobj.Rows[0]["firstname"].ToString();
                                App.Username = dtobj.Rows[0]["Username"].ToString();
                                DataTable bustabobj = new DataTable();
                                bustabobj = objService.GetBusinessProfileByUserID(UserID);

                                ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
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
                                        App.IsExpiryAccount = false;
                                        LoginSuccess();
                                    }
                                    else
                                    {
                                        App.IsExpiryAccount = true;
                                        Renew = "1";
                                        GetFreeUserDetails();
                                    }
                                }

                                if (CheckRenewalValue == 0 && flag == 0)
                                {
                                    LoginSuccess();
                                }
                            }
                            else
                            {
                                loading.Visibility = Visibility.Collapsed;
                                tbErrorMessage.Text = "Invalid password; please try again.";
                            }
                        }
                        else
                        {
                            string ActivationCode = string.Empty;
                            ActivationCode = objService.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                            if (ActivationCode != "")
                            {

                                tbErrorMessage.Text = "Your account is not yet activated. Please check your email (" + dtobj.Rows[0]["username"].ToString() + ") to activate your USPDhub Account.";
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

                                    tbErrorMessage.Text = "Your Account Registration is incomplete. Please click here to complete your Registration.";
                                }
                                else
                                {
                                    ProfileID = 0;
                                    UserID = 0;

                                    tbErrorMessage.Text = "Your Account Registration is incomplete. Please click here to start new Registration...!";
                                }
                            }
                        }
                    }
                    else
                    {
                        loading.Visibility = Visibility.Collapsed;
                        tbErrorMessage.Text = "Invalid login name or password, please try again.";
                    }
                }
                else
                {
                    loading.Visibility = Visibility.Collapsed;
                    tbErrorMessage.Text = "Invalid Login Name & Password";
                }

            }
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "Login.cs", "LoginChecking", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");

                loading.Visibility = Visibility.Collapsed;
                
            }
        }

        private void LoginSuccess()
        {
            //Properties.Settings.Default.Reset();
            Properties.Settings.Default.ProfileID = ProfileID;
            Properties.Settings.Default.UserID = UserID;
            Properties.Settings.Default.Save();

            App.Password = txtPassword.Password;

            loading.Visibility = Visibility.Collapsed;

            if (chkRememberme.IsChecked == true)
            {
                Properties.Settings.Default.UserName = txtUsername.Text.Trim();
                Properties.Settings.Default.Password = EncryptDecrypt.DESEncrypt(txtPassword.Password.Trim());
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }

            // pbw.Close();
            loading.Visibility = Visibility.Collapsed;

            MainWindow parentWindow = new MainWindow();
            this.Hide();
            parentWindow.Topmost = true;
            parentWindow.ShowDialog();
        }

        private void GetFreeUserDetails()
        {
            try
            {
                // Check For Free User
                string username = txtUsername.Text.Trim();
                var dtobj = objService.GetUserDetailsByUserID(UserID);
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
                        LoginSuccess();
                    }
                    else
                    {
                        LoginSuccess();
                    }
                }
                CheckRenewalValue = 1;
                int ListingProfileID = 0;
                ListingProfileID = objService.GetProfileIDByUserID(UserID);

            }
            catch (Exception ex)
            {

            }
        }


        private void OnWorkerMethodStart()
        {
            MyClass myC = new MyClass();
            myC.OnWorkerComplete += new MyClass.OnWorkerMethodCompleteDelegate(OnWorkerMethodComplete);
            ThreadStart tStart = new ThreadStart(myC.WorkerMethod);
            Thread t = new Thread(tStart);
            t.Start();

            //pbw = new ProgressBarWindow();
            //pbw.Owner = this;
            //pbw.ShowDialog();

            loading.Visibility = Visibility.Visible;
        }

        private void OnWorkerMethodComplete(string message)
        {
            btnLogin.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
            new Action(
            delegate()
            {
                string UserName = txtUsername.Text.Trim();
                string Password = txtPassword.Password.Trim();

                //LoginSuccess();
                LoginChecking(UserName, Password);
            }
            ));

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                //this.DialogResult = true;
            }
            catch /*(Exception ex)*/
            {
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            App.Username = "";
            Properties.Settings.Default.ProfileID = 0;
            Properties.Settings.Default.UserID = 0;
            Properties.Settings.Default.Save();
            //Properties.Settings.Default.Reset();

            Application.Current.Shutdown();
        }

    }

    class MyClass
    {
        public delegate void OnWorkerMethodCompleteDelegate(string message);
        public event OnWorkerMethodCompleteDelegate OnWorkerComplete;


        public void WorkerMethod()
        {
            Thread.Sleep(1000);
            OnWorkerComplete("The processing is complete");
        }
    }

}
