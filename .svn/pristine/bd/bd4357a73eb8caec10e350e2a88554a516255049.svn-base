using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.IO;
using System.Xml;

namespace USPDHUB.Business.MyAccount
{
    public partial class PrintMessageDetails : System.Web.UI.Page
    {
        public int MessageHistoryID = 0;
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBusinessBLL = new BusinessBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        public string ImageName = "";
        public DataTable dtReplyNotes = new DataTable("dtReplyNotes");

        public static string ButtonType = "";
        public string RootPath = "";
        public string DomainName = "";

        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objInBuiltData.ErrorHandling("LOG", "Wanted.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                if (Session["userid"] == null || Session["ProfileID"] == null || Session["VerticalDomain"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"]);

                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;


                    /*** BT: ButtonType :: MHID:MessageHistoryID ***/
                    ButtonType = EncryptDecrypt.DESDecrypt(Request.QueryString["BT"].ToString());
                    MessageHistoryID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["MHID"].ToString()));
                }
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }



                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();

                if (!IsPostBack)
                {
                    LoadMessageDetails();
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ViewMessageDetails.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadMessageDetails()
        {
            try
            {
                ClearValues();

                DataSet ds = objBusinessBLL.ViewMessageHistoryDetailsByID(MessageHistoryID, ButtonType, ProfileID);
                DataTable dtMessageDetails = new DataTable("dtMessageDetails");

                dtMessageDetails = ds.Tables[0];

                dtReplyNotes = ds.Tables[1];
                ViewState["dtReplyNotes"] = dtReplyNotes;

                DLNotes.DataSource = dtReplyNotes;
                DLNotes.DataBind();

                //GetAssociateUsers();

                if (dtMessageDetails.Rows.Count > 0)
                {
                    lblSubject.Text = Convert.ToString(dtMessageDetails.Rows[0]["Subject"]);
                    lblContactName.Text = Convert.ToString(dtMessageDetails.Rows[0]["ContactName"]).Replace("(null)", "");
                    lblContactEmailID.Text = Convert.ToString(dtMessageDetails.Rows[0]["ContactEmailID"]).Replace("(null)", "");
                    lblPhoneNumber.Text = Convert.ToString(dtMessageDetails.Rows[0]["PhoneNumber"]).Replace("(null)", "");
                    lblCustomMessage.Text = Convert.ToString(dtMessageDetails.Rows[0]["CustomPredefinedMessage"]).Replace("(null)", "");
                    lblCategoryName.Text = Convert.ToString(dtMessageDetails.Rows[0]["CategoryName"]).Replace("(null)", "");
                    lblRefID.Text = Convert.ToString(dtMessageDetails.Rows[0]["ReferenceID"]);
                    lblItemTitle.Text = Convert.ToString(dtMessageDetails.Rows[0]["ItemTitle"]);
                    lblTabName.Text = Convert.ToString(dtMessageDetails.Rows[0]["TabName"]);
                    lblMessageDate.Text = Convert.ToString(dtMessageDetails.Rows[0]["SentDate"]);

                    lblIsApproximateDistance.Text = Convert.ToString(dtMessageDetails.Rows[0]["ApproximateDistanceMsg"]);

                    /*** Device QR Scan Location***/
                    if (Convert.ToString(dtMessageDetails.Rows[0]["Location"]) != string.Empty)
                    {
                        string QRScanLocation = Convert.ToString(dtMessageDetails.Rows[0]["Location"]);
                        lblLocation.Text = QRScanLocation.Replace(", , ,", "");
                    }


                    /*** QR Code Address ***/
                    if (Convert.ToString(dtMessageDetails.Rows[0]["AddressInfo"]) != string.Empty)
                    {
                        string QRCodeAddress = "";
                        if (Convert.ToString(dtMessageDetails.Rows[0]["AddressInfo"]).StartsWith("<"))
                        {

                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.LoadXml(Convert.ToString(Convert.ToString(dtMessageDetails.Rows[0]["AddressInfo"])));

                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@Street") != null)
                            {
                                QRCodeAddress = xmldoc.SelectSingleNode("QRCodeLocation/Address/@Street").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@City") != null)
                            {
                                QRCodeAddress = QRCodeAddress + ", " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@City").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@State") != null)
                            {
                                QRCodeAddress = QRCodeAddress + ", " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@State").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@Zip") != null)
                            {
                                QRCodeAddress = QRCodeAddress + " " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@Zip").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@Country") != null)
                            {
                                QRCodeAddress = QRCodeAddress + ", " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@Country").Value;
                            }
                        }
                        else
                        {
                            QRCodeAddress = Convert.ToString(dtMessageDetails.Rows[0]["AddressInfo"]);
                        }

                        lblQRLocation.Text = QRCodeAddress;
                    }

                    hdnImageName.Value = ImageName = Convert.ToString(dtMessageDetails.Rows[0]["ImageName"]).Replace("(null)", "").Trim();
                    if (ImageName != string.Empty)
                    {
                        #region Loading Image

                        string ImageVirtualPath = "";
                        string ImgRootPath = "";

                        if (ButtonType == ButtonTypes.Tips || ButtonType == ButtonTypes.ContactUs)
                        {
                            ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\DevicePhotos\\" + ProfileID + "\\" + ImageName;
                            ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "\\DevicePhotos\\" + ProfileID + "\\" + ImageName;
                        }
                        else if (ButtonType == ButtonTypes.PrivateCall)
                        {
                            ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\PrivateCallDirectoryTapImages\\" + ProfileID + "\\" + ImageName;
                            ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "\\PrivateCallDirectoryTapImages\\" + ProfileID + "\\" + ImageName;
                        }
                        else if (ButtonType == ButtonTypes.SmartConnect)
                        {
                            ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\PublicCallDirectoryTapImages\\" + ProfileID + "\\" + ImageName;
                            ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "\\PublicCallDirectoryTapImages\\" + ProfileID + "\\" + ImageName;
                        }
                        else if (ButtonType == ButtonTypes.PrivateSmartConnect)
                        {
                            ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\PrivateSmartConnectTapImages\\" + ProfileID + "\\" + ImageName;
                            ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "\\PrivateSmartConnectTapImages\\" + ProfileID + "\\" + ImageName;
                        }

                        if (File.Exists(ImageVirtualPath))
                        {
                            int width = 0;
                            int height = 0;
                            //btnCopyImageGallery.Visible = true;

                            using (FileStream fs = new FileStream(ImageVirtualPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                                {
                                    height = image.Height;
                                    width = image.Width;
                                }
                            }

                            if (width > 350 && height > 250)
                            {
                                lblImage.Text = "<img src='" + ImgRootPath + "' Width='350' Height='250'  />";
                            }
                            else if (width > 350)
                            {
                                lblImage.Text = "<img src='" + ImgRootPath + "' Width='350' />";
                            }
                            else if (height > 250)
                            {
                                lblImage.Text = "<img src='" + ImgRootPath + "' Height='250' />";
                            }
                            else
                            {
                                lblImage.Text = "<img src='" + ImgRootPath + "'  />";
                            }
                        }
                        #endregion
                    }
                }//

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ViewMessageDetails.aspx.cs", "LoadMessageDetails()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void ClearValues()
        {
            lblSubject.Text = "";
            lblContactName.Text = "";
            lblContactEmailID.Text = "";
            lblPhoneNumber.Text = "";
            lblCustomMessage.Text = "";
            lblLocation.Text = "";
            //txtNotes.Text = "";
            //chkNotify.Checked = false;
            hdnEmailIds.Value = "";
            hdnImageName.Value = "";
            lblMessage.Visible = false;
        }
    }
}