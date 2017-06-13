using System;
using System.Linq;
using System.Data;
using System.Configuration;
using System.IO;
using USPDHUBBLL;
using System.Data.SqlClient;

namespace USPDHUB.Business.MyAccount
{
    public partial class ApproveAndRejectForms : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public string Urlinfo = string.Empty;
        public int CUserID = 0;
        SqlConnection sqlCon;
        SqlCommand sqlCmd = new SqlCommand();
        string ss = string.Empty;
        string pUsername = string.Empty;
        string cUsername = string.Empty;
        public int Val = 0;
        DataTable dt = new DataTable();
        BusinessUpdatesBLL adminobjs = new BusinessUpdatesBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        EventCalendarBLL eventobj = new EventCalendarBLL();
        string remarks = string.Empty;
        CommonBLL objCommon = new CommonBLL();
        string DomainName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null || Session["ProfileID"] == null)
                {
                    Urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(Urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                    pUsername = Session["username"].ToString();
                }

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    cUsername = Session["C_USER_NAME"].ToString();
                }
                else
                    CUserID = UserID;
                DomainName = Convert.ToString(Session["VerticalDomain"]);
                if (!IsPostBack)
                {
                    if (Session["BulletinID"] != null && Session["BulletinID"].ToString() != "")
                    {
                        if (Session["Type"] != null && Session["Type"].ToString() != "")
                        {
                            if (Session["PageName"] != null && Session["PageName"].ToString() != "")
                            {
                                if (Session["PageName"].ToString() == "A") //A for Approve..
                                {
                                    Label1.Visible = BtnReject.Visible = TxtRemarks.Visible = false;
                                    if (Session["Type"].ToString() == PageNames.BULLETIN)
                                    {
                                        ss = "Update T_Manage_Bulletins set IsPublished='true',Published_By='" + CUserID + "',Modified_Date='" + System.DateTime.Now + "',Modified_User=" + CUserID + " where Bulletin_ID=" + Convert.ToInt32(Session["BulletinID"].ToString()) + "";
                                        Val = InsertDetails(ss);
                                        if (Val > 0)
                                            lblstatusmessage.Text = "<font face=arial size=2>Published bulletin has been approved successfully.</font>";
                                    }
                                    else if (Session["Type"].ToString() == PageNames.UPDATE)
                                    {
                                        ss = "Update T_BusinessUpdates set IsPublished='true',Published_By='" + CUserID + "',MODIFIED_USER=" + CUserID + ",MODIFIED_DATE='" + System.DateTime.Now + "' where UpdateId=" + Convert.ToInt32(Session["BulletinID"].ToString()) + "";
                                        Val = InsertDetails(ss);
                                        if (Val > 0)
                                            lblstatusmessage.Text = "<font face=arial size=2>Published update has been approved successfully.</font>";
                                    }
                                    else if (Session["Type"].ToString() == PageNames.EVENT)
                                    {
                                        ss = "Update T_EventsCalendar set IsPublished='true',Published_By='" + CUserID + "',ModifyDate='" + System.DateTime.Now + "',ModifiedUser=" + CUserID + " where EventId=" + Convert.ToInt32(Session["BulletinID"].ToString()) + "";
                                        Val = InsertDetails(ss);
                                        if (Val > 0)
                                            lblstatusmessage.Text = "<font face=arial size=2>Published event has been approved successfully.</font>";
                                    }
                                    RemoveSession();
                                }
                            }
                        }
                    }
                }

                TxtRemarks.Focus();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ApproveAndRejectForms.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["BulletinID"] != null && Session["BulletinID"].ToString() != "")
                {
                    if (Session["Type"] != null && Session["Type"].ToString() != "")
                    {
                        if (Session["PageName"] != null && Session["PageName"].ToString() != "")
                        {

                            if (Session["Type"].ToString() == PageNames.BULLETIN)
                            {
                                dt = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(Session["BulletinID"].ToString()));
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["Remarks"].ToString() == "")
                                        remarks = CUserID + " -- " + TxtRemarks.Text;
                                    else
                                        remarks = CUserID + " -- " + TxtRemarks.Text + " | " + dt.Rows[0]["Remarks"].ToString();
                                    ss = "Update T_Manage_Bulletins set Remarks='" + remarks + "', Rejected_By='" + CUserID + "', IsPublished='false',Modified_Date='" + System.DateTime.Now + "',Modified_User=" + CUserID + ",Publish_Date=null,,IsPrivate='true',Published_By=null where Bulletin_ID=" + Convert.ToInt32(Session["BulletinID"].ToString()) + "";
                                    Val = InsertDetails(ss);
                                }
                                if (Val > 0)
                                    lblstatusmessage.Text = "<font face=arial size=2>Published bulletin has been rejected successfully.</font>";
                            }
                            else if (Session["Type"].ToString() == PageNames.UPDATE)
                            {
                                dt = adminobjs.UpdateBusinessUpdateDetails(Convert.ToInt32(Session["BulletinID"].ToString()));
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["Remarks"].ToString() == "")
                                        remarks = CUserID + " -- " + TxtRemarks.Text;
                                    else
                                        remarks = CUserID + " -- " + TxtRemarks.Text + " | " + dt.Rows[0]["Remarks"].ToString();
                                    ss = "Update T_BusinessUpdates set Remarks='" + remarks + "', Rejected_By='" + CUserID + "', IsPublished='false',MODIFIED_USER=" + CUserID + ",MODIFIED_DATE='" + System.DateTime.Now + "',Publish_Date=null,IsPublic='false',Published_By=null where UpdateId=" + Convert.ToInt32(Session["BulletinID"].ToString()) + "";
                                    Val = InsertDetails(ss);
                                }
                                if (Val > 0)
                                    lblstatusmessage.Text = "<font face=arial size=2>Published update has been rejected successfully.</font>";
                            }
                            else if (Session["Type"].ToString() == PageNames.EVENT)
                            {
                                dt = eventobj.GetCalendarEventDetails(Convert.ToInt32(Session["BulletinID"].ToString()));
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["Remarks"].ToString() == "")
                                        remarks = CUserID + " -- " + TxtRemarks.Text;
                                    else
                                        remarks = CUserID + " -- " + TxtRemarks.Text + " | " + dt.Rows[0]["Remarks"].ToString();
                                    ss = "Update T_EventsCalendar set Remarks='" + remarks + "', Rejected_By='" + CUserID + "', IsPublished='false',ModifyDate='" + System.DateTime.Now + "',ModifiedUser=" + CUserID + ",Publish_Date=null,IsPublic='false',Published_By=null where EventId=" + Convert.ToInt32(Session["BulletinID"].ToString()) + "";
                                    Val = InsertDetails(ss);
                                }
                                if (Val > 0)
                                    lblstatusmessage.Text = "<font face=arial size=2>Published event has been rejected successfully.</font>";
                            }

                            SendRejectNotifications(Session["Type"].ToString(), UserID, Session["PageName"].ToString());
                            RemoveSession();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ApproveAndRejectForms.aspx.cs", "BtnReject_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void RemoveSession()
        {
            try
            {
                Session.Remove("BulletinID");
                Session.Remove("Type");
                Session.Remove("PageName");
                TxtRemarks.Text = "";
                Label1.Visible = BtnReject.Visible = TxtRemarks.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ApproveAndRejectForms.aspx.cs", "RemoveSession", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public string SendRejectNotifications(string typeName, int userID, string id) //Roles & Permissions...
        {
            string ccemail = string.Empty;
            string returnval = string.Empty;
            try
            {
                ccemail = id;

                string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\EmailContent\\";
                StreamReader re = File.OpenText(strfilepath + "RejectForms.txt");
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
                msgbody = msgbody.Replace("#RootUrl#", Session["RootPath"].ToString());
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#Type#", typeName);
                msgbody = msgbody.Replace("#Email#", (cUsername != "" && cUsername != null) ? cUsername : pUsername);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                UtilitiesBLL utlobj = new UtilitiesBLL();
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
                if (typeName == PageNames.BULLETIN)
                    returnval = utlobj.SendWowzzyEmail(emailInfo, pUsername, "Rejected Bulletin", msgbody, ccemail, "", "uspdhub");
                else if (typeName == PageNames.UPDATE)
                    returnval = utlobj.SendWowzzyEmail(emailInfo, pUsername, "Rejected Update", msgbody, ccemail, "", "uspdhub");
                else if (typeName == PageNames.EVENT)
                    returnval = utlobj.SendWowzzyEmail(emailInfo, pUsername, "Rejected Event", msgbody, ccemail, "", "uspdhub");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ApproveAndRejectForms.aspx.cs", "SendRejectNotifications", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnval;
        }

        public int InsertDetails(string query)
        {
            int returnval = 0;
            try
            {
               
                sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                sqlCmd = new SqlCommand(ss, sqlCon);
                returnval = sqlCmd.ExecuteNonQuery();
                USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ApproveAndRejectForms.aspx.cs", "InsertDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnval;
        }
    }
}