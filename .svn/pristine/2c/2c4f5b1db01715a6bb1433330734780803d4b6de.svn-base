using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Configuration;

public partial class Business_MyAccount_ProfileDescription : BaseWeb
{
    public int UserID = 0;
    public int ProfileID = 0;
    BusinessBLL _ObjBus = new BusinessBLL();
    public int MaxBusinessUpdateID = 0;
    public int C_UserID = 0;
    public static DataTable dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
    public string titleName = "";
    public string DomainName = "";
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    AddOnBLL objAddOn = new AddOnBLL();
    CommonBLL objCommon = new CommonBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            lblerror.Text = "";

            // *** Make back button visible and disable by query string 26-03-2013 *** //
            if (!string.IsNullOrEmpty(Request.QueryString["App"] as string))
                btnBack.Visible = true;
            else
                btnBack.Visible = false;

            if (!string.IsNullOrEmpty(Request.QueryString["Status"] as string))
                lblerror.Text = "Your changes have been updated successfully.";
            else
                lblerror.Text = "";

            DomainName = Session["VerticalDomain"].ToString();
            titleName = objApp.GetMobileAppSettingTabName(UserID, "Home", DomainName);
            lblTitle.Text = titleName;

            if (!IsPostBack)
            {

                lblOff.Visible = true;
                if (objCommon.DisplayOn_OffSettingsContent(UserID, "Home"))
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }

                // *** Issue 1037 *** //
                if (Session["ezSmartPreivew"] != null && Session["ezSmartPreivew"].ToString() != "")
                {
                    lblerror.Text = "Your changes have been updated successfully.";
                    Session["ezSmartPreivew"] = null;
                }
                // *** End Issue 1037 *** //

                LoadIntialSubscriptionvalues();

                //roles & permissions..
                //USPD-1107 Permission related Changes
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    //hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                    hdnHomePermission.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Home");
                    //if (hdnPermissionType.Value == "A" || string.IsNullOrEmpty(hdnPermissionType.Value))
                    if (string.IsNullOrEmpty(hdnHomePermission.Value))
                    {
                        UpdatePanel1.Visible = false;
                        UpdatePanel2.Visible = true;
                        lblerrormessage.Text = "<font face=arial size=2 color=red>You do not have permission to update profile details.</font>";
                    }
                }
                //ends here


                //Font-Family Profile Base
                DataTable dtProfileAddress = new DataTable();
                dtProfileAddress = _ObjBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                {
                    hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ProfileDescription.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void LoadIntialSubscriptionvalues()
    {
        try
        {
            string BusinessUrl = string.Empty;
            string Corporateurl = string.Empty;
            DataTable dtobj = _ObjBus.GetProfileDetailsByProfileID(ProfileID);
            if (dtobj.Rows.Count > 0)
            {
                string Description_Edit_HTML = dtobj.Rows[0]["Description_Edit_HTML"].ToString();
                lblEditText.Text = Description_Edit_HTML;
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ProfileDescription.aspx.cs", "LoadIntialSubscriptionvalues", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void Modify_Profile(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/default.aspx"));
    }
    protected void Modify_Continue(object sender, EventArgs e)
    {
        try
        {
            if (UpdateProfileDeatils())
            {
                _ObjBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "Home", "Update");
                if (btnBack.Visible == false)
                {
                    _ObjBus.UpdateDashboardFlow(UserID, 2, C_UserID);
                    Response.Redirect("ProfileDescription.aspx?Status=1");
                }
                Session["ezSmartPreivew"] = "Update";

                Response.Redirect("ProfileDescription.aspx?App=1");

                MPEProgress.Hide();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ProfileDescription.aspx.cs", "Modify_Continue", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private bool UpdateProfileDeatils()
    {
        USPDHUBBLL.UtilitiesBLL utlObj = new USPDHUBBLL.UtilitiesBLL();
        string businessdesc = string.Empty;
        businessdesc = hdnPreviewHTML.Value.ToString();
        // Get Shorten Url from Long Url
        businessdesc = objCommon.ReplaceShortURltoHtmlString(businessdesc);

        string editHTML = hdnEditHTML.Value.ToString();

        int updateflag = 0;
        DataTable dtobj = _ObjBus.GetProfileDetailsByProfileID(ProfileID);
        string businessname = string.Empty;
        string contactname = string.Empty;
        string address1 = string.Empty;
        string address2 = string.Empty;
        string cityname = string.Empty;
        string statename = string.Empty;
        string countryname = string.Empty;
        string zipcode = string.Empty;
        string phonenum = string.Empty;
        string extenction = string.Empty;
        string faxnumber = string.Empty;
        string mobilenum = string.Empty;
        string alternatephone = string.Empty;
        int timezoneid = 0;
        if (dtobj.Rows.Count > 0)
        {
            businessname = dtobj.Rows[0]["Profile_name"].ToString();
            contactname = dtobj.Rows[0]["Profile_Contact_Name"].ToString();
            address1 = dtobj.Rows[0]["Profile_StreetAddress1"].ToString();
            address2 = dtobj.Rows[0]["Profile_StreetAddress2"].ToString();
            cityname = dtobj.Rows[0]["Profile_City"].ToString();
            statename = dtobj.Rows[0]["Profile_State"].ToString();

            if (dtobj.Rows[0]["Profile_County"].ToString() != "")
            {
                countryname = dtobj.Rows[0]["Profile_County"].ToString();
            }
            else
            {
                DataTable dtobj1 = _ObjBus.GetUserDetailsByUserID(UserID);
                if (dtobj1.Rows.Count == 1)
                {
                    countryname = dtobj1.Rows[0]["User_Country"].ToString();
                }
            }
            
            zipcode = dtobj.Rows[0]["Profile_Zipcode"].ToString();
            timezoneid = Convert.ToInt32(dtobj.Rows[0]["TimeZoneID"].ToString());
            phonenum = dtobj.Rows[0]["Profile_Phone1"].ToString();
            // *** Issue 1186 *** //
            if (dtobj.Rows[0]["Mobile_Number"] != null)
                mobilenum = dtobj.Rows[0]["Mobile_Number"].ToString();
            // *** Fix for IRHM 1.1 Web changes 25-02-2013 *** //
            if (dtobj.Rows[0]["Alternate_Phone"] != null)
                alternatephone = dtobj.Rows[0]["Alternate_Phone"].ToString();
            if (dtobj.Rows[0]["Profile_Phone2"].ToString().Length > 0)
            {
                extenction = dtobj.Rows[0]["Profile_Phone2"].ToString();
            }
            faxnumber = dtobj.Rows[0]["Profile_Fax"].ToString();
        }
        #region Getting Latidude & longtidude values
        string fullAddress = address1 + "," + cityname + "," + statename +"," + countryname + "," + zipcode;
        Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

        double latitude1 = Convert.ToDouble(coordinates.Latitude);
        double longitude1 = Convert.ToDouble(coordinates.Longitude);

        #endregion

        updateflag = _ObjBus.UpdateBusinessProfileDetails(businessname, businessdesc, contactname, "", "", address1, address2, cityname, statename,countryname,
            zipcode, phonenum, extenction, faxnumber, UserID, ProfileID, mobilenum, alternatephone, latitude1, longitude1, C_UserID, editHTML, timezoneid);

        // *** Fix for IRH-52 31-12-2013 *** //
        int value = _ObjBus.UpdatenewsiteIntiation(ProfileID, address1, businessdesc, cityname, statename,countryname, zipcode, latitude1, longitude1, C_UserID);
        if (updateflag > 0)
            return true;
        else
            return false;
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
        CommonBLL objCommonBll = new CommonBLL();
        htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);

        return htmlString;
    }
}