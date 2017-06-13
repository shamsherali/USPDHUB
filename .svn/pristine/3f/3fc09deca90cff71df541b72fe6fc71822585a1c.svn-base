using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CSSFriendly
{
    public class Utility
    {
        /// <summary>
        /// Register Scripts
        /// </summary>
        /// <param name="page">page</param>
        static public void RegisterScripts(Page page)
        {
            Utility temp = new Utility();
            page.ClientScript.RegisterClientScriptInclude(temp.GetType(), temp.GetType().ToString(), page.ResolveUrl("~/Scripts/AdapterUtils.js"));
        }
    }
}
