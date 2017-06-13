using System;
using System.Collections;
using System.Net;
using System.IO;
using AnetApi.Schema;
using System.Configuration;

namespace USPDHUBBLL
{
    public class AuthorizedNet
    {
        public static readonly string ApiLoginID = ConfigurationSettings.AppSettings["CheckPC"].ToString();
        public static readonly string TransactionKey = ConfigurationSettings.AppSettings["CheckPCKey"].ToString();
        CommonBLL objCommonBLL = new CommonBLL();

        public string AdvanceIntegrationForAuthorizedNet(string cardNumber, string expDate, string amount, string firstname, string lastName, string address, string state, string zipCode, string paymentMode, string cvvnumber, string authType)
        {

            // Testing URL : https://test.authorize.net/gateway/transact.dll

            // Live URL    : https://secure.authorize.net/gateway/transact.dll

            String postUrl = ConfigurationSettings.AppSettings["CheckPCName"];
            //String postUrl = "https://test.authorize.net/gateway/transact.dll";
            Hashtable postValues = new Hashtable();
            postValues.Add("x_login", ApiLoginID);
            postValues.Add("x_tran_key", TransactionKey);
            postValues.Add("x_delim_data", "TRUE");
            postValues.Add("x_delim_char", '|');
            postValues.Add("x_relay_response", "FALSE");
            postValues.Add("x_type", authType);
            postValues.Add("x_method", "CC");
            postValues.Add("x_card_num", cardNumber);
            postValues.Add("x_exp_date", expDate);
            postValues.Add("x_amount", amount);
            postValues.Add("x_description", paymentMode);
            postValues.Add("x_first_name", firstname);
            postValues.Add("x_last_name", lastName);
            postValues.Add("x_address", address);
            postValues.Add("x_state", state);
            postValues.Add("x_zip", zipCode);
            postValues.Add("x_card_code", cvvnumber);
            String postString = "";
            foreach (DictionaryEntry field in postValues)
            {
                postString += field.Key + "=" + field.Value + "&";
            }
            postString = postString.TrimEnd('&');

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(postUrl);
            objRequest.Method = "POST";
            objRequest.ContentLength = postString.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(postString);
            myWriter.Close();

            // returned values are returned as a stream, then read into a string
            String postResponse;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                postResponse = responseStream.ReadToEnd();
                responseStream.Close();
                responseStream.Dispose();
            }
            // the response string is broken into an array      
            Array responseArray = postResponse.Split('|');
            string responseCode = string.Empty;
            // the results are output to the screen in the form of an html numbered list.       
            foreach (string value in responseArray)
            {
                responseCode = value;
                break;
            }
            return responseCode;
        }


        // Sample Method
        public string CIMAuthorizedNet()
        {
            string ErrorMessage = "";
            string StatusCode = "";

            // Checking  if return ID >0 SUCCESS else fail
            string result = "";

            XmlAPIUtilities.PRINT_POST = false;
            bool update_profile = false;


            #region Create Subcription, Customer Address, Credit Card Details

            // Create a new customer profile
            long new_Subcription_id = CreateCustomerProfile("balaji.logictree@gmail.com", "Example Tranctions", out ErrorMessage, out StatusCode);

            // Create a new customer address
            long new_address_id = CreateCustomerAddress(new_Subcription_id, "Banjara hills Road 7", "Hyderabad", "CA", "500045");

            // Create a new customer payment profile like Credit Card Details
            long new_payment_id = CreateCustomerPaymentProfile(new_Subcription_id, "4111111111111111", "2010-10", "", out ErrorMessage, out StatusCode);

            #endregion

            #region New Transction

            // Test the transaction functionality
            bool create_transaction = CreateTransaction(new_Subcription_id, new_payment_id, 1.00M, DateTime.Now.ToShortDateString());

            #endregion

            #region Retrive Customer Related Details By Profile ID

            // Get the profile for this customer
            customerProfileMaskedType profile = GetCustomerProfile(new_Subcription_id);

            #endregion

            #region  Update  Subcription Details & Customer Addreess & Payment Details (Credit card details)


            if (profile != null)
            {
                // Update this profile with different text
                profile.description = "Update customer " + (DateTime.Now.Ticks.ToString());

                // Do the actual profile update
                update_profile = UpdateCustomerProfile(profile,"");

                if (profile.paymentProfiles.Length > 0)
                {
                    // This will update this payment profile with a new card if there is a payment profile already in this profile
                    UpdateCustomerPaymentProfile(new_Subcription_id, profile.paymentProfiles[0].customerPaymentProfileId, "4111111111111111", "2010-10", "Rob",
                        "", "", "", "", "", "", "", "", "");
                }

                // This will update the shipping address
                if (profile.shipToList.Length > 0)
                {
                    UpdateCustomerAddress(new_Subcription_id, profile.shipToList[0].customerAddressId, "", "", "", "","");
                }
            }


            #endregion

            #region Delete Subcription Details and Related


            // Delete the existing profile
            bool delete_profile = DeleteCustomerProfile(new_Subcription_id);

            #endregion

            return result;
        }


        /// <summary>
        /// Create a transaciton
        /// </summary>
        public bool CreateTransaction(long profile_id, long payment_profile_id, decimal transctionAmount, string pInvoiceNumber)
        {
            bool out_bool = false;

            createCustomerProfileTransactionRequest request = new createCustomerProfileTransactionRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);

            profileTransactionType new_trans = new profileTransactionType();

            profileTransAuthOnlyType new_item = new profileTransAuthOnlyType();
            new_item.customerProfileId = profile_id.ToString();
            new_item.customerPaymentProfileId = payment_profile_id.ToString();
            new_item.amount = transctionAmount;

            orderExType order = new orderExType();
            order.invoiceNumber = pInvoiceNumber;
            new_item.order = order;


            new_trans.Item = new_item;
            request.transaction = new_trans;

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            createCustomerProfileTransactionResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is createCustomerProfileTransactionResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                //Console.WriteLine(String.Format("Created Transaction\n	 code: {0}\n	  msg: {1}", ErrorResponse.messages.message[0].code, ErrorResponse.messages.message[0].text));
                return out_bool;
            }
            if (bResult) api_response = (createCustomerProfileTransactionResponse)response;
            if (api_response != null)
            {
                out_bool = true;
                //Console.WriteLine("Created Transaction " + api_response.directResponse);
                //Console.WriteLine(String.Format("	 code: {0}\n	  msg: {1}", api_response.messages.message[0].code, api_response.messages.message[0].text));
            }
            return out_bool;
        }

        /// <summary>
        /// Update the customer profile 
        /// </summary>
        /// <param name="in_profile">The profile ID that we are updating</param>
        /// <returns>If the operation was successfull or not</returns>
        public bool UpdateCustomerProfile(customerProfileMaskedType in_profile, string billingemail)
        {

            bool out_bool = false;
            string statusCode = "";
            string statusMessage = "";
            updateCustomerProfileRequest request = new updateCustomerProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);
            request.profile = new customerProfileExType();
            request.profile.customerProfileId = in_profile.customerProfileId;
            request.profile.email = billingemail;
            request.profile.description = billingemail;
            request.profile.merchantCustomerId = in_profile.merchantCustomerId;

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            updateCustomerProfileResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is updateCustomerProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                statusCode = ErrorResponse.messages.message[0].code;
                statusMessage = ErrorResponse.messages.message[0].text;

                return out_bool;
            }
            if (bResult) api_response = (updateCustomerProfileResponse)response;
            if (api_response != null)
            {
                out_bool = true;
                statusCode = api_response.messages.message[0].code;
                statusMessage = api_response.messages.message[0].text;
            }
            objCommonBLL.InsertErrorLog("LOG", "UpdateCustomerProfile() -  Message: " + statusMessage, "Code: " + statusCode, "", "", "ReviewOrder.aspx.cs", "lnkPlaceOrder_Click");
            return out_bool;
        }

        /// <summary>
        /// Delete the customer profile
        /// </summary>
        /// <param name="profile_id">The profile id that we are deleting</param>
        /// <returns>The operaiton succeeded or not</returns>
        public bool DeleteCustomerProfile(long profile_id)
        {
            bool out_bool = false;

            deleteCustomerProfileRequest request = new deleteCustomerProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);
            request.customerProfileId = profile_id.ToString();

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            deleteCustomerProfileResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is deleteCustomerProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                //Console.WriteLine(String.Format("Deleted Profile\n	 code: {0}\n	  msg: {1}", ErrorResponse.messages.message[0].code, ErrorResponse.messages.message[0].text));
                return out_bool;
            }
            if (bResult) api_response = (deleteCustomerProfileResponse)response;
            if (api_response != null)
            {
                out_bool = true;
                //Console.WriteLine("Deleted Profile #" + profile_id);
                //Console.WriteLine(String.Format("	 code: {0}\n	  msg: {1}", api_response.messages.message[0].code, api_response.messages.message[0].text));
            }

            return out_bool;
        }

        /// <summary>
        /// Get the customer profile
        /// </summary>
        /// <param name="profile_id">The ID of the customer that we are getting the profile for</param>
        /// <returns>The profile that was returned</returns>
        public customerProfileMaskedType GetCustomerProfile(long profile_id)
        {
            customerProfileMaskedType out_profile = null;

            getCustomerProfileRequest request = new getCustomerProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);
            request.customerProfileId = profile_id.ToString();

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            getCustomerProfileResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is getCustomerProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                //Console.WriteLine(String.Format("Retrieved Profile\n	 code: {0}\n	  msg: {1}", ErrorResponse.messages.message[0].code, ErrorResponse.messages.message[0].text));
                return out_profile;
            }
            if (bResult) api_response = (getCustomerProfileResponse)response;
            if (api_response != null)
            {
                out_profile = api_response.profile;
                //Console.WriteLine("Retrieved Profile #" + profile_id);
                //Console.WriteLine(String.Format("	 code: {0}\n	  msg: {1}", api_response.messages.message[0].code, api_response.messages.message[0].text));
            }

            return out_profile;
        }

        /// <summary>
        /// Update the customer address
        /// </summary>
        /// <param name="profile_id">The customer profile id we are doing this for</param>
        /// <param name="AddressID">The payment profile id that we are updating</param>
        /// <returns></returns>
        public bool UpdateCustomerAddress(long profile_id, string Address1, string pStreetAddress, string pCity, string pState, string pZipcode, string AddressID)
        {
            bool out_bool = false;
            string statusCode = "";
            string statusMessage = "";

            // Setup the request
            updateCustomerShippingAddressRequest request = new updateCustomerShippingAddressRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);

            // Create a new address record
            customerAddressExType new_address = new customerAddressExType();
            new_address.address = pStreetAddress;
            new_address.city = pCity;
            new_address.state = pState;
            new_address.zip = pZipcode;

            // Assign the values to this request
            request.customerProfileId = profile_id.ToString();
            request.address = new_address;
            request.address.customerAddressId = AddressID;

            // Send the request and get the response
            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            updateCustomerShippingAddressResponse api_response = null;

            // See what the response was
            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is updateCustomerShippingAddressResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                statusCode = ErrorResponse.messages.message[0].code;
                statusMessage = ErrorResponse.messages.message[0].text;
                return out_bool;
            }
            if (bResult) api_response = (updateCustomerShippingAddressResponse)response;
            if (api_response != null)
            {
                out_bool = true;
                statusCode = api_response.messages.message[0].code;
                statusMessage = api_response.messages.message[0].text;
            }
            objCommonBLL.InsertErrorLog("LOG", "UpdateCustomerAddress() -  Message: " + statusMessage, "Code: " + statusCode, "", "", "ReviewOrder.aspx.cs", "lnkPlaceOrder_Click");
            return out_bool;
        }

        /// <summary>
        /// Update the customer payment profile
        /// </summary>
        /// <param name="profile_id">The customer profile id we are doing this for</param>
        /// <param name="PaymentProfileID">The payment profile id that we are updating</param>
        /// <param name="CardNumber">The number for the card that we are processing</param>
        /// <param name="ExpirationDate">The expiration date for the card that we are processing</param>
        /// <param name="BillToFirstName">The first name of the person who will be the bill to</param>
        /// <returns></returns>
        public bool UpdateCustomerPaymentProfile(long profile_id, string PaymentProfileID,
            string CardNumber, string ExpirationDate, string BillToFirstName, string LastName, string CompanyName, string Address, string City,
            string State, string Zip, string Country, string PhoneNumber, string FaxNumber)
        {
            bool out_bool = false;

            // Setup the request
            updateCustomerPaymentProfileRequest request = new updateCustomerPaymentProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);

            // Create a new credit card
            customerPaymentProfileExType new_payment_profile = new customerPaymentProfileExType();
            paymentType new_payment = new paymentType();
            creditCardType new_card = new creditCardType();
            new_card.cardNumber = CardNumber;
            new_card.expirationDate = ExpirationDate;
            new_payment.Item = new_card;
            new_payment_profile.payment = new_payment;

            // Create the bill to type
            new_payment_profile.billTo = new customerAddressType();
            new_payment_profile.billTo.firstName = BillToFirstName;
            new_payment_profile.billTo.lastName = LastName;
            new_payment_profile.billTo.company = CompanyName;
            new_payment_profile.billTo.address = Address;
            new_payment_profile.billTo.city = City;
            new_payment_profile.billTo.state = State;
            new_payment_profile.billTo.zip = Zip;
            new_payment_profile.billTo.country = Country;
            new_payment_profile.billTo.phoneNumber = PhoneNumber;
            new_payment_profile.billTo.faxNumber = FaxNumber;

            // Apply the new card over the existing card
            request.customerProfileId = profile_id.ToString();
            request.paymentProfile = new_payment_profile;
            request.paymentProfile.customerPaymentProfileId = PaymentProfileID;

            // Send the request and get the response
            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            updateCustomerPaymentProfileResponse api_response = null;

            // See what the response was
            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is updateCustomerPaymentProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                // Console.WriteLine(String.Format("Updated Payment Profile\n	 code: {0}\n	  msg: {1}", ErrorResponse.messages.message[0].code, ErrorResponse.messages.message[0].text));
                return out_bool;
            }
            if (bResult) api_response = (updateCustomerPaymentProfileResponse)response;
            if (api_response != null)
            {
                out_bool = true;
                // Console.WriteLine(String.Format("Updated Payment Profile\n	 code: {0}\n	  msg: {1}", api_response.messages.message[0].code, api_response.messages.message[0].text));
            }

            return out_bool;
        }
        /// <summary>
        /// Create the customer payment profile
        /// </summary>
        /// <param name="profile_id">The ID of the customer that we are creating</param>
        /// <param name="IsBank">If this is a bank or not</param>
        /// <returns>The return result</returns>
        public long CreateCustomerPaymentProfile(long profile_id, string pCreditCardNumber, string pExDate, string pCVV, out string ErrorMessage, out string StatusCode)
        {
            ErrorMessage = "";
            StatusCode = "";

            long out_id = 0;

            customerPaymentProfileType new_payment_profile = new customerPaymentProfileType();
            paymentType new_payment = new paymentType();

            creditCardType new_card = new creditCardType();
            new_card.cardNumber = pCreditCardNumber;
            new_card.expirationDate = pExDate;
            new_payment.Item = new_card;
            new_card.cardCode = pCVV;

            new_payment_profile.payment = new_payment;

            createCustomerPaymentProfileRequest request = new createCustomerPaymentProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);

            request.customerProfileId = profile_id.ToString();
            request.paymentProfile = new_payment_profile;
            // checking Live Mode or Test Mode
            request.validationMode = validationModeEnum.liveMode;

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            createCustomerPaymentProfileResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is createCustomerPaymentProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                ErrorMessage = ErrorResponse.messages.message[0].text;
                StatusCode = ErrorResponse.messages.message[0].code;
                return out_id;
            }
            if (bResult) api_response = (createCustomerPaymentProfileResponse)response;
            if (api_response != null)
            {
                out_id = Convert.ToInt64(api_response.customerPaymentProfileId);
                ErrorMessage = api_response.messages.message[0].text;
                StatusCode = api_response.messages.message[0].code;
            }

            return out_id;
        }


        /// <summary>
        /// Create a customer address record for the specified profile
        /// </summary>
        /// <param name="profile_id">The customer profile that we are creating a new address for</param>
        /// <returns>The ID of the profile that was created</returns>
        public long CreateCustomerAddress(long profile_id, string pStreetAddress, string pCity, string pState, string pZipcode)
        {
            long out_id = 0;

            // Create a new address record
            customerAddressType new_address = new customerAddressType();
            new_address.address = pStreetAddress;
            new_address.city = pCity;
            new_address.state = pState;
            new_address.zip = pZipcode;

            // Create a new request
            createCustomerShippingAddressRequest request = new createCustomerShippingAddressRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);

            // Assign the values to this request
            request.customerProfileId = profile_id.ToString();
            request.address = new_address;

            // Send the request 
            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            createCustomerShippingAddressResponse api_response = null;

            // Retrieve the response
            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is createCustomerShippingAddressResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                return out_id;
            }
            if (bResult) api_response = (createCustomerShippingAddressResponse)response;
            if (api_response != null)
            {
                out_id = Convert.ToInt64(api_response.customerAddressId);
            }

            return out_id;
        }


        /// <summary>
        /// Create the customer profile
        /// </summary>
        /// <returns>The result of the operation</returns>
        public long CreateCustomerProfile(string pCustomerEmailID, string pDescription, out string ErrorMessage, out string StatusCode)
        {
            ErrorMessage = "";
            StatusCode = "";

            long out_id = 0;
            createCustomerProfileRequest request = new createCustomerProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);

            customerProfileType m_new_cust = new customerProfileType();
            m_new_cust.email = pCustomerEmailID;
            m_new_cust.description = pDescription;

            request.profile = m_new_cust;

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            createCustomerProfileResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is createCustomerProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                ErrorMessage = ErrorResponse.messages.message[0].text;
                StatusCode = ErrorResponse.messages.message[0].code;
                return out_id;
            }
            if (bResult) api_response = (createCustomerProfileResponse)response;
            if (api_response != null)
            {
                out_id = Convert.ToInt64(api_response.customerProfileId);
                ErrorMessage = api_response.messages.message[0].text;
                StatusCode = api_response.messages.message[0].code;
            }

            return out_id;
        }

    }
}
