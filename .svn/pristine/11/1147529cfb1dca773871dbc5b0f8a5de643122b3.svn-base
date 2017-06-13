using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;

public partial class Business_MyAccount_Discussions : BaseWeb
{
    public int UserID = 0;
    public int ProfileID = 0;
    public int Inboxflag = 0;
    public DataTable Dtobj = new DataTable();
    static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public string Headertext = string.Empty;
    public int CUserID = 0;
    public string RootPath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Added the Auto Refresh code for the Appointments.
            if (this.Master.Page.Header != null)
            {
                HtmlHead hh = this.Master.Page.Header;
                HtmlMeta hm = new HtmlMeta();
                hm.Attributes.Add("http-equiv", "Refresh");
                hm.Attributes.Add("content", "300");
                hh.Controls.Add(hm);

            }
            // End of the Auto Refresh Code.

            lblmess.Text = "";
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                UserID = Convert.ToInt32(Session["userid"]);
                lblfirstname.Text = "<font color=green size=3><b>" + Session["Firstname"].ToString() + "'s</B></font>";

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
            }
            // *** Get Domain Name *** //
            RootPath = Session["RootPath"].ToString();
            if (Session["ProfileID"] != null)
                ProfileID = Convert.ToInt32(Session["ProfileID"]);



            if ((Request.QueryString["T"] != null))
            {
                if (Request.QueryString["T"].ToString() == "INBOX")
                {
                    lblinbox.Text = "<font color=green size=3><b>Inbox</b></font>";
                    lblsent.Text = "Sent Messages";
                    //lblemail.Text = "Sent Emails";
                    Inboxflag = 1;
                }
                else
                {
                    lblinbox.Text = "Inbox";
                    //lblemail.Text = "Sent Emails";
                    lblsent.Text = "<font color=green size=3><b>Sent Messages</b></font>";
                }
            }
            else
            {
                Inboxflag = 1;
                lblinbox.Text = "<font color=green size=3><b>Inbox</b></font>";
                lblsent.Text = "Sent Messages";
                //lblemail.Text = "Sent Emails";
            }


            if (!IsPostBack)
            {

                FillGrid();



            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    protected string GetURLString(int msgid)
    {
        string urlstring = string.Empty;
        try
        {
            int replyid = 0;
            DataTable dtobj = new DataTable();
            BusinessBLL busobj = new BusinessBLL();
            dtobj = busobj.GetMessageDetailsByID(msgid);
            if (dtobj.Rows.Count > 0)
            {
                replyid = Convert.ToInt32(dtobj.Rows[0]["Reply_ID"]);
            }

            if ((Request.QueryString["T"] != null))
            {
                if (Request.QueryString["T"].ToString() == "INBOX")
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["User_Read_Flag"].ToString()) == true)
                    {
                        if (replyid >= 0)
                        {
                            if (Convert.ToInt32(dtobj.Rows[0]["From_ID"]) != 0)
                                urlstring = "<a href='Reply.aspx?msgid=" + msgid + "'> Reply</a>";
                            else
                                urlstring = string.Empty;
                        }
                    }
                    else
                    {
                        urlstring = string.Empty;
                    }

                }
                else
                {
                    urlstring = "Sent";
                }
            }
            else
            {
                if (Convert.ToBoolean(dtobj.Rows[0]["User_Read_Flag"].ToString()) == true)
                {
                    if (replyid == 0)
                    {
                        if (Convert.ToInt32(dtobj.Rows[0]["From_ID"]) != 0)
                            urlstring = "<a href='Reply.aspx?msgid=" + msgid + "'> Reply</a>";
                        else
                            urlstring = string.Empty;
                    }
                    else
                        urlstring = "<a href='Reply.aspx?msgid=" + msgid + "'> Reply</a>";
                }
                else
                {
                    urlstring = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "GetURLString", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

        return urlstring;
    }



    protected string GetViewURLString(int msgid)
    {
        string subject = string.Empty;
        DataTable dtobjmsg = new DataTable();
        BusinessBLL busobj = new BusinessBLL();
        string urlstring = string.Empty;
        try
        {
            dtobjmsg = busobj.GetMessageDetailsByID(msgid);
            if (dtobjmsg.Rows.Count > 0)
            {
                subject = dtobjmsg.Rows[0]["subject"].ToString();
            }
            if (Inboxflag == 1)
            {
                if (dtobjmsg.Rows[0]["User_Read_Flag"].ToString() == "False")
                {

                    urlstring = "<b><a href='ViewMessage.aspx?T=INBOX&msgid=" + msgid + "'>" + subject + "</a></b>";
                }
                else
                {

                    urlstring = "<a href='ViewMessage.aspx?T=INBOX&msgid=" + msgid + "'>" + subject + "</a>";
                }

            }
            else
            {

                if (dtobjmsg.Rows[0]["Profile_Read_Flag"].ToString() == "False")
                {

                    urlstring = "<a href='ViewMessage.aspx?T=SENT&msgid=" + msgid + "'>" + subject + "</a>";
                }
                else
                {

                    urlstring = "<a href='ViewMessage.aspx?T=SENT&msgid=" + msgid + "'>" + subject + "</a>";
                }

            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "GetViewURLString", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }


        return urlstring;
    }

    protected void msgGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            //Edit Record in Discussions
            Discussions.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "msgGrid_RowEditing", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void msgGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            //Cancle Record in Discussions
            Discussions.EditIndex = -1;
            FillGrid();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "msgGrid_RowCancelingEdit", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }


    protected void msgGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            // Raise Alerts

            //issue No: #161
            // 17-01-09
            if (e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[2].Text = Headertext;
                //Issue 253 
                if (Request.QueryString["T"] != null)
                {
                    if (Request.QueryString["T"].ToString() == "INBOX")
                    {
                        e.Row.Cells[4].Visible = true;
                        e.Row.Cells[4].Text = "Status";
                    }
                    else
                    {
                        e.Row.Cells[4].Visible = false;
                    }
                }
                else
                {
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[4].Text = "Status";
                }
            }
            //end issue 253

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblsub = e.Row.FindControl("Label3") as Label;
                Label lblstatus = e.Row.FindControl("lblstatus") as Label;
                Image MessImage = e.Row.FindControl("MessageLogo") as Image;
                //Issue 253 
                if (Request.QueryString["T"] != null)
                {
                    if (Request.QueryString["T"].ToString() == "INBOX")
                    {
                        lblstatus.Visible = true;
                        e.Row.Cells[4].Visible = true;
                    }
                    else
                    {
                        lblstatus.Visible = false;
                        e.Row.Cells[4].Visible = false;
                    }
                }
                else
                {
                    e.Row.Cells[4].Visible = true;
                    lblstatus.Visible = true;
                }
                //end issue 253
                int msgid = Convert.ToInt32(Discussions.DataKeys[e.Row.RowIndex]["Message_ID"].ToString());
                string subject = string.Empty;
                DataTable dtobjmsg = new DataTable();
                BusinessBLL busobj = new BusinessBLL();
                dtobjmsg = busobj.GetMessageDetailsByID(msgid);
                int RepliedMsgCount = busobj.GetRepliedMessageCountByMsgID(msgid);
                if (MessImage != null)
                {
                    if (Inboxflag == 1)
                    {
                        if (dtobjmsg.Rows[0]["User_read_Flag"].ToString() == "False")
                        {
                            MessImage.ImageUrl = RootPath + "/images/message-r0-s3.gif";

                            lblstatus.Text = "New";
                        }
                        else
                        {
                            MessImage.ImageUrl = RootPath + "/images/business1.gif";
                            if (RepliedMsgCount == 0)
                            {

                                lblstatus.Text = "Read";
                            }
                            else
                            {
                                lblstatus.Text = "Replied";
                            }
                        }
                    }
                    else
                    {
                        if (dtobjmsg.Rows[0]["profile_read_flag"].ToString() == "False")
                        {
                            MessImage.ImageUrl = RootPath + "/images/message-r0-s3.gif";

                            lblstatus.Text = "New";
                        }
                        else
                        {
                            MessImage.ImageUrl = RootPath + "/images/business1.gif";
                            if (RepliedMsgCount == 0)
                            {

                                lblstatus.Text = "Read";
                            }
                            else
                            {
                                lblstatus.Text = "Replied";
                            }
                        }
                    }

                }
                if (Discussions.EditIndex == -1)
                {
                    LinkButton Linkbtn = e.Row.FindControl("btnDelete") as LinkButton;
                    if (Linkbtn != null)
                        Linkbtn.OnClientClick = "if (confirm('Are you sure you want to delete this Message?') == false) return false;";
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "msgGrid_RowDataBound", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessBLL BusObj = new BusinessBLL();
            LinkButton lnkdel = sender as LinkButton;
            int msgID = Convert.ToInt32(lnkdel.CommandArgument.ToString());
            if (Inboxflag == 1)
            {
                int uflag = BusObj.ManageBusinessMessage(0, 0, 0, string.Empty, string.Empty, 0, true, msgID, UserID, 1, CUserID);
            }
            else
            {
                int uflag = BusObj.ManageBusinessMessage(0, 0, 0, string.Empty, string.Empty, 0, true, msgID, UserID, 2, CUserID);
            }
            FillGrid();
            errMsg.Text = "<font face=arial color=red size=3><b>Your message has been deleted successfully.</b></font>";
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "btnDelete_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void msgGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Discussions.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void msgGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }
    public void FillGrid()
    {
        try
        {
            //Populate Data in to ConsumersGrid
            BusinessBLL Busobj = new BusinessBLL();
            if (Session["userid"] != null)
            {
                UserID = Convert.ToInt32(Session["userid"]);
            }
            if (Inboxflag == 1)
            {
                Dtobj = Busobj.GetProfileMessages(false, ProfileID);

                Headertext = "Sender";
            }
            else // load the sent items 
            {
                Dtobj = Busobj.GetProfileSentMessages(false, ProfileID);
                Headertext = "Sent to";
            }

            if (Dtobj != null)
            {
                if (Dtobj.Rows.Count > 0)
                {

                    Discussions.DataSource = Dtobj;
                    Discussions.DataBind();
                }
                else
                {
                    // All the rows are deleted .. then assign the empty data table.
                    Discussions.DataSource = Dtobj;
                    Discussions.DataBind();

                    errMsg.Text = "<font color=red face=arial size=2> &nbsp;</font>";
                }
            }
            else
            {   // All the rows are deleted .. then assign the empty data table.
                Discussions.DataSource = Dtobj;
                Discussions.DataBind();
                errMsg.Text = "<font color=red face=arial size=2> &nbsp;</font>";
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "FillGrid", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lblCompose_Click(object sender, EventArgs e)
    {
        string urlinfo = string.Empty;
        urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/sendmail.aspx");
        Response.Redirect(urlinfo);
    }

    //***Start Issue 1234 ***//
    protected void lnkUnRead_Click(object sender, EventArgs e)
    {
        try
        {
            //lblinbox.Text = "<font color=green size=3><b>Inbox</b></font>";
            //lnkUnRead.Font.Size = 11;
            //lnkUnRead.ForeColor = System.Drawing.Color.Green;
            //lnkUnRead.Font.Bold=true;
            lblsent.Text = "Sent Messages";
            lblinbox.Text = "Inbox";
            lnkUnRead.Text = "<font color=green size=3><b>Unread</b></font>";
            BusinessBLL Busobj1 = new BusinessBLL();
            DataTable dt = new DataTable();
            dt = Busobj1.GetProfileMessages(false, ProfileID);
            string str = "User_read_Flag=false";
            DataView dv = new DataView(dt, str, "CREATED_DT DESC", DataViewRowState.CurrentRows);
            Discussions.DataSource = dv;
            Discussions.DataBind();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Discussions.aspx.cs", "lnkUnRead_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    //***End Issue 1234 ***//
}
