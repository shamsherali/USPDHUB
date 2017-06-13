using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml;
using System.Management;

namespace ISANotifications
{
    public class VersionHelper
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ISANotifications_Download";

        private string MSIFilePath = path + "\\notificationsAlert.exe";
        //  private string CmdFilePath = path + "\\Install.cmd";
        private string MsiUrl = String.Empty;

        public string CheckForNewVersion()
        {
            string strVersion = string.Empty;
            MsiUrl = GetNewVersionUrl(out strVersion);
            return strVersion;
        }

        public void DownloadNewVersion()
        {
            DownloadNewVersion(MsiUrl);
            RunFile();

            #region For Upgrade Purpose

            string strpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ISANotifications_Download\\Updated";
            if (!Directory.Exists(strpath))
                Directory.CreateDirectory(strpath);

            #endregion

            GetInstalledPrograms.GetInstalled_Programs();
            ExitApplication();
        }

        private string GetNewVersionUrl(out string strVersion)
        {
            strVersion = String.Empty;
            Double currentVersion = Convert.ToDouble(ConfigurationManager.AppSettings["Version"]);
            //get xml from url.
            var url = ConfigurationManager.AppSettings["VersionUrl"].ToString();
            var builder = new StringBuilder();
            using (var stringWriter = new StringWriter(builder))
            {
                using (var xmlReader = new XmlTextReader(url))
                {
                    var doc = System.Xml.Linq.XDocument.Load(xmlReader);
                    //get versions.
                    var versions = from v in doc.Descendants("item")
                                   select new
                                   {
                                       Name = v.Element("name").Value,
                                       Number = Convert.ToDouble(v.Element("number").Value),
                                       URL = v.Element("url").Value,
                                       Date = (v.Element("releasedate").Value).ToString()
                                   };
                    var version = versions.ToList()[0];
                    //check if latest version newer than current version.
                    if (Convert.ToDouble(version.Number) > currentVersion)
                    {
                        strVersion = version.Number.ToString();
                        return version.URL;
                    }
                }
            }
            return String.Empty;
        }

        private void DownloadNewVersion(string url)
        {
            try
            {
                //delete existing msi.
                if (File.Exists(MSIFilePath))
                {
                    File.Delete(MSIFilePath);
                }
                else
                {
                    Directory.CreateDirectory(path);
                }

                //download new msi.
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, MSIFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went to wrong while downloading the file.");
                return;
            }

        }


        private void RunFile()
        {//run command file to reinstall app.
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = MSIFilePath;
            psi.UseShellExecute = false;
            // Process.Start(psi);
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();

        }

        private void ExitApplication()
        {//exit the app.
            Application.Current.Shutdown();
        }

    }
}
