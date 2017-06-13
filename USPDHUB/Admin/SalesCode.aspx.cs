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
    public partial class SalesCode : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        AdminBLL objAdmin = new AdminBLL();
        CommonBLL objCommon = new CommonBLL();

        public string fstext = "";
        int ConfigID;
        public string RootPath = "";
        public string SC = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RootPath = Session["RootPath"].ToString();
                if (Request.QueryString["ConfigID"] != null)
                {
                    ConfigID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ConfigID"]));
                    SC = EncryptDecrypt.DESDecrypt(Request.QueryString["SC"]);
                }

                //Sign Links from Web Config
                hlinkuspd.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL")) + SC;
                hlinkuspd.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL")) + SC;
                hlinkTwoive.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL")) + SC;
                hlinkTwoive.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL")) + SC;
                hlinkInSchool.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL")) + SC;
                hlinkInSchool.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL")) + SC;
                hlinkMyYouth.Text = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL")) + SC;
                hlinkMyYouth.NavigateUrl = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL")) + SC;

                if (!IsPostBack)
                {
                    BindResellerDetails();
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SalesCode.aspx.cs", "Page_Load", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "SalesCode.aspx.cs", "BindResellerDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                string url = RootPath + "/PrintManageSalesCode.aspx?ConfigID=" + EncryptDecrypt.DESEncrypt(ConfigID.ToString()) + "&SC=" + EncryptDecrypt.DESEncrypt(SC);
                ScriptManager.RegisterClientScriptBlock(this.btnPrint, this.GetType(), "Print", "window.open('" + url + "');", true);
                BindResellerDetails();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SalesCode.aspx.cs", "btnPrint_OnClick", ex.Message,
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
                    fstext = fstext.Replace("##lblAgreementSDate##", Convert.ToDateTime(dt.Rows[0]["AgreementDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##lblAgreementEDate##", Convert.ToDateTime(dt.Rows[0]["AgreementExpiryDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##lblSalesCode##", dt.Rows[0]["SalesCode"].ToString());
                    #region Channel Partner Details
                    fstext = fstext.Replace("##lblCPName##", dt.Rows[0]["ChannelPartnerName"].ToString());
                    fstext = fstext.Replace("##lblCPAddress##", dt.Rows[0]["ChannelPartnerAddress"].ToString());
                    fstext = fstext.Replace("##lblCPEmail##", dt.Rows[0]["ChannelPartnerEmail"].ToString());
                    fstext = fstext.Replace("##lblCPPhone##", dt.Rows[0]["ChannelPartnerPhone"].ToString());
                    fstext = fstext.Replace("##lblCPCP##", dt.Rows[0]["ChannelPartnerCommission"].ToString());
                    if (string.IsNullOrEmpty(dt.Rows[0]["ChannelPartnerName"].ToString()))
                    {
                        fstext = fstext.Replace("<tr id=\"trCP\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCP\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trCPName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCPName\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trCPDetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCPDetails\" runat=\"server\" style=\"display: none;\">");

                    }
                    else
                    {
                        fstext = fstext.Replace("<tr id=\"trCP\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCP\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trCPName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCPName\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trCPDetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCPDetails\" runat=\"server\">");

                    }
                    #endregion
                    #region LT Manager Details
                    fstext = fstext.Replace("##lblLTName##", dt.Rows[0]["LTManagerName"].ToString());
                    fstext = fstext.Replace("##lblLTAddress##", dt.Rows[0]["LTManagerAddress"].ToString());
                    fstext = fstext.Replace("##lblLTEmail##", dt.Rows[0]["LTManagerEmail"].ToString());
                    fstext = fstext.Replace("##lblLTPhone##", dt.Rows[0]["LTManagerPhone"].ToString());
                    fstext = fstext.Replace("##lblLTCP##", dt.Rows[0]["LTManagerCommission"].ToString());
                    if (string.IsNullOrEmpty(dt.Rows[0]["LTManagerName"].ToString()))
                    {
                        fstext = fstext.Replace("<tr id=\"trLTManager\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trLTManager\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trLTManagerName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trLTManagerName\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trLTDetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trLTDetails\" runat=\"server\" style=\"display: none;\">");

                    }
                    else
                    {
                        fstext = fstext.Replace("<tr id=\"trLTManager\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trLTManager\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trLTManagerName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trLTManagerName\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trLTDetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trLTDetails\" runat=\"server\">");

                    }
                    #endregion
                    #region Channel Manager Details
                    fstext = fstext.Replace("##lblCMName##", dt.Rows[0]["ChannelManagerName"].ToString());
                    fstext = fstext.Replace("##lblCMAddress##", dt.Rows[0]["ChannelManagerAddress"].ToString());
                    fstext = fstext.Replace("##lblCMEmail##", dt.Rows[0]["ChannelManagerEmail"].ToString());
                    fstext = fstext.Replace("##lblCMPhone##", dt.Rows[0]["ChannelManagerPhone"].ToString());
                    fstext = fstext.Replace("##lblCMCP##", dt.Rows[0]["ChannelManagerCommission"].ToString());
                    if (string.IsNullOrEmpty(dt.Rows[0]["ChannelManagerName"].ToString()))
                    {
                        fstext = fstext.Replace("<tr id=\"trCM\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCM\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trCMName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCMName\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trCMDetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCMDetails\" runat=\"server\" style=\"display: none;\">");

                    }
                    else
                    {
                        fstext = fstext.Replace("<tr id=\"trCM\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCM\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trCMName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCMName\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trCMDetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCMDetails\" runat=\"server\">");

                    }
                    #endregion
                    #region Channel Affiliate Details
                    fstext = fstext.Replace("##lblRName##", dt.Rows[0]["ChannelAffiliateName"].ToString());
                    fstext = fstext.Replace("##lblCAAddress##", dt.Rows[0]["ChannelAffiliateAddress"].ToString());
                    fstext = fstext.Replace("##lblCAEmail##", dt.Rows[0]["ChannelAffiliateEmail"].ToString());
                    fstext = fstext.Replace("##lblCAPhone##", dt.Rows[0]["ChannelAffiliatePhone"].ToString());
                    fstext = fstext.Replace("##lblCACP##", dt.Rows[0]["ChannelAffiliateCommission"].ToString());
                    if (string.IsNullOrEmpty(dt.Rows[0]["ChannelAffiliateName"].ToString()))
                    {
                        fstext = fstext.Replace("<tr id=\"trCA\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCA\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trCAName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCAName\" runat=\"server\" style=\"display: none;\">");
                        fstext = fstext.Replace("<tr id=\"trCADetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCADetails\" runat=\"server\" style=\"display: none;\">");

                    }
                    else
                    {
                        fstext = fstext.Replace("<tr id=\"trCA\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCA\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trCAName\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCAName\" runat=\"server\">");
                        fstext = fstext.Replace("<tr id=\"trCADetails\" runat=\"server\" style=\"display: block;\">", "<tr id=\"trCADetails\" runat=\"server\">");

                    }

                    #endregion

                    fstext = fstext.Replace("##lblNotes##", dt.Rows[0]["Notes"].ToString());
                    fstext = fstext.Replace("##lblCreated##", dt.Rows[0]["CreatedByName"].ToString());
                    fstext = fstext.Replace("##lblCreatedDate##", Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##lblApproved##", dt.Rows[0]["ApprovedBy"].ToString());
                    fstext = fstext.Replace("##lblApprovedDate##", Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToShortDateString());
                    fstext = fstext.Replace("##hlinkuspd##", Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubResellerURL")) + SC);
                    fstext = fstext.Replace("##hlinkTwoive##", Convert.ToString(ConfigurationManager.AppSettings.Get("TwoVieResellerURL")) + SC);
                    fstext = fstext.Replace("##hlinkInSchool##", Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubResellerURL")) + SC);
                    fstext = fstext.Replace("##hlinkMyYouth##", Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthhubResellerURL")) + SC);
                }
                string pdfilenameval = "SalesCode - " + objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["SalesCode"]));
                string savelocation = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + pdfilenameval + ".pdf";
                objCommon.HtmlToPDF_Print(fstext.ToString(), pdfilenameval, savelocation, true);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SalesCode.aspx.cs", "btnDownload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/ManageSalesCode.aspx");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SalesCode.aspx.cs", "btnBack_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}