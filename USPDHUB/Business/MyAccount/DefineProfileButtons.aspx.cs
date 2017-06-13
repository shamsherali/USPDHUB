using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class DefineProfileButtons : BaseWeb
    {
        public int ProfileID = 0;
        DataTable dt = new DataTable();
        DataTable mastertabs = new DataTable();
        public int C_UserID = 0;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string RootPath = "";
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();
        public DataTable dtUserDetails = new DataTable();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBlockedSendAccess = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                // *** Chcking for user session ***
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = Convert.ToInt32(Session["UserID"]);
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (!IsPostBack)
                {
                    DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        IsParent = false;
                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                    }

                    dt = objBus.GetManageButtonsByProfileID(ProfileID);

                    #region         Binding Master Tabs

                    //************* Page1 (Home)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page1", DomainName);
                    ddlhome.DataTextField = "Tab_Name";
                    ddlhome.DataSource = mastertabs;
                    ddlhome.DataBind();
                    //ddlhome.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));

                    // ************* Page2 (About)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page2", DomainName);
                    ddlabout.DataTextField = "Tab_Name";
                    ddlabout.DataSource = mastertabs;
                    ddlabout.DataBind();
                    //ddlabout.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));

                    // ************* Page3 (Media)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page3", DomainName);
                    ddlmedia.DataTextField = "Tab_Name";
                    ddlmedia.DataSource = mastertabs;
                    ddlmedia.DataBind();
                    //ddlmedia.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));

                    // ************* Page4 (Updates)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page4", DomainName);
                    ddlupdates.DataTextField = "Tab_Name";
                    ddlupdates.DataSource = mastertabs;
                    ddlupdates.DataBind();
                    //ddlupdates.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));

                    // ************* Page6 (Event Caledar)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page5", DomainName);
                    ddleventcal.DataTextField = "Tab_Name";
                    ddleventcal.DataSource = mastertabs;
                    ddleventcal.DataBind();
                    //ddleventcal.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));

                    // ************* Page7 (Bulletins)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page6", DomainName);
                    ddlbulletin.DataTextField = "Tab_Name";
                    ddlbulletin.DataSource = mastertabs;
                    ddlbulletin.DataBind();
                    //ddlbulletin.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));
                    // ************* Page7 (Bulletins)Tabs
                    mastertabs = objBus.GetMastermanageButtons("Page7", DomainName);
                    ddlweblinks.DataTextField = "Tab_Name";
                    ddlweblinks.DataSource = mastertabs;
                    ddlweblinks.DataBind();
                    //ddlweblinks.Items.Insert(mastertabs.Rows.Count, new ListItem("Custom Tab"));
                    #endregion
                    // *** Commented to remove tab order for App 26-03-2013 *** //
                    // TABS ORDERING DISPLAY
                    for (int i = 1; i <= 7; i++)
                    {
                        ddl1.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                        ddl2.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                        ddl3.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                        ddl4.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                        ddl5.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                        ddl6.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                        ddl7.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                    }


                    ddlhome.SelectedValue = "Home";
                    ddlabout.SelectedValue = "About Us";
                    ddlmedia.SelectedValue = "Gallery";
                    ddlupdates.SelectedValue = "Updates";
                    ddleventcal.SelectedValue = "Event Calendar";
                    ddlbulletin.SelectedValue = "Bulletins";
                    ddlweblinks.SelectedValue = "Web Links";

                    // TABS ORDERING DISPLAY
                    ddl1.SelectedValue = "1";
                    ddl2.SelectedValue = "2";
                    ddl3.SelectedValue = "3";
                    ddl5.SelectedValue = "5";
                    ddl4.SelectedValue = "4";
                    ddl6.SelectedValue = "6";
                    ddl7.SelectedValue = "7";
                    if (dt.Rows.Count > 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Tab_ID"].ToString() == "Page1")
                            {
                                ddlhome.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl1.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                            else if (dt.Rows[i]["Tab_ID"].ToString() == "Page2")
                            {
                                ddlabout.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl2.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                            else if (dt.Rows[i]["Tab_ID"].ToString() == "Page3")
                            {
                                ddlmedia.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl3.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                            else if (dt.Rows[i]["Tab_ID"].ToString() == "Page4")
                            {
                                ddlupdates.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl4.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                            else if (dt.Rows[i]["Tab_ID"].ToString() == "Page5")
                            {
                                ddleventcal.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl5.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                            else if (dt.Rows[i]["Tab_ID"].ToString() == "Page6")
                            {
                                ddlbulletin.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl6.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                            else if (dt.Rows[i]["Tab_ID"].ToString() == "Page7")
                            {
                                ddlweblinks.SelectedValue = dt.Rows[i]["Tab_Name"].ToString();
                                //ddl7.SelectedValue = dt.Rows[i]["Order_No"].ToString();
                            }
                        }
                    }
                    HiddenField1.Value = ddlhome.SelectedValue;
                    HiddenField2.Value = ddlabout.SelectedValue;
                    HiddenField3.Value = ddlmedia.SelectedValue;
                    HiddenField4.Value = ddlupdates.SelectedValue;
                    HiddenField5.Value = ddleventcal.SelectedValue;
                    HiddenField6.Value = ddlbulletin.SelectedValue;
                    HiddenField7.Value = ddlweblinks.SelectedValue;

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageButtons");
                        if (hdnPermissionType.Value == "A")
                        {
                            ddlabout.Enabled = ddlbulletin.Enabled = ddleventcal.Enabled = false;
                            lnkApply.Enabled = btnSubmit.Enabled = ddlhome.Enabled = ddlmedia.Enabled = ddlupdates.Enabled = ddlweblinks.Enabled = false;
                            lblMessage.Text = "<font face=arial size=2 color=red>You do not have permission to manage buttons.</font>";
                        }
                    }
                    //ends here
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddlhome.SelectedItem.Text, "Page1", Convert.ToInt32(ddl1.SelectedValue), C_UserID);
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddlabout.SelectedItem.Text, "Page2", Convert.ToInt32(ddl2.SelectedValue), C_UserID);
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddlmedia.SelectedItem.Text, "Page3", Convert.ToInt32(ddl3.SelectedValue), C_UserID);
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddlupdates.SelectedItem.Text, "Page4", Convert.ToInt32(ddl4.SelectedValue), C_UserID);
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddleventcal.SelectedItem.Text, "Page5", Convert.ToInt32(ddl5.SelectedValue), C_UserID);
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddlbulletin.SelectedItem.Text, "Page6", Convert.ToInt32(ddl6.SelectedValue), C_UserID);
                objBus.Inser_Update_ManageButtons(ProfileID, 0, ddlweblinks.SelectedItem.Text, "Page7", Convert.ToInt32(ddl7.SelectedValue), C_UserID);
                lblMessage.Text = "Manage buttons have been updated successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
           InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
           objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "btnApply_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
    
            }

        }

        protected void chkmedia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkmedia.Checked == true)
                {
                    ddlmedia.Enabled = true;
                }
                else
                {
                    ddlmedia.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "chkmedia_CheckedChanged", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void chkupdates_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkupdates.Checked == true)
                {
                    ddlupdates.Enabled = true;
                }
                else
                {
                    ddlupdates.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "chkupdates_CheckedChanged", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void chkeventcal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkeventcal.Checked == true)
                {
                    ddleventcal.Enabled = true;
                }
                else
                {
                    ddleventcal.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "chkeventcal_CheckedChanged", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void chkbulletin_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkbulletin.Checked == true)
                {
                    ddlbulletin.Enabled = true;
                }
                else
                {
                    ddlbulletin.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "chkbulletin_CheckedChanged", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void chkweblinks_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkweblinks.Checked == true)
                {
                    ddlweblinks.Enabled = true;
                }
                else
                {
                    ddlweblinks.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "chkweblinks_CheckedChanged", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int UserID = 0;
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"]);
                }
                CommonBLL objCommonBll = new CommonBLL();
                DataTable dtUserDetails = objBus.GetUserDetailsByUserID(UserID);
                string PageName = Convert.ToString(pagename.Value.ToString());
                string FromEmailInfo = "";
                DataTable dtConfigsemails = objCommonBll.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailInfo = row[1].ToString();
                    }
                }


                string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "ProfileButtons.txt");
                StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                string msgbody = string.Empty;
                string content = string.Empty;
                string desclaimer = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    msgbody = msgbody + desclaimer;
                }
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR>";
                }

                msgbody = msgbody.Replace("#RootUrl#", RootPath);
                msgbody = msgbody.Replace("#msgBody#", content);

                msgbody = msgbody.Replace("#UserID#", Convert.ToString(dtUserDetails.Rows[0]["User_ID"]));
                msgbody = msgbody.Replace("#UserName#", Convert.ToString(dtUserDetails.Rows[0]["Username"]));
                msgbody = msgbody.Replace("#PageNO#", GetPageName(PageName));
                msgbody = msgbody.Replace("#TabName#", txtTabName.Text.Trim());
                re.Close();
                re.Dispose();
                string ccemail = string.Empty;
                string returnval = string.Empty;
                string toEmailID = ConfigurationManager.AppSettings.Get("TabEmailID");

                USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
                returnval = utlobj.SendWowzzyEmail(FromEmailInfo, toEmailID, "Profile button Details", msgbody, ConfigurationManager.AppSettings.Get("EmailFrom"), "", DomainName);
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                txtTabName.Text = "";
                // divcustomtab.Visible = false;

                if (pagename.Value == "Page 1")
                {
                    ddlhome.SelectedValue = HiddenField1.Value;
                }
                else if (pagename.Value == "Page 2")
                {
                    ddlabout.SelectedValue = HiddenField2.Value;
                }
                else if (pagename.Value == "Page 3")
                {
                    ddlmedia.SelectedValue = HiddenField3.Value;
                }
                else if (pagename.Value == "Page 4")
                {
                    ddlupdates.SelectedValue = HiddenField4.Value;
                }
                else if (pagename.Value == "Page 5")
                {
                    ddleventcal.SelectedValue = HiddenField5.Value;
                }
                else if (pagename.Value == "Page 6")
                {
                    ddlbulletin.SelectedValue = HiddenField6.Value;
                }
                else if (pagename.Value == "Page 7")
                {
                    ddlweblinks.SelectedValue = HiddenField7.Value;
                }
                lblMessage.Text = "Your request has been submitted. One of our representatives will contact you soon.";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "btnSubmit_Click", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string GetPageName(string pagename)
        {
            try
            {
                switch (pagename)
                {
                    case "Page 1":
                        pagename = "Home";
                        break;
                    case "Page 2":
                        pagename = "About Us";
                        break;
                    case "Page 3":
                        pagename = "Media";
                        break;
                    case "Page 4":
                        pagename = "Updates";
                        break;
                    case "Page 5":
                        pagename = "Event Calendar";
                        break;
                    case "Page 6":
                        pagename = "Bulletins";
                        break;
                    case "Page 7":
                        pagename = "Web Links";
                        break;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "DefineProfileButtons.aspx.cs", "GetPageName", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return pagename;
        }
    }
}