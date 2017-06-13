using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ISANotifications
{
    public class Common
    {
        public static string GetFormImageUrl()
        {
            ///Assigning Form Icon Dynamically
            
            string iconPath = "Images\\INSA.ico";
            iconPath = Path.GetFullPath(iconPath);
            if (iconPath.ToLower().Contains("bin\\debug"))
            {
                iconPath = iconPath.ToLower().Replace("\\bin\\debug", "");
            }
            if (iconPath.ToLower().Contains("bin\\release"))
            {
                iconPath = iconPath.ToLower().Replace("\\bin\\release", "");
            }
            return iconPath;
        }

    }
}
