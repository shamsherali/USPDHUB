using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;

public partial class Business_MyAccount_NewsiteIntiation : BaseWeb
{
    BusinessBLL Busobj = new BusinessBLL();
    public int ProfileID = 0;
    public int UserID = 0;
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    DataTable dtobj2 = new DataTable();
    public int C_UserID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                lblfirstname.Text = "<font color=green size=3 font-weight=bold><b>" + Session["Name"].ToString() + "</B></font>";
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);


                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;

            }

            USPDHUBBLL.UtilitiesBLL utobj = new USPDHUBBLL.UtilitiesBLL();
            dtobj2 = utobj.GetAllStatesByCountry("USA");

            if (!IsPostBack)
            {
                if (dtobj2.Rows.Count > 0)
                {
                    ddlstate.DataSource = dtobj2;
                    ddlstate.DataTextField = "State_Name";
                    ddlstate.DataValueField = "State_Name";
                    ddlstate.DataBind();
                    ListItem item2 = new ListItem();
                    item2.Value = "0";
                    item2.Text = "-- Select State --";
                    ddlstate.Items.Add(item2);
                    ddlstate.SelectedIndex = ddlstate.Items.IndexOf(item2);
                }
                bindvalues(dtobj2);
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "NewsiteIntiation.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Streetaddress = txtStreetAdress.Text;
            string city = txtcity.Text;
            string state = ddlstate.SelectedItem.ToString();
            string zipcode = txtzipcode.Text;
            string busdesc = Txtbusinessdesc.Text;
            #region Getting Latidude & longtidude values
            //Getting Latidude & longtidude values
            //string testAddress = "6060 Sunrise Vista Dr. #1130,Citrus Heights,California,95610";
            string fullAddress = Streetaddress + "," + city + "," + state + "," + zipcode;
            Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

            double latitude1 = Convert.ToDouble(coordinates.Latitude);
            double longitude1 = Convert.ToDouble(coordinates.Longitude);

            #endregion
            #region Insert mobile app settings
            USPDHUBBLL.MobileAppSettings objMAppSets = new USPDHUBBLL.MobileAppSettings();
            DataTable dtMobileAppSettings = objMAppSets.GetMobileAppSetting(UserID);
            if (dtMobileAppSettings.Rows.Count == 0)
            {
                string xmlSettings = "<SubTools><Tools BName='True' Logo='True'  Address='True'  City='True'  State='True' Country='True' ZipCode='True' " +
                    " PhoneNumber='True'  AboutUs='True'  Updates='True'   Social='True' Coupons='True'  Photos='True' " +
                    " Events='True' IsContatUs='True'  /></SubTools>";

                objMAppSets.InsertMobileAppSettings(Convert.ToInt32(Session["SettingID"]), xmlSettings, Convert.ToInt32(Session["UserID"]), true, C_UserID, string.Empty, string.Empty);

            }


            #endregion

            int value = Busobj.UpdatenewsiteIntiation(ProfileID, Streetaddress, busdesc, city, state," ", zipcode, latitude1, longitude1, C_UserID);
            int value1 = Busobj.UpdateBusinessType(ProfileID, ddlbusinesstype.SelectedValue.ToString(), C_UserID);
            Session["BusinessType"] = ddlbusinesstype.SelectedItem.ToString();
            if (value > 0)
            {
                string url = string.Empty;
                string pagename = "Default.aspx";
                if (ConfigurationManager.AppSettings["runwizard"] == "1")
                    pagename = "RunezSmartSiteWizard.aspx";
                url = Page.ResolveClientUrl("~/Business/MyAccount/" + pagename);
                Response.Redirect(url);
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "NewsiteIntiation.aspx.cs", "btnSubmit_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void bindvalues(DataTable dtstates)
    {
        try
        {
            DataTable dtprofiledetails = Busobj.GetProfileDetailsByProfileID(ProfileID);
            if (dtprofiledetails.Rows.Count > 0)
            {
                string city = dtprofiledetails.Rows[0]["Profile_City"].ToString();
                string state = dtprofiledetails.Rows[0]["Profile_State"].ToString();
                //string zipcode = dtprofiledetails.Rows[0]["Profile_Zipcode"].ToString();
                string Desc = dtprofiledetails.Rows[0]["Profile_Description"].ToString();
                if (city.Length > 0)
                {
                    txtcity.Text = city;
                }
                if (state.Length > 0)
                {
                    for (int i = 0; i < dtstates.Rows.Count; i++)
                    {
                        if (state.ToUpper() == dtstates.Rows[i]["State_Name"].ToString().ToUpper())
                        {
                            ddlstate.SelectedValue = state;
                        }
                    }
                }
                if (Desc.Length > 0)
                {
                    Txtbusinessdesc.Text = Desc;
                }
            }
            DataTable dtbusinesstypes = new DataTable();
            dtbusinesstypes = Busobj.GetBusinessTypes();
            DataView SortDt = new DataView(dtbusinesstypes);
            SortDt.Sort = "Business_Type ASC";
            dtbusinesstypes = SortDt.ToTable();
            ddlbusinesstype.DataTextField = "Business_Type";
            ddlbusinesstype.DataValueField = "BID";
            ddlbusinesstype.DataSource = dtbusinesstypes;
            ddlbusinesstype.DataBind();
            ddlbusinesstype.Items.Insert(0, new ListItem("--Select--", "0"));
            DataTable dtprofilesettings = new DataTable();
            dtprofilesettings = Busobj.GetProfileSettingsByprofileID(ProfileID);
            if (dtprofilesettings.Rows.Count > 0)
            {
                if (dtprofilesettings.Rows[0]["Business_Type"] != null)
                {
                    string businesstype = dtprofilesettings.Rows[0]["Business_Type"].ToString();
                    ddlbusinesstype.SelectedValue = businesstype;

                    if (ddlbusinesstype.SelectedValue == "0")
                        Session["BusinessType"] = "Business";
                    else
                        Session["BusinessType"] = ddlbusinesstype.SelectedItem.ToString();

                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "NewsiteIntiation.aspx.cs", "bindvalues", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        bindvalues(dtobj2);
    }
}
