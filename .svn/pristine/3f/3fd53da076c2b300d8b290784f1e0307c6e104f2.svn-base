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
using System.Xml;

public partial class Business_MyAccount_PrintMessages : System.Web.UI.Page
{
    BusinessBLL objBus = new BusinessBLL();
    public int UserID = 0;
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public int C_UserID = 0;
    public int ProfileID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            if (Session["userid"] != null)
            {
                UserID = Convert.ToInt32(Session["userid"]);

                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["MID"].ToString() != null && Request.QueryString["MID"].ToString() != "")
                {
                    if (Request.QueryString["Flag"].ToString() != null && Request.QueryString["Flag"].ToString() != "")
                    {
                        if (Request.QueryString["Flag"].ToString().ToUpper() == "PUBLICCALL")
                        {
                            dvprint.Style.Add("display","none");
                            dvprintPubiccall.Style.Add("display", "block");
                            showPopupPublicCall(Convert.ToInt32(Request.QueryString["MID"].ToString()));
                        }
                        else if (Request.QueryString["Flag"].ToString().ToUpper() == "PRIVATECALL") {
                            dvprint.Style.Add("display", "none");
                            dvprintPubiccall.Style.Add("display", "block");
                            showPopupPrivateCall(Convert.ToInt32(Request.QueryString["MID"].ToString()));
                        }
                        else
                        {
                            dvprint.Style.Add("display", "block");
                            dvprintPubiccall.Style.Add("display", "none");
                            ShowContactusDetails(Convert.ToInt32(Request.QueryString["MID"].ToString()), Request.QueryString["Flag"].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "PrintMessages.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private void showPopupPublicCall(int historyID)
    {

        DataTable dt = new DataTable("PublicCallHistory");
        lblimagetext.Visible = true;
        lbllocationtext.Visible = true;
        dt = objBus.GetMobilePublicCallsHistory(false, historyID, ProfileID);
        if (dt != null && dt.Rows.Count > 0)
        {
            lblTitle.Text = dt.Rows[0]["Title"].ToString();
            lblCustomMsg.Text = dt.Rows[0]["CustomPredefinedMessage"].ToString();
            lblContactEmail.Text = dt.Rows[0]["ContactEmail"].ToString();
            lblPhoneNum.Text = dt.Rows[0]["ContactPhoneNumber"].ToString();
            lblContactName.Text = dt.Rows[0]["ContactName"].ToString();
            if (dt.Rows[0]["ImageName"].ToString() != "")
                imgPublicImage.ImageUrl = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/Upload/PublicCallDirectoryTapImages/" + ProfileID + "/" + dt.Rows[0]["ImageName"].ToString();
            else
                lblimagetext.Visible = false; 
            if (dt.Rows[0]["GPS_Details"] != null && dt.Rows[0]["GPS_Details"].ToString().Trim() != "")
            {
                string[] address = dt.Rows[0]["GPS_Details"].ToString().Split(',');

                string latitude = address[0];
                string longitude = address[1];
                XmlDocument doc = new XmlDocument();
                doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                if (element.InnerText == "ZERO_RESULTS")
                {
                    lblPublicCallLocation.Text = "";
                }
                else
                {
                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                    if (element != null)
                    {
                        if (((element).InnerText) != null && ((element).InnerText) != "")
                        {
                            string text = (element).InnerText;
                            string[] textdata = text.Split(',');
                            for (int i = 0; i < textdata.Length; i++)
                            {
                                if (lblPublicCallLocation.Text == "" || lblPublicCallLocation.Text == null)
                                    lblPublicCallLocation.Text = textdata[i].Trim().ToString();
                                else if ((textdata.Length - 2) == i)
                                    lblPublicCallLocation.Text = lblPublicCallLocation.Text + "," + " " + textdata[i].Trim().ToString();
                                else
                                    lblPublicCallLocation.Text = lblPublicCallLocation.Text + "," + "<br/>" + textdata[i].Trim().ToString();
                            }
                            lblPublicCallLocation.Text = lblPublicCallLocation.Text + ".";
                        }
                    }
                }

            }
            else
                lbllocationtext.Visible = false;

        }

    }
    private void ShowContactusDetails(int ContactID, string ContactusType)
    {
        try
        {
            cleardata();
            DataTable dtNLContact = new DataTable();
            dtNLContact = objBus.SelectMobileAppAlerts(UserID, ContactID, false, C_UserID);
            if (ContactusType == "T")
                lblmess.Text = "Tip:";
            else
                lblmess.Text = "Message:";

            if (dtNLContact.Rows.Count > 0)
            {
                string data = dtNLContact.Rows[0]["Message"].ToString();
                string[] message = data.Split('|');
                lblfn.Text = message[0].ToString();
                if (message[2] != null && message[2] != "")
                    lblemail.Text = message[2].ToString();
                if (message[1] != null && message[1] != "")
                    lblphone.Text = message[1].ToString();
                lbldescription.Text = message[3].ToString();


                // Used to Get the Address based on latitude and longitude......

                if (dtNLContact.Rows[0]["Latitude1"] != null && dtNLContact.Rows[0]["Latitude1"].ToString() != "" && Convert.ToInt32(dtNLContact.Rows[0]["Latitude1"]) != 0)
                {
                    if (dtNLContact.Rows[0]["Longitude1"] != null && dtNLContact.Rows[0]["Longitude1"].ToString() != "" && Convert.ToInt32(dtNLContact.Rows[0]["Longitude1"]) != 0)
                    {
                        string latitude = dtNLContact.Rows[0]["Latitude1"].ToString();
                        string longitude = dtNLContact.Rows[0]["Longitude1"].ToString();
                        XmlDocument doc = new XmlDocument();
                        doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");
                        XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                        if (element.InnerText == "ZERO_RESULTS")
                        {
                            lblLocation.Text = "";
                        }
                        else
                        {
                            element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                            if (((element).InnerText) != null && ((element).InnerText) != "")
                            {
                                string text = (element).InnerText;
                                string[] textdata = text.Split(',');
                                for (int i = 0; i < textdata.Length; i++)
                                {
                                    if (lblLocation.Text == "" || lblLocation.Text == null)
                                        lblLocation.Text = textdata[i].Trim().ToString();
                                    else if ((textdata.Length - 2) == i)
                                        lblLocation.Text = lblLocation.Text + "," + " " + textdata[i].Trim().ToString();
                                    else
                                        lblLocation.Text = lblLocation.Text + "," + "<br/>" + textdata[i].Trim().ToString();
                                }
                                lblLocation.Text = lblLocation.Text + ".";
                            }
                        }
                    }
                }

                // Ends Here...

                string imageName = Convert.ToString(dtNLContact.Rows[0]["PhotoName"]);
                if (imageName != string.Empty && imageName != null)
                {
                    //getting image path
                    string uploadphotosPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/Upload/DevicePhotos/" + ProfileID + "/";
                    imageName = uploadphotosPath + imageName;

                    lblImg.Text = "<img src='" + imageName + "' Width='500' />";
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "PrintMessages.aspx.cs", "ShowContactusDetails", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void showPopupPrivateCall(int historyID)
    {

        DataTable dt = new DataTable("PrivateCallHistory");
        lblimagetext.Visible = true;
        lbllocationtext.Visible = true;
        dt = objBus.GetMobilePrivateCallsHistory(false, historyID, ProfileID, true);
        if (dt != null && dt.Rows.Count > 0)
        {
            lblPrivatetitle.Text = dt.Rows[0]["Title"].ToString();
            lblprivateCallMsg.Text = dt.Rows[0]["CustomPredefinedMessage"].ToString();
            lblPrivateEmail.Text = dt.Rows[0]["ContactEmail"].ToString();
            lblPrivateNumber.Text = dt.Rows[0]["PhoneInformation"].ToString();
            lblPrivateName.Text = dt.Rows[0]["ContactName"].ToString();
            if (dt.Rows[0]["ImageName"].ToString() != "")
                imgPublicImage.ImageUrl = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/Upload/PublicCallDirectoryTapImages/" + ProfileID + "/" + dt.Rows[0]["ImageName"].ToString();
            else
                lblimagetext.Visible = false;
            if (dt.Rows[0]["GPS_Details"] != null && dt.Rows[0]["GPS_Details"].ToString().Trim() != "")
            {
                string[] address = dt.Rows[0]["GPS_Details"].ToString().Split(',');

                string latitude = address[0];
                string longitude = address[1];
                XmlDocument doc = new XmlDocument();
                doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                if (element.InnerText == "ZERO_RESULTS")
                {
                    lblPrivatelocation.Text = "";
                }
                else
                {
                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                    if (element != null)
                    {
                        if (((element).InnerText) != null && ((element).InnerText) != "")
                        {
                            string text = (element).InnerText;
                            string[] textdata = text.Split(',');
                            for (int i = 0; i < textdata.Length; i++)
                            {
                                if (lblPrivatelocation.Text == "" || lblPrivatelocation.Text == null)
                                    lblPrivatelocation.Text = textdata[i].Trim().ToString();
                                else if ((textdata.Length - 2) == i)
                                    lblPrivatelocation.Text = lblPrivatelocation.Text + "," + " " + textdata[i].Trim().ToString();
                                else
                                    lblPrivatelocation.Text = lblPrivatelocation.Text + "," + "<br/>" + textdata[i].Trim().ToString();
                            }
                            lblPrivatelocation.Text = lblPrivatelocation.Text + ".";
                        }
                    }
                }

            }
            else
                lbllocationtext.Visible = false;

        }

    }
    protected void cleardata()
    {
        lbldescription.Text = lblemail.Text = "";
        lblphone.Text = lblLocation.Text = "";
        lblfn.Text = lblImg.Text = "";
    }
}
