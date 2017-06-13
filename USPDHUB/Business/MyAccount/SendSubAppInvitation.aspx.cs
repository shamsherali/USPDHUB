using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
using Resources;

namespace USPDHUB.Business.MyAccount
{
    public partial class SendSubAppInvitation : System.Web.UI.Page
    {

        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string DomainName = "";
        DataTable dtSubApps = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

            DomainName = Session["VerticalDomain"].ToString();

            lblMessage.Text = "";
            lblErrorMessage.Text = "";

            if (!IsPostBack)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string vertical = DomainName;
                if (DomainName.EndsWith("com"))
                {
                    vertical = DomainName.Substring(0, DomainName.Length - 3);
                }
                dtSubApps = objBus.GetSearchSubAppsByUserID_EmailID(Convert.ToInt32(txtUserID.Text.Trim()), txtEmailID.Text.Trim(),vertical);

                ClearValues();

                pnlInvitation.Visible = false;
                if (dtSubApps.Rows.Count > 0)
                {
                    if (dtSubApps.Rows[0]["USER_ID"].ToString() == Session["userid"].ToString())
                    {
                        lblErrorMessage.Text = "No results found";
                        txtEmailID.Text = "";
                        txtUserID.Text = "";
                    }
                    else
                    {
                        pnlInvitation.Visible = true;

                        lblEmailID.Text = txtEmailID.Text;
                        lblUserID.Text = txtUserID.Text;
                        lblProfileName.Text = dtSubApps.Rows[0]["Profile_name"].ToString();

                        DataTable dtParentProfile = objBus.GetProfileDetailsByProfileID(ProfileID);

                        txtNotes.Text = hdnDefaultNotes.Value = hdnDefaultNotes.Value.ToString().Replace("#ChildProfileName#", dtSubApps.Rows[0]["Profile_name"].ToString()).Replace("#ParentProfileName#", dtParentProfile.Rows[0]["Profile_name"].ToString());
                    }
                }
                else
                {
                    lblErrorMessage.Text = "No results found";
                    txtEmailID.Text = "";
                    txtUserID.Text = "";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendSubAppInvitation.aspx.cs", "btnSearch_Click", ex.Message,
                   Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void ClearValues()
        {
            lblEmailID.Text = "";
            lblProfileName.Text = "";
            lblUserID.Text = ""; 
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            try
            {
                #region Save Invitation Process in DB

                string vertical = DomainName;
                if (DomainName.EndsWith("com"))
                {
                    vertical = DomainName.Substring(0, DomainName.Length - 3);
                }

                dtSubApps = objBus.GetSearchSubAppsByUserID_EmailID(Convert.ToInt32(txtUserID.Text.Trim()), txtEmailID.Text.Trim(), vertical);
                objBus.InsertSubAppInvitationRequest(ProfileID, Convert.ToInt32(dtSubApps.Rows[0]["Profile_ID"]), txtNotes.Text.Trim(), Convert.ToInt32(dtSubApps.Rows[0]["User_ID"]));



                #endregion


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
                string secureRootPath = objCommon.GetConfigSettings(Session["ProfileID"].ToString(), "Paths", "RootPath");

                string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "SubAppInvitationEmail.txt");
                string msgbody = string.Empty;
                string content = string.Empty;
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    msgbody = msgbody + input;
                }
                re.Close();
                re.Dispose();

                DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(ProfileID);

                #region Logo Binding
                string logourl = string.Empty;

                if (dtProfileDetails.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                    logourl = dtProfileDetails.Rows[0]["Profile_logo_path"].ToString();
                if (logourl.Length > 0)
                {
                    string originalfilename = logourl;
                    string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

                    string junk = ".";
                    string[] ret = originalfilename.Split(junk.ToCharArray());
                    string thumbimg1 = ret[0];
                    thumbimg1 = thumbimg1 + "_thumb" + extension;
                    string url = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\" + thumbimg1;
                    FileInfo obj = new FileInfo(url);


                    if (obj.Exists)
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        logourl = secureRootPath + "/Upload/Logos/" + ProfileID + "/" + thumbimg1 + "?Guid=" + imageDisID;

                    }
                    else
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        logourl = secureRootPath + "/Upload/Logos/" + ProfileID + "/" + logourl + "?Guid=" + imageDisID;

                    }
                }

                #endregion

                msgbody = msgbody.Replace("#ProfileLogo#", "<IMG SRC='" + logourl + "' border='0' />");
                msgbody = msgbody.Replace("#AppName#", dtProfileDetails.Rows[0]["Profile_name"].ToString());
                msgbody = msgbody.Replace("#Time#", DateTime.Now.ToString("MM/dd/yyyy HH:mm tt"));
                msgbody = msgbody.Replace("#Notes#", txtNotes.Text.Trim());
                msgbody = msgbody.Replace("#AgencyOwnerEmailID#", dtProfileDetails.Rows[0]["Username"].ToString());
                msgbody = msgbody.Replace("#LoginLink#", "<a href='" + secureRootPath + "/OP/" + DomainName + "/login.aspx" + "' target=_new>" + secureRootPath + "/OP/" + DomainName + "/login.aspx</a>");


                USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
                utlobj.SendWowzzyEmail(emailInfo, txtEmailID.Text.Trim(), "Sub-App Invitation from " + dtProfileDetails.Rows[0]["Profile_name"].ToString(), msgbody, "", "", DomainName);

                lblMessage.Text = LabelMessages.SubAppInvitationRequest.ToString();
                ClearValues();
                txtEmailID.Text = "";
                txtUserID.Text = "";
                txtNotes.Text = "";
                pnlInvitation.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "btnSend_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnManageSubApps_OnClick(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSubAppsInvitations.aspx");
            Response.Redirect(urlinfo);
        }

    }
}