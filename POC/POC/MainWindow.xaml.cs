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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using POC.POC_Utilities;

namespace POC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        USPDhubClientService.ClientServiceSoapClient objService = new USPDhubClientService.ClientServiceSoapClient();
        public int ProfileID = 0;
        public int UserID = 0;


        public string ProfileName = "";


        public MainWindow()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                App.ParentWindow = this;

                ProfileID = Properties.Settings.Default.ProfileID;
                UserID = Properties.Settings.Default.UserID;

                if (ProfileID == 0)
                {
                    Login objLogin = new Login();
                    objLogin.Topmost = true;
                    objLogin.ShowDialog();
                }

                #region Agency Logo Icon Set
                string countryVertival = ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString();
                string RootPath = objService.GetConfigSettingsByVertical(countryVertival, "Paths", "RootPath");
                //string iconPath = "icons/" + countryVertival + "/agencylogo.ico";
                string iconPath = RootPath + "/Images/POCDesktopIcons/" + ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString() + "/agencylogo.ico";
                // Set an icon using code
                Uri iconUri = new Uri(iconPath);
                this.Icon = BitmapFrame.Create(iconUri);

                #endregion

                DataTable bustabobj = new DataTable();
                bustabobj = objService.GetBusinessProfileByUserID(UserID);
                if (bustabobj.Rows.Count > 0)
                    ProfileName = Convert.ToString(bustabobj.Rows[0]["Profile_name"]);

                this.Title = ProfileName;


                naviateWindow.Navigate(new Uri("Business/Dashboard.xaml", UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {

            }
        }

        private void menuLogOut_Click(object sender, RoutedEventArgs e)
        {
            App.IsLogOut = true;

            Properties.Settings.Default.ProfileID = 0;
            Properties.Settings.Default.UserID = 0;
            Properties.Settings.Default.Save();
             

            //this.Close();
            this.Hide();

            Login objLogin = new Login();
            objLogin.Topmost = true;
            objLogin.ShowDialog();

        }

        private void menuHisotry_Click(object sender, RoutedEventArgs e)
        {
            naviateWindow.Navigate(new Uri("Business/Dashboard.xaml?ID=" + Guid.NewGuid(), UriKind.RelativeOrAbsolute));
        }

        private void naviateWindow_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            tbLoading.Visibility = Visibility.Visible;
        }

        private void naviateWindow_NavigationProgress(object sender, NavigationProgressEventArgs e)
        {
            tbLoading.Visibility = Visibility.Visible;
        }

        private void naviateWindow_Navigated(object sender, NavigationEventArgs e)
        {
            tbLoading.Visibility = Visibility.Collapsed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //MessageBoxResult result = MessageBox.Show("Would you like to exit?", "Confirmation", MessageBoxButton.YesNo);

            //if (result == MessageBoxResult.Yes)
            //{
            //    this.DialogResult = false;
            //}
            //else
            //{
            //    // ????
            //}

            App.Username = "";
            Properties.Settings.Default.ProfileID = 0;
            Properties.Settings.Default.UserID = 0;
            Properties.Settings.Default.Save();
             
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string rootPath = objService.GetConfigSettingByPID(ProfileID.ToString(), "Paths", "RootPath");

            string loggedUsername = "";
            string loggedPassword = App.Password;

            if (App.C_USER_ID == 0)
            {
                loggedUsername = App.Username;
            }
            else
            {
                loggedUsername = App.C_USER_NAME;
            }

            string urlinfo = rootPath + "/Business/MyAccount/DesktopLogin.aspx?username=" + EncryptDecrypt.DESEncrypt(loggedUsername) +
                "&pwd=" + EncryptDecrypt.DESEncrypt(loggedPassword);
            System.Diagnostics.Process.Start(urlinfo);


        }
    }
}
