using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml;
using System.Drawing;
using Winnovative.PdfCreator;
using Facebook;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManagePSCCallIndexAddOns : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public int SortDir = 0;

        AddOnBLL objAddOn = new AddOnBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        PrivateSmartConnectBLL objPSC = new PrivateSmartConnectBLL();
        public string RootPath = "";
        public string DomainName = "";
        public string QRCode_Image_Name = "LTPSC";
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        string appID = string.Empty;    //Facebook App ID and Secret
        string appSecret = string.Empty;

        public int CustomModuleId = 0;
        public string ArchiveValue = string.Empty;

        public DataTable dtCallIndexDetails = new DataTable();
        DataTable dtAddOn = new DataTable();



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();

            if (Session["CustomModuleID"] == null)
            {
                Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
            }
            else
                CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());


            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            lblmess.Text = "";


            if (!IsPostBack)
            {

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    DataTable dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                    for (int i = 0; i < dtpermissions.Rows.Count; i++)
                    {
                        string segName = dtpermissions.Rows[i]["ButtonType"].ToString().Trim();
                        if (segName == "PrivateSmartConnectAddOns" && CustomModuleId == Convert.ToInt32(dtpermissions.Rows[i]["UserModuleId"]))
                        {
                            //IsCategory checking
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"]))
                                hdnPermissionType.Value = "A";
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"]))
                                hdnPermissionType.Value = "P";
                            break;
                        }
                    }
                    //hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CustomModuleId, "PrivateSmartConnectAddOns");
                    if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage Private QR Connect addons.</font>";
                    }
                }
                //ends here

                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                GetAllManagePSCAddOns();
                BindQRConnectCategories();
                if (Request.QueryString["CategoryID"] != null)
                {
                    string catID = EncryptDecrypt.DESDecrypt(Request.QueryString["CategoryID"].ToString());
                    ddlCategories.SelectedValue = catID;
                    GetAllManagePSCAddOns(catID);

                }

                if (Request.QueryString["SID"] != null)
                    Session["BulletinSuccess"] = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["SID"]));
                if (Session["BulletinSuccess"] != null)
                {
                    lblmess.Text = Session["BulletinSuccess"].ToString();
                    Session.Remove("BulletinSuccess");
                    Session.Remove("BulletinID");
                }
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "Social");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "FacebookAPIKey")
                            hdnFacebookAppId.Value = row[1].ToString();
                    }
                }
            }
            if (Session["BulletinSend"] != null)
            {
                if (Session["BulletinSend"].ToString() != "")
                {
                    if (Session["BulletinSend"].ToString() == "1")
                    {
                        if (Session["CheckBulletinMess"] != null)
                        {
                            if (Session["CheckBulletinMess"].ToString() != "")
                            {
                                if (Session["CheckBulletinMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this content as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "2")
                                {
                                    string invalidIds = string.Empty;
                                    if (Session["invalidEventEmailID"] != null)
                                    {
                                        if (Session["invalidEventEmailID"].ToString() != "")
                                        {
                                            invalidIds = Session["invalidEventEmailID"].ToString().ToString();
                                        }
                                        Session["invalidEventEmailID"] = null;
                                    }
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this content because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
                            }
                            Session["CheckBulletinMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
                        }
                    }
                    else if (Session["BulletinSend"].ToString() == "2")
                    {
                        if (Session["CheckBulletinMess"] != null)
                        {
                            if (Session["CheckBulletinMess"].ToString() != "")
                            {
                                if (Session["CheckBulletinMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this content as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "2")
                                {
                                    string invalidIds = string.Empty;
                                    if (Session["invalidEventEmailID"] != null)
                                    {
                                        if (Session["invalidEventEmailID"].ToString() != "")
                                        {
                                            invalidIds = Session["invalidEventEmailID"].ToString().ToString();
                                        }
                                        Session["invalidEventEmailID"] = null;
                                    }
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "content") + "</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this content because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "content") + "</font>";
                            }
                            Session["CheckBulletinMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "content") + "</font>";
                        }

                    }
                }
                Session["BulletinSend"] = null;
            }
            ddlPageSize = (DropDownList)PageSizes.FindControl("ddlPageSize");
            ddlPageSize.AutoPostBack = true;
            ddlPageSize.SelectedIndexChanged += ddlPageSize_SelectedIndexChanged;
        }
        private void BindQRConnectCategories()
        {
            DataTable dtCategories = objPSC.GetPrivateSmartConnectCategoriesList(ProfileID, CustomModuleId);
            ddlCategories.DataSource = dtCategories;
            ddlCategories.DataTextField = "CategoryName";
            ddlCategories.DataValueField = "CategoryID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("All", "0"));
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetAllManagePSCAddOns(string catID = "0")
        {

            hdnCommandArg.Value = "";
            dtCallIndexDetails = objPSC.GetAllManagePSCCallIndexAddOns(UserID, CustomModuleId, catID);

            int TotalBulletins = dtCallIndexDetails.Rows.Count;
            Session["dtPSCDetails"] = dtCallIndexDetails;
            hdnShowButtons.Value = "1";
            GetSavedUserData();
            GrdCallIndex.PageSize = GetPageSize();
            GrdCallIndex.DataSource = dtCallIndexDetails;
            GrdCallIndex.DataBind();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdCallIndex_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = e.Row.Cells.Count;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = e.Row.FindControl("lnkTitle") as LinkButton;
                Label lblbulletinthumb = e.Row.FindControl("lblthumb") as Label;
                string customID = lb.CommandArgument;
                string ImageDisID = Guid.NewGuid().ToString();

                if (File.Exists(Server.MapPath("~") + "\\Upload\\AppThumbs\\PrivateSmartConnectModule\\" + ProfileID.ToString() + "\\" + customID + ".jpg"))
                    lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/AppThumbs/PrivateSmartConnectModule/" + ProfileID.ToString() + "/" + customID + ".jpg?Guid=" + ImageDisID + "' />";
                else
                    lblbulletinthumb.Text = "";

                // for QR Code
                QRCode_Image_Name = customID + ".png";
                string QRCodeImgVirtualPath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\PrivateSmartConnectQRCodes\\" + ProfileID + "\\" + QRCode_Image_Name;
                if (File.Exists(QRCodeImgVirtualPath))
                {
                    string ImgFullPath = ConfigurationManager.AppSettings.Get("RootPath") + "/Upload/PrivateSmartConnectQRCodes/" + ProfileID + "/" + QRCode_Image_Name;
                    string QRCodePath = "<img src='" + ImgFullPath + "' border='1' width='100' height='100'/>";
                    Label ltrlQRCodeImg = e.Row.FindControl("lblQRCodeImg") as Label;
                    Button btnPreview = e.Row.FindControl("btnPreview") as Button;
                    ltrlQRCodeImg.Text = QRCodePath;
                    btnPreview.Visible = true;
                }



            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdCallIndex_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            hdnShowButtons.Value = "1"; ; // *** To show all buttons ex: Preview, edit etc. *** //
            hdnCommandArg.Value = "";
            dtCallIndexDetails = (DataTable)Session["dtPSCDetails"];
            GrdCallIndex.PageIndex = e.NewPageIndex;
            GrdCallIndex.DataSource = dtCallIndexDetails;
            GrdCallIndex.DataBind();
        }


        protected void GrdCallIndex_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtCallIndexDetails = (DataTable)Session["dtPSCDetails"];
            if (hdnsortdire.Value != "")
            {
                if (hdnsortdire.Value != SortExp)
                {
                    hdnsortdire.Value = SortExp;
                    SortDir = 0;
                    hdnsortcount.Value = "0";
                }
            }
            else
            {
                hdnsortdire.Value = SortExp;
            }
            DataView Dv = new DataView(dtCallIndexDetails);
            if (SortDir == 0)
            {
                if (SortExp == "Title")
                {
                    Dv.Sort = "Title desc";
                }
                else if (SortExp == "MobileNumber")
                {
                    Dv.Sort = "MobileNumber desc";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "Title")
                {
                    Dv.Sort = "Title ASC";
                }
                else if (SortExp == "MobileNumber")
                {
                    Dv.Sort = "MobileNumber ASC";
                }
                hdnsortcount.Value = "0";
            }
            Session["dtPSCDetails"] = Dv.ToTable();
            GrdCallIndex.DataSource = Dv;
            GrdCallIndex.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkTitle_Click(object sender, EventArgs e)
        {
            LinkButton lnkTitle = sender as LinkButton;
            ShowPreview(Convert.ToInt32(lnkTitle.CommandArgument));
        }

        private void ShowPreview(int customID)
        {
            DataTable dtCallIndexDetails = objPSC.GetPSCCallIndexByID(customID);
            if (dtCallIndexDetails.Rows.Count > 0)
            {
                string preview = string.Empty;
                lblNamme.Text = hdnAddOnName.Value;
                string htmlString = BuildHTML(dtCallIndexDetails).Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;");
                lblPreviewHTML.Text = htmlString;
                MPEPreview.Show();
            }
        }
        private string BuildHTML(DataTable dtCallIndexDetails)
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                string previewText = objCommon.GetPSCCallPreviewText();
                if (Convert.ToString(dtCallIndexDetails.Rows[0]["ImageUrls"]) != "")
                    previewText = previewText.Replace("#IMGTag#", "<div id='divImage1' style='border: 0px soild #dddddd;'><span class=\"imgStyle\"><img src=\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["ImageUrls"]) + "\"  /></span></div>");
                else
                    previewText = previewText.Replace("#IMGTag#", "");
                previewText = previewText.Replace("#Title#", Convert.ToString(dtCallIndexDetails.Rows[0]["Title"]));

                if (Convert.ToString(dtCallIndexDetails.Rows[0]["MobileNumber"]) != "")
                {
                    previewText = previewText.Replace("#PhoneNumber#", "<tr><td style='page-break-inside: avoid;'>Phone: <span style='color:#FF6600; font-weight: bold;'>" + Convert.ToString(dtCallIndexDetails.Rows[0]["MobileNumber"]) + "</span></td></tr>");

                }
                else
                {

                    previewText = previewText.Replace("#PhoneNumber#", "");
                }
                previewText = previewText.Replace("#Description#", Convert.ToString(dtCallIndexDetails.Rows[0]["Description"]));
                StringBuilder Rows = new StringBuilder();

                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAutoEmail"]))
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"padding:4px; border-top: 1px solid #6d6d6d;\"");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Email: </b></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["Email_Subject"]) + "\"</span></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["Email_Description"]) + "\"</span><td></tr>");
                    if (Convert.ToString(dtCallIndexDetails.Rows[0]["Email_GroupIDs"]) != "")
                    {
                        DataSet dsGroup = objPSC.GetPSCGroupByID(Convert.ToInt32(dtCallIndexDetails.Rows[0]["Email_GroupIDs"]));
                        if (dsGroup.Tables[0].Rows.Count > 0)
                        {
                            Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dsGroup.Tables[0].Rows[0]["GroupName"]) + "\"</span></td></tr>");
                        }
                    }
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAutoPushNotification"]))
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d; padding:4px;\">");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Push Notification:</b></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["PushNotification_Subject"]) + "\"</span></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["PushNotification_Description"]) + "\"</span></td></tr>");
                    if (Convert.ToString(dtCallIndexDetails.Rows[0]["PushNotification_GroupIDs"]) != "")
                    {
                        DataSet dsGroup = objPSC.GetPSCGroupByID(Convert.ToInt32(dtCallIndexDetails.Rows[0]["PushNotification_GroupIDs"]));
                        if (dsGroup.Tables[0].Rows.Count > 0)
                        {
                            Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dsGroup.Tables[0].Rows[0]["GroupName"]) + "\"</span></td></tr>");
                        }
                    }
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAutoTextMessage"]))
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d; padding:4px;\">");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Text Message:</b> <br/><br/></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["SMS_Subject"]) + "\"</span></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["SMS_Description"]) + "\"</span></td></tr>");
                    if (Convert.ToString(dtCallIndexDetails.Rows[0]["SMS_GroupIDs"]) != "")
                    {
                        DataSet dsGroup = objPSC.GetPSCGroupByID(Convert.ToInt32(dtCallIndexDetails.Rows[0]["SMS_GroupIDs"]));
                        if (dsGroup.Tables[0].Rows.Count > 0)
                        {
                            Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dsGroup.Tables[0].Rows[0]["GroupName"]) + "\"</span></td></tr>");
                        }
                    }
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                previewText = previewText.Replace("#ROWS#", Rows.ToString());
                string deviceInfo = "";
                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsGPSInformation"]) || Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAllPhoneInformation"]) || Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAnonymous"]) || Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsUploadImage"]))
                {
                    deviceInfo = "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d;\"><tr>";
                    if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsGPSInformation"]))
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Include Device GPS Location</td>";
                    if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAllPhoneInformation"]))
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Phone Information</td>";
                    deviceInfo = deviceInfo + "</tr><tr>";

                    if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsUploadImage"]))
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Include User Image</td>";
                    deviceInfo = deviceInfo + "<tr></table>";
                }
                previewText = previewText.Replace("##DeviceInfo##", deviceInfo);
                strHtml.Append(previewText);
                strHtml.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            }
            catch (Exception ex)
            {

            }
            return strHtml.ToString();
        }

        protected void chkVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                int _result = objPSC.ChangePSCCallAddOnVisiblity(Convert.ToInt32(hdnCommandArg.Value), C_UserID);
                if (_result == 0)
                    lblerrormessage.Text = Resources.LabelMessages.CallAddOnVisibilityFailed;
                else if (_result == 1) // *** MAKING VISIBLE *** //
                    lblmess.Text = Resources.LabelMessages.PublicCallAddOnVisibilityOn;
                else if (_result == 2) // *** MAKING INVISIBLE *** //
                    lblmess.Text = Resources.LabelMessages.PublicCallAddOnVisibilityOff;

            }
            GetAllManagePSCAddOns();
            hdnCommandArg.Value = "";
        }
        protected void linkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkEdit = sender as LinkButton;
                int hdnCommandArg = Convert.ToInt32(linkEdit.CommandArgument);

                string ModuleName = string.Empty;
                string authorPermission = string.Empty;
                string pubPermission = string.Empty;
                DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
                if (dtAddOn.Rows.Count == 1)
                    ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
                #region You don't have permission to edit Content without UserID -- code comment
                //if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                //{
                //    dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                //    if (dtpermissions.Rows.Count > 0)
                //    {
                //        for (int i = 0; i < dtpermissions.Rows.Count; i++)
                //        {
                //            if (dtpermissions.Rows[i]["ModuleName"].ToString() == ModuleName)
                //            {
                //                if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                //                    authorPermission = "A";
                //                if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                //                    pubPermission = "P";
                //                break;
                //            }
                //        }
                //    }
                //}

                //if ((hdnCommandArg.ToString() != "" && ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))) || (Convert.ToString(Session["C_USER_ID"]) == "" || Session["C_USER_ID"] == null))
                //{
                //    string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PublicCallIndexAutoMessage.aspx?CustomID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.ToString()));
                //    Response.Redirect(RedirectUrl);

                //}
                //else
                //{
                //    //You don't have permission to edit Content
                //}
                #endregion

                //Accessing Permission for Edit SmartConnect Button to Associate Manager

                string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PSCAutoMessage.aspx?CustomID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.ToString()) + "&CategoryID=" + EncryptDecrypt.DESEncrypt(ddlCategories.SelectedValue));
                Response.Redirect(RedirectUrl);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "linkEdit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void linkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkDelete = sender as LinkButton;
                int hdnCommandArg = Convert.ToInt32(linkDelete.CommandArgument);
                objCommon.InsertUserActivityLog("has deleted a custom module", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                objPSC.DeletePscindexItem(hdnCommandArg, UserID);

                GetAllManagePSCAddOns();

                lblmess.Text = Resources.LabelMessages.PrivateSmartConnectDeleted;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "linkDelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void AddDefultCallImages()
        {
            int UserModuleID = CustomModuleId;
            string callModuleDirectory = Server.MapPath("~/Upload/CallModule/" + ProfileID);
            try
            {
                if (!System.IO.Directory.Exists(callModuleDirectory))
                {
                    System.IO.Directory.CreateDirectory(callModuleDirectory);
                }
                callModuleDirectory = callModuleDirectory + "/" + UserModuleID;
                if (!System.IO.Directory.Exists(callModuleDirectory))
                {
                    System.IO.Directory.CreateDirectory(callModuleDirectory);
                    string sourcePath = Server.MapPath("~/Upload/DefaultPublicCallModules/" + DomainName);

                    int GroupID = 0;
                    DataTable dtCallModuleDefaultItems = objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PublicCallAddOns);
                    if (dtCallModuleDefaultItems.Rows.Count > 0)
                    {
                        bool IsIntiatePhoneCall = false;
                        bool IsCustomPredefinedMessage = true;
                        string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + UserModuleID + "/";
                        bool IsAnonymous = false; bool IsUploadImage = false;
                        int AppUserAnonymousType = Convert.ToInt32(USPDHUBDAL.AddOnDAL.AppUserAnonymousType.AppIdentityChoose);
                        for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                        {
                            try
                            {
                                string srcPath = sourcePath + "/" + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]);
                                if (File.Exists(srcPath))
                                {
                                    string destFile = System.IO.Path.Combine(callModuleDirectory, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]));
                                    File.Copy(srcPath, destFile, true);
                                }
                            }
                            catch (Exception ex)
                            { }

                            int customid = objAddOn.InsertUpdatePublicCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false,
                                 Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), GroupID.ToString(),
                                      false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), GroupID.ToString(), true, false,
                                     true, UserID, UserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]),
                                     Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]),
                                     Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])),
                                     false, IsIntiatePhoneCall, IsCustomPredefinedMessage, IsAnonymous, IsUploadImage, AppUserAnonymousType, 0);

                            if (dtCallModuleDefaultItems.Rows[i]["CallTitle"].ToString().Contains("Contact Us"))
                                objAddOn.InsertDefaultContact(customid, UserID);

                        }
                    }
                }//
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManagePublicCallIndexAddOns.aspx.cs", "AddDefultCallImages()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        #region QRCode Preview,Print and Download

        protected void btnQRCodeDownload_OnClick(object sender, EventArgs e)
        {
            //string Title = "";
            //string CategoryName = "";

            //Button btn = sender as Button;

            //GridViewRow row = btn.NamingContainer as GridViewRow;
            //LinkButton lb = row.FindControl("lnkTitle") as LinkButton;
            //string customID = lb.CommandArgument;
            //Title = lb.Text;
            //CategoryName = row.Cells[4].Text;
            //QRCode_Image_Name =customID + ".png";
            //string ImgFullPath = ConfigurationManager.AppSettings.Get("RootPath") + "/Upload/PrivateSmartConnectQRCodes/" + ProfileID + "/" + QRCode_Image_Name;
            //string QRPreview = objCommon.GetQRCodePreviewText();
            //QRPreview = QRPreview.Replace("#Title#", Title);
            //QRPreview = QRPreview.Replace("#QRCodeImage#", ImgFullPath);
            //QRPreview = QRPreview.Replace("#CategoryName#", CategoryName);
            try
            {
                int CustomID = Convert.ToInt32(hdnCustomID.Value);

                string QRPreview = Session["QRPreview"].ToString();
                objPSC.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\PrivateSmartConnectQRCodes\\", ProfileID, UserID, Convert.ToInt32(CustomID), QRPreview);
                string QRCodeFolderPath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\PrivateSmartConnectQRCodes\\" + ProfileID;
                string ImgName = CustomID + ".jpg";
                string Title = objCommon.RemoveSpecialCharacters(Session["Title"].ToString());
                if (File.Exists(QRCodeFolderPath + "\\" + ImgName))
                {
                    string FileName = "QRC" + CustomID + "_" + Title + ".jpg";
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileName + "\"");
                    Response.TransmitFile(QRCodeFolderPath + "\\" + ImgName);
                    Response.End();

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "btnQRCodeDownload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }


        }

        protected void btnQRCodePrint_OnClick(object sender, EventArgs e)
        {
            try
            {

                string url = RootPath + "/PrintPSCQRCode.aspx";
                ScriptManager.RegisterClientScriptBlock(this.btnQRCodePrint, this.GetType(), "Print", "window.open('" + url + "');", true);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "btnQRCodePrint_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnPreview = sender as Button;
                string Title = "";
                string CategoryName = "";

                GridViewRow row = btnPreview.NamingContainer as GridViewRow;
                LinkButton lb = row.FindControl("lnkTitle") as LinkButton;

                Title = lb.Text;
                Session["Title"] = Title;
                CategoryName = row.Cells[4].Text;
                ShowQRCodePreview(Convert.ToInt32(lb.CommandArgument), Title, CategoryName);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "btnPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void ShowQRCodePreview(int CustomID, string Title, string CategoryName)
        {
            try
            {
                string QRCodePath;
                QRCode_Image_Name = CustomID + ".png";

                string QRCodeImgVirtualPath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\PrivateSmartConnectQRCodes\\" + ProfileID + "\\" + QRCode_Image_Name;
                if (File.Exists(QRCodeImgVirtualPath))
                {
                    string ImgFullPath = ConfigurationManager.AppSettings.Get("RootPath") + "/Upload/PrivateSmartConnectQRCodes/" + ProfileID + "/" + QRCode_Image_Name;
                    QRCodePath = "<img src='" + ImgFullPath + "' border='0'/>";
                    string QRPreview = objCommon.GetQRCodePreviewText();
                    QRPreview = QRPreview.Replace("#Title#", Title);
                    QRPreview = QRPreview.Replace("#QRCodeImage#", ImgFullPath);
                    QRPreview = QRPreview.Replace("#CategoryName#", CategoryName);
                    litQRCode.Text = QRPreview;
                    hdnCustomID.Value = Convert.ToString(CustomID);
                    Session["QRPreview"] = QRPreview;
                }
                modelQRCodePreview.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "ShowQRCodePreview", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        #endregion


        protected void ddlCategories_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string catID = ddlCategories.SelectedValue.ToString();
            GetAllManagePSCAddOns(catID);
        }
        DropDownList ddlPageSize;
        private void SaveUserSettings()
        {
            try
            {
                string XMLdata = "<PrivateSmartConnectAddOns MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
                var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_PrivateSmartConnectAddOns, CustomModuleId);
                if (dtDisplayReadFirst.Rows.Count == 0)
                    objBus.UserCustomizeSettings(0, ProfileID, UserID, WebConstants.Tab_PrivateSmartConnectAddOns, XMLdata, CustomModuleId);
                else
                    objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, WebConstants.Tab_PrivateSmartConnectAddOns, XMLdata, CustomModuleId);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManagePSCCallIndexAddOns.aspx.cs", "SaveUserSettings()", ex.Message,
                       Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkcopy_Click(object sender, EventArgs e)
        {
            LinkButton linkCopy = sender as LinkButton;
            hdnCommandArg.Value = linkCopy.CommandArgument;
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count == 1)
                ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PSCAutoMessage.aspx?CustomID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value) + "&CategoryID=" + EncryptDecrypt.DESEncrypt(ddlCategories.SelectedValue) + "&Type=Copy");
            Response.Redirect(RedirectUrl);
            //if (hdnCommandArg.Value != "")
            //{
            //    if (File.Exists(Server.MapPath("~") + "\\Upload\\AppThumbs\\PrivateSmartConnectModule\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
            //        lblBulletinImage.Text = "<img src='" + RootPath + "/Upload/AppThumbs/PrivateSmartConnectModule/" + ProfileID.ToString() + "/"  + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
            //    else
            //        lblBulletinImage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
            //    MPECopy.Show();
            //    txtBulletinName.Text = "";
            //}
        }

        protected void btnCopyBulletin_Click(object sender, EventArgs e)
        {

            CopyQRConnect();

        }
        protected void CopyQRConnect()
        {
            DataTable dtBulletinCheck = new DataTable();
            try
            {
                if (hdnCommandArg.Value != "")
                {
                    string RedirectUrl = string.Empty;

                    int CopyBullentinID = objPSC.CopyQRConnect(Convert.ToInt32(hdnCommandArg.Value), txtBulletinName.Text.Trim(), UserID, Convert.ToInt32(Session["ProfileID"].ToString()));
                    if (CopyBullentinID > 0)
                    {
                        Session["CustomID"] = CopyBullentinID;
                        Session["CCustomID"] = Convert.ToInt32(hdnCommandArg.Value);

                        RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/PSCAutoMessage.aspx?CustomID=" + EncryptDecrypt.DESEncrypt(CopyBullentinID.ToString()) + "&Type=Copy");

                        // Save User Activity Log
                        objCommon.InsertUserActivityLog("has created a bulletin titled <b>" + txtBulletinName.Text + "</b> by copying <b>" + hdnBulletinTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                        Response.Redirect(RedirectUrl);

                    }
                    else
                    {
                        lbleditext.Text = "Sorry, an error has been occurred while copy the content. Please try again.";
                        MPECopy.Show();
                    }
                }
                else
                {
                    lbleditext.Text = "Sorry, you already have  content with this name; please enter another name.";
                    MPECopy.Show();
                }
            }
            catch (Exception ex)
            {
                lbleditext.Text = ex.Message.ToString();
            }

        }
        public int GetPageSize()
        {
            int ReturnValue = 5;
            if (!string.IsNullOrEmpty(PageSizes.SelectedPage))
                ReturnValue = Convert.ToInt32(PageSizes.SelectedPage);
            return ReturnValue;
        }
        public void GetSavedUserData()
        {
            string XMLValue = string.Empty;
            DataTable dtDisplayReadFirst = new DataTable();
            dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_PrivateSmartConnectAddOns, CustomModuleId);
            if (dtDisplayReadFirst.Rows.Count > 0)
            {
                XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(XMLValue);
                if (XMLValue != "")
                {
                    if (xmldoc.SelectSingleNode("PrivateSmartConnectAddOns/@MessagePageSize") != null)
                    {
                        PageSizes.SelectedPage = xmldoc.SelectSingleNode("PrivateSmartConnectAddOns/@MessagePageSize").Value;
                    }
                }
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveUserSettings();
            GrdCallIndex.PageSize = GetPageSize();
            GrdCallIndex.DataSource = (DataTable)Session["dtPSCDetails"];
            GrdCallIndex.DataBind();
        }

    }
}