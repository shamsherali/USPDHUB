using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using USPDHUBDAL;
using System.Configuration;

namespace USPDHUB
{
    public partial class PrivateModuleInvitationResponse : System.Web.UI.Page
    {
        public USPDHUBBLL.PrivateModuleBLL objPrivateModuleBLL = new USPDHUBBLL.PrivateModuleBLL();
        BusinessBLL objBusinessBLL = new BusinessBLL();
        CommonBLL objCommonBLL = new CommonBLL();

        public string IOS_Url = "";
        public string Andriod_Url = "";
        public string Windows_Url = "";
        public string StoreUrl = "";
        public string AppName = "";
        public string TabName = "";
        public string ProfileName = "";
        public string AppDisplayName = "";

        public int UMID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["InvitationID"] != null)
                    {

                        int invitationid = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["invitationid"].ToString()));
                        string status = EncryptDecrypt.DESDecrypt(Request.QueryString["Status"].ToString());

                        string mobileNumber = "";
                        if (Request.QueryString["MobileNumber"] != null)
                        {
                            mobileNumber = EncryptDecrypt.DESDecrypt(Request.QueryString["MobileNumber"].ToString());
                        }

                        DataTable dtButtonDetails = objBusinessBLL.GetButtonDetails(invitationid, "");
                        string buttonType = "";
                        if (dtButtonDetails.Rows.Count > 0)
                        {
                            buttonType = Convert.ToString(dtButtonDetails.Rows[0]["ButtonType"]) + "Tab";
                            TabName = Convert.ToString(dtButtonDetails.Rows[0]["TabName"]);
                            UMID = Convert.ToInt32(dtButtonDetails.Rows[0]["UserModuleID"]);
                        }


                        int PID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["PID"].ToString()));
                        AppDisplayName = AppName = Request.QueryString["AppName"].ToString();
                        DataTable dtProfile = objBusinessBLL.GetProfileDetailsByProfileID(PID);
                        ProfileName = Convert.ToString(dtProfile.Rows[0]["profile_name"]);
                        DataTable dtAppStoresLinks = objBusinessBLL.GetAppStoresLinks(PID);
                        bool isAppUrlExists = false;
                        //Response.Redirect(appname + "://?InvitationID=" + invitationid + "&Status=" + status + "");
                        if (dtAppStoresLinks.Rows.Count > 0)
                        {
                            StoreUrl = Convert.ToString(dtAppStoresLinks.Rows[0]["Store_Url"]).Trim();
                            if (StoreUrl != "")
                                isAppUrlExists = true;
                        }
                        if (!isAppUrlExists)
                        {
                            string verticalDomain = objCommonBLL.GetDomainNameByCountry(Convert.ToInt32(dtProfile.Rows[0]["User_ID"]));
                            if (verticalDomain.ToLower().Contains("uspdhub"))
                            {
                                AppDisplayName = AppName = "USPDhub";
                                StoreUrl = ConfigurationManager.AppSettings["USPDhubAppurl"];
                            }
                            else if (verticalDomain.ToLower().Contains("inschoolhub"))
                            {
                                AppDisplayName = AppName = "inSchoolHub";
                                StoreUrl = ConfigurationManager.AppSettings["InSchoolHubAppurl"];
                            }
                            else if (verticalDomain.ToLower().Contains("twovie"))
                            {
                                AppDisplayName = AppName = "TwoVieHub";
                                StoreUrl = ConfigurationManager.AppSettings["TwoVieAppurl"];
                            }
                            else if (verticalDomain.ToLower().Contains("myyouthhub"))
                            {
                                AppDisplayName = AppName = "MyYouthHub";
                                StoreUrl = ConfigurationManager.AppSettings["MyYouthHubAppurl"];
                            }
                            else if (verticalDomain.ToLower().Contains("inschoolalert"))
                            {
                                AppName = "inSchoolAlertLite";
                                AppDisplayName = "inSchoolALERT";
                                StoreUrl = ConfigurationManager.AppSettings["inSchoolAlertLiteAppurl"];
                            }
                        }
                        hdnAppUrl.Value = AppName + "://?InvitationID=" + invitationid + "&Status=" + status + "&ButtonType=" + buttonType + "&UMID=" + UMID + "&PID=" + PID + "&MobileNumber=" + mobileNumber;

                        if (status.ToLower() == "Accepted".ToLower())
                        {
                            pnlSubmit.Visible = true;
                            pnlCancel.Visible = false;
                        }
                        else
                        {
                            pnlSubmit.Visible = false;
                            pnlCancel.Visible = true;
                        }

                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>PageRedirect();</script>", false);
                    }
                }
                catch (Exception ex)
                {
                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    /*** Error Log ***/
                    objInBuiltData.ErrorHandling("ERROR", "PrivateModuleInvitationResponse.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }

        }

        protected void btnCancelled_OnClick(object sender, EventArgs e)
        {
            try
            {

                string status = EncryptDecrypt.DESDecrypt(Request.QueryString["Status"].ToString());
                int invitationid = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["invitationid"].ToString()));
                int outputID = objPrivateModuleBLL.Insert_Update_Invitation(0, PrivateModule_InvitedStatus.CancelledStatus, string.Empty, string.Empty, "", "",
                    Convert.ToInt32(invitationid), 0, 0, "","");
                if (outputID == -1)
                {
                    lblMessage.Text = Resources.LabelMessages.PrivateInvitationExpiration.ToString();
                }
                else
                {
                    lblMessage.Text = Resources.LabelMessages.PrivateModuleDeclinedTitle.ToString();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "PrivateModuleInvitationResponse.aspx.cs", "btnCancelled_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}