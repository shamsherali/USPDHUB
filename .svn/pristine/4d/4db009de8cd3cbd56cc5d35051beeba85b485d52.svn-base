using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;

namespace USPDHUB
{
    public partial class PrintManageSalesCode : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        AdminBLL objAdmin = new AdminBLL();
        int ConfigID;
        public string SalesCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (Request.QueryString["ConfigID"] != null)
                {
                    ConfigID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ConfigID"]));
                    SalesCode = EncryptDecrypt.DESDecrypt(Request.QueryString["SC"]);
                }

                //Sign Links from Web Config
                hlinkuspd.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL")) + SalesCode;
                hlinkuspd.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL")) + SalesCode;
                hlinkTwoive.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL")) + SalesCode;
                hlinkTwoive.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL")) + SalesCode;
                hlinkInSchool.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL")) + SalesCode;
                hlinkInSchool.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL")) + SalesCode;
                hlinkMyYouth.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL")) + SalesCode;
                hlinkMyYouth.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL")) + SalesCode;

                if (!IsPostBack)
                {
                    BindResellerDetails();
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PrintManageSalesCode.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindResellerDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objAdmin.GetResellerDetailsByConfigID(ConfigID);
                if (dt.Rows.Count > 0)
                {
                    lblAgreementSDate.Text = Convert.ToDateTime(dt.Rows[0]["AgreementDate"].ToString()).ToShortDateString();
                    lblAgreementEDate.Text = Convert.ToDateTime(dt.Rows[0]["AgreementExpiryDate"].ToString()).ToShortDateString();
                    lblSalesCode.Text = dt.Rows[0]["SalesCode"].ToString();
                    #region Channel Partner Details
                    lblCPName.Text = dt.Rows[0]["ChannelPartnerName"].ToString();
                    lblCPAddress.Text = dt.Rows[0]["ChannelPartnerAddress"].ToString();
                    lblCPEmail.Text = dt.Rows[0]["ChannelPartnerEmail"].ToString();
                    lblCPPhone.Text = dt.Rows[0]["ChannelPartnerPhone"].ToString();
                    lblCPCP.Text = dt.Rows[0]["ChannelPartnerCommission"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["ChannelPartnerName"].ToString()))
                    {
                        trCP.Style.Add("display", "none");
                        trCPName.Style.Add("display", "none");
                        trCPDetails.Style.Add("display", "none");
                    }
                    #endregion
                    #region LT Manager Details
                    lblLTName.Text = dt.Rows[0]["LTManagerName"].ToString();
                    lblLTAddress.Text = dt.Rows[0]["LTManagerAddress"].ToString();
                    lblLTEmail.Text = dt.Rows[0]["LTManagerEmail"].ToString();
                    lblLTPhone.Text = dt.Rows[0]["LTManagerPhone"].ToString();
                    lblLTCP.Text = dt.Rows[0]["LTManagerCommission"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["LTManagerName"].ToString()))
                    {
                        trLTManager.Style.Add("display", "none");
                        trLTManagerName.Style.Add("display", "none");
                        trLTDetails.Style.Add("display", "none");
                    }
                    #endregion
                    #region Channel Manager Details
                    lblCMName.Text = dt.Rows[0]["ChannelManagerName"].ToString();
                    lblCMAddress.Text = dt.Rows[0]["ChannelManagerAddress"].ToString();
                    lblCMEmail.Text = dt.Rows[0]["ChannelManagerEmail"].ToString();
                    lblCMPhone.Text = dt.Rows[0]["ChannelManagerPhone"].ToString();
                    lblCMCP.Text = dt.Rows[0]["ChannelManagerCommission"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["ChannelManagerName"].ToString()))
                    {
                        trCM.Style.Add("display", "none");
                        trCMName.Style.Add("display", "none");
                        trCMDetails.Style.Add("display", "none");
                    }
                    #endregion
                    #region Channel Affiliate Details
                    lblRName.Text = dt.Rows[0]["ChannelAffiliateName"].ToString();
                    lblCAAddress.Text = dt.Rows[0]["ChannelAffiliateAddress"].ToString();
                    lblCAEmail.Text = dt.Rows[0]["ChannelAffiliateEmail"].ToString();
                    lblCAPhone.Text = dt.Rows[0]["ChannelAffiliatePhone"].ToString();
                    lblCACP.Text = dt.Rows[0]["ChannelAffiliateCommission"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["ChannelAffiliateName"].ToString()))
                    {
                        trCA.Style.Add("display", "none");
                        trCAName.Style.Add("display", "none");
                        trCADetails.Style.Add("display", "none");
                    }
                    #endregion
                    lblNotes.Text = dt.Rows[0]["Notes"].ToString();
                    lblCreated.Text = dt.Rows[0]["CreatedByName"].ToString();
                    lblCreatedDate.Text = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString();
                    lblApproved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                    lblApprovedDate.Text = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PrintManageSalesCode.aspx.cs", "BindResellerDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}