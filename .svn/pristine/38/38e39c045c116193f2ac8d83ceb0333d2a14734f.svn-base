using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace USPDHUB.Admin
{
    public partial class MemberInformation : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL _objBus = new BusinessBLL();
        public CommonBLL objCommonBLL = new CommonBLL();
        UtilitiesBLL utlObj;

        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        public string DomainName = "";

        DataTable dtobjMemberSite = new DataTable();
        public string RootPath = "";
        string Errormsg = "";

        public string Temp = string.Empty;
        public bool isShortLogo = false;
        public static bool IsResizeLogo = false;

        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] != null)
                {
                    UserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (Request.QueryString["pid"] != null)
                {
                    ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["pid"].ToString()));
                    UserID = CUserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["UID"].ToString()));
                }
                
                if (!IsPostBack)
                {
                    BindCountry();
                    Session["buttontype"] = "home";
                    hdnPID.Value = ProfileID.ToString();
                    hdnUID.Value = UserID.ToString();
                    RootPath = objCommonBLL.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");

                    LoadProfileContactInformation();
                    LoadProfileLogo();
                    LoadProfileDescription();


                    //Font-Family Profile Base
                    DataTable dtProfileAddress = new DataTable();
                    dtProfileAddress = _objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                    {
                        hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                    }

                    DomainName = Session["VerticalDomain"].ToString();
                    //lblTitle.Text = objApp.GetMobileAppSettingTabName(UserID, "Home", DomainName);
                    lnkHome.Text = objApp.GetMobileAppSettingTabName(UserID, "Home", DomainName);
                    lnkAboutUs.Text = objApp.GetMobileAppSettingTabName(UserID, "AboutUs", DomainName);

                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindCountry()
        {
            DataTable dtCountry = new DataTable();
            dtCountry = objCommonBLL.GetCountries();
            ddlCountry.DataSource = dtCountry;
            ddlCountry.DataTextField = "Country_Name";
            ddlCountry.DataValueField = "Country_Name";
            ddlCountry.DataBind();

            //ddlCountry.Items.Insert(0, "Select Country");
        }

        private void LoadProfileContactInformation()
        {
            try
            {
                string days = string.Empty;
                string hours = string.Empty;
                DataTable dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtobj.Rows.Count == 1)
                {
                    // Check For Type of Business
                    txtBusinessname.Text = dtobj.Rows[0]["Profile_name"].ToString();
                    hdncontactname.Value = dtobj.Rows[0]["Profile_Contact_Name"].ToString();
                    txtaddress1.Text = dtobj.Rows[0]["Profile_StreetAddress1"].ToString();
                    txtaddress2.Text = dtobj.Rows[0]["Profile_StreetAddress2"].ToString();
                    txtcity.Text = dtobj.Rows[0]["Profile_City"].ToString();
                    txtState.Text = dtobj.Rows[0]["Profile_State"].ToString();
                    if (dtobj.Rows[0]["Profile_County"].ToString() != "")
                    {
                        ddlCountry.SelectedValue = dtobj.Rows[0]["Profile_County"].ToString();
                    }
                    else
                    {
                        DataTable dtobj1 = _objBus.GetUserDetailsByUserID(UserID);
                        if (dtobj1.Rows.Count == 1)
                        {
                            ddlCountry.SelectedValue = dtobj1.Rows[0]["User_Country"].ToString();
                        }
                    }
                   
                    txtzipcode.Text = dtobj.Rows[0]["Profile_Zipcode"].ToString();
                    txtphonenumber.Text = dtobj.Rows[0]["Profile_Phone1"].ToString();
                    string TimezoneID = dtobj.Rows[0]["TimeZoneID"].ToString();
                    ddlTimeZone.SelectedValue = TimezoneID;
                    // *** Issue 1186 *** //
                    if (dtobj.Rows[0]["Mobile_Number"] != null)
                        txtmobile.Text = dtobj.Rows[0]["Mobile_Number"].ToString();
                    // *** Fix for IRHM 1.1 Web changes 25-02-2013 *** //
                    if (!string.IsNullOrEmpty(dtobj.Rows[0]["Alternate_Phone"].ToString()))
                        txtAlternatePhone.Text = dtobj.Rows[0]["Alternate_Phone"].ToString();
                    else
                        txtAlternatePhone.Text = txtphonenumber.Text;
                    if (dtobj.Rows[0]["Profile_Phone2"].ToString().Length > 0)
                    {
                        txtextenction.Text = dtobj.Rows[0]["Profile_Phone2"].ToString();
                    }
                    txtfaxnumber.Text = dtobj.Rows[0]["Profile_Fax"].ToString();

                }
                string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
                //string countryValue = "United States";
                //if (url.Contains(ConfigurationManager.AppSettings["UrlInschoolIndia"]))
                //    countryValue = "India";
                string countryValue = ddlCountry.SelectedItem.Text.ToString().Trim();
                // *** Binding Time Zones *** //
                DataTable dtTimeZones = _objBus.GetTimeZones(countryValue);
                if (dtTimeZones.Rows.Count > 0)
                {
                    ddlTimeZone.DataSource = dtTimeZones;
                    ddlTimeZone.DataTextField = "Display_Name";
                    ddlTimeZone.DataValueField = "TimeZone_ID";
                    ddlTimeZone.DataBind();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "LoadProfileContactInformation", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadProfileLogo()
        {
            try
            {
                string logourl = string.Empty;
                int logoProfileID = ProfileID; // *** Parent profileID *** //
                var dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtobj.Rows.Count == 1)
                {
                    /*if (!string.IsNullOrEmpty(dtobj.Rows[0]["Parent_ProfileID"].ToString()))
                    {
                        logoProfileID = Convert.ToInt32(dtobj.Rows[0]["Parent_ProfileID"].ToString());
                        DataTable dtParent = _objBus.GetProfileDetailsByProfileID(logoProfileID);
                        if (dtParent.Rows.Count == 1)
                        {
                            if (dtParent.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                                logourl = dtParent.Rows[0]["Profile_logo_path"].ToString();
                        }
                    }
                    else*/
                    if (dtobj.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                        logourl = dtobj.Rows[0]["Profile_logo_path"].ToString();
                    if (logourl.Length > 0)
                    {
                        logo.Visible = true;

                        string originalfilename = logourl;
                        string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

                        string junk = ".";
                        string[] ret = originalfilename.Split(junk.ToCharArray());
                        string thumbimg1 = ret[0];
                        thumbimg1 = thumbimg1 + "_thumb" + extension;
                        string url = Server.MapPath("~") + "\\Upload\\Logos\\" + logoProfileID + "\\" + thumbimg1;
                        FileInfo obj = new FileInfo(url);
                        DeleteCache();

                        if (obj.Exists)
                        {
                            string imageDisID = Guid.NewGuid().ToString();
                            logo.ImageUrl = RootPath + "/Upload/Logos/" + logoProfileID + "/" + thumbimg1 + "?Guid=" + imageDisID;

                        }
                        else
                        {
                            string imageDisID = Guid.NewGuid().ToString();
                            logo.ImageUrl = RootPath + "/Upload/Logos/" + logoProfileID + "/" + logourl + "?Guid=" + imageDisID;

                        }
                        logoimage.Enabled = false;
                        BtnUpdateLogo.Enabled = false;
                        btnLogoDelete.Visible = true;

                        logo.Visible = true;
                        obj = null;
                        pnlLogoUpload.Style["display"] = "none";
                    }
                    else
                    {
                        if (Convert.ToBoolean(dtobj.Rows[0]["IsShortLogo"]))
                        {
                            rbShortLogo.Checked = true;
                        }
                        else
                        {
                            rbLongLogo.Checked = true;
                        }

                        btnLogoDelete.Visible = false;
                        logoimage.Enabled = true;
                        pnlLogoUpload.Style["display"] = "block";
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "LoadProfileLogo", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void DeleteCache()
        {
            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.ViewState.Clear();
            Response.Cache.SetNoStore();
        }

        # region Delete Logo
        protected void btnLogoDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteLogo();
                lblMsg.Text = "<font color=red face=arial size=2><b>Your logo has been deleted successfully.</b></font>";
                btnLogoDelete.Visible = false;
                LoadEditHTML();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "btnLogoDelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void DeleteLogo()
        {
            try
            {
                GC.Collect();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                string strlogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\";
                DataTable dtobj = new DataTable();
                string logourl = string.Empty;
                dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtobj.Rows.Count == 1)
                {
                    logourl = strlogoPath + dtobj.Rows[0]["Profile_logo_path"].ToString();
                    int UFlag = _objBus.UpdateBusinessProfileLogo(string.Empty, ProfileID, UserID, CUserID);
                    logoimage.Visible = true;
                    logoimage.Enabled = true;
                    BtnUpdateLogo.Enabled = true;
                    string imagename1 = dtobj.Rows[0]["Profile_logo_path"].ToString();

                    string extension = System.IO.Path.GetExtension(Server.MapPath(imagename1));
                    logo.Visible = false;
                    string junk = ".";
                    string[] ret = logourl.Split(junk.ToCharArray());
                    string thumbimg = ret[0];
                    thumbimg = thumbimg + "_thumb" + extension;

                    if (dtobj.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                    {
                        if (System.IO.File.Exists(logourl))
                        {
                            System.Threading.Thread.Sleep(500);
                            System.IO.File.Delete(logourl);
                        }

                        if (System.IO.File.Exists(thumbimg))
                        {
                            System.Threading.Thread.Sleep(500);
                            File.Delete(thumbimg);
                        }

                        btnLogoDelete.Visible = false;


                        //deletelogohelp.Visible = false;
                        //btnResizeLogo.Visible = false;
                    }
                    else
                    {
                        lblMsg.Text = "<font color=red face=arial size=2>There is no logo available to delete.</font>";
                    }

                }

                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                LoadProfileLogo();
                Updateprofilecouponimage();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "DeleteLogo", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        # endregion

        protected void btnUpdate_onClick(object sender, EventArgs e)
        {
            try
            {

                #region Agency Information Means App Details

                if (UpdateProfileDetails())
                {
                    lblMsg.Text = "<font color=green face=arial size=2><b>Your changes have been updated successfully.</b></font>";

                    RootPath = objCommonBLL.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");
                    LoadProfileContactInformation();
                    //LoadProfileLogo();
                    LoadProfileDescription();

                    // Save User Activity Log
                    objCommonBLL.InsertUserActivityLog("Business name, Logo and Contact details are updated. - " + txtBusinessname.Text, string.Empty, UserID, ProfileID, DateTime.Now, Convert.ToInt32(Session["adminuserid"]));

                }

                #endregion
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "btnUpdate_onClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void LoadEditHTML()
        {
            try
            {
                if (Convert.ToString(hdnEditHTML.Value).Trim() != string.Empty)
                {
                    if (hdnButtonType.Value == "home")
                    {
                        lblEditText.Text = hdnEditHTML.Value;
                    }
                    else
                    {
                        lblEditText.Text = hdnEditHTML_About.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "LoadEditHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Updateprofilecouponimage()
        {
            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.ViewState.Clear();
            // Start Issue 799
            Response.Cache.SetNoStore();
            string url = string.Empty;
            url = Server.MapPath("~").ToString();
            utlObj = new USPDHUBBLL.UtilitiesBLL();
            utlObj = null;
        }

        private void CreateLogoInImageGallery(string logoExtension)
        {
            try
            {
                string oldLogoFileName = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                if (File.Exists(oldLogoFileName))
                {
                    string imgName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + logoExtension;
                    string savefileName = Server.MapPath("~") + "\\Upload\\common\\" + +ProfileID + "\\" + imgName;

                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(oldLogoFileName);

                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();

                    System.Drawing.Image imgname = System.Drawing.Image.FromFile(oldLogoFileName);
                    actResize.Width = imgname.Width;
                    actResize.Height = imgname.Height;

                    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    uploadedImage.Actions.Add(actResize);
                    actResize = null;
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();

                    imgDraw.Elements.Add(uploadedImage);

                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 90;

                    uploadedImage = null;
                    //Now, save the output image on disk

                    imgDraw.Save(savefileName);
                    imgDraw.Dispose();


                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "CreateLogoInImageGallery", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LogoResize(int pWidth, int pHeight, string logoExtension)
        {
            try
            {
                GC.Collect();
                string dummyFIleName = null;

                // Duplicate Logo Save Path
                dummyFIleName = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb_dummy" + logoExtension;

                // Original Logo Save Path
                string LogoSavePath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;

                if (File.Exists(dummyFIleName))
                {
                    string imageUrl = dummyFIleName;
                    imageUrl = Path.GetFileName(imageUrl);
                    //Read in the width and height 

                    string dummyFileName = "";
                    if (imageUrl.Contains("?"))
                    {
                        var urls = imageUrl.Split('?');
                        dummyFileName = urls[0].ToString();
                    }
                    else
                    {
                        dummyFileName = imageUrl;
                    }

                    imageUrl = "\\Upload\\Logos\\" + ProfileID + "\\" + dummyFileName;
                    imageUrl = Server.MapPath("~") + imageUrl;

                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(imageUrl);

                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                    actResize.Width = pWidth;
                    actResize.Height = pHeight;
                    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    uploadedImage.Actions.Add(actResize);
                    actResize = null;
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();

                    imgDraw.Elements.Add(uploadedImage);

                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 90;

                    uploadedImage = null;
                    //Now, save the output image on disk

                    imgDraw.Save(LogoSavePath);
                    imgDraw.Dispose();

                }

                // Delete Dummy Logo :: Resize before logo
                if (File.Exists(dummyFIleName))
                {
                    File.Delete(dummyFIleName);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "LogoResize", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private bool UpdateProfileDetails()
        {
            string businessdesc = string.Empty;
            businessdesc = hdnPreviewHTML.Value.ToString();
            string editHTML = hdnEditHTML.Value.ToString();

            string businessname = txtBusinessname.Text.Trim();
            string contactname = hdncontactname.Value;
            string address1 = txtaddress1.Text;
            string address2 = txtaddress2.Text;
            string cityname = txtcity.Text;
            string statename = txtState.Text;
            string countryname = string.Empty;
            countryname = ddlCountry.SelectedItem.Text.ToString().Trim();
            //if (ddlCountry.SelectedValue != "0")
            //    countryname = ddlCountry.SelectedItem.Text.ToString().Trim();
            //else
            //    countryname = "";
            int timezoneid = 0;
            if (ddlTimeZone.SelectedValue != "0")
                timezoneid = Convert.ToInt32(ddlTimeZone.SelectedValue);
            string zipcode = txtzipcode.Text;
            string days = string.Empty;
            string extenction = string.Empty;
            extenction = txtextenction.Text.ToString();

            string businessduration = string.Empty;
            int noofemp = 0;
            string bussmission = string.Empty;
            string Corevalues = string.Empty;
            string productdesc = string.Empty;
            string localmembership = string.Empty;

            string phonenum = txtphonenumber.Text.Trim();
            string mobilenum = txtmobile.Text.Trim();
            string faxnumber = txtfaxnumber.Text;
            // *** Fix for IRHM 1.1 Web Changes 25-02-2013 *** //
            string alternatephone = txtAlternatePhone.Text;
            // *** Issue 1133 *** //
            businessduration = "";
            productdesc = "";
            localmembership = "";
            string noofemployees = "";
            if (noofemployees.Length > 0)
            {
                noofemp = Convert.ToInt32(noofemployees);
            }

            int updateflag = 0;
            int updatedesc = 0;
            int bushours = 1;
            if (bushours > 0)
            {
                #region Getting Latidude & longtidude values
                //Getting Latidude & longtidude values
                string fullAddress = txtaddress1.Text.Trim() + "," + txtcity.Text.Trim() + "," + txtState.Text.Trim() + "," + countryname + "," + txtzipcode.Text.Trim();
                Coordinate coordinates = Geocode.GetCoordinates(fullAddress);
                double latitude1 = Convert.ToDouble(coordinates.Latitude);
                double longitude1 = Convert.ToDouble(coordinates.Longitude);
                #endregion

                DataTable dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
                string AboutUsDesc = "";
                string editHtml = "";
                if (Session["buttontype"].ToString() == "home")
                {
                    businessdesc = hdnPreviewHTML.Value.ToString();
                    // Get Shorten Url from Long Url
                    businessdesc = objCommonBLL.ReplaceShortURltoHtmlString(businessdesc);
                    editHTML = hdnEditHTML.Value.ToString();

                    AboutUsDesc = dtobj.Rows[0]["Profile_Aboutus"].ToString();
                    editHtml = dtobj.Rows[0]["About_Edit_HTML"].ToString();
                }
                else
                {
                    AboutUsDesc = hdnPreviewHTML.Value.ToString();
                    // Get Shorten Url from Long Url
                    AboutUsDesc = objCommonBLL.ReplaceShortURltoHtmlString(AboutUsDesc);
                    editHtml = hdnEditHTML.Value.ToString();

                    businessdesc = dtobj.Rows[0]["Profile_Description"].ToString();
                    // Get Shorten Url from Long Url
                    businessdesc = objCommonBLL.ReplaceShortURltoHtmlString(businessdesc);
                    editHTML = dtobj.Rows[0]["Description_Edit_HTML"].ToString();
                }

                //Update Profile Details
                updateflag = _objBus.UpdateBusinessProfileDetails(businessname, businessdesc, contactname, "", "", address1, address2, cityname, statename,countryname,
                     zipcode, phonenum, extenction, faxnumber, UserID, ProfileID, mobilenum, alternatephone, latitude1, longitude1, CUserID, editHTML, timezoneid);

                updatedesc = _objBus.Updateprofiledescription(ProfileID, businessduration, noofemp, localmembership, businessdesc, productdesc, CUserID);
                Session["firstname"] = businessname;
                Session["profilename"] = businessname;

                #region About Us Data Updatation

                _objBus.UpdateProfileAboutUsDetails(ProfileID, AboutUsDesc, UserID, editHtml);


                #endregion

            }
            if (updateflag > 0 && updatedesc > 0 && bushours > 0)
            {
                return true;
            }
            else
                return false;
        }

        protected void btncancel_OnClick(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx");
            Response.Redirect(urlinfo);
        }

        private void LoadProfileDescription()
        {
            try
            {
                string BusinessUrl = string.Empty;
                string Corporateurl = string.Empty;
                DataTable dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtobj.Rows.Count > 0)
                {
                    if (Session["buttontype"].ToString() == "home")
                    {
                        string Description_Edit_HTML = hdnEditHTML.Value = dtobj.Rows[0]["Description_Edit_HTML"].ToString();
                        lblEditText.Text = Description_Edit_HTML;

                        hdnPreviewHTML.Value = dtobj.Rows[0]["Profile_Description"].ToString();
                    }
                    else
                    {
                        string AboutUs_EditHTML = hdnEditHTML_About.Value = dtobj.Rows[0]["About_Edit_HTML"].ToString();
                        lblEditText.Text = AboutUs_EditHTML;

                        hdnPreviewHTML_About.Value = dtobj.Rows[0]["Profile_Aboutus"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "LoadProfileDescription", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }



        //Suneel
        protected void BtnUpdateLogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (logoimage.FileName != "")
                {
                    if (logoimage.PostedFile != null)
                    {
                        int logoMinWidth = 0;
                        int logoMinHeight = 0;
                        if (rbShortLogo.Checked)
                        {
                            logoMinWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoWidth"));
                            logoMinHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoHeight"));
                        }
                        else
                        {
                            logoMinWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("LongLogoWidth"));
                            logoMinHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("LongLogoHeight"));
                        }


                        if (logoimage.PostedFile.FileName.ToString().Length > 1)
                        {
                            FileInfo logoobj = new FileInfo(logoimage.PostedFile.FileName);
                            if (logoobj.Extension == ".jpg" || logoobj.Extension == ".JPG" || logoobj.Extension == ".JPEG" || logoobj.Extension == ".jpeg" ||
                                logoobj.Extension == ".GIF" || logoobj.Extension == ".gif" || logoobj.Extension == ".bmp" || logoobj.Extension == ".BMP" ||
                                logoobj.Extension == ".png" || logoobj.Extension == ".PNG")
                            {

                                System.Drawing.Image myImage = System.Drawing.Image.FromStream(logoimage.PostedFile.InputStream);
                                if ((myImage.Height >= logoMinHeight) && (myImage.Width >= logoMinWidth))
                                {
                                    UploadAndSaveFile(logoimage, 1); // 1 is for logo 2 for photos, 3 for commerical.
                                    Response.ContentType = "text/HTML";
                                    Temp = "LOGO & ";
                                }
                                else
                                {
                                    if (rbShortLogo.Checked)
                                        lblMsg.Text = "<font color=red face=arial size=2><b>" + Resources.LabelMessages.ShortlogoUploadMessage + " " + logoMinWidth + "px X " + logoMinHeight + "px</b>.</font>";
                                    else
                                        lblMsg.Text = "<font color=red face=arial size=2><b>" + Resources.LabelMessages.LonglogoUploadMessage + " " + logoMinWidth + "px X " + logoMinHeight + "px</b>.</font>";
                                }

                            }
                            else
                            {
                                Errormsg = Errormsg.ToString() + "Your logo is in an incorrect file format. Please try again.";
                                lblMsg.Text = "<font color=red face=arial size=2><b>" + Errormsg + "</b></font>";
                            }
                            logoobj = null;
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "<font color=red face=arial size=2><b>You have not selected a logo file to upload. Please try again.</b></font>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "BtnUpdateLogo_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void UploadAndSaveFile(FileUpload file, int imagetype)
        {
            try
            {
                RootPath = objCommonBLL.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");

                string tempSaveFilePath = Server.MapPath("~") + "\\Upload";
                string folderPath = string.Empty;
                if (imagetype == 1) //logo folder
                    folderPath = tempSaveFilePath + "\\TempLogos\\" + ProfileID;
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                FileInfo logoobj = new FileInfo(file.PostedFile.FileName);
                string logoExtension = logoobj.Extension;
                if (logoExtension == ".bmp" || logoExtension == ".BMP")
                {
                    logoExtension = ".jpg";
                }

                string logoName = ProfileID + "_thumb" + logoExtension;
                Session["logoName"] = logoName;
                string LogoVartualPath = folderPath + "\\" + logoName;
                file.SaveAs(LogoVartualPath);

                System.Drawing.Image myImage = System.Drawing.Image.FromFile(LogoVartualPath);
                hdnOriginalWidth.Value = myImage.Width.ToString();
                hdnOriginalHeight.Value = myImage.Height.ToString();

                myImage.Dispose();
                myImage.Dispose();

                string logoRootPath = RootPath + "/Upload/TempLogos/" + ProfileID + "/" + logoName;
                hdnImgURL.Value = logoRootPath + "?id=" + Guid.NewGuid();
                if (rbShortLogo.Checked)
                {
                    string tempShortLogoName = ProfileID + "_Short_thumb" + logoExtension;
                    Session["tempShortLogoName"] = tempShortLogoName;
                    //LogoResize(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoMaxAllowWidth")), Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoMaxAllowWidth")),
                    //    folderPath, tempShortLogoName, LogoVartualPath);

                    LogoResize(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoWidth")), Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoHeight")),
                        folderPath, tempShortLogoName, LogoVartualPath);

                    hdbTempShortLogoURL.Value = RootPath + "/Upload/TempLogos/" + ProfileID + "/" + tempShortLogoName + "?id=" + Guid.NewGuid(); ;
                }
                LogoModalPopup.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "BtnUpdateLogo_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                file.Dispose();
                utlObj = null;
            }
        }

        protected void btnCropLogo_OnClick(object sende, EventArgs e)
        {
            try
            {

                string fname = Session["logoName"].ToString();
                string fpath = Path.Combine(Server.MapPath("~/Upload/TempLogos/" + ProfileID.ToString()), fname);

                string logoExtension = "";
                GC.Collect();

                if (!System.IO.Directory.Exists(Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID);
                }



                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(fpath)))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                        Rectangle cropcords = new Rectangle(Convert.ToInt32(hdnx.Value),
                        Convert.ToInt32(hdny.Value),
                        Convert.ToInt32(hdnw.Value),
                        Convert.ToInt32(hdnh.Value));

                        string cfpath;
                        using (Bitmap bitMap = new Bitmap(cropcords.Width, cropcords.Height, img.PixelFormat))
                        {
                            Graphics grph = Graphics.FromImage(bitMap);
                            grph.DrawImage(img, new Rectangle(0, 0, bitMap.Width, bitMap.Height), cropcords, GraphicsUnit.Pixel);

                            logoExtension = "" + fname.Substring(fname.LastIndexOf('.'));


                            GC.Collect();
                            Response.Clear();
                            Response.ClearContent();
                            Response.Clear();
                            Response.Cache.SetExpires(DateTime.Now);
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            this.ViewState.Clear();

                            string originalLogoPath = "";
                            if (rbShortLogo.Checked)
                            {
                                //string folderPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID;
                                //string fileName = ProfileID + "_Short_thumb" + logoExtension;
                                //string newFileName = ProfileID + "_thumb" + logoExtension;
                                //originalLogoPath = folderPath + "\\" + fileName;
                                //cfpath = Path.Combine(originalLogoPath);
                                //if (File.Exists(originalLogoPath))
                                //{
                                //    File.Delete(originalLogoPath);
                                //}
                                //bitMap.Save(cfpath);

                                if (rbSystemResizeLogo.Checked)
                                {
                                    string TempLogoLocation = Server.MapPath("~") + "\\Upload\\TempLogos\\" + ProfileID + "\\" + Session["tempShortLogoName"].ToString();
                                    originalLogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;

                                    File.Copy(TempLogoLocation, originalLogoPath, true);
                                }
                                else
                                {
                                    //LogoResize(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoWidth")),
                                    //    Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoHeight")), folderPath, newFileName, cfpath);

                                    originalLogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                                    cfpath = Path.Combine(originalLogoPath);
                                    if (File.Exists(originalLogoPath))
                                    {
                                        File.Delete(originalLogoPath);
                                    }
                                    bitMap.Save(cfpath);
                                }
                            }
                            else
                            {
                                originalLogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                                cfpath = Path.Combine(originalLogoPath);
                                if (File.Exists(originalLogoPath))
                                {
                                    File.Delete(originalLogoPath);
                                }
                                bitMap.Save(cfpath);
                            }
                        }
                    }
                    ms.Flush();
                    ms.Close();
                    ms.Dispose();
                }

                string photoFileName = ProfileID + logoExtension;
                _objBus.UpdateBusinessProfileLogo(photoFileName, ProfileID, UserID, CUserID);
                if (rbShortLogo.Checked)
                    isShortLogo = true;
                _objBus.UpdateShortorLongLogo(UserID, isShortLogo);
                //lblLogoMsg.Text = "";

                var tempFileLog = Server.MapPath("~") + "\\Upload\\TempLogos\\" + ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                if (File.Exists(tempFileLog))
                {
                    File.Delete(tempFileLog);
                }

                if (IsResizeLogo == false)
                {
                    Session["LogoSuccess"] = "Your logo has been uploaded successfully.";
                }
                else
                {
                    Session["LogoSuccess"] = "Your logo has been uploaded successfully.";
                }


                // Save User Activity Log
                objCommonBLL.InsertUserActivityLog("has got a new profile picture", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                CreateLogoInImageGallery(logoExtension);

                //string reidrectUrl = Page.ResolveClientUrl("~/Business/Myaccount/ModifyLogo.aspx");
                //if (Request.QueryString["App"] != null)
                //    reidrectUrl = reidrectUrl + "?App=" + Request.QueryString["App"].ToString();
                //Response.Redirect(reidrectUrl);

                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.ViewState.Clear();
                LoadProfileLogo();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Business_MyAccount_ModifyLogo.aspx.cs", "btnCropLogo_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnResizeCancel_Click(object sender, EventArgs e)
        {
            if (IsResizeLogo == false)
            {
                DeleteLogo();
            }

            LogoModalPopup.Hide();
            lblMsg.Text = "";
        }


        private void LogoResize(int pWidth, int pHeight, string folderLocation, string LogoName, string oldLogoLocation)
        {
            try
            {
                GC.Collect();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.ViewState.Clear();


                string SavelogoLocation = folderLocation + "\\" + LogoName;

                if (!Directory.Exists(folderLocation))
                {
                    Directory.CreateDirectory(folderLocation);
                }

                if (File.Exists(oldLogoLocation))
                {
                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(oldLogoLocation);
                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                    actResize.Width = pWidth;
                    actResize.Height = pHeight;
                    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    uploadedImage.Actions.Add(actResize);
                    actResize = null;
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                    imgDraw.Elements.Add(uploadedImage);
                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 90;
                    uploadedImage = null;
                    //Now, save the output image on disk

                    if (File.Exists(SavelogoLocation))
                    {
                        File.Delete(SavelogoLocation);
                    }
                    imgDraw.Save(SavelogoLocation);
                    imgDraw.Dispose();

                }

                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.ViewState.Clear();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MemberInformation.aspx.cs", "LogoResize", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void lnkAboutUs_OnClick(object sender, EventArgs e)
        {
            Session["buttontype"] = "aboutus";
            //lblTitle.Text = objApp.GetMobileAppSettingTabName(UserID, "AboutUs", DomainName);
            LoadProfileDescription();
            lnkHome.CssClass = "btn-tab";
            lnkAboutUs.CssClass = "btn-tab active";
        }

        protected void lnkHome_OnClick(object sender, EventArgs e)
        {
            Session["buttontype"] = "home";
            //lblTitle.Text = objApp.GetMobileAppSettingTabName(UserID, "Home", DomainName);
            LoadProfileDescription();
            lnkHome.CssClass = "btn-tab active";
            lnkAboutUs.CssClass = "btn-tab";
        }


    }
}