using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class GenerateCodes : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public bool IsSuperAdmin = true;

        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();


        public string RootPath = "";
        public string DomainName = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }

            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();

            hdnSubAppsCount.Value = System.Configuration.ConfigurationManager.AppSettings.Get("SubAppsCount").ToString();
            if (!IsPostBack)
            {
                DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                if (Session["C_USER_ID"] != null)
                {
                    DataTable dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                    if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                        IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = Resources.LabelMessages.SubAppReqCodesUnPaidSuccess;
                bool isPaid = false;
                if (rbPaid.Checked)
                {
                    isPaid = true;
                    msg = Resources.LabelMessages.SubAppReqCodesPaidSuccess;
                }
                int reqSubAppCount = Convert.ToInt32(txtAppsCount.Text.Trim());
                msg = msg.Replace("#Count#", reqSubAppCount.ToString());
                Session["SubAppReqCodesSuccessMsg"] = msg;
                int count = objAgency.GenerateSubAppCodes(ProfileID, C_UserID, reqSubAppCount, isPaid);
                if (count == reqSubAppCount)
                {
                    //lblsuccess.Text = msg;
                    if (rbPaid.Checked)
                    {

                        string Contactus = string.Empty;
                        UtilitiesBLL ObjUtl = new UtilitiesBLL();

                        string ToEmail = string.Empty;
                        string EmailSubject = "Pre-Paid codes";
                        string FromEmail = "";
                        string CCEmail = "";

                        DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                        if (dtConfigsemails.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtConfigsemails.Rows)
                            {
                                if (row[0].ToString() == "EmailInfo")
                                {
                                    FromEmail = row[1].ToString();
                                    break;
                                }
                            }
                        }
                        DataTable dtprofiledetails = new DataTable();
                        dtprofiledetails = objBus.GetProfileDetailsByProfileID(ProfileID);
                        string profileName = string.Empty;
                        if (dtprofiledetails.Rows.Count > 0)
                        {
                            profileName = dtprofiledetails.Rows[0]["Profile_Name"].ToString();
                        }
                        string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";

                        // Note:: First Email ID is TO emailID Remain IDs are CC IDS
                        StreamReader emaildsReader = File.OpenText(strfilepath + "GenerateCodesEmailIDs.txt");
                        string ids = emaildsReader.ReadToEnd();

                        StreamReader re = File.OpenText(strfilepath + "GenerateCodes.txt");
                        StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                        string msgbody = string.Empty;
                        string desclaimer = string.Empty;
                        while ((desclaimer = reDeclaimer.ReadLine()) != null)
                        {
                            msgbody = msgbody + desclaimer;
                        }
                        string contentBody = string.Empty;
                        string content = string.Empty;
                        while ((content = re.ReadLine()) != null)
                        {
                            contentBody = contentBody + content + "<br/>";
                        }
                        re.Close();
                        re.Dispose();
                        msgbody = msgbody.Replace("#RootUrl#", RootPath);
                        msgbody = msgbody.Replace("#msgBody#", contentBody);
                        msgbody = msgbody.Replace("#ProfileID#", ProfileID.ToString());
                        msgbody = msgbody.Replace("#ProfileName#", profileName);
                        msgbody = msgbody.Replace("#Count#", txtAppsCount.Text.Trim());
                        emaildsReader.Close();
                        emaildsReader.Dispose();
                        reDeclaimer.Close();
                        reDeclaimer.Dispose();
                        //sending email 
                        var result = ObjUtl.SendWowzzyEmail(FromEmail, ids, EmailSubject, msgbody, CCEmail, "", DomainName);
                    }
                }
                else
                {
                    lblsuccess.Text = "<font color='red'>" + Resources.LabelMessages.SubAppReqCodesFailed + "</font>";
                }
            }
            catch (Exception ex)
            {
                lblsuccess.Text = "<font color='red'>" + ex.Message.ToString() + "</font>";
            }
            rbPaid.Checked = true;
            txtAppsCount.Text = "";
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendInvitation.aspx"));
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendInvitation.aspx"));
        }
    }
}