using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Web.Services;
using System.Data;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class WebWidget : BaseWeb
    {
        public int C_UserID = 0;
        public int UserID = 0;
        public int ProfileID = 0;
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL busobj = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string moduleOptions = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (!IsPostBack)
                {
                    rssmikle_id.Value = EncryptDecrypt.DESEncrypt(ProfileID.ToString());
                    DataTable dtConfigs = objCommon.GetVerticalConfigsByType(Session["VerticalDomain"].ToString(), "FeedUrl");
                    if (dtConfigs.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigs.Rows)
                        {
                            if (row[0].ToString() == "UrlPath")
                            {
                                rssmikle_path.Value = row[1].ToString();
                                break;
                            }
                        }
                    }
                    DataTable dtCustomModules = new DataTable();
                    if (Convert.ToBoolean(Session["IsLiteVersion"]))
                        dtCustomModules = busobj.DashboardIcons(UserID, true);
                    else
                        dtCustomModules = busobj.DashboardIcons(UserID);
                    for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                    {
                        string moduleType = Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]);
                        string requiredName = Convert.ToString(dtCustomModules.Rows[i]["TabName"]);
                        string moduleID = Convert.ToString(dtCustomModules.Rows[i]["UserModuleID"]);
                        if (moduleType == "Bulletins")
                            moduleOptions = moduleOptions + "<option value='" + requiredName + "|SP|" + moduleType + "," + moduleID + "'>" + requiredName + "</option>";
                        if (moduleType == "Updates")
                            moduleOptions = moduleOptions + "<option value='" + requiredName + "|SP|" + moduleType + "," + moduleID + "'>" + requiredName + "</option>";
                        if (moduleType == "EventCalendar")
                            moduleOptions = moduleOptions + "<option value='" + requiredName + "|SP|" + moduleType + "," + moduleID + "'>" + requiredName + "</option>";
                        if (moduleType == "AddOn")
                            moduleOptions = moduleOptions + "<option value='" + requiredName + "|SP|" + moduleType + "," + moduleID + "'>" + requiredName + "</option>";
                        if (moduleType == WebConstants.Tab_CalendarAddOns)
                            moduleOptions = moduleOptions + "<option value='" + requiredName + "|SP|" + moduleType + "," + moduleID + "'>" + requiredName + "</option>";
                    }
                    ltrlOptions.Text = moduleOptions;
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WebWidget.aspx.cs", "Page_Load", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [WebMethod]
        public static string EmailHTMLCode(string toEmail, string feedCode, string subject, string description, string profileID)
        {
            string domainName = Convert.ToString(System.Web.HttpContext.Current.Session["VerticalDomain"]);
            string rootPath = "";
            CommonBLL obCommon = new CommonBLL();
            DataTable dtConfigs = obCommon.GetVerticalConfigsByType(domainName, "Paths");
            if (dtConfigs.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigs.Rows)
                {
                    if (row[0].ToString() == "RootPath")
                        rootPath = row[1].ToString();
                }
            }
            string fromEmailSupport = "";
            DataTable dtConfigsemails = obCommon.GetVerticalConfigsByType(domainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        fromEmailSupport = row[1].ToString();
                }
            }
            string profile_ID = EncryptDecrypt.DESDecrypt(profileID);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Widget\\" + profile_ID;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            try
            {
                string[] filePaths = Directory.GetFiles(filePath + "\\");
                if (filePaths.Length > 0)
                {
                    foreach (string file in filePaths)
                        File.Delete(file);
                }
            }
            catch (Exception /*ex*/)
            {

            }
            filePath = filePath + "\\" + profile_ID + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
                using (TextWriter tw = new StreamWriter(filePath))
                {
                    tw.WriteLine(feedCode);
                    tw.Flush();
                    tw.Dispose();
                    tw.Close();
                }

            }
            else if (File.Exists(filePath))
            {
                using (TextWriter tw = new StreamWriter(filePath))
                {
                    tw.Flush();
                    tw.Dispose();
                    tw.Close();
                    tw.WriteLine(feedCode);
                    tw.Flush();
                    tw.Dispose();
                    tw.Close();
                }
            }
            UtilitiesBLL objUtl = new UtilitiesBLL();
            string msgBody = description + "<br/><br/><b>Note: Please open the attached text file to view the code.</b>";

            bool _result = objUtl.SendWowzzyEmailWithAttachments(fromEmailSupport, toEmail, subject, msgBody, string.Empty, filePath, domainName);
            return _result == false ? "FAILED" : "SUCCESS";
        }
    }
}