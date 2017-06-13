using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Configuration;


namespace USPDHUB.Admin
{
    public partial class ActivityLog : System.Web.UI.Page
    {
       
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        AdminBLL objAdmin = new AdminBLL();
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        int ActivityID = 0;
        int? ProfileID = null;
        int UserID = 0;
        string DomainName=string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["AID"]!= null)
                {
                    ActivityID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["AID"].ToString()));
                }
                if (Request.QueryString["PID"] != null && Request.QueryString["UID"] != null)
                {
                    int PID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["PID"].ToString()));
                    ProfileID = PID;
                    UserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["UID"].ToString()));
                    DataTable dt = new DataTable();
                    dt = objBus.GetProfileDetailsByProfileID(PID);
                    rdbtnUser.Text = UserID + "-" + dt.Rows[0]["Profile_name"].ToString();
                    DomainName = dt.Rows[0]["Vertical_Name"].ToString();
                    divUsers.Style.Add("display", "block");
                    if(rdbtnUser.Checked==true)
                       divDomain.Style.Add("display", "none");
                }
                
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/Default.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!IsPostBack)
                {
                    DataTable dtverticals = agencyobj.GetActiveVerticals();
                    ddlDomainName.DataSource = dtverticals;
                    ddlDomainName.DataTextField = "Vertical_Name";
                    ddlDomainName.DataValueField = "Vertical_Value";
                    ddlDomainName.DataBind();
                    ddlDomainName.Items.Insert(0, new ListItem("All Verticals", ""));
                    if (ActivityID > 0)
                        LoadActivityData(ActivityID);
                }
             
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ActivityLog.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadActivityData(int ActivityID)
        {
            DataTable dtActivity = new DataTable();
            dtActivity = objBus.GetManageLogByActivityID(ActivityID);
            if (dtActivity.Rows.Count > 0)
            {
                RadEditor1.Content = dtActivity.Rows[0]["EditPreviewHtml"].ToString();
                if (string.IsNullOrEmpty(dtActivity.Rows[0]["Vertical"].ToString()))
                {
                    ddlDomainName.SelectedItem.Text = "All Verticals";
                }
                else
                {
                    ddlDomainName.SelectedItem.Text = dtActivity.Rows[0]["Vertical"].ToString();
                }
                
                if (Convert.ToString(dtActivity.Rows[0]["ExpiryDate"]) != string.Empty)
                {
                    
                    txtExDate.Text = Convert.ToDateTime(dtActivity.Rows[0]["ExpiryDate"]).ToShortDateString();
                    txtExHours.Enabled = true;
                    txtExMinutes.Enabled = true;
                    ddlExSS.Enabled = true;

                    DateTime expiryTime = Convert.ToDateTime(dtActivity.Rows[0]["ExpiryDate"]);

                    if (expiryTime.ToString().Contains("PM"))
                    {
                        if (expiryTime.Hour > 12)
                        {
                            txtExHours.Text = (expiryTime.Hour - 12).ToString();
                        }
                        else
                        {
                            txtExHours.Text = (expiryTime.Hour).ToString();
                        }
                        ddlExSS.SelectedValue = "PM";
                    }
                    else
                    {
                        if (expiryTime.Hour == 0)
                        {
                            txtExHours.Text = "12";
                        }
                        else
                        {
                            txtExHours.Text = (expiryTime.Hour).ToString();
                        }
                        ddlExSS.SelectedValue = "AM";
                    }
                    txtExMinutes.Text = expiryTime.Minute.ToString();

                }
                else
                {
                    txtExHours.Enabled = false;
                    txtExMinutes.Enabled = false;
                    ddlExSS.Enabled = false;
                }
            }
        }
      
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/ManageActivityLog.aspx"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";
                DateTime? expiryDate=null;
                if(rdbtnAllUser.Checked==true)
                    DomainName = string.Empty;
                if (string.IsNullOrEmpty(DomainName))
                {
                    if (ddlDomainName.SelectedItem.Text == "All Verticals")
                        DomainName = string.Empty;
                    else
                        DomainName = ddlDomainName.SelectedItem.Text;
                }

                string previewHtml = string.Empty;
                previewHtml = RadEditor1.Content;
                string editHTML = RadEditor1.Content;
             
                if (txtExDate.Text.Trim() != "")
                {
                    if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
                    {
                        exHour = txtExHours.Text;
                        if (exHour == "")
                            exHour = "12";
                        exMin = txtExMinutes.Text;
                        if (exMin == "")
                            exMin = "00";
                        exSS = ddlExSS.SelectedValue.ToString();

                        exTime = exHour + ":" + exMin + ":00 " + exSS;
                    }
                    else
                    {
                        exHour = "12";
                        exMin = "00";
                        exSS = "AM";

                        exTime = exHour + ":" + exMin + ":00 " + exSS;
                    }
                    expiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
                }
                if (rdbtnAllUser.Checked == true)
                {
                    ProfileID = null;
                }
                int i = objAdmin.InsertActivityLog(ActivityID, string.Empty, editHTML, previewHtml, DomainName, ProfileID, expiryDate);
                if (i > 0)
                {
                    Response.Redirect("~/Admin/ManageActivityLog.aspx");
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ActivityLog.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

   
    }
}