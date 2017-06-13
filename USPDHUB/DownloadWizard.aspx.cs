using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class DownloadWizard : System.Web.UI.Page
    {
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        public string LogoName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["VerticalDomain"] == null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    DomainName = objCommon.CreateDomainUrl(url);
                }

                LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DownloadWizard.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                DomainName = Session["VerticalDomain"].ToString();
                DomainName = DomainName + "_NotificationAlerts.exe";
                string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/" + DomainName);
                if (File.Exists(VirtualPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + DomainName);
                    Response.TransmitFile(VirtualPath);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DownloadWizard.aspx.cs", "lnkDownload_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}