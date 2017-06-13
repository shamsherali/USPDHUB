using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for ManageAudio.xaml
    /// </summary>
    public partial class ManageAudio : Page
    {

        ISAService.ClientServiceSoapClient objService = new ISAService.ClientServiceSoapClient();

        public string fileExt = "";
        public string fileUniqueName = "";
        public string fileTitle = "";
        public string fileSelectedPath = "";


        DataTable dtAudioFiles = new DataTable("dtAudioFiles");

        MediaPlayer objMediaEle = null;

        Nullable<bool> result = false;

        private BackgroundWorker bgWorker1 = new BackgroundWorker();
        long numBytes = 0;

        public ManageAudio()
        {
            InitializeComponent();
            loadingControl.tb1.Text = "Uploading..";
            LoadAudioData();
            loadingControl.tb1.Text = "Uploading..";           
        }
        private void brwse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".wav";
            dlg.Filter = "Audio (.wav)|*.wav";

            // Display OpenFileDialog by calling ShowDialog method
            result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                fileSelectedPath = fileUniqueName = dlg.FileName;
                txtAudio.Text = fileSelectedPath;
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            fileExt = System.IO.Path.GetExtension(fileUniqueName);
            ErrorTemplate.Text = "";
             
            if (txtAudioTitle.Text.Trim() == "")
            {
                ErrorTemplate.Text = "Please enter audio title";

            }
            else if (!IsTextAllowed(txtAudioTitle.Text.Trim()))
            {
                ErrorTemplate.Text = "Enter alpha numeric only";
            }
            else if (txtAudio.Text.Trim() == "")
            {
                ErrorTemplate.Text = "Please upload audio file";
            }
            else if (result == false)
            {
                ErrorTemplate.Text = " Please upload audio file";
            }
            else if (fileExt != ".wav")
            {
                ErrorTemplate.Text = " Please upload valid audio file";
            }
            else
            {
                fileTitle = txtAudioTitle.Text.Trim();
                fileUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "" + fileExt;

                try
                {
                    // get the file information form the selected file
                    FileInfo fInfo = new FileInfo(fileSelectedPath);

                    // get the length of the file to see if it is possible
                    // to upload it (with the standard 4 MB limit)
                    numBytes = fInfo.Length;
                    double dLen = Convert.ToDouble(fInfo.Length / 1000000);

                    // Default limit of 4 MB on web server
                    // have to change the web.config to if
                    // you want to allow larger uploads
                    if (dLen <= 4)
                    {
                        loadingControl.Visibility = Visibility.Visible;
                        OnWorkerMethodStart();
                    }
                    else
                    {
                        // Display message if the file was too large to upload
                        MessageBox.Show("The file selected exceeds the size limit for uploads.", "File Size");
                    }
                }
                catch (Exception ex)
                { }

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
            if (Common.IsNetworkAvailable())
            {
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
                new Action(
                delegate ()
                {
                // set up a file stream and binary reader for the
                // selected file
                FileStream fStream = new FileStream(fileSelectedPath,
                    FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                // convert the file to a byte array
                byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                // pass the byte array (file) and file name to the web service 
                dtAudioFiles = objService.ISA_UploadAudioFiles(data, fileTitle, fileUniqueName, Convert.ToInt32(Properties.Settings.Default.RegistrationID), Convert.ToBoolean(chkDefault.IsChecked), "0");
                    fStream.Close();
                    fStream.Dispose();

                // this will always say OK unless an error occurs,
                // if an error occurs, the service returns the error message
                MessageBox.Show("File Uploaded Successfully.");

                    LoadAudioData();
                    ClearTextboxValues();
                    emptyAudioRow.Visibility = Visibility.Collapsed;

                    loadingControl.Visibility = Visibility.Collapsed;
                }
                ));
            }
            else
                MessageBox.Show("Network Connection failed");

        }

        private void LoadAudioData()
        {
            if (Common.IsNetworkAvailable())
            {
                dtAudioFiles = objService.ISA_GetAudioDetails(Properties.Settings.Default.RegistrationID.ToString());
                grdAudioFiles.ItemsSource = null;
                if (dtAudioFiles.Rows.Count > 0)
                {

                    grdAudioFiles.ItemsSource = dtAudioFiles.AsDataView();

                }
                else
                {
                    emptyAudioRow.Visibility = Visibility.Visible;
                }
            }
        }

        private void imgPlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Common.IsNetworkAvailable())
            {
                bool IsPause = false;
                var imgPlay = sender as Image;
                // var imgStop = sender as Image;
                if (objMediaEle != null)
                {
                    if (objMediaEle.CanPause && imgPlay.Tag.ToString().Equals(playurl))
                    { objMediaEle.Play(); IsPause = true; }
                    else if (objMediaEle.CanPause)
                    {
                        objMediaEle.Stop();
                    }
                }

                MediaImageVisibility();

                if (!IsPause)
                {
                    objMediaEle = new MediaPlayer();
                    var playUrl = App.RootPath + imgPlay.Tag.ToString();
                    objMediaEle.Open(new Uri(playUrl));
                    objMediaEle.Play();
                }

                imgPlay.Visibility = Visibility.Collapsed;
                objMediaEle.MediaEnded += ObjMediaEle_MediaEnded;

                StackPanel spAudio = imgPlay.Parent as StackPanel;
                var imgPause = spAudio.FindName("imgPause") as Image;
                imgPause.Visibility = Visibility.Visible;

                var imgStop = spAudio.FindName("imgStop") as Image;
                imgStop.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Network Connection failed");
        }

        private void MediaImageVisibility()
        {
            for (int i = 0; i < grdAudioFiles.Items.Count; i++)
            {
                DataGridCell cell = GetCell(i, 1);
                //  Image tb = cell.Content as Image;
                var cp = (ContentPresenter)cell.Content;
                var pause = (Image)cp.ContentTemplate.FindName("imgPause", cp);
                var play = (Image)cp.ContentTemplate.FindName("imgPlay", cp);
                var stop = (Image)cp.ContentTemplate.FindName("imgStop", cp);
                pause.Visibility = Visibility.Collapsed;
                play.Visibility = Visibility.Visible;
                stop.Visibility = Visibility.Collapsed;
                playurl = "";
            }
        }
        private void ObjMediaEle_MediaEnded(object sender, EventArgs e)
        {
            MediaImageVisibility();
        }

        public DataGridCell GetCell(int row, int column)
        {
            DataGridRow rowContainer = GetRow(row);

            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    grdAudioFiles.ScrollIntoView(rowContainer, grdAudioFiles.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }

        public DataGridRow GetRow(int index)
        {
            DataGridRow row = (DataGridRow)grdAudioFiles.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                grdAudioFiles.UpdateLayout();
                grdAudioFiles.ScrollIntoView(grdAudioFiles.Items[index]);
                row = (DataGridRow)grdAudioFiles.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        string playurl = "";

        private void imgPause_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var imgPause = sender as Image;
            playurl = "";
            if (objMediaEle != null)
                objMediaEle.Pause();

            imgPause.Visibility = Visibility.Collapsed;

            StackPanel spAudio = imgPause.Parent as StackPanel;
            var imgPlay = spAudio.FindName("imgPlay") as Image;            
            playurl = imgPlay.Tag.ToString();
            imgPlay.Visibility = Visibility.Visible;
            var imgStop = spAudio.FindName("imgStop") as Image;
            imgStop.Visibility = Visibility.Collapsed;
        }

        private void imgStop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var imgStop = sender as Image;
            if (objMediaEle != null)
                objMediaEle.Stop();

            StackPanel spAudio = imgStop.Parent as StackPanel;
            var imgPlay = spAudio.FindName("imgPlay") as Image;
            imgPlay.Visibility = Visibility.Visible;

            var imgStopAudio = spAudio.FindName("imgStop") as Image;
            imgStopAudio.Visibility = Visibility.Collapsed;

            var imgPause = spAudio.FindName("imgPause") as Image;
            imgPause.Visibility = Visibility.Collapsed;

            playurl = "";

        }

        private void imgAudioDelete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Common.IsNetworkAvailable())
            {
                if (MessageBox.Show("Are you sure you want to delete?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var imgDelete = sender as Image;
                    string audioID = Convert.ToString(imgDelete.Tag);
                    int deleteAudio = objService.ISA_DeleteAudioFileonRegID((Properties.Settings.Default.RegistrationID).ToString(), audioID);
                    if (deleteAudio > 0)
                    {
                        var imgStop = sender as Image;
                        if (objMediaEle != null)
                            objMediaEle.Stop();
                    }

                    MessageBox.Show("Audio file has been deleted successfully.");
                    LoadAudioData();
                }
            }
            else
                MessageBox.Show("Network Connection failed");
        }

        private void imgAudioDelete_Loaded(object sender, RoutedEventArgs e)
        {
            var imgDelete = sender as Image;
            string audioID = Convert.ToString(imgDelete.Tag);
            DataRow[] drValues = dtAudioFiles.Select("AudioID=" + audioID);


            DataTable dttemp = new DataTable();
            if (drValues.Length > 0)
                dttemp = drValues.CopyToDataTable();

            bool IsDefault = false;
            if (dttemp.Rows.Count > 0)
                IsDefault = Convert.ToBoolean(dttemp.Rows[0]["IsDefault"]);

            if (IsDefault)
                imgDelete.Visibility = Visibility.Collapsed;
            else
                imgDelete.Visibility = Visibility.Visible;


        }

        private void btnSetasDefault_Click(object sender, RoutedEventArgs e)
        {
            if (Common.IsNetworkAvailable())
            {
                if (MessageBox.Show("Are you sure you want to change default audio?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var btnSetasDefault = sender as Button;
                    string audioID = Convert.ToString(btnSetasDefault.Tag);

                    int dtAudioUpdate = objService.ISA_UpdateAudioFiles(Properties.Settings.Default.RegistrationID, audioID);
                    if (dtAudioUpdate > 0)
                    {
                        MessageBox.Show("This audio file has been set as default successfully.");
                    }

                    LoadAudioData();
                }
            }
            else
                MessageBox.Show("Network Connection failed");

        }

        private void btnSetasDefault_Loaded(object sender, RoutedEventArgs e)
        {
            var btnSetasDefault = sender as Button;
            string audioID = Convert.ToString(btnSetasDefault.Tag);
            DataRow[] drValues = dtAudioFiles.Select("AudioID=" + audioID);


            DataTable dttemp = new DataTable();
            if (drValues.Length > 0)
                dttemp = drValues.CopyToDataTable();

            bool IsDefault = false;
            if (dttemp.Rows.Count > 0)
                IsDefault = Convert.ToBoolean(dttemp.Rows[0]["IsDefault"]);

            if (IsDefault)
                btnSetasDefault.Visibility = Visibility.Collapsed;
            else
                btnSetasDefault.Visibility = Visibility.Visible;

        }

        private void ClearTextboxValues()
        {
            txtAudio.Text = "";
            txtAudioTitle.Text = "";
            chkDefault.IsChecked = false;
        }


        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("^[a-zA-Z0-9 ]+$");
            return regex.IsMatch(text);
        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ErrorTemplate.Text = "";
        }

        private void txtAudioTitle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ErrorTemplate.Text = "";
        }
    }


}
