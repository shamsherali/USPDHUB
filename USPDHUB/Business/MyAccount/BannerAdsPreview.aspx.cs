﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using System.Threading;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Xml.Linq;
using System.Web.Services;

namespace USPDHUB.Business.MyAccount
{
    public partial class BannerAdsPreview : BaseWeb
    {
        public string RootPath = "";
        public string DomainName = "";
        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        public string ProfileBGImagesPath = "ProfileBGImages";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string VerticalCodeFolderName = "";
        public string xmlSettings = "";
        DataTable dtCustomModules;
        USPDHUBBLL.MobileAppSettings objMobileSettings = new USPDHUBBLL.MobileAppSettings();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
                lblUpdateMsg.Text = "";
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (!IsPostBack)
                {
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string Permission_Type = string.Empty;
                        Permission_Type = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.BannerAds);
                        if (Permission_Type == "")
                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                    }
                    hdnUploadTye.Value = "";
                    LoadCurrentBGImagesPreview();
                    if (Session["SaveMessage"] != null)
                    {
                        lblUpdateMsg.Text = Convert.ToString(Session["SaveMessage"]);
                        Session.Remove("SaveMessage");
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadCurrentBGImagesPreview()
        {
            try
            {
                hdnToggle.Value = "0";
                StringBuilder objImgPreview = new StringBuilder();
                ltrBGImagePreview.Text = "";
                string strfilepath = Server.MapPath("~") + "\\BulletinPreview\\BGImagePreview.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    objImgPreview.Append(input);
                }
                re.Close();
                string displayMobResolution = Resources.ValidationValues.DisplayMobileResolution;
                string ImageDirectory = Server.MapPath("~/Upload/" + ProfileBGImagesPath + "/" + ProfileID + "/" + ProfileID + "_bg_" + displayMobResolution + ".png");
                string img320Preview = "";
                if (File.Exists(ImageDirectory))
                    img320Preview = " background-image: url('" + RootPath + "/Upload/" + ProfileBGImagesPath + "/" + ProfileID + "/" + ProfileID + "_bg_" + displayMobResolution + ".png?id=" + Guid.NewGuid() + "');";
                objImgPreview.Replace("#BackgroundBGImage#", img320Preview).Replace("##BindAppIcons##", LoadButtonsOnApp(displayMobResolution));
                objImgPreview = LoadBanners(objImgPreview);
                LoadProfileAddress(objImgPreview);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "LoadCurrentBGImagesPreview", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string LoadButtonsOnApp(string displayMobResolution)
        {
            StringBuilder objFooter = new StringBuilder();
            try
            {
               VerticalCodeFolderName = USPDHUBDAL.MServiceDAL.GetVerticalNameByProfileID(ProfileID);
                dtCustomModules = objBus.DashboardIcons(UserID);
                if (dtCustomModules.Rows.Count > 0)
                {
                    string TimeStampGUID = DateTime.Now.ToString("yyyyMMddHHmmss");
                    objFooter.Append("<table class='footerNav' id=\"app_navigation_bar\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr>");
                    int tabsCount = 0;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtCustomModules.Rows[i]["IsVisible"]))
                        {
                            if (tabsCount > 0)
                                objFooter.Append("<td class=\"ui-btn-separator\"></td>");
                            objFooter.Append("<td class=\"ui-btn-up\"><a href=\"javascript:void(0);\" data-role=\"button\" class=\"navigation_bar_item clr_navBar_item_bg clr_navBar_item_brdr clr_navBar_item_hdlTxt ui-btn-up\"><div class=\"navigation_bar_item_bubble clr_navBar_item_bubbleBg\">");
                            objFooter.Append(" <img class=\"item_image\" src=\"" + RootPath + "/Upload/ProfileTabIcons2.0/" + VerticalCodeFolderName + "/" + displayMobResolution + "/" + Convert.ToString(dtCustomModules.Rows[i]["AppIcon"]) + "_n_" + displayMobResolution + ".png?id=" + TimeStampGUID + "\" alt=\"\">");
                            objFooter.Append("<div class=\"navigation_bar_item_text item_text\">" + Convert.ToString(dtCustomModules.Rows[i]["TabName"]) + "</div></div></a></td>");
                            tabsCount++;
                        }
                        if (tabsCount == 4)
                            break;
                    }
                    objFooter.Append("</tr></table>");
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "LoadButtonsOnApp", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return objFooter.ToString();
        }
        private void LoadProfileAddress(StringBuilder strHTML)
        {
            try
            {
                string profileAddress = "";
                string logoimg = "<div class=\"logo\" style=\"width:52px;\"><img class=\"cominglogo\" src=\"../../images/MobileDevice/logo.jpg\" width=\"52\" height=\"52\" alt=\"\"></div>";
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);
                DataTable dtMobileAppSettings = objMobileSettings.GetMobileAppSetting(UserID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                    if (IsShortLogo)
                    {
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                        {
                            profileAddress = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                            if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                                profileAddress += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                        }
                        string city = "";
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                            city = profileAddress += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                        {
                            if (city == "")
                                profileAddress += "<br/>" + dtProfile.Rows[0]["State_Code"].ToString();
                            else
                                profileAddress += ", " + dtProfile.Rows[0]["State_Code"].ToString();
                        }
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                            profileAddress += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();
                        if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                        {
                            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                                profileAddress += "<br/>" + Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value);
                        }
                    }
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        string fileName = dtProfile.Rows[0]["Profile_logo_path"].ToString();
                        string extension = System.IO.Path.GetExtension(Server.MapPath(fileName));
                        string filePath = Server.MapPath("~/Upload/Logos/" + ProfileID + "/" + fileName.Replace(extension, "") + "_thumb" + extension);
                        if (File.Exists(filePath))
                            fileName = fileName.Replace(extension, "_thumb" + extension);
                        logoimg = "<div class=\"logo\" + style=\"width:" + (IsShortLogo ? "52px;" : "300px;") + "\"><img class=\"" + (IsShortLogo ? "shortlogo" : "longlogo") + "\" src='" + RootPath + "/Upload/Logos/" + ProfileID + "/" + fileName + "?Guid=" + imageDisID + "'/></div>";
                    }
                }
                profileAddress = logoimg + (IsShortLogo ? "<div class=\"Address\">" + profileAddress + "</div>" : "");
                string profileName = Convert.ToString(dtProfile.Rows[0]["Profile_name"]);
                if (profileName.Length > 30)
                    profileName = profileName.Substring(0, 30) + "...";
                strHTML.Replace("##ProfileName##", profileName).Replace("##LogoAddress##", profileAddress).Replace("##DomainName##", DomainName);
                ltrBGImagePreview.Text = strHTML.ToString();
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "LoadProfileAddress", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public StringBuilder LoadBanners(StringBuilder objImgPreview)
        {
            try
            {
                ltrBannersAds.Text = "";
                string displayMobResolution = Resources.ValidationValues.DisplayMobileResolution;
                string BannerAdspath = RootPath + "/Upload/BannerAds/" + ProfileID;
                StringBuilder strBanners = new StringBuilder();
                StringBuilder strUserAds = new StringBuilder();
                DataTable dtBanners = objBus.GetUserBannerAds(ProfileID);
                int maxBannerAds = Convert.ToInt32(lblMaxAds.Text.Trim());
                DataRow[] drAdd;
                strBanners.Clear();
                strUserAds.Clear();
                btnUpdate.Visible = false;
                if (dtBanners.Rows.Count > 0)
                {
                    string strfilepath = Server.MapPath("~") + "\\BulletinPreview\\BannerAdHeader.txt";
                    StreamReader re = File.OpenText(strfilepath);
                    string input = string.Empty;
                    while ((input = re.ReadLine()) != null)
                    {
                        strUserAds.Append(input);
                    }
                    re.Close();
                    btnUpdate.Visible = true;
                }
                for (int i = 0; i < maxBannerAds; i++)
                {
                    strUserAds.Append("<div class=\"slotheader\"><div class=\"slotname\">##SlotName##</div><div class=\"slotblock\">");
                    drAdd = dtBanners.Select("Order_No=" + (i + 1));
                    if (drAdd.Length > 0)
                    {
                        //<a href=\"" + (Convert.ToString(drAdd[0]["Hyperlink_Url"]) != "" ? Convert.ToString(drAdd[0]["Hyperlink_Url"]) + "\" target=\"_blank\"" : "javascript:void(0);\"") + ">
                        strUserAds.Append("<a href=\"javascript:EditBannerAd('" + EncryptDecrypt.DESEncrypt(Convert.ToString(drAdd[0]["BannerAd_Id"])) + "', ' " + EncryptDecrypt.DESEncrypt((i + 1).ToString()) + "');\"><img src=\"" + BannerAdspath + "/" + Convert.ToString(drAdd[0]["Ads_Timespan"]) + "_" + displayMobResolution + ".png?id=" + Guid.NewGuid() + "\"/></a>");
                        strUserAds.Append("</div><div class=\"displayblock\"><input type=\"checkbox\" class=\"appdisplaycheck\" id=\"chk" + Convert.ToString(drAdd[0]["BannerAd_Id"]) + "\"" + (Convert.ToBoolean(drAdd[0]["App_Display"]) ? " checked" : "") + "/></div>");
                        strUserAds.Append("<div class=\"deleteblock\"><a href=\"javascript:DeleteBannerAd('" + Convert.ToString(drAdd[0]["BannerAd_Id"]) + "');\"><img src=\"" + RootPath + "/images/Dashboard/delete1.gif" + "\"/></a></div>");
                        if (Convert.ToBoolean(drAdd[0]["App_Display"]))
                        {
                            strBanners.Append("<div><a href=\"" + (Convert.ToString(drAdd[0]["Hyperlink_Url"]) != "" ? Convert.ToString(drAdd[0]["Hyperlink_Url"]) + "\" target=\"_blank\"" : "javascript:void(0);\"") + "><img class=\"banneraddrotator\" src=\"" + BannerAdspath + "/" + Convert.ToString(drAdd[0]["Ads_Timespan"]) + "_" + displayMobResolution + ".png?id=" + Guid.NewGuid() + "\"" + "/></a></div>");
                        }
                    }
                    else
                    {
                        strUserAds.Append("<a href=\"javascript:UploadNewBannerAd('" + EncryptDecrypt.DESEncrypt((i + 1).ToString()) + "');\">Click here to upload</a>");
                        strUserAds.Append("</div>");
                    }
                    strUserAds.Replace("##SlotName##", "Ad " + (i + 1));
                    strUserAds.Append("</div><div style=\"clear:both;\"></div>");
                }
                objImgPreview = objImgPreview.Replace("##BindBanners##", strBanners.ToString() != "" ? ("<div id=\"slideshow\">" + strBanners.ToString() + "</div>") : "");
                ltrBannersAds.Text = strUserAds.ToString();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "LoadBanners", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return objImgPreview;
        }
        protected void lnkClickUpload_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/BannerAddUpload.aspx"));
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int bannerAdId = Convert.ToInt32(hdnOrderNo.Value);
                DataTable dtBannerAd = objBus.GetBannerAdById(bannerAdId);
                objBus.UpdateBannerAdDelete(bannerAdId, C_UserID);
                if (dtBannerAd.Rows.Count > 0)
                {
                    string[] adResolutions = Resources.ValidationValues.ImageResolutions.Split(',');
                    string adTimeStamp = Convert.ToString(dtBannerAd.Rows[0]["Ads_Timespan"]);
                    if (adResolutions.Length > 0)
                    {
                        string bannerAdFilepath = Server.MapPath("~/Upload/BannerAds/" + ProfileID + "/");
                        for (int i = 0; i < adResolutions.Length; i++)
                        {
                            if (File.Exists(bannerAdFilepath + adTimeStamp + "_" + adResolutions[i] + ".png"))
                                File.Delete(bannerAdFilepath + adTimeStamp + "_" + adResolutions[i] + ".png");
                        }
                    }
                }
                lblUpdateMsg.Text = "<font color='green'>" + Resources.LabelMessages.BannerAdDeleteSuccess + "</font>";
                LoadCurrentBGImagesPreview();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "BindLoadEvents();", true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "btnDelete_Click()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string checkedList = hdnBannerAdsResult.Value.ToString();
                if (checkedList.StartsWith("##"))
                {
                    checkedList = checkedList.Substring(2);
                }
                var rows = checkedList.Split(new string[] { "##" }, StringSplitOptions.None);
                for (int i = 0; i < rows.Length; i++)
                {
                    string bannerAdId = "";
                    string updateFlag = "";

                    var cols = rows[i].ToString().Split(',');
                    bannerAdId = cols[0].ToString();
                    updateFlag = cols[1].ToString();

                    int CUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                    if (HttpContext.Current.Session["C_USER_ID"] != null && HttpContext.Current.Session["C_USER_ID"].ToString() != "")
                        CUserID = Convert.ToInt32(HttpContext.Current.Session["C_USER_ID"]);
                    objBus.UpdateBannerAdAppDisplay(Convert.ToInt32(bannerAdId), Convert.ToBoolean(updateFlag), CUserID);
                }
                lblUpdateMsg.Text = "<font color='green'>" + Resources.LabelMessages.BannerAdsAppdisplaySuccess + "</font>";
                LoadCurrentBGImagesPreview();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "BindLoadEvents();", true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "btnUpdate_Click()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btndashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        [WebMethod]
        public static string UpdateAppDiplayItems(string bannerAdId, string updateFlag)
        {
            string _result = "failed";
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                int CUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                if (HttpContext.Current.Session["C_USER_ID"] != null && HttpContext.Current.Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(HttpContext.Current.Session["C_USER_ID"]);
                objBus.UpdateBannerAdAppDisplay(Convert.ToInt32(bannerAdId), Convert.ToBoolean(updateFlag), CUserID);
                _result = "success";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsPreview.aspx.cs", "UpdateAppDiplayItems()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return _result;
        }
    }
}