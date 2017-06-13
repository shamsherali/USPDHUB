using System;
using System.Web.Configuration;

namespace UserFormsDAL
{
    public class DataAccess
    {
        #region class data
        public static string SqlCon1 = WebConfigurationManager.ConnectionStrings["WOWZYDevServer"].ConnectionString;
        #endregion
    }
}
