using System;
using System.Linq;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using USPDHUBDAL;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using USPDHUBBLL;
using System.Web;
using Winnovative.WnvHtmlConvert;
using System.Text;
using System.Drawing;
using System.Xml.Linq;
using System.Xml;

namespace USPDHUB.m_service
{
    /// <summary>
    /// Summary description for ClientService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientService : System.Web.Services.WebService
    {
        public CommonBLL objCommonBLL = new CommonBLL();
        public string ErrorMessage = "ERROR";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [WebMethod]
        public DataTable GetUserDetails(string username, string domainName)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetUserDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtobj = USPDHUBDAL.Consumer.GetUserDetails(username, domainName);

                //if (dtobj.Rows.Count == 0)
                //{
                //    var dtAssociate = GetAssociateUserDetails(username, domainName);
                //    if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                //    {
                //        dtobj = GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                //    }
                //}

                return dtobj;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetUserDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable(); ;
            }
        }

        [WebMethod]
        public DataTable GetSuperAdminiDetails1(string username, out string superAdminUserName, string domainName)
        {
            /*
            string s = "SELECT SuperAdmin_ID,User_ID,Firstname,Lastname FROM T_Users WHERE Username='" + username + "' and Active_flag=1";
            SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
            SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable ds = new DataTable("dt");
            da.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                s = "SELECT Username FROM T_Users WHERE User_ID=" + ds.Rows[0]["SuperAdmin_ID"] + " and Active_flag=1";
                sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                sqlCmd = new SqlCommand(s, sqlCon);
                superAdminUserName = sqlCmd.ExecuteScalar().ToString();
                USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            else
            {
                superAdminUserName = "";
            }
            */
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetSuperAdminiDetails1()", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable ds = USPDHUBDAL.Consumer.GetAssociateUserDetails(username, domainName);

                if (ds.Rows.Count > 0)
                {
                    var s = "SELECT Username FROM T_Users WHERE User_ID=" + ds.Rows[0]["SuperAdmin_ID"] + " and Active_flag=1";
                    SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                    SqlCommand sqlCmd = new SqlCommand(s.ToString(), sqlCon);
                    superAdminUserName = sqlCmd.ExecuteScalar().ToString();
                    USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
                }
                else
                {
                    superAdminUserName = "";
                }
                return ds;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetSuperAdminiDetails1()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                superAdminUserName = string.Empty;
                return new DataTable(); ;
            }
        }

        [WebMethod]
        public DataTable GetBusinessProfileByUserID(int userID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetBusinessProfileByUserID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.GetBusinessProfileByUserID(userID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetBusinessProfileByUserID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable(); ;
            }
        }

        [WebMethod]
        public DataTable Getorderidbyuserid(int userid)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "Getorderidbyuserid()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.Getorderidbyuserid(userid);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "Getorderidbyuserid()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable(); ;
            }
        }

        [WebMethod]
        public DataTable GetUserDetailsByID(int userID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetUserDetailsByID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return USPDHUBDAL.Consumer.GetUserDetailsByID(userID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetUserDetailsByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable(); ;
            }
        }
        [WebMethod]
        public string CheckUserActivationCodeForRegistration(int userid)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "CheckUserActivationCodeForRegistration()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.CheckUserActivationCodeForRegistration(userid);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "CheckUserActivationCodeForRegistration()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }
        [WebMethod]
        public int GetProfileIDByUserID(int userID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetProfileIDByUserID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.GetProfileIDByUserID(userID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetProfileIDByUserID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return -1;
            }
        }

        [WebMethod]
        public DataTable GetUserDetailsByUserID(int userID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetUserDetailsByUserID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.GetUserDetailsByUserID(userID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetUserDetailsByUserID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
        }


        [WebMethod]
        public DataTable GetMobileAppAlerts(bool flag, int userID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetMobileAppAlerts()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.GetMobileNewsletterAlerts(flag, userID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetMobileAppAlerts()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
        }

        [WebMethod]
        public DataTable GetMobileTips(bool flag, int userID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetMobileTips()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.GetMobileTips(flag, userID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetMobileTips()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
        }

        [WebMethod]
        public DataTable GetDesktopMobileAlerts(int pUserID, bool pFlag, DateTime pPoolDate)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetDesktopMobileAlerts()", string.Empty, string.Empty, string.Empty, string.Empty);

                SqlCommand sqlCmd = new SqlCommand("usp_DesktopMobileAlerts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@flag", pFlag);
                sqlCmd.Parameters.AddWithValue("@PoolDate", pPoolDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetDesktopMobileAlerts()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        [WebMethod]
        public DataTable GetDesktopMobileAlertsByPoolDate(int pUserID, bool pFlag, DateTime pPoolDate)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetDesktopMobileAlerts()", string.Empty, string.Empty, string.Empty, string.Empty);

                SqlCommand sqlCmd = new SqlCommand("usp_DesktopMobileAlertsByPoolDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@flag", pFlag);
                sqlCmd.Parameters.AddWithValue("@PoolDate", pPoolDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetDesktopMobileAlerts()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }



        [WebMethod]
        public DataTable UpdateStatusForMobileAlerts(int userID, int contactID, bool flag, int id)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "UpdateStatusForMobileAlerts()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.SelectMobileTips(userID, contactID, flag, id);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "UpdateStatusForMobileAlerts()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
        }

        [WebMethod]
        public DataTable GetMobileAppAlertsForDesktop(string pSource, int pUserID, int pRowCount)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetMobileAppAlertsForDesktop()", string.Empty, string.Empty, string.Empty, string.Empty);

                return BusinessDAL.GetMobileAppAlertsForDesktop(pSource, pUserID, pRowCount);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetMobileAppAlertsForDesktop()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return new DataTable();
            }
        }

        [WebMethod]
        public string GetConfigSettingByPID(string pProfileID, string pType, string pConfigName)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetConfigSettingByPID()", string.Empty, string.Empty, string.Empty, string.Empty);

                USPDHUBBLL.MServiceBLL objMServiceBLL = new USPDHUBBLL.MServiceBLL();
                return objMServiceBLL.GetConfigSettings(pProfileID, pType, pConfigName);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetConfigSettingByPID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }
        [WebMethod]
        public string GetConfigSettingsByVertical(string pDomain, string pType, string pConfigName)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetConfigSettingsByVertical()", string.Empty, string.Empty, string.Empty, string.Empty);

                //pDomain means inschoolhubcom&& inschoonin like...
                string returnValue = "";
                var dtConfigs = objCommonBLL.GetVerticalConfigsByType(pDomain, pType);
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
                return returnValue;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetConfigSettingsByVertical()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        [WebMethod]
        public string GetTipsManagerAudioFilePath(string pProfileID, string pVerticalDomain)
        {
            try
            {

                ErrorHandling("LOG ", "ClientService.asmx", "GetTipsManagerAudioFilePath(pProfileID: " + pProfileID + " ,  pVerticalDomain:" + pVerticalDomain + ")", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dt = AgencyDAL.GetTipsManagerDefaultAudioFile(Convert.ToInt32(pProfileID), pVerticalDomain);
                string audioFilePath = "";
                string RootPath = GetConfigSettingByPID(pProfileID, "Paths", "RootPath");

                if (dt.Rows.Count > 0)
                {
                    string USPDVirtualFolderPath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "/Upload/TipsManagerAudio/" + pProfileID + "/" + dt.Rows[0]["AudioFile"].ToString();
                    if (File.Exists(USPDVirtualFolderPath))
                    {
                        audioFilePath = RootPath + "/Upload/TipsManagerAudio/" + pProfileID + "/" + dt.Rows[0]["AudioFile"].ToString() + "?id=" + Guid.NewGuid();
                    }
                    else
                    {
                        audioFilePath = RootPath + "/Upload/TipsManagerAudio/DefaultAudio/" + pVerticalDomain + "/" + dt.Rows[0]["AudioFile"].ToString() + "?id=" + Guid.NewGuid();
                    }
                }

                return audioFilePath;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetTipsManagerAudioFilePath()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public DataTable UploadAudioFiles(byte[] audioBytes, string fileName, string audioFileName, int userID, int profileID, bool chkDefault, string domain)
        {
            AgencyBLL agencyobj = new AgencyBLL();
            DataTable dt = new DataTable("test");
            string strdocPath = "";
            string folderNamePath = "";
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "UploadAudioFiles()", string.Empty, string.Empty, string.Empty, string.Empty);

                #region Delete Audio File Previuos Default File
                if (chkDefault)
                {
                    var dtSelectedAudio = agencyobj.GetAudio_TipsManager(profileID, userID, domain);
                    foreach (DataRow objROw in dtSelectedAudio.Rows)
                    {
                        if (Convert.ToBoolean(objROw["IsDefault"]))
                        {
                            string FolderPath1 = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\TipsManagerAudio\\" + profileID;
                            string mediaFileName = objROw["AudioFile"].ToString();
                            if (File.Exists(FolderPath1 + "\\" + mediaFileName))
                            {
                                File.Delete(FolderPath1 + "\\" + mediaFileName);
                            }
                            break;
                        }
                    }
                }
                #endregion

                folderNamePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\TipsManagerAudio\\" + profileID;
                if (!Directory.Exists(folderNamePath))
                    Directory.CreateDirectory(folderNamePath);
                strdocPath = folderNamePath + "\\" + audioFileName;
                using (FileStream objAudiofilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    objAudiofilestream.Write(audioBytes, 0, audioBytes.Length);
                    objAudiofilestream.Flush();
                    objAudiofilestream.Close();
                    objAudiofilestream.Dispose();
                }
                agencyobj.Insert_UpdateAudio_TipsManager(0, profileID, userID, fileName, audioFileName, chkDefault, 0, "UserAudio");

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "UploadAudioFiles()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetAudioTipsManager(int profileId, int userId, string domainName)
        {
            AgencyBLL agencyobj = new AgencyBLL();
            DataTable dtAlerts = new DataTable();
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetAudioTipsManager()", string.Empty, string.Empty, string.Empty, string.Empty);
                dtAlerts = agencyobj.GetAudio_TipsManager(profileId, userId, domainName);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetAudioTipsManager()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return dtAlerts;
        }

        [WebMethod]
        public void DeleteAudioTipsManager(int audioID)
        {
            AgencyBLL agencyobj = new AgencyBLL();
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "DeleteAudioTipsManager()", string.Empty, string.Empty, string.Empty, string.Empty);
                agencyobj.DeleteAudio_TipsManager(audioID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "DeleteAudioTipsManager()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [WebMethod]
        public void InsertUpdateAudioTipsManager(int audioID, int ProfileID, int UserID, string audioName, string audioFile, bool isDefault, int DefaultAudioID, string AudioType)
        {
            AgencyBLL agencyobj = new AgencyBLL();
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "InsertUpdateAudioTipsManager()", string.Empty, string.Empty, string.Empty, string.Empty);
                agencyobj.Insert_UpdateAudio_TipsManager(audioID, ProfileID, UserID, audioName, audioFile, isDefault, DefaultAudioID, AudioType);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "InsertUpdateAudioTipsManager()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [WebMethod]
        public string PlayAudioTipsManager(string audioType, int ProfileID, string audioFile, string DomainName)
        {
            string audioFilePath = "";
            string RootPath = GetConfigSettingByPID(ProfileID.ToString(), "Paths", "RootPath");
            if (audioType == "UserAudio")
            {
                audioFilePath = RootPath + "/Upload/TipsManagerAudio/" + ProfileID + "/" + audioFile;
            }
            else
            {
                audioFilePath = RootPath + "/Upload/TipsManagerAudio/DefaultAudio/" + DomainName + "/" + audioFile;
            }

            return audioFilePath;
        }

        [WebMethod]
        public string GetCurrentDateTime()
        {
            DataTable msgs = new DataTable("dt");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPSTDateTimeFromUTC", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(msgs);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

            string ServerTime = "";
            ServerTime = msgs.Rows[0]["ServerTime"].ToString();

            ErrorHandling("Log ", "ClientService.asmx", "GetCurrentDateTime()", "Server Current Time: " + ServerTime, "", "", "", "USPDTipsManager");

            return ServerTime;
        }

        [WebMethod]
        public DataTable GetAllCannedMessages(string pPID)
        {
            return USPDHUBDAL.BusinessDAL.GetAllCannedMessages(Convert.ToInt32(pPID));
        }

        #region Error Log

        [WebMethod]
        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace,
            string innerException, string data, string AppNanme = "USPDTipsManager")
        {
            bool isErrorLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsErrorLog"));

            if (isErrorLog == true || errorType != "LOG ")
            {
                string strLogFile = "";
                string errorLogFolder = Server.MapPath("~") + "\\Upload\\ErrorLog\\";

                if (!Directory.Exists(errorLogFolder))
                {
                    Directory.CreateDirectory(errorLogFolder);
                }

                strLogFile = errorLogFolder + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "_" + AppNanme + "_ErrorLog.txt";

                StreamWriter oSW;
                if (File.Exists(strLogFile))
                {
                    oSW = new StreamWriter(strLogFile, true);
                }
                else
                {
                    oSW = File.CreateText(strLogFile);
                }

                oSW.WriteLine("================================" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "================================");
                oSW.WriteLine(" ");
                oSW.WriteLine("Type : " + errorType);
                oSW.WriteLine(" ");
                oSW.WriteLine("Page Name : " + pPageName);
                oSW.WriteLine(" ");
                oSW.WriteLine("Method Name : " + methodName);
                oSW.WriteLine(" ");
                oSW.WriteLine("MESSAGE : " + message);
                oSW.WriteLine(" ");
                oSW.WriteLine("STACKTRACE : " + strackTrace);
                oSW.WriteLine(" ");
                oSW.WriteLine("INNEREXCEPTION : " + innerException);
                oSW.WriteLine(" ");
                oSW.WriteLine("DATA : " + data);
                oSW.WriteLine(" ");
                oSW.Close();
            }
        }



        #endregion


        #region WPF POC Project Related Methods

        [WebMethod(EnableSession = true)]
        public string[] GetModuleTypes(string UserID = "", string DomainName = "")
        {
            string bulletinsTabName = "";
            string UpdateTabName = "";

            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "GetModuleTypes()", string.Empty, string.Empty, string.Empty, string.Empty);

                BusinessBLL objBus = new BusinessBLL();
                USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();


                DataTable dtDefaultProfileTabs = objBus.GetDefaultProfileTabNames(DomainName);
                for (int k = 0; k < dtDefaultProfileTabs.Rows.Count; k++)
                {
                    if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Updates")
                        UpdateTabName = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();

                    else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Bulletins")
                        bulletinsTabName = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                }

                //Getting Mobile App Settings
                DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(Convert.ToInt32(UserID));
                var xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                Session["SettingID"] = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);

                if (xmlTools.Element("Tools").Attribute("UpdatesTabName") != null)
                    UpdateTabName = Convert.ToString(xmlTools.Element("Tools").Attribute("UpdatesTabName").Value);

                if (xmlTools.Element("Tools").Attribute("BulletinsTabName") != null)
                    bulletinsTabName = Convert.ToString(xmlTools.Element("Tools").Attribute("BulletinsTabName").Value);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "GetModuleTypes()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");

            }
            return new string[] { "Bulletins##" + bulletinsTabName, "Updates##" + UpdateTabName };
        }



        [WebMethod]
        public int Insert_DesktopPOC_ModulContent(int pProfileID, string pModuleType, string pDomainVertical, string pTitle, string pPreviewHTML,
            string pEditHTML, int pCreatedUser, int pModifyUser, bool pIsCall, bool pIsContactUs, bool pisPublic, DateTime? pExpiryDate,
            DateTime? pPublishDate, bool IsPublish, bool pIsDesktopPOC, int pPublishID, int pUserID)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "Insert_DesktopPOC_ModulContent()", string.Empty, string.Empty, string.Empty, string.Empty);


                int returnID = 0;
                InBuiltDataBLL objInBuiltDataBLL = new InBuiltDataBLL();
                if (pModuleType == "Bulletins")
                {
                    #region  Bulletins

                    DataTable dtBlankTemp = BulletinDAL.GetBulletinBlankTemplateDetails(pProfileID.ToString());

                    var pTemplateBID = Convert.ToInt32(dtBlankTemp.Rows[0]["Template_BID"]);
                    var Category = Convert.ToString(dtBlankTemp.Rows[0]["BulletinCategoryName"]);


                    returnID = BulletinDAL.Insert_Update_BulletinDetails(0, pTemplateBID, pTitle, pPreviewHTML, pEditHTML, pCreatedUser, pModifyUser,
                        false, pUserID, pProfileID, pIsCall, false, pIsContactUs, pisPublic, pExpiryDate, pPublishDate, Category, IsPublish,
                       pPublishID, "", "", "", pIsDesktopPOC);

                    // Update Long URL to Short URL
                    string outerURL = objCommonBLL.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                    string bulletinURL = outerURL + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(returnID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                    bulletinURL = objCommonBLL.longurlToshorturl(bulletinURL);
                    CommonDAL.UpdateShortenURl(returnID, bulletinURL, "BULLETINS");


                    string folderNamePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Bulletins\\";
                    objInBuiltDataBLL.CreateImage(folderNamePath, pProfileID, pCreatedUser, returnID, pPreviewHTML);

                    #endregion

                }
                else if (pModuleType == "Updates")
                {
                    #region Updates

                    returnID = BusinessUpdatesDAL.InsertBusinessUpdateDetailsNew(0, pProfileID, pTitle, true, pPreviewHTML, pTitle, pisPublic, pisPublic,
                    pCreatedUser, pPublishDate, pEditHTML, pPublishID, "", pExpiryDate, pIsCall, pIsContactUs, pIsDesktopPOC);

                    string outerURL = objCommonBLL.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                    string shortenUrl = outerURL + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(returnID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    shortenUrl = objCommonBLL.longurlToshorturl(shortenUrl);
                    // *** Update shorten url *** //
                    objCommonBLL.UpdateShortenURl(returnID, shortenUrl, "UPDATES");

                    string folderNamePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Updates\\";
                    objInBuiltDataBLL.CreateImage(folderNamePath, pProfileID, pCreatedUser, returnID, pPreviewHTML);

                    #endregion
                }
                return returnID;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "Insert_DesktopPOC_ModulContent()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");
                return -1;
            }


        }

        [WebMethod]
        public DataTable GetPOC_ModuleContentHistory(int pProfileID)
        {
            return BulletinDAL.GetPOC_ModuleContentHistory(pProfileID);

        }

        [WebMethod]
        public int InsertBulletinDetails(int pBulletinID, int pTemplateBID, string pBulletinTitle, string pBulletinHTML, string pBulletinXML,
            int pCreatedUser, int pModifyUser, bool pIsArchive, int pUserID, int pProfileID, bool pIsCall, bool pIsPhotoCapture, bool pIsContactUs,
            bool pIsPrivate, DateTime? pExpiryDate, DateTime? pPublishDate, string Category, bool IsPublic, int? PublishedBy,
            string printerHtml = "", string pCustomXML = "", string pListDescription = "")
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "InsertBulletinDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                if (pCustomXML == null)
                {
                    pCustomXML = "";
                }

                DataTable dtBlankTemp = BulletinDAL.GetBulletinBlankTemplateDetails(pProfileID.ToString());
                pTemplateBID = Convert.ToInt32(dtBlankTemp.Rows[0]["Template_BID"]);
                Category = Convert.ToString(dtBlankTemp.Rows[0]["BulletinCategoryName"]);

                int BID = BulletinDAL.Insert_Update_BulletinDetails(pBulletinID, pTemplateBID, pBulletinTitle, pBulletinHTML, pBulletinXML, pCreatedUser, pModifyUser,
                    pIsArchive, pUserID, pProfileID, pIsCall, pIsPhotoCapture, pIsContactUs, pIsPrivate, pExpiryDate, pPublishDate, Category, IsPublic,
                    PublishedBy, printerHtml, pCustomXML, pListDescription, true);

                #region MyRegion Update Long URL to Short URL
                if (pBulletinID == 0)
                {
                    // Update Long URL to Short URL
                    string outerURL = objCommonBLL.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                    string bulletinURL = outerURL + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(BID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                    bulletinURL = objCommonBLL.longurlToshorturl(bulletinURL);
                    CommonDAL.UpdateShortenURl(BID, bulletinURL, "BULLETINS");
                }
                #endregion

                InBuiltDataBLL objInBuiltDataBLL = new InBuiltDataBLL();
                string folderNamePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Bulletins\\";
                objInBuiltDataBLL.CreateImage(folderNamePath, pProfileID, pCreatedUser, BID, pBulletinHTML);


                return BID;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "InsertBulletinDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");
                return -1;
            }

        }


        [WebMethod]
        public int InsertBusinessUpdateDetailsNew(int updateID, int profileID, string title, bool status, string businessDesc, string updateName,
           bool progressLevel, bool isPublic, int id, DateTime? pPublishDate, string pEditHtml, int? publishedBy, string pListDescription,
           DateTime? pExDate, bool pIsCall, bool pIsContactUs, int pUserID)
        {

            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "InsertBusinessUpdateDetailsNew()", string.Empty, string.Empty, string.Empty, string.Empty);

                updateID = BusinessUpdatesDAL.InsertBusinessUpdateDetailsNew(updateID, profileID, title, status, businessDesc, updateName, progressLevel, isPublic,
                   id, pPublishDate, pEditHtml, publishedBy, pListDescription, pExDate, pIsCall, pIsContactUs, true);

                string outerURL = objCommonBLL.GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string shortenUrl = outerURL + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(updateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
                shortenUrl = objCommonBLL.longurlToshorturl(shortenUrl);
                // *** Update shorten url *** //
                objCommonBLL.UpdateShortenURl(updateID, shortenUrl, "UPDATES");


                // *** Convert to image ***//
                string strhtml = "<html><head></head><body><table width='650px' border='0' cellspacing='0' cellpadding='0'><tr><td style='padding:30px;'>" + businessDesc + "</td></tr><tr></table></body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
                ImgConverter imgConverter = new ImgConverter();
                MemoryStream msval = new MemoryStream(buffer);
                imgConverter.LicenseKey = ConfigurationManager.AppSettings.Get("imgkeyval");
                imgConverter.PageWidth = 650;
                string saveFilePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Updates\\" + profileID.ToString();
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + updateID.ToString() + ".jpg";
                string tempimagepath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Updates\\" + profileID.ToString() + "\\" + profileID.ToString() + pUserID.ToString() + ".jpg";
                if (File.Exists(savelocation))
                {
                    File.Delete(savelocation);
                }
                imgConverter.SaveImageFromHtmlStreamToFile(msval, Encoding.UTF8, System.Drawing.Imaging.ImageFormat.Jpeg, tempimagepath);
                //msval = null;
                buffer = null;


                // *** Creating Thmb image *** //
                string srcfile = tempimagepath;
                string destfile = savelocation;
                int thumbWidth = 350;
                System.Drawing.Image image = System.Drawing.Image.FromFile(srcfile);
                int srcWidth = image.Width;
                int srcHeight = image.Height;
                Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
                int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
                Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
                gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                bmp.Save(destfile);
                bmp.Dispose();
                image.Dispose();
                if (File.Exists(tempimagepath))
                {
                    File.Delete(tempimagepath);
                }

                msval.Flush();
                msval.Close();
                msval.Dispose();

                return updateID;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "InsertBusinessUpdateDetailsNew()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");
                return -1;
            }
        }


        [WebMethod]
        public bool UploadPOCImage(Byte[] imgBytes, string ProfileID, string fileName)
        {
            try
            {
                string strdocPath;
                string tempFileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "_temp.png";
                string folderNamePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Bulletins\\Templates\\" + ProfileID + "\\Template";
                if (!Directory.Exists(folderNamePath))
                {
                    Directory.CreateDirectory(folderNamePath);
                }
                strdocPath = folderNamePath + "\\" + tempFileName;
                using (FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    objfilestream.Write(imgBytes, 0, imgBytes.Length);
                    objfilestream.Flush();
                    objfilestream.Close();
                    objfilestream.Dispose();

                }

                #region Image Resize

                //Resize to 300 * 300
                GC.Collect();
                string imageUrl = strdocPath;
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                //*** uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(imageUrl);***/
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(imgBytes);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.Width = 300;
                actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Png;
                imgDraw.JpegCompressionLevel = 100;

                //We need to create a unique filename for each generated image        
                string myString = string.Empty;
                myString = folderNamePath + "\\" + fileName;

                ErrorHandling("ERROR ", "ClientService.asmx", "UploadPOCImage()", myString, "",
                    "mystring", "mystring", "DesktopPOC");

                //Save the thumbnail in PNG format.  
                imgDraw.Save(myString);

                if (File.Exists(strdocPath))
                {
                    File.Delete(strdocPath);
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "UploadPOCImage()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");
                return false;
            }
        }

        [WebMethod]
        public DataTable GetPermissionsById(int associateID)
        {
            return USPDHUBDAL.AgencyDAL.GetPermissionsById(associateID);
        }

        [WebMethod]
        public DataTable GetAssociateUserDetails(string username, string domainName)
        {
            return USPDHUBDAL.Consumer.GetAssociateUserDetails(username, domainName);
        }


        [WebMethod(EnableSession = true)]
        public string SendAuthorNotifications(string C_Username, int ID, string ModuleName, int UserID, string Username, string DomainName,
            string C_UserID, string RootPath)
        {
            try
            {
                ErrorHandling("LOG ", "ClientService.asmx", "SendAuthorNotifications()", string.Empty, string.Empty, string.Empty, string.Empty);


                HttpContext.Current.Session["C_USER_ID"] = C_UserID;
                HttpContext.Current.Session["RootPath"] = RootPath;

                ErrorHandling("ERROR ", "ClientService.asmx:: EMail Log", "SendAuthorNotifications()", string.Empty,
                    "C_Username:: " + C_Username + "  ID::" + ID + " ModuleName::" + ModuleName + "  UserID::" + UserID + " Username::" + Username + "  DomainName::" + DomainName, string.Empty, string.Empty);


                CommonBLL objCommon = new CommonBLL();
                if (ModuleName.ToLower().Contains("bulletin"))
                {
                    return objCommon.SendAuthorNotifications(C_Username, ID, PageNames.BULLETIN, UserID, Username, PageNames.BULLETIN, DomainName);
                }
                else
                {
                    return objCommon.SendAuthorNotifications(C_Username, ID, PageNames.UPDATE, UserID, Username, PageNames.UPDATE, DomainName);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "SendAuthorNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "DesktopPOC");
                return ErrorMessage;
            }
        }

        [WebMethod]
        public DateTime ConvertToUserTimeZone(int profileID)
        {
            DateTime dtNow = DateTime.UtcNow;
            DataTable dtprofile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtprofile.Rows.Count > 0)
            {
                string timeZone = "Pacific Standard Time";
                if (!string.IsNullOrEmpty(dtprofile.Rows[0]["Display_Name"].ToString()))
                    timeZone = dtprofile.Rows[0]["Display_Name"].ToString();
                dtNow = TimeZoneInfo.ConvertTimeFromUtc(dtNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            }
            return dtNow;
        }

        [WebMethod]
        public DateTime ConvertUserTimeZoneToPST(DateTime dtuserDate)
        {
            string timeZone = "Pacific Standard Time";
            DateTime dtNow = DateTime.UtcNow;
            dtNow = TimeZoneInfo.ConvertTimeFromUtc(dtuserDate, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            return dtNow;
        }

        [WebMethod]
        public string GetDomainNameByCountryVertical(string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDomainNameByCountryVertical", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                string formHeader = Convert.ToString(sqlCmd.ExecuteScalar());
                return formHeader;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        [WebMethod]
        public string returnUserPermission(int AssociateID, int moduleID, string moduleName)
        {
            //USPD-1107 and USPD-1116 Permission related Changes
            string retValue = string.Empty;
            string ModuleName = string.Empty;
            string segName = string.Empty;
            AddOnBLL objAddOn = new AddOnBLL();
            AgencyBLL agencyobj = new AgencyBLL();
            DataTable dtAddOn = new DataTable();
            if (moduleName == "Bulletins") //Bulletins
                ModuleName = "Bulletins";
            else if (moduleName == "Events")    //EventCalendar
                ModuleName = "EventCalendar";
            else if (moduleName == "Surveys")   //Surveys
                ModuleName = "Surveys";
            else if (moduleName == "AppSettings") //SocialMedia
                ModuleName = CommonModules.AppSettings;//"App Settings";
            else if (moduleName == "ManageButtons")
                ModuleName = CommonModules.ManageButtons;//"Manage Buttons";
            else if (moduleName == "PushNotifications")
                ModuleName = CommonModules.PushNotifications;//"Push Notifications";
            else if (moduleName == "Contacts")
                ModuleName = CommonModules.Contacts;//"Contacts";
            else if (moduleName == "ManageMessageReceipt")
                ModuleName = CommonModules.ManageMessageReceipt; //"Manage Message Receipt";
            else if (moduleName == "Downloads")
                ModuleName = CommonModules.Downloads;//"Downloads";
            else if (moduleName == "PrivateInvitation")
                ModuleName = CommonModules.PrivateAddOnInvs; //"Access Private AddOn Invitations";
            else if (moduleName == CommonModules.AccessMarketPlace)
                ModuleName = CommonModules.AccessMarketPlace; //"Access MarketPlace";
            else if (moduleName == CommonModules.ManageAssociates)
                ModuleName = CommonModules.ManageAssociates; //"Access Manage Associates";
            else if (moduleName == CommonModules.AppBackgroundImage)
                ModuleName = CommonModules.AppBackgroundImage; //"App Background Image";
            else if (moduleName == CommonModules.Home)
                ModuleName = CommonModules.Home;//"Home";
            else if (moduleName == CommonModules.AboutUs)
                ModuleName = CommonModules.AboutUs;//"Our Mission";
            else if (moduleName == CommonModules.WebLinks)
                ModuleName = CommonModules.WebLinks;//"Links";
            else if (moduleName == CommonModules.SocialMedia)
                ModuleName = CommonModules.SocialMedia;//"Social";
            else if (moduleID > 0)
            {
                dtAddOn = objAddOn.GetAddOnById(moduleID);
                if (dtAddOn.Rows.Count == 1)
                    ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            }
            else
                ModuleName = moduleName;
            DataTable dtpermissions = agencyobj.GetPermissionsByAssociateId(AssociateID);
            if (dtpermissions.Rows.Count > 0)
            {
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    segName = dtpermissions.Rows[i]["ButtonType"].ToString().Trim();
                    if (moduleName == "AppSettings" || moduleName == "ManageButtons" ||
                        moduleName == "PushNotifications" || moduleName == "Contacts" ||
                        moduleName == "ManageMessageReceipt" || moduleName == "Downloads" || moduleName == "PrivateInvitation" ||
                        moduleName == CommonModules.AccessMarketPlace || moduleName == CommonModules.ManageAssociates ||
                        moduleName == CommonModules.AppBackgroundImage || moduleName == CommonModules.Home || moduleName == CommonModules.AboutUs ||
                        moduleName == CommonModules.WebLinks || moduleName == CommonModules.SocialMedia || moduleName == CommonModules.BillingHistory)
                    {
                        if (segName == ModuleName)
                        {
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                                retValue = "P";
                            else
                                retValue = "A";
                            break;
                        }
                    }
                    if (segName == "CalendarAddOn" || segName == "AddOn" || segName == "PrivateAddOn" || segName == "PrivateCallAddOns")
                    {
                        if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == ModuleName)
                        {
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                                retValue = "A";
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                                retValue = "P";
                            break;
                        }
                    }
                    if (segName == ModuleName)
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            retValue = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            retValue = "P";
                        break;
                    }
                }
            }
            return retValue;
        }

        #endregion



        #region WPF inSchool Alert Notifications Methods
        [WebMethod]
        public DataTable ISA_GetBusinessSchoolsList(string pRegistrationID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDetails = new DataTable("BusinessList");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_GetBusinessSchoolsList", sqlCon);
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDetails);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_GetBusinessSchoolsList()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtDetails;
        }

        [WebMethod]
        public int ISA_Add_Update_User(string pFirstName, string pLastName, string pMobieNo, string pSystemOSName, string pSystemOSVersion, string pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_Notification_Registration", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", pFirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", pLastName);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", pMobieNo);
                sqlCmd.Parameters.AddWithValue("@SystemOSName", pSystemOSName);
                sqlCmd.Parameters.AddWithValue("@SystemOSVersion", pSystemOSVersion);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_Add_Update_User()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return result;
        }

        [WebMethod]
        public string ISA_Generate_OTP(string pPhoneNumber, string pProfileID)
        {
            string OTP = "";
            string result = "success";
            string CountryPhoneCode = ConfigurationManager.AppSettings.Get("CountryPhoneCode").ToString();

            #region Get Country Code

            DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(int.Parse(pProfileID));
            if (dtProfileDetails.Rows.Count > 0)
                CountryPhoneCode = Convert.ToString(dtProfileDetails.Rows[0]["Country_Code"]);

            #endregion
            try
            {
                Random generator = new Random();
                OTP = generator.Next(0, 10000).ToString("D4");
                string textMessage = "";
                textMessage = "Your one time password is " + OTP + ".";
                pPhoneNumber = pPhoneNumber.Replace(" ", "");
                result = objCommonBLL.SendOTPMessage(CountryPhoneCode, pPhoneNumber, textMessage, int.Parse(pProfileID), "Send OTP DeskTopInschoolAlert");
                if (result.ToLower().Equals("error"))
                    return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "ISA_Generate_OTP()", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                result = ErrorMessage;
            }
            return OTP;
        }

        [WebMethod]
        public DataTable ISA_GetPushNotifications(string pProfielID, string pPushNoteCount, string pCallNoteCount, string pRegistrationID, out string NoteReadColor, out string NoteUnReadColor, string pIsFirstSync, string pLastSyncTime, out string pLatestSyncTime)
        {
            pLatestSyncTime = DateTime.Now.ToString();
            NoteReadColor = ConfigurationManager.AppSettings.Get("NoteReadColor").ToString();
            NoteUnReadColor = ConfigurationManager.AppSettings.Get("NoteUnReadColor").ToString();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDetails = new DataTable("NotificationsList");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_GetPushNotifications", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", int.Parse(pProfielID));
                sqlCmd.Parameters.AddWithValue("@PushNoteCount", int.Parse(pPushNoteCount));
                sqlCmd.Parameters.AddWithValue("@CallNoteCount", int.Parse(pCallNoteCount));
                sqlCmd.Parameters.AddWithValue("@RegistrationID", int.Parse(pRegistrationID));
                sqlCmd.Parameters.AddWithValue("@LastSyncDate", pLastSyncTime);
                sqlCmd.Parameters.AddWithValue("@isFirstSync", int.Parse(pIsFirstSync));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDetails);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_GetPushNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtDetails;
        }

        [WebMethod]
        public DataTable ISA_GetProfileDetailsOnRegID(string pRegistrationID, string pIsAddAll = "0")
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDetails = new DataTable("ProfilesList");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_GetProfileDetailsOnRegID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@RegistrationID", int.Parse(pRegistrationID));
                sqlCmd.Parameters.AddWithValue("@IsAddAll", pIsAddAll);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDetails);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_GetProfileDetailsOnRegID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtDetails;
        }

        [WebMethod]
        public DataTable ISA_AddProfiles(string pRegistrationID, string pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDetails = new DataTable("ProfilesList");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_AddProfiles", sqlCon);
                sqlCmd.Parameters.AddWithValue("@RegistrationID", int.Parse(pRegistrationID));
                sqlCmd.Parameters.AddWithValue("@ProfileID", int.Parse(pProfileID));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDetails);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_AddProfiles()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtDetails;
        }

        [WebMethod]
        public DataTable ISA_UploadAudioFiles(byte[] pAudioBytes, string pFileName, string pAudioFileName, int pRegistrationID, bool pChkDefault, string pAudioID = "0")
        {
            AgencyBLL agencyobj = new AgencyBLL();
            DataTable dt = new DataTable("AudioFiles");
            string strdocPath = "";
            string folderNamePath = "";
            try
            {
                //  ErrorHandling("LOG ", "ClientService.asmx", "UploadAudioFiles()", string.Empty, string.Empty, string.Empty, string.Empty);
                SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
                //#region Delete Audio File Previuos Default File
                //if (pChkDefault)
                //{
                //    // var dtSelectedAudio = agencyobj.GetAudio_TipsManager(profileID, userID, domain);

                //    DataTable dtAudio = new DataTable("dtAudio");
                //    dtAudio = ISA_GetAudioDetails(pRegistrationID.ToString());

                //    foreach (DataRow objROw in dtAudio.Rows)
                //    {
                //        if (Convert.ToBoolean(objROw["IsDefault"]))
                //        {
                //            string FolderPath1 = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\ISA_AudioFiles\\" + pRegistrationID;
                //            string mediaFileName = objROw["AudioFile"].ToString();
                //            if (File.Exists(FolderPath1 + "\\" + mediaFileName))
                //            {
                //                File.Delete(FolderPath1 + "\\" + mediaFileName);
                //            }
                //            break;
                //        }
                //    }
                //}
                //#endregion

                folderNamePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\ISA_AudioFiles\\" + pRegistrationID;
                if (!Directory.Exists(folderNamePath))
                    Directory.CreateDirectory(folderNamePath);
                strdocPath = folderNamePath + "\\" + pAudioFileName;
                using (FileStream objAudiofilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    objAudiofilestream.Write(pAudioBytes, 0, pAudioBytes.Length);
                    objAudiofilestream.Flush();
                    objAudiofilestream.Close();
                    objAudiofilestream.Dispose();
                }
                //agencyobj.Insert_UpdateAudio_TipsManager(0, pProfileID, userID, fileName, audioFileName, chkDefault, 0, "UserAudio");


                try
                {
                    SqlCommand sqlCmd = new SqlCommand("Usp_ISA_InsertUpdateAudio_Details", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@AudioID", int.Parse(pAudioID));
                    sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                    sqlCmd.Parameters.AddWithValue("@AudioName", pFileName);
                    sqlCmd.Parameters.AddWithValue("@AudioFile", pAudioFileName);
                    sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                    sqlCmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                    sqlCmd.Parameters.AddWithValue("@IsDefault", pChkDefault);
                    int result = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    dt = ISA_GetAudioDetails(pRegistrationID.ToString());
                }
                catch (Exception ex)
                {
                    ErrorHandling("ERROR ", "ClientService.asmx", "ISA_UploadAudioFiles()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
                finally
                {
                    ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
                }

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "UploadAudioFiles()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return dt;
        }


        [WebMethod]
        public int ISA_UpdateAudioFiles(int pRegistrationID, string pAudioID)
        {
            int result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_InsertUpdateAudio_Details", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AudioID", int.Parse(pAudioID));
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                sqlCmd.Parameters.AddWithValue("@AudioName", "");
                sqlCmd.Parameters.AddWithValue("@AudioFile", "");
                sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                sqlCmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                sqlCmd.Parameters.AddWithValue("@IsDefault", true);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_UpdateAudioFiles()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return result;
        }

        [WebMethod]
        public DataTable ISA_GetAudioDetails(string pRegistrationID)
        {
            DataTable dtAudio = new DataTable("dtAudio");
            dtAudio = GetAudioDetails(pRegistrationID);
            return dtAudio;
        }

        public DataTable GetAudioDetails(string pRegistrationID, string pAudioID = "0")
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAudio = new DataTable("dtAudio");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_GetAudio_Details", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                sqlCmd.Parameters.AddWithValue("@AudioID", pAudioID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtAudio);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtAudio;
        }


        [WebMethod]
        public int ISA_DeleteProfilesOnRegID(string pRegistrationID, string pProfieID)
        {
            int result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_DeleteProfiles", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", int.Parse(pRegistrationID));
                sqlCmd.Parameters.AddWithValue("@ProfileID", int.Parse(pProfieID));
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_DeleteProfilesOnRegID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return result;
        }

        [WebMethod]
        public int ISA_UpdateNotifications_OnOff(string pRegistrationID, string pProfileID, string isNotificationsOn)
        {
            int result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_UpdateNotificationsOnOff", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", int.Parse(pRegistrationID));
                sqlCmd.Parameters.AddWithValue("@ProfileID", int.Parse(pProfileID));
                sqlCmd.Parameters.AddWithValue("@isNoteficationsOn", isNotificationsOn);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_UpdateNotifications_OnOff()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return result;
        }

        [WebMethod]
        public DataTable ISA_SyncNoticicationsData(string pRegistrationID, string pLastSynTime, out string strRecentDateTime)
        {
            strRecentDateTime = DateTime.Now.ToString();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDetails = new DataTable("dtNotifications");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_SyncNotifications", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                sqlCmd.Parameters.AddWithValue("@LastSyncDate", pLastSynTime);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtDetails);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtDetails;

        }
        [WebMethod]
        public int ISA_DeleteAudioFileonRegID(string pRegistrationID, string pAudioID)
        {
            int result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_DeleteAudioFile", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                sqlCmd.Parameters.AddWithValue("@AudioID", pAudioID);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_DeleteAudioFileonRegID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return result;
        }


        [WebMethod]
        public DataTable ISA_GetDefaultAudio(string pRegistrationID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAudio = new DataTable("dtAudio");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_GetDefaultAudio", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtAudio);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return dtAudio;
        }

        [WebMethod]
        public List<string> ISA_GetSyncTimeIntervals(out string pDefautSynTime)
        {
            pDefautSynTime = ConfigurationManager.AppSettings["DefaultSyncTime"].ToString();   // Default sync time interval
            List<string> items = new List<string>();
            for (int i = 1; i <= 6; i++)
            {
                items.Add((i * 5).ToString());
            }
            return items;
        }

        [WebMethod]
        public string ISA_GetEmergencyNotificationDetails_ByCustomID(string pPID, string pCustomID, string pPushNotifyID)
        {
            try
            {
                string pGPSDetails = "";
                string pBody = "";
                DataTable dtCallOnsDetails = GetPrivateCallOnsDetailsByCustomID(Convert.ToInt32(pCustomID));
                double latitude = 0;
                double longtude = 0;
                string dailNumber = "";
                DateTime callingtime = DateTime.Now;
                string PushNotification_Message = "";
                string PushNotification_Subect = "";
                string AppDisplayname = "";
                string ItemTitle = "";

                if (dtCallOnsDetails.Rows.Count > 0)
                {
                    PushNotification_Subect = Convert.ToString(dtCallOnsDetails.Rows[0]["PushNotification_Subject"]);
                    PushNotification_Message = Convert.ToString(dtCallOnsDetails.Rows[0]["PushNotification_Description"]);
                    dailNumber = Convert.ToString(dtCallOnsDetails.Rows[0]["MobileNumber"]);
                    ItemTitle = Convert.ToString(dtCallOnsDetails.Rows[0]["Title"]);
                }


                string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(pPID));
                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pPID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);

                string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());
                string strfilepath = ConfigurationManager.AppSettings["USPDVirtualFolderPath"].ToString() + "\\EmailContent" + domain + "\\";

                StreamReader re = File.OpenText(strfilepath + "PrivateCallAddOns_PushMessage.txt");
                string content = string.Empty;
                while ((content = re.ReadLine()) != null)
                {
                    pBody = pBody + content + "<BR>";
                }
                re.Close();

                DataTable dtCallIngUserDetails = GetPrivateCallOns_CallingUserDetails(Convert.ToInt32(pPID), Convert.ToInt32(pCustomID), Convert.ToInt32(pPushNotifyID));

                pBody = pBody.Replace("#DailNumber#", dailNumber);
                pBody = pBody.Replace("#Subject#", PushNotification_Subect);
                pBody = pBody.Replace("#Message#", PushNotification_Message);

                if (dtCallIngUserDetails.Rows.Count > 0)
                {
                    pBody = pBody.Replace("#Name#", Convert.ToString(dtCallIngUserDetails.Rows[0]["Name"]));
                    pBody = pBody.Replace("#Phone#", Convert.ToString(dtCallIngUserDetails.Rows[0]["MobileNumber"]));
                    pBody = pBody.Replace("#EmailID#", Convert.ToString(dtCallIngUserDetails.Rows[0]["EmailID"]));

                    pGPSDetails = Convert.ToString(dtCallIngUserDetails.Rows[0]["GPS_Details"]);
                    if (pGPSDetails.Contains(","))
                    {
                        var values = pGPSDetails.Split(',');
                        latitude = Convert.ToDouble(values[0]);
                        longtude = Convert.ToDouble(values[1]);
                    }
                    callingtime = Convert.ToDateTime(dtCallIngUserDetails.Rows[0]["CallingTime"]);
                    AppDisplayname = Convert.ToString(dtCallIngUserDetails.Rows[0]["ButtonTitle"]);
                    pBody = pBody.Replace("#TabName#", Convert.ToString(dtCallIngUserDetails.Rows[0]["TabName"]));


                }
                else
                {
                    pBody = pBody.Replace("#ButtonTitle#", "").Replace("#Name#", "").Replace("#Phone#", "").Replace("#EmailID#", "").Replace("#TabName#", "").Replace("#ItemTitle#", "");
                }

                #region Get Current Address by Lati & Long
                string callingAddress = "";
                try
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longtude + "&sensor=false");
                    XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                    if (element.InnerText == "ZERO_RESULTS")
                    {
                        callingAddress = "";
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
                                if (callingAddress == "")
                                    callingAddress = textdata[i].Trim().ToString();
                                else if ((textdata.Length - 2) == i)
                                    callingAddress = callingAddress + "," + " " + textdata[i].Trim().ToString();
                                else
                                    callingAddress = callingAddress + "," + "<br/>" + textdata[i].Trim().ToString();
                            }
                            callingAddress = callingAddress + ".";
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                #endregion


                pBody = pBody.Replace("#Time#", callingtime.ToString());
                pBody = pBody.Replace("#Location#", callingAddress);

                pBody = pBody.Replace("#AppName#", AppDisplayname);
                pBody = pBody.Replace("#ItemTitle#", ItemTitle);

                pBody = "<div style='font-family: segoe ui;'>" + pBody + "<div>";

                return pBody;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "ISA_GetEmergencyNotificationDetails_ByCustomID()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;

            }
        }

        public DataTable GetPrivateCallOnsDetailsByCustomID(int pCustomID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetCallOnsDetailsByCustomID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public DataTable GetPrivateCallOns_CallingUserDetails(int pPID, int pPushTypeID, int pPushNotificationID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_PrivateAddOns_CallingUserDetails", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@PrivateCallOns_CustomID", pPushTypeID);
                sqlCmd.Parameters.AddWithValue("@PushNoticationID", pPushNotificationID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        [WebMethod]
        public int ISA_UpdateNotificationStatus(string pRegistrationID, string pPushNotifyID)
        {
            int result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ISA_UpdateNotificationStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegistrationID", pRegistrationID);
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pPushNotifyID);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ClientService.asmx", "ISA_UpdateNotificationStatus()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return result;
        }


        #endregion

    }
}
