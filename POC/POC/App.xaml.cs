using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using POC.POC_Utilities;
using System.IO;

namespace POC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string FileTitle { get; set; }

        public static string FileFullName { get; set; }

        public static Stream objImgStream { get; set; }

        public static Window ParentWindow { get; set; }

        public static int _PageCount { get; set; }

        public static int PermissionValue { get; set; }

        public static string PermissionType { get; set; }

        public static int C_USER_ID { get; set; }
        public static string C_USER_NAME { get; set; }

        public static string Username { get; set; }
        public static string Password { get; set; }

        public static bool IsLogOut = false;

        public static bool IsExpiryAccount = false;

        public static string strEditHTML { get; set; }
        public static string strPreviewHTML { get; set; }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    ThemeManager.ApplyTheme(this, "BubbleCreme");
        //    base.OnStartup(e);
        //}
    }
}
