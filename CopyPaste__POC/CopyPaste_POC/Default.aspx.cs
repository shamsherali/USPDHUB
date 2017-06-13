using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CopyPaste_POC
{
    public partial class Default : System.Web.UI.Page
    {
        public string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                CreateDomainUrl(url);
            }
        }
        protected void btnSubmit_Click(object seder, EventArgs e)
        {
            string username = string.Empty;
            string passcode = string.Empty;
            username = txtEmail.Text;
            passcode = txtPassword.Text;
            int roleID = 0;
            string DomainName = Convert.ToString(Session["VerticalDomain"]);
            DataTable dtobj = GetUserDetails(username, DomainName);
            if (dtobj != null)
            {
                DataTable dtAssociate = new DataTable();
                Session["C_USER_ID"] = null;
                int associateId = 0;
                if (dtobj.Rows.Count == 0)
                {
                    dtAssociate = GetAssociateUserDetails(username, DomainName);
                    if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                    {
                        Session["C_USER_ID"] = dtAssociate.Rows[0]["User_ID"].ToString();
                        associateId = Convert.ToInt32(dtAssociate.Rows[0]["User_ID"].ToString());
                        Session["C_USER_NAME"] = username.ToString();
                        Session["C_FIRST_NAME"] = dtAssociate.Rows[0]["Firstname"].ToString();
                        Session["C_LAST_NAME"] = dtAssociate.Rows[0]["Lastname"].ToString();
                        dtobj = GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                    }
                    else
                        Session["C_USER_NAME"] = Session["C_USER_ID"] = null;
                }

                if (dtobj.Rows.Count == 1)
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                    {
                        //Populate the profile details
                        DataTable bustabobj = new DataTable();
                        bustabobj = GetBusinessProfileByUserID(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                        if (bustabobj.Rows.Count == 1)
                        {
                            int code = 1;
                            string passcod = string.Empty;
                            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") //added by venkat
                            {
                                passcod = EncryptDecrypt.DESDecrypt(dtAssociate.Rows[0]["Password"].ToString());
                                code = passcode.CompareTo(passcod.ToString());
                            }
                            else
                            {
                                passcod = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                                code = passcode.CompareTo(passcod.ToString());
                            }

                            if (code == 0)
                            {
                                //Assign to Session variables 
                                Session["UserID"] = dtobj.Rows[0]["User_ID"].ToString();
                                Session["username"] = dtobj.Rows[0]["Username"].ToString();
                                Session["Name"] = dtobj.Rows[0]["firstname"].ToString();
                                Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                                Session["ProfileID"] = Convert.ToString(bustabobj.Rows[0]["Profile_ID"]);
                                Response.Redirect(Session["RootPath"] + "/pdfconvertpoc/Editor.aspx");
                            }
                            else
                                lblmsg.Text = "<font face=arial color=red size=2>Invalid password; please try again.</font>";
                        }
                        else
                            lblmsg.Text = "<font face=arial color=red size=2>This User has multiple Profiles Exists. Please contact customer support. </font>";
                    }
                    else
                        lblmsg.Text = "<font face='arial' color='red' size='2'>Invalid login name. Please check your login name.</font>";
                }
                else
                    lblmsg.Text = "<font face=arial color=red size=2>Invalid username or password, please try again.</font>";
            }
            else
                lblmsg.Text = "<font face=arial color=red size=2>Invalid username & Password</font>";
        }
        private void CreateDomainUrl(string url)
        {
            string host = new System.Uri(url).Host.ToLower();
            int index = host.LastIndexOf('.'), last = 3;
            while (index > 0 && index >= last - 3)
            {
                last = index;
                index = host.LastIndexOf('.', last - 1);
            }
            string domain = host.Substring(index + 1);
            string[] domainarray = domain.Split('.');
            string verticalDomain = domain.Replace(".", "");
            if (verticalDomain != "")
            {
                Session["VerticalDomain"] = verticalDomain;
                DataTable dtConfigs = GetVerticalConfigsByType(verticalDomain, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            HttpContext.Current.Session["RootPath"] = row[1].ToString();
                    }
                }
            }
        }
        #region database acess
        private DataTable GetVerticalConfigsByType(string verticalDomain, string type)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDomainConfigsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", verticalDomain);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        private DataTable GetUserDetails(string username, string domainName)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(user);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        private DataTable GetAssociateUserDetails(string userName, string domainName)
        {
            DataTable msgs = new DataTable("Associate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAssociateUserDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        private DataTable GetUserDetailsByID(int userID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(user);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        private DataTable GetBusinessProfileByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessProfileByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        #endregion
    }
}