using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using LeadsDAL;
using System.Configuration;
using System.IO;


namespace LeadsBLL
{
    public class CommonBLL
    {
        public string CreateDomainUrl(string url)
        {
            string host = new System.Uri(url).Host.ToLower();
            int index = host.LastIndexOf('.'), last = 3;
            while (index > 0 && index >= last - 3)
            {
                last = index;
                index = host.LastIndexOf('.', last - 1);
            }
            string domain = host.Substring(index + 1);
            string[] domainarray = domain.Split('.');
            string verticalDomain = domain.Replace(".", "");
            if (verticalDomain != "")
            {
                HttpContext.Current.Session["VerticalDomain"] = verticalDomain;
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(verticalDomain, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            HttpContext.Current.Session["RootPath"] = row[1].ToString();
                    }
                }
            }
            return verticalDomain;
        }
        public DataTable GetVerticalConfigsByType(string verticalDomain, string type)
        {
            return CommonDAL.GetVerticalConfigsByType(verticalDomain, type);
        }
        public int SaveContactInquiry(DataTable dtResellerInfo, LeadsModels.Inquiry objInquiry, string DomainName)
        {
            int inquiryId = InquiryDAL.SaveResellerInquiry(objInquiry);
            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
            StreamReader re = File.OpenText(strfilepath + "ContactInfo.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR>";
            }
            re.Close();
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Close();
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#msgBody#", content).Replace("#Name#", objInquiry.Name).Replace("#PhoneNumber#", objInquiry.PhoneNumer);
            msgbody = msgbody.Replace("#EmailAddress#", objInquiry.EmailAddress).Replace("#City#", objInquiry.City).Replace("#State#", objInquiry.State);
            msgbody = msgbody.Replace("#BestTime#", objInquiry.BestDayTime != null ? objInquiry.BestDayTime : "").Replace("#BusinessName#", objInquiry.BusinessName);
            msgbody = msgbody.Replace("#ReferalDate#", DateTime.Now.ToString()).Replace("#ChannelPartner#", objInquiry.ReferralURL);
            string FromEmailInfo = "";
            DataTable dtConfigsemails = GetVerticalConfigsByType(DomainName, "EmailAccounts");
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
            UtilitiesBLL objUtilitiesBLL = new UtilitiesBLL();
            string toEmail = Convert.ToString(ConfigurationManager.AppSettings["ToEmails"]);
            if (dtResellerInfo.Rows.Count > 0)
            {
                toEmail = Convert.ToString(dtResellerInfo.Rows[0]["SelfEmail"]);
            }
            objUtilitiesBLL.SendOutEmail(FromEmailInfo, toEmail, "Affiliate Referral", msgbody, Convert.ToString(dtResellerInfo.Rows[0]["EmailAdress"]), "", DomainName);
            return inquiryId;
        }
        public int SaveResellerInquiry(DataTable dtResellerInfo, LeadsModels.Inquiry objInquiry, string DomainName)
        {
            int inquiryId = InquiryDAL.SaveResellerInquiry(objInquiry);
            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
            StreamReader re = File.OpenText(strfilepath + "ResellerReferral.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR>";
            }
            re.Close();
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Close();
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#msgBody#", content).Replace("#Name#", objInquiry.Name).Replace("#PhoneNumber#", objInquiry.PhoneNumer);
            msgbody = msgbody.Replace("#EmailAddress#", objInquiry.EmailAddress).Replace("#City#", objInquiry.City).Replace("#State#", objInquiry.State);
            msgbody = msgbody.Replace("#BestTime#", objInquiry.BestDayTime != null ? objInquiry.BestDayTime : "").Replace("#BusinessName#", objInquiry.BusinessName);
            msgbody = msgbody.Replace("#ReferalDate#", DateTime.Now.ToString()).Replace("#ChannelPartner#", Convert.ToString(dtResellerInfo.Rows[0]["Name"]));
            msgbody = msgbody.Replace("#ChannelCode#", Convert.ToString(dtResellerInfo.Rows[0]["SalesCode"]));
            string FromEmailInfo = "";
            DataTable dtConfigsemails = GetVerticalConfigsByType(DomainName, "EmailAccounts");
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
            UtilitiesBLL objUtilitiesBLL = new UtilitiesBLL();
            objUtilitiesBLL.SendOutEmail(FromEmailInfo, Convert.ToString(dtResellerInfo.Rows[0]["SelfEmail"]), "Affiliate Referral", msgbody, Convert.ToString(dtResellerInfo.Rows[0]["EmailAdress"]), "", DomainName);
            return inquiryId;
        }
        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            bool isErrorLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsErrorLog"));

            if (isErrorLog == true || errorType != "LOG")
            {
                string strLogFile = "";
                string errorLogFolder = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ErrorLog\\";

                if (!Directory.Exists(errorLogFolder))
                {
                    Directory.CreateDirectory(errorLogFolder);
                }

                strLogFile = errorLogFolder + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_ErrorLog.txt";

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
    }
}
