using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Xml;
using System.Threading;
using System.Web.Script.Services;

namespace USPDHUB.Business.MyAccount
{
    public partial class HowToVideos : BaseWeb
    {
        public string RootPath = "";
        public string StrNoItemsFoundMSG = "";
     
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNoHelpMsg.Text = "";
            string msg = txtVideoSearch.Text;
            RootPath = Session["RootPath"].ToString();
           
            StrNoItemsFoundMSG = Resources.LabelMessages.NotFoundSearchHelpVideo; ;
            //Hidden1.Value = LblMsg;
            if (!IsPostBack)
            {
                LoadCustomers("");
                //string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                //ScriptManager.RegisterStartupScript(btnSubmit, this.GetType(), "load", script, true);
            }
        }
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    // Add Fake Delay to simulate long running process.
        //    Button btnSearch = sender as Button;
        //    LoadCustomers(btnSearch.CommandName);
        //}
        private void LoadCustomers(string commandName)
        {
            try
            {
                CommonBLL objVideos = new CommonBLL();
                DataTable dt = new DataTable();
                //   dt = objVideos.GetAllVideos(txtVideoSearch.Text.Trim(), Convert.ToString(Session["VerticalDomain"]));
                //   dlVideos.DataSource = dt;
                //   dlVideos.DataBind();
                //if (dt.Rows.Count == 0 && commandName == "Search")
                //    lblNoHelpMsg.Text = Resources.LabelMessages.NotFoundSearchHelpVideo.Replace("##SearchHelpVideo##", txtVideoSearch.Text.Trim());

            }
            catch (Exception ex)
            {
            }
        }

        protected void dlVideos_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblThumbnailUrl = e.Item.FindControl("lblThumbnailUrl") as Label;
            string thumbUrl = RootPath + "/Upload/HowToVideosThumbs/" + lblThumbnailUrl.Text.Trim(); //GetThumbFromVimeo(lblThumbnailUrl.Text);
            lblThumbnailUrl.Text = "<IMG src='" + thumbUrl + "' />";
        }
        public string GetThumbFromVimeo(string id)
        {
            /*
            <thumbnail_small>http://ts.vimeo.com.s3.amazonaws.com/235/662/23566238_100.jpg</thumbnail_small> 
        <thumbnail_medium>http://ts.vimeo.com.s3.amazonaws.com/235/662/23566238_200.jpg</thumbnail_medium> 
        <thumbnail_large>http://ts.vimeo.com.s3.amazonaws.com/235/662/23566238_640.jpg</thumbnail_large> 
       */
            //https://vimeo.com/119144921
            string ImgThumbUrl = "";

            try
            {
                if (id.Contains("vimeo.com"))
                {
                    id = id.Substring(id.IndexOf("vimeo.com") + 10);
                }

                XmlDocument doc = new XmlDocument();
                doc.Load("https://vimeo.com/api/v2/video/" + id + ".xml");

                XmlElement root = doc.DocumentElement;
                ImgThumbUrl = root.FirstChild.SelectSingleNode("thumbnail_large").ChildNodes[0].Value;

            }
            catch (Exception ex)
            { }
            return ImgThumbUrl;

        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetHelpVideoName(string pre)
        {
            List<string> allCompanyName = new List<string>();
            return allCompanyName;
        }
        [System.Web.Services.WebMethod]
        public static string InsertViewData(string videoId)
        {
            CommonBLL objCommonBll = new CommonBLL();
            string _result = "";
            if (HttpContext.Current.Session["ProfileID"] != null)
            {
                int profileId = Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString());
                objCommonBll.InsertHelpVideoViews(Convert.ToInt32(videoId), profileId);
            }
            else
                _result = "No Session";
            return _result;
        }

        // Lazy loading for video
        [System.Web.Services.WebMethod(EnableSession = true)]

        public static VideoDetails[] BindVideosData(string Start, string End, string Search)
        {
            CommonBLL objCommonBLL = new CommonBLL();
            DataTable dtActivityLogs = new DataTable();
            List<VideoDetails> details = new List<VideoDetails>();
            CommonBLL objVideos = new CommonBLL();
            DataTable dt = new DataTable();
            string domain = "";
            string isLiteVersion="";
       

            if (HttpContext.Current.Session["VerticalDomain"] != null)
                domain = HttpContext.Current.Session["VerticalDomain"].ToString();
            isLiteVersion = HttpContext.Current.Session["isLiteVersion"].ToString();
            dt = objVideos.GetAllVideos(Search, domain, int.Parse(Start), int.Parse(End),isLiteVersion);

            foreach (DataRow dtrow in dt.Rows)
            {
                VideoDetails user = new VideoDetails();
                user.Url = dtrow["Url"].ToString();
                user.VideoID = dtrow["VideoID"].ToString();
                user.Thumb_Url = HttpContext.Current.Session["RootPath"].ToString() + "/Upload/HowToVideosThumbs/" + dtrow["Thumb_Url"].ToString();
                user.Title = dtrow["Title"].ToString();
                user.TotalVideoCount = dtrow["TotalVideoCount"].ToString();
                details.Add(user);
            }


            return details.ToArray();

        }

        public class VideoDetails
        {
            public string Url { get; set; }
            public string VideoID { get; set; }
            public string Thumb_Url { get; set; }
            public string Title { get; set; }
            public string TotalVideoCount { get; set; }

        }

    }
}