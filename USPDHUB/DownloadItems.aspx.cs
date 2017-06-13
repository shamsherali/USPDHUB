using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using USPDHUBBLL;
using System.IO;

namespace USPDHUB
{
    public partial class DownloadItems : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuilt = new InBuiltDataBLL();
        string filePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Request.QueryString["DownloadFile"] != null && Convert.ToString(HttpContext.Current.Request.QueryString["DownloadFile"]) != "")
                {
                    string file = Convert.ToString(HttpContext.Current.Request.QueryString["DownloadFile"]);
                    string[] filename = file.Split('/');
                    using (WebClient webClient = new WebClient())
                    {
                        filePath = HttpContext.Current.Server.MapPath("/Upload/UserDownloads/") + filename[filename.Length - 1];
                        webClient.DownloadFile(file, filePath);
                        this.Response.Clear();
                        this.Response.ContentType = "application/octet-stream";
                        this.Response.AddHeader("Content-Disposition", "attachment; filename= " + filename[filename.Length - 1]);
                        this.Response.WriteFile(filePath);
                        this.Response.Flush();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuilt.ErrorHandling("ERROR", "DownloadItems.aspx", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}