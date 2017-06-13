<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;


public class Handler : IHttpHandler
{

    string filename = "";
    string pProfileID = "";

    public void ProcessRequest(HttpContext context)
    {
        filename = context.Request.QueryString["PhotoCaption"].ToString();
        pProfileID = context.Request.QueryString["PID"].ToString();

        string uploadFilePath = System.Configuration.ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "/Upload/DevicePhotos/" + pProfileID;
        //string uploadFilePath = context.Server.MapPath("~/Upload/DevicePhotos/" + pProfileID);
        if (!Directory.Exists(uploadFilePath))
        {
            Directory.CreateDirectory(uploadFilePath);
        }

        if (!File.Exists(uploadFilePath + filename))
        {
            using (FileStream fs = File.Create(uploadFilePath + "\\" + filename))
            {
                SaveFile(context.Request.Files[0].InputStream, fs);
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
        }
    }

    private void SaveFile(Stream stream, FileStream fs)
    {
        byte[] buffer = new byte[4096];
        int bytesRead;
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            fs.Write(buffer, 0, bytesRead);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


    //this function is reqd for thumbnail creation
    public bool ThumbnailCallback()
    {
        return false;
    }

}


