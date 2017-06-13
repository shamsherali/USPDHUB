using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Aurigma.GraphicsMill;
using Aurigma.GraphicsMill.AdvancedDrawing;
using Aurigma.GraphicsMill.AdvancedDrawing.Art;
using Aurigma.GraphicsMill.Codecs;
using System.Text.RegularExpressions;
using Aurigma.GraphicsMill.Transforms;
using System.IO;
using System.Drawing;
using UserFormsBLL;

namespace UserForms
{
    public class Utilities
    {
        internal string DrawRotatedTextWatermark(string txtApprehend)
        {
            string locatedImgName = string.Empty;
            string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");
            string text = txtApprehend;
            if (string.IsNullOrEmpty(text))
            {
                text = "Apprehended";
            }
        
            using (var bitmap = new Aurigma.GraphicsMill.Bitmap(158, 161, Aurigma.GraphicsMill.PixelFormat.Format32bppArgb, Aurigma.GraphicsMill.RgbColor.Transparent))
            using (var graphics = bitmap.GetAdvancedGraphics())
            {
                using (var m = new System.Drawing.Drawing2D.Matrix())
                {
                    m.Rotate(-45); 

                    var plainText = new Aurigma.GraphicsMill.AdvancedDrawing.PlainText(txtApprehend, graphics.CreateFont("Arial", "Bold",26), 
                        new Aurigma.GraphicsMill.AdvancedDrawing.SolidBrush(System.Drawing.Color.Red),
                         new System.Drawing.PointF(10, 125));
                    plainText.Transform = m;
                    plainText.Pen = new Aurigma.GraphicsMill.AdvancedDrawing.Pen(Aurigma.GraphicsMill.RgbColor.White, 1);
                    plainText.Alignment = TextAlignment.Center; 
                    graphics.DrawText(plainText);

                    string LocatedImageFolder = uspdVirtualFolder + "/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                    if (!Directory.Exists(LocatedImageFolder))
                    {
                        Directory.CreateDirectory(LocatedImageFolder);
                    }

                    locatedImgName = "located_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";

                    bitmap.Save(LocatedImageFolder + "\\" + locatedImgName);


                    string imgPath = HttpContext.Current.Session["RootPath"].ToString() + "/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]) + "/" + locatedImgName;
                    //htmlString = htmlString.Replace("#LocatedImage#", imgPath);

                    //htmlString = CommonBLL.BuildLocatedImage_Dynamically(htmlString, locatedImgName);
                }
            }

            return locatedImgName;
        }
       
        
        internal string BuildLocatedImage(string htmlString, string imgname = "")
        {
            string imagePath = "";
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
            MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                imagePath = m.Groups[1].Value;
                if (imagePath.ToLower().Contains(imgname))
                {
                    imagePath = "";
                }
                else
                {
                    if (!imagePath.ToLower().Contains("upload/logos"))
                    { break; }
                      
                }
            }

            // Without image time Means Only Text
            if (imagePath.Trim() == string.Empty)
            {

            }
            else
            {
                string uspdUploadFolderPath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "/Upload"; ;

                string imgName = System.IO.Path.GetFileName(imagePath);
                string imgExt = System.IO.Path.GetExtension(imgName).ToLower();
                string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(imagePath);

                string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                FOlderPath = FOlderPath.Replace("upload", "");
                string olgImgPath = uspdUploadFolderPath + FOlderPath;


                string dateValue = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string newImgPath = olgImgPath.Replace(filenameWithoutExt.ToLower(), filenameWithoutExt.ToLower() + "_" + dateValue);
                try
                {
                    if (File.Exists(newImgPath))
                    { File.Delete(newImgPath); }

                }
                catch
                { }

                if (!File.Exists(newImgPath))
                {

                    string locatedImage = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "/Upload/LocatedImages/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                    locatedImage = locatedImage + "\\" + imgname;

                    if (olgImgPath.Contains('?'))
                        olgImgPath = olgImgPath.Substring(0, olgImgPath.LastIndexOf('?'));

                    try
                    {
                        //Load background image
                        Aurigma.GraphicsMill.Bitmap bitmap =
                            new Aurigma.GraphicsMill.Bitmap(olgImgPath);
                        int orgImgWidth = bitmap.Width;
                        int orgImgHeight = bitmap.Height;
                        //Load small image (foreground image)
                        Aurigma.GraphicsMill.Bitmap smallBitmap =
                            new Aurigma.GraphicsMill.Bitmap(locatedImage);

                        int newImgWidth = smallBitmap.Width;
                        int newImgHeight = smallBitmap.Height;
                        int locatedX = (orgImgWidth - newImgWidth) / 2;
                        int locatedY = (orgImgHeight - newImgHeight) / 2;

                        //Draw foreground image on background with transparency
                        bitmap.Draw(smallBitmap, locatedX, locatedY,
                           smallBitmap.Width, smallBitmap.Height,
                            Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, Aurigma.GraphicsMill.Transforms.ResizeInterpolationMode.High);

                        if (newImgPath.Contains('?'))
                            newImgPath = newImgPath.Substring(0, newImgPath.LastIndexOf('?'));


                        bitmap.Save(newImgPath);
                    }
                    catch (Exception ex)
                    {
                        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                        //Error 
                        objInBuiltData.ErrorHandling("ERROR", "Utilities.cs", "BuildLocatedImage", ex.Message,
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                    }

                    htmlString = htmlString.Replace(filenameWithoutExt, filenameWithoutExt + "_" + dateValue);
                }
            }
            return htmlString;
        }
        //public static string DrawRotatedTextWatermark(string txtApprehend)
        //{

        //}

        //public static string BuildLocatedImage_Dynamically(string htmlString, string imgname = "")
        //{

        //}
    }
}