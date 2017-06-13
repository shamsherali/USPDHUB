<%@ WebHandler Language="C#" Class="UploadBGImages" %>

using System;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;


public class UploadBGImages : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        //context.Response.Expires = -1;
        try
        {
            int PID = 0;
            string savefilePath = "TempBGImages";
            if (HttpContext.Current.Request.QueryString["PID"] != null)
            {
                PID = Convert.ToInt32(HttpContext.Current.Request.QueryString["PID"]);
            }
            if (HttpContext.Current.Request.QueryString["savepath"] != null)
                savefilePath = Convert.ToString(HttpContext.Current.Request.QueryString["savepath"]);
            string ImageDirectory = HttpContext.Current.Server.MapPath("~/Upload/" + savefilePath + "/" + PID);
            try
            {
                if (Directory.Exists(ImageDirectory))
                    Directory.Delete(ImageDirectory);
                Directory.CreateDirectory(ImageDirectory);
            }
            catch (Exception ex)
            {

            }

            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;

                ////  Uploading files to folder
                foreach (string key in files)
                {
                    //Regex.Replace(pValue, @"[^0-9a-zA-Z.]+", "");

                    HttpPostedFile file = files[key];
                    string ImageName = Path.GetFileNameWithoutExtension(file.FileName);
                    string imgExt = Path.GetExtension(file.FileName);


                    ImageName = Regex.Replace(ImageName, @"[^0-9a-zA-Z.]+", "");
                    
                    string savefile = ImageName + "-ResizeReference" + imgExt;
                    string imgSavePath = ImageDirectory + "\\" + savefile;
                    file.SaveAs(imgSavePath);
                    context.Response.Write(savefile);
                }
            }
            System.Threading.Thread.Sleep(2 * 1000);
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}