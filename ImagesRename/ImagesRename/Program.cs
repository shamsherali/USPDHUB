using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImagesRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string iconSize = "1080x1920";
            string directoryFolderPath = @"D:\ravibabu\new_format_icons\1080x1920";
            DirectoryInfo d = new DirectoryInfo(directoryFolderPath);
            FileInfo[] infos = d.GetFiles();
            int i = 0;
            string fExt;
            string fFromName;
            string fToName;

            // this one UI Designer Provided order
            // 100 Icons
            string[] names = { "aboutus" , "bulletins", "call","ChiefMessage02", "ChiefMessage03", "ChiefMessage04","ChiefMessage01", 
                               "contact", "directions","events","home","media", "Missingperson04","Missingperson02","Missingperson03","Missingperson01",
                              "notification", "Policeactivity02","Policeactivity03","Policeactivity04","Policeactivity01",
                              "Pressrelease02","Pressrelease03","Pressrelease04","Pressrelease01",
                              "Schoolnotification02","Schoolnotification03","Schoolnotification04","Schoolnotification01", "social",
                              "Stolenvehicle02", "Stolenvehicle03","Stolenvehicle04","Stolenvehicle01","submittip", "survey", 
                               "Template03","Template02","Template01",  "Template04", 
                               "Trafficalert04","Trafficalert02","Trafficalert03", "Trafficalert01","updates", 
                                "wanted04", "wanted02","wanted03","wanted01","weblinks"};

            // USPDhub folder custom tabs icons order
            //string[] names = { "aboutus" , "bulletins", "call","ChiefMessage01", "ChiefMessage02", "ChiefMessage03","ChiefMessage04", 
            //                   "contact", "directions","events","home","media", "Missingperson01","Missingperson02","Missingperson03","Missingperson04",
            //                  "notification", "Policeactivity01","Policeactivity02","Policeactivity03","Policeactivity04",
            //                  "Pressrelease01","Pressrelease02","Pressrelease03","Pressrelease04",
            //                  "Schoolnotification01","Schoolnotification02","Schoolnotification03","Schoolnotification04", "social",
            //                   "Stolenvehicle01","Stolenvehicle02","Stolenvehicle03","Stolenvehicle04","submittip", "survey", 
            //                   "Template01","Template02","Template03",  "Template04", 
            //                   "Trafficalert01","Trafficalert02","Trafficalert03", "Trafficalert04","updates", 
            //                     "wanted01","wanted02","wanted03","wanted04","weblinks"};

            foreach (FileInfo f in infos)
            {
                fFromName = Path.GetFileNameWithoutExtension(f.Name);
                string newFileName = fFromName.Replace("_" + iconSize, "");

                fExt = Path.GetExtension(f.Name);

                //fFromName = fFromName.Replace("640x960", "");
                string iconFileName = names.Where(row => row.ToString().Contains(fFromName)).SingleOrDefault();
                if (fFromName.Contains("_n_"))
                    fToName = string.Format("{0}_n_" + iconSize + "{1}", names[i], fExt); //aboutus_n_1080x1920.png
                else
                {
                    fToName = string.Format("{0}_s_" + iconSize + "{1}", names[i], fExt); //aboutus_n_1080x1920.png
                    i++;
                }
                File.Move(f.FullName, directoryFolderPath + "\\" + fToName);

            }
        }
    }
}
