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
using System.Text.RegularExpressions;
using System.Web.Services;

public partial class Business_MyAccount_ModifyUserDetails : BaseWeb
{
    public static int UserID = 0;

    public static int ProfileID = 0;

    UtilitiesBLL utlObj = new UtilitiesBLL();
    CommonBLL objCommon = new CommonBLL();
    Consumer conobj = new Consumer();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    string DomainName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                if (Session["userid"] != null)
                {
                    UserID = Convert.ToInt32(Session["userid"]);
                    lblfirstname.Text = "<font color=green size=3><b>" + Session["firstname"].ToString() + "</B></font>";
                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                }
            }
            DomainName = Session["VerticalDomain"].ToString();
            
            if (!IsPostBack)
            {
                BindCountry();
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "NameForDisplay")
                            hdnVerticalName.Value = row[1].ToString();
                    }
                }
                BusinessBLL objBusinessBLL = new BusinessBLL();
                DataTable dtprofiledetails = objBusinessBLL.GetProfileDetailsByProfileID(ProfileID);
                if (dtprofiledetails.Rows.Count > 0)
                {
                    hdnIsLiteVersion.Value = Convert.ToString(dtprofiledetails.Rows[0]["IsLiteVersion"]);
                }
                //ListItem item = new ListItem();
                //item.Value = "0";
                //item.Text = "-Select Country-";
                //ddlCountry.Items.Add(item);
                //ListItem item1 = new ListItem();
                //item1.Value = "1";
                //item1.Text = "USA";
                //ddlCountry.Items.Add(item1);
                //ddlCountry.SelectedIndex = 1;
                Consumer conobj = new Consumer();
                DataTable dtobj = conobj.GetUserDetails(Session["username"].ToString(), DomainName);
                txtusername.Text = Session["username"].ToString();
                if (dtobj != null)
                {
                    if (dtobj.Rows.Count > 0)
                    {
                        // Populate the existing values
                        PopulateUserDetails(dtobj);
                    }
                    else
                        lblmsg.Text = "<font color=red face=arial size=2> There are no User details available right now.</font>";
                }
                else
                {
                    lblmsg.Text = "<font color=red face=arial size=2> There are no User details right now.</font>";
                }

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    UpdatePanel2.Visible = true;
                    UpCheck.Visible = false;
                    lblerrormessage.Text = "<font face=arial size=2>You do not have permission to access account details.</font>";
                }
                //ends here           
            }


            if (Convert.ToString(Session["successMSG"]) != string.Empty)
            {
                lblmsg.Text = Convert.ToString(Session["successMSG"]);
                Session["successMSG"] = null;
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "Page_Load", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private void BindCountry()
    {
        DataTable dtCountry = new DataTable();
        dtCountry = objCommon.GetCountries();
        ddlCountry.DataSource = dtCountry;
        ddlCountry.DataTextField = "Country_Name";
        ddlCountry.DataValueField = "Country_Name";
        ddlCountry.DataBind();

        //ddlCountry.Items.Insert(0, "Select Country");
    }

    private void PopulateUserDetails(DataTable dtobj)
    {
        try
        {
            DataTable dtobj1 = new DataTable();
            //User details
            hdnCommEmail.Value = dtobj.Rows[0]["User_email"].ToString();
            txtFirstName.Text = dtobj.Rows[0]["Firstname"].ToString();
            txtLastName.Text = dtobj.Rows[0]["Lastname"].ToString();
            txtAddress1.Text = dtobj.Rows[0]["User_address1"].ToString();
            txtAddress2.Text = dtobj.Rows[0]["User_address2"].ToString();
            txtCity.Text = dtobj.Rows[0]["User_city"].ToString();
            txtState.Text = dtobj.Rows[0]["User_state"].ToString();
            ddlCountry.SelectedValue = dtobj.Rows[0]["User_Country"].ToString();
            //Issue No:157
            //dtobj1 = utlObj.GetAllStatesByCountry("USA");
            //drpState.DataSource = dtobj1;
            //drpState.DataTextField = "State_name";
            //drpState.DataValueField = "State_name";
            //drpState.DataBind();
            //if (dtobj.Rows[0]["User_state"].ToString().Length > 0)
            //    drpState.SelectedValue = dtobj.Rows[0]["User_state"].ToString();
            txtZipCode.Text = dtobj.Rows[0]["User_zipcode"].ToString();
            string phonenumber = dtobj.Rows[0]["User_phone"].ToString();
            txtPhone.Text = phonenumber.ToString();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "PopulateUserDetails", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void UserUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string Email = string.Empty;
            string UserName = string.Empty;
            string Password = string.Empty;
            string FirstName = string.Empty;
            string LastName = string.Empty;
            string PasswordQuestrion1 = string.Empty;
            string PasswordAnswer1 = string.Empty;
            string PasswordQuestrion2 = string.Empty;
            string PasswordAnswer2 = string.Empty;
            string Address1 = string.Empty;
            string Address2 = string.Empty;
            string City = string.Empty;
            string State = string.Empty;
            string Country = string.Empty;
            string ZipCode = string.Empty;
            string Phone = string.Empty;
            int RoleId = 0;
            string Status = string.Empty;
            string tmpfirstname = string.Empty;
            Email = hdnCommEmail.Value;
            if (Session["username"] != null)
            {
                UserName = Session["username"].ToString();
            }
            FirstName = txtFirstName.Text.Trim();
            LastName = txtLastName.Text.Trim();
            Address1 = txtAddress1.Text.Trim();
            Address2 = txtAddress2.Text.Trim();
            City = txtCity.Text.Trim();
            State = txtState.Text.Trim();
            Country = ddlCountry.SelectedItem.Text.ToString();
            ZipCode = txtZipCode.Text.Trim();
            Phone = txtPhone.Text.Trim();
            RoleId = (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business;
            Status = USPDHUBBLL.UtilitiesBLL.Statuses.Active.ToString();

            DataTable dtobj = new DataTable();
            int addflag = 0;

            //Snag it changes , suresh Dated June 1st 2009
            if (Session["UserID"] != null)
            {
                UserID = Convert.ToInt32(Session["UserID"]);
            }
            if (UserID > 0) // Consumer registration Updated successfully.
            {
                addflag = conobj.ModifyConsumer(UserName, Email, FirstName, LastName, RoleId, true, Address1, Address2, City, State, Country, ZipCode, Phone, UserID, Status, ProfileID);
                tmpfirstname = FirstName;
                tmpfirstname = tmpfirstname.Substring(0, 1).ToUpper() + tmpfirstname.Substring(1, tmpfirstname.Length - 1);
                Session["BusinessUserFirstName"] = tmpfirstname;

                lblmsg.Text = "<font color=green face=arial size=2><b>" + tmpfirstname + ", your contact information has been updated.</b></font>";
                //
            }
            else
            {
                lblmsg.Text = "<Font face=arial color=red size=2> There is problem in Update. Please try again..!";
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "UserUpdate_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }



    protected void UserCancel_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

    protected void btndashboard_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

    protected void btnChangeloginID_OnClick(object sender, EventArgs e)
    {
        txtExistLoginID.Text = txtusername.Text;
        txtEmail.Text = "";
        LoginIDModal.Show();
    }

    protected void btnLoginIDUpdate_OnClick(object sender, EventArgs e)
    {
        try
        {
            //Session["username"]
            conobj.ChangeloginID(txtEmail.Text.Trim(), UserID);
            Session["successMSG"] = "<font color=green face=arial size=2><b>" + txtEmail.Text + ", your login id has been updated.</b></font>";
            Session["username"] = txtEmail.Text.Trim();
            txtusername.Text = txtEmail.Text.Trim();

            string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/ModifyUserDetails.aspx?flag=1");
            Response.Redirect(urlinfo);

        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "btnLoginIDUpdate_OnClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    [WebMethod]
    public new static string ServerSidefill(string emid)
    {
        BusinessBLL objWow = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();

        string typevalue = "";
        try
        {
            if (emid.Length > 0)
            {
                Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!rEMail.IsMatch(emid))
                {
                    typevalue = "3";
                }
                else
                {
                    try
                    {
                        string vertical = "";
                        string Country = "";

                        BusinessBLL objBusinessBLL = new BusinessBLL();
                        var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(HttpContext.Current.Session["ProfileID"]));
                        vertical = Convert.ToString(dtProfileDetails.Rows[0]["Vertical_Name"]);
                        Country = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);

                        int countUser;
                        countUser = objWow.CheckUserNameandPasswordForVaildUser(emid, vertical, Country);
                        int count = objAgency.ValidateAgencyEmailID(emid, vertical, Country);
                        if (count > 0)
                            typevalue = "4";
                        else
                        {
                            if (countUser == 0)
                            {
                                typevalue = "1";
                            }
                            else
                            {
                                typevalue = "2";
                            }
                        }
                    }
                    catch
                    {
                        typevalue = "3";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "ServerSidefill", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return typevalue;
    }
}
