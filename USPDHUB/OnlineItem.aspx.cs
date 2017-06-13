using System;
using System.Linq;
using System.Data;
using USPDHUBBLL;
using USPDHUBDAL;
using System.Xml.Linq;

namespace USPDHUB
{
    public partial class OnlineItem : System.Web.UI.Page
    {
        public int CustomID = 0;
        AddOnBLL objAddOn = new AddOnBLL();
        CommonBLL objCommon = new CommonBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["CMID"] != null && Request.QueryString["CMID"] != "")
                {
                    string blid = Request.QueryString["CMID"].ToString().Replace(" ", "+");
                    blid = blid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                    int length = blid.Length;
                    if (blid[length - 1] != '=')
                    {
                        blid += '=';
                    }
                    blid = EncryptDecrypt.DESDecrypt(blid);
                    CustomID = Convert.ToInt32(blid);

                }
                else
                {
                    if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                        CustomID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString()));
                }

                if (!IsPostBack)
                {
                    if (CustomID > 0)
                    {
                        DataTable dtBulletin = objAddOn.GetCustomModuleByID(CustomID);
                        if (dtBulletin.Rows.Count > 0)
                        {
                            lblTitle.Text = dtBulletin.Rows[0]["Bulletin_Title"].ToString();
                            string bulletinHTML = dtBulletin.Rows[0]["Bulletin_HTML"].ToString();
                            int UserID = Convert.ToInt32(dtBulletin.Rows[0]["User_ID"]);
                            int ProfileID = Convert.ToInt32(dtBulletin.Rows[0]["Profile_ID"]);
                            string bulletinHeader = string.Empty;  
                                bulletinHeader = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);                           
                            bulletinHTML = bulletinHeader.Replace("#BuildHtmlForForm#", bulletinHTML);
                            bulletinHTML = objCommon.ReplaceShortURltoHtmlString(bulletinHTML);
                            lblbulletin.Text = bulletinHTML;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlineItem.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));


                lblbulletin.Text = ex.Message;
            }
        }

        public string GetConfigSettings(string pProfileID, string pType, string pConfigName)
        {
            string returnValue = "";
            try
            {
                string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(pProfileID));


                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);


                string domain = objCommon.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());

                var dtConfigs = objCommon.GetVerticalConfigsByType(domain, pType);
                if (dtConfigs.Rows.Count > 0)
                {
                    for (int i = 0; i < dtConfigs.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtConfigs.Rows[i]["Name"]).ToLower() == pConfigName.ToLower())
                        {
                            returnValue = Convert.ToString(dtConfigs.Rows[i]["Value"]).Trim();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlineItem.aspx.cs", "GetConfigSettings", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
            return returnValue;
        }

        public string GetHeaderForOnlineBulletins(int userID, int profileID)
        {
            try{
            string address = string.Empty;
            string xmlSettings = string.Empty;
            string strHeader = "";
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\CommonHeader.txt";
            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                strHeader = strHeader + input;
            }
            re.Close();
            re.Dispose();
            string RootPath = GetConfigSettings(profileID.ToString(), "Paths", "RootPath"); ;
            strHeader = strHeader.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtProfile.Rows.Count > 0)
            {
                DataTable dtMobileAppSettings = USPDHUBDAL.MobileAppSettings.GetMobileAppSetting(userID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    InBuiltDataBLL objInbuilt = new InBuiltDataBLL();
                    xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);

                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value) == true)
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                        strHeader = strHeader.Replace("#HeaderLogo#", objInbuilt.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, profileID));
                    if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                    {
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                        {
                            strHeader = strHeader.Replace("#EmergencyNumber#", Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value));
                        }
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                    {
                        address = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                            address += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    string city = "";
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                        city = address += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                    {
                        if (city == "")
                            address += "<br/>" + dtProfile.Rows[0]["Profile_State"].ToString();
                        else
                            address += ", " + dtProfile.Rows[0]["Profile_State"].ToString();
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                        address += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();
                }
            }
            strHeader = strHeader.Replace("#HeaderLogo#", "").Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
            return strHeader;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlineItem.aspx.cs", "GetHeaderForOnlineBulletins", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                return "";
            }
        }
    }
}