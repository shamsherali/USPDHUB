<%@ WebHandler Language="C#" Class="UploadWordContent" %>

using System;
using System.Web;
using System.IO;



public class UploadWordContent : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            string fileExtension = "";
            string fileName = "";
            string fileSavePath = "";
            string ProfileID = "";
            if (HttpContext.Current.Request.QueryString["PID"] != null)
            {
                ProfileID = HttpContext.Current.Request.QueryString["PID"].ToString();
            }

            string uploadFolderPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\WordContent\\" + ProfileID.ToString();
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            if (context.Request.Files.Count > 0)
            {
                GC.Collect();
                HttpFileCollection files = context.Request.Files;
                int i = 1;
                foreach (string key in files)
                {
                    HttpPostedFile file = files[key];
                    fileName = key;
                    fileSavePath = uploadFolderPath + "\\" + fileName;

                    try
                    {
                        if (File.Exists(fileSavePath))
                        { File.Delete(fileSavePath); }
                    }
                    catch (Exception ex)
                    {
                    }

                    file.SaveAs(fileSavePath);

                    context.Response.Write(fileName);
                    i++;
                    fileExtension = Path.GetExtension(fileName);
                } // Loop END



            }// End if 

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