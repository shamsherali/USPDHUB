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
using POC.POC_Utilities;
using System.Configuration;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace POC.Business
{
    /// <summary>
    /// Interaction logic for ModuleContent.xaml
    /// </summary>
    public partial class ModuleContent : Page
    {
        USPDhubClientService.ClientServiceSoapClient objService = new USPDhubClientService.ClientServiceSoapClient();
        public int ProfileID = 0;
        public int UserID = 0;

        public int CUserID = 0;

        public string StrPreviewHTML = "";
        public string StrEditHTML = "";

        public string DomainVertical = "";

        private ProgressBarWindow pbw = null;

        public int i = 1;

        public string RootPath = "";


        public ModuleContent()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(ModuleContent_Loaded);
        }

        void ModuleContent_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ProfileID = Properties.Settings.Default.ProfileID;
                UserID = Properties.Settings.Default.UserID;

                if (App.C_USER_ID != 0)
                {
                    CUserID = App.C_USER_ID;
                }
                else
                {
                    CUserID = UserID;
                }

                RootPath = objService.GetConfigSettingByPID(ProfileID.ToString(), "Paths", "RootPath");

                var strModuleTypes = objService.GetModuleTypes(UserID.ToString(), ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString());
                IList<POC_Utilities.ModuleTypes> moduleTypeList = new List<POC_Utilities.ModuleTypes>();
                for (int i = 0; i < strModuleTypes.Length; i++)
                {
                    string[] sValues = strModuleTypes[i].ToString().Split(new string[] { "##" }, StringSplitOptions.None);
                    if (sValues[1].ToString() != "")
                        ddlModuleype.Items.Add(new ComboBoxItem { Content = sValues[1].ToString(), Tag = sValues[0].ToString() });
                }
                ddlModuleype.SelectedIndex = 0;

                rbUnPublish.IsChecked = true;
                txtTitle.Text = App.FileTitle;
                App.FileTitle = "";

                dtPublishDate.Text = DateTime.Now.ToShortDateString();


                // Preivew Images 
                preview.NavigateToString(App.strPreviewHTML);
                

                /*
                 * spPreviewImage.Children.Clear();
                for (int i = 1; i <= App._PageCount; i++)
                {
                    string imgPath = RootPath + "/Upload/Bulletins/Templates/" + ProfileID + "/Template/" + i + "_" + App.FileFullName;
                    var uri = new Uri(imgPath);

                    Image objImage = new Image();
                    objImage.Source = new BitmapImage(uri);

                    spPreviewImage.Children.Add(objImage); 
                }
                */

                /*
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                GC.Collect();
                string folderPath = "C://POC//";
                string fileFullpath = folderPath + "" + App.FileFullName;
                FileStream filestream = new FileStream(fileFullpath, FileMode.Open);
                image.StreamSource = filestream;
                image.DecodePixelWidth = 200;
                image.DecodePixelHeight = 200;
                image.EndInit(); 
                imgPreview.Source = image;
                filestream.Dispose();
                filestream.Close();
                */

            }
            catch (Exception ex)
            {

            }
        }

        private void rbUnPublish_Click(object sender, RoutedEventArgs e)
        {
            tbErrorMessage.Text = "";
            if (rbPublish.IsChecked == true)
            {
                spPublishDate.Visibility = Visibility.Visible;
            }
            else
            {
                spPublishDate.Visibility = Visibility.Collapsed;
            }
        }

        void splashAnimationTimer_Tick(object sender, EventArgs e)
        {
            //loading.Content = i++;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            OnWorkerMethodStart();
        }

        private bool ValidatePublishDate()
        {
            bool _result = true;
            if (rbPublish.IsChecked == true && dtPublishDate.Text.Trim() != string.Empty)
            {
                DateTime dtToday = objService.ConvertToUserTimeZone(ProfileID);
                if (DateTime.Compare(Convert.ToDateTime(dtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
                {
                    tbErrorMessage.Text = "Publish date should be equal or later than current date.";
                    _result = false;
                }
            }

            return _result;
        }

        private bool ValidateExpiryDate()
        {
            bool _result = true;
            if (dtExpirationhDate.Text.Trim() != string.Empty)
            {
                DateTime dtToday = objService.ConvertToUserTimeZone(ProfileID);
                string inputString = dtExpirationhDate.Text;
                DateTime dDate;
                if (!DateTime.TryParse(inputString, out dDate))
                {
                    tbErrorMessage.Text = "Invalid Date Format.";
                    _result = false;
                }
                else if (DateTime.Compare(Convert.ToDateTime(dtExpirationhDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
                {
                    tbErrorMessage.Text = "Expiration date should be equal or later than current date.";
                    _result = false;
                }

            }

            return _result;
        }

        private bool CheckingValidation()
        {

            bool _result = true;
            try
            {
                tbErrorMessage.Text = "";
                if (txtTitle.Text.Trim() == string.Empty)
                {
                    tbErrorMessage.Text = "Title is mandatory.";
                    txtTitle.Focus();
                    _result = false;
                }
                else if (rbPublish.IsChecked == true && dtPublishDate.Text.Trim() == string.Empty)
                {
                    tbErrorMessage.Text = "Publish Date is mandatory.";
                    _result = false;
                }
            }
            catch (Exception ex)
            {

            }

            return _result;
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
            btnSubmit.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
            new Action(
            delegate()
            {
                tbErrorMessage.Text = "";
                DomainVertical = ConfigurationManager.AppSettings.Get("CountryVerticalName");

                if (CheckingValidation() && ValidateExpiryDate() && ValidatePublishDate())
                {
                    DataSave();
                    loadingControl.Visibility = Visibility.Collapsed;
                }
                else
                {
                    loadingControl.Visibility = Visibility.Collapsed;
                }

                // Publish bar
                //pbw.Close();

            }
            ));

        }

        private void DataSave()
        {
            int _resultID = 0;
            DateTime? publishDate;

            publishDate = null;

            DateTime? expiryDate;
            expiryDate = null;
            if (dtExpirationhDate.Text.Trim() != string.Empty)
            {
                expiryDate = Convert.ToDateTime(dtExpirationhDate.Text + " 11:59:00 PM");
            }

            ComboBoxItem objModuleTypes = ddlModuleype.SelectedItem as ComboBoxItem;
            string moduleTypeName = objModuleTypes.Tag.ToString();

            string draggedFileName = App.FileFullName;



            StrEditHTML = "<table id=\"maintable\" cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" "
                + App.strEditHTML + "</table>";

            StrPreviewHTML = App.strPreviewHTML;


            if (moduleTypeName == "Bulletins")
            {

                DateTime? datePublish;
                datePublish = null;

                bool isArchive = false;
                bool isCall = true;
                bool isPhotoCapture = false;
                bool isContactUs = true;
                int? id = null;
                bool isPublish = Convert.ToBoolean(rbUnPublish.IsChecked);

                bool isPrivate = true;
                if (rbUnPublish.IsChecked == true)
                    isPrivate = false;

                if (dtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(dtPublishDate.Text.Trim());
                }


                if (rbUnPublish.IsChecked == true)
                    datePublish = null;


                StrEditHTML = StrEditHTML.Replace("'", "\"").Replace("’", "");

                string bulletinTitle = txtTitle.Text.Trim();

                //roles & permissions..
                if (App.C_USER_ID != 0)
                {
                    if (App.PermissionType == "A")
                    {
                        _resultID = objService.InsertBulletinDetails(0, 0, bulletinTitle, StrPreviewHTML,
                        StrEditHTML, CUserID, CUserID, isArchive, UserID, ProfileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish,
                        "", false, id, "", "", "");
                        if (isPrivate == true)
                            objService.SendAuthorNotifications(App.C_USER_NAME.ToString(), _resultID, "bulletin", UserID, App.Username,
                                ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString(), App.C_USER_ID.ToString(), RootPath);
                    }
                    else if (App.PermissionType == "P")
                    {
                        if (isPrivate == true)
                        {
                            _resultID = objService.InsertBulletinDetails(0, 0, bulletinTitle, StrPreviewHTML,
                            StrEditHTML, CUserID, CUserID, isArchive, UserID, ProfileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate,
                            datePublish, "", isPrivate, CUserID, "", "", "");
                        }
                        else
                        {
                            _resultID = objService.InsertBulletinDetails(0, 0, bulletinTitle, StrPreviewHTML,
                            StrEditHTML, CUserID, CUserID, isArchive, UserID, ProfileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate,
                            datePublish, "", isPrivate, id, "", "", "");
                        }
                    }
                }
                else
                {
                    if (isPrivate == true)
                    {
                        _resultID = objService.InsertBulletinDetails(0, 0, bulletinTitle, StrPreviewHTML,
                        StrEditHTML, CUserID, CUserID, isArchive, UserID, ProfileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish,
                        "", isPrivate, CUserID, "", "", "");
                    }
                    else
                    {
                        _resultID = objService.InsertBulletinDetails(0, 0, bulletinTitle, StrPreviewHTML,
                        StrEditHTML, CUserID, CUserID, isArchive, UserID, ProfileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish,
                        "", isPrivate, id, "", "", "");
                    }
                }

            }
            else if (moduleTypeName == "Updates")
            {

                #region  Data Save

                string title = string.Empty;
                string updateName = string.Empty;
                bool updateStatus = true;
                bool isPublic = false;


                publishDate = null;
                int? id = null;
                title = txtTitle.Text.Trim();
                string EditHtml = StrEditHTML;
                string BusinessDesc = StrPreviewHTML;
                string ListDescription = "";

                bool isCall = true;
                bool isContatUs = true;


                if (rbPublish.IsChecked == true)
                    isPublic = true;

                if (dtPublishDate.Text != string.Empty)
                {
                    publishDate = Convert.ToDateTime(dtPublishDate.Text);
                }


                //roles & permissions..

                if (App.C_USER_ID != 0)
                {
                    if (App.PermissionType == "A")
                    {
                        _resultID = objService.InsertBusinessUpdateDetailsNew(0, ProfileID, title, updateStatus, BusinessDesc, updateName, false, isPublic,
                              CUserID, publishDate, EditHtml, id, ListDescription, expiryDate, isCall, isContatUs, UserID);
                        if (isPublic == true)
                            objService.SendAuthorNotifications(App.C_USER_NAME.ToString(), _resultID, "Update", UserID, App.Username,
                                ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString(), App.C_USER_ID.ToString(), RootPath);
                    }
                    else if (App.PermissionType == "P")
                    {
                        if (isPublic == true)
                            _resultID = objService.InsertBusinessUpdateDetailsNew(0, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                                CUserID, publishDate, EditHtml, CUserID, ListDescription, expiryDate, isCall, isContatUs, UserID);
                        else
                            _resultID = objService.InsertBusinessUpdateDetailsNew(0, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                                CUserID, publishDate, EditHtml, id, ListDescription, expiryDate, isCall, isContatUs, UserID);
                    }
                }
                else
                {
                    if (isPublic == true)
                        _resultID = objService.InsertBusinessUpdateDetailsNew(0, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                            CUserID, publishDate, EditHtml, CUserID, ListDescription, expiryDate, isCall, isContatUs, UserID);
                    else
                        _resultID = objService.InsertBusinessUpdateDetailsNew(0, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                            CUserID, publishDate, EditHtml, id, ListDescription, expiryDate, isCall, isContatUs, UserID);
                }
                #endregion
            }


            // pbw.loading.tb1.Text = "Publishing to app";
            //Thread.Sleep(1000 * 5);

            // After Web Service Call Completed
            if (_resultID > 0)
            {
                loading.Visibility = Visibility.Visible;
                tbMessage.Text = "Your file has been successfully uploaded";
                spGotoMainScreen.Visibility = Visibility.Visible;
                spContent.Visibility = Visibility.Collapsed;

                string musicfilePath = RootPath + "/Upload/POCAudio/" + ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString() + "/datasave.wav";
                Uri objUri = new Uri(musicfilePath);
                player.Source = objUri;

                loadingControl.Visibility = Visibility.Collapsed;
            }
        }

        private void btnGotoMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Business/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Business/Dashboard.xaml", UriKind.RelativeOrAbsolute));
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
