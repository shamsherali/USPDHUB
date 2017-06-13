using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
        public static bool IsNetworkAvailable()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

        }
        public static void DeleteRows(DataRow[] drDeleteList)
        {
            foreach (DataRow dr in drDeleteList)
            {
                try
                {

                    DataRow[] drList = Properties.Settings.Default.DataTableNotifications.Select("PushNotifyID=" + Convert.ToInt32(dr["PushNotifyID"]));
                    if (drList.Length > 0)
                    {
                        foreach (DataRow drDelete in drList)
                        {
                            drDelete.Delete();
                        }
                    }
                }
                catch { }
            }
            Properties.Settings.Default.DataTableNotifications.AcceptChanges();
        }
        public static void InsertRows(DataRow[] drList, string NoteficationColor)
        {
            DataTable dt = drList.CopyToDataTable();
            dt.Columns.Add("Color");
            if (dt.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Color"] = NoteficationColor;
                        int id = int.Parse(dt.Rows[i]["PushNotifyID"].ToString());
                        var dr = Properties.Settings.Default.DataTableNotifications.Select("PushNotifyID=" + id).FirstOrDefault();
                        if (dr == null)
                            Properties.Settings.Default.DataTableNotifications.Rows.Add(dt.Rows[i].ItemArray);
                    }
                    Properties.Settings.Default.DataTableNotifications.AcceptChanges();
                }
                catch (Exception ex)
                {

                }
            }

        }

    }
}
