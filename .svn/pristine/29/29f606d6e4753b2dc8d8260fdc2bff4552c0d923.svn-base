using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ISANotifications
{
    /// <summary>
    /// Interaction logic for NotifyWindow.xaml
    /// </summary>
    public partial class NotifyWindow : Window
    {
        Timer timer1 = new Timer();
        Timer AppTimer = new Timer();
        DispatcherTimer MyTimer;
        public double WindowLeft = 0;
        public double WindowTop = 0;
        MediaPlayer objMediaEle = null;
        private bool isActive = false;
        public MainWindow objMainWindow = null;
        public static NotifyWindow objNotifyWindow = null;
        ISAService.ClientServiceSoapClient objService = new ISAService.ClientServiceSoapClient();

        public NotifyWindow()
        {
            InitializeComponent();
            Loaded += NotifyWindow_Loaded;

            try
            {
                if (objMediaEle != null)
                    objMediaEle.Stop();
            }
            catch (Exception ex)
            {
                if (Common.IsNetworkAvailable())
                {
                    objService.ErrorHandling("ERROR", "Notification.cs", "NotifyWindow()", Convert.ToString(ex.Message),
                         Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), "", "");
                }
            }

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (MyTimer != null)
                MyTimer.Stop();
        }
        private void NotifyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ShowMessage();
            //NotificationTimeSetting();
            MyTimer = new System.Windows.Threading.DispatcherTimer();
            MyTimer.Interval = new TimeSpan(0, 0, Convert.ToInt32(Properties.Settings.Default.DurationTime), 0, 0);
            MyTimer.Tick += new EventHandler(RefreshData);
            // Start the timer
            MyTimer.Start();
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }
        public void RefreshData(object sender, EventArgs e)
        {
            Window parentWindow = App.Current.MainWindow;
            if (Properties.Settings.Default.IsAppExit == false)
            {
                if (parentWindow != null)
                {
                    try
                    {
                        MainWindow objMainWindow = App.Current.MainWindow as MainWindow;
                        if (objMainWindow != null)
                            objMainWindow.checkforUpdate();
                    }
                    catch
                    { }
                    ShowMessage();
                }
            }
            else
                MyTimer.Stop();

        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        public void StopTimer()
        {
            if (MyTimer != null)
                MyTimer.Stop();
            if (timer1 != null)
                timer1.Stop();
            if (AppTimer != null)
                AppTimer.Stop();
        }


        #region Notify Window popup
        private void ShowMessage()
        {
            try
            {
                if (Common.IsNetworkAvailable())
                {
                    #region Pool DateTime With Server Time 

                    // Get Server Time 
                    DateTime dtServerTime = DateTime.Now;
                    DateTime poolDate = DateTime.Now;

                    // First Installation Time if condition excution
                    if (Convert.ToString(Properties.Settings.Default.PoolDate).Trim() == string.Empty)
                    {
                        try
                        {
                            dtServerTime = Convert.ToDateTime(objService.GetCurrentDateTime());
                        }
                        catch (Exception ex)
                        {
                            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                            var utcNow = DateTime.UtcNow;
                            var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);

                            dtServerTime = pacificNow;
                        }

                        poolDate = dtServerTime;
                    }
                    else
                    {
                        poolDate = Convert.ToDateTime(Properties.Settings.Default.PoolDate);
                        poolDate = poolDate.AddSeconds(-poolDate.Second);

                        try
                        {
                            dtServerTime = Convert.ToDateTime(objService.GetCurrentDateTime());
                        }
                        catch (Exception ex)
                        {
                            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                            var utcNow = DateTime.UtcNow;
                            var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);

                            dtServerTime = pacificNow;
                        }

                    }

                    // Save Pool Date
                    Properties.Settings.Default.PoolDate = dtServerTime.ToString();

                    // Last Sync Date Updating
                    Properties.Settings.Default.LastSyncDate = DateTime.Now.ToString();
                    Properties.Settings.Default.Save();


                    #endregion

                    DataTable dtAlerts = new DataTable("dtAlerts");
                    string strRecentDateTime = string.Empty;
                    dtAlerts = objService.ISA_SyncNoticicationsData(out strRecentDateTime, Properties.Settings.Default.RegistrationID.ToString(),
                        poolDate.ToString());


                    System.Windows.Application.Current.Dispatcher.Invoke(
              System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
              {
                  int numberPushCount = 0;
                  int notificationOffCount = 0;
                  if (dtAlerts.Rows.Count > 0)
                  {
                      numberPushCount = Convert.ToInt32(dtAlerts.Rows[0]["NotificationsCount"]);
                      notificationOffCount = Convert.ToInt32(dtAlerts.Rows[0]["NotificationOffCount"]);
                  }

                  moreMessage.Text = "";
                  if (numberPushCount <= 0)
                  {
                      if (!isActive)
                      {
                          this.Hide();
                          moreMessage.Text = "No New Messages.";

                          spSchoolName.Visibility = Visibility.Collapsed;
                          spMessage.Visibility = Visibility.Collapsed;
                      }
                      if (notificationOffCount > 0)
                      {
                          Window parentWindow = App.Current.MainWindow;
                          Frame dummyFrame = parentWindow.FindName("frame") as Frame;
                          dummyFrame.Navigate(new Uri("/dummy.xaml", UriKind.Relative));
                      }
                  }
                  else
                  {
                      isActive = true;
                      DataTable dtAudioFile = objService.ISA_GetDefaultAudio(Properties.Settings.Default.RegistrationID.ToString());
                      if (dtAudioFile.Rows.Count > 0)
                      {
                          objMediaEle = new MediaPlayer();
                          var playUrl = App.RootPath + dtAudioFile.Rows[0]["AudioPlayUrl"].ToString();
                          objMediaEle.Open(new Uri(playUrl));
                          objMediaEle.Play();
                      }

                      spSchoolName.Visibility = Visibility.Visible;
                      spMessage.Visibility = Visibility.Visible;

                      //First Push Message display her
                      if (numberPushCount > 1)
                      {
                          tbNotificationType.Text = (dtAlerts.Rows[0]["UMButtonType"].ToString().Equals("PrivateCallAddOns") ? "Call Directory Alert Notification" : "General Push Notification");
                          tbSchoolName.Text = dtAlerts.Rows[0]["Profile_name"].ToString();
                          tbMessage.Text = ((dtAlerts.Rows[0]["Message"].ToString().Length > 65) ? dtAlerts.Rows[0]["Message"].ToString().Substring(0, 62) + "..." : dtAlerts.Rows[0]["Message"].ToString());
                          int count = numberPushCount - 1;
                          moreMessage.Text = "You have " + count + " more notification(s).";
                      }
                      else
                      {
                          tbNotificationType.Text = (dtAlerts.Rows[0]["UMButtonType"].ToString().Equals("PrivateCallAddOns") ? "Call Directory Alert Notification" : "General Push Notification");
                          tbSchoolName.Text = dtAlerts.Rows[0]["Profile_name"].ToString();
                          tbMessage.Text = ((dtAlerts.Rows[0]["Message"].ToString().Length > 65) ? dtAlerts.Rows[0]["Message"].ToString().Substring(0, 62) + "..." : dtAlerts.Rows[0]["Message"].ToString());
                      }

                      Window objWindow = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
                      if (this.WindowState == WindowState.Minimized)
                      {
                          this.WindowState = WindowState.Normal;
                      }
                      objNotifyWindow = this;
                      this.Show();
                      this.Activate();
                      this.Topmost = true;


                      Window parentWindow = App.Current.MainWindow;
                      //parentWindow.Hide();
                      //parentWindow.Show();

                      Frame dummyFrame = parentWindow.FindName("frame") as Frame;
                      dummyFrame.Navigate(new Uri("/dummy.xaml", UriKind.Relative));

                  } //END Else
              });
                }
                else
                    MessageBox.Show("Network Connection failed");
            } //try
            catch (Exception ex)
            {
                if (Common.IsNetworkAvailable())
                {
                    objService.ErrorHandling("ERROR", "Notification.cs", "ShowMessage()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), "", "");
                }
                else
                    MessageBox.Show("Network Connection failed");
            }
        }
        #endregion 
        private void imgClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.WindowState = WindowState.Minimized;
            isActive = false;
            this.Hide();
            //sp.Stop();
            if (objMediaEle != null)
                objMediaEle.Stop();
        }

        private void imgMainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (objMediaEle != null)
                objMediaEle.Stop();
            isActive = false;
            this.Hide();
            for (int count = App.Current.Windows.Count - 1; count >= 0; count--)
                App.Current.Windows[count].Hide();


            Window parentWindow = App.Current.MainWindow;
            parentWindow.Show();
            parentWindow.WindowState = WindowState.Maximized;
        }
    }
}
