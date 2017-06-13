using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class SMSCompose : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";
        public string invalidIds = string.Empty;

        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        SMSBLL objSMSBLL = new SMSBLL();

        DataTable DtSelectedContactList = new DataTable();




        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                lblmess.Text = "";

                if (!IsPostBack)
                {
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SMSCompose.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkimportcontacts_Click(object sender, EventArgs e)
        {
            try
            {
                txtto.Text = "";
                Session["NoContact"] = null;
                BusinessBLL BusObj = new BusinessBLL();
                DataTable DtContacts = BusObj.GetAllUserContactsbyUserID(UserID, 0, "All");
                if (DtContacts.Rows.Count > 0)
                {
                    pnldiscontact.Visible = true;
                    pnlnocotnact.Visible = false;
                }
                else
                {
                    pnldiscontact.Visible = false;
                    pnlnocotnact.Visible = true;
                }
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SMSCompose.aspx.cs", "lnkimportcontacts_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            DtSelectedContactList.Dispose();
            DtSelectedContactList.Rows.Clear();
            ModalPopupExtender1.Hide();

        }
        protected void btnclick_Click(object sender, EventArgs e)
        {
            try
            {
                txtto.Text = "";
                DtSelectedContactList = (DataTable)(Session["ContactTable"]);
                DataRow[] DrChecked = DtSelectedContactList.Select("checkvalue=0");
                for (int i = 0; i < DrChecked.Length; i++)
                {
                    DtSelectedContactList.Rows.Remove(DrChecked[i]);
                }

                if (DtSelectedContactList.Rows.Count > 0)
                {
                    string ContactList = string.Empty;
                    for (int i = 0; i < DtSelectedContactList.Rows.Count; i++)
                    {
                        if (ContactList != "")
                        {
                            ContactList = ContactList + DtSelectedContactList.Rows[i]["Mobile"].ToString() + "" + ",";
                        }
                        else
                        {
                            ContactList = DtSelectedContactList.Rows[i]["Mobile"].ToString() + "" + ",";
                        }
                    }
                    if (ContactList != "")
                    {
                        ContactList = ContactList.Remove(ContactList.Length - 1);
                        ContactList = ContactList.Replace("-", "");
                        txtto.Text = ContactList;
                    }
                }

                if (txtto.Text != "")
                {


                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SMSCompose.aspx.cs", "btnclick_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btncancelpop_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected int validatePhoneNumbers(string phoneNumber)
        {
            int CountTotalPhoneNumbers1 = 0;
            try
            {
                string[] Totalphonenumbers1;
                string phonenumberss = string.Empty;
                string SplitType1 = ",";
                Totalphonenumbers1 = phoneNumber.Split(SplitType1.ToCharArray());
                //---------Email Scheduling--------------

                //----Check wether No of Phone Numbers are greater than or equal to daylimit or not--


                if (Totalphonenumbers1.Length > 0)
                {
                    for (int i = 0; i < Totalphonenumbers1.Length; i++)
                    {
                        if (Totalphonenumbers1[i].Length > 0)
                        {
                            string SplitVal = "'";
                            string[] Currentvalues;
                            string EA = Totalphonenumbers1[i].ToString();
                            Currentvalues = EA.Split(SplitVal.ToCharArray());
                            if (Currentvalues.Length > 0)
                            {
                                if (Currentvalues.Length != 1)
                                {
                                    if (Currentvalues[1].Length > 0)
                                    {
                                        string ToNumbersAdd = Currentvalues[1].ToString();
                                        CountTotalPhoneNumbers1++;
                                        if (phonenumberss.Length == 0)
                                        {
                                            phonenumberss = ToNumbersAdd;
                                        }
                                        else
                                        {
                                            phonenumberss = phonenumberss + ", " + ToNumbersAdd;
                                        }

                                    }
                                }
                                else
                                {
                                    if (Currentvalues.Length == 1)
                                    {
                                        if (Currentvalues[0].Length > 1)
                                        {

                                            string Emailsent = Currentvalues[0].ToString();
                                            Emailsent = Emailsent.Replace(" ", "");
                                            string strRegex = @"^\d+$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(Emailsent))
                                            {
                                                if (phonenumberss.Length == 0)
                                                {
                                                    phonenumberss = Emailsent;
                                                }
                                                else
                                                {
                                                    phonenumberss = phonenumberss + ", " + Emailsent;
                                                }
                                                CountTotalPhoneNumbers1++;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SMSCompose.aspx.cs", "validatePhoneNumbers", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return CountTotalPhoneNumbers1;
            //---End

        }

        protected void lnkSend_Click(object sender, EventArgs e)
        {
            ValidateSMSConctas();
        }



        protected void btnenhance_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageContacts.aspx"));
        }

        protected void lnkCancelMail_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageSMS.aspx"));
        }

        private void ValidateSMSConctas()
        {
            try
            {
                int SendCount = 0;

                string sent_phoneNumber = "";

                string Address = string.Empty;
                string[] TotalAddress;
                string mailids = string.Empty;
                string SplitType = ",";
                Address = txtto.Text;
                Address = Address.Replace("\n", "");
                Address = Address.Replace("\r", "");
                TotalAddress = Address.Split(SplitType.ToCharArray());

                if (TotalAddress.Length > 0)
                {
                    for (int i = 0; i < TotalAddress.Length; i++)
                    {
                        if (TotalAddress[i].Length > 0)
                        {
                            string SplitVal = "'";
                            string[] Currentvalues;
                            string EA = TotalAddress[i].ToString();
                            Currentvalues = EA.Split(SplitVal.ToCharArray());

                            if (Currentvalues.Length > 0)
                            {
                                if (Currentvalues[0].Length > 1)
                                {
                                    string Phonesent = Currentvalues[0].ToString();
                                    Phonesent = Phonesent.Replace(" ", "");
                                    string strRegex = @"^\d+$";
                                    Regex re = new Regex(strRegex);
                                    if (re.IsMatch(Phonesent) && (Phonesent.Length >= 10 && Phonesent.Length <= 11))
                                    { //
                                        sent_phoneNumber = Phonesent + "," + sent_phoneNumber;
                                        SendCount++;
                                    }
                                    else
                                    {
                                        if (invalidIds.Length == 0)
                                        {
                                            invalidIds = Currentvalues[0].ToString();
                                        }
                                        else
                                        {
                                            invalidIds = invalidIds + ", " + Currentvalues[0].ToString();
                                        }
                                    }

                                }
                            }
                        }
                    }// for each


                    //UPDATE SMS SENT FLAG
                    if (sent_phoneNumber != string.Empty)
                    {
                        if (sent_phoneNumber.StartsWith(","))
                        {
                            sent_phoneNumber = sent_phoneNumber.Remove(1, sent_phoneNumber.Length);
                        }
                        if (sent_phoneNumber.EndsWith(","))
                        {
                            sent_phoneNumber = sent_phoneNumber.Remove(sent_phoneNumber.Length - 1);
                        }

                        string smsUserName = ConfigurationManager.AppSettings.Get("SMSUserName");
                        string smsPassword = ConfigurationManager.AppSettings.Get("SMSPassword");
                        string smsSenderID = ConfigurationManager.AppSettings.Get("SMSSenderID");

                        string result = SendSMS(smsUserName, smsPassword, smsSenderID, sent_phoneNumber, txtmessage.Text.Trim());
                        //if (result != "")
                        //{
                        objSMSBLL.InsertSMSDetails(txtmessage.Text.Trim(), UserID, ProfileID, sent_phoneNumber);
                        Session["smsMessage"] = "SMS sent successfully.";
                        //}
                        //else
                        //{
                        //    lblmess.Text = "<font>Message sending failed.</font>";
                        //    return;
                        //}

                    }

                    // Message
                    if (SendCount == 0 & invalidIds.Length > 0)
                    {
                        Session["CheckMess"] = "1";
                    }
                    else if (SendCount == 0)
                    {
                        Session["CheckMess"] = "5";
                    }
                    else if (SendCount > 0 & invalidIds.Length > 0)
                    {
                        Session["CheckMess"] = "2";
                        Session["invalid"] = invalidIds;
                    }
                    else if (SendCount > 0)
                    {
                        Session["CheckMess"] = "4";
                    }
                    else if (SendCount > 0 & invalidIds.Length == 0)
                    {
                        Session["CheckMess"] = "3";
                    }


                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageSMS.aspx"));

                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmsCompose.aspx.cs", "ButtonClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        private string SendSMS(string username, string password, string fromNumber, string toNumber, string message)
        {
            try
            {
                string FullUri = "http://www.onlinesmslogin.com/quicksms/api.php?username=" + username + "&password=" + password + "&to=" + toNumber + "&from=" + fromNumber + "&message=" + message + "";
                HttpWebRequest Request;
                StreamReader ResponseReader;
                Request = ((HttpWebRequest)(WebRequest.Create(FullUri)));
                ResponseReader = new StreamReader(Request.GetResponse().GetResponseStream());
                return ResponseReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmsCompose.aspx.cs", "SendSMS", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return "";
        }
    }
}