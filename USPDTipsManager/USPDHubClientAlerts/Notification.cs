using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;

namespace USPDHubClientAlerts
{
    public partial class Notification : Form
    {
        UserDetails objUserDetails = new UserDetails();

        public int MessageID { get; set; }

        string ClientServicURL = ConfigurationManager.AppSettings.Get("ClientServiceURL");
        ClientService.ClientServiceSoapClient objService = new ClientService.ClientServiceSoapClient();

        //public int profileID = objUserDetails.ProfileID;

        SoundPlayer sp;


        Timer timer1 = new Timer();
        Timer AppTimer = new Timer();

        public int WindowLeft = 0;
        public int WindowTop = 0;
        public bool flag = false;
        public bool soundFlag = false;

        public Login loginWindow;

        ContextMenu contextMenu1;

        public string audioFile = "";
        public string DomainName = "";

        static int windowCOunt = 0;

        public MDIParentPage objParentMDI = null;

        string PermissionType = "";

        /// <summary>
        /// Constructor
        /// </summary>
        public Notification()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
        }

        /// <summary>
        /// Parameter Constructor
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pProfileID"></param>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        public Notification(int pUserID, int pProfileID, string pUsername, string pPassword, string C_USER_ID)
        {
            InitializeComponent(); //10141            

            LoadAudioPath(pProfileID, ConfigurationManager.AppSettings.Get("CountryVerticalName"));
            sp = new SoundPlayer(audioFile);
            Load += new EventHandler(Alerts_Load);

            objUserDetails.ProfileID = pProfileID;
            objUserDetails.UserID = pUserID;

            objUserDetails.Username = pUsername;
            objUserDetails.Password = pPassword;
            objUserDetails.C_USER_ID = C_USER_ID;


            //Context Menu
            MenuItem exitMenu = new MenuItem();
            exitMenu.Text = "Exit";
            exitMenu.Click += new EventHandler(exitMenu_Click);

            MenuItem OpenMenu = new MenuItem();
            OpenMenu.Text = "Open";
            OpenMenu.Click += new EventHandler(OpenMenu_Click);

            contextMenu1 = new System.Windows.Forms.ContextMenu();
            contextMenu1.MenuItems.Add(OpenMenu);
            contextMenu1.MenuItems.Add(exitMenu);

            notifyIcon1.ContextMenu = contextMenu1;

            //HideWindow();
            if (loginWindow != null)
            {
                loginWindow.Hide();
            }

            //MessageBox.Show(Properties.Settings.Default.IsTrayIcons.ToString());
            if (Properties.Settings.Default.IsTrayIcons == true)
            {
                notifyIcon1.Visible = true;
                string iconPath = EncryptDecrypt.GetFormImageUrl();
                System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
                this.Icon = ico;

                notifyIcon1.Icon = ico;


                DomainName = ConfigurationManager.AppSettings.Get("DomainName");
                notifyIcon1.Text = DomainName + " Message Center";


                Properties.Settings.Default.IsTrayIcons = false;
                Properties.Settings.Default.Save();

                NotificationTimeSetting();
                ShowMessage();

            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        /// <summary>
        ///  Context Menu Option for Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenMenu_Click(object sender, EventArgs e)
        {
            //ShowMessage();
            //this.Show();
            //this.WindowState = FormWindowState.Normal;

            //this.WindowState = FormWindowState.Minimized;
            HideWindow();

            //MDIParentPage parent = new MDIParentPage(objUserDetails);
            if (objParentMDI == null || objParentMDI.IsMdiContainer == false)
            {
                //objParentMDI.Dispose();
                objParentMDI.Hide();
                objParentMDI = new MDIParentPage(objUserDetails);
                objParentMDI.Show();
                objParentMDI.BringToFront();
                objParentMDI.Focus();
            }
            else
            {
                objParentMDI.ShowTipsWindow();
                objParentMDI.Show();
                objParentMDI.BringToFront();
                objParentMDI.Focus();
            }

        }

        /// <summary>
        /// Context Menu Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void exitMenu_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsTrayIcons = true;
            Properties.Settings.Default.IsLoginTrayIcon = true;
            Properties.Settings.Default.Save();

            notifyIcon1.Visible = false;
            this.Close();

            loginWindow.Refresh();
            loginWindow.Close();
            loginWindow.Dispose();


            Application.Exit();

            Application.ExitThread();
        }

        /// <summary>
        /// Window Load(Page Load)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Alerts_Load(object sender, EventArgs e)
        {
            if (loginWindow != null)
            {
                loginWindow.Hide();
                loginWindow.Visible = false;
            }

        }

        /// <summary>
        /// Show Alert when get new message from tip/contact app
        /// </summary>
        private void ShowMessage()
        {
            try
            {
                #region Notification Window Position Right Side Bottom

                var desktopWorkingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                if (WindowLeft == 0)
                {
                    this.Left = desktopWorkingArea.Right - this.Width;
                    this.Top = desktopWorkingArea.Bottom - this.Height;

                    WindowLeft = this.Left;
                    WindowTop = this.Top;
                }
                else
                {
                    this.Left = WindowLeft;
                    this.Top = WindowTop;
                }

                #endregion

                #region Pool DateTime With Server Time

                objService.ErrorHandling("Log", "Notification.cs", "ShowMessage( Method Calling 1)", "", "", "", "", "Tips Manager");


                // Get Server Time 
                DateTime dtServerTime = DateTime.Now;
                DateTime poolDate = DateTime.Now;

                // First Installation Time if condition excution
                if (Convert.ToString(Properties.Settings.Default.PoolDate).Trim() == string.Empty)
                {
                    try
                    {
                        objService.ErrorHandling("Log", "Notification.cs", "ShowMessage( Method Calling 2)", "", "", "", "", "Tips Manager");
                        dtServerTime = Convert.ToDateTime(objService.GetCurrentDateTime());
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
                    poolDate = Convert.ToDateTime(Properties.Settings.Default.PoolDate);
                    poolDate = poolDate.AddSeconds(-poolDate.Second);

                    try
                    {
                        objService.ErrorHandling("Log", "Notification.cs", "ShowMessage( Method Calling 2 )", "", "", "", "", "Tips Manager");
                        dtServerTime = Convert.ToDateTime(objService.GetCurrentDateTime());
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
                objService.ErrorHandling("Log", "Notification.cs", "ShowMessage( Method Calling 3)", "", "", "", "", "Tips Manager");
                Properties.Settings.Default.PoolDate = dtServerTime.ToString();
                Properties.Settings.Default.Save();


                #endregion

                DataTable dtAlerts = new DataTable("dtAlerts");
                DataTable dtAlertsByPoolDate = new DataTable("dtAlertsByPoolDate");

                try
                {
                    dtAlerts = objService.GetDesktopMobileAlerts(objUserDetails.UserID, true, poolDate);
                    dtAlertsByPoolDate = objService.GetDesktopMobileAlertsByPoolDate(objUserDetails.UserID, true, poolDate);
                }
                catch (Exception ex)
                {
                    objService.ErrorHandling("ERROR", "Notification.cs", "ShowMessage( Line:: 248)", Convert.ToString(ex.Message),
                   Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Tips Manager");
                }

                lblNoMessages.Text = "";


                if (dtAlerts.Rows.Count <= 0)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                    lblSubject.Text = "";
                    lblUsername.Text = "";
                    lblMore.Text = "";
                    lblNoMessages.Text = "No New Messages.";
                }
                else
                {

                    MessageID = Convert.ToInt32(dtAlerts.Rows[0]["Message_ID"]);
                    string MessageType = Convert.ToString(dtAlerts.Rows[0]["Source"]);
                    lblSubject.Text = Convert.ToString(dtAlerts.Rows[0]["Subject"]);
                    string data = Convert.ToString(dtAlerts.Rows[0]["Message"]);
                    string[] message = data.Split('|');
                    lblUsername.Text = message[0].ToString();

                    PermissionType = "";
                    if (!String.IsNullOrEmpty(objUserDetails.C_USER_ID))
                    {
                        if (MessageType == "T")
                            PermissionType = objService.returnUserPermission(Convert.ToInt32(objUserDetails.C_USER_ID), 0, "Receive Tips");
                        else
                            PermissionType = objService.returnUserPermission(Convert.ToInt32(objUserDetails.C_USER_ID), 0, "Receive Feedback/Tips");
                    }

                    /*** Start Checking Associate Permission ***/
                    if (PermissionType != "A")
                    {
                        if (dtAlerts.Rows.Count > 1)
                        {
                            lblMore.Visible = true;
                            int count = Convert.ToInt32(dtAlerts.Rows.Count.ToString()) - 1;
                            lblMore.Text = "You have " + count + " more message(s)/tip(s).";
                        }
                        else
                        {
                            lblMore.Visible = false;
                        }


                        if (flag && dtAlertsByPoolDate.Rows.Count > 0)
                        {
                            if (sp != null)
                            {
                                sp.Dispose();
                            }

                            LoadAudioPath(objUserDetails.ProfileID, ConfigurationManager.AppSettings.Get("CountryVerticalName"));

                            try
                            {
                                sp = new SoundPlayer(audioFile);
                                sp.Play();
                            }
                            catch (Exception ex)
                            {
                                objService.ErrorHandling("ERROR", "Notification.cs", "ShowMessage( Line: 305 )", Convert.ToString(ex.Message),
                                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Tips Manager");
                            }
                        }

                        flag = false;

                        this.TopMost = true;
                        this.Show();
                        this.WindowState = FormWindowState.Normal;

                    } /*** END Checking Associate Permission ***/



                }//END Else



            } //try
            catch (Exception ex)
            {
                objService.ErrorHandling("ERROR", "Notification.cs", "ShowMessage()", Convert.ToString(ex.Message),
                  Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "Tips Manager");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 3;
            //Color borderColor = new SolidBrush(Color.FromArgb(123, 150, 198)).Color;
            Color borderColor = new SolidBrush(Color.FromArgb(0, 128, 204)).Color;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
              borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
              ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
              borderColor, borderWidth, ButtonBorderStyle.Solid);

            if (loginWindow != null)
            {
                loginWindow.Hide();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            MDIParentPage parent = new MDIParentPage(objUserDetails);
            parent.BringToFront();
            parent.Show();

            this.Hide();
        }

        private void imgClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            HideWindow();
            sp.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgNotify_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            HideWindow();

            //MDIParentPage parent = new MDIParentPage(objUserDetails);
            //parent.Show();
            //parent.BringToFront();
            //parent.Focus();
            sp.Stop();
            if (objParentMDI == null || objParentMDI.IsMdiContainer == false)
            {
                //objParentMDI.Dispose();
                objParentMDI.Hide();
                objParentMDI = new MDIParentPage(objUserDetails);
                objParentMDI.Show();
                objParentMDI.BringToFront();
                objParentMDI.Focus();
            }
            else
            {
                objParentMDI.ShowTipsWindow();
                objParentMDI.Show();
                if (objParentMDI.WindowState == FormWindowState.Minimized)
                    objParentMDI.WindowState = FormWindowState.Normal;
                objParentMDI.BringToFront();
                objParentMDI.Focus();
            }
        }

        public void HideWindow()
        {
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            ShowMessage();
            // ShowNotificationWindow();
            this.TopMost = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        public void NotificationTimeSetting()
        {
            //Minutes.. Seconds... Miliseconds
            int time = (Convert.ToInt32(Properties.Settings.Default.DurationTime) * 60 * 1000); //60 * 1000
            if (timer1.Interval != time)
            {
                int Mins = Convert.ToInt32(Properties.Settings.Default.DurationTime);
                timer1.Interval = time;
                timer1.Start();
                timer1.Tick += new EventHandler(timer1_Tick);
            }

            //For TimeUpdate Notification-- Every 10 seconds checking Duration Time changing..
            AppTimer.Interval = 1 * 10 * 1000;
            AppTimer.Start();
            AppTimer.Tick += new EventHandler(AppTimer_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flag = true;
            ShowMessage();
        }

        void AppTimer_Tick(object sender, EventArgs e)
        {
            int time = (Convert.ToInt32(Properties.Settings.Default.DurationTime) * 60 * 1000); //60 * 1000
            if (timer1.Interval != time)
            {
                timer1.Stop();

                timer1.Interval = time;
                timer1.Start();
            }
        }

        public void HideTrayIcon()
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Visible = false;
            this.Refresh();
        }

        private void LoadAudioPath(int profileID, string vertical)
        {
            audioFile = objService.GetTipsManagerAudioFilePath(Convert.ToString(profileID), vertical);
        }

    }
}
