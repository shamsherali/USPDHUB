using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Diagnostics;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Windows;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace ISANotifications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool IsRegisterdUser = Convert.ToBoolean(Properties.Settings.Default.IsRegisteredUser);
        string RegID = Properties.Settings.Default.RegistrationID.ToString();
        bool isClickUpdate = true;
        private NotifyIcon MyNotifyIcon;

        private const uint SC_CLOSE = 0xF060;
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hwnd, bool revert);
        [DllImport("user32.dll")]
        private static extern bool DeleteMenu(IntPtr hMenu, uint position, uint flags);

        public MainWindow()
        {

            InitializeComponent();


            Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;
            App.Current.MainWindow = this;

            this.ShowInTaskbar = true;
            RemoveNotifyIcon();

            Properties.Settings.Default.IsTrayIcon = true;
            Properties.Settings.Default.Save();
            MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
            MyNotifyIcon.Icon = new System.Drawing.Icon(Common.GetFormImageUrl());
            MyNotifyIcon.Visible = true;
            MyNotifyIcon.MouseDoubleClick +=
                new System.Windows.Forms.MouseEventHandler
                    (MyNotifyIcon_MouseDoubleClick);


            CheckUser();


        }

        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = WindowState.Maximized;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
        }
        private void MainWindow_Closing(object sender, EventArgs e)
        {
            MyNotifyIcon.Visible = false;
            MyNotifyIcon.Icon = null;
            MyNotifyIcon.Dispose();
            MyNotifyIcon = null;
            Properties.Settings.Default.IsAppExit = true;
            Properties.Settings.Default.Save();
            foreach (Process p in Process.GetProcessesByName("ISANotifications"))
            {
                p.CloseMainWindow();
                //p.Kill();
            }
            NotifyWindow windowNotify = new NotifyWindow();
            windowNotify.StopTimer();
            windowNotify.Close();
            Environment.Exit(0);
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MyNotifyIcon.Visible = false;
            MyNotifyIcon.Icon = null;
            MyNotifyIcon.Dispose();
            MyNotifyIcon = null;
            foreach (Process p in Process.GetProcessesByName("ISANotifications"))
            {
                p.CloseMainWindow();
                //p.Kill();
            }
            Environment.Exit(0);
        }
        private void RemoveNotifyIcon()
        {

            foreach (Process p in Process.GetProcessesByName("ISANotifications"))
            {
                p.CloseMainWindow();


                //p.Kill();
            }
            if (MyNotifyIcon != null)
            {
                MyNotifyIcon.Visible = false;
                MyNotifyIcon.Icon = null;
                MyNotifyIcon.Dispose();
                MyNotifyIcon = null;
                Environment.Exit(0);
            }

        }
        private void CheckUser()
        {

            if (IsRegisterdUser)
            {
                #region Reset PoolDate for Sync process

                // Resetting Flags for Sync process
                Properties.Settings.Default.IsFirstLaunch = true;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.IsAppExit = false;
                Properties.Settings.Default.Save();

                DateTime dtServerTime = DateTime.Now;
                try
                {
                    ISAService.ClientServiceSoapClient objService = new ISAService.ClientServiceSoapClient();
                    if (Common.IsNetworkAvailable())
                    {
                        dtServerTime = Convert.ToDateTime(objService.GetCurrentDateTime());
                    }
                    else
                        System.Windows.MessageBox.Show("Network Connection failed");
                }
                catch (Exception ex)
                {
                    TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                    var utcNow = DateTime.UtcNow;
                    var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);

                    dtServerTime = pacificNow;
                }
                // Save Pool Date
                Properties.Settings.Default.PoolDate = dtServerTime.ToString();
                Properties.Settings.Default.Save();
                #endregion

                frame.Navigate(new Uri("/ManageNotifications.xaml", UriKind.Relative));
                spMenu.Visibility = Visibility.Visible;
            }
            else
            {
                spMenu.Visibility = Visibility.Collapsed;
            }

        }
        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            //gridNotify.Opacity = 0;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.IsFirstLaunch)
                SetAddRemoveProgramsIcon();
            checkforUpdate();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                try
                {
                    tbCurrentVersion.Text = "Current Version: " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                catch (Exception ex)
                {
                    tbCurrentVersion.Text = "Current Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
            }


        }

        public void checkforUpdate()
        {
            if (Common.IsNetworkAvailable())
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;
                    deployment.CheckForUpdateCompleted += deployment_CheckForUpdateCompleted;
                    try
                    {
                        deployment.CheckForUpdateAsync();
                    }
                    catch (InvalidOperationException e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }
            }


        }
        void deployment_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {

            try
            {
                bool ClickOnceUpdateAvailable = e.UpdateAvailable;
                if (ClickOnceUpdateAvailable)
                {
                    tbLatestVersion.Text = " New update available";
                    spUpdates.Visibility = Visibility.Visible;
                }
                else
                {
                    spUpdates.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {

            }
        }

        private static void SetAddRemoveProgramsIcon()
        {
            //only run if deployed 
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
                 && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    Assembly code = Assembly.GetExecutingAssembly();
                    AssemblyDescriptionAttribute asdescription =
                        (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
                    string assemblyDescription = asdescription.Description;

                    //the icon is included in this program
                    string iconSourcePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Images\\INSA.ico");

                    if (!File.Exists(iconSourcePath))
                        return;

                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        if (myValue.ToString() == "inSchoolALERT Notification System")
                        {

                            //if (myValue != null && myValue.ToString() == assemblyDescription)
                            //{

                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //log an error
                }
            }
        }
        private void menuNotification_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            frame.Navigate(new Uri("/ManageNotifications.xaml", UriKind.Relative));
        }

        private void menuSettings_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void menuFav_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("/Favorites.xaml", UriKind.Relative));

        }

        private void menuAlertSound_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("/ManageAudio.xaml", UriKind.Relative));
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //this.Hide();
                Properties.Settings.Default.IsAppExit = true;
                Properties.Settings.Default.Save();
                NotifyWindow windowNotify = new NotifyWindow();
                windowNotify.StopTimer();
                this.WindowState = WindowState.Minimized;
                this.ShowInTaskbar = false;
                RemoveNotifyIcon();

            }
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

            IsRegisterdUser = Convert.ToBoolean(Properties.Settings.Default.IsRegisteredUser);
            if (IsRegisterdUser)
            {
                spMenu.Visibility = Visibility.Visible;
            }

        }

        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {

            IsRegisterdUser = Convert.ToBoolean(Properties.Settings.Default.IsRegisteredUser);
            if (IsRegisterdUser)
            {
                spMenu.Visibility = Visibility.Visible;
            }


        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            //this.Hide();

            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
        }


        private void btnUpdateVersion_Click(object sender, MouseButtonEventArgs e)
        {
            //  this.Hide();
            //  version.DownloadNewVersion();
            if (isClickUpdate)
                InstallUpdateSyncWithInfo();
            else
                System.Windows.MessageBox.Show("You have not restarted your computer since the last update. Please restart and check for new updates.");


            // AutoUpdater.LetUserSelectRemindLater = false;
            // AutoUpdater.Start("http://staging.uspdhub.com/Upload/VersionCheck/CheckNewVersion.xml");

        }

        private void InstallUpdateSyncWithInfo()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;
                if (deployment.CheckForUpdate())
                {
                    MessageBoxResult res = System.Windows.MessageBox.Show("Are you sure you want to update?", "ISA Notifications Updater", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Properties.Settings.Default.NotificationsSyncDate = string.Empty;
                            //  deployment.UpdateProgressChanged += deployment_UpdateProgressChanged;
                            deployment.UpdateCompleted += deployment_UpdateCompleted;
                            deployment.UpdateAsync();
                        }
                        catch (Exception)
                        {
                            System.Windows.MessageBox.Show("Sorry, but an error has occurred while updating. Please try again", "ISA Notifications Updater", MessageBoxButton.OK);
                        }
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("No updates available.", "ISA Notifications Updater");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Updates not allowed unless you are launched through ClickOnce from http://www.uspdhub.com/Upload/VersionCheck/new/publish.htm");
            }
        }

        public void deployment_UpdateCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBoxResult res2 = MessageBoxResult.None;
            if (e.Error == null)
            {
                res2 = System.Windows.MessageBox.Show("Installing the update is completed, do you want to restart the application to apply the update?", "ISA Notification Updater", MessageBoxButton.YesNo);
            }
            else
            {
                System.Windows.MessageBox.Show("Sorry, but an error has occured while updating. Please try again", "ISA Notification Updater", MessageBoxButton.OK);
            }
            if (res2 == MessageBoxResult.Yes)
            {
                System.Windows.Forms.Application.Restart();
            }
            else
            {
                isClickUpdate = false;
                spUpdates.Visibility = Visibility.Collapsed;
            }
        }
        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            spUpdates.Margin = new Thickness(this.RenderSize.Width - 700, 0, 0, 0);
        }
    }

    class MyClass
    {
        public delegate void OnWorkerMethodCompleteDelegate(string message);
        public event OnWorkerMethodCompleteDelegate OnWorkerComplete;


        public void WorkerMethod()
        {
            //Thread.Sleep(1000 * 10);
            OnWorkerComplete("The processing is complete");
        }
    }
}
