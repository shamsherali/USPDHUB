using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Web.Services;
using System.Configuration;
using System.Text;

public partial class AdminLite : System.Web.UI.MasterPage
{
    public string RootPath = "";
    public string LiteRootPath = "";
    public string DomainName = "";
    public int UserID = 0;
    public int ProfileID = 0;
    public int CUserID = 0;
    public string LogoName = "";
    public string Profilename = "";
    public string FreeToUpgrade = "";
    CommonBLL _objCommon = new CommonBLL();
    BusinessBLL _objBus = new BusinessBLL();
    ezSmartSiteWizard _objezSmartsite = new ezSmartSiteWizard();
    AgencyBLL _objAgency = new AgencyBLL();
    protected override void OnInit(EventArgs e)
    {
        try
        {
            base.OnInit(e);
            if (Request.Url.ToString().Contains("/ForgotPassword.aspx") == false)
            {
                if (Convert.ToString(Session["UserID"]) == "" || Session["VerticalDomain"] == null)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                }
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "OnInit", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (!IsPostBack)
            {
                DataTable dtConfigPageKeys = _objCommon.GetVerticalConfigsByType(DomainName, "DashboardKeys");
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
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        CUserID = UserID;
                    if (Session["ProfileID"] != null)
                    {
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);
                        if (Session["ProfileID"].ToString() != "")
                        {
                            // Check For New User
                            DataTable dtprofile = _objBus.GetBusinessDeatilsByUserID(UserID);
                            if (dtprofile != null && dtprofile.Rows.Count > 0)
                            {
                                hdnIsLiteVersion.Value = Convert.ToString(dtprofile.Rows[0]["IsLiteVersion"]);
                                Profilename = dtprofile.Rows[0]["Profile_name"].ToString();
                                Session["profilename"] = dtprofile.Rows[0]["Profile_name"].ToString();
                                ViewState["menu1value"] = 2;
                                Consumer conObjforpassword = new Consumer();
                                DataTable dtobjforpasswprd = conObjforpassword.GetUserDetailsByID(UserID);
                                if (dtobjforpasswprd.Rows.Count > 0)
                                {
                                    if (dtobjforpasswprd.Rows[0]["Password_Changed"].ToString().Length > 0 && dtobjforpasswprd.Rows[0]["Password_Changed"].ToString() != "1")
                                    {
                                        if (Request.Url.ToString().Contains("/Changepassword.aspx") == false)
                                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Changepassword.aspx?CPD=ActivateUser"));
                                    }
                                }
                            }
                            // End
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
            LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";
            // *** Adding page title and meta keys for page *** //
            DataTable dtConfigPageKeys1 = _objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
            if (dtConfigPageKeys1.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigPageKeys1.Rows)
                {
                    if (row[0].ToString() == "DisplayLabel")
                        hdnLoginType.Value = row[1].ToString();
                }
            }
            FreeToUpgrade = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=1&isug=true";
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkHelpDownload_OnClick(object sender, EventArgs e)
    {
        int helpID = Convert.ToInt32(hdnhelpID.Value);
        string filename = "";
        DataTable dthelpdetails;
        try
        {
            dthelpdetails = _objezSmartsite.GetHelpmenuDetailsbyHelpID(helpID);
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
    private void Gethelpmenudata()
    {
        try
        {
            // *** Get Menu Links Data ***

            DataTable dtGetRootMenus = _objezSmartsite.GetHelpMasterMenuItems(true,DomainName);
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

                    DataTable dtChildMenus = _objezSmartsite.GetHelpChildMenuForMasterID(rootMenuID);
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
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "Gethelpmenudata", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    protected void btnHelpSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int helpCount = 0;
            if (string.IsNullOrEmpty(txtHelpSearch.Text) || hdnhelpKeyword.Value == txtHelpSearch.Text)
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
            List<string> HelpResult = new List<string>();
            hdnhelpKeyword.Value = txtHelpSearch.Text;
            HelpResult = _objCommon.GetHelpSearchDetails(txtHelpSearch.Text.Trim(), true);
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
                    {
                        childnode.Text = childnode.Text.Replace("<p style='background-color:#CCE6FF; padding: 4px 0px;'>", "").Replace("</p>", ""); ;
                    }
                }
            }
            if (helpCount == 0)
            {
                TreeView1.CollapseAll();
                lblNoHelpMsg.Text = "We couldn't find any results.";
            }
            else
                lblNoHelpMsg.Text = "";
            pnlHelpDetails.Style.Add("display", "none");
            pnlHelpList.Style.Add("display", "inline");
            ModalPopupExtenderhelp.Show();
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "btnHelpSearch_Click", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnHelpClear_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtHelpSearch.Text))
            {
                ModalPopupExtenderhelp.Show();
                txtHelpSearch.Text = "";
                lblNoHelpMsg.Text = "";
                pnlHelpDetails.Style.Add("display", "none");
                foreach (TreeNode node in TreeView1.Nodes)
                {
                    foreach (TreeNode childnode in node.ChildNodes)
                    {
                        node.Expanded = false;
                        childnode.Text = childnode.Text.Replace("<p style='background-color:#CCE6FF; padding: 4px 0px;'>", "").Replace("</p>", ""); ;
                    }
                }
            }
            else
            {
                btnHelpSearch_Click(sender, e);
                lblNoHelpMsg.Text = "";
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "btnHelpClear_Click", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        ModalPopupExtenderhelp.Hide();
    }
    protected void imgBtnHidePopup_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "imgBtnHidePopup_Click", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void GetMenu()
    {
        try
        {
            DataTable Dtpermissions = new DataTable();
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Roles & permissions
                Dtpermissions = _objAgency.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
            string navigationUrl = "";
            MenuDashBoard objMenuDash = new MenuDashBoard();
            BusinessBLL objBusiness = new BusinessBLL();
            #region dispaly menu links
            DataTable dtTools = objBusiness.GetSelectedToolsByUserID(UserID);
            DataTable dtProfileDetails = objBusiness.GetProfileDetailsByProfileID(ProfileID);
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
            DataTable dtMenulinks = objBusiness.GetPackageMenuLinks(pkgNumber, Convert.ToBoolean(dtProfileDetails.Rows[0]["IsLiteVersion"]),DomainName);
            MenuItem categoryezMenu = new MenuItem();
            string permissionName = "";
            string chkPermission = string.Empty;
            StringBuilder strOptionsMenu = new StringBuilder();
            if (dtMenulinks.Rows.Count > 0)
            {
                for (int i = 0; i < dtMenulinks.Rows.Count; i++)
                {
                    string rootMenuName = string.Empty;
                    rootMenuName = dtMenulinks.Rows[i]["NodeName"].ToString();
                    permissionName = Convert.ToString(dtMenulinks.Rows[i]["PermissionName"]);
                    if (permissionName == "SubAffiliates" && isSubApp)
                        continue;
                    if (permissionName == "SubAffiliates")
                        permissionName = PageNames.APPSETTINGS;

                    if (!string.IsNullOrEmpty(dtMenulinks.Rows[i]["Navigate_Url"].ToString()))
                        navigationUrl = dtMenulinks.Rows[i]["Navigate_Url"].ToString().Replace("#SSLPath#", RootPath).Replace("#NONSSLPath#", RootPath).Replace("#ProfileID#", EncryptDecrypt.DESEncrypt(ProfileID.ToString()));
                    else
                        navigationUrl = dtMenulinks.Rows[i]["Free_Java_Script"].ToString();
                    if (Session["Free"] != null && Session["Free"].ToString() != "")
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(Session["C_USER_ID"])))
                        {
                            if (dtMenulinks.Rows[i]["IsFree"].ToString() == "True")
                                strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
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
                                            chkPermission = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageButtons");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() == "Mobile App")
                                            chkPermission = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() == "Contacts")
                                            chkPermission = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Contacts");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() == "SubAffiliates")
                                            chkPermission = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                                        else if (dtMenulinks.Rows[i]["PermissionName"].ToString() != "")
                                            chkPermission = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, dtMenulinks.Rows[i]["PermissionName"].ToString());
                                        else
                                            chkPermission = "P";
                                        if (chkPermission == "P")
                                            strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                                    }
                                    else
                                        strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMenulinks.Rows[i]["PermissionName"])))
                                        strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                                }
                            }
                            else
                                strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                        }
                    }
                }
            }
            ltrOptionsMenu.Text = strOptionsMenu.ToString();
            // *** Start menu for My Account *** //
            DataTable dtGetRootMenus = objMenuDash.GetParentMenuLinks(Convert.ToBoolean(dtProfileDetails.Rows[0]["IsLiteVersion"]));
            DataRow[] drMyAccount = dtGetRootMenus.Select("Category_No='2'");
            strOptionsMenu.Clear();
            if (drMyAccount.Length > 0)
            {
                foreach (DataRow dr in drMyAccount)
                {
                    string rootMenuName = string.Empty;
                    rootMenuName = dr["NodeName"].ToString();
                    permissionName = Convert.ToString(dr["PermissionName"]);
                    if (!string.IsNullOrEmpty(dr["Navigate_Url"].ToString()))
                        navigationUrl = dr["Navigate_Url"].ToString().Replace("#SSLPath#", RootPath).Replace("#NONSSLPath#", RootPath).Replace("#ProfileID#", EncryptDecrypt.DESEncrypt(ProfileID.ToString()));
                    else
                        navigationUrl = dr["Free_Java_Script"].ToString();
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (permissionName.ToLower().ToString() != PageNames.CPASSWORD && permissionName.ToLower().ToString() != PageNames.CINFORMATION)
                        {
                            if (permissionName != "")
                            {
                                if (_objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, permissionName) == "P")
                                    strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                            }
                            else
                                strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                        }
                    }
                    else
                        strOptionsMenu.Append("<li><a href=\"" + navigationUrl + "\">" + rootMenuName + "</a></li>");
                }
            }
            ltrAccountMenu.Text = strOptionsMenu.ToString();
            // *** End menu for My Account *** //
            #endregion
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminLite.master.cs", "GetMenu", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}