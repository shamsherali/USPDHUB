using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace USPDHubClientAlerts
{

    public partial class PopupCannedMeesage : Form
    {
        UserDetails objUserDetails = new UserDetails();
        public string contactEmailID = "";

        DataTable dtCannedMessages = new DataTable();

        ClientService.ClientServiceSoapClient objService = new ClientService.ClientServiceSoapClient();
        public string selectedMessage = "";

        public PopupCannedMeesage()
        {
            InitializeComponent();

            string DomainName = ConfigurationManager.AppSettings.Get("DomainName");
            this.Text = DomainName + " Message Center";
        }

        public PopupCannedMeesage(UserDetails pUserDetais, string pContactEmailID)
        {
            InitializeComponent();

            objUserDetails = pUserDetais;
            contactEmailID = pContactEmailID;
            Load += new EventHandler(PopupCannedMeesage_Load);

            TextRenderer.MeasureText(this.Text, this.Font, new Size { Width = 500 }, TextFormatFlags.WordBreak);
        }


        private void PopupCannedMeesage_Load(object sender, EventArgs e)
        {

            string iconPath = EncryptDecrypt.GetFormImageUrl();
            System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
            this.Icon = ico;

            dtCannedMessages = objService.GetAllCannedMessages(objUserDetails.ProfileID.ToString());
            //panleMessages.Controls.Clear();

            int top = 0;
            RadioButton rbNew = new RadioButton();
            for (int i = 0; i < dtCannedMessages.Rows.Count; i++)
            {
                if (i == 0)
                { top = 10; }
                else
                {
                    top = top + 25;
                }
                rbNew = new RadioButton
                {
                    Text = Convert.ToString(dtCannedMessages.Rows[i]["MessageText"]),
                    Name = "rb" + i,
                    Top = top,
                    Left = 15,
                    AutoSize = true                    
                };

                
                rbNew.Click += new EventHandler(rbNew_Click);
                panleMessages.Controls.Add(rbNew);
            }

            /*
            LBCannedMessages.DataSource = dtCannedMessages;
            LBCannedMessages.DisplayMember = "MessageText";
            LBCannedMessages.ValueMember = "MessageText";
            if (dtCannedMessages.Rows.Count > 0)
            {
                LBCannedMessages.SelectedIndex = -1;
            }
            */
        }

        void rbNew_Click(object sender, EventArgs e)
        {
            RBNone.Checked = false;

            RadioButton rb = sender as RadioButton;
            selectedMessage = rb.Text;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest, // handle to destination DC
            int nXDest, // x-coord of destination upper-left corner
            int nYDest, // y-coord of destination upper-left corner
            int nWidth, // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc, // handle to source DC
            int nXSrc, // x-coordinate of source upper-left corner
            int nYSrc, // y-coordinate of source upper-left corner
            System.Int32 dwRop // raster operation code
        );


        private void btnReply_Click(object sender, EventArgs e)
        {
            /*
            if (chkNone.Checked == false && LBCannedMessages.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a canned message.");
            }
            else
            {
                if (chkNone.Checked)
                {
                    Process.Start(String.Format("mailto:{0}?body={1}", contactEmailID, ""));
                }
                else
                {
                    Process.Start(String.Format("mailto:{0}?body={1}", contactEmailID, LBCannedMessages.SelectedValue.ToString()));
                }

                this.Close();
            }*/

            if (RBNone.Checked)
            {
                Process.Start(String.Format("mailto:{0}?body={1}", contactEmailID, ""));
            }
            else
            {
                Process.Start(String.Format("mailto:{0}?body={1}", contactEmailID, selectedMessage));
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RBNone_Click(object sender, EventArgs e)
        {
            foreach (Control control in panleMessages.Controls)
            {
                RadioButton rb = control as RadioButton;
                rb.Checked = false;

            }
        }

    }
}
