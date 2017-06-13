using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for OTPScreen.xaml
    /// </summary>
    public partial class OTPScreen : Page
    {
        ISAService.ClientServiceSoapClient objClient = new ISAService.ClientServiceSoapClient();
        RegistrationUser objRegUser = App.ObjRegistrationUser;
        string generateOTP;

        MyClass myC = new MyClass();
        ThreadStart tStart;
        Thread t;

        public OTPScreen()
        {
            InitializeComponent();
            tStart = new ThreadStart(myC.WorkerMethod);
            t = new Thread(tStart);
            myC.OnWorkerComplete += new MyClass.OnWorkerMethodCompleteDelegate(OnWorkerMethodComplete);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtOTP.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                if (txtOTP.Text.Trim() == string.Empty)
                {
                    tbErrorMsg.Text = "Please enter the OTP.";
                    tbErrorMsg.Foreground = new SolidColorBrush(Colors.Red);
                    return;
                }
                else if (!IsValidOTP(txtOTP.Text.Trim()))
                {
                    tbErrorMsg.Text = "Invalid OTP. Please try again.";
                    tbErrorMsg.Foreground = new SolidColorBrush(Colors.Red);
                    return;
                }
                if (Validation.GetHasError(txtOTP) == false)
                {
                    if (objRegUser.GenerateOTP == txtOTP.Text || generateOTP == txtOTP.Text)
                    {
                        loadingControl.Visibility = Visibility.Visible;
                        OnWorkerMethodStart();
                    }
                    else
                    {
                        tbErrorMsg.Text = "Invalid OTP. Please try again.";
                        tbErrorMsg.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tbErrorMsg.Text = "Invalid OTP. Please try again.";
                    tbErrorMsg.Foreground = new SolidColorBrush(Colors.Red);
                }
                loadingControl.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                objClient.ErrorHandling("ERROR", "OTPScreen.cs", "btnSubmit_Click", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), "", "");
            }


        }

        private void OnWorkerMethodStart()
        {
            t.Start();
        }

        private void OnWorkerMethodComplete(string message)
        {
            btnSubmit.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
            new Action(
            delegate ()
            {
                try {
                    int RegID = objClient.ISA_Add_Update_User(objRegUser.FirstName, objRegUser.LastName, objRegUser.MobileNumber, objRegUser.OSName, objRegUser.OSVersion, objRegUser.ProfileID.ToString());
                    if (RegID > 0)
                    {
                        Properties.Settings.Default.RegistrationID = RegID;
                        bool IsRegisterdUser = Convert.ToBoolean(Properties.Settings.Default.IsRegisteredUser);
                        if (IsRegisterdUser == false)
                        {
                            Properties.Settings.Default.IsRegisteredUser = true;
                        }

                        Properties.Settings.Default.Save();

                        NavigationService.Navigate(new Uri("/ManageNotifications.xaml", UriKind.Relative));

                    }

                    else
                    {
                        tbErrorMsg.Text = "Invalid OTP. Please try again.";
                        tbErrorMsg.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                catch (Exception ex)
                {
                    objClient.ErrorHandling("ERROR", "OTPScreen.cs", "OnWorkerMethodComplete()", Convert.ToString(ex.Message),
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), "", "");
                }

                loadingControl.Visibility = Visibility.Collapsed;
            }
            ));

        }
        private void btnResend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtOTP.Text = "";
                generateOTP = objClient.ISA_Generate_OTP(objRegUser.MobileNumber, objRegUser.ProfileID.ToString());
                objRegUser.GenerateOTP = generateOTP;
                if (!string.IsNullOrEmpty(objRegUser.GenerateOTP))
                {
                    tbErrorMsg.Text = "OTP resent successfully";
                    tbErrorMsg.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    tbErrorMsg.Text = "OTP resent failed";
                    tbErrorMsg.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            catch (Exception ex)
            {

            }

        }
        private static bool IsValidOTP(string text)
        {
            Regex regex = new Regex("^\\(?([0-9]{4})$");
            return regex.IsMatch(text);
        }
    }
}
