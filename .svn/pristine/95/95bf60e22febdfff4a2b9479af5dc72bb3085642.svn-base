using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Web.Services;
using USPDHUBDAL;
using System.Text;

namespace USPDHUB.Business.MyAccount
{
    public partial class ViewMessageDetails : BaseWeb
    {
        public int MessageHistoryID = 0;
        public static string ButtonType = "";
        public string RootPath = "";
        public string DomainName = "";

        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;

        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBusinessBLL = new BusinessBLL();
        CommonBLL objCommonBLL = new CommonBLL();

        public string ImageName = "";
        public DataTable dtReplyNotes = new DataTable("dtReplyNotes");

        public string buttonText = "Block Sender";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
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

                    if (objBusinessBLL.CheckModulePermission(WebConstants.Purchase_PublicCallAddOns, ProfileID))
                    {
                        imgButton.Visible = true;
                    }
                    /*** BT: ButtonType :: MHID:MessageHistoryID ***/
                    ButtonType = EncryptDecrypt.DESDecrypt(Request.QueryString["BT"].ToString());
                    MessageHistoryID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["MHID"].ToString()));
                    hdnQueryStringParms.Value = Request.QueryString["BT"].ToString() + "|" + Request.QueryString["MHID"].ToString();

                    DataTable dt = objBusinessBLL.GetContactsbyHistoryID(MessageHistoryID, ButtonType);
                    gveContacts.DataSource = dt;
                    gveContacts.DataBind();
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

                DLNotes.DataSource = dtReplyNotes;
                DLNotes.DataBind();

                GetAssociateUsers();

                if (dtMessageDetails.Rows.Count > 0)
                {
                    lblSubject.Text = Convert.ToString(dtMessageDetails.Rows[0]["Subject"]);
                    lblContactName.Text = Convert.ToString(dtMessageDetails.Rows[0]["ContactName"]).Replace("(null)", "");
                    lblContactEmailID.Text = Convert.ToString(dtMessageDetails.Rows[0]["ContactEmailID"]).Replace("(null)", "");
                    lblPhoneNumber.Text = Convert.ToString(dtMessageDetails.Rows[0]["PhoneNumber"]).Replace("(null)", "");
                    lblMessageDate.Text = "";
                    lblCustomMessage.Text = Convert.ToString(dtMessageDetails.Rows[0]["CustomPredefinedMessage"]).Replace("(null)", "");
                    lblCategoryName.Text = Convert.ToString(dtMessageDetails.Rows[0]["CategoryName"]);

                    lblRefID.Text = Convert.ToString(dtMessageDetails.Rows[0]["ReferenceID"]);
                    lblMessageDate.Text = Convert.ToString(dtMessageDetails.Rows[0]["SentDate"]);
                    lblTabName.Text = Convert.ToString(dtMessageDetails.Rows[0]["TabName"]);
                    lblItemTitle.Text = Convert.ToString(dtMessageDetails.Rows[0]["ItemTitle"]);

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
                                if (Convert.ToString(xmldoc.SelectSingleNode("QRCodeLocation/Address/@Street").Value) != string.Empty)
                                    QRCodeAddress = xmldoc.SelectSingleNode("QRCodeLocation/Address/@Street").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@City") != null)
                            {
                                if (Convert.ToString(xmldoc.SelectSingleNode("QRCodeLocation/Address/@City").Value) != string.Empty)
                                    QRCodeAddress = QRCodeAddress + ", " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@City").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@State") != null)
                            {
                                if (Convert.ToString(xmldoc.SelectSingleNode("QRCodeLocation/Address/@State").Value) != string.Empty)
                                    QRCodeAddress = QRCodeAddress + ", " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@State").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@Zip") != null)
                            {
                                if (Convert.ToString(xmldoc.SelectSingleNode("QRCodeLocation/Address/@Zip").Value) != string.Empty)
                                    QRCodeAddress = QRCodeAddress + " " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@Zip").Value;
                            }
                            if (xmldoc.SelectSingleNode("QRCodeLocation/Address/@Country") != null)
                            {
                                if (Convert.ToString(xmldoc.SelectSingleNode("QRCodeLocation/Address/@Country").Value) != string.Empty)
                                    QRCodeAddress = QRCodeAddress + ", " + xmldoc.SelectSingleNode("QRCodeLocation/Address/@Country").Value;
                            }

                            lblQRLocation.Text = QRCodeAddress;
                        }
                        else
                        {
                            QRCodeAddress = Convert.ToString(dtMessageDetails.Rows[0]["AddressInfo"]);
                            lblQRLocation.Text = QRCodeAddress.Replace(", , ,", "").Replace(", ", "").Replace(" ,", "");
                        }


                    }

                    if (Convert.ToBoolean(dtMessageDetails.Rows[0]["IsBlocked"]))
                    {
                        hdnIsBlocked.Value = "1";
                        imgButton.ImageUrl = "../../Images/Dashboard/UnBlockSender.png";
                        buttonText = "Unblock Sender";
                    }
                    else
                    {
                        hdnIsBlocked.Value = "0";
                        imgButton.ImageUrl = "../../Images/Dashboard/BlockSender.png";
                        buttonText = "Block Sender";
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
                            btnCopyImageGallery.Visible = true;

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
                }
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
            txtNotes.Text = "";
            chkNotify.Checked = false;
            hdnEmailIds.Value = "";
            hdnImageName.Value = "";
            lblMessage.Visible = false;
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string url = "";
            if (ButtonType == ButtonTypes.Tips)
                url = "~/Business/MyAccount/MobileAppAlerts.aspx";
            else if (ButtonType == ButtonTypes.ContactUs)
                url = "~/Business/MyAccount/MobileAppAlerts.aspx";
            else if (ButtonType == ButtonTypes.PrivateCall)
                url = "~/Business/MyAccount/MobileAppAlerts.aspx";
            else if (ButtonType == ButtonTypes.SmartConnect)
                url = "~/Business/MyAccount/SmartConnectMessage.aspx";
            else if (ButtonType == ButtonTypes.PrivateSmartConnect)
                url = "~/Business/MyAccount/PrivateSmartConnectMessages.aspx";

            Response.Redirect(Page.ResolveClientUrl(url));

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            /*** Internal Users Send Notes ***/
            SendNotes_Email(false);

            LoadMessageDetails();
            lblMessage.Text = Resources.LabelMessages.VMSuccess.ToString();
            lblMessage.Visible = true;
        }


        private string GetAssociateUsers()
        {
            string returnString = "";
            try
            {
                BusinessBLL objBusinessBLL = new BusinessBLL();
                int UMID = 0;
                DataTable dtEmailIds = objBusinessBLL.GetAssociateUsersForMessageDetails(UserID, UMID, ButtonType, MessageHistoryID);
                for (int i = 0; i < dtEmailIds.Rows.Count; i++)
                {
                    if (Convert.ToString(dtEmailIds.Rows[i]["Username"]).Trim() != string.Empty)
                        returnString = returnString + dtEmailIds.Rows[i]["Username"] + ",";
                }

                if (returnString.EndsWith(","))
                {
                    returnString = returnString.Remove(returnString.Length - 1);
                }
                hdnAssociateUsers.Value = returnString;

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>GetAssociateUsers()</script>", false);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ViewMessageDetails.aspx.cs", "GetAssociateUsers", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnString;
        }

        protected void lnkSelectContacts_Click(object sender, EventArgs e)
        {
            txtEMailIds.Text = "";
            ContactsList.Show();
            DataTable dt = objBusinessBLL.GetContactsbyHistoryID(MessageHistoryID, ButtonType);
            gveContacts.DataSource = dt;
            gveContacts.DataBind();

        }


        protected void btnContactSubmit_Click(object sender, EventArgs e)
        {
            if (hdnSelectedEMailIds.Value.ToString().StartsWith(","))
            {
                hdnSelectedEMailIds.Value = hdnSelectedEMailIds.Value.Substring(1);
            }
            txtEMailIds.Text = hdnEmailIds.Value = hdnSelectedEMailIds.Value;
        }
        protected void btnSendReply_OnClick(object sender, EventArgs e)
        {
            /*** Sender Send Notes ***/
            SendNotes_Email(true);

            LoadMessageDetails();
            lblMessage.Visible = true;
        }

        protected void btnBlock_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;

                if (hdnIsBlocked.Value == "0")
                {
                    /*** SmartConnect ***/
                    if (ButtonType == ButtonTypes.SmartConnect)
                    {
                        objBusinessBLL.BlockUnBlockSmartConnectSenders(MessageHistoryID, true, C_UserID);
                    }
                    else
                    {  /*** Contact & Tips ***/
                        objBusinessBLL.BlockUnBlockMessageSenders(MessageHistoryID, true, C_UserID);
                    }

                    msg = Resources.LabelMessages.BlockSender.ToString();
                    imgButton.ImageUrl = "../../Images/Dashboard/UnBlockSender.png";
                    hdnIsBlocked.Value = "1";
                }
                else
                {
                    /*** SmartConnect ***/
                    if ((ButtonType == ButtonTypes.SmartConnect))
                    {
                        objBusinessBLL.BlockUnBlockSmartConnectSenders(MessageHistoryID, false, C_UserID);
                    }
                    else
                    {  /*** Contact & Tips ***/
                        objBusinessBLL.BlockUnBlockMessageSenders(MessageHistoryID, false, C_UserID);
                    }

                    msg = Resources.LabelMessages.UnblockSender.ToString();
                    imgButton.ImageUrl = "../../Images/Dashboard/BlockSender.png";
                    hdnIsBlocked.Value = "0";
                }

                lblMessage.Text = msg;


            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnBlockUsers_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void SendNotes_Email(bool IsSenderEmail)
        {

            //body = body.Replace("#ProfileName#", ProfileName); 
            #region Notes save to DB

            if (IsSenderEmail)
            {
                hdnEmailIds.Value = lblContactEmailID.Text.Trim();
                objBusinessBLL.Insert_ReplyHistory_Notes(txtReplyNotes.Text.Trim(), hdnEmailIds.Value.ToString().Trim(), C_UserID, MessageHistoryID, ButtonType, IsSenderEmail);
            }
            else
            {
                DataSet ds1 = objBusinessBLL.ViewMessageHistoryDetailsByID(MessageHistoryID, ButtonType, ProfileID);
                dtReplyNotes = ds1.Tables[1];

                if (chkNotify.Checked)
                    hdnEmailIds.Value = txtEMailIds.Text.Trim();
                else
                    hdnEmailIds.Value = string.Empty;


                objBusinessBLL.Insert_ReplyHistory_Notes(txtNotes.Text.Trim(), hdnEmailIds.Value.ToString().Trim(), C_UserID, MessageHistoryID, ButtonType, IsSenderEmail);
            }

            #endregion



            try
            {

                string strfilepath = "";
                string body = string.Empty;
                string input = string.Empty;

                if (IsSenderEmail)
                    strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\" + "ReplyMessagesToSender.txt";
                else
                    strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\" + "ReplyMessages.txt";

                using (StreamReader re = File.OpenText(strfilepath))
                {
                    while ((input = re.ReadLine()) != null)
                    {
                        body = body + input;
                    }
                }

                strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";
                string StrPreviouNotesHtml = string.Empty;
                input = string.Empty;

                using (StreamReader re = File.OpenText(strfilepath + "SmartConnect_PreviousNotes.txt"))
                {
                    while ((input = re.ReadLine()) != null)
                    {
                        StrPreviouNotesHtml = StrPreviouNotesHtml + input;
                    }
                }


                string FromEmailInfo = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailInfo = row[1].ToString();
                            break;
                        }
                    }
                }


                string outerURL = objCommonBLL.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");
                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(ProfileID);
                #region Logo

                string logoName = "";
                logoName = dtProfileDetails.Rows[0]["Profile_logo_path"].ToString();
                int logoprofileid = ProfileID;
                string extension = System.IO.Path.GetExtension(logoName);
                if (logoName == string.Empty)
                {
                    extension = ".jpg";
                }

                string logoFullPath = "";
                string logoServerpath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Logos\\";
                logoServerpath = logoServerpath + logoprofileid + "\\" + logoprofileid + "_thumb" + extension;
                if (File.Exists(logoServerpath) && logoName != "")
                {
                    logoFullPath = outerURL + "/Upload/Logos/" +
                      logoprofileid + "/" + logoprofileid + "_thumb" + extension;
                }
                else
                {
                    logoFullPath = "";
                }

                #endregion

                body = body.Replace("#ProfileLogo#", "<IMG SRC='" + logoFullPath + "' border='0' />");
                body = body.Replace("#AppName#", dtProfileDetails.Rows[0]["Profile_name"].ToString());
                body = body.Replace("#Subject#", lblSubject.Text);
                body = body.Replace("#Message#", lblCustomMessage.Text.Trim());
                body = body.Replace("#RepliedBy#", Session["C_USER_NAME"] == null ? Session["username"].ToString() : Session["C_USER_NAME"].ToString());
                body = body.Replace("#RepliedDate#", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                body = body.Replace("#MessageID#", lblRefID.Text);

                if (IsSenderEmail)
                    body = body.Replace("#Notes#", txtReplyNotes.Text.Trim());
                else
                    body = body.Replace("#Notes#", txtNotes.Text.Trim());

                body = body.Replace("#TabName#", lblTabName.Text.Trim());

                if (dtReplyNotes.Rows.Count > 0)
                {
                    if (chkIncludePreviousNotes.Checked)
                    {
                        string strPreviousNotes = "";
                        for (int i = 0; i < dtReplyNotes.Rows.Count; i++)
                        {
                            strPreviousNotes = strPreviousNotes + StrPreviouNotesHtml.Replace("#Note#", dtReplyNotes.Rows[i]["Notes"].ToString())
                                                                    .Replace("#User#", dtReplyNotes.Rows[i]["NotesByUser"].ToString())
                                                                    .Replace("#date#", Convert.ToDateTime(dtReplyNotes.Rows[i]["CreatedDate"]).ToString("MM/dd/yyyy hh:mm tt"));

                        }
                        body = body.Replace("#PreviousNotes#", "<b>Previous Notes</b><br/> " + strPreviousNotes.ToString());
                    }
                    else
                    {
                        body = body.Replace("#PreviousNotes#", "");
                    }
                }
                else
                {
                    body = body.Replace("#PreviousNotes#", "");
                }

                //<b>Notes</b>: #Notes#<br/><br/> 
                if (ButtonType == ButtonTypes.SmartConnect || ButtonType == ButtonTypes.PrivateSmartConnect)
                    body = body.Replace("#CatName#", "<b>Category</b>: " + lblCategoryName.Text.Trim() + "<br/><br/>");
                else
                    body = body.Replace("#CatName#", "");

                if (ButtonType == ButtonTypes.SmartConnect || ButtonType == ButtonTypes.PrivateCall || ButtonType == ButtonTypes.PrivateSmartConnect)
                    body = body.Replace("#ButtonName#", "<b>Button Name</b>: " + lblItemTitle.Text.Trim() + "<br/><br/>");
                else
                    body = body.Replace("#ButtonName#", "");

                UtilitiesBLL objUtilitiesBLL = new UtilitiesBLL();
                objUtilitiesBLL.SendWowzzyEmail(FromEmailInfo, hdnEmailIds.Value.ToString().Trim(), "Reply message from " + lblSubject.Text, body, "", "", DomainName);

                txtEMailIds.Text = "";
                hdnEmailIds.Value = "";
                txtReplyNotes.Text = "";



                chkIncludePreviousNotes.Checked = false;
                chkNotify.Checked = false;
                txtEMailIds.Text = "";
                hdnEmailIds.Value = "";
                hdnSelectedEMailIds.Value = "";

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ViewMessageDetails.aspx.cs", "SendNotes_Email()" + IsSenderEmail, ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }



        }
    }
}