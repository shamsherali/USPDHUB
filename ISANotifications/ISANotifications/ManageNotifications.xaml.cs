using System;
using System.Collections.Generic;
using System.Data;
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
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace ISANotifications
{
    /// <summary>
    /// Interaction logic for ManageNotifications.xaml
    /// </summary>
    public partial class ManageNotifications : Page
    {
        ISAService.ClientServiceSoapClient objClient = null;
        private PagingCollectionView _pushview;

        private PagingCollectionView _callview;
        int pushNotificationCount = 0;
        int callNotificationCount = 0;       
        private int Start = 1;

        public string selectedValue = "0";

        private DispatcherTimer _timer = null;

        public ManageNotifications()
        {
            InitializeComponent();
            Loaded += ManageNotifications_Loaded;
            DisplayLastSyncTime();
            //Properties.Settings.Default.SettingChanging += SettingChanging;
        }

        private void DisplayLastSyncTime()
        {
            //tbLastSyncTime.Text = Convert.ToDateTime(Properties.Settings.Default.PoolDate).ToString("dd/MM/yyyy hh:mm tt");
        }

        private void ManageNotifications_Loaded(object sender, RoutedEventArgs e)
        {
            objClient = new ISAService.ClientServiceSoapClient();
            // Root Path Like http://www.uspdhub.com
            App.RootPath = "http://" + objClient.Endpoint.Address.Uri.Host;

            loadingControl.Visibility = Visibility.Visible;
            OnWorkerMethodStart();
            //LoadData();
            LoadSchoolsList();

            string DefaultSyncTime = "0";
            List<string> scheduleTime = new List<string>();
            scheduleTime = objClient.ISA_GetSyncTimeIntervals(out DefaultSyncTime).ToList<String>();

            if (Properties.Settings.Default.DurationTime != DefaultSyncTime)
            {
                Properties.Settings.Default.DurationTime = DefaultSyncTime;
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.IsFirstLaunch == true)
            {               
                Properties.Settings.Default.IsFirstLaunch = false;
                Properties.Settings.Default.Save();
                NotifyWindow notifyWindo = new NotifyWindow();
                notifyWindo.ShowInTaskbar = false;
                notifyWindo.Show();
            }
            //_timer = new DispatcherTimer();
            //_timer.Tick += Each_Tick;
            //_timer.Interval = new TimeSpan(0, 0, Convert.ToInt32(DefaultSyncTime), 0, 0);
            //_timer.Start();
        }

        private void Each_Tick(object o, EventArgs sender)
        {
            // Refresh from database etc ...
            //initializeload();

            // Anything else you need ...
        }

        private void initializeload()
        {
            DataTable dtAlerts = new DataTable("dtAlerts");
            string strRecentDateTime = string.Empty;
            dtAlerts = objClient.ISA_SyncNoticicationsData(out strRecentDateTime, Properties.Settings.Default.RegistrationID.ToString(),
                GetPoolDate().ToString());
            if (dtAlerts.Rows.Count > 0)
            {
                LoadData();
            }
        }
        private DateTime GetPoolDate()
        {
            // Get Server Time 
            DateTime dtServerTime = DateTime.Now;
            DateTime poolDate = DateTime.Now;

            // First Installation Time if condition excution
            if (Convert.ToString(Properties.Settings.Default.ManagePoolDate).Trim() == string.Empty)
            {
                try
                {
                    dtServerTime = Convert.ToDateTime(objClient.GetCurrentDateTime());
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
                poolDate = Convert.ToDateTime(Properties.Settings.Default.ManagePoolDate);
                poolDate = poolDate.AddSeconds(-poolDate.Second);

                try
                {
                    dtServerTime = Convert.ToDateTime(objClient.GetCurrentDateTime());
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
            Properties.Settings.Default.ManagePoolDate = dtServerTime.ToString();
            Properties.Settings.Default.Save();


            return poolDate;
        }
        DataTable dtNotifications;

        //private void btnrefresh_Click(object sender, RoutedEventArgs e)
        //{
        //    var selectedSchool = cmbFavSchools.SelectedValue.ToString();
        //    LoadData(selectedSchool);

        //}
        private void cmbFavSchools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            emptyCallRow.Visibility = Visibility.Collapsed;
            emptyPushRow.Visibility = Visibility.Collapsed;
            selectedValue = cmbFavSchools.SelectedValue.ToString();
            //LoadData(selectedSchool);
            loadingControl.Visibility = Visibility.Visible;
            OnWorkerMethodStart();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

            PopupViewNotification ViewNotification = new PopupViewNotification();
            ViewNotification.GeneralContent.Visibility = Visibility.Visible;
            ViewNotification.EmergencyContent.Visibility = Visibility.Collapsed;
            ViewNotification.NotificationHeader.Content = "General Push Notification";

            if (grdPushNotifications.ItemsSource != null)
            {
                DataRowView row = (DataRowView)grdPushNotifications.SelectedItem;
                ViewNotification.NotificationHeader.Content = "General Push Notification From";
                ViewNotification.lblSchoolName.Content = (row["Profile_name"]).ToString();
                ViewNotification.txtSchoolName.Text = (row["Profile_name"]).ToString();
                ViewNotification.txtMsg.Text = (row["Message"]).ToString();
                ViewNotification.txtSentDate.Text = (row["Sending_Date"]).ToString();
                ViewNotification.Show();

                ViewNotification.Activate();
                ViewNotification.BringIntoView();
            }
        }

        private void OnWorkerMethodStart()
        {
            MyClass myC = new MyClass();
            myC.OnWorkerComplete += new MyClass.OnWorkerMethodCompleteDelegate(OnWorkerMethodComplete);
            ThreadStart tStart = new ThreadStart(myC.WorkerMethod);
            Thread t = new Thread(tStart);
            t.Start();
        }

        private void OnWorkerMethodComplete(string message)
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
            new Action(
            delegate ()
            {
                LoadData();
                loadingControl.Visibility = Visibility.Collapsed;
            }
            ));

        }


        protected void SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (e.SettingName == "PoolDate")
            {
                // tbLastSyncTime.Text = e.NewValue.ToString();   // Assigning Last Sync Time to label
            }
        }
        protected void LoadData()
        {
            dtNotifications = objClient.ISA_GetPushNotifications(selectedValue, (Properties.Settings.Default.PushNotificationCount),
                (Properties.Settings.Default.CallNotificationCount),
                Properties.Settings.Default.RegistrationID.ToString());
            //tbLastSyncTime.Text = Properties.Settings.Default.PoolDate.ToString();
            //checking the type of notification
            DataTable dtPushNotification = new DataTable("dtPushNotification");
            DataTable dtCallNotification = new DataTable("dtCallNotification");
            if (dtNotifications.Rows.Count > 0)
            {
                DataRow[] drPush = dtNotifications.Select("UMButtonType<>'PrivateCallAddOns' ");                
                if (drPush.Length > 0)
                {
                    dtPushNotification = drPush.CopyToDataTable();
                    if (dtPushNotification.Rows.Count % 5 == 0)
                        pushNotificationCount = dtPushNotification.Rows.Count / 5;
                    else
                        pushNotificationCount = (dtPushNotification.Rows.Count / 5)+1;                    
                    _pushview = new PagingCollectionView(dtPushNotification.DefaultView, 5);
                    _pushview.CurrentPage = 1;
                    grdPushNotifications.DataContext = _pushview;
                    btnPushNext.Visibility = Visibility.Visible;
                    btnPushPrev.Visibility = Visibility.Visible;
                    currentPage.Visibility = Visibility.Visible;
                    currentPage.Content = "You are at page: " + 1 + " of " + pushNotificationCount; 
                }
                else
                {
                    grdPushNotifications.DataContext = null;
                    btnPushNext.Visibility = Visibility.Collapsed;
                    btnPushPrev.Visibility = Visibility.Collapsed;
                    currentPage.Visibility = Visibility.Collapsed;
                    emptyPushRow.Visibility = Visibility.Visible;
                }

                if (drPush.Length == 1)
                {
                    btnPushNext.Visibility = Visibility.Collapsed;
                    btnPushPrev.Visibility = Visibility.Collapsed;
                }


                DataRow[] drCall = dtNotifications.Select("UMButtonType='PrivateCallAddOns' ");                
                if (drCall.Length > 0)
                {
                    dtCallNotification = drCall.CopyToDataTable();
                    if (dtCallNotification.Rows.Count % 5 == 0)
                        callNotificationCount = dtCallNotification.Rows.Count / 5;
                    else
                        callNotificationCount = (dtCallNotification.Rows.Count / 5) + 1;
                    _callview = new PagingCollectionView(dtCallNotification.DefaultView, 5);
                    _callview.CurrentPage = 1;
                    grdCallNotifications.DataContext = _callview;
                    btnCallPushNext.Visibility = Visibility.Visible;
                    btnCallPushPrev.Visibility = Visibility.Visible;
                    callcurrentPage.Visibility = Visibility.Visible;
                    callcurrentPage.Content = "You are at page: " + 1 +" of "+ callNotificationCount;
                }
                else
                {
                    btnCallPushNext.Visibility = Visibility.Collapsed;
                    btnCallPushPrev.Visibility = Visibility.Collapsed;
                    callcurrentPage.Visibility = Visibility.Collapsed;
                    grdCallNotifications.DataContext = null;
                    emptyCallRow.Visibility = Visibility.Visible;
                }

                if (drCall.Length == 1)
                {
                    btnCallPushNext.Visibility = Visibility.Collapsed;
                    btnCallPushPrev.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                btnPushNext.Visibility = Visibility.Collapsed;
                btnPushPrev.Visibility = Visibility.Collapsed;
                currentPage.Visibility = Visibility.Collapsed;
                btnCallPushNext.Visibility = Visibility.Collapsed;
                btnCallPushPrev.Visibility = Visibility.Collapsed;
                callcurrentPage.Visibility = Visibility.Collapsed;
                grdPushNotifications.DataContext = null;
                grdCallNotifications.DataContext = null;
                emptyCallRow.Visibility = Visibility.Visible;
                emptyPushRow.Visibility = Visibility.Visible;
            }

            if (_pushview != null)
            {
                if (_pushview.CurrentPage == 1)
                    btnPushPrev.Visibility = Visibility.Collapsed;
                currentPage.Content = "You are at page: " + _pushview.CurrentPage + " of " + pushNotificationCount;
            }
            if (_callview != null)
            {
                if (_callview.CurrentPage == 1)
                    btnCallPushPrev.Visibility = Visibility.Collapsed;
                callcurrentPage.Content = "You are at page: " + _callview.CurrentPage + " of " + callNotificationCount; 
            }
        }

        protected void LoadSchoolsList()
        {

            DataTable schoolsList = objClient.ISA_GetProfileDetailsOnRegID((Properties.Settings.Default.RegistrationID).ToString(), "1");
            cmbFavSchools.ItemsSource = schoolsList.DefaultView;
            if (cmbFavSchools.ItemsSource != null)
            {
                cmbFavSchools.DisplayMemberPath = schoolsList.Columns["Profile_name"].ToString();
                cmbFavSchools.SelectedValuePath = schoolsList.Columns["ProfileID"].ToString();

                cmbFavSchools.SelectedIndex = 0;
                cmbFavSchools.SelectedItem = "All";
            }

        }

        private void hypCallLink_Click(object sender, RoutedEventArgs e)
        {
            PopupViewNotification ViewNotification = new PopupViewNotification();
            ViewNotification.EmergencyContent.Visibility = Visibility.Visible;
            ViewNotification.GeneralContent.Visibility = Visibility.Collapsed;

            if (grdCallNotifications.ItemsSource != null)
            {
                DataRowView row = (DataRowView)grdCallNotifications.SelectedItem;
                ViewNotification.EmergencyNotificationHeader.Content = "Call Directory Alert Notification From";
                ViewNotification.lblEmergencySchoolName.Content = (row["Profile_name"]).ToString();

                string strPushnotifyID = (row["PushNotifyID"]).ToString();
                string strPushTypeID = (row["Type_ID"]).ToString();
                string strProfileID = (row["Profile_ID"]).ToString();
                string resultContent = "";
                resultContent = objClient.ISA_GetEmergencyNotificationDetails_ByCustomID(strProfileID, strPushTypeID, strPushnotifyID);
                ViewNotification.WebContent.NavigateToString(resultContent);

                ViewNotification.Show();
                ViewNotification.Activate();
                ViewNotification.BringIntoView();


            }
        }

        private void OnNextClicked(object sender, RoutedEventArgs e)
        {
            _pushview.MoveToNextPage();
            try
            {
                if (btnPushPrev.Visibility == Visibility.Collapsed)
                    btnPushPrev.Visibility = Visibility.Visible;
                currentPage.Content = "You are at page: " + _pushview.CurrentPage+" of "+pushNotificationCount;


                if (_pushview.CurrentPage == _pushview.PageCount)
                { btnPushNext.Visibility = Visibility.Collapsed; }
            }
            catch (Exception ex)
            { }


        }

        private void OnPreviousClicked(object sender, RoutedEventArgs e)
        {
            _pushview.MoveToPreviousPage();
            try
            {
                currentPage.Content = "You are at page: " + _pushview.CurrentPage + " of " + pushNotificationCount; 
                if (_pushview.CurrentPage == 1)
                    btnPushPrev.Visibility = Visibility.Collapsed;

                if (_pushview.CurrentPage != _pushview.PageCount)
                { btnPushNext.Visibility = Visibility.Visible; }
            }
            catch (Exception ex)
            { }
        }


        private void OnNextClicked1(object sender, RoutedEventArgs e)
        {
            _callview.MoveToNextPage();
            try
            {
                if (btnCallPushPrev.Visibility == Visibility.Collapsed)
                    btnCallPushPrev.Visibility = Visibility.Visible;
                callcurrentPage.Content = "You are at page: " + _callview.CurrentPage + " of " + callNotificationCount; 

                if (_callview.CurrentPage == _callview.PageCount)
                { btnCallPushNext.Visibility = Visibility.Collapsed; }

            }
            catch (Exception ex)
            { }

        }

        private void OnPreviousClicked1(object sender, RoutedEventArgs e)
        {
            _callview.MoveToPreviousPage();
            if (_callview.CurrentPage == 1)
                btnCallPushPrev.Visibility = Visibility.Collapsed;
            callcurrentPage.Content = "You are at page: " + _callview.CurrentPage + " of " + callNotificationCount;

            if (_callview.CurrentPage != _callview.PageCount)
            { btnCallPushNext.Visibility = Visibility.Visible; }
        }

        private void Image_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region Last Sync Date Change

            /*
            var dtServerTime = DateTime.Now;

            try
            {
                dtServerTime = Convert.ToDateTime(objClient.GetCurrentDateTime());
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

            */

            Properties.Settings.Default.LastSyncDate = DateTime.Now.ToString();
            Properties.Settings.Default.Save();

            #endregion

            DisplayLastSyncTime();
            selectedValue = cmbFavSchools.SelectedValue.ToString();
            loadingControl.Visibility = Visibility.Visible;

            OnWorkerMethodStart();
        }

       
    }
    public class DateTimeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (String.IsNullOrEmpty(value.ToString()))
            { return string.Empty; }
            else {
                DateTime d = System.Convert.ToDateTime(value);
                return d.ToString("dd/MM/yyyy hh:mm tt");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
