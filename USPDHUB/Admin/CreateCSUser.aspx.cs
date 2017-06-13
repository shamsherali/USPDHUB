using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services;
using USPDHUBBLL;
using System.Data;
using USPDHUBDAL;
using System.IO;
using System.Text;

namespace USPDHUB.Admin
{
    public partial class CreateCSUser : System.Web.UI.Page
    {
        BusinessBLL objWow = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public int AdminUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (Session["adminuserid"] != null)
            {
                AdminUserID = Convert.ToInt32(Session["adminuserid"]);
            }
        }
        protected void btnCreateAdminUser(object sender, EventArgs e)
        {
            try
            {
                int checkUserExits = objWow.CheckUserNameandPasswordForCreateUser(txtEmail.Text.Trim());
                if (checkUserExits != 0)
                {
                    lblerror.Text = "Username already exists. Please try another one.";
                }
                else
                {
                    if (txtPassword.Text.Trim() == txtConfirmPwd.Text.Trim())
                    {
                        objWow.NewAdminUserInsertion(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmail.Text.Trim(), EncryptDecrypt.DESEncrypt(txtPassword.Text.Trim()), AdminUserID);
                        SendregistrationEmail(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim());
                        Response.Redirect("Default.aspx");
                    }
                    else
                        lblerror.Text = "Confirm Password must match Password.";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateCSUser.aspx.cs", "btnCreateAdminUser", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public string SendregistrationEmail(string name, string email1, string password)
        {
            string returnval = string.Empty;
            try
            {
                string emailInfo = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType("uspdhubcom", "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            emailInfo = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContentuspdhubcom\\";
                StreamReader re = File.OpenText(strfilepath + "AdminActivation.txt");
                string content = string.Empty;
                string desclaimer = string.Empty;

                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR/>";
                }
                content = content.Replace("#Email#", email1);
                content = content.Replace("#Password#", password);
                re.Close();
                re.Dispose();
                string ccemail = string.Empty;

                USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
                returnval = utlobj.SendWowzzyEmail(emailInfo, email1, "Auto email for Admin User Details", content, ccemail, "", "uspdhubcom");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateCSUser.aspx.cs", "SendregistrationEmail", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnval;

        }


        [WebMethod]
        public static string ServerSidefill(string emid)
        {
            BusinessBLL objWow = new BusinessBLL();
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
                            int countUser;
                            countUser = objWow.CheckUserNameandPasswordForCreateUser(emid);
                            if (countUser == 0)
                                typevalue = "1";
                            else
                                typevalue = "2";
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
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateCSUser.aspx.cs", "ServerSidefill", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return typevalue;
        }
    }
}