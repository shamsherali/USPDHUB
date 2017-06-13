using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class testInstaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                txtfolderpath.Text = desktopPath + "\\";
            }
        }
        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                hdnCopyPath.Value = txtfolderpath.Text.Trim();
                string downloadSoftwarePath = hdnCopyPath.Value.ToString();
                if (hdnInstallerName.Value == "1")
                {
                    string VirtualPath = Server.MapPath("~/Upload/") + "Shortcut_URL_Setup_12072013";
                    DirectoryInfo oldDirectory = new DirectoryInfo(VirtualPath);

                    string copyFolderPath = downloadSoftwarePath + "Shortcut_URL\\";
                    DirectoryInfo newDirectory = new DirectoryInfo(copyFolderPath);
                    CopyFolder(oldDirectory, newDirectory);
                    hdnCopyPath.Value = copyFolderPath;
                }
                else
                {
                    string VirtualPath = Server.MapPath("~/Upload/") + "TipsManager_Setup_17072013";
                    DirectoryInfo oldDirectory = new DirectoryInfo(VirtualPath);

                    string copyFolderPath = downloadSoftwarePath + "USPDTipsManager\\";
                    DirectoryInfo newDirectory = new DirectoryInfo(copyFolderPath);
                    CopyFolder(oldDirectory, newDirectory);
                    hdnCopyPath.Value = copyFolderPath;
                }
                //Process.Start(copyFolderPath + "setup.exe");

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "Installation();", true);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "testInstaller.aspx.cs", "BtnDownload_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        public void CopyFolder(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                foreach (DirectoryInfo dir in source.GetDirectories())
                    CopyFolder(dir, target.CreateSubdirectory(dir.Name));
                foreach (FileInfo file in source.GetFiles())
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
            catch (Exception /*ex*/)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Please enter the valid folder path');", true);
                ModalPopupExtender1.Show();
                txtfolderpath.Focus();
                return;
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string VirtualPath = Server.MapPath("~/Upload/USPDTipsManager.exe");
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=USPDTipsManager.exe");
            Response.TransmitFile(VirtualPath);
        }
    }
}