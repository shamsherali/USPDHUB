using System;
using System.Linq;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.Web;
using System.Web.UI.HtmlControls;

namespace USPDHUB
{
    public partial class ViewBulletin : System.Web.UI.Page
    {
        public int BulletinID = 0;
        public int SchBulletinID = 0;
        public int UserID = 0;
        public int ProfileID = 0;
        public string BulletinPreview = string.Empty;
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objbus = new BusinessBLL();
        public string EmailAddress = string.Empty;
        public string[] Split;
        public string RootPath = "";
        CommonBLL objCommon = new CommonBLL();
        public string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                if (!IsPostBack)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    objCommon.CreateDomainUrl(url);
                }
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (Request.QueryString["SID"] != null)
                {
                    if (Request.QueryString["SID"].ToString() != "")
                    {
                        string iD = EncryptDecrypt.DESDecrypt(Request.QueryString["SID"].ToString());
                        BulletinID = Convert.ToInt32(iD);
                    }
                }
                if (Request.QueryString["SchID"] != null)
                {
                    if (Request.QueryString["SchID"].ToString() != "")
                    {
                        string schID = EncryptDecrypt.DESDecrypt(Request.QueryString["SchID"].ToString());
                        SchBulletinID = Convert.ToInt32(schID);
                    }
                }
                if (Request.QueryString["REA"] != null)
                {
                    if (Request.QueryString["REA"].ToString() != "")
                    {
                        EmailAddress = EncryptDecrypt.DESDecrypt(Request.QueryString["REA"].ToString());
                    }
                }
                if (!IsPostBack)
                {
                    // *** Adding page title and meta keys for page *** //
                    DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "DashboardKeys");
                    if (dtConfigPageKeys.Rows.Count > 0)
                    {
                        HtmlMeta htmlMeta = new HtmlMeta();
                        foreach (DataRow row in dtConfigPageKeys.Rows)
                        {
                            if (row[0].ToString() == "Title")
                                this.Page.Title = row[1].ToString();
                            else if (row[0].ToString() == "author")
                                htmlMeta.Attributes.Add("author", row[1].ToString());
                            else if (row[0].ToString() == "description")
                                htmlMeta.Attributes.Add("description", row[1].ToString());
                            else if (row[0].ToString() == "keywords")
                                htmlMeta.Attributes.Add("keywords", row[1].ToString());
                        }
                        HtmlHead header = new HtmlHead();
                        header.Controls.Add(htmlMeta);
                    }
                    GetBulletinDetails();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ViewBulletin.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void GetBulletinDetails()
        {
            try
            {
                string unsubscribeContent = string.Empty;
                string bulletinBody = string.Empty;
                DataTable dtSchBulletinDetails;
                bool contactusFlag = false;
                bool storelinksShare = false;
                string shareUpdate = string.Empty;
                string templateTitle = "";

                if (SchBulletinID != 0)
                {
                    dtSchBulletinDetails = objBulletin.GetBulletinDetailsBySchID(SchBulletinID);
                }
                else
                {
                    dtSchBulletinDetails = objBulletin.GetBulletinByID(BulletinID);
                }
                if (dtSchBulletinDetails.Rows.Count > 0)
                {

                    bulletinBody = dtSchBulletinDetails.Rows[0]["Bulletin_HTML"].ToString();
                    templateTitle = Convert.ToString(dtSchBulletinDetails.Rows[0]["Template_Name"]);

                    if (SchBulletinID != 0)
                    {
                        ProfileID = Convert.ToInt32(dtSchBulletinDetails.Rows[0]["Sender_ProfileID"].ToString());
                        UserID = Convert.ToInt32(dtSchBulletinDetails.Rows[0]["Sender_UserID"].ToString());
                        contactusFlag = Convert.ToBoolean(dtSchBulletinDetails.Rows[0]["Contactuschecked"].ToString());
                        shareUpdate = dtSchBulletinDetails.Rows[0]["ShareBulletin"].ToString();
                        BulletinID = Convert.ToInt32(dtSchBulletinDetails.Rows[0]["Bulletin_ID"].ToString());
                        storelinksShare = Convert.ToBoolean(dtSchBulletinDetails.Rows[0]["StoreLinksChecked"].ToString());
                    }
                    else
                    {
                        ProfileID = Convert.ToInt32(dtSchBulletinDetails.Rows[0]["Profile_ID"].ToString());

                        DataTable dtUsers = objbus.GetuserdetailsByProfileID(ProfileID);
                        if (dtUsers.Rows.Count > 0)
                        {
                            UserID = Convert.ToInt32(dtUsers.Rows[0]["User_ID"].ToString());
                        }
                    }
                }



                string bulletinHeader = string.Empty;
                if (templateTitle.ToLower().Contains("Weekly Report".ToLower()) || templateTitle.ToLower().Contains("Crime Report".ToLower()))
                {
                    bulletinHeader = objCommon.GetHeaderForBulletins(UserID, ProfileID, true);
                }
                else
                {
                    bulletinHeader = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
                }

                //bulletinHeader = objCommon.GetHeaderForBulletins(UserID, ProfileID);
                bulletinBody = bulletinHeader.Replace("#BuildHtmlForForm#", bulletinBody);

                BulletinPreview = "<html><head></head><body><table border='0' cellspacing='0' cellpadding='0' align='center' style='border: solid 2px #F4EBEB;'><tr><td align='right' style='padding: 10px;' colspan='2'><a href='#' onclick='CloseWindow()'><img src='" + RootPath + "/images/Dashboard/btn-close.gif' border='0' /><a></td></tr><tr><td colspan='2' style='padding: 30px;'>" + bulletinBody + "</td></tr>";
                unsubscribeContent = UserProfileUnsubscribeLink(ProfileID, UserID);
                if (contactusFlag == true)
                {
                    string contactus = "<a href=\"" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(BulletinID.ToString()) + "&ET=BL\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                    BulletinPreview = BulletinPreview + @"<tr><td colspan='2' align='center' style='padding:10px;'>" + contactus + "</td></tr>";
                }
                if (Request.QueryString["SI"] != null)
                {
                    if (Request.QueryString["SI"].ToString() != "")
                    {
                        char[] separator = new char[] { '-' };
                        string socialIcons = Request.QueryString["SI"].ToString();
                        Split = socialIcons.Split(separator);
                        if (Split[0] == "1")
                        {
                            string contactus = "<a href=\"" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(BulletinID.ToString()) + "&ET=BL\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                            BulletinPreview = BulletinPreview + @"<tr><td colspan='2' align='center' style='padding:10px;'>" + contactus + "</td></tr>";
                        }
                        if (Split.Length > 1 && Split[Split.Length - 1] == "1")
                        {
                            StoreLinks();
                        }
                    }
                }
                else if (storelinksShare)
                    StoreLinks();
                if (shareUpdate != "")
                {
                    BulletinPreview = BulletinPreview + @"<tr><td colspan='2' align='center' style='padding-top: 5px;'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td align='center'>" + shareUpdate + "</td><td></td></tr></table></td></tr>";
                }
                BulletinPreview = BulletinPreview + @"<tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; width:700px; border-top: solid 1px #F4EBEB;'>" + unsubscribeContent + "</td><td align='right' valign='top' style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB;'><a href=\"" + RootPath + "\" target=\"_blank\"><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>";
                BulletinPreview = BulletinPreview.Replace("&#60;recipient's email address&#62;", EmailAddress);


                BulletinPreview = objCommon.ReplaceShortURltoHtmlString(BulletinPreview);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ViewBulletin.aspx.cs", "GetBulletinDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        private void StoreLinks()
        {
            try
            {
                string storelinks = "";
                DataTable dtStoreLinks = objbus.GetStoreDetailsById(UserID);
                if (dtStoreLinks.Rows.Count > 0)
                {
                    if (Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) != "")
                        storelinks = "<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/iosemail.png' alt='iOS Store' border='0'/></a>";
                    if (Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) != "")
                        storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/androidemail.png' alt='Android Store' border='0'/></a>";
                    if (Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) != "")
                        storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/windowsemail.png' alt='Windows Phone Store' border='0'/></a>";
                    BulletinPreview = BulletinPreview + @"<tr><td style='padding:10px;' colspan='2' align='center'>" + Convert.ToString(dtStoreLinks.Rows[0]["StoreLinksTitle"]) + "</td></tr><tr><td style='padding:10px; padding:left: 50px;' colspan='2' align='center'>" + storelinks + "</td></tr>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ViewBulletin.aspx.cs", "StoreLinks", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string UserProfileUnsubscribeLink(int profileID, int userID)
        {
            string unSubscribeLinkText = "";
            try
            {
                DataTable dtProfileAddress = objbus.GetProfileDetailsByProfileID(profileID);
                string totalAddress = "";
                string profileName = "";
                if (dtProfileAddress.Rows.Count > 0)
                {
                    if (dtProfileAddress.Rows[0]["Profile_name"].ToString() != "")
                    {
                        profileName = dtProfileAddress.Rows[0]["Profile_name"].ToString();
                    }
                    if (dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString() != "")
                    {
                        totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString();
                    }
                    if (dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString() != "")
                    {
                        if (totalAddress != "")
                        {
                            totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                        }
                        else
                        {
                            totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                        }
                    }
                    if (dtProfileAddress.Rows[0]["Profile_City"].ToString() != "")
                    {
                        if (totalAddress != "")
                        {
                            totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_City"].ToString();
                        }
                        else
                        {
                            totalAddress = dtProfileAddress.Rows[0]["Profile_City"].ToString();
                        }
                    }
                    if (dtProfileAddress.Rows[0]["Profile_State"].ToString() != "")
                    {
                        if (totalAddress != "")
                        {
                            totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_State"].ToString();
                        }
                        else
                        {
                            totalAddress = dtProfileAddress.Rows[0]["Profile_State"].ToString();
                        }
                    }
                    if (dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString() != "")
                    {
                        if (totalAddress != "")
                        {
                            totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                        }
                        else
                        {
                            totalAddress = dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                        }
                    }
                }
                unSubscribeLinkText = "This message was sent from " + profileName + " to &#60;recipient's email address&#62;. It was sent from: " + totalAddress + ". If you no longer wish to receive our updates, <a href=\"" + RootPath + "/UnsubscribeBulletin.aspx?ID=" + EncryptDecrypt.DESEncrypt(userID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(BulletinID.ToString()) + "\" target=\"_blank\">Click here</a> to unsubscribe.";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ViewBulletin.aspx.cs", "UserProfileUnsubscribeLink", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return unSubscribeLinkText;
        }
    }
}