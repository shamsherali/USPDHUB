using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;

namespace USPDHUB.Controls
{
    public partial class HelpControl : System.Web.UI.UserControl
    {
        UtilitiesBLL objutil = new UtilitiesBLL();
        ezSmartSiteWizard objezSmartsite = new ezSmartSiteWizard();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                if (Session["VerticalDomain"] == null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    objCommon.CreateDomainUrl(url);
                }
                DomainName = Convert.ToString(Session["VerticalDomain"]);
                RootPath = Convert.ToString(Session["RootPath"]);
                if (!IsPostBack)
                {
                    GetHelpMenuData();
                    pnlContentCtrl.Style.Add("display", "none");
                    pnlemailCtrl.Style.Add("display", "none");
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["title"]))
                        {
                            int helpId = Convert.ToInt32(Request.QueryString["id"]);
                            string helpTitle = Request.QueryString["title"];
                            GetHelpMenuDataByID(helpId, helpTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void GetHelpMenuDataByID(int helpId, string helpTitle)
        {
            try
            {
                CommonBLL objCommon = new CommonBLL();
                string helpName = objCommon.GetHelpNameByID(helpId);
                if (!string.IsNullOrEmpty(helpName))
                {
                    if (helpTitle == helpName)
                    {
                        string script = string.Format("ModalHelpPopup('{0}', '{1}', '{2}');",
                                                     helpName,
                                                     helpId.ToString(),
                                                     string.Empty);

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
                    }
                }
                RemoveQuery();
            }
            catch (Exception ex)
            {
            }
        }
        private void RemoveQuery()
        {
            try
            {
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                                                    "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("id");
                if (this.Request.QueryString.ToString() != string.Empty)
                {
                    string[] separateURL = this.Request.QueryString.ToString().Split('?');
                    NameValueCollection queryString = HttpUtility.ParseQueryString(separateURL[1]);
                    queryString.Remove("id");
                }
            }
            catch (Exception /*ex*/)
            {

            }
        }
        private void GetHelpMenuData()
        {
            DataTable dtHelpMenus = objezSmartsite.GetHelpMasterMenuItems(false,DomainName);
            int count = 0;
            int rootID = 0;
            string tClientID = TVHelpCtrl.ClientID;
            TVHelpCtrl.Nodes.Clear();
            if (dtHelpMenus.Rows.Count > 0)
            {
                for (int i = 0; i < dtHelpMenus.Rows.Count; i++)
                {
                    int rootMenuID = 0;

                    rootMenuID = Convert.ToInt32(dtHelpMenus.Rows[i]["Help_ID"].ToString());
                    string[,] parentNode = new string[100, 2];
                    parentNode[count, 0] = dtHelpMenus.Rows[i]["Help_ID"].ToString();
                    parentNode[count++, 1] = dtHelpMenus.Rows[i]["Help_Name"].ToString();
                    TreeNode root = new TreeNode();
                    root.Text = parentNode[i, 1];
                    root.NavigateUrl = "javascript:TreeView_ToggleNode(" + tClientID + "_Data," + rootID + ",document.getElementById('" + tClientID + "n" + rootID + "'),' ',document.getElementById('" + tClientID + "n" + rootID + "Nodes'));";

                    DataTable dtChildMenus = objezSmartsite.GetHelpChildMenuForMasterID(rootMenuID);
                    if (dtChildMenus.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtChildMenus.Rows.Count; k++)
                        {
                            string childMenuID = string.Empty;
                            string childMenuName = string.Empty;
                            childMenuID = dtChildMenus.Rows[k]["Help_ID"].ToString();
                            childMenuName = dtChildMenus.Rows[k]["Help_Name"].ToString();
                            string helpcontent = dtChildMenus.Rows[k]["Help_Content"].ToString();
                            string helpvideoname = dtChildMenus.Rows[k]["Video_File"].ToString();
                            string helpvideo = string.Empty;
                            if (helpvideoname != "")
                            {
                                helpvideo = "<embed src='" + RootPath + "/mediaplayer.swf' width='320' height='220' allowscriptaccess='always' allowfullscreen='true' flashvars='width=320&height=220&file=" + RootPath + "/HelpVideos/" + childMenuID + "/" + helpvideoname + "'></embed>";
                            }
                            childMenuName = childMenuName.Replace("'", "\\'");
                            helpcontent = helpcontent.Replace("'", "\\'");
                            helpvideo = helpvideo.Replace("'", "\\'");
                            TreeNode child = new TreeNode();
                            child.Text = dtChildMenus.Rows[k]["Help_Name"].ToString();
                            child.NavigateUrl = "javascript:ModalHelpPopup('" + childMenuName + "'," + childMenuID + ",'" + helpvideo + "')";
                            root.ChildNodes.Add(child);
                        }
                        rootID = rootID + dtChildMenus.Rows.Count + 1;
                    }
                    TVHelpCtrl.Nodes.Add(root);
                }
                TVHelpCtrl.CollapseAll();
            }
            else
                lblNoHelpCtrl.Text = Resources.LabelMessages.ComingSoon;
        }
        protected void btnsendCtrl_Click(object sender, EventArgs e)
        {
            if (txtemailCtrl.Text.Length > 0)
            {
                SendHelpGidemail();
                lblhelpmsgCtrl.Text = "Email has been sent successfully.";
            }
            ScriptManager.RegisterClientScriptBlock(btnsendCtrl, this.GetType(), "ClientScriptFunction", "displayemailpanel(1)", true);
        }
        protected void SendHelpGidemail()
        {
            string subject = "Help Text";
            string msg = string.Empty;
            string toEmail = txtemailCtrl.Text;
            string videotext = string.Empty;
            string helpid = string.Empty;
            string senderEmail = "";
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        senderEmail = row[1].ToString();
                }
            }
            if (Session["HelpID"] != null)
                helpid = Session["HelpID"].ToString();
            if (hdnhelpvideoCtrl.Value.Length > 0)
                videotext = @"<br/>Looking for demonstration? " + "<a href='" + RootPath + "/Helpvideo.aspx?VID=" + helpid + "' target=_blank>Click here</a> to watch the video.<br/>";
            string helpText = hdnhelpTextCtrl.Value.Replace("&lt;", "<");
            helpText = helpText.Replace("&gt;", ">");
            msg = @"<html><head>   </head><body>
                    <table width='750px' border='0' cellspacing='0' cellpadding='0' align='center' style='border: solid 2px #F4EBEB;'>
                    <tr><td style='padding-left: 10px;'> <b>" + hdnhelpnameCtrl.Value + @"</b><br/></td></tr>
                    <tr><td colspan='2' style='padding:30px; border-bottom: solid 1px #F4EBEB;'>" + helpText + videotext + @"
                    </td></tr>
                    <tr style='color:#B3B3B3;'><td style='padding-left: 10px;'><strong style='color: #0071B3'>
                      Disclaimer Notice:</strong><br><br>
                      This email and its attachments may be confidential and are intended solely for the use of the individual to whom it is addressed.
                     Any views or opinions expressed are solely those of the author and do not necessarily represent those of USPDhub.com.                     
                     If you are not the intended recipient of this email and its attachments, 
                       you must take no action based upon them nor must you copy or show them to anyone.<br><br>
                       Please contact <u style='color: #0071B3'>info@uspdhub.com</u>  
                      if you believe you have received this email in error and you would like to be taken off our email list.</td></tr>
                   </table></body></html>";
            objutil.SendWowzzyEmail(senderEmail, toEmail, subject, msg, "", "", DomainName);
            txtemailCtrl.Text = "";
        }
        protected void lnkHelpDownloadCtrl_OnClick(object sender, EventArgs e)
        {
            int helpID = Convert.ToInt32(hdnhelpIDCtrl.Value);
            string filename = "";
            DataTable dthelpdetails;
            try
            {
                dthelpdetails = objezSmartsite.GetHelpmenuDetailsbyHelpID(helpID);
                filename = dthelpdetails.Rows[0]["Pdf_Name"].ToString();
                string path = Server.MapPath("~/HelpDownloads/" + filename);
                Response.AppendHeader("content-disposition", "attachment; filename=" + filename.Replace("Quick", ""));
                Response.ContentType = "Application/pdf";
                Response.WriteFile(path);
                Response.End();
            }
            catch (Exception /*ex*/)
            {

            }
        }
        protected void btnHelpSearchCtrl_Click(object sender, EventArgs e)
        {
            int helpCount = 0;
            if (string.IsNullOrEmpty(txtHelpSearch.Text))
            {
                foreach (TreeNode node in TVHelpCtrl.Nodes)
                {
                    foreach (TreeNode childnode in node.ChildNodes)
                    {
                        node.Expanded = false;
                        childnode.Text = childnode.Text.Replace("<p style='background-color:#CCE6FF; padding: 4px 0px;'>", "").Replace("</p>", "");
                    }
                }
            }
            CommonBLL objCommon = new CommonBLL();
            List<string> HelpResult = new List<string>();
            hdnhelpKeywordCtrl.Value = txtHelpSearch.Text;
            HelpResult = objCommon.GetHelpSearchDetails(txtHelpSearch.Text.Trim(), false);
            foreach (TreeNode node in TVHelpCtrl.Nodes)
            {
                foreach (TreeNode childnode in node.ChildNodes)
                {
                    if (HelpResult.Contains(childnode.Text))
                    {
                        node.Expanded = true;
                        childnode.Text = "<p class='helphighlights'>" + childnode.Text + "</p>";
                        helpCount += 1;
                    }
                    else
                        childnode.Text = childnode.Text.Replace("<p class='helphighlights'>", "").Replace("</p>", "");
                }
            }
            if (helpCount == 0)
            {
                TVHelpCtrl.CollapseAll();
                lblNoHelpMsgCtrl.Text = "We couldn't find any results.";
            }
            else
                lblNoHelpMsgCtrl.Text = "";
            pnlGuideCtrl.Style.Add("display", "inline");
            pnlemailCtrl.Style.Add("display", "none");
        }
        protected void btnHelpClearCtrl_Click(object sender, EventArgs e)
        {
            txtHelpSearch.Text = "";
            GetHelpMenuData();
            lblNoHelpMsgCtrl.Text = "";
        }
    }
}