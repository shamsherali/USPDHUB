using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using USPDHUBDAL;
using System.IO;

namespace USPDHUB.Admin
{
    public partial class ModifyUserDetails : System.Web.UI.Page
    {
        public int UserID = 0;
        public int RoleId = 0;
        public bool isFree = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        UserID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    }
                }

                if (!IsPostBack)
                {
                    // Load the country dropdown.
                    ListItem item = new ListItem();
                    item.Value = "0";
                    item.Text = "-Select Country-";
                    ddlCountry.Items.Add(item);
                    ListItem item1 = new ListItem();
                    item1.Value = "1";
                    item1.Text = "USA";
                    ddlCountry.Items.Add(item1);
                    ddlCountry.SelectedIndex = 1;


                    AdminBLL admobj = new AdminBLL();
                    DataTable dtobj = new DataTable();

                    string username = String.Empty;
                    int tmpUserID = Convert.ToInt32(Request.QueryString["ID"]);
                    dtobj = admobj.GetUserDetailsByID(tmpUserID);

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

                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void PopulateUserDetails(DataTable dtobj)
        {
            try
            {
                //User details
                txtEmail.Text = dtobj.Rows[0]["Username"].ToString();
                txtemail2.Text = dtobj.Rows[0]["User_email"].ToString();
                txtPassword.Text = hdnOld.Value = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                txtRePassword.Text = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                txtQuestion1.Text = dtobj.Rows[0]["Forgot_Password_Q1"].ToString();
                txtQuestion2.Text = dtobj.Rows[0]["Forgot_Password_Q2"].ToString();
                txtAnswer1.Text = dtobj.Rows[0]["Forgot_Password_A1"].ToString();
                txtAnswer2.Text = dtobj.Rows[0]["Forgot_Password_A2"].ToString();
                txtFirstName.Text = dtobj.Rows[0]["Firstname"].ToString();
                txtLastName.Text = dtobj.Rows[0]["Lastname"].ToString();
                txtAddress1.Text = dtobj.Rows[0]["User_address1"].ToString();
                txtAddress2.Text = dtobj.Rows[0]["User_address2"].ToString();
                txtCity.Text = dtobj.Rows[0]["User_city"].ToString();
                txtState.Text = dtobj.Rows[0]["User_state"].ToString();
                txtZipCode.Text = dtobj.Rows[0]["User_zipcode"].ToString();
                txtPhone.Text = dtobj.Rows[0]["User_phone"].ToString();
                if (!string.IsNullOrEmpty(dtobj.Rows[0]["IsFree"].ToString()))
                    hdnIsFree.Value = dtobj.Rows[0]["IsFree"].ToString();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
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
                //int RoleId = 0;
                string Status = string.Empty;


                Email = txtemail2.Text.Trim();
                UserName = txtEmail.Text.Trim();
                Password = txtPassword.Text.Trim();
                FirstName = txtFirstName.Text.Trim();
                LastName = txtLastName.Text.Trim();
                PasswordQuestrion1 = txtQuestion1.Text.Trim();
                PasswordAnswer1 = txtAnswer1.Text.Trim();
                PasswordQuestrion2 = txtQuestion2.Text.Trim();
                PasswordAnswer2 = txtAnswer2.Text.Trim();
                Address1 = txtAddress1.Text.Trim();
                Address2 = txtAddress2.Text.Trim();
                City = txtCity.Text.Trim();
                State = txtState.Text.Trim();
                Country = ddlCountry.SelectedItem.Text;
                ZipCode = txtZipCode.Text.Trim();
                Phone = txtPhone.Text.Trim();

                RoleId = Convert.ToInt32(UtilitiesBLL.RoleTypes.Business);
                Status = UtilitiesBLL.Statuses.Active.ToString();
                AdminBLL admobj = new AdminBLL();
                DataTable dtobj = new DataTable();
                int addflag = 0;
                if (UserID > 0) // Consumer registration Updated successfully.
                {
                    addflag = admobj.AddConsumer(UserName, EncryptDecrypt.DESEncrypt(Password), Email, FirstName, LastName, PasswordQuestrion1, PasswordAnswer1, PasswordQuestrion2, PasswordAnswer2, RoleId, true, Address1, Address2, City, State, Country, Status, ZipCode, Phone, UserID, Convert.ToBoolean(hdnIsFree.Value));
                    string urlinfo = Page.ResolveClientUrl("~/Admin/ConsumerManagement.aspx?UFlag=1");
                    CommonBLL objCommon = new CommonBLL();
                    string domainName = "";
                    string rootPath = "";
                    string emailInfo = "";

                    /*************** Getting DomainName, RootPath and EmailInfo ***************/
                    domainName = objCommon.GetDomainNameByCountry(UserID);

                    DataTable dtDomainInfo = new DataTable();
                    dtDomainInfo = objCommon.GetVerticalConfigsByType(domainName, "Paths");
                    if (dtDomainInfo.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDomainInfo.Rows)
                        {
                            if (row[0].ToString() == "RootPath")
                                rootPath = row[1].ToString();
                        }
                    }

                    DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(domainName, "EmailAccounts");
                    if (dtConfigsemails.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails.Rows)
                        {
                            if (row[0].ToString() == "EmailInfo")
                                emailInfo = row[1].ToString();
                        }
                    }
                    /*************** Getting DomainName, RootPath and EmailInfo ***************/

                    if (hdnOld.Value != Password)
                    {
                        #region Send Change Password Email
                        string strfilepath = Server.MapPath("~") + "\\EmailContent" + domainName + "\\";
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
                        msgbody = msgbody.Replace("#RootUrl#", rootPath);
                        msgbody = msgbody.Replace("#msgBody#", content);
                        msgbody = msgbody.Replace("#Username#", UserName);
                        msgbody = msgbody.Replace("#Password#", Password);
                        re.Close();
                        re.Dispose();
                        reDeclaimer.Close();
                        reDeclaimer.Dispose();
                        string ccemail = string.Empty;
                        UtilitiesBLL utlobj = new UtilitiesBLL();
                        utlobj.SendWowzzyEmail(emailInfo, UserName, "Change Password Service", msgbody, ccemail, "", domainName);

                        #endregion
                    }
                    Response.Redirect(urlinfo);
                }
                else
                {
                    lblmsg.Text = "<Font face=arial color=red size=2>There is problem in Update. Please try again..!";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ModifyUserDetails.aspx.cs", "UserUpdate_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void UserCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsumerManagement.aspx");
        }
    }
}