using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using USPDHUBBLL;

public partial class Business_MyAccount_AboutUs : BaseWeb
{
    public int UserID = 0;
    public int AboutUsFlag = 0;
    BusinessUpdatesBLL adminobj = new BusinessUpdatesBLL();
    BusinessBLL busobj = new BusinessBLL();
    static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public int ProfileID = 0;
    public int MaxBusinessUpdateID = 0;
    public string AboutUsDesc = string.Empty;
    public int CUserID = 0;
    public DataTable Dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
    public string PermissionType = string.Empty;
    public int PermissionValue = 0;
    public string titleName = "";
    public string DomainName = "";
    AddOnBLL objAddOn = new AddOnBLL();
    CommonBLL objCommon = new CommonBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
            }
            // *** Make back button visible and disable by query string 26-03-2013 *** //
            if (!string.IsNullOrEmpty(Request.QueryString["App"]))
                btnBack.Visible = true;
            else
                btnBack.Visible = false;

            if (!string.IsNullOrEmpty(Request.QueryString["Status"] as string))
                lblerror.Text = "Your changes have been updated successfully.";
            else
                lblerror.Text = "";

            if (!string.IsNullOrEmpty(Request.QueryString["status"] as string))
                lblerror.Text = "Your details have been saved successfully.";
            else
                lblerror.Text = "";

            DomainName = Session["VerticalDomain"].ToString();
            titleName = objApp.GetMobileAppSettingTabName(UserID, "AboutUs", DomainName);
            lblTitle.Text = titleName;

            if (!IsPostBack)
            {

                lblOff.Visible = true;
                if (objCommon.DisplayOn_OffSettingsContent(UserID, "AboutUs"))
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }

                //GetProfileAboutusDetails();
                DataTable dtprofiledetails1 = busobj.GetProfileDetailsByProfileID(ProfileID);
                if (dtprofiledetails1.Rows.Count > 0)
                {
                    if (dtprofiledetails1.Rows[0]["About_Edit_HTML"] != DBNull.Value && dtprofiledetails1.Rows[0]["About_Edit_HTML"].ToString() != "")
                    {
                        string aboutustext = dtprofiledetails1.Rows[0]["About_Edit_HTML"].ToString();
                        lblEditText.Text = aboutustext;
                    }
                    else
                    {
                        //***else block Added for showing watermark symbol if AbousUs content Empty 06/19/2013.***//
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(1);", true);
                    }
                    hdnIsLiteVersion.Value = Convert.ToString(dtprofiledetails1.Rows[0]["IsLiteVersion"]);
                }
                if (lblEditText.Text.Trim() == string.Empty)
                {
                    lblEditText.Text = "<div id='watermark'>Your block goes here!!!</div>";
                }
                //roles & permissions..
                //USPD-1107 Permission related Changes
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    //hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                    hdnAboutUsPermission.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AboutUs");
                    //if (hdnPermissionType.Value == "A" || string.IsNullOrEmpty(hdnPermissionType.Value))
                    if (string.IsNullOrEmpty(hdnAboutUsPermission.Value))
                    {
                        UpdatePanel1.Visible = false;
                        UpdatePanel2.Visible = true;
                        lblerrormessage.Text = "<font face=arial size=2 color=red>You do not have permission to update agency information.</font>";
                    }
                }
                //ends here 


                //Font-Family Profile Base
                DataTable dtProfileAddress = new DataTable();
                dtProfileAddress = busobj.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                {
                    hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AboutUs.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    private void GetProfileAboutusDetails()
    {
        try
        {
            lblEditText.Text = "";

            DataTable dtprofiledetails1 = busobj.GetProfileDetailsByProfileID(ProfileID);
            if (dtprofiledetails1.Rows.Count > 0)
            {
                if (dtprofiledetails1.Rows[0]["About_Edit_HTML"] != DBNull.Value && dtprofiledetails1.Rows[0]["About_Edit_HTML"].ToString() != "")
                {
                    string aboutustext = dtprofiledetails1.Rows[0]["About_Edit_HTML"].ToString();
                    lblEditText.Text = aboutustext;
                }
            }
            if (lblEditText.Text.Trim() == string.Empty)
            {
                lblEditText.Text = "<div id='watermark'>Your block goes here!!!</div>";
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AboutUs.aspx.cs", "GetProfileAboutusDetails", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
            Response.Redirect(urlinfo);
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AboutUs.aspx.cs", "btnCancel_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            AboutUsDesc = hdnPreviewHTML.Value.ToString();
            // Get Shorten Url from Long Url
            AboutUsDesc = objCommon.ReplaceShortURltoHtmlString(AboutUsDesc);

            string editHtml = hdnEditHTML.Value.ToString();

            busobj.UpdateProfileAboutUsDetails(ProfileID, AboutUsDesc, CUserID, editHtml);
            busobj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "AboutUs", "Update");
            //GetProfileAboutusDetails();
            Response.Redirect("AboutUs.aspx?status=1");

            MPEProgress.Hide();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AboutUs.aspx.cs", "Button1_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }

    protected void btnDashboard_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }

    [System.Web.Services.WebMethod]
    public static string ReplaceShortURltoHmlString(string htmlString)
    {
        try
        {
            CommonBLL objCommonBll = new CommonBLL();
            htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "AboutUs.aspx.cs", "ReplaceShortURltoHmlString", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

        return htmlString;


    }
}
