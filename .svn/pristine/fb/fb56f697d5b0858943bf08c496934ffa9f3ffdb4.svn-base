using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class Default : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        public string DomainName = "";
        public string SecureRootPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                DomainName = objCommon.CreateDomainUrl(url);
            }
            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(DomainName, "Paths");
            if (dtConfigs.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigs.Rows)
                {
                    if (row[0].ToString() == "SRootPath")
                        SecureRootPath = row[1].ToString();
                }
            }
        }
    }
}