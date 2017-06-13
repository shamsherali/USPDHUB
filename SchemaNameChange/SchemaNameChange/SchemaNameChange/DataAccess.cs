using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SchemaNameChange
{
    public class DataAccess
    {
        
        
        #region class data

        public static string SqlCon1 = WebConfigurationManager.ConnectionStrings["WOWZYDevServer"].ConnectionString;


        #endregion
    }
}