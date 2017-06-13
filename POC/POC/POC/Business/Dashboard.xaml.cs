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
using System.IO;
using System.Data;
//using Aspose.Pdf;
//using Aspose.Pdf.Devices;
//using Aspose.Words;
//using Aspose.Words.Saving;
//using Aspose.Words.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using POC.POC_Utilities;
using Microsoft.Win32;
//using Neodynamic.SDK.ImageDraw;

using Spire.Doc;
using Spire.Doc.Fields;
using Spire.Doc.Documents;



namespace POC.Business
{



    /// <summary>
    /// Interaction logic for FileHistory.xaml
    /// </summary>
    public partial class Dashboard : System.Windows.Controls.Page
    {
        DataTable dtFileContentHistory = new DataTable("dtFilehistory");

        public string selectedFileName = "";

        public string Title = "";
        public string Extension = "";

        USPDhubClientService.ClientServiceSoapClient objService = new USPDhubClientService.ClientServiceSoapClient();
        public int ProfileID = 0;
        public int UserID = 0;

        private ProgressBarWindow pbw = null;

        public Window parentWindow = null;

        public DataTable Dtpermissions = new DataTable();

        public string RootPath = string.Empty;

        public Dashboard()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Dashboard_Loaded);
        }

        void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            lbFileList.Items.Clear();

            ProfileID = Properties.Settings.Default.ProfileID;
            UserID = Properties.Settings.Default.UserID;

            // Upload History
            dtFileContentHistory = objService.GetPOC_ModuleContentHistory(ProfileID);
            dgHistory.ItemsSource = null;
            dgHistory.ItemsSource = dtFileContentHistory.AsDataView();

            RootPath = objService.GetConfigSettingByPID(ProfileID.ToString(), "Paths", "RootPath");

            if (App.IsExpiryAccount == true)
            {
                spDrag.Visibility = Visibility.Collapsed;
                tbMessage.Visibility = Visibility.Visible;
                tbMessage.Text = "Your subscription has expired.";
            }
            else if (App.C_USER_ID != 0)
            {
                Dtpermissions = objService.GetPermissionsById(Convert.ToInt32(App.C_USER_ID));
                if (Dtpermissions.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtpermissions.Rows.Count; i++)
                    {
                        App.PermissionValue = Convert.ToInt32(Dtpermissions.Rows[i]["Permission_Values"].ToString());
                        if (Convert.ToBoolean(App.PermissionValue & Constants.BULLETINS))
                        {
                            App.PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                        }
                        if (Convert.ToBoolean(App.PermissionValue & Constants.UPDATES))
                        {
                            App.PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                        }
                    }
                }
                if (string.IsNullOrEmpty(App.PermissionType))
                {
                    spDrag.Visibility = Visibility.Collapsed;
                    tbMessage.Visibility = Visibility.Visible;
                    tbMessage.Text = "You have no privileges to create or edit bulletins/updates.";
                }
            }
        }


        private void SPFileDrop_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var a = e.Data.GetData(DataFormats.Html, true);
                var b = e.Data.GetData("FileName", true);
                var c = e.Data.GetFormats();
                ;

                string[] droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                if (droppedFilePaths.Length > 1)
                {
                    MessageBox.Show(App.ParentWindow, "Multiple files are not allowed.");
                }
                else
                {
                    lbFileList.Items.Clear();
                    foreach (var path in droppedFilePaths)
                    {
                        string fileExtension = System.IO.Path.GetExtension(path).ToLower();
                        //if (fileExtension == ".docx" || fileExtension == ".doc" || fileExtension == ".pdf" || fileExtension == ".epub" || fileExtension == ".png"
                        //    || fileExtension == ".jpeg" || fileExtension == ".jpg")
                        if (fileExtension == ".docx" || fileExtension == ".doc")
                        {
                            //file has correct extension, do something with file
                            selectedFileName = System.IO.Path.GetFileName(path);
                            lbFileList.Items.Add(new ListBoxItem { Content = path });

                            string musicfilePath = RootPath + "/Upload/POCAudio/" + ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString() + "/filedrop.wav";
                            Uri objUri = new Uri(musicfilePath);
                            player.Source = objUri;
                        }
                        else
                        {
                            MessageBox.Show(App.ParentWindow, "Incorrect file format.");
                        }

                    }
                }
            }
        }


        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lbFileList.Items.Count == 0)
            {
                MessageBox.Show(App.ParentWindow, "Please select your file.");
            }
            else
            {
                OnWorkerMethodStart();
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
            ////pbw.Topmost = true;
            //pbw.ShowDialog();


            loading.Visibility = Visibility.Visible;

        }

        private void OnWorkerMethodComplete(string message)
        {
            btnNext.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
            new Action(
            delegate()
            {
                DraggedFilesUpload();
                loading.Visibility = Visibility.Collapsed;
            }
            ));

        }

        private void DraggedFilesUpload()
        {
            try
            {
                var item = lbFileList.Items[0] as ListBoxItem;

                #region  Conversation File to Images

                var path = item.Content.ToString();
                selectedFileName = System.IO.Path.GetFileName(path);
                App.FileTitle = selectedFileName.Substring(0, selectedFileName.LastIndexOf('.'));

                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\POC";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string Extension = selectedFileName.Substring(selectedFileName.LastIndexOf('.')).ToLower();
                string draggedFileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".png";
                string myNewpath = "";
                App.FileFullName = draggedFileName;
                int _pageCount = 0;


                if (Extension == ".docx" || Extension == ".doc")
                {
                    Document document = null;
                    document = new Document(path, Spire.Doc.FileFormat.Txt, XHTMLValidationType.None);
                    //_pageCount = document.PageCount;

                    myNewpath = folderPath + "\\" + draggedFileName;
                    Word_WriteImages_Text(myNewpath, document);

                    App.strPreviewHTML = "<table style=\"margin-left:20px; border:1px solid black;\" border=\"0\" >" + App.strPreviewHTML + "</table>";
                }
                else
                {
                    MessageBox.Show(App.ParentWindow, "Incorrect file format.");
                    return;
                }
                /*
             else if (Extension == ".jpeg" || Extension == ".jpg" || Extension == ".png")
             {
                 App._PageCount = 1;
                 _pageCount = 1;
                 myNewpath = folderPath + "\\" + "1_" + draggedFileName;
                 File.Copy(path, myNewpath);
             }
          */
                //Thread.Sleep(100);


                try
                {  //E:\USPDhub\USPDhub\POC\POC\bin\Debug
                    string myExeDir = "C:";
                    myExeDir = myExeDir + "\\Upload";
                    if (Directory.Exists(myExeDir))
                    {
                        Directory.Delete(myExeDir, true);
                    }
                }
                catch (Exception ex) { }
                #endregion

                //
                NavigationService.Navigate(new Uri("Business/ModuleContent.xaml", UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }



        }

        private string Word_WriteImages_Text(string pFilePath, Document document)
        {
            StringBuilder htmlStr = new StringBuilder();
            StringBuilder previewStr = new StringBuilder();
            //<table style='margin-left:20px; border:1px solid black;' border='0'  >" + tds + "</table>

            try
            {
                IList<Field> hyperlinks = new List<Field>();

                int index = 1;

                foreach (Spire.Doc.Section section in document.Sections)
                {
                    foreach (Spire.Doc.Documents.Paragraph paragraph in section.Paragraphs)
                    {
                        string ParaText = paragraph.Text.Trim();

                        hyperlinks = new List<Field>();
                        if (paragraph.Text.Trim() != string.Empty)
                        {
                            foreach (DocumentObject docObject in paragraph.ChildObjects)
                            {
                                if (docObject.DocumentObjectType == DocumentObjectType.Field)
                                {
                                    Field field = docObject as Field;
                                    if (field.Type == FieldType.FieldHyperlink)
                                    {
                                        if (field.FieldText.Trim() != string.Empty)
                                        {
                                            ParaText = ParaText.Replace(field.FieldText, "####");
                                            ParaText = ParaText.Replace("########", "<a href=" + field.Value.ToString() + " >" + field.FieldText + "</a>");
                                            ParaText = ParaText.Replace("####", "<a href=" + field.Value.ToString() + " >" + field.FieldText + "</a>");
                                        }//
                                    }//
                                }//
                            }//


                            ParaText = ParaText.Replace("\v", "");

                            TextAppend(htmlStr, "TEXT", 0, ParaText, string.Empty, index);
                            previewStr.Append("<tr><td  style=\"width: 300px; padding-bottom: 2px; text-align: left;\">" + ParaText + " </td></tr>");

                            index++;
                        }

                        //E:\USPDhub\USPDhub\POC\POC\bin\Debug
                        string myExeDir = "C:";
                        myExeDir = myExeDir + "\\Upload";
                        if (!Directory.Exists(myExeDir))
                            Directory.CreateDirectory(myExeDir);

                        string imgName = "";

                        foreach (DocumentObject docObject in paragraph.ChildObjects)
                        {
                            if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                            {
                                DocPicture pic = docObject as DocPicture;
                                try
                                {
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                    imgName = DateTime.Now.ToString("yyyyMMddHHmmss") + "" + DateTime.Now.Millisecond + "" + index.ToString() + ".png";
                                    pic.Image.Save(myExeDir + "\\" + imgName, System.Drawing.Imaging.ImageFormat.Png);
                                }
                                catch (Exception ex)
                                { }


                                string imgFullPath = RootPath + "\\Upload\\Bulletins\\Templates\\" + ProfileID + "\\Template\\" + imgName;
                                TextAppend(htmlStr, "IMAGE", pic.Image.Width, string.Empty, imgFullPath, index);

                                if (pic.Image.Width >= 300)
                                {
                                    previewStr.Append("<tr><td  style=\"width: 300px; padding-bottom: 2px; text-align: left; padding-bottom: 2px; text-align:left;\"><img src=\"" + imgFullPath + "\" width=\"300px\" /></td></tr>");
                                }
                                else
                                {
                                    previewStr.Append("<tr><td  style=\"padding-bottom: 2px; text-align: left; padding-bottom: 2px; text-align:left;\"><img src=\"" + imgFullPath + "\"  /></td></tr>");
                                }

                                index++;


                                #region file upload

                                try
                                {
                                    GC.Collect();
                                    using (FileStream filestream = new FileStream(myExeDir + "\\" + imgName, FileMode.Open))
                                    {
                                        BinaryReader br = new BinaryReader(filestream);
                                        var bytes = br.ReadBytes((Int32)filestream.Length);
                                        objService.UploadPOCImage(bytes, ProfileID.ToString(), imgName);
                                        br.Close();
                                        filestream.Dispose();
                                        filestream.Close();
                                    }

                                }
                                catch (Exception ex)
                                {
                                    GC.Collect();
                                }

                                #endregion
                            }

                        }
                    }
                }


                document.Close();

            }
            catch (Exception ex)
            {

            }

            App.strEditHTML = htmlStr.ToString();
            App.strPreviewHTML = previewStr.ToString();

            return htmlStr.ToString();
        }



        private void TextAppend(StringBuilder htmlStr, string blocktype, int imgWidth, string paragraphText, string imgFullPath, int index)
        {
            if (blocktype == "TEXT")
            {
                htmlStr.Append("<tr id=\"tr" + index + "\">");
                htmlStr.Append("<td class=\"drop ui-sortable\" style=\"min-height: 20px;\">");
                htmlStr.Append("<div id=\"parentedit" + index + "\" style=\"float: left; margin-top: 10px;\" class=\"assigned\" >");
                htmlStr.Append("<div id='edit" + index + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >");
                htmlStr.Append("<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family:14px; text-align: left; display: block;'>" + paragraphText + "</span>");
                htmlStr.Append("</div>");
                htmlStr.Append("<div id='editsection" + index + "' class='editsectionclass' style='float:left;' >");
                htmlStr.Append("<img src='../../Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + index + ")' />");
                htmlStr.Append("<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + index + ")' />");
                htmlStr.Append("</div>");
                htmlStr.Append("</div>");
                htmlStr.Append("</td>");
                htmlStr.Append("</tr>");
            }
            else if (blocktype == "IMAGE")
            {
                htmlStr.Append("<tr id=\"tr" + index + "\">");
                htmlStr.Append("<td class=\"drop ui-sortable\" style=\"min-height: 20px;\">");
                htmlStr.Append("<div id=\"parentedit" + index + "\" style=\"float: left; margin-top: 10px;\" class=\"assigned\" >");
                htmlStr.Append("<div id='edit" + index + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >");

                if (imgWidth >= 300)
                {
                    htmlStr.Append("<img src='" + imgFullPath + "' width='300px' /> ");
                }
                else
                {
                    htmlStr.Append("<img src='" + imgFullPath + "'  /> ");
                }
                htmlStr.Append("</div>");
                htmlStr.Append("<div id='editsection" + index + "' class='editsectionclass' style='float:left;' >");
                htmlStr.Append("<img  src='../../Images/EditImage.png'  style='cursor: pointer; margin-left:5px;' onclick='EditImage(edit" + index + ")' />");
                htmlStr.Append("<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + index + ")' />");
                htmlStr.Append("</div>");
                htmlStr.Append("</div>");
                htmlStr.Append("</td>");
                htmlStr.Append("</tr>");
            }
        }

        private void SPFileDrop_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {


        }

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            //openFileDialog.Filter = "|*.png;*.jpeg;*.jpg;*.pdf;*.doc;*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                string droppedFilePaths = openFileDialog.FileName;
                lbFileList.Items.Clear();

                string fileExtension = System.IO.Path.GetExtension(droppedFilePaths).ToLower();
                if (fileExtension == ".docx" || fileExtension == ".doc" || fileExtension == ".pdf" || fileExtension == ".epub" || fileExtension == ".png"
                    || fileExtension == ".jpeg" || fileExtension == ".jpg")
                {
                    //file has correct extension, do something with file
                    selectedFileName = System.IO.Path.GetFileName(droppedFilePaths);
                    lbFileList.Items.Add(new ListBoxItem { Content = droppedFilePaths });

                    string musicfilePath = RootPath + "/Upload/POCAudio/" + ConfigurationManager.AppSettings.Get("CountryVerticalName").ToString() + "/filedrop.wav";
                    Uri objUri = new Uri(musicfilePath);
                    player.Source = objUri;
                }
                else
                {
                    MessageBox.Show(App.ParentWindow, "Incorrect file format.");
                }
            }
        }
    }
}
