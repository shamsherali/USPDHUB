using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserFormsDAL;
using System.Data;

namespace UserFormsBLL
{
    public class SocialMediaAutoShareBLL
    {
        /// <summary>
        /// for retrieving existing user data
        /// </summary>
        /// <param name="profileID">profileid</param>
        /// <returns>datatble</returns>
        public DataTable GetExistingUserData(int profileID)
        {
            return SocialMediaAutoShareDAL.GetExistingUserData(profileID);
        }
        /// <summary>
        /// retrieves twitter data by user id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>datatable</returns>
        public DataTable GetTwitterDataByUserID(int profileID)
        {
            return SocialMediaAutoShareDAL.GetTwitterDataByUserID(profileID);
        }
    }
}
