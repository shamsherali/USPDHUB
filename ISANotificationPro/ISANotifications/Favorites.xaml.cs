using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Favorites.xaml
    /// </summary>
    public partial class Favorites : Page
    {
        ISAService.ClientServiceSoapClient objClient = new ISAService.ClientServiceSoapClient();

        List<string> schoolList = new List<string>();
        DataTable dtSchoolList;
        DataTable dtFavoriteList;
        string RegID = Properties.Settings.Default.RegistrationID.ToString();
        public Favorites()
        {
            try
            {
                InitializeComponent();
                if (Common.IsNetworkAvailable())
                {
                    FavoriteDataBind();
                    dtSchoolList = objClient.ISA_GetBusinessSchoolsList(RegID);

                    //schoolList = dtSchoolList.AsEnumerable()
                    //               .Select(r => r.Field<string>("Profile_name"))
                    //               .ToList();
                }
                else
                    MessageBox.Show("Network Connection failed");

                txtSchool.TextChanged += new TextChangedEventHandler(txtSchool_TextChanged);
                if (grdAddSchools.ItemsSource == null)
                {
                    grdAddSchools.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void txtSchool_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string typedString = txtSchool.Text;
                //List<string> autoList = new List<string>();
                //autoList.Clear();
                //foreach (string item in schoolList)
                //{
                //    if (!string.IsNullOrEmpty(txtSchool.Text.Trim()))
                //    {
                //        if (item.ToLower().Contains(typedString.ToLower()))
                //        {
                //            autoList.Add(item);
                //        }
                //    }
                //}

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
                        grdAddSchools.ItemsSource = tempDt.DefaultView;
                        grdAddSchools.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        grdAddSchools.ItemsSource = dtSchoolList.DefaultView;
                        grdAddSchools.Visibility = Visibility.Visible;
                    }
                    txtSchool.TextChanged += new TextChangedEventHandler(txtSchool_TextChanged);
                }
            }
            catch (Exception ex)
            {
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
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Common.IsNetworkAvailable())
            {
                DataRowView rowview = grdAddSchools.SelectedItem as DataRowView;
                string ProfileID = rowview.Row["Profile_ID"].ToString();
                DataTable dtFavorites = objClient.ISA_AddProfiles(RegID, ProfileID);

                FavoriteDataBind();
                txtSchool.Text = "";
                grdAddSchools.ItemsSource = null;
                grdAddSchools.Visibility = Visibility.Collapsed;
                lbSchoolList.Visibility = Visibility.Collapsed;
                DataTable dtNotifications = new DataTable();
                string NoteficationReadColor = "";
                string NoteficationUnReadColor = "";
                string isFirstSync = "0";
                string strLastSyncTime = DateTime.Now.ToString();
                string strLatestTime = "";
               
                dtNotifications = objClient.ISA_GetPushNotifications(out NoteficationReadColor, out NoteficationUnReadColor, out strLatestTime, ProfileID, (Properties.Settings.Default.PushNotificationCount),
                                (Properties.Settings.Default.CallNotificationCount),
                                Properties.Settings.Default.RegistrationID.ToString(), isFirstSync, strLastSyncTime);
                if (dtNotifications.Rows.Count > 0)
                {
                    DataRow[] drNotifyList = dtNotifications.Select("IsActive=1");
                    if (drNotifyList.Length > 0)
                        Common.InsertRows(drNotifyList, NoteficationReadColor);
                }

                MessageBox.Show("Added to favorites successfully.");
                dtSchoolList.Clear();
                dtSchoolList = objClient.ISA_GetBusinessSchoolsList(RegID);
            }
            else
                MessageBox.Show("Network Connection failed");

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Common.IsNetworkAvailable())
            {
                if (MessageBox.Show("Are you sure you want to remove this school from your favorites?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    DataRowView rowview = grdFavorites.SelectedItem as DataRowView;
                    string ProfileID = rowview.Row["ProfileID"].ToString();
                    int favID = objClient.ISA_DeleteProfilesOnRegID(RegID, ProfileID);
                    if (favID > 0)
                    {
                        FavoriteDataBind();
                        txtSchool.Text = "";
                        grdAddSchools.ItemsSource = null;
                        grdAddSchools.Visibility = Visibility.Collapsed;
                        lbSchoolList.Visibility = Visibility.Collapsed;

                        dtSchoolList.Clear();
                        dtSchoolList = objClient.ISA_GetBusinessSchoolsList(RegID);
                        DataRow[] drDeleteList = Properties.Settings.Default.DataTableNotifications.Select("Profile_ID=" + ProfileID);
                        if (drDeleteList.Length > 0)
                        {
                            Thread deleteThread = new System.Threading.Thread(delegate ()
                          {
                              Common.DeleteRows(drDeleteList);
                          });
                            deleteThread.Start();
                        }

                    }
                    if (grdFavorites.Items.Count <= 0)
                        lblemptyRows.Visibility = Visibility.Visible;
                    else
                        lblemptyRows.Visibility = Visibility.Collapsed;
                }
            }
            else
                MessageBox.Show("Network Connection failed");

        }
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (Common.IsNetworkAvailable())
            {
                DataRowView rowview = grdFavorites.SelectedItem as DataRowView;
                string ProfileID = rowview.Row["ProfileID"].ToString();
                bool chkStatus = Convert.ToBoolean(rowview.Row["IsNotificationsOn"].ToString());

                if (chkStatus == true)
                {
                    if (MessageBox.Show("Are you sure you want to turn OFF notifications?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        int i = objClient.ISA_UpdateNotifications_OnOff(RegID, ProfileID, "0");//Zero indicates Notification Off(False)

                    }

                }
                if (chkStatus == false)
                {
                    if (MessageBox.Show("Are you sure you want to turn ON notifications?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        int i = objClient.ISA_UpdateNotifications_OnOff(RegID, ProfileID, "1");//Zero indicates Notification On(True)

                    }
                }


                FavoriteDataBind();
            }
            else
                MessageBox.Show("Network Connection failed");
        }

        private void FavoriteDataBind()
        {
            dtFavoriteList = objClient.ISA_GetProfileDetailsOnRegID(RegID, "0");

            grdFavorites.ItemsSource = null;
            grdFavorites.ItemsSource = dtFavoriteList.DefaultView;
        }
    }
}
