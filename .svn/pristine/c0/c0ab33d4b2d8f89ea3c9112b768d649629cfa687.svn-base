using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace USPDHubClientAlerts
{
    public partial class Settings : Form
    {
        public MDIParentPage parentPage = null;

        UserDetails objUserDetails = new UserDetails();

        public Settings(UserDetails pobjUserDetails)
        {
            InitializeComponent();
            Load += new EventHandler(Settings_Load);

            objUserDetails = pobjUserDetails;

            //string DomainName = ConfigurationManager.AppSettings.Get("DomainName");
            //this.Text = DomainName + " Tips Manager";
        }

        void Settings_Load(object sender, EventArgs e)
        {
            string iconPath = EncryptDecrypt.GetFormImageUrl();
            System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
            this.Icon = ico;


            this.Text = Utilities.AgencyName;

            lblErrorMessage.Text = "";

            if (Properties.Settings.Default.DurationTime != "")
            {
                //txtDurationTime.Text = Properties.Settings.Default.DurationTime;
                var time = Properties.Settings.Default.DurationTime;
                cmbTime.Text = time;
            }
            if (Properties.Settings.Default.MessagesCount != "")
            {
                txtMessagesCount.Text = Properties.Settings.Default.MessagesCount;
            }
            if (Properties.Settings.Default.TipsCount != "")
            {
                txtTipsCount.Text = Properties.Settings.Default.TipsCount;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;

            if (txtMessagesCount.Text.Trim() == "")
            {
                lblErrorMessage.Text = "Please enter the display messages count.";
            }
            else if (CheckIfNumeric(txtMessagesCount.Text.Trim()) == false)
            {
                lblErrorMessage.Text = "Please enter the display messages count only numbers.";
            }
            else if (txtTipsCount.Text.Trim() == "")
            {
                lblErrorMessage.Text = "Please enter the display tips count.";
            }
            else if (CheckIfNumeric(txtTipsCount.Text.Trim()) == false)
            {
                lblErrorMessage.Text = "Please enter the display tips count only numbers.";
            }
            else
            {
                Properties.Settings.Default.DurationTime = cmbTime.Text.ToString();
                Properties.Settings.Default.MessagesCount = txtMessagesCount.Text.Trim();
                Properties.Settings.Default.TipsCount = txtTipsCount.Text.Trim();
                Properties.Settings.Default.Save();

                lblErrorMessage.ForeColor = System.Drawing.Color.Green;

                //Notification obj = new Notification();


                // lblErrorMessage.Text = "Settings have been Saved Successfully.";

                if (MessageBox.Show("Settings have been saved successfully. Do you want to go back to the alerts screen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MobileAppAlerts appAlertWindow = new MobileAppAlerts(objUserDetails);
                    //appAlertWindow.MdiParent = null;
                    appAlertWindow.MdiParent = parentPage;
                    appAlertWindow.Show();
                    appAlertWindow.BringToFront();
                }



            }
        }
        public bool CheckIfNumeric(string pValue)
        {
            bool IsNum = true;
            for (int index = 0; index < pValue.Length; index++)
            {
                if (!Char.IsNumber(pValue[index]))
                {
                    IsNum = false;
                    break;
                }
            }
            return IsNum;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MobileAppAlerts appAlertWindow = new MobileAppAlerts(objUserDetails); 
            appAlertWindow.MdiParent = parentPage;
            appAlertWindow.Show();
            appAlertWindow.BringToFront();
        }
    }
}
