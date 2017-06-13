<%@ WebHandler Language="C#" Class="UploadImages" %> 

using System;
using System.Web;
using System.IO;


public class UploadImages : IHttpHandler
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

            string uploadFolderPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString();
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
                    break;

                    // END
                } // Loop END


                string rsizeimagepath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + "Templates" + "\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + "\\" + fileName;

                if (fileExtension == ".jpg" || fileExtension == ".JPG" || fileExtension == ".JPEG"
                    || fileExtension == ".jpeg" || fileExtension == ".GIF" || fileExtension == ".gif"
                    || fileExtension == ".png" || fileExtension == ".PNG")
                {
                    int width = 0;
                    int height = 0;
                    using (FileStream fs = new FileStream(fileSavePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                        width = image.Width;
                        height = image.Height;
                    }
                    GC.Collect();
                    if (width >= 300)
                    {
                        Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                        uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(fileSavePath);
                        Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                        actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                        actResize.Width = Convert.ToInt32(300);
                        uploadedImage.Actions.Add(actResize);
                        Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                        imgDraw.Elements.Add(uploadedImage);
                        imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                        imgDraw.JpegCompressionLevel = 100;

                        imgDraw.Save(rsizeimagepath);
                        imgDraw.Dispose();
                    }
                    else
                    {
                        context.Request.Files[0].SaveAs(rsizeimagepath);
                    }
                    GC.Collect();
                }

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