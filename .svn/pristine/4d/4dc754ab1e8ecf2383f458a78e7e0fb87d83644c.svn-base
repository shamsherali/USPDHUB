using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Data;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class Contactus : System.Web.UI.Page
    {
        UtilitiesBLL utlobj = new UtilitiesBLL();
        AdminBLL objAdmin = new AdminBLL();
        public string DomainName = "";
        public string RootPath = "";
        public string HelpDesk = ConfigurationManager.AppSettings["helpdesk"];
        public string SalesDesk = ConfigurationManager.AppSettings["salesdesk"];
        public string InfoDesk = ConfigurationManager.AppSettings["Emailinfo1"];
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            try
            { }
            catch (Exception /*ex*/)
            {
                lblShowError.Text = "The verification code has expired. Please try again.";
                txtcaptcha.Text = "";
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
                            StreamReader re = File.OpenText(strfilepath + "WebContactUs.txt");
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
                            reDeclaimer.Close();
                            reDeclaimer.Dispose();
                            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                            if (dtConfigsemails.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtConfigsemails.Rows)
                                {
                                    if (row[0].ToString() == "EmailInfo")
                                        InfoDesk = row[1].ToString();
                                    if (row[0].ToString() == "EmailSupport")
                                        HelpDesk = row[1].ToString();
                                    if (row[0].ToString() == "SalesDesk")
                                        SalesDesk = row[1].ToString();
                                }
                            }
                            string ccemail = string.Empty;
                            string returnval = string.Empty;
                            string toEmailID = "";
                            string seletedType = ddlType.SelectedValue.ToString();
                            if (seletedType == "1")
                                toEmailID = HelpDesk;
                            else if (seletedType == "2" || seletedType == "3")
                                toEmailID = SalesDesk;
                            else
                                toEmailID = InfoDesk;


                            returnval = utlobj.SendWowzzyEmail(InfoDesk, toEmailID, "Contact Us Details", msgbody, ccemail, "", DomainName);
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
                        lblShowError.Text = "Enter correct verification Code";
                        txtcaptcha.Text = "";
                    }
                    Random ran = new Random();
                    img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
                }
            }
            catch (Exception /*ex*/)
            {
                lblShowError.Text = "The verification code has expired. Please try again.";
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