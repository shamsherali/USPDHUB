using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace USPDHUB.Admin
{
    public partial class TrainingUserManagement : System.Web.UI.Page
    {
        public int AdminUserID = 0;
        public string Userid = string.Empty;
        public Boolean TypeOfBusiness = false;
        BusinessBLL Busobj = new BusinessBLL();
        AdminBLL adminobj = new AdminBLL();
        CommonBLL objCommonBll = new CommonBLL();
        AgencyBLL agencyobj = new AgencyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] != null)
                {
                    AdminUserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!IsPostBack)
                {
                    FillGrid();// Populate Data in to TrainingUsersGrid
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void FillGrid()
        {
            //Populate Data in to TrainingUsersGrid
            try
            {
                DataTable dtobj = new DataTable();
                dtobj = adminobj.FillTrainingUsersData();
                if (dtobj.Rows.Count <= 0)
                    btnDelete.Visible = false;
                Session["TrainingUsers"] = dtobj;
                TrainingUsersGrid.DataSource = dtobj;
                TrainingUsersGrid.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "FillGrid", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void DeleteUsersRecord(object sender, EventArgs e)
        {
            try
            {
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in TrainingUsersGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        int uid = int.Parse(((Label)(TrainingUsersGrid.Rows[row.RowIndex].FindControl("Label1"))).Text);

                        #  region user tracking
                        // user tracking                           
                        string hostName = System.Net.Dns.GetHostName();
                        string localipaddress = string.Empty;
                        System.Net.IPHostEntry local = System.Net.Dns.GetHostEntry(hostName);
                        foreach (System.Net.IPAddress useripaddres in local.AddressList)
                        {
                            localipaddress = useripaddres.ToString();

                        }
                        # endregion
                        adminobj.DeleteUsersRecord(uid, AdminUserID, localipaddress);
                    }
                }
                FillGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "DeleteUsersRecord", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void TrainingUsersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //delete Record form ConsumersGrid
                int uid = int.Parse(((Label)(TrainingUsersGrid.Rows[e.RowIndex].FindControl("Label1"))).Text);
                AdminBLL adminObj = new AdminBLL();

                string hostName = System.Net.Dns.GetHostName();
                string localipaddress = string.Empty;
                System.Net.IPHostEntry local = System.Net.Dns.GetHostEntry(hostName);
                foreach (System.Net.IPAddress useripaddres in local.AddressList)
                {
                    localipaddress = useripaddres.ToString();

                }
                adminObj.DeleteUsersRecord(uid, AdminUserID, localipaddress);
                FillGrid();
                lblSuccess.Text = "<font size='2' color='green'>Selected Training user(s) has been deleted successfully.</font>";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "TrainingUsersGrid_RowDeleting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void TrainingUsersGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                #region
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lbltype = e.Row.FindControl("lbltype") as Label;
                    Label lblroletype = e.Row.FindControl("Label4") as Label;
                    string uname = lblroletype.Text;
                    Userid = TrainingUsersGrid.DataKeys[e.Row.RowIndex].Value.ToString();
                    DataTable dtprofiledetails = new DataTable();
                    DataTable dtuser = new DataTable();
                    dtuser = Busobj.GetUserDetailsByUserID(int.Parse(Userid));
                    int roleid = Convert.ToInt32(dtuser.Rows[0]["Role_ID"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        bool Isfree = false;
                        if (dtuser.Rows[0]["IsFree"] != null)
                        {
                            if (dtuser.Rows[0]["IsFree"].ToString() != "")
                            {
                                Isfree = Convert.ToBoolean(dtuser.Rows[0]["IsFree"].ToString());
                            }
                        }
                        if (Isfree == false)
                        {
                            if (roleid == 2)
                            {
                                lbltype.Text = "Paid Member";
                            }
                            if (roleid == 1)
                            {
                                lbltype.Text = "Free Listing";
                            }
                        }
                        else
                        {
                            lbltype.Text = "Free Listing";
                        }
                    }
                #endregion

                    dtprofiledetails = Busobj.GetBusinessDeatilsByUserID(int.Parse(Userid));
                    if (dtprofiledetails.Rows.Count == 1)
                    {
                        Label lblprofilename = e.Row.FindControl("lblcompanyname") as Label;
                        lblprofilename.Text = dtprofiledetails.Rows[0]["Profile_Name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "TrainingUsersGrid_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void TrainingUsersGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TrainingUsersGrid.PageIndex = e.NewPageIndex;
            TrainingUsersGrid.DataBind();
            FillGrid();
        }
        protected void TrainingUsersGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }

        protected string GetRoleName(int gval)
        {
            if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Admin) == gval)
                return "Admin";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.AdminStaff) == gval)
                return "AdminStaff";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Consumer) == gval)
                return "Consumer";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Business) == gval)
                return "Business";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Advertiser) == gval)
                return "Advertiser";
            else
                return string.Empty;

        }

        protected void btn_goDashboard(object sender, EventArgs e)
        {
            try
            {
                string dashboardurl = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/Admin/Default.aspx";
                Response.Redirect(dashboardurl);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "btn_goDashboard", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [WebMethod]
        public static string ServerSidefill(string EMID)
        {
            BusinessBLL ObjWow = new BusinessBLL();
            string Typevalue = "";
            try
            {
                if (EMID.Length > 0)
                {
                    Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    if (!rEMail.IsMatch(EMID))
                    {
                        Typevalue = "3";
                    }
                    else
                    {
                        try
                        {
                            // address = EMID;
                            int CountUser;
                            CountUser = ObjWow.CheckUserNameandPasswordForVaildUser(EMID, "", "");
                            string s = "SELECT COUNT(SuperAdmin_ID) FROM T_Users WHERE Username='" + EMID + "'";
                            SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                            SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
                            int count = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                            USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
                            if (count > 0)
                                Typevalue = "4";
                            else
                            {
                                if (CountUser == 0)
                                {
                                    Typevalue = "1";
                                }
                                else
                                {
                                    Typevalue = "2";
                                }
                            }
                        }
                        catch
                        {
                            Typevalue = "3";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "ServerSidefill", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return Typevalue;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string Password = objCommonBll.GenerateRandomPassword();

                #region Getting Latidude & longtidude values
                string fullAddress = txtAgencyAddress.Text + "," + txtCity.Text + "," + txtState.Text + "," + txtZipCode.Text;
                Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

                double latitude1 = Convert.ToDouble(coordinates.Latitude);
                double longitude1 = Convert.ToDouble(coordinates.Longitude);
                #endregion

                int i = agencyobj.InsertTrainingUserDetails(txtAgencyName.Text, txtContactPerson.Text, txtEmail.Text, EncryptDecrypt.DESEncrypt(Password), txtAgencyAddress.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtphonenumber.Text, latitude1, longitude1, ddlVertical.SelectedValue);
                if (i > 0)
                {
                    SendActivationEmail(txtEmail.Text, Password);
                    lblSuccess.Text = "<font size='2' color='green'>Training user has been created successfully.</font>";
                    cleardata();
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendActivationEmail(string username, string password)
        {
            try
            {
                string strfilepath = Server.MapPath("~") + "\\EmailContent\\";
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
                msgbody = msgbody.Replace("#RootUrl#", System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath"));
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#Link#", "<a href='" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/Login.aspx' target='_blank'>Login</a>");
                msgbody = msgbody.Replace("#Email#", username);
                msgbody = msgbody.Replace("#Password#", password);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                string returnval = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                returnval = utlobj.SendWowzzyEmail(ConfigurationManager.AppSettings.Get("Emailinfo"), username, "Agency Account Details", msgbody, ccemail, "", "uspdhub");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "SendActivationEmail", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void cleardata()
        {
            txtAgencyAddress.Text = txtAgencyName.Text = txtCity.Text = "";
            txtContactPerson.Text = txtEmail.Text = txtphonenumber.Text = "";
            txtState.Text = txtZipCode.Text = "";
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cleardata();
                lblSuccess.Text = lblUserNameCheck.Text = "";
                popcreateshortcut.Show();
                // *** Gettting Active Verticals *** //
                DataTable dtverticals = agencyobj.GetActiveVerticals();
                ddlVertical.DataSource = dtverticals;
                ddlVertical.DataTextField = "Vertical_Name";
                ddlVertical.DataValueField = "Vertical_Value";
                ddlVertical.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TrainingUserManagement.aspx.cs", "BtnAdd_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}