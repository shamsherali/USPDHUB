using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;
using System.Configuration;

namespace USPDHUB.m_service
{
    /// <summary>
    /// Summary description for ShoppingCartService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ShoppingCartService : System.Web.Services.WebService
    {
        USPDHUBBLL.BusinessBLL objBusinessBLL = new USPDHUBBLL.BusinessBLL();
        public string ErrorMessage = "ERROR";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProfileSubcriptions()
        {
            try
            {
                ErrorHandling("LOG ", "ShoppingCartService.asmx", "GetProfileSubcriptions()", string.Empty, string.Empty, string.Empty, string.Empty);


                var startDate = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + " 12:00:00 AM").AddDays(-1);
                var endDate = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + " 11:59:00 PM").AddDays(-1);

                DataTable dtProfileSubcriptions = objBusinessBLL.GetProfileSubcriptionsByDates(startDate, endDate);
                List<ProfileSubcriptions> objList = new List<ProfileSubcriptions>();

                for (int i = 0; i < dtProfileSubcriptions.Rows.Count; i++)
                {
                    objList.Add(new ProfileSubcriptions
                     {
                         SubscriptionTypeID = Convert.ToString(dtProfileSubcriptions.Rows[i]["SubscriptionType_ID"]),
                         DiscountAmount = Convert.ToString(dtProfileSubcriptions.Rows[i]["Discount_Amount"]),
                         SubscriptionID = Convert.ToString(dtProfileSubcriptions.Rows[i]["Subscription_ID"]),
                         TotalAmount = Convert.ToString(dtProfileSubcriptions.Rows[i]["Total_Amount"]),
                         OrderBillableAmount = Convert.ToString(dtProfileSubcriptions.Rows[i]["OrderBillable_Amt"]),
                         PendingAmount = Convert.ToString(dtProfileSubcriptions.Rows[i]["PendingAmount"]),
                         DiscountCode = Convert.ToString(dtProfileSubcriptions.Rows[i]["Discount_Code"]),
                         PaymentType = Convert.ToString(dtProfileSubcriptions.Rows[i]["Payment_Type"]),
                         CartType = Convert.ToString(dtProfileSubcriptions.Rows[i]["Card_Type"]),

                         ProfileID = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_ID"]),
                         UserID = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_ID"]),
                         ProfileName = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_name"]),
                         Profile_AddressLine1 = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_StreetAddress1"]),
                         Profile_AddressLine2 = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_StreetAddress2"]),
                         Profile_City = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_City"]),
                         Profile_State = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_State"]),
                         Profile_Country = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_County"]),
                         Profile_Zipcode = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_Zipcode"]),
                         Profile_Phone1 = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_Phone1"]),
                         Profile_Phone2 = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_Phone2"]),
                         Profile_Fax = Convert.ToString(dtProfileSubcriptions.Rows[i]["Profile_Fax"]),
                         MobileNumber = Convert.ToString(dtProfileSubcriptions.Rows[i]["Mobile_Number"]),
                         VerticalName = Convert.ToString(dtProfileSubcriptions.Rows[i]["Vertical_Name"]),

                         FirstName = Convert.ToString(dtProfileSubcriptions.Rows[i]["Firstname"]),
                         LastName = Convert.ToString(dtProfileSubcriptions.Rows[i]["Lastname"]),
                         PrimaryEmailID = Convert.ToString(dtProfileSubcriptions.Rows[i]["Username"]),
                         CommunicationEmailID = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_email"]),
                         User_AddressLine1 = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_address1"]),
                         User_AddressLine2 = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_address2"]),
                         User_City = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_city"]),
                         User_State = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_state"]),
                         User_Country = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_Country"]),
                         User_Zipcode = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_zipcode"]),
                         User_Phone1 = Convert.ToString(dtProfileSubcriptions.Rows[i]["User_phone"])

                     });
                }

                string result = new JavaScriptSerializer().Serialize(objList);
                result = "{ ProfileSubcriptionsDetails: " + result + " }";
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "ShoppingCartService.asmx", "GetProfileSubcriptions()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        #region Error Log

        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
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

                strLogFile = errorLogFolder + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "_ShoppingCart_ErrorLog.txt";

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
    }

    public class ProfileSubcriptions
    {
        public string SubscriptionTypeID { get; set; }
        public string DiscountAmount { get; set; }
        public string SubscriptionID { get; set; }
        public string TotalAmount { get; set; }
        public string OrderBillableAmount { get; set; }
        public string PendingAmount { get; set; }
        public string DiscountCode { get; set; }
        public string PaymentType { get; set; }
        public string CartType { get; set; }

        public string ProfileID { get; set; }
        public string UserID { get; set; }
        public string ProfileName { get; set; }
        public string Profile_AddressLine1 { get; set; }
        public string Profile_AddressLine2 { get; set; }
        public string Profile_City { get; set; }
        public string Profile_State { get; set; }
        public string Profile_Country { get; set; }
        public string Profile_Zipcode { get; set; }
        public string Profile_Phone1 { get; set; }
        public string Profile_Phone2 { get; set; }
        public string Profile_Fax { get; set; }
        public string MobileNumber { get; set; }
        public string VerticalName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmailID { get; set; }
        public string CommunicationEmailID { get; set; }

        public string User_AddressLine1 { get; set; }
        public string User_AddressLine2 { get; set; }
        public string User_City { get; set; }
        public string User_State { get; set; }
        public string User_Country { get; set; }
        public string User_Zipcode { get; set; }
        public string User_Phone1 { get; set; }

    }
}
