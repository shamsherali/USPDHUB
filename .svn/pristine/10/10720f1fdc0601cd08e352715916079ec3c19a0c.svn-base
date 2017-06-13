using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.IO;

namespace USPDHUB.ProfileIframes
{
    public partial class DataFeedsPreview : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public string RootPath = "";
        public string FeedsType = "";
        string outerURL = "";

        public USPDHUBBLL.AgencyBLL objAgencyBLL = new USPDHUBBLL.AgencyBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        MServiceBLL objMServiceBLL = new MServiceBLL();

        public DataTable dtDataFeeds = new DataTable();
        public int moduleID = 0;

        string fontsize = "12";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["rssmikle_id"] != null)
            {
                if (Request.QueryString["rssmikle_id"].ToString() != "")
                {
                    ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["rssmikle_id"].ToString()));
                }
                if (Request.QueryString["rssmikle_feedtype"].ToString() != "")
                {
                    FeedsType = Convert.ToString(Request.QueryString["rssmikle_feedtype"].ToString());
                }

                try
                {
                    string[] feedTypeArray = FeedsType.Split(new string[] { "|SP|" }, StringSplitOptions.None);
                    string[] moduleName = feedTypeArray[0].Split(','); // *** tab name, below 2.0 it is module name, for 2.0 it is changed name that doesn't relect along with web *** //
                    string contetnTitle = feedTypeArray[0];
                    if (feedTypeArray.Length > 1)
                    {
                        moduleName = feedTypeArray[1].Split(',');
                        if (moduleName.Length > 1) // *** from 2.1 it reflects with web *** //
                        {
                            DataTable dtAddOn = objAddOn.GetAddOnById(Convert.ToInt32(moduleName[1]));
                            moduleID = Convert.ToInt32(moduleName[1]);
                            if (dtAddOn.Rows.Count > 0)
                                contetnTitle = Convert.ToString(dtAddOn.Rows[0]["TabName"]);
                        }
                    }
                    lblTitle.Text = contetnTitle;

                    hdnTarget.Value = Request.QueryString["rssmikle_target"].ToString();
                    StringBuilder strBuilder = new StringBuilder("<style type='text/css'> body{margin:0;padding:0;overflow-x:hidden;}");
                    strBuilder.Append("#container{");
                    if (Request.QueryString["corner"] != null && Request.QueryString["corner"].ToString() == "on")
                        strBuilder.Append("border-radius:10px;");
                    if (Request.QueryString["rssmikle_font_size"] != null)
                        fontsize = Request.QueryString["rssmikle_font_size"].ToString();

                    strBuilder.Append("overflow:hidden;margin:0;padding:0;width:" + Convert.ToInt32(Request.QueryString["rssmikle_frame_width"].ToString()) + "px;height:" + Request.QueryString["rssmikle_frame_height"].ToString() + "px;font-family:" + Request.QueryString["rssmikle_font"].ToString() + ";font-size:" + fontsize + "px;border:1px solid #CCCCCC;}");
                    strBuilder.Append("#header{margin:0px;padding:5px 5px 5px 5px;color:" + Request.QueryString["rssmikle_title_color"].ToString() + ";background-color:" + Request.QueryString["rssmikle_title_bgcolor"].ToString() + ";background-image:none;}");
                    strBuilder.Append("#header .feed_title{margin:0;padding:0;font-weight:bold;}");
                    strBuilder.Append("#header .feed_title a:link{color:" + Request.QueryString["rssmikle_title_color"].ToString() + ";text-decoration:none;}");
                    strBuilder.Append("#header .feed_title a:visited{color:" + Request.QueryString["rssmikle_title_color"].ToString() + ";text-decoration:none;}");
                    strBuilder.Append("#header .feed_title a:hover{color:" + Request.QueryString["rssmikle_title_color"].ToString() + ";text-decoration:underline;}");
                    strBuilder.Append("#header .feed_title a:active{color:" + Request.QueryString["rssmikle_title_color"].ToString() + ";text-decoration:none;}");
                    strBuilder.Append("#content{overflow:hidden;margin:0px;padding:5px 0px 0px 0px;background-color:" + Request.QueryString["rssmikle_item_bgcolor"].ToString() + ";background-image:none; height:" + (Convert.ToInt32(Request.QueryString["rssmikle_frame_height"].ToString()) - 30) + "px;}");
                    strBuilder.Append("#content .feed_item{margin:0 0 7px 0;padding:0 7px 7px 0;");
                    if (Request.QueryString["rssmikle_item_border_bottom"] != null && Request.QueryString["rssmikle_item_border_bottom"].ToString() == "on")
                        strBuilder.Append("border-bottom:1px dashed #CCCCCC;}");
                    else
                        strBuilder.Append("}");
                    strBuilder.Append("#content .feed_item_title{margin:1px 0 1px 3px;padding:1px 2px 1px 3px;color:" + Request.QueryString["rssmikle_item_title_color"].ToString() + ";font-weight:bold;}");
                    strBuilder.Append("#content .feed_item_title a:link{color:" + Request.QueryString["rssmikle_item_title_color"].ToString() + ";text-decoration:none;}");
                    strBuilder.Append("#content .feed_item_title a:visited{color:" + Request.QueryString["rssmikle_item_title_color"].ToString() + ";text-decoration:none;}");
                    strBuilder.Append("#content .feed_item_title a:hover{color:" + Request.QueryString["rssmikle_item_title_color"].ToString() + ";text-decoration:underline;}");
                    strBuilder.Append("#content .feed_item_title a:active{color:" + Request.QueryString["rssmikle_item_title_color"].ToString() + ";text-decoration:none;}");
                    strBuilder.Append("#content .feed_item_description{margin:0 0 0 3px;padding:0 2px 0 3px;color:" + Request.QueryString["rssmikle_item_description_color"].ToString() + ";line-height:135%;}");
                    strBuilder.Append("</style>");
                    LiteralControl ltrcss = new LiteralControl(strBuilder.ToString());
                    ltrcss.ID = "ltdCss";
                    Page.Header.Controls.Add(ltrcss);
                    if (!IsPostBack)
                    {
                        dtDataFeeds = objAgencyBLL.GetDataFeeds(ProfileID, feedTypeArray.Length > 1 ? feedTypeArray[1].Split(',')[0] : moduleName[0].ToUpper(), moduleID);
                        outerURL = objMServiceBLL.GetConfigSettings(Convert.ToString(ProfileID), "Paths", "RootPath");
                        string ViewUrl = "";

                        if (moduleName[0].ToLower() == "updates")
                            ViewUrl = outerURL + "/OnlineUpdate.aspx?TID=";
                        if (moduleName[0].ToLower() == "bulletins")
                            ViewUrl = outerURL + "/OnlineBulletin.aspx?TID=";
                        if (moduleName[0].ToLower() == "eventcalendar")
                            ViewUrl = outerURL + "/OnlineEvent.aspx?TID=";
                        if (moduleName[0] == "AddOn")
                            ViewUrl = outerURL + "/OnlineItem.aspx?TID=";
                        if (moduleName[0] == WebConstants.Tab_CalendarAddOns)
                            ViewUrl = outerURL + "/OnlineCalendar.aspx?TID=";

                        for (int i = 0; i < dtDataFeeds.Rows.Count; i++)
                        {
                            string htmlDescription = Convert.ToString(dtDataFeeds.Rows[i]["HtmlDescription"]);
                            htmlDescription = htmlDescription.Replace("<A href=\"http://tr\" target=_blank></A>&nbsp;", "");
                            htmlDescription = System.Text.RegularExpressions.Regex.Replace(htmlDescription, "<[^>]*>", string.Empty);

                            if (moduleName[0].ToLower() == "bulletins" || moduleName[0].ToLower() == "addon")
                            {
                                htmlDescription = ""; // *** don't show the thumbnail or content for bulletins as they are forms *** //
                                //string imgThumbPath = outerURL + "/Upload/Bulletins/" + ProfileID + "/" + dtDataFeeds.Rows[i]["ID"].ToString() + ".jpg";
                                //string bulletinLink = outerURL + "/viewBulletin.aspx?SID=" + EncryptDecrypt.DESEncrypt(dtDataFeeds.Rows[i]["ID"].ToString());
                                //htmlDescription = "<a border='0' href='" + bulletinLink + "' target='_new' ><img border='0' src='" + imgThumbPath + "' /> </a>";
                            }
                            if (moduleName[0].ToLower() == "eventcalendar" || moduleName[0].ToLower() == WebConstants.Tab_CalendarAddOns.ToLower())
                            {
                                dtDataFeeds.Rows[i]["ModifiedDate"] = Convert.ToDateTime(dtDataFeeds.Rows[i]["StartDate"]).ToString("MM/dd/yyyy hh:mm tt") + " to " + Convert.ToDateTime(dtDataFeeds.Rows[i]["EndDate"]).ToString("MM/dd/yyyy hh:mm tt");
                            }
                            else
                                dtDataFeeds.Rows[i]["ModifiedDate"] = Convert.ToDateTime(dtDataFeeds.Rows[i]["ModifyDate"]).ToString("MM/dd/yyyy hh:mm tt");
                            if (htmlDescription.Length > 200)
                                htmlDescription = htmlDescription.Substring(0, Math.Min(htmlDescription.Length, 200)) + "...";
                            dtDataFeeds.Rows[i]["HtmlDescription"] = htmlDescription;
                            dtDataFeeds.Rows[i]["URL"] = ViewUrl + EncryptDecrypt.DESEncrypt(dtDataFeeds.Rows[i]["ID"].ToString());
                        }//end For

                        DLDataFeeds.DataSource = dtDataFeeds;
                        DLDataFeeds.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    /*** Error Log ***/
                    objInBuiltData.ErrorHandling("ERROR", "DataFeedsPreview.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }


            }
        }
    }
}