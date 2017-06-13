using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using USPDHUBBLL;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Threading;
using System.Net;
using System.IO;
using Aurigma.GraphicsMill.Transforms;

namespace USPDHUB.Business.MyAccount
{
    public partial class BulletinVideoGallery : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public string RootPath = "";


        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommonBLL = new CommonBLL();

        public string VideoSrc = "";
        public static string videoID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ProfileID"] == null)
                {
                    //From Admin Member Information Page
                    if (Request.QueryString["PID"] != null)
                    {
                        Session["ProfileID"] = Convert.ToInt32(Request.QueryString["PID"]);
                        Session["RootPath"] = objCommonBLL.GetConfigSettings(Session["ProfileID"].ToString(), "Paths", "RootPath");
                        Session["UserID"] = Convert.ToInt32(Request.QueryString["UID"]);
                    }
                }

                // *** Get Domain Name *** //

                RootPath = Session["RootPath"].ToString();


                if (Request.QueryString["VideoSrc"] != null)
                {
                    Session["VideoSrc"] = Request.QueryString["VideoSrc"];
                    VideoSrc = Session["VideoSrc"].ToString();
                }
                if (!IsPostBack)
                {
                    string regUrl = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                    string currentLoadImgUrl = string.Empty;
                    Regex r = new Regex(regUrl);
                    MatchCollection results = r.Matches(VideoSrc);
                    foreach (Match m in results)
                    {
                        txtVideoUrl.Text = m.Value.ToString().Replace("?type=video", ""); ;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnVideoSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                //string VideoUrl = txtVideoUrl.Text.Trim();


                //if (VideoUrl.ToLower().Contains("youtube") || VideoUrl.ToLower().Contains("youtu.be"))
                //{
                //    hdnVideoThumbUrl.Value = GetThumbnailFromYoutubeVideo(VideoUrl);
                //}
                //else if (VideoUrl.ToLower().Contains("vimeo"))
                //{
                //    hdnVideoThumbUrl.Value = GetThumbFromVimeo(VideoUrl);
                //}

                videoID = "";
                VideoSrc = txtVideoUrl.Text.Trim();

                if (VideoSrc.ToLower().Contains("vimeo.com"))
                    hdnVideoThumbUrl.Value = GetThumbFromVimeo(VideoSrc);
                else
                    hdnVideoThumbUrl.Value = GetThumbnailFromYoutubeVideo(VideoSrc);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>SubmitVideoThumbUrl('" + hdnVideoThumbUrl.Value + "','" + videoID + "')</script>", false);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "btnVideoSubmit_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [WebMethod]
        public static string GetThumbnailFromYoutubeVideo(string videoUrl)
        {
            try
            {
                string ImgThumbUrl = "";
                string strVideoCode = "";

                if (videoUrl.IndexOf("youtu.be") != -1)
                {
                    strVideoCode = Regex.Match(videoUrl, @"(?:youtube\.com\/(?:[^\/]+\/.+\/|(?:v|e(?:mbed)?)\/|.*[?&amp;]v=)|youtu\.be\/)([^""&amp;?\/ ]{11})").Groups[1].Value;
                    if (strVideoCode == string.Empty)
                    {
                        var ids = videoUrl.Split(new string[] { "youtu.be/" }, StringSplitOptions.None);
                        if (videoUrl.Contains("?v"))
                        {
                            strVideoCode = videoUrl.Substring(videoUrl.IndexOf("?v") + 3);
                            if (strVideoCode.Contains("&"))
                                strVideoCode = strVideoCode.Split('&')[0].ToString();
                        }
                        else
                            strVideoCode = ids[1].ToString();
                    }
                }
                else
                {
                    int mInd = videoUrl.IndexOf("/v/");
                    if (mInd != -1)
                    {
                        strVideoCode = videoUrl.Substring(videoUrl.IndexOf("/v/") + 3);
                        int ind = strVideoCode.IndexOf("?");
                        strVideoCode = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
                        ImgThumbUrl = "https://img.youtube.com/vi/" + strVideoCode + "/hqdefault.jpg";
                    }
                    else
                    {
                        if (videoUrl.Contains("?v"))
                            strVideoCode = videoUrl.Substring(videoUrl.IndexOf("?v") + 3);

                        if (strVideoCode.Contains("?type"))
                            strVideoCode = strVideoCode.Substring(0, strVideoCode.IndexOf("?"));

                        if (strVideoCode.Contains("&t="))
                            strVideoCode = strVideoCode.Substring(0, strVideoCode.IndexOf("&t="));
                    }
                }
                if (strVideoCode != "")
                    ImgThumbUrl = "https://img.youtube.com/vi/" + strVideoCode + "/hqdefault.jpg";


                videoID = strVideoCode;

                #region downloading file


                WebClient client = new WebClient();
                string directoryPath = HttpContext.Current.Server.MapPath("/Upload/CustomModules/" + HttpContext.Current.Session["ProfileID"] + "/YoutubeThumbs");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                string imgExt = ".jpg";
                string ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;

                client.DownloadFile(ImgThumbUrl, directoryPath + "//" + ImageUniqueName);

                //Load background image
                Aurigma.GraphicsMill.Bitmap bitmap =
                    new Aurigma.GraphicsMill.Bitmap(directoryPath + "//" + ImageUniqueName);

                string playBtnImage = HttpContext.Current.Server.MapPath("/Images/play_btn.png");
                //Load small image (foreground image)
                Aurigma.GraphicsMill.Bitmap smallBitmap =
                    new Aurigma.GraphicsMill.Bitmap(playBtnImage);

                //Draw foreground image on background with transparency
                bitmap.Draw(smallBitmap, 220, 160,
                   smallBitmap.Width, smallBitmap.Height,
                    Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, ResizeInterpolationMode.High);

                string mixedImgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;
                bitmap.Save(directoryPath + "//" + mixedImgName);

                try
                {
                    if (File.Exists(directoryPath + "//" + ImageUniqueName))
                        File.Delete(directoryPath + "//" + ImageUniqueName);
                }
                catch (Exception ex)
                {
                    objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "GetThumbnailFromYoutubeVideo()1", ex.Message,
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }

                ImgThumbUrl = HttpContext.Current.Session["RootPath"] + "/Upload/CustomModules/" + HttpContext.Current.Session["ProfileID"] + "/YoutubeThumbs/" + mixedImgName;
                #endregion

                return ImgThumbUrl;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "GetThumbnailFromYoutubeVideo()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return "";
            }
        }

        [WebMethod]
        public static string GetThumbFromVimeo(string id)
        {
            try
            {
                /*
                <thumbnail_small>http://ts.vimeo.com.s3.amazonaws.com/235/662/23566238_100.jpg</thumbnail_small> 
            <thumbnail_medium>http://ts.vimeo.com.s3.amazonaws.com/235/662/23566238_200.jpg</thumbnail_medium> 
            <thumbnail_large>http://ts.vimeo.com.s3.amazonaws.com/235/662/23566238_640.jpg</thumbnail_large> 
           */
                //https://vimeo.com/119144921
                //https://i.vimeocdn.com/video/451480917
                string ImgThumbUrl = "";

                try
                {
                    //if (id.Contains("vimeo.com"))
                    //{
                    //    id = id.Substring(id.IndexOf("vimeo.com") + 10);
                    //}

                    var items = id.Split('/');
                    id = items[items.Length - 1].ToString();

                    id = id.Replace("?type=video", "");
                    //remove ... video/
                    if (id.Contains("/"))
                        id = id.Substring(6);



                    XmlDocument doc = new XmlDocument();
                    doc.Load("https://vimeo.com/api/v2/video/" + id + ".xml");
                    Thread.Sleep(1 * 1000);
                    XmlElement root = doc.DocumentElement;
                    ImgThumbUrl = root.FirstChild.SelectSingleNode("thumbnail_large").ChildNodes[0].Value;

                    /*** https://i.vimeocdn.com/video/451480917.webp?mw=300&mh=200 ***/
                    /*** https://i.vimeocdn.com/video/605544723.webp?mw=960&mh=540 ***/


                    #region downloading file


                    WebClient client = new WebClient();
                    string directoryPath = HttpContext.Current.Server.MapPath("/Upload/CustomModules/" + HttpContext.Current.Session["ProfileID"] + "/YoutubeThumbs");
                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);

                    string imgExt = Path.GetExtension(ImgThumbUrl);
                    string ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;
                    client.DownloadFile(ImgThumbUrl, directoryPath + "//" + ImageUniqueName);

                    //Load background image
                    Aurigma.GraphicsMill.Bitmap bitmap =
                        new Aurigma.GraphicsMill.Bitmap(directoryPath + "//" + ImageUniqueName);

                    string playBtnImage = HttpContext.Current.Server.MapPath("/Images/play_btn.png");
                    //Load small image (foreground image)
                    Aurigma.GraphicsMill.Bitmap smallBitmap =
                        new Aurigma.GraphicsMill.Bitmap(playBtnImage);

                    //Draw foreground image on background with transparency
                    bitmap.Draw(smallBitmap, 280, 200,
                       smallBitmap.Width, smallBitmap.Height,
                        Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, ResizeInterpolationMode.High);

                    string mixedImgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;
                    bitmap.Save(directoryPath + "//" + mixedImgName);

                    try
                    {
                        if (File.Exists(directoryPath + "//" + ImageUniqueName))
                            File.Delete(directoryPath + "//" + ImageUniqueName);
                    }
                    catch (Exception ex)
                    { }

                    ImgThumbUrl = HttpContext.Current.Session["RootPath"] + "/Upload/CustomModules/" + HttpContext.Current.Session["ProfileID"] + "/YoutubeThumbs/" + mixedImgName;
                    #endregion


                }
                catch (Exception ex)
                {
                    objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "GetThumbFromVimeo()", ex.Message,
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
                return ImgThumbUrl;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "GetThumbFromVimeo()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return "";
            }
        }



    }
}