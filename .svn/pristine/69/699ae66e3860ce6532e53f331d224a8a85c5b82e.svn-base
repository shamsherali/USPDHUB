using System;
using System.Data;
using USPDHUBDAL;
using System.Configuration;
using System.Text.RegularExpressions;

namespace USPDHUBBLL
{
    public class UtilitiesBLL
    {
        public UtilitiesBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Role Types
        /// </summary>
        public enum RoleTypes
        {
            Consumer = 1, Business, Admin, AdminStaff, Advertiser, Developer
        }
        /// <summary>
        /// Statuses
        /// </summary>
        public enum Statuses
        {
            Active, InActive, Suspend, Hold
        }
        /// <summary>
        /// Send Wowzzy Email
        /// </summary>
        /// <param name="fromEmail">fromEmail</param>
        /// <param name="toEmail">toEmail</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="cCemail">cCemail</param>
        /// <param name="fromDisplayName">fromDisplayName</param>
        /// <param name="domainName">domainName</param>
        /// <returns>String</returns>
        public string SendWowzzyEmail(string fromEmail, string toEmail, string subject, string message, string cCemail, string fromDisplayName, string domainName)
        {
            try
            {
                InBuiltDataBLL objError = new InBuiltDataBLL();
                // *** Get SMTP server credentials *** //
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(domainName, "SMTPServer");
                string host = ConfigurationManager.AppSettings.Get("SmtpServerName");
                string hostcr = EncryptDecrypt.DESDecrypt(ConfigurationManager.AppSettings.Get("SmtpServer"));
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SmtpServerName")
                            host = row[1].ToString();
                        else if (row[0].ToString() == "SmtpServerCr")
                            hostcr = EncryptDecrypt.DESDecrypt(row[1].ToString());
                    }
                }
                System.Net.Mail.SmtpClient oSmtlClient = new System.Net.Mail.SmtpClient();
                oSmtlClient.Host = host;

                /*** For Sendgrid SMTP Server Port  July 21 2016 Azure Deployement ***/
                string sendgridSMTPServer_Username = Convert.ToString(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Username"));
                oSmtlClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Port"));


                oSmtlClient.Credentials = new System.Net.NetworkCredential(sendgridSMTPServer_Username, hostcr);
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(fromEmail, fromDisplayName);

                string[] strto = toEmail.Split(',');
                for (int i = 0; i < strto.Length; i++)
                {
                    //string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    //                                     @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    //                                     @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    //Regex re = new Regex(strRegex);
                    //if (re.IsMatch(strto[i].Trim()))
                    //{
                        mailMessage.To.Add(new System.Net.Mail.MailAddress(strto[i].Trim()));
                    //}
                }
                if (cCemail != "")
                {
                    string[] ccemails = cCemail.Split(',');
                    for (int i = 0; i < ccemails.Length; i++)
                    {
                        mailMessage.CC.Add(new System.Net.Mail.MailAddress(ccemails[i].Trim()));
                    }
                }
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
                mailMessage.Subject = subject;
                oSmtlClient.Send(mailMessage);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objError = new InBuiltDataBLL();
                objError.ErrorHandling("ERROR", "UtilitiesBLL.cs", "SendWowzzyEmail", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ex.Message.ToString();
            }
        }
        /// <summary>
        /// Get All Cities By State
        /// </summary>
        /// <param name="statename">statename</param>
        /// <param name="countyname">countyname</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllCitiesByState(string statename, string countyname)
        {
            return USPDHUBDAL.Utilities.GetAllCitiesByState(statename, countyname);
        }
        /// <summary>
        /// Get All States By Country
        /// </summary>
        /// <param name="countyname">countyname</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllStatesByCountry(string countyname)
        {
            return USPDHUBDAL.Utilities.GetAllStatesByCountry(countyname);
        }
        /// <summary>
        /// Get All Short States By Country
        /// </summary>
        /// <param name="countyname"> countyname</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllShortStatesByCountry(string countyname)
        {
            return USPDHUBDAL.Utilities.GetAllShortStatesByCountry(countyname);
        }
        /// <summary>
        /// Get All Zip codes By Cities
        /// </summary>
        /// <param name="cityname">cityname</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllZipcodesByCities(string cityname)
        {
            return USPDHUBDAL.Utilities.GetAllZipcodesByCities(cityname);
        }
        /// <summary>
        /// Get Config Details by Name
        /// </summary>
        /// <param name="configName">configName</param>
        /// <returns>DataTable</returns>
        public DataTable GetConfigDetailsbyName(string configName)
        {
            return USPDHUBDAL.Utilities.GetConfigDetailsbyName(configName);
        }
        /// <summary>
        /// Add Refer Friend Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="rFirstname">rFirstname</param>
        /// <param name="rlastname">rlastname</param>
        /// <param name="ffirstname">ffirstname</param>
        /// <param name="fLastname">fLastname</param>
        /// <param name="femail">femail</param>
        /// <param name="message">message</param>
        /// <param name="conFlag">conFlag</param>
        /// <param name="tempprofileid">tempprofileid</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int AddReferAFriendDetails(int userID, string rFirstname, string rlastname, string ffirstname, string fLastname, string femail, string message, bool conFlag, int tempprofileid, int id)
        {
            return USPDHUBDAL.Utilities.AddReferAFriendDetails(userID, rFirstname, rlastname, ffirstname, fLastname, femail, message, conFlag, tempprofileid, id);
        }
        /// <summary>
        /// State Name
        /// </summary>
        /// <param name="stateval">stateval</param>
        /// <returns>String</returns>
        public string StateName(string stateval)
        {
            string returnval = string.Empty;
            DataTable dtstates = USPDHUBDAL.Search.GetStateName();

            if (stateval.Length == 2)
            {
                string strclause = "state_code='" + stateval.ToUpper() + "'";
                DataRow[] results = dtstates.Select(strclause);
                if (results.Length > 0)
                    returnval = Convert.ToString(results[0]["State_Name"]);
            }
            else
            {
                returnval = stateval;
            }

            return returnval;
        }
        /// <summary>
        /// Check If Numberic
        /// </summary>
        /// <param name="myNumber">myNumber</param>
        /// <returns>Boolean</returns>
        public bool CheckIfNumberic(string myNumber)
        {
            bool isNum = true;
            for (int index = 0; index < myNumber.Length; index++)
            {
                if (!Char.IsNumber(myNumber[index]))
                {
                    isNum = false;
                    break;
                }
            }
            return isNum;
        }
        /// <summary>
        /// Validate Zip code
        /// </summary>
        /// <param name="zipCode">zipCode</param>
        /// <returns>DataTable</returns>
        public DataTable VaildateUserZipCode(string zipCode)
        {
            return USPDHUBDAL.Utilities.VaildateUserZipCode(zipCode);
        }
        /// <summary>
        /// Get latitude and longitude by city
        /// </summary>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <returns>DataTable</returns>
        public DataTable Getlatitudeandlongitudebycity(string city, string state)
        {
            return USPDHUBDAL.Utilities.Getlatitudeandlongitudebycity(city, state);
        }
        /// <summary>
        /// Update Opt out status by UserId
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="optoutFlag">optoutFlag</param>
        public void UpdateOptoutstatusbyUserId(int userID, bool optoutFlag)
        {
            USPDHUBDAL.Utilities.UpdateOptoutstatusbyUserId(userID, optoutFlag);
        }



        /// <summary>
        /// Start Unsubscribe General Email
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="optOutFlag">optOutFlag</param>
        public void UnsubscribeGeneralMail(string emailID, string optOutFlag)
        {
            USPDHUBDAL.Utilities.UnsubscribeGeneralMail(emailID, optOutFlag);
        }



        /// <summary>
        ///Get Unsubscribe user status
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUnsubscribeuserstatus(string emailID)
        {
            return USPDHUBDAL.Utilities.GetUnsubscribeuserstatus(emailID);
        }

        /// <summary>
        /// start Duplicate Email-ID validation
        /// </summary>
        /// <param name="dtUserdetails">dtUserdetails</param>
        /// <returns>DataTable</returns>
        protected DataTable RemoveDuplicateEmailIDs(DataTable dtUserdetails)
        {
            DataTable dtuseremails = new DataTable();
            dtuseremails.Columns.Add("contactid", typeof(Int32));
            dtuseremails.Columns.Add("firstName", typeof(string));
            dtuseremails.Columns.Add("email", typeof(string));
            dtuseremails.Columns.Add("group", typeof(string));

            for (int i = 0; i < dtUserdetails.Rows.Count; i++)
            {
                DataRow dtrow = dtuseremails.NewRow();
                int count = 0;
                if (dtuseremails.Rows.Count > 0)
                {
                    for (int j = 0; j < dtuseremails.Rows.Count; j++)
                    {
                        if (dtuseremails.Rows[j]["email"].ToString() == dtUserdetails.Rows[i]["email"].ToString())
                        {
                            count = count + 1;
                        }

                    }
                    if (count == 0)
                    {
                        dtrow["contactid"] = dtUserdetails.Rows[i]["contactid"].ToString();
                        dtrow["firstname"] = dtUserdetails.Rows[i]["firstname"].ToString();
                        dtrow["email"] = dtUserdetails.Rows[i]["email"].ToString();
                        dtrow["group"] = dtUserdetails.Rows[i]["group"].ToString();
                        dtuseremails.Rows.Add(dtrow);
                        dtuseremails.AcceptChanges();
                    }
                }
                else
                {
                    dtrow["contactid"] = dtUserdetails.Rows[i]["contactid"].ToString();
                    dtrow["firstname"] = dtUserdetails.Rows[i]["firstname"].ToString();
                    dtrow["email"] = dtUserdetails.Rows[i]["email"].ToString();
                    dtrow["group"] = dtUserdetails.Rows[i]["group"].ToString();
                    dtuseremails.Rows.Add(dtrow);
                    dtuseremails.AcceptChanges();
                }
            }

            return dtuseremails;

        }

        /// <summary>
        /// Format Phone number
        /// </summary>
        /// <param name="phonenumber">phonenumber</param>
        /// <returns>String</returns>
        public string FormatPhonenumber(string phonenumber)
        {
            //Description: Formate given 10 digit phone number as 000-000-0000 unique format.
            string formatedPhonenumber = string.Empty;
            if (phonenumber.Length == 10)
            {
                formatedPhonenumber = phonenumber.Substring(0, 3) + "-" + phonenumber.Substring(3, 3) + "-" + phonenumber.Substring(6, 4);
            }
            else
            {
                formatedPhonenumber = phonenumber.ToString();
            }
            return formatedPhonenumber;//return 000-000-0000 type formated number
        }
        /// <summary>
        /// Get City,State For ZipCode
        /// </summary>
        /// <param name="zipCode">zipCode</param>
        /// <returns>DataTable</returns>
        public DataTable GetCitySttateForZipCode(string zipCode)
        {
            return USPDHUBDAL.Utilities.GetCitySttateForZipCode(zipCode);
        }
        /// <summary>
        /// Send Compaign Mail
        /// </summary>
        /// <param name="fromEmail">fromEmail</param>
        /// <param name="toEmail">toEmail</param>
        /// <param name="subject">subject</param>
        /// <param name="body">body</param>
        /// <param name="cCemail">cCemail</param>
        /// <param name="fromDisplayName">fromDisplayName</param>
        /// <param name="domainName">domainName</param>
        /// <returns>Boolean</returns>
        public bool SendCompaignMail(string fromEmail, string toEmail, string subject, string body, string cCemail, string fromDisplayName, string domainName)
        {
            bool bReturn;
            try
            {
                // *** Get SMTP server credentials *** //
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(domainName, "SMTPServer");
                string host = ConfigurationManager.AppSettings.Get("SmtpServerName");
                string hostcr = EncryptDecrypt.DESDecrypt(ConfigurationManager.AppSettings.Get("SmtpServer"));
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SmtpServerName")
                            host = row[1].ToString();
                        else if (row[0].ToString() == "SmtpServerCr")
                            hostcr = EncryptDecrypt.DESDecrypt(row[1].ToString());
                    }
                }

                System.Net.Mail.SmtpClient oSmtlClient = new System.Net.Mail.SmtpClient();
                oSmtlClient.Host = host;

                /*** For Sendgrid SMTP Server Port  July 21 2016 Azure Deployement ***/
                string sendgridSMTPServer_Username = Convert.ToString(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Username"));
                oSmtlClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Port"));


                oSmtlClient.Credentials = new System.Net.NetworkCredential(sendgridSMTPServer_Username, hostcr);
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new System.Net.Mail.MailAddress(fromEmail, fromDisplayName);
                message.To.Add(toEmail);
                if (cCemail != "") message.CC.Add(cCemail);
                message.Body = body;
                message.IsBodyHtml = true;
                message.Priority = System.Net.Mail.MailPriority.Normal;
                message.Subject = subject;
                oSmtlClient.Send(message);
                bReturn = true;
            }
            catch (Exception /*ex*/)
            {
                bReturn = false;
            }
            return bReturn;
        }

        /// <summary>
        /// sending Mail with attachment
        /// </summary>
        /// <param name="fromEmail">fromEmail</param>
        /// <param name="toEmail">toEmail</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="cCemail">cCemail</param>
        /// <param name="attachment">attachment</param>
        /// <param name="domainName">domainName</param>
        /// <returns>Boolean</returns>
        public bool SendWowzzyEmailWithAttachments(string fromEmail, string toEmail, string subject, string message, string cCemail, string attachment, string domainName)
        {
            bool bReturn;
            try
            {
                // *** Get SMTP server credentials *** //
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(domainName, "SMTPServer");
                string host = ConfigurationManager.AppSettings.Get("SmtpServerName");
                string hostcr = EncryptDecrypt.DESDecrypt(ConfigurationManager.AppSettings.Get("SmtpServer"));
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SmtpServerName")
                            host = row[1].ToString();
                        else if (row[0].ToString() == "SmtpServerCr")
                            hostcr = EncryptDecrypt.DESDecrypt(row[1].ToString());
                    }
                }
                System.Net.Mail.SmtpClient oSmtlClient = new System.Net.Mail.SmtpClient();
                oSmtlClient.Host = host;

                /*** For Sendgrid SMTP Server Port  July 21 2016 Azure Deployement ***/
                string sendgridSMTPServer_Username = Convert.ToString(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Username"));
                oSmtlClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Port"));

                oSmtlClient.Credentials = new System.Net.NetworkCredential(sendgridSMTPServer_Username, hostcr);
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new System.Net.Mail.MailAddress(fromEmail);
                string[] strto = toEmail.Split(',');
                for (int i = 0; i < strto.Length; i++)
                {
                    msg.To.Add(new System.Net.Mail.MailAddress(strto[i].Trim()));
                }
                if (cCemail != "")
                {
                    string[] ccemails = cCemail.Split(',');
                    for (int i = 0; i < ccemails.Length; i++)
                    {
                        msg.CC.Add(new System.Net.Mail.MailAddress(ccemails[i].Trim()));
                    }
                }
                string bccEmails = ConfigurationManager.AppSettings.Get("InvoiceBCC");
                if (bccEmails != "")
                {
                    string[] bccemailsarray = bccEmails.Split(',');
                    for (int i = 0; i < bccemailsarray.Length; i++)
                    {
                        msg.Bcc.Add(new System.Net.Mail.MailAddress(bccemailsarray[i].Trim()));
                    }
                }
                msg.Body = message;
                System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(attachment);
                msg.Attachments.Add(att);
                msg.IsBodyHtml = true;
                msg.Priority = System.Net.Mail.MailPriority.Normal;
                msg.Subject = subject;
                oSmtlClient.Send(msg);
                bReturn = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "ManagePublicCallIndexAddOns.aspx.cs", "SmartConnectRequestEmail()", ex.Message,
                     Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                bReturn = false;
            }
            return bReturn;

        }
        // *** Fix for IRH-45 04-02-2013 *** //
        /// <summary>
        /// Create Commission Report For User
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="purchaseOrderID">purchaseOrderID</param>
        public void CreateCommissionReportForUser(int userID, int purchaseOrderID)
        {
            try
            {
                DataTable dtPurchase = BusinessDAL.GetPurchageOrderDetails(userID, purchaseOrderID);
                if (dtPurchase.Rows.Count > 0)
                {
                    int purchaseSpid = Convert.ToInt32(dtPurchase.Rows[0]["SalesPersonID"]);
                    DateTime dtTrasanctionDate = Convert.ToDateTime(dtPurchase.Rows[0]["Created_Date"]);
                    decimal purchaseAmt = 0.00M;
                    decimal totalAmt = 0.00M;
                    for (int i = 0; i < dtPurchase.Rows.Count; i++)
                    {
                        purchaseAmt += Convert.ToDecimal(dtPurchase.Rows[i]["OrderBillable_Amt"]);
                        totalAmt += Convert.ToDecimal(dtPurchase.Rows[i]["Total_Amount"]);
                    }
                    DataTable dtSalesComms = BusinessDAL.GetSalesPersonCommission(purchaseSpid);
                    if (dtSalesComms.Rows.Count > 0)
                    {
                        int salesPersonID = Convert.ToInt32(dtSalesComms.Rows[0]["SalePerson_ID"]);
                        decimal commsAmt = 0.00M;
                        int percentage = 0;
                        if (!string.IsNullOrEmpty(dtSalesComms.Rows[0]["Percentage"].ToString()))
                            percentage = Convert.ToInt32(dtSalesComms.Rows[0]["Percentage"]) == 0 ? percentage : Convert.ToInt32(dtSalesComms.Rows[0]["Percentage"]);
                        else
                            percentage = Convert.ToInt32(dtSalesComms.Rows[0]["CPercentage"]) == 0 ? percentage : Convert.ToInt32(dtSalesComms.Rows[0]["CPercentage"]);
                        commsAmt = (purchaseAmt * percentage) / 100;
                        commsAmt = Math.Round(commsAmt, 2);
                        SalesReportRecursive(purchaseAmt, totalAmt, commsAmt, dtSalesComms, dtTrasanctionDate, purchaseOrderID, userID, salesPersonID, percentage);
                    }
                }
            }
            catch (Exception /*ex*/)
            { }
        }

        /// <summary>
        /// Sales Report Recursive
        /// </summary>
        /// <param name="purchaseAmt">purchaseAmt</param>
        /// <param name="totalAmt">totalAmt</param>
        /// <param name="commsAmt">commsAmt</param>
        /// <param name="dtSalesComms">dtSalesComms</param>
        /// <param name="dtTrasanctionDate">dtTrasanctionDate</param>
        /// <param name="orderID">orderID</param>
        /// <param name="userID">userID</param>
        /// <param name="salesPersonID">salesPersonID</param>
        /// <param name="percentage">percentage</param>
        private void SalesReportRecursive(decimal purchaseAmt, decimal totalAmt, decimal commsAmt, DataTable dtSalesComms, DateTime dtTrasanctionDate, int orderID, int userID, int salesPersonID, int percentage)
        {
            if (dtSalesComms.Rows.Count > 0)
            {
                if (commsAmt > 0)
                {
                    if (string.IsNullOrEmpty(dtSalesComms.Rows[0]["Manager_ID"].ToString()))
                    {
                        BusinessDAL.AddSalesReport(orderID, totalAmt, purchaseAmt, salesPersonID, commsAmt, userID, dtTrasanctionDate, percentage);
                    }
                    else
                    {
                        int commsflag = 0;
                        int managerID = Convert.ToInt32(dtSalesComms.Rows[0]["Manager_ID"].ToString());
                        DataTable dtSalesCommsM = BusinessDAL.GetSalesPersonCommission(managerID);
                        if (dtSalesCommsM.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtSalesCommsM.Rows[0]["IsActive"].ToString()) && Convert.ToBoolean(dtSalesCommsM.Rows[0]["IsActive"]) == true)
                            {
                                if (!string.IsNullOrEmpty(dtSalesCommsM.Rows[0]["Effected_Date"].ToString()) && (DateTime.Compare(Convert.ToDateTime(dtSalesCommsM.Rows[0]["Effected_Date"]), DateTime.Now) <= 0))
                                {
                                    if (commsAmt > 0)
                                    {
                                        decimal commsAmtM = 0.00M;
                                        int percentageM = 0;
                                        if (!string.IsNullOrEmpty(dtSalesCommsM.Rows[0]["Percentage"].ToString()))
                                            percentageM = Convert.ToInt32(dtSalesCommsM.Rows[0]["Percentage"]) == 0 ? percentageM : Convert.ToInt32(dtSalesCommsM.Rows[0]["Percentage"]);
                                        else
                                            percentageM = Convert.ToInt32(dtSalesCommsM.Rows[0]["CPercentage"]) == 0 ? percentageM : Convert.ToInt32(dtSalesCommsM.Rows[0]["CPercentage"]);
                                        commsAmtM = (commsAmt * percentageM) / 100;
                                        commsAmtM = Math.Round(commsAmtM, 2);
                                        decimal commsAmtS = commsAmt - commsAmtM;
                                        BusinessDAL.AddSalesReport(orderID, totalAmt, purchaseAmt, salesPersonID, commsAmtS, userID, dtTrasanctionDate, percentage);
                                        commsflag = 1;
                                        SalesReportRecursive(purchaseAmt, totalAmt, commsAmtM, dtSalesCommsM, dtTrasanctionDate, orderID, userID, managerID, percentageM);
                                    }
                                }
                            }
                        }
                        if (commsflag == 0)
                            BusinessDAL.AddSalesReport(orderID, totalAmt, purchaseAmt, salesPersonID, commsAmt, userID, dtTrasanctionDate, percentage);
                    }
                }
            }
        }

    }
}
