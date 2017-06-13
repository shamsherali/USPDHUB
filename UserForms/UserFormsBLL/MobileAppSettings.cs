using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;
using UserFormsDAL;

namespace UserFormsBLL
{
    public class MobileAppSettings
    {
        /// <summary>
        /// for retrieving mobile app settings
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public DataTable GetMobileAppSetting(int pUserID)
        {
            return UserFormsDAL.MobileAppSettings.GetMobileAppSetting(pUserID);
        }
    }
}
