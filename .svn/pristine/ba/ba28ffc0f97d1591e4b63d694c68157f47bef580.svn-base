using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;
using UserFormsBLL;
using System.Web;

namespace UserForms
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        BusinessBLL busobj = new BusinessBLL();
        public int UserID = 0;
        public int EzMenuvalidate = 0;
        public int ProfileID = 0;
        string useremail = string.Empty;
        string senderEmail = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;
        public string Dburl = string.Empty;
        public string Checkdburl = string.Empty;
        public string Profilename = string.Empty;
        public bool IsTraining = false;
        public bool IsCompleted = true;
        public string LogoName = "";
        public DataTable Dtpermissions = new DataTable();
        CommonBLL commonBll = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";

        public bool IsManageLogins = false;
        public bool IsSocial = false;
        public bool IsContact = false;
        public bool IsAppDiplayCustomization = false;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Convert.ToString(Session["UserID"]) == "" || Session["VerticalDomain"] == null)
            {
                Response.Redirect(Page.ResolveClientUrl("~/Default.aspx?sflag=1"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            Session["RoleID"] = (int)UtilitiesBLL.RoleTypes.Business;
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                DomainName = commonBll.CreateDomainUrl(url);
            }
            Dburl = Request.Url.ToString();
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            Checkdburl = RootPath + "/Business/MyAccount/Default.aspx";
            lblgmsg.Text = "";

            if (Session["UserID"] == null || Session["ProfileID"] == null)
            {
                Response.Redirect(Checkdburl);
            }
            if (Session["ProfileID"].ToString() != "")
            {
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                //Store Module Functionality
                if (busobj.CheckModulePermission(WebConstants.Purchase_ManageLoginsSetup, ProfileID))
                {
                    IsManageLogins = true;
                }

                if (busobj.CheckModulePermission(WebConstants.Purchase_SocialMediaAutoPostSetup, ProfileID))
                {
                    IsSocial = true;
                }
                if (busobj.CheckModulePermission(WebConstants.Purchase_Contacts_Reports, ProfileID))
                {
                    IsContact = true;
                }
                if (busobj.CheckModulePermission(WebConstants.Purchase_AppDisplayCustomizationSetup, ProfileID))
                {
                    IsAppDiplayCustomization = true;
                }
            }

            if (!IsPostBack)
            {
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = commonBll.GetVerticalConfigsByType(DomainName, "DashboardKeys");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    HtmlMeta htmlMeta = new HtmlMeta();
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "Title")
                            this.Page.Title = row[1].ToString();
                        else if (row[0].ToString() == "author")
                            htmlMeta.Attributes.Add("author", row[1].ToString());
                        else if (row[0].ToString() == "description")
                            htmlMeta.Attributes.Add("description", row[1].ToString());
                        else if (row[0].ToString() == "keywords")
                            htmlMeta.Attributes.Add("keywords", row[1].ToString());
                    }
                    HtmlHead header = new HtmlHead();
                    header.Controls.Add(htmlMeta);
                }
                DataTable dtDomain = commonBll.GetDomainDetails(Session["VerticalDomain"].ToString());
                if (dtDomain.Rows.Count == 1)
                {
                    ltrFooter.Text = dtDomain.Rows[0]["Footer"].ToString().Replace("#RootPath#", RootPath).Replace("#DomainName#", DomainName);
                }
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    if (Session["ProfileID"] != null)
                    {
                        if (Session["ProfileID"].ToString() != "")
                        {
                            // Check For New User
                            DataTable dtprofile = busobj.GetBusinessDeatilsByUserID(UserID);

                            if (dtprofile != null && dtprofile.Rows.Count > 0)
                            {
                                hdnIsLiteVersion.Value = Convert.ToString(dtprofile.Rows[0]["IsLiteVersion"]);
                                Session["IsLiteVersion"] = "false";
                                if (Convert.ToBoolean(dtprofile.Rows[0]["IsLiteVersion"]) == true && !DomainName.Equals("inschoolalertcom"))
                                    Session["IsLiteVersion"] = dtprofile.Rows[0]["IsLiteVersion"].ToString();
                                Profilename = dtprofile.Rows[0]["Profile_name"].ToString();
                                Session["profilename"] = dtprofile.Rows[0]["Profile_name"].ToString();
                                ViewState["menu1value"] = 2;
                                DataTable dtobjforpasswprd = busobj.GetUserDetailsByID(UserID);
                                Session["Username"] = dtobjforpasswprd.Rows[0]["Username"].ToString();
                                if (dtobjforpasswprd.Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(dtobjforpasswprd.Rows[0]["IsTraining"].ToString()) && Convert.ToBoolean(dtobjforpasswprd.Rows[0]["IsTraining"].ToString()))
                                        IsTraining = true;
                                }
                            }
                            GetMenu();
                        }
                    }
                }
                Gethelpmenudata();
            }
            if (Session["profilename"] != null)
            {
                if (Session["profilename"].ToString() != "")
                {
                    Profilename = Session["profilename"].ToString();
                }
            }
            if (Session["HelpText"] != null && Session["HelpName"] != null)
            {
                hdnhelpText.Value = Session["HelpText"].ToString().Replace("<", "&lt;").Replace(">", "&gt;");
                hdnhelpname.Value = Session["HelpName"].ToString();
            }
            if (Session["Helpvideo"] != null)
            {
                hdnhelpvideo.Value = Session["Helpvideo"].ToString();
            }
            LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + Session["VerticalDomain"] + "logo.png";
            // *** Adding page title and meta keys for page *** //
            DataTable dtConfigPageKeys1 = commonBll.GetVerticalConfigsByType(DomainName, "VerticalNames");
            if (dtConfigPageKeys1.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigPageKeys1.Rows)
                {
                    if (row[0].ToString() == "DisplayLabel")
                        hdnLoginType.Value = row[1].ToString();
                }
            }
        }
        private void GetMenu()
        {
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Roles & permissions
                Dtpermissions = busobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
            string navigationUrl = "";
            int profileID = Convert.ToInt32(Session["ProfileID"].ToString());
            #region dispaly menu links
            DataTable dtTools = busobj.GetSelectedToolsByUserID(UserID);
            DataTable dtProfileDetails = busobj.GetProfileDetailsByProfileID(profileID);
            bool isSms = false;
            bool isSubApp = false;
            if (Convert.ToBoolean(dtProfileDetails.Rows[0]["IsSms"].ToString()))
                isSms = true;
            if (!string.IsNullOrEmpty(dtProfileDetails.Rows[0]["Parent_ProfileID"].ToString()))
                isSubApp = true;
            int pkgNumber = 1;
            if (dtTools.Rows.Count > 0)
            {
                pkgNumber = dtTools.Rows[0]["Package_Number"] != null ? Convert.ToInt32(dtTools.Rows[0]["Package_Number"].ToString()) : 1;
            }
            DataTable dtMenulinks = busobj.GetPackageMenuLinks(pkgNumber, Convert.ToBoolean(dtProfileDetails.Rows[0]["IsLiteVersion"]));

            // *** Start menu for Messages *** //

            MenuItem categoryMessage = new MenuItem();
            DataTable dtGetMasterRootMenus = commonBll.GetMasterMenuLinks();
            for (int i = 0; i < dtGetMasterRootMenus.Rows.Count; i++)
            {
                if (dtGetMasterRootMenus.Rows[i]["Category_No"].ToString() == "4")
                {
                    categoryMessage.Text = dtGetMasterRootMenus.Rows[i]["NodeName"].ToString();
                    menuMessages.Items.Add(categoryMessage);
                }
            }
            DataTable dtGetRootMenus1 = commonBll.GetParentMenuLinks(Convert.ToBoolean(dtProfileDetails.Rows[0]["IsLiteVersion"]));
            DataRow[] drMessages = dtGetRootMenus1.Select("Category_No='4'");

            bool IsSmartConnectAviable = false;
            DataTable dtCustomModules = commonBll.CheckingModuleExists(ProfileID, ButtonTypes.SmartConnect);
            if (dtCustomModules.Rows.Count > 0)
                IsSmartConnectAviable = true;

            if (drMessages.Length > 0)
            {
                foreach (DataRow dr in drMessages)
                {
                    string rootMenuName = string.Empty;
                    rootMenuName = dr["NodeName"].ToString();
                    if (rootMenuName.ToLower().Contains("smartconnect") && IsSmartConnectAviable == false)
                        continue;

                    string permissionName1 = Convert.ToString(dr["PermissionName"]);
                    MenuItem categoryItem = new MenuItem(rootMenuName);
                    if (!string.IsNullOrEmpty(dr["Navigate_Url"].ToString()))
                        navigationUrl = dr["Navigate_Url"].ToString().Replace("#SSLPath#", RootPath).Replace("#NONSSLPath#", RootPath).Replace("#ProfileID#", EncryptDecrypt.DESEncrypt(profileID.ToString()));
                    else
                        navigationUrl = dr["Free_Java_Script"].ToString();
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (permissionName1.ToLower().ToString() != PageNames.CPASSWORD && permissionName1.ToLower().ToString() != PageNames.CINFORMATION)
                        {
                            if (permissionName1 != "")
                            {
                                if (commonBll.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, permissionName1) == "P")
                                    categoryItem.NavigateUrl = navigationUrl;
                            }
                            else
                                categoryItem.NavigateUrl = navigationUrl;
                        }
                    }
                    else
                        categoryItem.NavigateUrl = navigationUrl;
                    if (dr["NodeName"].ToString().Contains("Renew"))
                    {
                        if (Session["Renewal"] != null && Session["Renewal"].ToString() == "1")
                            categoryMessage.ChildItems.Add(categoryItem);
                    }
                    else
                        categoryMessage.ChildItems.Add(categoryItem);

                }
            }
            // *** Start menu for Messages *** //


            MenuItem categoryezMenu = new MenuItem();
            string permissionName = "";
            string chkPermission = string.Empty;
            categoryezMenu.Text = "Options";
            Menu1.Items.Add(categoryezMenu);
            if (dtMenulinks.Rows.Count > 0)
            {
                for (int i = 0; i < dtMenulinks.Rows.Count; i++)
                {
                    string rootMenuName = string.Empty;
                    rootMenuName = dtMenulinks.Rows[i]["NodeName"].ToString();
                    //Store Module Functionality
                    if (rootMenuName == "Manage Logins" && !IsManageLogins)
                        continue;

                    if (rootMenuName == "Setup Social Auto Share" && !IsSocial)
                        continue;
                    if (rootMenuName == "Contacts" && !IsContact)
                        continue;
                    if (rootMenuName == "App Display Settings" && !IsAppDiplayCustomization)
                        continue;

                    permissionName = Convert.ToString(dtMenulinks.Rows[i]["PermissionName"]);
                    if (permissionName == "SubAffiliates" && isSubApp)
                        continue;
                    if (permissionName == "SubAffiliates")
                        permissionName = PageNames.APPSETTINGS;
                    MenuItem categoryItem = new MenuItem(rootMenuName);

                    if (!string.IsNullOrEmpty(dtMenulinks.Rows[i]["Navigate_Url"].ToString()))
                        navigationUrl = dtMenulinks.Rows[i]["Navigate_Url"].ToString().Replace("#SSLPath#", RootPath).Replace("#NONSSLPath#", RootPath).Replace("#ProfileID#", EncryptDecrypt.DESEncrypt(profileID.ToString()));
                    else
                        navigationUrl = dtMenulinks.Rows[i]["Free_Java_Script"].ToString();
                    if (Session["Free"] != null && Session["Free"].ToString() != "")
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(Session["C_USER_ID"])))
                        {
                            if (dtMenulinks.Rows[i]["IsFree"].ToString() == "True")
                                categoryItem.NavigateUrl = navigationUrl;
                        }
                    }
                    else
                    {
                        if (dtMenulinks.Rows[i]["IsFree"].ToString() == "True")
                        {
                            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                            {
                                if (Dtpermissions.Rows.Count > 0) //Roles & Permissions...
                                {
                                    if (permissionName != "")
                                    {
                                        if (dtMenulinks.Rows[i]["NodeName"].ToString() == "App Buttons")
                                            chkPermission = commonBll.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageButtons");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() == "Mobile App")
                                            chkPermission = commonBll.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() == "Contacts")
                                            chkPermission = commonBll.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Contacts");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() == "SubAffiliates")
                                            chkPermission = commonBll.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() != "")
                                            chkPermission = commonBll.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, dtMenulinks.Rows[i]["PermissionName"].ToString());
                                        else
                                            chkPermission = "P";
                                        if (chkPermission == "P")
                                            categoryItem.NavigateUrl = navigationUrl;
                                    }
                                    else
                                        categoryItem.NavigateUrl = navigationUrl;
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMenulinks.Rows[i]["PermissionName"])))
                                        categoryItem.NavigateUrl = navigationUrl;
                                }
                            }
                            else
                                categoryItem.NavigateUrl = navigationUrl;
                        }
                    }
                    if (categoryItem.Text.ToLower().Contains("sms"))
                    {
                        if (isSms)
                            categoryezMenu.ChildItems.Add(categoryItem);
                    }
                    else
                        categoryezMenu.ChildItems.Add(categoryItem);
                }
            }
            // *** Start menu for My Account *** //
            MenuItem categoryMyAcc = new MenuItem(); 
            for (int i = 0; i < dtGetMasterRootMenus.Rows.Count; i++)
            {
                if (dtGetMasterRootMenus.Rows[i]["Category_No"].ToString() == "2")
                {
                    categoryMyAcc.Text = dtGetMasterRootMenus.Rows[i]["NodeName"].ToString();
                    Menu2.Items.Add(categoryMyAcc);
                }
            }
            DataTable dtGetRootMenus = commonBll.GetParentMenuLinks(Convert.ToBoolean(dtProfileDetails.Rows[0]["IsLiteVersion"]));
            DataRow[] drMyAccount = dtGetRootMenus.Select("Category_No='2'");
            if (drMyAccount.Length > 0)
            {
                foreach (DataRow dr in drMyAccount)
                {
                    string rootMenuName = string.Empty;
                    rootMenuName = dr["NodeName"].ToString();
                    permissionName = Convert.ToString(dr["PermissionName"]);
                    MenuItem categoryItem = new MenuItem(rootMenuName);
                    if (!string.IsNullOrEmpty(dr["Navigate_Url"].ToString()))
                        navigationUrl = dr["Navigate_Url"].ToString().Replace("#SSLPath#", RootPath).Replace("#NONSSLPath#", RootPath).Replace("#ProfileID#", EncryptDecrypt.DESEncrypt(profileID.ToString()));
                    else
                        navigationUrl = dr["Free_Java_Script"].ToString();
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (permissionName.ToLower().ToString() != PageNames.CPASSWORD && permissionName.ToLower().ToString() != PageNames.CINFORMATION)
                            categoryItem.NavigateUrl = navigationUrl;
                    }
                    else
                        categoryItem.NavigateUrl = navigationUrl;

                    if (dr["NodeName"].ToString().Contains("Renew"))
                    {
                        if (Session["Renewal"] != null && Session["Renewal"].ToString() == "1")
                            categoryMyAcc.ChildItems.Add(categoryItem);
                    }
                    else
                        categoryMyAcc.ChildItems.Add(categoryItem);
                }
            }
            // *** Start menu for My Account *** //
            #endregion
        }
        private void Gethelpmenudata()
        {
            // *** Get Menu Links Data ***
            DataTable dtGetRootMenus = commonBll.GetHelpMasterMenuItems(Convert.ToBoolean(hdnIsLiteVersion.Value));
            int count = 0;
            int rootID = 0;
            string tClientID = TreeView1.ClientID;
            if (dtGetRootMenus.Rows.Count > 0)
            {
                for (int i = 0; i < dtGetRootMenus.Rows.Count; i++)
                {
                    int rootMenuID = 0;

                    rootMenuID = Convert.ToInt32(dtGetRootMenus.Rows[i]["Help_ID"].ToString());
                    string[,] parentNode = new string[100, 2];
                    parentNode[count, 0] = dtGetRootMenus.Rows[i]["Help_ID"].ToString();
                    parentNode[count++, 1] = dtGetRootMenus.Rows[i]["Help_Name"].ToString();
                    TreeNode root = new TreeNode();
                    root.Text = parentNode[i, 1];
                    //  root.NavigateUrl = "javascript:showPanel(0)";
                    root.NavigateUrl = "javascript:TreeView_ToggleNode(" + tClientID + "_Data," + rootID + ",document.getElementById('" + tClientID + "n" + rootID + "'),' ',document.getElementById('" + tClientID + "n" + rootID + "Nodes'));";

                    DataTable dtChildMenus = commonBll.GetHelpChildMenuForMasterID(rootMenuID);
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
                    TreeView1.Nodes.Add(root);
                }
                TreeView1.CollapseAll();
            }
            else
                lblNoHelp.Text = Resources.LabelMessages.ComingSoon;
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            //TreeView1.CollapseAll();
            ModalPopupExtenderhelp.Hide();

        }
        protected void btnsend_Click(object sender, EventArgs e)
        {
            if (txtemail.Text.Length > 0)
            {
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                }
                else
                    Response.Redirect(RootPath + "/Login.aspx?sflag=1");
                DataTable dtuserdetails = busobj.GetUserDetailsByUserID(UserID);
                if (dtuserdetails.Rows.Count > 0)
                {
                    useremail = dtuserdetails.Rows[0]["Username"].ToString();
                    senderEmail = ConfigurationManager.AppSettings.Get("EmailFrom");
                    firstname = dtuserdetails.Rows[0]["Firstname"].ToString();
                    lastname = dtuserdetails.Rows[0]["Lastname"].ToString();
                }

                Sendmail(1);
                lblhelpmsg.Text = "Email has been sent successfully.";
            }
            ScriptManager.RegisterClientScriptBlock(btnsend, this.GetType(), "ClientScriptFunction", "displayemailpanel(1)", true);
            ModalPopupExtenderhelp.Show();

        }
        #region Glossary module
        protected void btnshowglossary_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderhelp.Show();
        }
        protected void btnhelpmenu_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderhelp.Show();
        }

        protected void btngsend_Click(object sender, EventArgs e)
        {
            if (txtgemail.Text.Length > 0)
            {
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                }
                else
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                DataTable dtuserdetails = new DataTable();
                dtuserdetails = busobj.GetUserDetailsByUserID(UserID);
                if (dtuserdetails.Rows.Count > 0)
                {
                    senderEmail = ConfigurationManager.AppSettings.Get("EmailFrom");
                    firstname = dtuserdetails.Rows[0]["Firstname"].ToString();
                    lastname = dtuserdetails.Rows[0]["Lastname"].ToString();
                }

                Sendmail(0);
                lblgmsg.Text = "Email has been sent successfully.";
            }
            ScriptManager.RegisterClientScriptBlock(btnsend, this.GetType(), "ClientScriptFunction", "displaygemailpanel(1)", true);
            ModalPopupExtenderhelp.Show();

        }

        #endregion
        protected void Sendmail(int value)
        {
            UtilitiesBLL objutil = new UtilitiesBLL();
            if (value == 1)
            {
                string subject = "Help Text";
                string msg = string.Empty;
                string toEmail = txtemail.Text;
                string videotext = string.Empty;
                string helpid = string.Empty;
                if (Session["HelpID"] != null)
                {
                    helpid = Session["HelpID"].ToString();
                }
                if (hdnhelpvideo.Value.Length > 0)
                {
                    videotext = @"<br/>Looking for demonstration? " + "<a href='" + RootPath + "/Helpvideo.aspx?VID=" + helpid + "' target=_blank>Click here</a> to watch the video.<br/>";
                }
                string helpText = hdnhelpText.Value.Replace("&lt;", "<");
                helpText = helpText.Replace("&gt;", ">");
                msg = @"    <html><head>   </head><body>
                  <table width='750px' border='0' cellspacing='0' cellpadding='0' align='center' style='border: solid 2px #F4EBEB;'>
        <tr><td style='padding-left: 10px;'> <b>" + hdnhelpname.Value + @"</b><br/></td></tr>
                   <tr><td colspan='2' style='padding:30px; border-bottom: solid 1px #F4EBEB;'>" + helpText + videotext + @"

               <br/><br/>Thank you,<br/>" + firstname + " " + lastname + @"<br/><br/></td></tr> 
                    
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
                txtemail.Text = "";
            }
            else
            {
                string subject = "Glossary Text";
                string msg = string.Empty;
                string toEmail = txtgemail.Text;
                msg = @"    <html><head>   </head><body>
                  <table width='750px' border='0' cellspacing='0' cellpadding='0' align='center' style='border: solid 2px #F4EBEB;'>
        <tr><td style='padding-left: 10px;'> <b>" + hdnGlossarytext.Value + @"</b><br/></td></tr>
                   <tr><td colspan='2' style='padding:30px; border-bottom: solid 1px #F4EBEB;'>" + hdnGlossarydesc.Value + @"

               <br/><br/>Thank you,<br/>" + firstname + " " + lastname + @"<br/><br/></td></tr> 
                    
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
                txtgemail.Text = "";
            }


        }
        protected void lnkHelpDownload_OnClick(object sender, EventArgs e)
        {
            int helpID = Convert.ToInt32(hdnhelpID.Value);
            string filename = "";
            DataTable dthelpdetails;
            try
            {
                dthelpdetails = commonBll.GetHelpmenuDetailsbyHelpID(helpID);
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
        protected void btnHelpSearch_Click(object sender, EventArgs e)
        {
            int helpCount = 0;
            if (string.IsNullOrEmpty(txtHelpSearch.Text))
            {
                foreach (TreeNode node in TreeView1.Nodes)
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
            hdnhelpKeyword.Value = txtHelpSearch.Text;
            HelpResult = objCommon.GetHelpSearchDetails(txtHelpSearch.Text.Trim(), Convert.ToBoolean(hdnIsLiteVersion.Value));
            foreach (TreeNode node in TreeView1.Nodes)
            {
                foreach (TreeNode childnode in node.ChildNodes)
                {
                    if (HelpResult.Contains(childnode.Text))
                    {
                        node.Expanded = true;
                        childnode.Text = "<p style='background-color:#CCE6FF; padding: 4px 0px;'>" + childnode.Text + "</p>";
                        helpCount += 1;
                    }
                    else
                        childnode.Text = childnode.Text.Replace("<p style='background-color:#CCE6FF; padding: 4px 0px;'>", "").Replace("</p>", "");
                }
            }
            if (helpCount == 0)
            {
                TreeView1.CollapseAll();
                lblNoHelpMsg.Text = "We couldn't find any results.";
            }
            else
                lblNoHelpMsg.Text = "";
            pnl1.Style.Add("display", "none");
            pnl2.Style.Add("display", "inline");
            pnlemail.Style.Add("display", "none");
            Pnlglossary.Style.Add("display", "none");
            pnlglossarydesc.Style.Add("display", "none");
            pnlglossaryemail.Style.Add("display", "none");
            ModalPopupExtenderhelp.Show();
        }
        protected void btnHelpClear_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderhelp.Show();
            txtHelpSearch.Text = "";
            lblNoHelpMsg.Text = "";
        }
        protected void imgBtnHidePopup_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in TreeView1.Nodes)
            {
                foreach (TreeNode childnode in node.ChildNodes)
                {
                    node.Expanded = false;
                    childnode.Text = childnode.Text.Replace("<p style='background-color:#CCE6FF; padding: 4px 0px;'>", "").Replace("</p>", "");
                }
            }
            ModalPopupExtenderhelp.Hide();
        }
    }
}