using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Text;

namespace USPDHUB
{
    public partial class Register : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();
        public string LogoName = "";
        string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["RootPath"] == null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string domainName = objCommon.CreateDomainUrl(url);
                }
                DomainName = Session["VerticalDomain"].ToString();
                LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";
                if (!IsPostBack)
                {
                    if (Request.QueryString["SchId"] != null)
                    {
                        hdnSchId.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["SchId"].ToString());
                        DataTable dtWebnair = objBus.GetWebnairDetails(Convert.ToInt32(hdnSchId.Value));
                        if (dtWebnair.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dtWebnair.Rows[0]["ExpirationDate"])) && Convert.ToDateTime(dtWebnair.Rows[0]["ExpirationDate"]) < DateTime.Now)
                            {
                                pnlForm.Visible = false;
                                pnlExpired.Visible = true;
                            }
                            else
                            {
                                lblWebnairTitle.Text = Convert.ToString(dtWebnair.Rows[0]["WebnairTitle"]);
                                txtEmail.Text = Convert.ToString(dtWebnair.Rows[0]["Receiver_EmailID"]);
                                lblDescription.Text = Convert.ToString(dtWebnair.Rows[0]["Webnairdescription"]);
                            }
                        }
                        else
                        {
                            pnlForm.Visible = false;
                            pnlExpired.Visible = true;
                        }
                    }
                    else
                        Response.Redirect(Session["RootPath"].ToString());
                }
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Register.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    int schId = Convert.ToInt32(hdnSchId.Value);
                    string emailAddress = txtEmail.Text.Trim();
                    string firstName = txtFN.Text.Trim();
                    string lastname = txtLN.Text.Trim();
                    string phone = txtPhone.Text.Trim();
                    string checkUser = objBus.CheckValidUserForWebnair(emailAddress, schId);
                    if (checkUser == "1")
                    {
                        int attendentId = objBus.InsertWebnairUser(schId, emailAddress, firstName, lastname, phone);
                        if (attendentId > 0)
                        {
                            SendWebnairDetails();
                            lblMessage.Text = "<font color='green'>" + Resources.LabelMessages.WebnairSuccess + "</font>";
                        }
                        else
                            lblMessage.Text = "<font color='red'>" + Resources.LabelMessages.WebnairAlreadyRegistered + "</font>";
                    }
                    else
                        lblMessage.Text = "<font color='red'>" + Resources.LabelMessages.WebnairAlreadyRegistered + "</font>";
                    txtEmail.Text = "";
                    txtFN.Text = "";
                    txtLN.Text = "";
                    txtPhone.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "<font color='red'>" + Resources.LabelMessages.WebnairError + "</font>";

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Register.aspx.cs", "lnkSubmit_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void SendWebnairDetails()
        {
            try
            {
                DataTable dtWebnair = objBus.GetWebnairDetails(Convert.ToInt32(hdnSchId.Value));
                if (dtWebnair.Rows.Count > 0 && Convert.ToBoolean(dtWebnair.Rows[0]["IsSendRegistrationEmail"]))
                {
                    string FromInfo = "";
                    DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                    if (dtConfigsemails.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails.Rows)
                        {
                            if (row[0].ToString() == "EmailInfo")
                                FromInfo = row[1].ToString();
                        }
                    }
                    string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                    StreamReader re = File.OpenText(strfilepath + "WebnairRegistration.txt");
                    StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                    StringBuilder msgbody = new StringBuilder();
                    StringBuilder content = new StringBuilder();
                    string desclaimer = string.Empty;
                    while ((desclaimer = reDeclaimer.ReadLine()) != null)
                    {
                        msgbody.Append(desclaimer);
                    }
                    string input = string.Empty;
                    while ((input = re.ReadLine()) != null)
                    {
                        content.Append(input);
                    }

                    string webnairTitle = "";
                    string webnairDate = "";
                    string webnairTime = "";
                    string webanairLocation = "";
                    string additionalDesc = "";
                    string regSubject = "Registration Successfull";
                    webnairTitle = Convert.ToString(dtWebnair.Rows[0]["WebnairTitle"]);
                    webanairLocation = Convert.ToString(dtWebnair.Rows[0]["Location"]);
                    additionalDesc = Convert.ToString(dtWebnair.Rows[0]["AdditionalDescription"]);
                    string additionalDescTop = Convert.ToString(dtWebnair.Rows[0]["AdditionalDescriptionTop"]);
                    string timeZone = Convert.ToString(dtWebnair.Rows[0]["TimeZone"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(dtWebnair.Rows[0]["RegisterSubject"])))
                    {
                        regSubject = Convert.ToString(dtWebnair.Rows[0]["RegisterSubject"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(dtWebnair.Rows[0]["WebnairDate"])))
                    {
                        webnairDate = String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dtWebnair.Rows[0]["WebnairDate"]));
                        webnairTime = String.Format("{0:t}", Convert.ToDateTime(dtWebnair.Rows[0]["WebnairDate"]));
                    }
                    string registerPhone = "";
                    if (txtPhone.Text.Trim() != "")
                        registerPhone = "<tr><td>Phone Number:</td><td>" + txtPhone.Text.Trim() + "</td></tr>";
                    string rootPath = Session["RootPath"].ToString();
                    msgbody.Replace("#msgBody#", content.ToString());
                    msgbody.Replace("#RootUrl#", rootPath);
                    msgbody.Replace("##WebnairTitle##", webnairTitle);
                    msgbody.Replace("##WebnairDate##", webnairDate);
                    msgbody.Replace("##WebnairTime##", webnairTime);
                    msgbody.Replace("##WebnairLocation##", webanairLocation);
                    msgbody.Replace("##AdditionalDesc##", additionalDesc);
                    msgbody.Replace("##AdditionalDescTop##", additionalDescTop);
                    msgbody.Replace("##TimeZone##", timeZone);
                    msgbody.Replace("##RegisterName##", txtFN.Text.Trim() + " " + txtLN.Text.Trim());
                    msgbody.Replace("##RegisterEmail##", txtEmail.Text.Trim());
                    msgbody.Replace("##RegisterPhone##", registerPhone);
                    re.Close();
                    re.Dispose();
                    reDeclaimer.Close();
                    reDeclaimer.Dispose();
                    UtilitiesBLL utlobj = new UtilitiesBLL();
                    utlobj.SendWowzzyEmail(FromInfo, txtEmail.Text.Trim(), regSubject, msgbody.ToString(), "", "", DomainName);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "<font color='red'>" + Resources.LabelMessages.WebnairError + "</font>";

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Register.aspx.cs", "SendWebnairDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["RootPath"].ToString());
        }
        [WebMethod]
        public static string ServerSidefill(string emid, string schId)
        {


            BusinessBLL objBus = new BusinessBLL();
            string validuser = "";
            try
            {
                if (emid.Length > 0)
                {
                    Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    if (!rEMail.IsMatch(emid))
                    {
                        validuser = "Invalid";
                    }
                    else
                    {
                        try
                        {
                            validuser = objBus.CheckValidUserForWebnair(emid, Convert.ToInt32(schId));
                        }
                        catch (Exception ex)
                        {
                            validuser = ex.Message;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Register.aspx.cs", "ServerSidefill", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return validuser;
        }
    }
}