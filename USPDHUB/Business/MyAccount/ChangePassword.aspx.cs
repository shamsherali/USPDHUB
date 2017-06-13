using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using USPDHUBBLL;
using System.IO;
using System.Web.UI.WebControls;
using System.Web;

public partial class Business_MyAccount_ChangePassword : BaseWeb
{
    public int UserID = 0;
    public int ProfileID = 0;
    public int CUserID = 0;
    public static string Urlreferer = string.Empty;
    public string UserEmail = string.Empty;
    public string UserName = string.Empty;
    public string Password = string.Empty;
    BusinessBLL busobj = new BusinessBLL();
    CommonBLL objCommon = new CommonBLL();
    public string ChangepwdFirsttime = string.Empty;
    string urlinfo1 = string.Empty;
    public string RootPath = "";
    public string DomainName = "";
    AddOnBLL objAddOn = new AddOnBLL();
    AgencyBLL agencyobj = new AgencyBLL();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }

            lblstatus.Text = "";
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            ProfileID = Convert.ToInt32(Session["ProfileID"]);
            UserID = Convert.ToInt32(Session["UserID"]);
            if (Session["firstname"] != null)
            {
                lblfirstname.Text = "<font color=green size=3><b>" + Session["firstname"].ToString() + "</B></font>";
            }
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
            if (!IsPostBack)
            {
                if (Session["Activate"] != null)
                {
                    lblstatus.Text = "Please check your email for your temporary password.";
                    Session["Activate"] = null;
                }

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    UpdatePanel2.Visible = true;
                    UpCheck.Visible = false;
                    lblerrormessage.Text = "<font face=arial size=2>You do not have permission to access change password.</font>";
                }
                //ends here
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

            }

            if (Request.QueryString != null)
            {
                if (Request.QueryString["CPD"] != null)
                {
                    if (Request.QueryString["CPD"] == "ActivateUser")
                    {
                        // *** Adding default sub domain logo *** //
                        DataTable dtProfile = busobj.GetProfileDetailsByProfileID(ProfileID);
                        if (Convert.ToBoolean(dtProfile.Rows[0]["IsLiteVersion"]))
                        {
                            string sourceLogo = Server.MapPath("/Upload/DefaultLiteLogos/" + DomainName + "logo.jpg");
                            if (File.Exists(sourceLogo))
                            {
                                string destPath = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID;
                                if (!Directory.Exists(destPath))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID);
                                }
                                destPath = destPath + "\\" + ProfileID + "_thumb.jpg";
                                if (string.IsNullOrEmpty(Convert.ToString(dtProfile.Rows[0]["Profile_logo_path"])))
                                {
                                    if (!File.Exists(destPath))
                                    {
                                        File.Copy(sourceLogo, destPath);
                                        string photoFileName = ProfileID + ".jpg";
                                        busobj.UpdateBusinessProfileLogo(photoFileName, ProfileID, UserID, CUserID);
                                    }
                                }
                            }
                        }
                        //if (!Convert.ToBoolean(dtProfile.Rows[0]["IsLiteVersion"]))
                        //{
                        //    DataTable dtInitialAddOns = objAddOn.GetInitialAddOns(DomainName, "AddOn", UserID);
                        //    if (dtInitialAddOns.Rows.Count > 0)
                        //    {
                        //        DataTable dtCustomModuleTemplates = agencyobj.GetCustomModuleTemplates(DomainName, true); // *** Get only content template *** //
                        //        if (dtCustomModuleTemplates.Rows.Count > 0)
                        //        {
                        //            int module = Convert.ToInt32(dtCustomModuleTemplates.Rows[0]["ModuleID"]);
                        //            for (int i = 0; i < dtInitialAddOns.Rows.Count; i++)
                        //            {
                        //                objAddOn.InsertInitialAddOns(Convert.ToInt32(dtInitialAddOns.Rows[i]["DefaultButtonID"]), module, UserID, ProfileID, CUserID);
                        //            }
                        //        }
                        //    }
                        //}
                        ChangepwdFirsttime = "ActivateUser";
                        Lbl_Currentpassword.Text = "Temporary password:";
                        Lbl_ChooseNewPassword.Text = "New password:";
                        Lbl_ReenterNewpassword.Text = "Confirm new password:";
                        Lbl_Msg_Temporarypassword.Text = "Note: Enter the assigned temporary password sent to you in the activation email.";
                        Lbl_Msg_Headermessage.Text = "To continue, please change the temporary password for security purposes.";

                        //btnCancel.Visible = false;
                        //btnCancel.Enabled = false;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ChangePassword.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btndashboard1_Click(object sender, EventArgs e)
    {
        urlinfo1 = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo1);
    }

    protected void Update_Password(object sender, EventArgs e)
    {
        try
        {
            string emailInfo = "";
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        emailInfo = row[1].ToString();
                }
            }
            Consumer conObj = new Consumer();

            string oldpassword = string.Empty;

            DataTable dtobj = conObj.GetUserDetailsByID(UserID);

            if (dtobj.Rows.Count == 1)
            {
                UserEmail = dtobj.Rows[0]["Username"].ToString();
                UserName = dtobj.Rows[0]["username"].ToString();

                oldpassword = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                //   oldpassword =dtobj.Rows[0]["Password"].ToString(); 
            }
            if (txtoldpassword.Text.CompareTo(oldpassword) != 0)
            {
                if (Lbl_Currentpassword.Text != "Temporary password:")
                {
                    lblmsg.Text = "<font color=red size=2> Your old password is incorrect.</font>";
                }
                else
                {
                    lblmsg.Text = "<font color=red size=2> Your temporary password is incorrect.</font>";
                }
            }
            else // Old password is matched.
            {
                // Update the password.
                Password = txtRePassword.Text.ToString().Trim();
                int passwordChanged = 1;// If password changed by user then update his password changed flag by 1, other wise it is zero.
                int updateflag = conObj.UpdateUserPassword(UserID, EncryptDecrypt.DESEncrypt(txtPassword.Text.Trim()), passwordChanged);
                //   int updateflag = conObj.UpdateUserPassword(UserID, txtPassword.Text.Trim(), Password_Changed);
                if (updateflag > 0)
                {
                    #region Send Change Password Email
                    string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
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
                        content = content + input + "<BR/>";
                    }
                    msgbody = msgbody.Replace("#RootUrl#", RootPath);
                    msgbody = msgbody.Replace("#msgBody#", content);
                    msgbody = msgbody.Replace("#Username#", UserName);
                    msgbody = msgbody.Replace("#Password#", Password);
                    re.Close();
                    re.Dispose();

                    // If Turn OFF Emails 09/15/2014
                    DataTable dtUserDetails;
                    dtUserDetails = busobj.GetUserDtlsByUserID(UserID);
                    bool isSendEmail = Convert.ToBoolean(dtUserDetails.Rows[0]["IsTurnOnEmail"].ToString());

                    string toEmails = UserName;
                    if (isSendEmail == false)
                    {
                        toEmails = "";
                        reDeclaimer = File.OpenText(strfilepath + "AutoEmails.txt");
                        while ((desclaimer = reDeclaimer.ReadLine()) != null)
                        {
                            toEmails = toEmails + desclaimer;
                        }
                        reDeclaimer.Close();
                        reDeclaimer.Dispose();
                    }
                    string ccemail = string.Empty;
                    UtilitiesBLL utlobj = new UtilitiesBLL();
                    utlobj.SendWowzzyEmail(emailInfo, toEmails, "Change Password Service", msgbody, ccemail, "", DomainName);

                    #endregion


                    lblstatus.Text = Resources.LabelMessages.Passwordupdated;

                    if (ChangepwdFirsttime == "ActivateUser")
                    {
                        hdn.Value = "1";

                        ScriptManager.RegisterClientScriptBlock(btnUpdate, this.GetType(), "AlFun", "displayalert()", true);

                    }
                }
                else
                {
                    lblmsg.Text = "<font color=red size=2> Your password did not update successfully, please try again..!</font>";
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ChangePassword.aspx.cs", "Update_Password", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

}
