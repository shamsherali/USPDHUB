using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web.Services;
using System.Reflection;
using System.Collections.Specialized;
using System.Text;

namespace USPDHUB.Admin
{
    public partial class CustomerServiceNew : System.Web.UI.Page
    {
        public int CsrID = 0;
        public int ProfileID = 0;
        public int UserID = 0;
        public int CheckRenewalValue = 0;
        public int AssociateID = 0;


        public string Tmpvarpath = string.Empty;
        public string Htprefval = string.Empty;
        public int Passwordchanged = 3;
        public string LoginCokValue = string.Empty;
        public string Urlinfo = string.Empty;
        BusinessBLL busobj = new BusinessBLL();
        Consumer conobj = new Consumer();
        public bool Redirectflag = true;
        public string ProfileState = string.Empty;
        public string ChangeName = string.Empty;
        public string ProfileCity = string.Empty;
        public string ProfileStateCode = string.Empty;
        public string StateCode = string.Empty;
        public string ProfileCodeChek;
        public string NewSite = string.Empty;
        public string Browserses = string.Empty;
        public string Renew = string.Empty;
        DataTable dtobj = new DataTable();
        public string Userid = string.Empty;
        AdminBLL adminobj = new AdminBLL();
        CommonBLL objCommon = new CommonBLL();
        Consumer conObj = new Consumer();
        AgencyBLL objAgency = new AgencyBLL();

        public DataTable Dtsales = new DataTable();
        public double Subamt = 0;
        public double Billamt = 0;
        public static int SortStrigCount = 0;
        public static string SortString = string.Empty;

        public int UserId;
        public string EmailFrom = string.Empty;
        public string EmailTo = string.Empty;
        public string Subject = string.Empty;
        public string Message = string.Empty;
        public string getSubAppStatus = string.Empty;
        public string[] splitSubAppUserID;
        public bool isShortLogo = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CsrID = Convert.ToInt32(Session["adminuserid"]);

                lblLogoMsg.Text = "";

                if (!IsPostBack)
                {
                    lblmsg.Text = "";
                    lblerr.Text = "";
                    lblerror.Text = "";
                    pnlCustomerDetails.Visible = false;
                    NotesTable.Visible = false;
                    if ((Request.QueryString["frm"] != null) && (Request.QueryString["frm"] != null))
                    {
                        DataTable dtobj = new DataTable();
                        pnlCustomerDetails.Visible = true;

                        CustomersPanel.Visible = false;
                        NotesDatalist.Visible = true;
                        NotesTable.Visible = true;


                        int userid = Convert.ToInt32(Request.QueryString["frm"].ToString());
                        dtobj = adminobj.GetMemberDetails(userid);
                        #region assigningValues
                        // *** start of issue 1246 ***//
                        if (dtobj.Rows.Count != 0)
                        {
                            // *** end of issue 1246 ***//
                            lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                            BindAssociatesUsers();


                            lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                            lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                            lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                            lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                            lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                            lblcity.Text = dtobj.Rows[0]["City"].ToString();
                            lblstate.Text = dtobj.Rows[0]["State"].ToString();
                            lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                            lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                            lblemail.Text = dtobj.Rows[0]["User_email"].ToString();

                            getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                            splitSubAppUserID = getSubAppStatus.Split(',');
                            lblSubApp.Text = splitSubAppUserID[0];
                            lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                            if (lblSubApp.Text == "Yes")
                                lnkUserID.Text = splitSubAppUserID[1];

                            pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                            lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                            lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                            lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                            lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                            lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();
                            if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                            {
                                if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                                {
                                    lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                                }
                            }

                            lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                            lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                            if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                            {
                                lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                                DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                            }
                            else
                                lbllastlogin.Text = "";

                            if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                            {
                                lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                            }
                            lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                            ShowButtons();
                            BindPinCode();
                            if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                            {
                                if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                                {
                                    lblremainingdays.ForeColor = System.Drawing.Color.Red;
                                    lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                                }
                                else
                                {
                                    lblremainingdays.ForeColor = System.Drawing.Color.Black;
                                    lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                                }
                            }
                            else
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Black;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }

                            lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                            lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                            lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                            lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                            if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                                Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                            {
                                lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                            }
                            else
                                lblExpiredDatecc.Text = "";
                            hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                        #endregion assingningValues

                            FillNotes1(userid);
                            if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                            {
                                btnTestAccount.Text = "Change To Normal Account";
                            }
                            else
                            {
                                btnTestAccount.Text = "Change To Test Account";
                            }
                        }
                    }
                    #region Getting Sales Persons
                    Dtsales = adminobj.GetSalesPerson();
                    ddlReferBy.DataSource = Dtsales;
                    ddlReferBy.DataTextField = "Sales_Name";
                    ddlReferBy.DataValueField = "SalePerson_ID";
                    ddlReferBy.DataBind();
                    ddlReferBy.Items.Insert(0, new ListItem(ConfigurationManager.AppSettings.Get("ReferBy"), "0"));
                    #endregion
                    // *** end of issue 1246 ***//
                    if (Session["Message"] != null)
                    {
                        lblerror.Text = "<Font face=arial color=green size=2>" + Session["Message"].ToString() + "</font>";
                        Session["Message"] = null;
                    }


                    if (Request.QueryString["SearchSelectedValue"] != null)
                    {
                        drpcategory.SelectedValue = EncryptDecrypt.DESDecrypt(Request.QueryString["SearchSelectedValue"].ToString());
                        txtcategory.Text = EncryptDecrypt.DESDecrypt(Request.QueryString["SearchInputValue"].ToString());
                        RemoveQuerystrings();
                        GetSearchDetails();
                    }
                    if (Request.QueryString["SelectedValue"] != null)
                    {
                        drpcategory.SelectedValue = EncryptDecrypt.DESDecrypt(Request.QueryString["SelectedValue"].ToString());
                        txtcategory.Text = EncryptDecrypt.DESDecrypt(Request.QueryString["SelectedText"].ToString());
                        RemoveQuerystrings();
                        GetSearchDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindPinCode()
        {
            try
            {
                hdnUserAppName.Value = "";
                trPinCode.Visible = false;
                if (hdnMemberID.Value != "")
                {
                    int selUserId = Convert.ToInt32(hdnMemberID.Value);
                    DataTable dtPinCode = objAgency.GetAppPinCode(selUserId);
                    if (dtPinCode.Rows.Count > 0 && !string.IsNullOrEmpty(dtPinCode.Rows[0]["App_Name"].ToString()))
                    {
                        trPinCode.Visible = true;
                        lblAppPinCode.Text = dtPinCode.Rows[0]["Password_Pin"].ToString();
                        hdnUserAppName.Value = dtPinCode.Rows[0]["App_Name"].ToString();
                    }
                }
                btnRemovePinCode.Visible = false;
                if (!string.IsNullOrEmpty(lblAppPinCode.Text))
                {
                    btnShowPinCode.Text = "Update";
                    btnRemovePinCode.Visible = true;
                }
                else
                    btnShowPinCode.Text = "Create";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BindPinCode", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void RemoveQuerystrings()
        {
            try
            {
                PropertyInfo isreadonly =
             typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
             "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("SearchSelectedValue");
                this.Request.QueryString.Remove("SearchInputValue");
                if (this.Request.QueryString.ToString() != string.Empty)
                {
                    string[] separateURL = this.Request.QueryString.ToString().Split('?');
                    NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]); // 
                    queryString.Remove("SearchSelectedValue");
                    queryString.Remove("SearchInputValue");
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "RemoveQuerystrings", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            GetSearchDetails();
        }

        private void GetSearchDetails()
        {
            try
            {
                lblmsg.Text = "";
                int selectedCategoryID = Convert.ToInt32(drpcategory.SelectedValue.ToString());
                Session["MailingUserID"] = null;
                if (selectedCategoryID == 0)
                {
                    pnlCustomerDetails.Visible = false;
                    CustomersPanel.Visible = false;
                    NotesTable.Visible = false;

                    lblmsg.Text = "Please enter Cumstomer Details";
                }
                if (selectedCategoryID == 1)
                #region MemberID
                {
                    DataTable dtobj = new DataTable();
                    int queryUserID = Convert.ToInt32(txtcategory.Text.ToString());
                    dtobj = adminobj.GetMemberDetails(queryUserID);
                    if (chkAssociteUser.Checked == false && dtobj.Rows.Count > 0)
                    {
                        btnBillingHistory.Visible = true;
                        DataRow[] rows = dtobj.Select("Active_flag<>0 and Status_flag<>0");
                        if (rows.Count() > 0)
                        {
                            dtobj = rows.CopyToDataTable();
                        }
                        else
                        {
                            dtobj = new DataTable();
                        }
                    }
                    //For Differnet Color Demo users
                    if (dtobj.Rows.Count > 0)
                    {
                        // True Means Demo Users
                        if (Convert.ToString(dtobj.Rows[0]["IsArchived"]).ToString().ToLower() == "true")
                        {
                            lblMemberID.CssClass = "demousers";
                            lblcompname.CssClass = "demousers";
                        }
                        else // Real Users
                        {
                            lblMemberID.CssClass = "realusers1";
                            lblcompname.CssClass = "realusers1";
                        }
                    }


                    if (dtobj.Rows.Count == 1)
                    {
                        //Add Activity Button Enable
                        hdnPID.Value = dtobj.Rows[0]["Profile_ID"].ToString();
                        hdnUID.Value = dtobj.Rows[0]["USER_ID"].ToString();
                        btnAddActivity.Visible = true;


                        pnlCustomerDetails.Visible = true;
                        #region assigningValues

                        lblPSType.Text = GetProfileSubTypeValue(Convert.ToInt32(dtobj.Rows[0]["ProfileSubTypeID"]));
                        lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                        hdnMemberID.Value = lblMemberID.Text;
                        BindAssociatesUsers();
                        lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                        lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                        lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                        lblcity.Text = dtobj.Rows[0]["City"].ToString();
                        lblstate.Text = dtobj.Rows[0]["State"].ToString();
                        lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                        lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                        lblemail.Text = dtobj.Rows[0]["User_email"].ToString();

                        getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                        splitSubAppUserID = getSubAppStatus.Split(',');
                        lblSubApp.Text = splitSubAppUserID[0];
                        lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                        if (lblSubApp.Text == "Yes")
                            lnkUserID.Text = splitSubAppUserID[1];

                        pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                        lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                        lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                        lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                        lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                        lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();
                        lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                        ShowButtons();
                        BindPinCode();
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                        {
                            if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                            {
                                lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                                //added code by 31-01-2013 logictree
                                HyperEnable.Visible = false;
                            }
                        }
                        AssignSalesPersonDetails_RecurringDetails(dtobj);
                        lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                        lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                        hdnLoginName.Value = lblloginname.Text;

                        if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                        {
                            lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                            DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                        }
                        else
                            lbllastlogin.Text = "";
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                        {
                            lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                        }

                        if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                        {
                            if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Red;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                            else
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Black;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                        }
                        else
                        {
                            lblremainingdays.ForeColor = System.Drawing.Color.Black;
                            lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                        }
                        lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                        lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                        lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                        lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                        Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                        {
                            lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                        }
                        else
                            lblExpiredDatecc.Text = "";
                        hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                        #endregion assingningValues
                        FillNotes();
                        if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                        {
                            btnTestAccount.Text = "Change To Normal Account";
                        }
                        else
                        {
                            btnTestAccount.Text = "Change To Test Account";
                        }
                        NotesTable.Visible = true;
                        CustomersPanel.Visible = false;
                        NotesDatalist.Visible = true;

                        BindAssociatesUsers();

                        #region When Search with Associate below code also excuted

                        if (chkAssociteUser.Checked == true && dtobj.Rows.Count > 0)
                        {
                            DataTable dtParentDetails = new DataTable("dtp");
                            if (Convert.ToString(dtobj.Rows[0]["SuperAdmin_ID"]) != string.Empty && chkAssociteUser.Checked == true)
                            {
                                dtParentDetails = adminobj.GetMemberDetails(Convert.ToInt32(dtobj.Rows[0]["SuperAdmin_ID"]));

                                hdnMemberID.Value = dtParentDetails.Rows[0]["User_ID"].ToString();
                                hdnLoginName.Value = dtParentDetails.Rows[0]["LoginName"].ToString();


                                lblcompname.Text = dtParentDetails.Rows[0]["ProfileName"].ToString();
                                lblContname.Text = dtParentDetails.Rows[0]["ContactName"].ToString();
                                lblProfName.Text = dtParentDetails.Rows[0]["ProfileName"].ToString();
                                lbladdress1.Text = dtParentDetails.Rows[0]["Address1"].ToString();
                                lbladdress2.Text = dtParentDetails.Rows[0]["Address2"].ToString();
                                lblcity.Text = dtParentDetails.Rows[0]["City"].ToString();
                                lblstate.Text = dtParentDetails.Rows[0]["State"].ToString();
                                lblCountry.Text = dtParentDetails.Rows[0]["Country"].ToString();
                                lblzipcode.Text = dtParentDetails.Rows[0]["Zip"].ToString();

                                pblphone.Text = dtParentDetails.Rows[0]["PhoneNo1"].ToString();
                                lblfax.Text = dtParentDetails.Rows[0]["Fax"].ToString();
                                //lblfirstname.Text = dtParentDetails.Rows[0]["Firstname"].ToString();
                                //lbllastname.Text = dtParentDetails.Rows[0]["Lastname"].ToString();
                                lblstatus.Text = dtParentDetails.Rows[0]["MemberStatus"].ToString();
                                lbllevel.Text = dtParentDetails.Rows[0]["MembershipLevel"].ToString();
                                lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);

                                ShowButtons();
                                BindPinCode();
                                if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                                {
                                    if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                                    {
                                        lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                                        //added code by 31-01-2013 logictree
                                        HyperEnable.Visible = false;
                                    }
                                }
                                AssignSalesPersonDetails_RecurringDetails(dtParentDetails);

                                lblrenewdate.Text = dtParentDetails.Rows[0]["RenewalDate"].ToString();
                                lblsubscpstartdate.Text = dtParentDetails.Rows[0]["SubscriptionStartDate"].ToString();
                                lblVertical.Text = dtParentDetails.Rows[0]["Vertical_Name"].ToString();
                                lblamount.Text = dtParentDetails.Rows[0]["PaidAmount"].ToString();
                                if (Convert.ToString(dtParentDetails.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtParentDetails.Rows[0]["cc_expire_year"]) != "" &&
                                    Convert.ToString(dtParentDetails.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtParentDetails.Rows[0]["cc_expire_year"]) != "0")
                                {
                                    lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                                }
                                else
                                    lblExpiredDatecc.Text = "";
                                hdnTurnOff.Value = dtParentDetails.Rows[0]["IsTurnOnEmail"].ToString();

                                if (dtParentDetails.Rows[0]["TestAccount"].ToString().Trim() != "")
                                {
                                    btnTestAccount.Text = "Change To Normal Account";
                                }
                                else
                                {
                                    btnTestAccount.Text = "Change To Test Account";
                                }
                            }
                        }

                        #endregion


                    }
                    else
                    {
                        if (dtobj.Rows.Count == 0)
                        {
                            NotesTable.Visible = false;
                            pnlCustomerDetails.Visible = false;
                            CustomersPanel.Visible = false;
                            NotesDatalist.Visible = false;
                            btnUpgrade.Visible = false;
                            btnSponserAds.Visible = false;
                            btnAddActivity.Visible = false;
                            lblmsg.Text = "No Member exists with the provided details.";
                        }
                        else
                        {
                            //fillCustomerData();
                            pnlCustomerDetails.Visible = false;// Each customer indepth details
                            CustomersPanel.Visible = true;//Grid View
                            NotesTable.Visible = false;
                            NotesDatalist.Visible = false;
                            CustomersGridView.DataSource = dtobj;
                            CustomersGridView.DataBind();
                            //Add Activity Button Enable
                            hdnPID.Value = dtobj.Rows[0]["Profile_ID"].ToString();
                            hdnUID.Value = dtobj.Rows[0]["USER_ID"].ToString();

                            btnUpgrade.Visible = false;
                            btnSponserAds.Visible = false;
                            //btnAddActivity.Visible = false;
                        }
                    }
                #endregion
                }
                else
                # region
                {
                    DataTable dtobjUsers = new DataTable();
                    string queryUser = txtcategory.Text;
                    int queryID = Convert.ToInt32(drpcategory.SelectedValue);
                    dtobjUsers = adminobj.GetMemberDetails(queryID, queryUser);

                    if (chkAssociteUser.Checked == false && dtobjUsers.Rows.Count > 0)
                    {
                        btnBillingHistory.Visible = true;
                        DataRow[] rows = dtobjUsers.Select("Active_flag<>0 and Status_flag<>0");
                        if (rows.Count() > 0)
                        {
                            dtobjUsers = rows.CopyToDataTable();
                        }
                        else
                        {
                            dtobjUsers = new DataTable();
                        }
                    }

                    if (dtobjUsers.Rows.Count == 1)
                    {
                        //Add Activity Button Enable
                        hdnPID.Value = dtobjUsers.Rows[0]["Profile_ID"].ToString();
                        hdnUID.Value = dtobjUsers.Rows[0]["USER_ID"].ToString();
                        btnAddActivity.Visible = true;


                        #region assigningValues
                        DataTable dtobj = new DataTable();
                        // *** Issue 1170 *** //
                        dtobj = adminobj.GetMemberDetails(Convert.ToInt32(dtobjUsers.Rows[0]["User_ID"].ToString()));

                        lblPSType.Text = GetProfileSubTypeValue(Convert.ToInt32(dtobj.Rows[0]["ProfileSubTypeID"]));
                        lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                        hdnMemberID.Value = lblMemberID.Text;

                        BindAssociatesUsers();
                        lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                        lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                        lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                        lblcity.Text = dtobj.Rows[0]["City"].ToString();
                        lblstate.Text = dtobj.Rows[0]["State"].ToString();
                        lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                        lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                        lblemail.Text = dtobj.Rows[0]["User_email"].ToString();

                        getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                        splitSubAppUserID = getSubAppStatus.Split(',');
                        lblSubApp.Text = splitSubAppUserID[0];
                        lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                        if (lblSubApp.Text == "Yes")
                            lnkUserID.Text = splitSubAppUserID[1];

                        pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                        lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                        lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                        lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                        lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                        lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();

                        lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                        ShowButtons();
                        BindPinCode();
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                        {
                            if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                            {
                                lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                                //added code by 31-01-2013 logictree
                                HyperEnable.Visible = false;
                            }
                        }
                        AssignSalesPersonDetails_RecurringDetails(dtobj);
                        lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                        hdnLoginName.Value = lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                        {
                            lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                            DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                        }
                        else
                            lbllastlogin.Text = "";
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                        {
                            lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                        }

                        if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                        {
                            if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Red;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                            else
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Black;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                        }
                        else
                        {
                            lblremainingdays.ForeColor = System.Drawing.Color.Black;
                            lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                        }



                        lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                        lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                        lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                        lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                                    Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                        {
                            lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                        }
                        else
                            lblExpiredDatecc.Text = "";
                        hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                        if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                        {
                            btnTestAccount.Text = "Change To Normal Account";
                        }
                        else
                        {
                            btnTestAccount.Text = "Change To Test Account";
                        }
                        #endregion assingningValues
                        pnlCustomerDetails.Visible = true;
                        CustomersPanel.Visible = false;
                        NotesTable.Visible = true;
                        NotesDatalist.Visible = true;
                        FillNotes1(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));

                        #region When Search with Associate below code also excuted

                        if (chkAssociteUser.Checked == true && dtobj.Rows.Count > 0)
                        {
                            DataTable dtParentDetails = new DataTable("dtp");
                            if (Convert.ToString(dtobj.Rows[0]["SuperAdmin_ID"]) != string.Empty && chkAssociteUser.Checked == true)
                            {
                                dtParentDetails = adminobj.GetMemberDetails(Convert.ToInt32(dtobj.Rows[0]["SuperAdmin_ID"]));

                                hdnMemberID.Value = dtParentDetails.Rows[0]["User_ID"].ToString();
                                hdnLoginName.Value = dtParentDetails.Rows[0]["LoginName"].ToString();


                                lblcompname.Text = dtParentDetails.Rows[0]["ProfileName"].ToString();
                                lblContname.Text = dtParentDetails.Rows[0]["ContactName"].ToString();
                                lblProfName.Text = dtParentDetails.Rows[0]["ProfileName"].ToString();
                                lbladdress1.Text = dtParentDetails.Rows[0]["Address1"].ToString();
                                lbladdress2.Text = dtParentDetails.Rows[0]["Address2"].ToString();
                                lblcity.Text = dtParentDetails.Rows[0]["City"].ToString();
                                lblstate.Text = dtParentDetails.Rows[0]["State"].ToString();
                                lblCountry.Text = dtParentDetails.Rows[0]["Country"].ToString();
                                lblzipcode.Text = dtParentDetails.Rows[0]["Zip"].ToString();

                                pblphone.Text = dtParentDetails.Rows[0]["PhoneNo1"].ToString();
                                lblfax.Text = dtParentDetails.Rows[0]["Fax"].ToString();
                                //lblfirstname.Text = dtParentDetails.Rows[0]["Firstname"].ToString();
                                //lbllastname.Text = dtParentDetails.Rows[0]["Lastname"].ToString();
                                lblstatus.Text = dtParentDetails.Rows[0]["MemberStatus"].ToString();
                                lbllevel.Text = dtParentDetails.Rows[0]["MembershipLevel"].ToString();
                                lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);

                                ShowButtons();
                                BindPinCode();
                                if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                                {
                                    if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                                    {
                                        lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                                        //added code by 31-01-2013 logictree
                                        HyperEnable.Visible = false;
                                    }
                                }
                                AssignSalesPersonDetails_RecurringDetails(dtParentDetails);

                                lblrenewdate.Text = dtParentDetails.Rows[0]["RenewalDate"].ToString();
                                lblsubscpstartdate.Text = dtParentDetails.Rows[0]["SubscriptionStartDate"].ToString();
                                lblVertical.Text = dtParentDetails.Rows[0]["Vertical_Name"].ToString();
                                lblamount.Text = dtParentDetails.Rows[0]["PaidAmount"].ToString();
                                if (Convert.ToString(dtParentDetails.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtParentDetails.Rows[0]["cc_expire_year"]) != "" &&
                                    Convert.ToString(dtParentDetails.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtParentDetails.Rows[0]["cc_expire_year"]) != "0")
                                {
                                    lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                                }
                                else
                                    lblExpiredDatecc.Text = "";
                                hdnTurnOff.Value = dtParentDetails.Rows[0]["IsTurnOnEmail"].ToString();

                                if (dtParentDetails.Rows[0]["TestAccount"].ToString().Trim() != "")
                                {
                                    btnTestAccount.Text = "Change To Normal Account";
                                }
                                else
                                {
                                    btnTestAccount.Text = "Change To Test Account";
                                }
                            }
                        }

                        #endregion

                    }
                    else
                    {
                        if (dtobjUsers.Rows.Count == 0)
                        {
                            NotesTable.Visible = false;
                            pnlCustomerDetails.Visible = false;
                            CustomersPanel.Visible = false;
                            NotesDatalist.Visible = false;

                            btnUpgrade.Visible = false;
                            btnSponserAds.Visible = false;
                            btnAddActivity.Visible = false;
                            lblmsg.Text = "No Member exists with the provided details";
                        }
                        else
                        {
                            //fillCustomerData();
                            pnlCustomerDetails.Visible = false;// Each customer indepth details
                            CustomersPanel.Visible = true;//Grid View
                            NotesTable.Visible = false;
                            NotesDatalist.Visible = false;
                            CustomersGridView.DataSource = dtobjUsers;
                            CustomersGridView.DataBind();
                            //Add Activity Button Enable
                            hdnPID.Value = dtobjUsers.Rows[0]["Profile_ID"].ToString();
                            hdnUID.Value = dtobjUsers.Rows[0]["USER_ID"].ToString();
                            btnUpgrade.Visible = false;
                            btnSponserAds.Visible = false;
                            //btnAddActivity.Visible = false;
                        }
                    }
                }
                # endregion
                string url = "/Admin/SponsorAdsPreview.aspx?userid=" + EncryptDecrypt.DESEncrypt(hdnUID.Value) + "&profileid=" + EncryptDecrypt.DESEncrypt(hdnPID.Value);
                btnSponserAds.NavigateUrl = url;
                string urlActivity = "/Admin/ActivityLog.aspx?PID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&UID=" + EncryptDecrypt.DESEncrypt(hdnUID.Value);
                btnAddActivity.NavigateUrl = urlActivity;
                string urlUpgrade = "/Admin/UpgradeSelectPayType.aspx?PID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&UID=" + EncryptDecrypt.DESEncrypt(hdnUID.Value) + "&SearchSelectedValue=" + EncryptDecrypt.DESEncrypt(drpcategory.SelectedValue) + "&SearchInputValue=" + EncryptDecrypt.DESEncrypt(txtcategory.Text.Trim());
                btnUpgrade.NavigateUrl = urlUpgrade;

            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "GetSearchDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindAssociatesUsers()
        {
            try
            {
                DataTable dtAssociates = new DataTable();
                dtAssociates = conObj.GetActiveAssociates(Convert.ToInt32(lblMemberID.Text.Trim()));
                if (dtAssociates.Rows.Count > 0)
                {
                    pnlAssociates.Visible = true;
                }

                ddlAssociates.DataSource = dtAssociates;
                ddlAssociates.DataTextField = "Username";
                ddlAssociates.DataValueField = "User_ID";

                ddlAssociates.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BindAssociatesUsers", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtndashboardClick(object sender, EventArgs e)
        {
            try
            {
                string urlinfo = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath").ToString() + "/Admin/Default.aspx";
                Response.Redirect(urlinfo);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtndashboardClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnNotes_Click(object sender, EventArgs e)
        {
            try
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AccessCodeButtonText();", true);
                string notes = TxtBxNotes.Text;
                string notesBy = txtNotesBy.Text;
                //string notes = Literal1.Text;
                int customerIDforNotes = Convert.ToInt32(lblMemberID.Text.ToString());
                DataTable adminUserDtobj = new DataTable();
                //adminUserDtobj = adminobj.GetAdminDetails(CsrID);
                adminUserDtobj = adminobj.GetAdminDetailsCheck(CsrID);
                string adminUserName = adminUserDtobj.Rows[0]["First_Name"].ToString();
                adminobj.InsertCustomerDeskNotesDetails(customerIDforNotes, notes, adminUserName, notesBy);
                FillNotes();
                pnlCustomerDetails.Visible = true;
                CustomersPanel.Visible = false;
                NotesTable.Visible = true;
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnNotes_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void FillNotes()
        {
            try
            {
                DataTable dtobj = new DataTable();
                int queryUserID = Convert.ToInt32(lblMemberID.Text.ToString());
                dtobj = adminobj.GetCustomerDeskNotesDetailsByUser_ID(queryUserID);
                string emptyTextBx = string.Empty;
                TxtBxNotes.Text = emptyTextBx;
                txtNotesBy.Text = emptyTextBx;
                DataList_CustomerNotes.DataSource = dtobj;
                DataList_CustomerNotes.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "FillNotes", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void FillNotes1(int userid)
        {
            try
            {
                DataTable dtobj = new DataTable();
                int queryUserID = userid;
                dtobj = adminobj.GetCustomerDeskNotesDetailsByUser_ID(queryUserID);
                string emptyTextBx = string.Empty;
                TxtBxNotes.Text = emptyTextBx;
                DataList_CustomerNotes.DataSource = dtobj;
                DataList_CustomerNotes.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "FillNotes1", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DrpcategorySelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtcategory.Text = "";
                if (drpcategory.SelectedValue != "0")
                {
                    pnlcategory.Visible = true;
                    pnlCustomerDetails.Visible = false;
                    CustomersPanel.Visible = false;
                    NotesDatalist.Visible = false;
                    NotesTable.Visible = false;
                    ModalPopupExtenderSendEmail.Hide();
                }
                else
                {
                    NotesDatalist.Visible = false;
                    pnlcategory.Visible = true;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "DrpcategorySelectedIndexChanged", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GridView_RowEditing(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkUser = sender as LinkButton;
                DataTable dtobj = new DataTable();
                pnlCustomerDetails.Visible = true;
                CustomersPanel.Visible = false;
                NotesDatalist.Visible = true;
                NotesTable.Visible = true;
                int userid = Convert.ToInt32(lnkUser.CommandArgument);
                dtobj = adminobj.GetMemberDetails(userid);
                hdnPID.Value = dtobj.Rows[0]["Profile_ID"].ToString();
                hdnUID.Value = dtobj.Rows[0]["User_ID"].ToString();
                #region assigningValues
                DataView dtview = new DataView(dtobj);
                dtview.Sort = "LastLoginDate DESC";
                dtobj = dtview.ToTable();
                if (dtobj.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtobj.Rows[0]["ProfileSubTypeID"].ToString()))
                        lblPSType.Text = GetProfileSubTypeValue(Convert.ToInt32(dtobj.Rows[0]["ProfileSubTypeID"].ToString()));
                }

                lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                BindAssociatesUsers();
                lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                lblcity.Text = dtobj.Rows[0]["City"].ToString();
                lblstate.Text = dtobj.Rows[0]["State"].ToString();
                lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                lblemail.Text = dtobj.Rows[0]["User_email"].ToString();
                hdnMemberID.Value = lblMemberID.Text;
                getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                splitSubAppUserID = getSubAppStatus.Split(',');
                lblSubApp.Text = splitSubAppUserID[0];
                lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                if (lblSubApp.Text == "Yes")
                    lnkUserID.Text = splitSubAppUserID[1];

                pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();
                if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                {
                    if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                    {
                        lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                    }
                }
                lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                {
                    lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                    DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                }
                else
                    lbllastlogin.Text = "";
                if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                {
                    lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                }
                lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                ShowButtons();
                BindPinCode();
                if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                {
                    if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                    {
                        lblremainingdays.ForeColor = System.Drawing.Color.Red;
                        lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                    }
                    else
                    {
                        lblremainingdays.ForeColor = System.Drawing.Color.Black;
                        lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                    }
                }
                else
                {
                    lblremainingdays.ForeColor = System.Drawing.Color.Black;
                    lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                }
                lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                                    Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                {
                    lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                }
                else
                    lblExpiredDatecc.Text = "";
                hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                #endregion assingningValues

                FillNotes1(userid);
                if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                {
                    btnTestAccount.Text = "Change To Normal Account";
                }
                else
                {
                    btnTestAccount.Text = "Change To Test Account";
                }
                AssignSalesPersonDetails_RecurringDetails(dtobj);
                string url = "/Admin/SponsorAdsPreview.aspx?userid=" + EncryptDecrypt.DESEncrypt(hdnUID.Value) + "&profileid=" + EncryptDecrypt.DESEncrypt(hdnPID.Value);
                btnSponserAds.NavigateUrl = url;
                string urlActivity = "/Admin/ActivityLog.aspx?PID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&UID=" + EncryptDecrypt.DESEncrypt(hdnUID.Value);
                btnAddActivity.NavigateUrl = urlActivity;
                string urlUpgrade = "/Admin/UpgradeSelectPayType.aspx?PID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&UID=" + EncryptDecrypt.DESEncrypt(hdnUID.Value) + "&SearchSelectedValue=" + EncryptDecrypt.DESEncrypt(drpcategory.SelectedValue) + "&SearchInputValue=" + EncryptDecrypt.DESEncrypt(txtcategory.Text.Trim());
                btnUpgrade.NavigateUrl = urlUpgrade;

            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "GridView_RowEditing", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ImcloseClick(object sender, ImageClickEventArgs e)
        {
        }
        protected void BtnMemberLoginClick(object sender, EventArgs e)
        {
            try
            {

                DataTable dtAssociates = new DataTable();
                dtAssociates = conObj.GetActiveAssociates(Convert.ToInt32(lblMemberID.Text.Trim()));
                if (dtAssociates.Rows.Count > 0)
                {
                    ddlAssociates.DataSource = dtAssociates;
                    ddlAssociates.DataTextField = "Username";
                    ddlAssociates.DataValueField = "User_ID";

                    ddlAssociates.DataBind();
                    pnlAssociates.Visible = true;
                }
                else
                {
                    GotoMemberDashboard(Convert.ToInt32(lblMemberID.Text.Trim()), 0);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnMemberLoginClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GotoMemberDashboard(int pMemberID, int pAssociateID)
        {
            try
            {
                Session["GoMemDashboard"] = "1";
                string username = string.Empty;
                string vertical = lblVertical.Text;
                username = lblloginname.Text;
                int loginMemberID = pMemberID;
                DataTable dtobj = new DataTable();
                int roleID = 0;
                if (username == ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    pnlCustomerDetails.Visible = true;
                    NotesTable.Visible = true;
                    NotesDatalist.Visible = true;
                    lblerror.Text = "You cannot login as a admin user.";
                }
                else
                {
                    Session["HelpCheck"] = "1";

                    dtobj = conobj.GetUserDetailsByID(loginMemberID);
                    if (dtobj != null)
                    {
                        if (dtobj.Rows.Count == 1)
                        {
                            if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                            {
                                Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                                try
                                {
                                    roleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);
                                }
                                catch (Exception /*ex*/)
                                { }

                                //int checkWizard = 0;

                                Urlinfo = "";
                                # region For Business User

                                if (roleID == (int)UtilitiesBLL.RoleTypes.Business)
                                {
                                    //Populate the profile details
                                    DataTable bustabobj = new DataTable();
                                    bustabobj = busobj.GetBusinessProfileByUserID(loginMemberID);
                                    if (bustabobj.Rows.Count == 0)
                                    {
                                        Redirectflag = false;
                                    }
                                    else if (bustabobj.Rows.Count == 1)
                                    {
                                        string domain = "";
                                        domain = objCommon.GetDomainNameByCountry(loginMemberID);
                                        DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                                        string userRootpath = "";
                                        if (dtConfigs.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in dtConfigs.Rows)
                                            {
                                                if (row[0].ToString() == "RootPath")
                                                    userRootpath = row[1].ToString();
                                            }
                                            if (pAssociateID != 0)
                                            {
                                                loginMemberID = pAssociateID;
                                            }
                                            string urlinforforroot = userRootpath + "/login.aspx?UID=" + EncryptDecrypt.DESEncrypt(loginMemberID.ToString()) + "&flag=1&al=1";
                                            string fullUrl = "window.open('" + urlinforforroot + "', '_blank', '')";
                                            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                                        }
                                    }
                                    else
                                    {
                                        Redirectflag = false;
                                    }
                                }
                                # endregion

                            }
                        }
                    }
                }
                pnlCustomerDetails.Visible = true;
                NotesTable.Visible = true;
                NotesDatalist.Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "GotoMemberDashboard", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetFreeUserDetails(string urlInfo)
        {
            try
            {
                // Check For Free User
                dtobj = busobj.GetUserDetailsByUserID(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
                        Session["Free"] = "1";
                    if (Renew == "1")
                    {
                        Session["Free"] = "1";
                        Session["Renewal"] = "1";
                    }
                    Urlinfo = urlInfo + "/Business/MyAccount/Default.aspx";
                    string fullUrl = "window.open('" + Urlinfo + "', '_blank', '')";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                }
                pnlCustomerDetails.Visible = true;
                NotesTable.Visible = true;
                NotesDatalist.Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "GetFreeUserDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnMemberSiteClick(object sender, EventArgs e)
        {
            try
            {
                string uname = string.Empty;
                uname = lblloginname.Text;
                string pid = string.Empty;
                DataTable dtobjMemberSite = new DataTable();
                if (uname == System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    pnlCustomerDetails.Visible = true;
                    NotesTable.Visible = true;
                    NotesDatalist.Visible = true;
                    lblerror.Text = "Admin user doesn't have the membership.";
                }
                else
                {
                    dtobjMemberSite = adminobj.GetProfileIDByUserEmail(uname, lblVertical.Text);
                    if (dtobjMemberSite != null)
                        pid = dtobjMemberSite.Rows[0]["profile_id"].ToString();
                    Urlinfo = ConfigurationManager.AppSettings.Get("OuterRootURL") + "/profiles/Default.aspx?PID=" + pid;
                    string fullUrl = "window.open('" + Urlinfo + "', '_blank', '')";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                }
                pnlCustomerDetails.Visible = true;
                NotesTable.Visible = true;
                NotesDatalist.Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnMemberSiteClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnEmailClick(object sender, EventArgs e)
        {
            try
            {
                string username = string.Empty;
                username = lblloginname.Text;
                int loginMemberID = Convert.ToInt32(lblMemberID.Text);
                DataTable dtobj = new DataTable();
                if (username == System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    pnlCustomerDetails.Visible = true;
                    NotesTable.Visible = true;
                    NotesDatalist.Visible = true;
                    lblerror.Text = "You cannot send an email to admin user.";
                }
                else
                {
                    Session["HelpCheck"] = "1";

                    dtobj = conobj.GetUserDetailsByID(loginMemberID);
                    if (dtobj != null)
                    {
                        if (dtobj.Rows.Count == 1)
                        {
                            if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                            {
                                Session["MailingUserID"] = dtobj.Rows[0]["User_ID"].ToString();
                            }
                        }
                    }
                    // *** start of issue 1246  ***//
                    if (Session["MailingUserID"] != null)
                    {
                        txtSendEmailTo.Text = "";
                        txtEmailSubject.Text = "";
                        txtNotes.Text = "";
                        UserId = Convert.ToInt32(Session["MailingUserID"].ToString());
                        dtobj = adminobj.GetUserDetailsByID(UserId);
                        txtSendEmailTo.Text = dtobj.Rows[0]["Username"].ToString();
                        ModalPopupExtenderSendEmail.Show();
                    }
                    if (Session["adminuserid"] == null)
                    {
                        string urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx?sflag=1");
                        Response.Redirect(urlinfo);
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnEmailClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "AccessCodeButtonText()", true);
        }
        protected void BtnSendEmailClick(object sender, EventArgs e)
        {
            try
            {
                string mailedflag1 = string.Empty;
                int lblUserID = Convert.ToInt32(lblMemberID.Text);
                EmailTo = txtSendEmailTo.Text.TrimEnd(',');
                Subject = txtEmailSubject.Text.TrimEnd(',');
                Message = txtNotes.Text.TrimEnd(',');
                mailedflag1 = SendCsrEmail(lblUserID, EmailTo, Subject, Message);
                if (mailedflag1 == "SUCCESS")
                {
                    lblmsg.Text = "Your test mail had sent successfully.";
                }
                else
                {
                    lblmsg.Text = "we apologize that this Email Sending is Failed.";
                }
                txtSendEmailTo.Text = "";
                txtEmailSubject.Text = "";
                txtNotes.Text = "";
                ModalPopupExtenderSendEmail.Hide();
                pnlCustomerDetails.Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnSendEmailClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "AccessCodeButtonText()", true);
        }
        protected void BtnCancelClick(object sender, EventArgs e)
        {
            txtEmailSubject.Text = "";
            txtNotes.Text = "";
            txtSendEmailTo.Text = "";
            pnlCustomerDetails.Visible = true;
            ModalPopupExtenderSendEmail.Hide();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "AccessCodeButtonText()", true);
        }
        public string SendCsrEmail(int lblUserID, string emailTo, string subject, string message)
        {
            UtilitiesBLL objUtil = new UtilitiesBLL();
            try
            {
                string domain = "";
                string vertRootPath = "";
                domain = objCommon.GetDomainNameByCountry(lblUserID);
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            vertRootPath = row[1].ToString();
                    }
                }
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(domain, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            EmailFrom = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + domain + "\\";
                StreamReader re = File.OpenText(strfilepath + "CsrMessage.txt");
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
                msgbody = msgbody.Replace("#RootUrl#", vertRootPath);
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#CsrEmailContent#", message);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();

                return objUtil.SendWowzzyEmail(EmailFrom, emailTo, subject, msgbody, "", "", domain);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "SendCsrEmail", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return "";
        }
        // *** End of issue 1246  ***//
        protected void LnkSuspendClick(object sender, EventArgs e)
        {
            try
            {
                string username = string.Empty;
                username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                bool ezSmartSite = false;
                int pid = 0;
                if (username == System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    pnlCustomerDetails.Visible = true;
                    NotesTable.Visible = true;
                    NotesDatalist.Visible = true;
                    lblerror.Text = "You cannot suspend the admin user.";
                }
                else
                {
                    dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                    if (dtobjEzsmartSite != null)
                    {
                        pid = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                        adminobj.UpdateEzsmartSiteByprofileID(ezSmartSite, pid);
                        DataTable dtobj = new DataTable();
                        pnlCustomerDetails.Visible = true;
                        CustomersPanel.Visible = false;
                        NotesDatalist.Visible = true;
                        NotesTable.Visible = true;
                        dtobj = adminobj.GetUserDetailsByProfileID(pid);
                        lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                        BindAssociatesUsers();
                        lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                        lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                        lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                        lblcity.Text = dtobj.Rows[0]["City"].ToString();
                        lblstate.Text = dtobj.Rows[0]["State"].ToString();
                        lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                        lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                        lblemail.Text = dtobj.Rows[0]["User_email"].ToString();

                        getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                        splitSubAppUserID = getSubAppStatus.Split(',');
                        lblSubApp.Text = splitSubAppUserID[0];
                        lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                        if (lblSubApp.Text == "Yes")
                            lnkUserID.Text = splitSubAppUserID[1];

                        pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                        lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                        lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                        lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                        lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                        lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                        {
                            if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                            {
                                lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                            }
                        }
                        AssignSalesPersonDetails_RecurringDetails(dtobj);
                        lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                        lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                        {
                            lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                            DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                        }
                        else
                            lbllastlogin.Text = "";
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                        {
                            lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                        }
                        lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                        ShowButtons();
                        BindPinCode();
                        if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                        {
                            if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Red;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                            else
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Black;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                        }
                        else
                        {
                            lblremainingdays.ForeColor = System.Drawing.Color.Black;
                            lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                        }

                        lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                        lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                        lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                        lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                                    Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                        {
                            lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                        }
                        else
                            lblExpiredDatecc.Text = "";
                        hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                        FillNotesByProfileID(pid);
                        if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                        {
                            btnTestAccount.Text = "Change To Normal Account";
                        }
                        else
                        {
                            btnTestAccount.Text = "Change To Test Account";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "LnkSuspendClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkActivateClick(object sender, EventArgs e)
        {
            try
            {
                string username = string.Empty;
                username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                bool ezSmartSite = true;
                int pid = 0;
                if (username == System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    pnlCustomerDetails.Visible = true;
                    NotesTable.Visible = true;
                    NotesDatalist.Visible = true;
                    lblerror.Text = "You cannot inactivate the admin user.";
                }
                else
                {
                    dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                    if (dtobjEzsmartSite != null)
                    {
                        pid = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                        adminobj.UpdateEzsmartSiteByprofileID(ezSmartSite, pid);

                        DataTable dtobj = new DataTable();
                        pnlCustomerDetails.Visible = true;

                        CustomersPanel.Visible = false;
                        NotesDatalist.Visible = true;
                        NotesTable.Visible = true;

                        dtobj = adminobj.GetUserDetailsByProfileID(pid);
                        lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                        hdnMemberID.Value = lblMemberID.Text;

                        BindAssociatesUsers();
                        lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                        lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                        lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                        lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                        lblcity.Text = dtobj.Rows[0]["City"].ToString();
                        lblstate.Text = dtobj.Rows[0]["State"].ToString();
                        lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                        lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                        lblemail.Text = dtobj.Rows[0]["User_email"].ToString();

                        getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                        splitSubAppUserID = getSubAppStatus.Split(',');
                        lblSubApp.Text = splitSubAppUserID[0];
                        lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                        if (lblSubApp.Text == "Yes")
                            lnkUserID.Text = splitSubAppUserID[1];

                        pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                        lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                        lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                        lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                        lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                        lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                        {
                            if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                            {
                                lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                            }
                        }
                        AssignSalesPersonDetails_RecurringDetails(dtobj);
                        lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                        lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                        {
                            lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                            DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                        }
                        else
                            lbllastlogin.Text = "";
                        if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                        {
                            lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                        }
                        lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                        ShowButtons();
                        BindPinCode();
                        if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                        {
                            if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Red;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                            else
                            {
                                lblremainingdays.ForeColor = System.Drawing.Color.Black;
                                lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                            }
                        }
                        else
                        {
                            lblremainingdays.ForeColor = System.Drawing.Color.Black;
                            lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                        }

                        lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                        lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                        lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                        lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                        if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                                    Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                        {
                            lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                        }
                        else
                            lblExpiredDatecc.Text = "";
                        hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                        FillNotesByProfileID(pid);
                        if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                        {
                            btnTestAccount.Text = "Change To Normal Account";
                        }
                        else
                        {
                            btnTestAccount.Text = "Change To Test Account";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "LnkActivateClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void FillNotesByProfileID(int profileID)
        {
            try
            {
                DataTable dtobj = new DataTable();
                int queryUserID = profileID;
                dtobj = adminobj.GetCustomerDeskNotesDetailsByProfileID(queryUserID);
                string emptyTextBx = string.Empty;
                TxtBxNotes.Text = emptyTextBx;
                DataList_CustomerNotes.DataSource = dtobj;
                DataList_CustomerNotes.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "FillNotesByProfileID", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnPasswordClick(object sender, EventArgs e)
        {
            try
            {
                string emailInfo = "";
                string rootPath = "";
                string username = string.Empty;
                username = ddlAssociates.SelectedItem.Text.Trim();
                int memberId = Convert.ToInt32(ddlAssociates.SelectedValue);
                if (username != System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    DataTable dtPassword = busobj.GetUserNameAndPaswwordForUserID(memberId);
                    string domain = "";
                    string password = string.Empty;
                    domain = objCommon.GetDomainNameByCountry(Convert.ToInt32(lblMemberID.Text));
                    if (dtPassword.Rows.Count > 0)
                    {
                        password = EncryptDecrypt.DESDecrypt(dtPassword.Rows[0]["Password"].ToString());
                    }
                    DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                    if (dtConfigs.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigs.Rows)
                        {
                            if (row[0].ToString() == "RootPath")
                                rootPath = row[1].ToString();
                        }
                    }
                    DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(domain, "EmailAccounts");
                    if (dtConfigsemails.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails.Rows)
                        {
                            if (row[0].ToString() == "EmailInfo")
                                emailInfo = row[1].ToString();
                        }
                    }
                    string strfilepath = Server.MapPath("~") + "\\EmailContent" + domain + "\\";
                    StreamReader re = File.OpenText(strfilepath + "CustServicePassword.txt");
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

                    msgbody = msgbody.Replace("#RootUrl#", rootPath);
                    msgbody = msgbody.Replace("#msgBody#", content);

                    msgbody = msgbody.Replace("#Link#", "<a href='" + rootPath + "/OP/" + domain + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target=_new>Login</a>");
                    msgbody = msgbody.Replace("#AddLink#", rootPath + "/OP/" + domain + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()));
                    msgbody = msgbody.Replace("#Email#", username);
                    msgbody = msgbody.Replace("#Password#", password);
                    re.Close();
                    re.Dispose();
                    reDeclaimer.Close();
                    reDeclaimer.Dispose();
                    string ccemail = string.Empty;
                    UtilitiesBLL utlobj = new UtilitiesBLL();
                    utlobj.SendWowzzyEmail(emailInfo, username, "Password Details", msgbody, ccemail, "", domain);
                    lblerror.Text = "Password has been sent to user successfully.";
                    lblerror.ForeColor = System.Drawing.Color.Green;
                }
                pnlCustomerDetails.Visible = true;
                NotesTable.Visible = true;
                NotesDatalist.Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnPasswordClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnTestAccountClick(object sender, EventArgs e)
        {
            try
            {
                int userID = Convert.ToInt32(lblMemberID.Text.ToString());
                BusinessBLL busobj = new BusinessBLL();
                if (btnTestAccount.Text.Trim() == "Change To Test Account")
                {
                    busobj.ChangeToTestAccount(userID, 1);
                    btnTestAccount.Text = "Change To Normal Account";
                }
                else
                {
                    busobj.ChangeToTestAccount(userID, 2);
                    btnTestAccount.Text = "Change To Test Account";
                }
                pnlCustomerDetails.Visible = true;
                NotesTable.Visible = true;
                NotesDatalist.Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnTestAccountClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void CustomersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGdPassword = (Label)e.Row.FindControl("lblGdPassword");
                    lblGdPassword.Text = EncryptDecrypt.DESDecrypt(lblGdPassword.Text);
                    Label lblIsArchived = e.Row.FindControl("lblIsArchived") as Label;
                    if (lblIsArchived.Text != "" && Convert.ToBoolean(lblIsArchived.Text) == false)
                        e.Row.CssClass = "realusers";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "CustomersGridView_RowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnReferByOnClick(object sender, EventArgs e)
        {
            try
            {
                int memUSerID = Convert.ToInt32(lblMemberID.Text);
                if (hdnSalesPeronID.Value == ddlReferBy.SelectedValue.ToString())
                {
                    lblerror.Text = "Sales person already assigned.";
                    lblerror.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    hdnSalesPeronID.Value = ddlReferBy.SelectedValue.ToString();
                    adminobj.UpdateReferBy(memUSerID, Convert.ToInt32(ddlReferBy.SelectedValue));
                    lblerror.Text = "Sales person assigned successfully.";
                    lblerror.ForeColor = System.Drawing.Color.Green;

                    // *** Fix for IRH-45 06-02-2013 *** //
                    DataTable dtSubscriptions = busobj.GetInvoiceDetails(memUSerID);
                    if (dtSubscriptions.Rows.Count > 0)
                    {
                        UtilitiesBLL objUitilities = new UtilitiesBLL();
                        for (int i = 0; i < dtSubscriptions.Rows.Count; i++)
                        {
                            objUitilities.CreateCommissionReportForUser(memUSerID, Convert.ToInt32(dtSubscriptions.Rows[i]["SubscriptionType_ID"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnReferByOnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnPayUpgradeClick(object sender, EventArgs e)
        {
            try
            {
                string uname = string.Empty;
                uname = lblloginname.Text;
                string pid = string.Empty;
                DataTable dtobjMemberSite = new DataTable();
                if (uname == System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                {
                    pnlCustomerDetails.Visible = true;
                    NotesTable.Visible = true;
                    NotesDatalist.Visible = true;
                    lblerror.Text = "Admin user doesn't have the inReachHub.";
                }
                else
                {
                    dtobjMemberSite = adminobj.GetProfileIDByUserEmail(uname, lblVertical.Text);
                    if (dtobjMemberSite != null)
                        pid = dtobjMemberSite.Rows[0]["profile_id"].ToString();
                    string ezStoreUrl = System.Configuration.ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Business/RedirectTools.aspx?PID=" + EncryptDecrypt.DESEncrypt(pid.ToString()) + "&UID=" + lblMemberID.Text;
                    ezStoreUrl = "window.open('" + ezStoreUrl + "', '_blank', '')";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", ezStoreUrl, true);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnPayUpgradeClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void HyperEnable_OnClick(object sender, EventArgs e)
        {
            try
            {
                bool isRecurring = false;
                DataTable dtSubscriptionDetails = new DataTable();
                dtSubscriptionDetails = busobj.Getorderidbyuserid(Convert.ToInt32(lblMemberID.Text));
                if (dtSubscriptionDetails.Rows.Count > 0)
                {
                    if (HyperEnable.Text == "Disable")
                    {
                        HyperEnable.Text = "Enable";
                        lblRecurring.Text = "No";
                        adminobj.UpdateProfileSubcriptionRecurring(isRecurring, Convert.ToInt32(dtSubscriptionDetails.Rows[0]["order_id"]));
                    }
                    else
                    {
                        string uname = string.Empty;
                        uname = lblloginname.Text;
                        int pid = 0;
                        DataTable dtobjMemberSite = new DataTable();
                        dtobjMemberSite = adminobj.GetProfileIDByUserEmail(uname, lblVertical.Text);
                        if (dtobjMemberSite != null)
                            pid = Convert.ToInt32(dtobjMemberSite.Rows[0]["profile_id"]);
                        DataTable dtCreditCardDetails = busobj.GetOrderSubscriptionByProfileID(pid);
                        if (dtCreditCardDetails.Rows.Count > 0)
                        {
                            if (Convert.ToString(dtCreditCardDetails.Rows[0]["CC_number"]) == string.Empty)
                                ScriptManager.RegisterClientScriptBlock(HyperEnable, this.GetType(), "validation", "alert('You do not have credit card details. Please fill the credit card details.');", true);
                            else
                            {
                                HyperEnable.Text = "Disable";
                                lblRecurring.Text = "Yes";
                                isRecurring = true;
                                adminobj.UpdateProfileSubcriptionRecurring(isRecurring, Convert.ToInt32(dtSubscriptionDetails.Rows[0]["order_id"]));
                            }
                        }
                        else
                            ScriptManager.RegisterClientScriptBlock(HyperEnable, this.GetType(), "validation", "alert('You do not have credit card details. Please fill the credit card details.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "HyperEnable_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkUpdateCredicardOnClick(object sender, EventArgs e)
        {
            try
            {
                string uname = string.Empty;
                uname = lblloginname.Text;
                string pid = string.Empty;
                DataTable dtobjMemberSite = new DataTable();
                dtobjMemberSite = adminobj.GetProfileIDByUserEmail(uname, lblVertical.Text);
                if (dtobjMemberSite != null)
                    pid = dtobjMemberSite.Rows[0]["profile_id"].ToString();
                DataTable dtCreditCardDetails = busobj.GetOrderSubscriptionByProfileID(Convert.ToInt32(pid));
                if (dtCreditCardDetails.Rows.Count > 0)
                {
                    //CC Details
                    DropDownList ddlCardType = CCDetails1.FindControl("ddlCardType") as DropDownList;
                    TextBox txtfirstName = CCDetails1.FindControl("txtfirstName") as TextBox;
                    TextBox txtlastname = CCDetails1.FindControl("txtlastname") as TextBox;
                    AjaxControlToolkit.TextBoxWatermarkExtender waterCCNumber = CCDetails1.FindControl("waterCCNumber") as AjaxControlToolkit.TextBoxWatermarkExtender;
                    TextBox txtcreditCardNumber = CCDetails1.FindControl("txtcreditCardNumber") as TextBox;
                    TextBox txtexpmonth = CCDetails1.FindControl("txtexpmonth") as TextBox;
                    TextBox txtexpyear = CCDetails1.FindControl("txtexpyear") as TextBox;
                    TextBox txtcvv2Number = CCDetails1.FindControl("txtcvv2Number") as TextBox;


                    ddlCardType.SelectedValue = Convert.ToString(dtCreditCardDetails.Rows[0]["Card_Type"]);
                    txtfirstName.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_name"]);
                    txtlastname.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_lastname"]);

                    string ccNumber = EncryptDecrypt.DESDecrypt(Convert.ToString(dtCreditCardDetails.Rows[0]["CC_number"]));
                    if (ccNumber.Length >= 4)
                    {
                        ccNumber = "xxxx xxxx xxxx " + ccNumber.Substring(ccNumber.Length - 4).ToString();
                        txtcreditCardNumber.Text = ccNumber;
                        waterCCNumber.WatermarkText = ccNumber;
                    }
                    else
                    {
                        txtcreditCardNumber.Text = " ";
                        waterCCNumber.WatermarkText = " ";
                    }

                    txtexpmonth.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_expire_month"]);
                    txtexpyear.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_expire_year"]);
                    txtcvv2Number.Text = EncryptDecrypt.DESDecrypt(Convert.ToString(dtCreditCardDetails.Rows[0]["cc_cvv"]));

                    Session["orderID"] = Convert.ToString(dtCreditCardDetails.Rows[0]["Order_ID"]);

                    //Billing Details
                    TextBox txtAddress1 = (TextBox)CCDetails1.FindControl("txtaddress1");
                    TextBox txtAddress2 = (TextBox)CCDetails1.FindControl("txtaddress2");
                    TextBox txtCity = (TextBox)CCDetails1.FindControl("txtcity");
                    DropDownList drpState = (DropDownList)CCDetails1.FindControl("DrpState");
                    TextBox txtZipcode = (TextBox)CCDetails1.FindControl("txtzip");

                    txtAddress1.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_address1"]);
                    txtAddress2.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_address2"]);
                    txtCity.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_city"]);
                    drpState.SelectedValue = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_state"]);
                    txtZipcode.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_zipcode"]);
                }
                CCDetailsModalPopup.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "LnkUpdateCredicardOnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkClose_Click(object sender, EventArgs e)
        {
            CCDetailsModalPopup.Hide();
        }
        private void AssignSalesPersonDetails_RecurringDetails(DataTable dtobj)
        {
            try
            {
                if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                {
                    if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                    {
                        lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                        HyperEnable.Visible = false;
                    }
                    else
                        HyperEnable.Visible = true;
                }
                else
                    HyperEnable.Visible = true;

                if (string.IsNullOrEmpty(dtobj.Rows[0]["SalesPersonID"].ToString()))
                {
                    ddlReferBy.SelectedIndex = 0;
                    hdnSalesPeronID.Value = "-1";
                }
                else if (ddlReferBy.Items.FindByValue(dtobj.Rows[0]["SalesPersonID"].ToString()) == null)
                {
                    ddlReferBy.SelectedIndex = 0;
                    hdnSalesPeronID.Value = "-1";
                }
                else
                {
                    ddlReferBy.SelectedValue = dtobj.Rows[0]["SalesPersonID"].ToString();
                    hdnSalesPeronID.Value = ddlReferBy.SelectedValue.ToString();
                }
                //Getting User Profile Subcription
                DataTable dtProfileSubcription = adminobj.GetUserProfileSubcription(Convert.ToInt32(dtobj.Rows[0]["User_ID"]));
                if (dtProfileSubcription.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtProfileSubcription.Rows[0]["IsRecurring"]) == true)
                    {
                        HyperEnable.Text = "Disable";
                        lblRecurring.Text = "Yes";
                    }
                    else
                    {
                        HyperEnable.Text = "Enable";
                        lblRecurring.Text = "No";
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "AssignSalesPersonDetails_RecurringDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnUpdatePassword(object sender, EventArgs e)
        {
            try
            {
                int memberID = Convert.ToInt32(ddlAssociates.SelectedValue.ToString());
                string newPwd = "", confirmPwd = "";
                newPwd = txtNewPwd.Value.Trim();
                confirmPwd = txtCnfPwd.Value.Trim();
                if (newPwd == confirmPwd)
                {
                    int passwordChanged = 1;// If password changed by user then update his password changed flag by 1, other wise it is zero.
                    int updateflag = conObj.UpdateUserPassword(memberID, EncryptDecrypt.DESEncrypt(newPwd), passwordChanged);
                    //   int updateflag = conObj.UpdateUserPassword(UserID, txtPassword.Text.Trim(), Password_Changed);
                    if (updateflag > 0)
                    {
                        string emailInfo = "";
                        string rootPath = "";
                        string username = string.Empty;
                        username = ddlAssociates.SelectedItem.Text.ToString();
                        if (username != System.Configuration.ConfigurationManager.AppSettings.Get("AdminUserID").ToString())
                        {
                            DataTable dtPassword = busobj.GetUserNameAndPaswwordForUserID(memberID);
                            string domain = "";
                            string password = string.Empty;
                            domain = objCommon.GetDomainNameByCountry(Convert.ToInt32(lblMemberID.Text));
                            if (dtPassword.Rows.Count > 0)
                            {
                                password = EncryptDecrypt.DESDecrypt(dtPassword.Rows[0]["Password"].ToString());
                            }
                            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                            if (dtConfigs.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtConfigs.Rows)
                                {
                                    if (row[0].ToString() == "RootPath")
                                        rootPath = row[1].ToString();
                                }
                            }
                            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(domain, "EmailAccounts");
                            if (dtConfigsemails.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtConfigsemails.Rows)
                                {
                                    if (row[0].ToString() == "EmailInfo")
                                        emailInfo = row[1].ToString();
                                }
                            }
                            string strfilepath = Server.MapPath("~") + "\\EmailContent" + domain + "\\";
                            StreamReader re = File.OpenText(strfilepath + "Changepassword.txt");
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

                            msgbody = msgbody.Replace("#RootUrl#", rootPath);
                            msgbody = msgbody.Replace("#msgBody#", content);
                            msgbody = msgbody.Replace("#Username#", username);
                            msgbody = msgbody.Replace("#Password#", password);
                            re.Close();
                            re.Dispose();
                            reDeclaimer.Close();
                            reDeclaimer.Dispose();
                            string ccemail = string.Empty;
                            UtilitiesBLL utlobj = new UtilitiesBLL();
                            utlobj.SendWowzzyEmail(emailInfo, username, "Change Password Service", msgbody, ccemail, "", domain);
                            lblerror.Text = "<Font face=arial color=green size=2><b>Password has been changed successfully.</b></font>";
                        }
                    }
                }
                else
                {
                    lblerror.Text = "<Font face=arial color=red size=2><b>Passwords do not match.</b></font>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnUpdatePassword", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void CreateUpdateAccessCodeClick(object sender, EventArgs e)
        {
            try
            {
                int profileID = 0;
                string username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                if (dtobjEzsmartSite != null)
                {
                    profileID = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                }
                string accessCode = txtAccsCode.Value;
                txtAccsCode.Value = "";
                int accessCodeResult = adminobj.CreateUpdateAccessCodes(profileID, accessCode, false);
                if (accessCodeResult == 1)
                {
                    if (lblAccCode.Text != "" && lblAccCode.Text != null)
                        lblerror.Text = "<Font face=arial color=green size=2><b>Access code has been updated successfully.</b></font>";
                    else
                        lblerror.Text = "<Font face=arial color=green size=2><b>Access code has been created successfully.</b></font>";
                    lblAccCode.Text = accessCode;

                    ShowButtons();
                }
                else
                {
                    lblerror.Text = "";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "CreateUpdateAccessCodeClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnUpdatePin_Click(object sender, EventArgs e)
        {
            try
            {
                string pinCode = txtAccsCode.Value;
                txtPinDummy.Value = "";
                objAgency.CreateUpdatePinCode(pinCode, hdnUserAppName.Value);
                if (lblAppPinCode.Text != "" && lblAppPinCode.Text != null)
                    lblerror.Text = "<Font face=arial color=green size=2><b>Pin code has been updated successfully.</b></font>";
                else
                    lblerror.Text = "<Font face=arial color=green size=2><b>Pin code has been created successfully.</b></font>";
                BindPinCode();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "btnUpdatePin_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnExtend_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime renewDate = Convert.ToDateTime(lblrenewdate.Text);
                DateTime updateRenewDate = Convert.ToDateTime(txtMemshipExtend.Text);
                int profileID = 0;
                int memberID = Convert.ToInt32(hdnMemberID.Value);
                string username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                bool isValid = true;
                string msgError = "<font face=arial color=red size=2>Extended date should be later than current date.</font>";
                if (updateRenewDate <= DateTime.Today)
                    isValid = false;
                else if (updateRenewDate <= renewDate)
                {
                    isValid = false;
                    msgError = "<font face=arial color=red size=2>Extended date should be later than existing date.</font>";
                }
                if (isValid)
                {
                    dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                    if (dtobjEzsmartSite != null)
                        profileID = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                    int resCode = adminobj.ExtendSubscriptionPeriod(profileID, memberID, updateRenewDate);
                    adminobj.PreserveSubscriptionRenewDates(profileID + "-" + memberID + "-" + "Extended Subscription", renewDate);
                    if (resCode == 1)
                    {
                        DataTable dtUserDetails = adminobj.GetMemberDetails(memberID);
                        lblrenewdate.Text = dtUserDetails.Rows[0]["RenewalDate"].ToString();
                        lblremainingdays.Text = dtUserDetails.Rows[0]["DaysRemaining"].ToString();
                        lblerror.Text = "<Font face=arial color=green size=2>Subscription period has extended successfully.</font>";
                    }
                }
                else
                    lblerror.Text = msgError;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "btnExtend_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCreateFreeAccount(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/CreateFreeAccount.aspx");
            Response.Redirect(urlinfo);
        }
        private void ShowButtons()
        {
            btnRemoveCode.Visible = false;
            if (!string.IsNullOrEmpty(lblAccCode.Text))
            {
                btnAccCode.Text = "Update";
                btnRemoveCode.Visible = true;
            }
            else
                btnAccCode.Text = "Create";
        }
        /** This method is for getting Associate details when Associate logins after parent logins.**/
        private void DisplayAssociateDetails(int parentID, DateTime parentLastLogin)
        {
            try
            {
                DataTable dtAssociateInfo = new DataTable();
                DateTime dateofLastLogin;
                string date = "";
                dtAssociateInfo = adminobj.GetAssociateLatestLogin(parentID, parentLastLogin);
                if (dtAssociateInfo.Rows.Count > 0)
                {
                    date = dtAssociateInfo.Rows[0]["User_LastLoginDate"].ToString() + " " + dtAssociateInfo.Rows[0]["User_LastLoginTime"].ToString();
                    dateofLastLogin = Convert.ToDateTime(date);
                    AssociateID = Convert.ToInt32(dtAssociateInfo.Rows[0]["User_ID"].ToString());
                    lblAssocID.Text = dtAssociateInfo.Rows[0]["User_ID"].ToString();
                    lbllastlogin.Text = Convert.ToString(dateofLastLogin);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "DisplayAssociateDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnUpdateLogo_Click(object sender, EventArgs e)
        {
            try
            {
                int CUserID = 0;
                int ProfileID = 0;
                string username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                if (dtobjEzsmartSite != null)
                {
                    ProfileID = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                }
                if (logoimage.FileName != "")
                {
                    if (logoimage.PostedFile != null)
                    {
                        if (logoimage.PostedFile.FileName.ToString().Length > 1)
                        {
                            FileInfo logoobj = new FileInfo(logoimage.PostedFile.FileName);
                            if (logoobj.Extension == ".jpg" || logoobj.Extension == ".JPG" || logoobj.Extension == ".JPEG" || logoobj.Extension == ".jpeg" ||
                                logoobj.Extension == ".GIF" || logoobj.Extension == ".gif" || logoobj.Extension == ".bmp" || logoobj.Extension == ".BMP" ||
                                logoobj.Extension == ".png" || logoobj.Extension == ".PNG")
                            {

                                System.Drawing.Image myImage = System.Drawing.Image.FromStream(logoimage.PostedFile.InputStream);
                                if ((myImage.Height <= 150) && (myImage.Width <= 150))
                                {
                                    string saveFilePath = Server.MapPath("~") + "\\Upload";
                                    string folderPath = string.Empty;
                                    folderPath = saveFilePath + "\\Logos\\" + ProfileID;
                                    if (!System.IO.Directory.Exists(folderPath))
                                    {
                                        System.IO.Directory.CreateDirectory(folderPath);
                                    }

                                    string logoExtension = logoobj.Extension;
                                    if (logoExtension == ".bmp" || logoExtension == ".BMP")
                                    {
                                        logoExtension = ".jpg";
                                    }


                                    string fileName1 = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb_dummy" + logoExtension;

                                    if ((myImage.Height <= 65) || (myImage.Width <= 65))
                                    {
                                        fileName1 = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                                    }

                                    /*** Deleting An Existing LOGO ***/
                                    string strlogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\";
                                    DataTable dtobj = new DataTable();
                                    dtobj = busobj.GetProfileDetailsByProfileID(ProfileID);
                                    if (dtobj.Rows.Count == 1)
                                    {
                                        string logourl = string.Empty;
                                        logourl = strlogoPath + dtobj.Rows[0]["Profile_logo_path"].ToString();
                                        string imagename1 = dtobj.Rows[0]["Profile_logo_path"].ToString();

                                        string extension = System.IO.Path.GetExtension(Server.MapPath(imagename1));
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
                                        }
                                    }
                                    /*** Deleting An Existing LOGO ***/

                                    logoimage.SaveAs(fileName1);
                                    string photoFileName = ProfileID + logoExtension;
                                    int UFlag = busobj.UpdateBusinessProfileLogo(photoFileName, ProfileID, UserID, CUserID);



                                    if ((myImage.Height > 65) || (myImage.Width > 65))
                                    {
                                        LogoResize(65, 65, logoExtension);    // Mobile App Logo Size 65*65
                                        isShortLogo = true;
                                        busobj.UpdateShortorLongLogo(UserID, isShortLogo);

                                    }
                                    if (UFlag == ProfileID)
                                    {
                                        lblLogoMsg.Text = "<font color=green face=arial size=2><b>Your logo has been saved successfully.</b></font>";
                                        mpeLogo.Show();
                                    }
                                }
                                else
                                {
                                    lblLogoMsg.Text = "<font color=red face=arial size=2><b>Your logo must be less than or equal to 150px X 150px.</b></font>";
                                    mpeLogo.Show();
                                }
                            }
                            else
                            {
                                lblLogoMsg.Text = "<font color=red face=arial size=2><b>Your logo is in an incorrect file format. Please try again.</b></font>";
                                mpeLogo.Show();
                            }
                            logoobj = null;
                        }
                    }
                }
                else
                {
                    lblLogoMsg.Text = "<font color=red face=arial size=2><b>You have not selected a logo file to upload. Please try again.</b></font>";
                    mpeLogo.Show();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "BtnUpdateLogo_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LogoResize(int pWidth, int pHeight, string logoExtension)
        {
            try
            {
                int ProfileID = 0;
                string username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                if (dtobjEzsmartSite != null)
                {
                    ProfileID = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                }

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
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "LogoResize", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnMemberInformation_OnClick(object sender, EventArgs e)
        {
            try
            {
                int loginMemberID = Convert.ToInt32(lblMemberID.Text);
                var pid = "0";
                string uname = string.Empty;
                //uname = hdnLoginName.Value;
                uname = lblloginname.Text;
                var dtobjMemberSite = adminobj.GetProfileIDByUserEmail(uname, lblVertical.Text);
                if (dtobjMemberSite != null)
                    pid = dtobjMemberSite.Rows[0]["profile_id"].ToString();

                string urlinfo = Page.ResolveClientUrl("~/Admin/MemberInformation.aspx?pid=" + EncryptDecrypt.DESEncrypt(pid.ToString()) + "&UID=" + EncryptDecrypt.DESEncrypt((loginMemberID.ToString())));
                HttpContext.Current.Response.Redirect(urlinfo);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "btnMemberInformation_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnTurnonMail_Click(object sender, EventArgs e)
        {
            try
            {
                int profileID = 0;
                string password = "";
                DataTable dtProfile = new DataTable();
                dtProfile = adminobj.GetProfileIDByUserEmail(lblloginname.Text, lblVertical.Text);
                if (dtProfile != null)
                {
                    profileID = Convert.ToInt32(dtProfile.Rows[0]["profile_id"].ToString());
                    password = dtProfile.Rows[0]["Password"].ToString();
                }
                SendActivationEmail(lblLoginEmail.Text, password, "", lblVertical.Text);
                objCommon.SendRepresentationEmail(profileID, lblVertical.Text);
                objAgency.UpdateAutoOnOff(Convert.ToInt32(lblMemberID.Text), true);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "btnTurnonMail_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendActivationEmail(string username, string password, string location, string verticalValue)
        {
            try
            {
                CommonBLL objCommon = new CommonBLL();
                string vertRootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(verticalValue, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            vertRootPath = row[1].ToString();
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(verticalValue, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + verticalValue + "\\";
                StreamReader re = File.OpenText(strfilepath + "AgencyActivationCode.txt");
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
                msgbody = msgbody.Replace("#RootUrl#", vertRootPath);
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#Link#", "<a href='" + vertRootPath + "/OP/" + verticalValue + "/Login.aspx' target='_blank'>Login</a>");
                msgbody = msgbody.Replace("#Email#", username);
                msgbody = msgbody.Replace("#Password#", password);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                utlobj.SendWowzzyEmail(FromEmailsupport, username, "Account Details", msgbody, ccemail, "", verticalValue);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "SendActivationEmail", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnRemoveCode_Click(object sender, EventArgs e)
        {
            try
            {
                txtAccsCode.Value = "";
                int profileID = 0;
                string username = lblloginname.Text;
                DataTable dtobjEzsmartSite = new DataTable();
                dtobjEzsmartSite = adminobj.GetProfileIDByUserEmail(username, lblVertical.Text);
                if (dtobjEzsmartSite != null)
                {
                    profileID = Convert.ToInt32(dtobjEzsmartSite.Rows[0]["profile_id"].ToString());
                }
                int accessCode = adminobj.CreateUpdateAccessCodes(profileID, lblAccessCode.Text, true); // *** 1 means delete access code *** //
                if (accessCode == 1)
                {
                    lblerror.Text = "<Font face=arial color=green size=2><b>Access code has been removed successfully.</b></font>";
                    lblAccCode.Text = "";
                    ShowButtons();
                }
                else
                {
                    lblerror.Text = "";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "btnRemoveCode_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnRemovePinCode_Click(object sender, EventArgs e)
        {

        }
        protected void lnkUserID_Click(object sender, EventArgs e)
        {
            try
            {
                txtcategory.Text = lnkUserID.Text;
                DataTable dtobj = new DataTable();
                dtobj = adminobj.GetMemberDetails(Convert.ToInt32(lnkUserID.Text));

                //For Differnet Color Demo users
                if (dtobj.Rows.Count > 0)
                {
                    // True Means Demo Users
                    if (Convert.ToString(dtobj.Rows[0]["IsArchived"]).ToString().ToLower() == "true")
                    {
                        lblMemberID.CssClass = "demousers";
                        lblcompname.CssClass = "demousers";
                    }
                    else // Real Users
                    {
                        lblMemberID.CssClass = "realusers1";
                        lblcompname.CssClass = "realusers1";
                    }
                }
                if (dtobj.Rows.Count == 1)
                {
                    pnlCustomerDetails.Visible = true;
                    #region assigningValues

                    lblMemberID.Text = dtobj.Rows[0]["User_ID"].ToString();
                    lblcompname.Text = dtobj.Rows[0]["ProfileName"].ToString();
                    lblContname.Text = dtobj.Rows[0]["ContactName"].ToString();
                    lblProfName.Text = dtobj.Rows[0]["ProfileName"].ToString();
                    lbladdress1.Text = dtobj.Rows[0]["Address1"].ToString();
                    lbladdress2.Text = dtobj.Rows[0]["Address2"].ToString();
                    lblcity.Text = dtobj.Rows[0]["City"].ToString();
                    lblstate.Text = dtobj.Rows[0]["State"].ToString();
                    lblCountry.Text = dtobj.Rows[0]["Country"].ToString();
                    lblzipcode.Text = dtobj.Rows[0]["Zip"].ToString();
                    lblemail.Text = dtobj.Rows[0]["User_email"].ToString();

                    getSubAppStatus = adminobj.CheckSubApp(Convert.ToInt32(hdnMemberID.Value));
                    splitSubAppUserID = getSubAppStatus.Split(',');
                    lblSubApp.Text = splitSubAppUserID[0];
                    lblAppVersion.Text = dtobj.Rows[0]["App_Version"].ToString();
                    if (lblSubApp.Text == "Yes")
                        lnkUserID.Text = splitSubAppUserID[1];

                    pblphone.Text = dtobj.Rows[0]["PhoneNo1"].ToString();
                    lblfax.Text = dtobj.Rows[0]["Fax"].ToString();
                    lblfirstname.Text = dtobj.Rows[0]["Firstname"].ToString();
                    lbllastname.Text = dtobj.Rows[0]["Lastname"].ToString();
                    lblstatus.Text = dtobj.Rows[0]["MemberStatus"].ToString();
                    lbllevel.Text = dtobj.Rows[0]["MembershipLevel"].ToString();
                    lblAccCode.Text = Convert.ToString(dtobj.Rows[0]["Access_Code"]);
                    ShowButtons();
                    BindPinCode();
                    if (!string.IsNullOrEmpty(dtobj.Rows[0]["Discount_Code"].ToString()))
                    {
                        if (dtobj.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                        {
                            lbllevel.Text = ConfigurationManager.AppSettings.Get("FreetrailAlert").ToString();
                            //added code by 31-01-2013 logictree
                            HyperEnable.Visible = false;
                        }
                    }
                    AssignSalesPersonDetails_RecurringDetails(dtobj);
                    lblLoginEmail.Text = dtobj.Rows[0]["LoginName"].ToString();
                    lblloginname.Text = dtobj.Rows[0]["LoginName"].ToString();
                    if (Convert.ToString(dtobj.Rows[0]["User_LastLoginDate"]) != "")
                    {
                        lbllastlogin.Text = dtobj.Rows[0]["LastLoginDate"].ToString();
                        DisplayAssociateDetails(Convert.ToInt32(lblMemberID.Text), Convert.ToDateTime(lbllastlogin.Text));
                    }
                    else
                        lbllastlogin.Text = "";
                    if (!string.IsNullOrEmpty(dtobj.Rows[0]["User_Browser"].ToString()))
                    {
                        lblbrowser.Text = dtobj.Rows[0]["User_Browser"].ToString() + " (" + dtobj.Rows[0]["User_BrowserVersion"].ToString() + ")";
                    }

                    if (dtobj.Rows[0]["DaysRemaining"].ToString() != "ForEver")
                    {
                        if (Convert.ToInt32(dtobj.Rows[0]["DaysRemaining"].ToString()) < 15)
                        {
                            lblremainingdays.ForeColor = System.Drawing.Color.Red;
                            lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                        }
                        else
                        {
                            lblremainingdays.ForeColor = System.Drawing.Color.Black;
                            lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                        }
                    }
                    else
                    {
                        lblremainingdays.ForeColor = System.Drawing.Color.Black;
                        lblremainingdays.Text = dtobj.Rows[0]["DaysRemaining"].ToString();
                    }
                    lblrenewdate.Text = dtobj.Rows[0]["RenewalDate"].ToString();
                    lblsubscpstartdate.Text = dtobj.Rows[0]["SubscriptionStartDate"].ToString();
                    lblVertical.Text = dtobj.Rows[0]["Vertical_Name"].ToString();
                    lblamount.Text = dtobj.Rows[0]["PaidAmount"].ToString();
                    if (Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "" &&
                        Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) != "0" && Convert.ToString(dtobj.Rows[0]["cc_expire_year"]) != "0")
                    {
                        lblExpiredDatecc.Text = String.Format("{0:MM/yy}", Convert.ToDateTime(Convert.ToString(dtobj.Rows[0]["cc_expire_month"]) + "/" + "1" + "/" + Convert.ToString(dtobj.Rows[0]["cc_expire_year"])));
                    }
                    else
                        lblExpiredDatecc.Text = "";
                    hdnTurnOff.Value = dtobj.Rows[0]["IsTurnOnEmail"].ToString();
                    #endregion assingningValues
                    FillNotes();
                    if (dtobj.Rows[0]["TestAccount"].ToString().Trim() != "")
                    {
                        btnTestAccount.Text = "Change To Normal Account";
                    }
                    else
                    {
                        btnTestAccount.Text = "Change To Test Account";
                    }
                    NotesTable.Visible = true;
                    CustomersPanel.Visible = false;
                    NotesDatalist.Visible = true;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "lnkUserID_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnAssociateMemberLogin_OnClick(object sender, EventArgs e)
        {
            GotoMemberDashboard(Convert.ToInt32(lblMemberID.Text), Convert.ToInt32(ddlAssociates.SelectedValue.ToString()));
        }

        protected void btnAddContentModule_OnClick(object sender, EventArgs e)
        {
            try
            {
                Session["UserID"] = hdnMemberID.Value;
                string uname = string.Empty;
                //uname = hdnLoginName.Value;
                uname = lblloginname.Text;
                DataTable dtobjMemberSite = adminobj.GetProfileIDByUserEmail(uname, lblVertical.Text);
                if (dtobjMemberSite != null)
                {
                    Session["ProfileID"] = dtobjMemberSite.Rows[0]["profile_id"].ToString();
                }

                Response.Redirect("~/Admin/SetupContentModule.aspx?SearchSelectedValue=" + EncryptDecrypt.DESEncrypt(drpcategory.SelectedValue) + "&SearchInputValue=" + EncryptDecrypt.DESEncrypt(txtcategory.Text.Trim()));
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CustomerServiceNew.aspx.cs", "btnAddContentModule_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        //protected void btnAddActivity_Click(object sender, EventArgs e)
        //{
        //    string url = "/Admin/ActivityLog.aspx?PID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&UID=" + EncryptDecrypt.DESEncrypt(hdnUID.Value);
        //    string fullUrl = "window.open('" + url + "', '_blank', '')";
        //    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
        //    //Response.Redirect("~/Admin/ActivityLog.aspx?PID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&UID=" + EncryptDecrypt.DESEncrypt(hdnUID.Value));
        //}

        //protected void btnSponserAds_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string url ="/Admin/SponsorAdsPreview.aspx?userid=" + EncryptDecrypt.DESEncrypt(hdnUID.Value) + "&profileid=" + EncryptDecrypt.DESEncrypt(hdnPID.Value);
        //        //Response.Redirect("~/Admin/SponsorAdsPreview.aspx?userid=" + EncryptDecrypt.DESEncrypt(hdnUID.Value) + "&profileid=" + EncryptDecrypt.DESEncrypt(hdnPID.Value));

        //        string fullUrl = "window.open('" + url + "', '_blank', '')";
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);               

        //    }
        //    catch (Exception ex)
        //    { 
        //    }
        //}


        private string GetProfileSubTypeValue(int psTypeID)
        {
            btnUpgrade.Visible = false;
            btnSponserAds.Visible = false;
            //btnAddActivity.Visible = false;
            string value = "";
            if (psTypeID == Convert.ToInt32(ProfileSubscriptionTypes.Premium))
                value = "Premium";
            else if (psTypeID == Convert.ToInt32(ProfileSubscriptionTypes.PaidLite))
            {
                btnAddActivity.Visible = true;
                btnSponserAds.Visible = true;
                btnUpgrade.Visible = true;
                value = "Paid Basic";
            }
            else if (psTypeID == Convert.ToInt32(ProfileSubscriptionTypes.SponsoredLite))
            {
                btnAddActivity.Visible = true;
                btnSponserAds.Visible = true;
                btnUpgrade.Visible = true;
                value = "Sponsored Basic";
            }
            return value;
        }


        protected void btnBillingHistory_Click(object sender, EventArgs e)
        {
            string strPprofileID = hdnPID.Value;
            string urlinfo = Page.ResolveClientUrl("~/Admin/BillingHistory.aspx?pid=" + EncryptDecrypt.DESEncrypt(strPprofileID));
            Response.Redirect(urlinfo);
        }
        protected void btnUpgradeModules_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/AdminRenewalStore.aspx?ProfileID=" + EncryptDecrypt.DESEncrypt(hdnPID.Value) + "&SelectedValue=" + EncryptDecrypt.DESEncrypt(drpcategory.SelectedValue) + "&SelectedText=" + EncryptDecrypt.DESEncrypt(txtcategory.Text) + "&MemID=" + EncryptDecrypt.DESEncrypt(lblMemberID.Text) + "&ProfileName=" + EncryptDecrypt.DESEncrypt(lblProfName.Text));
            Response.Redirect(urlinfo);
        }
    }

}