using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using Winnovative.PdfCreator;
using Winnovative.HtmlToPdfClient;
using System.IO;
using System.Text;
using System.Configuration;

namespace USPDHUB.Admin
{
    public partial class PrintSalesCode : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        AdminBLL objAdmin = new AdminBLL();
        CommonBLL objCommon = new CommonBLL();
        
        public string fstext = "";
        int ConfigID;
        public string RootPath = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RootPath = Session["RootPath"].ToString();
                if (Request.QueryString["ConfigID"] != null)
                {
                    ConfigID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ConfigID"]));
                }

                //Sign Links from Web Config
                hlinkuspd.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL"));
                hlinkuspd.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL"));
                hlinkTwoive.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL"));
                hlinkTwoive.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL"));
                hlinkInSchool.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL"));
                hlinkInSchool.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL"));
                hlinkMyYouth.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL"));
                hlinkMyYouth.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL"));

                if (!IsPostBack)
                {
                    BindResellerDetails();
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PrintSalesCode.aspx.cs", "Page_Load", ex.Message,
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
                    //Channel Affiliate Details
                    lblRName.Text = dt.Rows[0]["ChannelAffiliateName"].ToString();
                    lblAgreementSDate.Text = Convert.ToDateTime(dt.Rows[0]["AgreementDate"].ToString()).ToShortDateString();
                    lblAgreementEDate.Text = Convert.ToDateTime(dt.Rows[0]["AgreementExpiryDate"].ToString()).ToShortDateString();
                    lblSalesCode.Text = dt.Rows[0]["SalesCode"].ToString();
                    lblCACP.Text = dt.Rows[0]["ChannelAffiliateCommission"].ToString();
                    lblCAAddress.Text = dt.Rows[0]["ChannelAffiliateAddress"].ToString();
                    lblCACity.Text = dt.Rows[0]["ChannelAffiliateCity"].ToString();
                    lblCAState.Text = dt.Rows[0]["ChannelAffiliateState"].ToString();
                    lblCAZip.Text = dt.Rows[0]["ChannelAffiliateZipCode"].ToString();
                    //LT Manager Details
                    lblLTName.Text = dt.Rows[0]["LTManagerName"].ToString();
                    lblLTCP.Text = dt.Rows[0]["LTManagerCommission"].ToString();
                    //Channel Manager Details
                    lblCMName.Text = dt.Rows[0]["ChannelManagerName"].ToString();
                    lblCMAddress.Text = dt.Rows[0]["ChannelManagerAddress"].ToString();
                    lblCMEmail.Text = dt.Rows[0]["ChannelManagerEmail"].ToString();
                    lblCMPhone.Text = dt.Rows[0]["ChannelManagerPhone"].ToString();
                    lblCMCP.Text = dt.Rows[0]["ChannelManagerCommission"].ToString();
                    //Channel Partner Details
                    lblCPName.Text = dt.Rows[0]["ChannelPartnerName"].ToString();
                    lblCPAddress.Text = dt.Rows[0]["ChannelPartnerAddress"].ToString();
                    lblCPEmail.Text = dt.Rows[0]["ChannelPartnerEmail"].ToString();
                    lblCPPhone.Text = dt.Rows[0]["ChannelPartnerPhone"].ToString();
                    lblCPCP.Text = dt.Rows[0]["ChannelPartnerCommission"].ToString();
                    lblNotes.Text = dt.Rows[0]["Notes"].ToString();
                    lblCreated.Text = dt.Rows[0]["CreatedByName"].ToString();
                    lblCreatedDate.Text = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString();
                    lblApproved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                    lblApprovedDate.Text = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PrintSalesCode.aspx.cs", "BindResellerDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                string url = RootPath + "/PrintManageSalesCode.aspx?ConfigID=" + EncryptDecrypt.DESEncrypt(ConfigID.ToString());
                ScriptManager.RegisterClientScriptBlock(this.btnPrint, this.GetType(), "Print", "window.open('" + url + "');", true);
                BindResellerDetails();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PrintSalesCode.aspx.cs", "btnPrint_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDownload_OnClick(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = File.OpenRead(Server.MapPath("~/BulletinPreview/SalesCode.htm")); 
                byte[] byt = new byte[(int)fs.Length];
                char[] chr = new char[byt.Length];
                fs.Read(byt, 0, (int)fs.Length);
                byt.CopyTo(chr, 0);
                fstext = new string(chr);
                fs.Close();
                fstext = fstext.Replace("ï»¿", "");
                DataTable dt = new DataTable();
                dt = objAdmin.GetResellerDetailsByConfigID(ConfigID);
                
                string imagepath = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    fstext = fstext.Replace("##lblRName##", dt.Rows[0]["ChannelAffiliateName"].ToString());
                    fstext = fstext.Replace("##lblAgreementSDate##", Convert.ToDateTime(dt.Rows[0]["AgreementDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##lblAgreementEDate##", Convert.ToDateTime(dt.Rows[0]["AgreementExpiryDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##lblSalesCode##", dt.Rows[0]["SalesCode"].ToString());
                    fstext = fstext.Replace("##lblCACP##", dt.Rows[0]["ChannelAffiliateCommission"].ToString());
                    fstext = fstext.Replace("##lblCAAddress##", dt.Rows[0]["ChannelAffiliateAddress"].ToString());
                    fstext = fstext.Replace("##lblCACity##", dt.Rows[0]["ChannelAffiliateCity"].ToString());
                    fstext = fstext.Replace("##lblCAState##", dt.Rows[0]["ChannelAffiliateState"].ToString());
                    fstext = fstext.Replace("##lblCAZip##", dt.Rows[0]["ChannelAffiliateZipCode"].ToString());
                    fstext = fstext.Replace("##lblLTName##", dt.Rows[0]["LTManagerName"].ToString());
                    fstext = fstext.Replace("##lblLTCP##", dt.Rows[0]["LTManagerCommission"].ToString());
                    fstext = fstext.Replace("##lblCMName##", dt.Rows[0]["ChannelManagerName"].ToString());
                    fstext = fstext.Replace("##lblCMAddress##", dt.Rows[0]["ChannelManagerAddress"].ToString());
                    fstext = fstext.Replace("##lblCMEmail##", dt.Rows[0]["ChannelManagerEmail"].ToString());
                    fstext = fstext.Replace("##lblCMPhone##", dt.Rows[0]["ChannelManagerPhone"].ToString());
                    fstext = fstext.Replace("##lblCMCP##", dt.Rows[0]["ChannelManagerCommission"].ToString());
                    fstext = fstext.Replace("##lblCPName##", dt.Rows[0]["ChannelPartnerName"].ToString());
                    fstext = fstext.Replace("##lblCPAddress##", dt.Rows[0]["ChannelPartnerAddress"].ToString());
                    fstext = fstext.Replace("##lblCPEmail##", dt.Rows[0]["ChannelPartnerEmail"].ToString());
                    fstext = fstext.Replace("##lblCPPhone##", dt.Rows[0]["ChannelPartnerPhone"].ToString());
                    fstext = fstext.Replace("##lblCPCP##", dt.Rows[0]["ChannelPartnerCommission"].ToString());
                    fstext = fstext.Replace("##lblNotes##", dt.Rows[0]["Notes"].ToString());
                    fstext = fstext.Replace("##lblCreated##", dt.Rows[0]["CreatedByName"].ToString());
                    fstext = fstext.Replace("##lblCreatedDate##", Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##lblApproved##", dt.Rows[0]["ApprovedBy"].ToString());
                    fstext = fstext.Replace("##lblApprovedDate##", Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##hlinkuspd##", Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL")));
                    fstext = fstext.Replace("##hlinkTwoive##", Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL")));
                    fstext = fstext.Replace("##hlinkInSchool##", Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL")));
                    fstext = fstext.Replace("##hlinkMyYouth##", Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL")));
                }
                string pdfilenameval = "SalesCode - "+objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["SalesCode"])) ;
                string savelocation = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + pdfilenameval + ".pdf";
                objCommon.HtmlToPDF_Print(fstext.ToString(), pdfilenameval, savelocation, true);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PrintSalesCode.aspx.cs", "btnDownload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}