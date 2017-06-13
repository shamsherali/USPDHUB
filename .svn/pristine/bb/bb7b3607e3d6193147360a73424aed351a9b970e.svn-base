using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using USPDHUBBLL;
using System.IO;

namespace USPDHUB
{
    public partial class Contactus : System.Web.UI.Page
    {
        UtilitiesBLL utlobj = new UtilitiesBLL();
        USPDHUBBLL.AdminBLL objAdmin = new USPDHUBBLL.AdminBLL();
        public string helpdesk = ConfigurationManager.AppSettings["helpdesk"];
        public string salesdesk = ConfigurationManager.AppSettings["salesdesk"];
        public string infodesk = ConfigurationManager.AppSettings["Emailinfo1"];
        public string RootPath = "";
        public string DomainName = "";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["VerticalDomain"] == null || Session["RootPath"]== null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    DomainName = objCommon.CreateDomainUrl(url);
                }
                DomainName = Convert.ToString(Session["VerticalDomain"]);
                RootPath = Session["RootPath"].ToString();
                Response.Redirect(RootPath + "/OP/" + DomainName + "/Contactus.aspx");
                try
                { }
                catch (Exception /*ex*/)
                {
                    lblShowError.Text = "Security code has been expired. Please fill the security code again.";
                    txtcaptcha.Text = "";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "Contactus.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtName.Text.Trim();
                string Email = txtEmail.Text.Trim();
                string Phone = txtPhone.Text.Trim();
                string Type = ddlType.SelectedItem.Text.ToString();
                string Subject = txtSubject.Text.Trim();
                string Comments = txtComments.Text.Trim();
                string VerificationCode = txtcaptcha.Text.Trim();
                if (Page.IsValid)
                {
                    if (captcha.CheckCaptcha(txtcaptcha.Text.Trim()))
                    {
                        //DB Insert&Sending mail to                         
                        int result = objAdmin.InsertContactUsDetails(Name, Email, Phone, Type, Subject, Comments);
                        if (result > 0)
                        {
                            string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                            StreamReader re = File.OpenText(strfilepath + "USPDHubInquiry.txt");
                            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                            string msgbody = string.Empty;
                            string content = string.Empty;
                            string desclaimer = string.Empty;
                            while ((desclaimer = reDeclaimer.ReadLine()) != null)
                            {
                                msgbody = msgbody + desclaimer + "\n";
                            }
                            string input = string.Empty;
                            while ((input = re.ReadLine()) != null)
                            {
                                content = content + input + "<BR>";
                            }

                            msgbody = msgbody.Replace("#RootUrl#", RootPath);
                            msgbody = msgbody.Replace("#msgBody#", content);

                            msgbody = msgbody.Replace("#Name#", Name);
                            msgbody = msgbody.Replace("#Email#", Email);
                            msgbody = msgbody.Replace("#Phone#", Phone);
                            msgbody = msgbody.Replace("#Subject#", Subject);
                            msgbody = msgbody.Replace("#Comments#", Comments);
                            msgbody = msgbody.Replace("#Type#", Type);
                            re.Close();
                            re.Dispose();
                            string ccemail = string.Empty;
                            string returnval = string.Empty;
                            string toEmailID = "";
                            string seletedType = ddlType.SelectedValue.ToString();
                            if (seletedType == "1")
                                toEmailID = helpdesk;
                            else if (seletedType == "2" || seletedType == "3")
                                toEmailID = salesdesk;
                            else
                                toEmailID = infodesk;

                            reDeclaimer.Close();
                            reDeclaimer.Dispose();
                            returnval = utlobj.SendWowzzyEmail(ConfigurationManager.AppSettings.Get("Emailinfo"), toEmailID, "Contact Us Details", msgbody, ccemail, "", DomainName);
                            if (returnval == "SUCCESS")
                            {
                                lblShowError.ForeColor = System.Drawing.Color.Green;
                                lblShowError.Text = "Thank you for contacting us.";
                                txtcaptcha.Text = txtName.Text = txtEmail.Text = txtPhone.Text = txtSubject.Text = txtComments.Text = "";
                                ddlType.SelectedIndex = 0;
                            }
                            else
                                lblShowError.Text = returnval;
                        }
                    }
                    else
                    {
                        lblShowError.Text = "Enter Correct Security Code";
                        txtcaptcha.Text = "";
                    }
                    Random ran = new Random();
                    img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
                }
            }
            catch (Exception /*ex*/)
            {
                lblShowError.Text = "Security code has been expired. Please fill the security code again.";
                txtcaptcha.Text = "";
            }
            finally
            {
                Random ran = new Random();
                img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
            }
        }
    }
}