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

namespace USPDHUB.Controls
{
    public partial class AdminLogin : System.Web.UI.UserControl
    {
        public string LoginCokValue = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            // *** Start to read the Cookie for the username to prepapulate ***
            HttpCookie myCookie = new HttpCookie("AdminUSPDHUBUserID");
            myCookie = Request.Cookies["AdminUSPDHUBUserID"];
            if (myCookie != null)
            {
                if (email.Text.Length > 0)
                {
                    LoginCokValue = email.Text;
                }
                else
                {
                    email.Text = myCookie.Values["email"];
                    password.Attributes.Add("value", EncryptDecrypt.DESDecrypt(myCookie.Values["password"]));
                }
            }
            email.Focus();
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string username = string.Empty;
            string passcode = string.Empty;

            username = email.Text;
            passcode = password.Text;
            DataTable dtobj = new DataTable();
            AdminBLL userobj = new AdminBLL();
            dtobj = userobj.GetAdminUserDetailsCheck(username);
            if (dtobj != null)
            {
                if (dtobj.Rows.Count == 1)
                {
                    passcode = EncryptDecrypt.DESEncrypt(passcode);
                    if (passcode.CompareTo(dtobj.Rows[0]["Password"].ToString()) == 0)
                    {
                        // Save the username in Cookie
                        if (wowzzyID.Checked)
                        {
                            HttpCookie cookie = new HttpCookie("AdminUSPDHUBID");
                            cookie.Name = "AdminUSPDHUBUserID";
                            cookie.Values["email"] = email.Text;
                            cookie.Values["password"] = passcode;
                            cookie.Expires = DateTime.Now.AddDays(15);
                            Response.Cookies.Add(cookie);

                        }
                        // Verify which user it is.
                        string urlinfo = "";
                        if (Convert.ToInt32(dtobj.Rows[0]["Role_ID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Admin)
                            urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx");
                        else if (Convert.ToInt32(dtobj.Rows[0]["Role_ID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.AdminStaff)
                            urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx");
                        else if (Convert.ToInt32(dtobj.Rows[0]["Role_ID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Developer)
                            urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx");
                        else
                            lblmsg.Text = "<font face=arial color=red size=2>Can not Recognize User.<BR> Please contact Site Administrator.</font>";

                        if (urlinfo != "")
                        {
                            Session["AdminUserRole"] = Convert.ToString(dtobj.Rows[0]["Role_ID"]);
                            Session["adminuserid"] = dtobj.Rows[0]["Admin_ID"].ToString();                            
                            Response.Redirect(urlinfo);
                        }
                    }
                    else
                        lblmsg.Text = "<font face=arial color=red size=2>Invalid Password. Try again..!</font>";
                }
                else
                    lblmsg.Text = "<font face=arial color=red size=2>Invalid username & Password</font>";
            }
            else
            {
                lblmsg.Text = "<font face=arial color=red size=2>Invalid username & Password</font>";
            }
        }
    }
}