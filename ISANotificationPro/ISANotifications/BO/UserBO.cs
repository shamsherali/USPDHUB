using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISANotifications
{
    public class UserBO
    {
        #region Variables    

        string _fName = string.Empty;
        string _mobileNo = string.Empty;
        string _schoolName = string.Empty;
        string _password = string.Empty;

        #endregion

        #region Properties    
        /// <summary>    
        /// Gets or sets the name of the user.    
        /// </summary>    
        /// <value>    
        /// The name of the user.    
        /// </value>    
        public string FirstName
        {
            get
            {
                return _fName;
            }
            set
            {
                _fName = value;
            }
        }



        /// <summary>    
        /// Gets or sets the mobile no.    
        /// </summary>    
        /// <value>    
        /// The mobile no.    
        /// </value>    
        public string MobileNo
        {
            get
            {
                return _mobileNo;
            }
            set
            {
                _mobileNo = value;
            }
        }
        /// <summary>    
        /// Gets or sets the OTP.    
        /// </summary>    
        /// <value>    
        /// OTP   
        /// </value>    
        public string OTP
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        /// <summary>    
        /// Gets or sets the School Name.    
        /// </summary>    
        /// <value>    
        /// The School Name
        /// </value>    
        public string SchoolName
        {
            get
            {
                return _schoolName;
            }
            set
            {
                _schoolName = value;
            }
        }
        #endregion
    }


    public class RegistrationUser
    {
        public int RegistrationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string OSName { get; set; }

        public string OSVersion { get; set; }
        public int ProfileID { get; set; }

        public string GenerateOTP { get; set; }

    }

}

