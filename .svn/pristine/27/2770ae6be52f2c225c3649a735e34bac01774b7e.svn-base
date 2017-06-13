using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using USPDHUBBLL;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using USPDHUBDAL;

namespace USPDHUB.m_service
{
    /// <summary>
    /// Summary description for AdminService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AdminService : System.Web.Services.WebService
    {

        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string ValidateEmailID(SignUpDetails pobjSignUpDetails)
        {

            string typevalue = "";

            try
            {
                int countUser;
                countUser = objBus.CheckUserNameandPasswordForVaildUser(pobjSignUpDetails.EmailID.Trim(), pobjSignUpDetails.Vertical.Trim(), pobjSignUpDetails.Country);
                int count = objAgency.ValidateAgencyEmailID(pobjSignUpDetails.EmailID.Trim(), pobjSignUpDetails.Vertical.Trim(), pobjSignUpDetails.Country);
                if (count > 0)
                    typevalue = "4";
                else
                {
                    if (countUser == 0)
                    {
                        typevalue = "1";
                    }
                    else
                    {
                        typevalue = "2";
                    }
                }
            }
            catch
            {
                typevalue = "3";
            }

            return typevalue;

        }

        [WebMethod]
        public string FreeTrailAccountSignUp(SignUpDetails pobjSignUpDetails)
        {
            //twoviecom

            string result = "";

            try
            {
                #region Inquiry Insert (Agency Details)

                int? parentProfileID = null;
                string remarks = string.Empty;
                string title = string.Empty;
                string country = "United States";
                string date = "";
                string PromoCode = "FreeTrial";

                int inquiryID = objAgency.AddAgencyUser(pobjSignUpDetails.OrganizationName.Trim(), pobjSignUpDetails.EmailID, pobjSignUpDetails.FirstName,
                    pobjSignUpDetails.OrganizationPhoneNumber, date, remarks, 0, title, pobjSignUpDetails.HowDidYouHearAboutUs, pobjSignUpDetails.Vertical, PromoCode,
                    parentProfileID, parentProfileID, pobjSignUpDetails.LastName, country, pobjSignUpDetails.Address.Trim(), pobjSignUpDetails.City.Trim(),
                    pobjSignUpDetails.State.Trim(), pobjSignUpDetails.Zipcode);

                #endregion

                InsertUserDetails(inquiryID, null, pobjSignUpDetails);

                result = "success";
            }
            catch (Exception ex)
            {

            }
            return result;

        }

        private void InsertUserDetails(int inquiryId, int? parentProfileID, SignUpDetails pobjSignUpDetails)
        {
            string DomainName = pobjSignUpDetails.DomainName;
            int profileID = 0;
            int userID = 0;
            string username = "";
            int subPeriod = 1;
            decimal totalAmt = 0.00M;
            decimal billableAmt = 0.00M;
            decimal discount = 0.00M;
            decimal renewal = 0.00M;
            string PromoCode = "FreeTrial";

            string Address = pobjSignUpDetails.Address.Trim();
            string CityName = pobjSignUpDetails.City;
            string zipCode = pobjSignUpDetails.Zipcode;
            string stateName = pobjSignUpDetails.State;
            string password = objCommon.GenerateRandomPassword();

            #region Getting Latidude & longtidude values
            string fullAddress = Address + "," + CityName + "," + stateName + "," + zipCode;
            Coordinate coordinates = Geocode.GetCoordinates(fullAddress);
            double latitude1 = Convert.ToDouble(coordinates.Latitude);
            double longitude1 = Convert.ToDouble(coordinates.Longitude);
            #endregion
            profileID = objAgency.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), inquiryId,Convert.ToInt32(ProfileSubscriptionTypes.Premium));
            DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileID);


            //Session["ProfileID"] = profileID;
            username = pobjSignUpDetails.EmailID.Trim();
            if (dtuserdetails.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtuserdetails.Rows[0]["Username"].ToString()))
                    username = dtuserdetails.Rows[0]["Username"].ToString();
                userID = Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]);
            }
            #region Insert Tranaction Details (SubcriptionTypes Table)
            int subscriptionID = objBus.InsertUserSubscriptions(profileID, userID, subPeriod, totalAmt, discount, billableAmt, "", "", "", "", "", "", "", "", "", 0, 0, "",  "",PromoCode, false);

            int SID = 0;
            DataTable dtSubcriptions = objBus.GetStoreItems("New", DomainName.ToString());
            for (int i = 0; i < dtSubcriptions.Rows.Count; i++)
            {
                // Non-Branded Amount Year
                if (Convert.ToString(dtSubcriptions.Rows[i]["Type"]).Trim() == string.Empty &&
                    Convert.ToString(dtSubcriptions.Rows[i]["Subscription_period"]) == "1")
                {
                    SID = Convert.ToInt32(dtSubcriptions.Rows[i]["Subscription_ID"]);
                    break;
                }
            }

            // Insert Transction Details
            int subcriptionTypeID = objBus.InsertTransaction(profileID, userID, subscriptionID, 10000,
                                   Convert.ToDecimal(discount), Convert.ToDecimal(billableAmt),
                                   Convert.ToDecimal(totalAmt), userID, subPeriod, DateTime.Now.AddMonths(subPeriod), "",
                                   "", "", "", "",
                                   "", "", "", "", "", "", "", Convert.ToInt32(RequestCustomFormTypes.NewRegistration), subPeriod, 0, 0, "", "", "");


            //Insert Order Details
            DateTime createDate = DateTime.Now;
            DateTime renewalDate = createDate.AddMonths(subPeriod);
            int? promoCodeId = null;
            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, SID, totalAmt, discount,
                      billableAmt, createDate, userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                      subPeriod, "", Convert.ToDecimal(renewal), false, promoCodeId);

            SendActivationEmail(username, password, "", DomainName);
            SendRepresentationEmail(profileID, DomainName);

            //Response.Redirect(RootPath + "/OP/" + DomainName + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileID.ToString()));

            #endregion
        }

        private void SendActivationEmail(string username, string password, string location, string verticalValue)
        {
            try
            {
                string vertRootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(verticalValue, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            vertRootPath = row[1].ToString();
                    }
                }
                string FromInfo = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(verticalValue, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromInfo = row[1].ToString();
                    }
                }
                //string strfilepath = Server.MapPath("~") + "\\EmailContent" + verticalValue + "\\";
                string strfilepath = ConfigurationManager.AppSettings.Get("USPDEmailContentFolderPath") + "\\EmailContent" + verticalValue + "\\";
                StreamReader re = File.OpenText(strfilepath + "AgencyActivationCode.txt");
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
                msgbody = msgbody.Replace("#RootUrl#", vertRootPath);
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#Link#", "<a href='" + vertRootPath + "/OP/" + verticalValue + "/Login.aspx' target='_blank'>Login</a>");
                msgbody = msgbody.Replace("#Email#", username);
                msgbody = msgbody.Replace("#Password#", password);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                if (string.IsNullOrEmpty(location))
                    utlobj.SendWowzzyEmail(FromInfo, username, "Account Details", msgbody, ccemail, "", verticalValue);
                else
                    utlobj.SendWowzzyEmailWithAttachments(FromInfo, username, "Account Details", msgbody, ccemail, location, verticalValue);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "AdminService.asmx", "SendActivationEmail()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void SendRepresentationEmail(int profileID, string verticalValue)
        {
            try
            {
                string displayName = "";
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(verticalValue, "VerticalNames");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "NameForDisplay")
                        {
                            displayName = row[1].ToString();
                            break;
                        }
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(verticalValue, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailsupport = row[1].ToString();
                            break;
                        }
                    }
                }
                //string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + verticalValue + "\\";
                string strfilepath = ConfigurationManager.AppSettings.Get("USPDEmailContentFolderPath") + "\\EmailContent" + verticalValue + "\\";
                StreamReader re = File.OpenText(strfilepath + "Representation.txt");
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
                DataTable dtuserdetails = BusinessDAL.GetuserdetailsByProfileID(profileID);
                if (dtuserdetails.Rows.Count > 0)
                {
                    DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
                    msgbody = msgbody.Replace("#msgBody#", content);
                    msgbody = msgbody.Replace("##DomainName##", displayName);
                    msgbody = msgbody.Replace("##ProfileName##", dtProfile.Rows[0]["Profile_name"].ToString());
                    msgbody = msgbody.Replace("##FirstName##", dtuserdetails.Rows[0]["Firstname"].ToString());
                    re.Close();
                    reDeclaimer.Close();
                    string ccemail = string.Empty;

                    UtilitiesBLL utlobj = new UtilitiesBLL();
                    utlobj.SendWowzzyEmail(FromEmailsupport, dtuserdetails.Rows[0]["Username"].ToString(), "Account Representative Details", msgbody, ccemail, "", verticalValue);
                    re.Dispose();
                    reDeclaimer.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "AdminService.asmx", "SendActivationEmail()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
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

    public class SignUpDetails
    {
        public string OrganizationName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HowDidYouHearAboutUs { get; set; }
        public string OrganizationPhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Vertical { get; set; }
        public string Country { get; set; }
        public string DomainName { get; set; }
    }


}
