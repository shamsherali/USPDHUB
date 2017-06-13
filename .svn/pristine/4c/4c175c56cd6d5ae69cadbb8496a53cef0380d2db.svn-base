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
using System.Diagnostics;
using System.IO;

namespace USPDHubClientAlerts
{
    public partial class MobileAppAlerts : Form
    {
        string ClientServicURL = ConfigurationManager.AppSettings.Get("ClientServiceURL");
        ClientService.ClientServiceSoapClient objService = new ClientService.ClientServiceSoapClient();

        UserDetails objUserDetails = new UserDetails();

        int AppMessageID = 0;

        DataTable dtMessages = new DataTable();
        DataTable dtTips = new DataTable();

        public MDIParentPage parentPage = null;

        public string DomainName = "USPD";
        string PermissionType = "";

        public MobileAppAlerts()
        {
            InitializeComponent();
        }

        public MobileAppAlerts(UserDetails puserDetais)
        {
            InitializeComponent();

            objUserDetails = puserDetais;
            //objService.Endpoint.Address = new System.ServiceModel.EndpointAddress(ClientServicURL);
        }

        private void AppAlerts_Load(object sender, EventArgs e)
        {
            lblPermissionMSG.Visible = false;
            GetTips_Messages();

            PermissionType = "";
            if (!String.IsNullOrEmpty(objUserDetails.C_USER_ID))
            {
                PermissionType = objService.returnUserPermission(Convert.ToInt32(objUserDetails.C_USER_ID), 0, "ManageMessageReceipt");

                if (PermissionType == "A")
                {
                    lblPermissionMSG.Visible = true;

                    lbl1.Visible = false;
                    lbl2.Visible = false;
                    dgMessages.Visible = false;
                    dgTips.Visible = false;

                    btnViewAll.Visible = false;
                }
            }

            //DomainName = ConfigurationManager.AppSettings.Get("DomainName");
            //this.Text = DomainName + " Tips Manager"; 
        }

        public void GetTips_Messages()
        {
            string iconPath = EncryptDecrypt.GetFormImageUrl();
            System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
            this.Icon = ico;

            this.Cursor = Cursors.WaitCursor;
            this.Text = Utilities.AgencyName;

            dgMessages.AutoGenerateColumns = dgTips.AutoGenerateColumns = false;

            //Properties.Settings.Default.AlertsCount = "10";
            //Properties.Settings.Default.Save();

            int RowsCount = Convert.ToInt32(Properties.Settings.Default.MessagesCount);



            //Messages
            dtMessages = objService.GetMobileAppAlertsForDesktop("Messages", objUserDetails.UserID, Convert.ToInt32(Properties.Settings.Default.MessagesCount));
            AddReplyColumn(dtMessages);
            dgMessages.DataSource = null;
            dtMessages.Columns.Add("MessageData", typeof(String));
            for (int i = 0; i < dtMessages.Rows.Count; i++)
            {
                string data = Convert.ToString(dtMessages.Rows[i]["Message"]);
                string[] message = data.Split('|');
                if (message.Length > 3)
                    dtMessages.Rows[i]["MessageData"] = message[3];
            }
            dgMessages.DataSource = dtMessages;

            //Tips
            dtTips = objService.GetMobileAppAlertsForDesktop("Tips", objUserDetails.UserID, Convert.ToInt32(Properties.Settings.Default.TipsCount));
            dgTips.DataSource = null;
            AddReplyColumn(dtTips);
            dtTips.Columns.Add("TipData", typeof(String));
            for (int i = 0; i < dtTips.Rows.Count; i++)
            {
                string data = Convert.ToString(dtTips.Rows[i]["Message"]);
                string[] message = data.Split('|');
                if (message.Length > 3)
                    dtTips.Rows[i]["TipData"] = message[3];
            }
            dgTips.DataSource = dtTips;

            this.Cursor = Cursors.Default;
        }

        private void dgMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                AppMessageID = Convert.ToInt32(dgMessages.Rows[e.RowIndex].Cells[0].Value);

                if (e.ColumnIndex == 6) // View Messages
                {
                    /*
                    DataRow[] DR = dtMessages.Select("Message_ID=" + AppMessageID);
                    FillMessageDtails(DR.CopyToDataTable());

                    GBMessage.Text = "Message";
                    objService.UpdateStatusForMobileAlerts(objUserDetails.UserID, AppMessageID, true, AppMessageID);
                     * */

                    DataRow[] DR = dtMessages.Select("Message_ID=" + AppMessageID);
                    PopupAlertDetails detailsWindow = new PopupAlertDetails();

                    objService.UpdateStatusForMobileAlerts(objUserDetails.UserID, AppMessageID, true, objUserDetails.UserID);

                    DataGridViewCellStyle style2 = new DataGridViewCellStyle(this.dgMessages.RowsDefaultCellStyle);
                    style2.Font = new System.Drawing.Font(this.dgMessages.Font, FontStyle.Regular);
                    dgMessages.Rows[e.RowIndex].DefaultCellStyle = style2;

                    detailsWindow.FillMessageDtails(DR.CopyToDataTable(), objUserDetails, "Message");
                    detailsWindow.ShowDialog();

                }
                else if (e.ColumnIndex == 7)    //Reply Messages
                {
                    DataRow[] DR = dtMessages.Select("Message_ID=" + AppMessageID);
                    OpenOutlook(DR.CopyToDataTable());
                }
            }
        }

        private void OpenOutlook(DataTable dtDetails)
        {
            if (dtDetails.Rows.Count > 0)
            {
                string Subject = "Re: " + Convert.ToString(dtDetails.Rows[0]["Subject"]);

                string data = Convert.ToString(dtDetails.Rows[0]["Message"]);

                string[] message = data.Split('|');
                string userName = message[0].ToString();
                string contactEmail = "";

                if (message[2] != null && message[2] != "")
                {
                    contactEmail = message[2].ToString();
                }
                if (contactEmail.Trim() != "")
                {
                    //Process.Start(String.Format("mailto:{0}?subject={1}", contactEmail, Subject));
                    PopupCannedMeesage objWindow = new PopupCannedMeesage(objUserDetails, contactEmail);
                    objWindow.ShowDialog();
                }
            }
        }

        private void dgTips_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                AppMessageID = Convert.ToInt32(dgTips.Rows[e.RowIndex].Cells[0].Value);

                // View Tips
                if (e.ColumnIndex == 6)
                {
                    /*
                    DataRow[] DR = dtTips.Select("Message_ID=" + AppMessageID);
                    FillMessageDtails(DR.CopyToDataTable());
                    GBMessage.Text = "Tip";
                    objService.UpdateStatusForMobileAlerts(objUserDetails.UserID, AppMessageID, true, AppMessageID);
                     * */
                    DataRow[] DR = dtTips.Select("Message_ID=" + AppMessageID);
                    PopupAlertDetails detailsWindow = new PopupAlertDetails();

                    objService.UpdateStatusForMobileAlerts(objUserDetails.UserID, AppMessageID, true, objUserDetails.UserID);

                    DataGridViewCellStyle style2 = new DataGridViewCellStyle(this.dgMessages.RowsDefaultCellStyle);
                    style2.Font = new System.Drawing.Font(this.dgMessages.Font, FontStyle.Regular);
                    dgTips.Rows[e.RowIndex].DefaultCellStyle = style2;


                    detailsWindow.FillMessageDtails(DR.CopyToDataTable(), objUserDetails, "Tip");
                    detailsWindow.ShowDialog();
                }
                // Reply Tips
                else if (e.ColumnIndex == 7)
                {
                    DataRow[] DR = dtTips.Select("Message_ID=" + AppMessageID);
                    OpenOutlook(DR.CopyToDataTable());
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {

            string rootPath = objService.GetConfigSettingByPID(objUserDetails.ProfileID.ToString(), "Paths", "RootPath");
            string urlinfo = rootPath + "/Business/MyAccount/DesktopTipsManager.aspx?username=" + EncryptDecrypt.DESEncrypt(objUserDetails.Username) + "&pwd=" + EncryptDecrypt.DESEncrypt(objUserDetails.Password);
            System.Diagnostics.Process.Start(urlinfo);


            //MessageBox.Show("Coming Soon");
        }

        private void AddReplyColumn(DataTable dt)
        {
            if (!dt.Columns.Contains("Reply"))
            {
                dt.Columns.Add("Reply");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string data = Convert.ToString(dt.Rows[i]["Message"]);
                    string[] message = data.Split('|');
                    if (message[2] != null && message[2] != "")
                    {
                        dt.Rows[i]["Reply"] = "Reply";
                    }
                    else
                    {
                        dt.Rows[i]["Reply"] = "";
                    }
                }
            }
        }

        private void dgMessages_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle(this.dgMessages.RowsDefaultCellStyle);
            style1.Font = new System.Drawing.Font(this.dgMessages.Font, FontStyle.Bold);

            foreach (DataGridViewRow row in this.dgMessages.Rows)
            {
                if (Convert.ToBoolean(row.Cells["UserReadFlag"].Value) == false)
                    row.DefaultCellStyle = style1;
            }
        }

        private void dgTips_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle(this.dgMessages.RowsDefaultCellStyle);
            style1.Font = new System.Drawing.Font(this.dgMessages.Font, FontStyle.Bold);

            foreach (DataGridViewRow row in this.dgTips.Rows)
            {
                if (Convert.ToBoolean(row.Cells["User_Read"].Value) == false)
                    row.DefaultCellStyle = style1;
            }
        }
    }
}
