using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;

namespace USPDHUBBLL
{
    public class MobileAppSettings
    {
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllCategories()
        {
            return USPDHUBDAL.MobileAppSettings.GetAllCategories();
        }

        /// <summary>
        /// Get Search Result
        /// </summary>
        /// <param name="pKeyword">Keyword</param>
        /// <param name="pCatType">CatType</param>
        /// <returns>DataTable</returns>
        public DataTable GetSearchResult(string pKeyword, string pCatType)
        {
            return USPDHUBDAL.MobileAppSettings.GetSearchResult(pKeyword, pCatType);
        }

        /// <summary>
        /// Get Mobile App Setting
        /// </summary>
        /// <param name="pUserID">UserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetMobileAppSetting(int pUserID)
        {
            return USPDHUBDAL.MobileAppSettings.GetMobileAppSetting(pUserID);
        }

        /// <summary>
        /// Insert Mobile App Settings
        /// </summary>
        /// <param name="pSettingID">SettingID</param>
        /// <param name="pPSettingsValue">PSettingsValue</param>
        /// <param name="pUserID">UserID</param>
        /// <param name="pEnableMobileApp">EnableMobileApp</param>
        /// <param name="ID">ID</param>
        /// <param name="pEmergencyNumber">EmergencyNumber</param>
        /// <param name="pAlternatePH">AlternatePH</param>
        /// <returns>Int</returns>
        public int InsertMobileAppSettings(int pSettingID, string pPSettingsValue, int pUserID, bool pEnableMobileApp, int ID,
            string pEmergencyNumber, string pAlternatePH)
        {
            return USPDHUBDAL.MobileAppSettings.InsertMobileAppSettings(pSettingID, pPSettingsValue, pUserID, pEnableMobileApp, ID, pEmergencyNumber, pAlternatePH);
        }

        /// <summary>
        /// Get Mobile App Setting Tab Name
        /// </summary>
        /// <param name="pUserID">UserID</param>
        /// <param name="type">type</param>
        /// <param name="DomainName">DomainName</param>
        /// <returns>String</returns>
        public string GetMobileAppSettingTabName(int pUserID, string type, string DomainName)
        {
            BusinessBLL objbus = new BusinessBLL();
            //string updates = "", events = "", bulletins = "", surveys = "", aboutUs = "";
            string defaultTabName = "", tabName = "";
            DataTable dtDefaultProfileTabs = objbus.GetDefaultProfileTabNames(DomainName);
            for (int k = 0; k < dtDefaultProfileTabs.Rows.Count; k++)
            {
                if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == type) //Updates
                {
                    defaultTabName = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                    break;
                }
                /*else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == type) //Events
                    events = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == type) //Bulletins
                    bulletins = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == type) //Surveys
                    surveys = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == type) //About Us
                    aboutUs = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();*/
            }
            DataTable dtmobileSettings = GetMobileAppSetting(pUserID);
            DataTable dtCustomModules = objbus.DashboardIcons(pUserID);
            if (dtmobileSettings.Rows.Count > 0)
            {
                string xmlSettings = Convert.ToString(dtmobileSettings.Rows[0]["M_SettingValue"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                if (type == "Updates")
                {
                    if (xmlTools.Element("Tools").Attribute("UpdatesTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("UpdatesTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "Updates")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Manage " + tabName + "</span>";
                            break;
                        }
                    }
                }

                if (type == "Events")
                {
                    if (xmlTools.Element("Tools").Attribute("EventsTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("EventsTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "EventCalendar")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Manage " + tabName + "</span>";
                            break;
                        }
                    }
                }

                if (type == "Surveys")
                {
                    if (xmlTools.Element("Tools").Attribute("SurveysTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("SurveysTabName").Value);
                    else
                        tabName = defaultTabName;

                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "Surveys")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Manage " + tabName + "</span>";
                            break;
                        }
                    }

                }
                if (type == "Bulletins")
                {
                    if (xmlTools.Element("Tools").Attribute("BulletinsTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("BulletinsTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "Bulletins")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Manage " + tabName + "</span>";
                            break;
                        }
                    }
                }
                if (type == "AboutUs")
                {
                    if (xmlTools.Element("Tools").Attribute("AboutUsTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("AboutUsTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "AboutUs")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + Convert.ToString(dtCustomModules.Rows[i]["TabName"]) + "</span>";
                            break;
                        }
                    }
                }
                if (type == "Home")
                {
                    if (xmlTools.Element("Tools").Attribute("HomeTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("HomeTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "Home")
                        {
                            if (dtCustomModules.Rows[i]["TabName"].ToString() != null)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();
                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + tabName + "</span>";
                            break;
                        }
                    }
                }
                if (type == "SocialMedia")
                {
                    if (xmlTools.Element("Tools").Attribute("SocialMediaTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("SocialMediaTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (tabName == string.Empty)
                            tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "SocialMedia")
                        {
                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + tabName + "</span>";
                            break;
                        }
                    }
                }
                if (type == "Notifications")
                {
                    if (xmlTools.Element("Tools").Attribute("NotificationTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("NotificationTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "Notifications")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Send " + tabName + "</span>";
                            break;
                        }
                    }
                }
                if (type == "Gallery")
                {
                    if (xmlTools.Element("Tools").Attribute("MediaTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("MediaTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "Gallery")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Manage " + tabName + "</span>";
                            break;
                        }
                    }
                }
                if (type == "WebLinks")
                {
                    if (xmlTools.Element("Tools").Attribute("WeblinksTabName") != null)
                        tabName = Convert.ToString(xmlTools.Element("Tools").Attribute("WeblinksTabName").Value);
                    else
                        tabName = defaultTabName;
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        if (dtCustomModules.Rows[i]["ButtonType"].ToString() == "WebLinks")
                        {
                            if (tabName == string.Empty)
                                tabName = dtCustomModules.Rows[i]["TabName"].ToString();

                            tabName = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' alt=''><span style='vertical-align:middle'>" + " Manage " + tabName + "</span>";
                            break;
                        }
                    }
                }
            }
            return tabName;
        }
    }
}
