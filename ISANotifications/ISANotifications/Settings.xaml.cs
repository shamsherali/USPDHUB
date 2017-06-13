using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISANotifications
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

            loadData();
        }



        protected void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTextAllowed(txtCallNumber.Text.Trim()))
            {
                MessageBox.Show("Enter numbers only");
            }
            else if (!IsTextAllowed(txtPushNumber.Text.Trim()))
            {
                MessageBox.Show("Enter numbers only");
            }
            else {
                if (txtPushNumber.Text.Trim() != "")
                {
                    Properties.Settings.Default.PushNotificationCount = txtPushNumber.Text;
                }
                if (txtCallNumber.Text.Trim() != "")
                {
                    Properties.Settings.Default.CallNotificationCount = txtCallNumber.Text;
                }
                if (cbSchedule.SelectedValue.ToString() != "")
                {
                    Properties.Settings.Default.DurationTime = cbSchedule.SelectedValue.ToString();
                }

                Properties.Settings.Default.Save();
                MessageBox.Show("Settings are updated successfully");
            }

        }

        protected void loadData()
        {
            txtCallNumber.Text = Properties.Settings.Default.CallNotificationCount;
            txtPushNumber.Text = Properties.Settings.Default.PushNotificationCount;
           // cbSchedule.Text = Properties.Settings.Default.DurationTime;

        }


        public void cbSchedule_Loaded(object sender, RoutedEventArgs e)
        {

            ISAService.ClientServiceSoapClient objClient = new ISAService.ClientServiceSoapClient();
            string DefaultSyncTime = "0";
            List<string> scheduleTime = new List<string>();
            scheduleTime = objClient.ISA_GetSyncTimeIntervals(out DefaultSyncTime).ToList<String>();
            if (Properties.Settings.Default.DurationTime.ToString() == string.Empty)
            {
                Properties.Settings.Default.DurationTime = DefaultSyncTime;
            }
            cbSchedule.ItemsSource = scheduleTime;
            cbSchedule.SelectedValue = Properties.Settings.Default.DurationTime.ToString();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ManageNotifications.xaml", UriKind.Relative));
        }

        private void txtCallNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void txtPushNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
