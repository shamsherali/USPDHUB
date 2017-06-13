using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace ISANotifications
{
    public static class GetInstalledPrograms
    {
        const string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        static string Logpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Log";        
        public static void GetInstalled_Programs()
        {
            GetInstalledProgramsFromRegistry(RegistryView.Registry32);
            GetInstalledProgramsFromRegistry(RegistryView.Registry64);
        }

        private static void GetInstalledProgramsFromRegistry(RegistryView registryView)
        {
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {

                        var name = (string)subkey.GetValue("DisplayName");
                        var releaseType = (string)subkey.GetValue("ReleaseType");
                        //var unistallString = (string)subkey.GetValue("UninstallString");
                        var systemComponent = subkey.GetValue("SystemComponent");
                        var parentName = (string)subkey.GetValue("ParentDisplayName");
                        if (File.Exists(Logpath))
                        {
                            ///File.AppendAllText(Logpath+"\\log.txt", appVersion + "," + name);
                        }
                        else
                        {
                            Directory.CreateDirectory(Logpath);
                        }
                        string appVersion = (string)subkey.GetValue("DisplayVersion");
                        File.AppendAllText(Logpath + "\\log.txt", appVersion + "," + name + ";");
                        if (name != null && name.ToString() == "inSchoolALERT Notification System")
                        {
                            //  string appVersion = (string)subkey.GetValue("DisplayVersion");
                            if (appVersion.Equals(ConfigurationManager.AppSettings["CurrentVersion"].ToString()))
                            {                              
                                string uninstall = (string)subkey.GetValue("UninstallString");
                                System.Diagnostics.Process FProcess = new System.Diagnostics.Process();

                                //  string temp = "/qn " + "/x{" + uninstall.Split("/".ToCharArray())[1].Split("I{".ToCharArray())[2];
                                string temp = "/x{" + uninstall.Split("/".ToCharArray())[1].Split("I{".ToCharArray())[2] + " /passive";
                                //replacing with /x with /i would cause another popup of the application uninstall

                                FProcess.StartInfo.FileName = uninstall.Split("/".ToCharArray())[0];

                                FProcess.StartInfo.Arguments = temp;

                                FProcess.StartInfo.UseShellExecute = false;

                                FProcess.Start();
                                FProcess.WaitForExit();



                                //
                                //string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ISANotifications";
                                ////for deleting files
                                //if (Directory.Exists(path))
                                //{
                                //    System.IO.DirectoryInfo di = new DirectoryInfo(path);
                                //    foreach (FileInfo file in di.GetFiles())
                                //    {
                                //        file.Delete();
                                //    }
                                //    foreach (DirectoryInfo dir in di.GetDirectories())
                                //    {
                                //        dir.Delete(true); //delete subdirectories and files
                                //    }
                                //    di.Refresh();
                                //}
                            
               


                            //  System.Console.Read(); 
                        }

                        }
                    }
                }
            }

            //  return result;
        }

        //private static bool IsProgramVisible(RegistryKey subkey)
        //{

        //    return
        //        !string.IsNullOrEmpty(name)
        //        && string.IsNullOrEmpty(releaseType)
        //        && string.IsNullOrEmpty(parentName)
        //        && (systemComponent == null);
        //}

    }
}
