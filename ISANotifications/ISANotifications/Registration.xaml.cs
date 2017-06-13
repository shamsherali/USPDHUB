using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace ISANotifications
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        ISAService.ClientServiceSoapClient objClient = null;

        List<string> schoolList = new List<string>();
        DataTable dtSchoolList;
        string RegID = Properties.Settings.Default.RegistrationID.ToString();

        public Registration()
        {
            try
            {
                InitializeComponent();
                Loaded += Registration_Loaded;
            }
            catch (Exception ex)
            {

            }

        }

        private void Registration_Loaded(object sender, RoutedEventArgs e)
        {
            objClient = new ISAService.ClientServiceSoapClient();
            // Root Path Like http://www.uspdhub.com
            App.RootPath = "http://" + objClient.Endpoint.Address.Uri.Host;


            dtSchoolList = objClient.ISA_GetBusinessSchoolsList(RegID);
            txtSchool.TextChanged += new TextChangedEventHandler(txtSchool_TextChanged);
            if (grdSchools.ItemsSource == null)
            {
                grdSchools.Visibility = Visibility.Collapsed;
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
            //pbw.Owner = App.ParentWindow;
            //pbw.ShowDialog();

            loadingControl.Visibility = Visibility.Visible;
        }
        private void OnWorkerMethodComplete(string message)
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
            new Action(
            delegate ()
            {
                SubmitButtonProcess();

            }
            ));

        }


        private void txtSchool_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string typedString = txtSchool.Text;
                DataRow[] rows = dtSchoolList.Select("Profile_name LIKE '%" + typedString + "%' OR Profile_Zipcode LIKE '%" + typedString + "%'");
                DataTable dtList = new DataTable("dtlist");
                if (rows.Length > 0)
                    dtList = rows.CopyToDataTable();

                if (dtList.Rows.Count > 0)
                {
                    lbSchoolList.ItemsSource = dtList.DefaultView;
                    lbSchoolList.DisplayMemberPath = "Profile_name";
                    lbSchoolList.SelectedValuePath = "Profile_name";
                    lbSchoolList.Visibility = Visibility.Visible;
                    grdSchools.Visibility = Visibility.Collapsed;
                }
                else if (txtSchool.Text.Equals(""))
                {
                    lbSchoolList.Visibility = Visibility.Collapsed;
                    lbSchoolList.ItemsSource = null;
                }
                else
                {
                    lbSchoolList.Visibility = Visibility.Collapsed;
                    lbSchoolList.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void lbSchoolList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lbSchoolList.ItemsSource != null)
                {
                    lbSchoolList.Visibility = Visibility.Collapsed;
                    txtSchool.TextChanged -= new TextChangedEventHandler(txtSchool_TextChanged);
                    if (lbSchoolList.SelectedIndex != -1)
                    {
                        DataRowView rowview = lbSchoolList.SelectedItem as DataRowView;
                        txtSchool.Text = rowview["Profile_name"].ToString();
                    }


                    DataTable tempDt = dtSchoolList.Copy();
                    tempDt.Clear();
                    if (txtSchool.Text != "")
                    {
                        foreach (DataRow dr in dtSchoolList.Rows)
                        {
                            if (dr["Profile_name"].ToString() == txtSchool.Text || dr["Profile_Zipcode"].ToString() == txtSchool.Text)
                            {
                                tempDt.ImportRow(dr);
                            }
                        }

                        grdSchools.ItemsSource = tempDt.DefaultView;

                        grdSchools.Focus();
                    }
                    else
                    {
                        grdSchools.ItemsSource = dtSchoolList.DefaultView;

                        grdSchools.Focus();
                    }
                    txtSchool.TextChanged += new TextChangedEventHandler(txtSchool_TextChanged);
                    grdSchools.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtFName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                txtMobile.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                if (txtFName.Text.Trim() == string.Empty)
                {
                    errorMessage.Content = "Please enter the first name.";

                    return;
                }
                if (!IsSpecialCharAllowed(txtFName.Text.Trim()))
                {
                    errorMessage.Content = "Please enter the valid first name.";

                    return;
                }
                if (txtLName.Text != "")
                {
                    if (!IsSpecialCharAllowed(txtLName.Text.Trim()))
                    {
                        errorMessage.Content = "Please enter the valid last name.";
                        return;
                    }
                }
                if (txtMobile.Text.Trim() == string.Empty)
                {
                    errorMessage.Content = "Please enter the mobile number.";
                    return;
                }
                if (txtMobile.Text.Length < 12)
                {
                    errorMessage.Content = "Please enter the valid mobile number.";
                    return;
                }
                if (txtSchool.Text.Trim() == "")
                {
                    errorMessage.Content = "Please enter the school name or zip code.";
                    return;
                }
                if (grdSchools.ItemsSource == null)
                {
                    errorMessage.Content = "Please select the school.";
                    return;
                }
                if (Validation.GetHasError(txtFName) == false && Validation.GetHasError(txtMobile) == false)
                {
                    SubmitButtonProcess();
                }

            }
            catch (Exception ex)
            {
            }


        }

        private void SubmitButtonProcess()
        {
            OperatingSystem OS = Environment.OSVersion;
            RegistrationUser reg = new RegistrationUser();
            reg.FirstName = txtFName.Text;
            reg.LastName = txtLName.Text;
            reg.MobileNumber = txtMobile.Text;
            reg.OSName = OS.Platform.ToString();
            reg.OSVersion = OS.Version.ToString();
            DataRowView row = (DataRowView)grdSchools.SelectedItems[0];
            reg.ProfileID = Convert.ToInt32(row["Profile_ID"].ToString());
            string generateOTP = objClient.ISA_Generate_OTP(txtMobile.Text, row["Profile_ID"].ToString());
            reg.GenerateOTP = generateOTP;
            App.ObjRegistrationUser = reg;


            if (!string.IsNullOrEmpty(generateOTP))
            {
                NavigationService.Navigate(new Uri("/OTPScreen.xaml", UriKind.Relative));
            }
        }

        private void imgLogo_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void sp_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var spPanel = sender as StackPanel;
                var imgLogo = spPanel.FindName("imgLogo") as Image;
                string logoName = imgLogo.Tag.ToString();

                TextBlock lblPID = spPanel.FindName("tbPID") as TextBlock;
                string pid = lblPID.Text;

                string fullLogoPath = App.RootPath + "/upload/logos/" + pid + "/" + logoName.Replace(pid, pid + "_thumb");
                var uri = new Uri(fullLogoPath);
                var bitmap = new BitmapImage(uri);
                imgLogo.Source = bitmap;

            }
            catch (Exception ex)
            {

            }

        }

        private void txtMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            string phNumber = txtMobile.Text.Trim();
            string formatedPhoneNumber = String.Format("{0:(###) ###-####}", phNumber);
            txtMobile.Text = Regex.Replace(phNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            if (txtMobile.Text.Length > 10)
            {
                txtMobile.SelectionStart = txtMobile.Text.Length;

            }

        }

        private void txtMobile_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
            //  MessageBox.Show("Please enter numbers only");
        }


        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]"); //regex that matches disallowed text
            return regex.IsMatch(text);
        }

        private static bool IsSpecialCharAllowed(string text)
        {
            Regex regex = new Regex("^[a-zA-Z0-9 ]+$");
            return regex.IsMatch(text);
        }

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            UIElement selectedElement = (UIElement)this.lbSchoolList.ItemContainerGenerator.ContainerFromItem(this.lbSchoolList.SelectedItem);
            if (selectedElement != null)
            {
                selectedElement.Focus();
            }

            e.Handled = false;
        }

    }
}
