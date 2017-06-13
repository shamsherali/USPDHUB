using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Xml;
using USPDHUBBLL;

public partial class UserTracking : System.Web.UI.Page
{
    CommonBLL objCommon = new CommonBLL();
    public int SchID = 0;
    public string EmailType = string.Empty;
    public string RootPath = ConfigurationManager.AppSettings["RootPath"];
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "image/jpeg";
            if (Request.QueryString["SID"] != null)
            {
                if (Request.QueryString["SID"].ToString() != "")
                {
                    string id = EncryptDecrypt.DESDecrypt(Request.QueryString["SID"].ToString());
                    SchID = Convert.ToInt32(id);
                }
            }
            if (Request.QueryString["ETP"] != null)
            {
                if (Request.QueryString["ETP"].ToString() != "")
                {
                    EmailType = Request.QueryString["ETP"].ToString();
                }
            }
            TrackUser(SchID, EmailType);
            Response.WriteFile(Server.MapPath("~/images/contactus.gif"));
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "UserTracking.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void TrackUser(int schid, string eT)
    {
        try
        {
            if (eT == "BP" || eT == "EC" || eT == "BL" || eT == "CA" || eT == "CM")
            {
                string countryCode = string.Empty;
                string countryName = string.Empty;
                string cityName = string.Empty;
                string longitude = string.Empty;
                string latitude = string.Empty;
                string regionName = string.Empty;
                string regionCode = string.Empty;
                string zipcode = string.Empty;
                string browser = string.Empty;
                //Get IP Address
                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];
                DataTable dt = objCommon.GetLocation(ipaddress);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        countryCode = dt.Rows[0]["countryCode"].ToString();//dt.Rows[0]["CountryCode"].ToString();
                        countryName = dt.Rows[0]["countryName"].ToString();//dt.Rows[0]["CountryName"].ToString();
                        cityName = dt.Rows[0]["cityName"].ToString();//dt.Rows[0]["City"].ToString();
                        regionCode = "";//dt.Rows[0]["RegionCode"].ToString();
                        regionName = dt.Rows[0]["regionName"].ToString();//dt.Rows[0]["RegionName"].ToString();
                        zipcode = dt.Rows[0]["zipCode"].ToString();//dt.Rows[0]["ZipPostalCode"].ToString();
                        latitude = dt.Rows[0]["latitude"].ToString();//dt.Rows[0]["Latitude"].ToString();
                        longitude = dt.Rows[0]["longitude"].ToString();//dt.Rows[0]["Longitude"].ToString();
                        browser = Request.Browser.Type.ToString();
                    }
                }
                objCommon.UpdateUserTracking(schid, eT, countryCode, countryName, cityName, regionCode, regionName, zipcode, latitude, longitude, ipaddress, browser.Replace("InternetExplorer", "IE"));
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "UserTracking.aspx.cs", "TrackUser", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
