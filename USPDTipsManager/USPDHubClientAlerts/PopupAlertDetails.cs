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

namespace USPDHubClientAlerts
{
    public partial class PopupAlertDetails : Form
    {
        private System.IO.Stream streamToPrint;
        string streamType;

        public PopupAlertDetails()
        {
            InitializeComponent();

            string DomainName = ConfigurationManager.AppSettings.Get("DomainName");
            this.Text = DomainName + " Message Center";
        }

        public void FillMessageDtails(DataTable dtDetails, UserDetails objUserDetails, string MessageType)
        {
            GBMessage.Visible = true;
            GBMessage.Text = MessageType;

            lblSubject.Text = "";
            lblUserName.Text = "";
            lblContactEmail.Text = "";
            lblPhoneNumber.Text = "";
            lblMessage.Text = "";
            lblLocation.Text = "";

            string Username = "";
            string ContactEmail = "";
            string PhoneNumber = "";
            string Message = "";
            string Location = "";

            if (dtDetails.Rows.Count > 0)
            {
                lblSubject.Text = "Subject: " + Convert.ToString(dtDetails.Rows[0]["Subject"]);

                string data = Convert.ToString(dtDetails.Rows[0]["Message"]);

                string[] message = data.Split('|');
                lblUserName.Text = message[0].ToString();
                Username = message[0].ToString();
                if (message[2] != null && message[2] != "")
                {
                    lblContactEmail.Text = message[2].ToString();
                    ContactEmail = message[2].ToString();
                }
                if (message[1] != null && message[1] != "")
                {
                    lblPhoneNumber.Text = message[1].ToString();
                    PhoneNumber = message[1].ToString();
                }

                lblMessage.Text = message[3].ToString();
                Message = message[3].ToString();



                if (dtDetails.Rows[0]["Latitude1"] != null && dtDetails.Rows[0]["Latitude1"].ToString() != "" && Convert.ToInt32(dtDetails.Rows[0]["Latitude1"]) != 0)
                {
                    if (dtDetails.Rows[0]["Longitude1"] != null && dtDetails.Rows[0]["Longitude1"].ToString() != "" && Convert.ToInt32(dtDetails.Rows[0]["Longitude1"]) != 0)
                    {
                        string latitude = dtDetails.Rows[0]["Latitude1"].ToString();
                        string longitude = dtDetails.Rows[0]["Longitude1"].ToString();
                        XmlDocument doc = new XmlDocument();
                        doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");
                        XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                        if (element.InnerText == "ZERO_RESULTS")
                        {
                            lblLocation.Text = "";
                        }
                        else
                        {
                            element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                            if (((element).InnerText) != null && ((element).InnerText) != "")
                            {
                                string text = (element).InnerText;
                                string[] textdata = text.Split(',');
                                for (int i = 0; i < textdata.Length; i++)
                                {
                                    if (lblLocation.Text == "" || lblLocation.Text == null)
                                        lblLocation.Text = textdata[i].Trim().ToString();
                                    else if ((textdata.Length - 2) == i)
                                        lblLocation.Text = lblLocation.Text + "," + " " + textdata[i].Trim().ToString();
                                    else
                                        lblLocation.Text = lblLocation.Text + "," + "<br/>" + textdata[i].Trim().ToString();
                                }

                                lblLocation.Text = (lblLocation.Text + ".").Replace("<br/>", "");
                                //lblLocation.Focus();

                                Location = (Location + ".").Replace("<br/>", "");

                            }
                        }
                    }
                }

                if (Username == "")
                {
                    panelUsername.Visible = false;
                }
                else
                {
                    panelUsername.Visible = true;
                }
                if (ContactEmail == "")
                {
                    panelEmail.Visible = false;
                }
                else
                {
                    panelEmail.Visible = true;
                }
                if (PhoneNumber == "")
                {
                    panelPhoneNumber.Visible = false;
                }
                else
                {
                    panelPhoneNumber.Visible = true;
                }
                if (Message == "")
                {
                    panelMessage.Visible = false;
                }
                else
                {
                    panelMessage.Visible = true;
                }
                if (Location == "")
                {
                    panelLocation.Visible = false;
                }
                else
                {
                    panelLocation.Visible = true;
                }

                string imageName = Convert.ToString(dtDetails.Rows[0]["PhotoName"]);
                if (imageName != string.Empty && imageName != null)
                {
                    //getting image path
                    string uploadphotosPath = "";
                    USPDHubClientAlerts.ClientService.ClientServiceSoapClient objService = new ClientService.ClientServiceSoapClient();
                   
                    /*
                      if(objService.Endpoint.Address.Uri.ToString().Contains("http://test.uspdhub.com"))
                      {
                          uploadphotosPath = "http://test.uspdhub.com/muspdhub1.1/Upload/DevicePhotos/" + objUserDetails.ProfileID + "/";
                      }
                      else if(objService.Endpoint.Address.Uri.ToString().Contains("http://www.uspdhub.com"))
                      {
                          uploadphotosPath = "http://www.uspdhub.com/muspdhub1.1/Upload/DevicePhotos/" + objUserDetails.ProfileID + "/";
                      }
                      else
                      {
                          uploadphotosPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/Upload/DevicePhotos/" + objUserDetails.ProfileID + "/";
                      }
                     
                      */

                    uploadphotosPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/Upload/DevicePhotos/" + objUserDetails.ProfileID + "/";
                    imageName = uploadphotosPath + imageName;

                    pictureBox1.ImageLocation = imageName;

                    panelImage.Visible = true;
                }
                else
                {
                    panelImage.Visible = false;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnClose.Visible = false;
            btnPrint.Visible = false;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\USPDHubClientAlerts";
            path = path + "\\PrintPage.png";

            int pageWidth = GBMessage.ClientRectangle.Width + 20;
            int pageHeight = GBMessage.ClientRectangle.Height + 40;

            Graphics g1 = this.CreateGraphics();
            Image MyImage = new Bitmap(pageWidth, pageHeight, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, pageWidth, pageHeight, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            MyImage.Save(path, ImageFormat.Png);
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StartPrint(fileStream, "Image");
            fileStream.Close();

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            btnClose.Visible = true;
            btnPrint.Visible = true;
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

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(this.streamToPrint);
            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;
            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
        }

        public void StartPrint(Stream streamToPrint, string streamType)
        {
            this.printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            this.streamToPrint = streamToPrint;
            this.streamType = streamType;
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            PrintDialog1.ShowHelp = true;
            PrintDialog1.Document = printDoc;

            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDoc.Print();
                //docToPrint.Print();
            }

        }

        private void PopupAlertDetails_Load(object sender, EventArgs e)
        {
            string iconPath = EncryptDecrypt.GetFormImageUrl();
            System.Drawing.Icon ico = new System.Drawing.Icon(iconPath);
            this.Icon = ico;
        }
    }
}
