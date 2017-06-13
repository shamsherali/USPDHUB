using System;
using System.Data;
using System.Web.Services;
using System.Collections.Generic;

namespace UserFormsBLL
{
    public class BaseWeb : System.Web.UI.Page
    {
        private bool isRefresh1 = false;
        private string messagetype1;
        private string messagetitle1;
        private string messageDesc;

        public const string SuccessMessage = "S";
        public const string ErrorMessage = "E";
        public const string InsertMessageHeading = "Error while Inserting";
        public const string DeleteMessageHeading = "Error while Deleting";
        public const string UpdateMessageHeading = "Error while Updating";

        public BaseWeb()
        {
            messagetype1 = SuccessMessage;
            messagetitle1 = "";
            messageDesc = "";
        }


        public bool IsRefresh
        {
            get
            {
                return isRefresh1;
            }
            set
            {
                isRefresh1 = value;
            }
        }

        public string Messagetype
        {
            get
            {
                return messagetype1;
            }
            set
            {
                messagetype1 = value;
            }
        }

        public string Messagetitle
        {
            get
            {
                return messagetitle1;
            }
            set
            {
                messagetitle1 = value;
            }
        }

        public string Messagedescription
        {
            get
            {
                return messageDesc;
            }
            set
            {
                messageDesc = value;
            }
        }



        public void ShowResultsMessage(string messageType, string messageTitle, Exception exp)
        {
            string messageDescription = exp.Message;

            ShowResultsMessage(messageTitle, messageTitle, messageDescription);
        }

        public void ShowResultsMessage(string messageType, string messageTitle, string strMessage)
        {
            string messageDescription = strMessage;
            messageDescription = messageDescription.Replace("'", "\"");
            messageDescription = messageDescription.Replace("\n", "");
            messageDescription = messageDescription.Replace("\r", "");

            messagetype1 = messageType;
            messagetitle1 = messageTitle;
            messageDesc = messageDescription.Replace("'", "\"");
            string strMsg;
            strMsg = "<script language=javascript>var strMessage_type;var strMessage_title;var strMessage_Desc;" +
                " strMessage_type = '" + messageType + "';" +
                " strMessage_title = '" + messageTitle + "';" +
                " strMessage_Desc = '" + messageDescription + "';</script>";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MsgScript", strMsg);
        }

        public string GetUniversalDate(string date)
        {
            return date;
        }


        [WebMethod]
        public static string GetHelpcontentbyHelpID(string helpID)
        {
            string helpcontent = string.Empty;
            string helpName = string.Empty;
            CommonBLL objCommon = new CommonBLL();
            DataTable dthelpdetails = objCommon.GetHelpmenuDetailsbyHelpID(int.Parse(helpID));
            if (dthelpdetails.Rows.Count > 0)
            {
                helpcontent = dthelpdetails.Rows[0]["Help_Content"].ToString();
                helpName = dthelpdetails.Rows[0]["Help_Name"].ToString();
                helpcontent = "<div>" + helpcontent + "</div>";
                System.Web.HttpContext.Current.Session["HelpID"] = helpID;
                System.Web.HttpContext.Current.Session["HelpName"] = helpName;
                System.Web.HttpContext.Current.Session["HelpText"] = helpcontent;
                if (dthelpdetails.Rows[0]["Video_File"].ToString() != "")
                {
                    string helpvideoname = dthelpdetails.Rows[0]["Video_File"].ToString();
                    string helpvideo = string.Empty;
                    if (helpvideoname != "")
                    {
                        helpvideo = "<embed src='../../mediaplayer.swf' width='320' height='220' allowscriptaccess='always' allowfullscreen='true' flashvars='width=320&height=220&file=HelpVideos/" + helpID + "/" + helpvideoname + "'></embed>";
                    }
                    System.Web.HttpContext.Current.Session["Helpvideo"] = helpvideo;
                }
                else
                {
                    System.Web.HttpContext.Current.Session["Helpvideo"] = null;
                }
            }
            return helpcontent;
        }

        [WebMethod]
        public static List<string> GetHelpItems(string prefixText)
        {
            CommonBLL objCommon = new CommonBLL();
            List<string> HelpResult = new List<string>();
            try
            {
                HelpResult = objCommon.GetHelpSearchDetails(prefixText, false);
            }
            catch (Exception HelpSearchException)
            {
                throw new Exception(HelpSearchException.Message);
            }
            return HelpResult;
        }
    }
}
