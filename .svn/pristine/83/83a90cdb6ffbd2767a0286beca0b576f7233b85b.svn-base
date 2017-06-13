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

namespace USPDHubClientAlerts
{
    public partial class MDIParentPage : Form
    {
        UserDetails objUserDetails = new UserDetails();
        public Login loginWindow;

        public MDIParentPage()
        {
            InitializeComponent();

        }
        public MDIParentPage(UserDetails puserDetais)
        {
            InitializeComponent();

            objUserDetails = puserDetais;
            ShowTipsWindow();
            
        }

        public void ShowTipsWindow()
        {
            MobileAppAlerts appAlertWindow = new MobileAppAlerts(objUserDetails);
            appAlertWindow.MdiParent = null;
            appAlertWindow.MdiParent = this;
            appAlertWindow.parentPage = this;
            appAlertWindow.Show();
            appAlertWindow.BringToFront();
            appAlertWindow.WindowState = FormWindowState.Maximized;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (loginWindow != null)
            {
                loginWindow.Hide();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsWindow = new Settings(objUserDetails);
            settingsWindow.MdiParent = null;
            settingsWindow.MdiParent = this;
            settingsWindow.parentPage = this;
            settingsWindow.Show();
        }

        private void alertsMenuItem_Click(object sender, EventArgs e)
        {
            MobileAppAlerts appAlertWindow = new MobileAppAlerts(objUserDetails);
            appAlertWindow.MdiParent = null;
            appAlertWindow.MdiParent = this;
            if (appAlertWindow.WindowState != FormWindowState.Maximized)
            {
                appAlertWindow.WindowState = FormWindowState.Maximized;
            }
            appAlertWindow.Show();
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\USPDHubClientAlerts";
                //for deleting files
                if (Directory.Exists(path))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true); //delete subdirectories and files
                    }
                    di.Refresh();
                }

                Notification noti = new Notification();
                noti.HideTrayIcon();
                noti.Hide();
                this.Refresh();

                Application.Exit();
                Application.ExitThread();

                Application.Restart();

            }
            catch (Exception ex)
            {
                Notification noti = new Notification();
                noti.HideTrayIcon();
                noti.Hide();

                this.Refresh();
                Application.Exit();
                Application.ExitThread();

                Application.Restart();
            }
        }

        private void MDIParentPage_Load(object sender, EventArgs e)
        {
            string iconPath = EncryptDecrypt.GetFormImageUrl();
            System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
            this.Icon = ico;

            string DomainName = ConfigurationManager.AppSettings.Get("DomainName");
            this.Text = DomainName + " Message Center";
        }

        private void alertSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageAudioFiles audioFileWindow = new ManageAudioFiles(objUserDetails);
            audioFileWindow.MdiParent = null;
            audioFileWindow.MdiParent = this;
            audioFileWindow.Show(); 
            audioFileWindow.BringToFront();
            audioFileWindow.WindowState = FormWindowState.Maximized;
        }

    }
}
