<%@ WebHandler Language="C#" Class="UploadMasterGallery" %>

using System;
using System.Web;
using System.IO;



public class UploadMasterGallery : IHttpHandler
{
    USPDHUBBLL.BusinessBLL objBusinessBLL = new USPDHUBBLL.BusinessBLL();
    
   
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        //context.Response.Expires = -1;
        try
        {
            string ParentType = "";
            string childFolderName = "";
            string RootFolder = "";
            string albumID = "0";
            int PID = 0;
            
            
            if (HttpContext.Current.Request.QueryString["ParentType"] != null)
            {
                ParentType = HttpContext.Current.Request.QueryString["ParentType"].ToString();
            }
            if (HttpContext.Current.Request.QueryString["FolderName"] != null)
            {
                childFolderName = HttpContext.Current.Request.QueryString["FolderName"].ToString();
            }
            if (HttpContext.Current.Request.QueryString["albumID"] != null)
            {
                albumID = HttpContext.Current.Request.QueryString["albumID"].ToString();
            }
            if (HttpContext.Current.Request.QueryString["PID"] != null)
            {
                PID = Convert.ToInt32(HttpContext.Current.Request.QueryString["PID"]);
            } 
            
            if (ParentType == "1")
                RootFolder = HttpContext.Current.Server.MapPath("~/Upload/MasterGallery/") + PID;
            else if (ParentType == "2")
                RootFolder = HttpContext.Current.Server.MapPath("~/Upload/MasterGallery/") + PID + "\\" + childFolderName;

            if (!Directory.Exists(RootFolder))
            {
                Directory.CreateDirectory(RootFolder);
            }
            
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                int i = 1;
                ////  Uploading files to folder
                foreach (string key in files)
                {
                    HttpPostedFile file = files[key];
                    string ImageName = Path.GetFileName(file.FileName);
                    string imgExt = Path.GetExtension(ImageName);
                    string ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + i.ToString() + imgExt;

                    string imgSavePath = RootFolder + "\\" + ImageUniqueName;
                    file.SaveAs(imgSavePath); 
                    i++;
                    objBusinessBLL.InsertGalleryImages(ImageName, ImageUniqueName, "", Convert.ToInt32(albumID), 0, Convert.ToInt32(PID));
                } // Loop END
            }
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