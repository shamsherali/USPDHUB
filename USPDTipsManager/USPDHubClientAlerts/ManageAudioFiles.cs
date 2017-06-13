using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Media;

namespace USPDHubClientAlerts
{
    public partial class ManageAudioFiles : Form
    {
        string ClientServicURL = ConfigurationManager.AppSettings.Get("ClientServiceURL");
        ClientService.ClientServiceSoapClient objService = new ClientService.ClientServiceSoapClient();

        UserDetails objUserDetails = new UserDetails();

        public string DomainName = ConfigurationManager.AppSettings.Get("CountryVerticalName");

        public ManageAudioFiles(UserDetails puserDetais)
        {
            InitializeComponent();
            //Load += new EventHandler();
            objUserDetails = puserDetais;
            LoadAudio();
        }

        void LoadAudio()
        {
            string iconPath = EncryptDecrypt.GetFormImageUrl();
            System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
            this.Icon = ico;

            this.Text = Utilities.AgencyName;

            dgAudio.AutoGenerateColumns = false;
            DataTable dtAudios = new DataTable();
            dtAudios = objService.GetAudioTipsManager(objUserDetails.ProfileID, objUserDetails.UserID, DomainName);

            if (!dtAudios.Columns.Contains("Play"))
            {
                //dtAudios.Columns.Add("Play");
            }
            if (!dtAudios.Columns.Contains("Delete"))
            {
                dtAudios.Columns.Add("Delete");
                for (int i = 0; i < dtAudios.Rows.Count; i++)
                {
                    if (dtAudios.Rows[i]["DefaultID"] != null && Convert.ToInt32(dtAudios.Rows[i]["DefaultID"]) > 0)
                        dtAudios.Rows[i]["Delete"] = "";
                    else //&& Convert.ToBoolean(dtAudios.Rows[i]["IsDefault"].ToString()) == false
                        dtAudios.Rows[i]["Delete"] = "Delete";
                }
            }
            if (!dtAudios.Columns.Contains("Set As Default"))
                dtAudios.Columns.Add("Set As Default");

            dgAudio.DataSource = dtAudios;
        }

        private void dgAudio_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int audioID, DefaultAudioID;
                string audioFile = "", AudioType = "";
                bool isDefault;
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    audioID = Convert.ToInt32(dgAudio.Rows[e.RowIndex].Cells[0].Value);
                    audioFile = Convert.ToString(dgAudio.Rows[e.RowIndex].Cells[5].Value);
                    isDefault = Convert.ToBoolean(dgAudio.Rows[e.RowIndex].Cells[6].Value);
                    DefaultAudioID = Convert.ToInt32(dgAudio.Rows[e.RowIndex].Cells[7].Value);
                    //AudioType = Convert.ToString(dgAudio.Rows[e.RowIndex].Cells[8].Value);
                    if (e.ColumnIndex == 2) //Play 
                    {
                        if (DefaultAudioID < 1)
                            AudioType = "UserAudio";
                        string audioPath = objService.PlayAudioTipsManager(AudioType, objUserDetails.ProfileID, audioFile, DomainName);
                        SoundPlayer sp = new SoundPlayer(audioPath);
                        sp.Play();
                    }
                    if (e.ColumnIndex == 3) //Delete 
                    {
                        if (isDefault)
                        {
                            MessageBox.Show("This audio is set as default audio for tips manager, So please change the status and delete it.");
                        }
                        else
                        {
                            objService.DeleteAudioTipsManager(audioID);
                            LoadAudio();
                            MessageBox.Show("This audio file has been deleted successfully.");
                        }
                    }
                    if (e.ColumnIndex == 4) // Set As Default
                    {
                        if (DefaultAudioID < 1)
                            AudioType = "UserAudio";
                        else
                            AudioType = "SystemAudio";
                        objService.InsertUpdateAudioTipsManager(audioID, objUserDetails.ProfileID, objUserDetails.UserID, string.Empty, audioFile, true, DefaultAudioID, AudioType);
                        LoadAudio();
                        MessageBox.Show("This audio file has been set as default successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "ManageAudioFiles.cs", "dgAudio_CellContentClick_1", Convert.ToString(ex.Message),
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Tips Manager");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = false;
            op1.Filter = "|*.wav";
            DialogResult result = op1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFilePath.Text = op1.FileName;
                txtFileName.Text = System.IO.Path.GetFileName(txtFilePath.Text).ToString().Replace(".wav", "");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != string.Empty && txtFileName.Text != "")
            {
                if (txtFilePath.Text != "" && txtFilePath.Text.ToString().Length > 1)
                {
                    FileInfo pict1obj = new FileInfo(txtFilePath.Text.ToString());
                    long FileSize = pict1obj.Length;
                    double dLen = Convert.ToDouble(pict1obj.Length / 1000000);
                    if (dLen <= 2)
                    {
                        if (pict1obj.Extension == ".wav")
                        {
                            try
                            {
                                bool defaultAudio = false;
                                if (chkDefault.Checked)
                                    defaultAudio = true;

                                // ****** Convert File Name to Stream ******//
                                FileStream fStream = new FileStream(txtFilePath.Text.ToString(), FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fStream);
                                byte[] data = br.ReadBytes((Int32)FileSize);
                                br.Close();
                                objService.UploadAudioFiles(data, txtFileName.Text, System.IO.Path.GetFileName(txtFilePath.Text), objUserDetails.UserID, objUserDetails.ProfileID, defaultAudio, DomainName);
                                fStream.Dispose();
                                fStream.Close();
                                chkDefault.Checked = false;
                                txtFileName.Text = "";
                                txtFilePath.Text = "";
                                LoadAudio();
                                MessageBox.Show("Your audio file has been uploaded successfully.");
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                            MessageBox.Show("Please select wav files only.");
                    }
                    else
                        MessageBox.Show("Your file was not uploaded because it exceeds the maximum size.");
                }
                else
                    MessageBox.Show("Please select an audio file to upload.");
            }
            else
            {
                if (txtFilePath.Text == "")
                    MessageBox.Show("Please enter an audio file name.\nPlease select an audio file to upload.");
                else
                    MessageBox.Show("Please enter an audio file name.");
            }
        }

        private void dgAudio_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgAudio.Rows)
            {
                if (Convert.ToBoolean(row.Cells["IsDefault"].Value) == true)
                    row.DefaultCellStyle.BackColor = Color.Gray;
            }
        }
    }
}
