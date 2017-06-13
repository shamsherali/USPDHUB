using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class RedirectDashboard : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL busobj = new BusinessBLL();
        Consumer conobj = new Consumer();
        public int loginMemberID = 0;
        public int UserID = 0;
        public int ProfileID = 0;
        public int roleID = 0;
        public bool Redirectflag = true;
        public string Renew = "";
        public int CheckRenewalValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string domainName = objCommon.CreateDomainUrl(url);
                Session["HelpCheck"] = "1";

                if (Request.QueryString["MemID"] != null)
                {
                    loginMemberID = Convert.ToInt32(Request.QueryString["MemID"].ToString());
                }
                if (loginMemberID > 0)
                {
                    DataTable dtobj = conobj.GetUserDetailsByID(loginMemberID);
                    if (dtobj != null)
                    {
                        if (dtobj.Rows.Count == 1)
                        {
                            if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                            {
                                //Assign to Session variables 
                                Session["UserID"] = dtobj.Rows[0]["User_ID"].ToString();
                                UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                Session["username"] = dtobj.Rows[0]["Username"].ToString();
                                Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                                roleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);
                                # region For Business User

                                if (roleID == (int)UtilitiesBLL.RoleTypes.Business)
                                {
                                    //Populate the profile details
                                    DataTable bustabobj = new DataTable();
                                    bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                                    if (bustabobj.Rows.Count == 0)
                                    {
                                        Redirectflag = false;
                                        Session["ProfileID"] = null;
                                        Session["UserID"] = null;
                                        Session["BusinessType"] = null;
                                    }
                                    else if (bustabobj.Rows.Count == 1)
                                    {
                                        // Get the ProfileID for further propogations         
                                        ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                        Session["UserID"] = UserID.ToString();
                                        Session["ProfileID"] = ProfileID.ToString();
                                        Session["Generaltab"] = "";
                                        Session["UserLogin"] = "1";
                                        Session["firstname"] = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.
                                        // End get business type
                                        // Get User Subscription Details
                                        DataTable dtSubscriptionDetails = new DataTable();
                                        dtSubscriptionDetails = busobj.Getorderidbyuserid(UserID);
                                        if (dtSubscriptionDetails.Rows.Count > 0)
                                        {
                                            DateTime renewalDate;
                                            renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                            if (renewalDate.Date >= DateTime.Now.Date)
                                            {
                                                //Urlinfo = Urlinfo + "/Business/MyAccount/Default.aspx";
                                            }
                                            else
                                            {
                                                Renew = "1";
                                                GetFreeUserDetails(Session["RootPath"].ToString());
                                            }

                                        }
                                        else
                                        {
                                            GetFreeUserDetails(Session["RootPath"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        Redirectflag = false;
                                    }
                                }
                                # endregion
                                else if (roleID == (int)UtilitiesBLL.RoleTypes.Consumer)
                                {

                                }
                                else
                                {
                                    Redirectflag = false;
                                }
                                //  if user user renewal date is greater than today date
                                if (CheckRenewalValue == 0)
                                {
                                    if (Convert.ToInt32(Session["RoleID"]) == (int)UtilitiesBLL.RoleTypes.Business)
                                    {
                                        Session["UserID"] = UserID.ToString();
                                        Session["ProfileID"] = ProfileID.ToString();
                                        Session["UserLogin"] = "1";
                                        Response.Redirect(Session["RootPath"].ToString() + "/Business/MyAccount/Default.aspx");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "RedirectDashboard.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetFreeUserDetails(string urlInfo)
        {
            try
            {
                // Check For Free User
                DataTable dtobj = busobj.GetUserDetailsByUserID(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
                        Session["Free"] = "1";
                    if (Renew == "1")
                    {
                        Session["Free"] = "1";
                        Session["Renewal"] = "1";
                    }
                    Response.Redirect(Session["RootPath"].ToString() + "/Business/MyAccount/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "RedirectDashboard.aspx.cs", "GetFreeUserDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}