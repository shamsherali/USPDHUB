using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;

public partial class Business_MyAccount_BusinessUpdates : BaseWeb
{
    public static string Urlreferer = string.Empty;
    public int ProfileID = 0;
    public int UserID = 0;
    public int BusinessUpdatesCount = 0;
    BusinessUpdatesBLL adminobj = new BusinessUpdatesBLL();
    static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public static DataTable DtHis = new DataTable();
    DataTable dtBusinessUpdates = new DataTable();
    public DataTable DtCampaign = new DataTable();
    public int BusinessUpdateUsageCount = 0;
    public DataTable Dtobj = new DataTable();
    public DataTable DtOptOuts = new DataTable();
    public string ArticleTitle = string.Empty;
    public string ArticleSummary = string.Empty;
    public int Divnum = 1;
    public string LinkedInurlinfo = string.Empty;
    public string FacebookInurlinfo = string.Empty;
    public string Twitterurlinfo = string.Empty;
    public string Mailtourlinfo = string.Empty;
    public int SortDir = 0;
    public int CUserID = 0;  //Added By Venkat...
    public string RootPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblmess.Text = "";
            if (Session["userid"] == null)
            {

                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
            }
            // *** Get Domain Name *** //
            RootPath = Session["RootPath"].ToString();
            if (Session["Send"] != null)
            {
                if (Session["Send"].ToString() != "")
                {
                    if (Session["Send"].ToString() == "1")
                    {
                        if (Session["CheckMess"] != null)
                        {
                            if (Session["CheckMess"].ToString() != "")
                            {
                                if (Session["CheckMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this update as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckMess"].ToString() == "2")
                                {
                                    string invalidIds = string.Empty;
                                    if (Session["invalid"] != null)
                                    {
                                        if (Session["invalid"].ToString() != "")
                                        {
                                            invalidIds = Session["invalid"].ToString().ToString();
                                        }
                                        Session["invalid"] = null;
                                    }
                                    lblmess.Text = "<font color='green'>Update has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessUpdatemail + "</font>";
                                }
                                else if (Session["CheckMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Update has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this update because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessUpdatemail + "</font>";
                            }
                            Session["CheckMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessUpdatemail + "</font>";
                        }
                    }
                    else if (Session["Send"].ToString() == "2")
                    {
                        if (Session["CheckMess"] != null)
                        {
                            if (Session["CheckMess"].ToString() != "")
                            {
                                if (Session["CheckMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this update as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckMess"].ToString() == "2")
                                {
                                    string invalidIds = string.Empty;
                                    if (Session["invalid"] != null)
                                    {
                                        if (Session["invalid"].ToString() != "")
                                        {
                                            invalidIds = Session["invalid"].ToString().ToString();
                                        }
                                        Session["invalid"] = null;
                                    }
                                    lblmess.Text = "<font color='green'>Update has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessUpdate + "</font>";
                                }
                                else if (Session["CheckMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Update has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this update because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessUpdate + "</font>";
                            }
                            Session["CheckMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessUpdate + "</font>";
                        }

                    }
                }
                Session["Send"] = null;
            }


            // Check For Unlimted Users


            BusinessUpdateUsageCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("BusinessUpdateUsageCount").Replace(",", ""));

            string wflag = string.Empty;
            if (Request.QueryString["WFlag"] != null)
            {
                wflag = Request.QueryString["WFlag"];
                if (wflag.Length > 0)
                {
                    btnwizard.Visible = true;
                    btndashboard1.Visible = false;
                }
                else
                {
                    btnwizard.Visible = false;
                    btndashboard1.Visible = true;
                }
            }
            else
            {
                btnwizard.Visible = false;
                btndashboard1.Visible = true;
            }
            // End

            if (!IsPostBack)
            {
                ProfileID = Convert.ToInt32(Session["ProfileID"]);
                Session["BusinessUpdateID"] = null;
                Session["BusinessUpdateDes"] = null;
                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                if (Session["UpdateSuccess"] != null)
                {
                    lblmess.Text = "<font color='green'>" + Session["UpdateSuccess"].ToString() + "</font>";
                    Session["UpdateSuccess"] = null;
                }
                FillDatalist();
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }


    }

    public void FillDatalist()
    {
        try
        {
            Dtobj = adminobj.GetAllBusinessUpdates(Convert.ToInt32(Session["ProfileID"]));

            Session["DtGetBusinessUpdates"] = Dtobj;
            BusinessUpdatesCount = Dtobj.Rows.Count;
            if (BusinessUpdatesCount > 0)
            {
                //NoBusinessUpdatesBtn.Visible = false;
                if (Dtobj != null)
                {
                    GrdbusinessUpdates.DataSource = Dtobj.DefaultView;
                    GrdbusinessUpdates.DataBind();
                    lblsharetxt.Visible = true;
                    Iconhide.Visible = true;
                }
                else
                {
                    lblsharetxt.Visible = false;
                    Iconhide.Visible = false;
                    errMsg.Text = "<font color=red face=arial size=2>There are no updates at this time.</font>";
                }
            }
            else
            {
                //Button2.Visible = false;
                //Button3.Visible = false;
                lblsharetxt.Visible = false;
                Iconhide.Visible = false;
                GrdbusinessUpdates.DataSource = Dtobj.DefaultView;
                GrdbusinessUpdates.DataBind();
                //emptyLbl.Text = "<font color=red face=arial size=2>There are no updates at this time.</font>";
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "FillDatalist", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/BusinessUpdates.aspx?UFlag=1");
            Response.Redirect(urlinfo);
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "btn_cancel_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }


    protected void GrdbusinessUpdates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // *** Issue 1031 *** //
                Image imgcanceleventblank = e.Row.FindControl("imgcanceleventblank") as Image;
                LinkButton lnkcancel = e.Row.FindControl("lnkHis") as LinkButton;
                // *** End Issue 1031 *** //
                BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
                LinkButton lb = e.Row.FindControl("lnkUpdateName") as LinkButton;
                LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
                HtmlGenericControl div = (HtmlGenericControl)e.Row.FindControl("para1");
                div.ID = "para" + Divnum;
                Label lblshareit = e.Row.FindControl("lblshare") as Label;
                int controlid = Divnum + 1;
                Image imgexpand = e.Row.FindControl("imgTab") as Image;
                imgexpand.ID = "imgTab" + Divnum;
                if (controlid < 10)
                {
                    imgexpand.Attributes.Add("onclick", "return toggleMe('ctl00_cphUser_GrdbusinessUpdates_ctl0" + controlid + "_" + div.ID.ToString() + "', 'ctl00_cphUser_GrdbusinessUpdates_ctl0" + controlid + "_" + imgexpand.ID.ToString() + "');");
                    lblshareit.Text = "<a onclick=\"return toggleMe('ctl00_cphUser_GrdbusinessUpdates_ctl0" + controlid + "_" + div.ID.ToString() + "', 'ctl00_cphUser_GrdbusinessUpdates_ctl0" + controlid + "_" + imgexpand.ID.ToString() + "');\"><font color='#FA951E'>Share</font></a>";
                }
                else
                {
                    imgexpand.Attributes.Add("onclick", "return toggleMe('ctl00_cphUser_GrdbusinessUpdates_ctl" + controlid + "_" + div.ID.ToString() + "', 'ctl00_cphUser_GrdbusinessUpdates_ctl" + controlid + "_" + imgexpand.ID.ToString() + "');");
                    lblshareit.Text = "<a onclick=\"return toggleMe('ctl00_cphUser_GrdbusinessUpdates_ctl" + controlid + "_" + div.ID.ToString() + "', 'ctl00_cphUser_GrdbusinessUpdates_ctl" + controlid + "_" + imgexpand.ID.ToString() + "');\"><font color='#FA951E'>Share</font></a>";
                }
                lblshareit.Attributes["onmouseover"] = "this.style.cursor='hand'";
                int schCount = 0;
                schCount = objBusUpdate.CheckBusinessUpdateCampaignCount(Convert.ToInt32(lb.CommandArgument));
                if (schCount > 0)
                {
                    lnkcam.Visible = true;
                    lnkcancel.Visible = true;
                    imgcanceleventblank.Visible = false;
                }
                else
                {
                    lnkcam.Visible = false;
                    lnkcancel.Visible = false;
                    imgcanceleventblank.Visible = true;
                }
                LinkButton lnkhis = e.Row.FindControl("lblhistroy") as LinkButton;
                Label lnksent = e.Row.FindControl("lblsent") as Label;
                Label lblstatus = e.Row.FindControl("lblstatus") as Label;
                LinkButton lnkStatus = e.Row.FindControl("lnkStatus") as LinkButton;
                Label lblopened = e.Row.FindControl("lblopened") as Label;
                LinkButton lnkopened = e.Row.FindControl("lnkopen") as LinkButton;
                LinkButton lnkedit = e.Row.FindControl("btnModify") as LinkButton;
                LinkButton lnksendnews = e.Row.FindControl("lblsentupdate") as LinkButton;
                LinkButton lnkdel = e.Row.FindControl("lnkdelete") as LinkButton;
                Label lbloptcount = e.Row.FindControl("lboptout") as Label;
                LinkButton lnkoptout = e.Row.FindControl("lnkoptout") as LinkButton;
                //Issue 938 Image imginactive = e.Row.FindControl("imginactive") as Image;
                if (lblstatus.Text == "True")
                {
                    lnkStatus.Text = "Active";
                    //Issue 938  imginactive.Visible = false;
                }
                else
                {
                    lnkStatus.Text = "Inactive";
                    lnksendnews.Visible = false;
                    //Issue 938  imginactive.Visible = true;
                }
                DataTable dtChekHis = new DataTable();
                dtChekHis = objBusUpdate.GetBusinessUpdateDetailsByBusinessUpdateID(Convert.ToInt32(lnkhis.CommandArgument));
                if (dtChekHis.Rows.Count > 0)
                {
                    lnkhis.Visible = true;
                    lnkhis.Text = dtChekHis.Rows.Count.ToString();
                    e.Row.Cells[3].Visible = true;
                    lnksent.Visible = false;
                }
                else
                {
                    lnkhis.Visible = false;
                    lnksent.Text = "0";
                }
                int checkForUnsent = objBusUpdate.CheckForUnsentBusinessUpdateEmailsforDelete(Convert.ToInt32(lnkhis.CommandArgument), UserID);
                if (checkForUnsent > 0)
                {
                    lnkdel.OnClientClick = "if(confirm('Your update campaign has not been sent yet. Are you sure want to delete?')==false) return false;";
                    lnkedit.OnClientClick = "if(confirm('Your update campaign has not been sent yet. Are you sure want to edit?')==false) return false;";
                }
                else
                {
                    lnkdel.OnClientClick = "if(confirm('Are you sure you want to delete this Update?')==false) return false;";
                }
                dtChekHis.Dispose();
                int checkOpenedmails = 0;
                checkOpenedmails = objBusUpdate.GetOpenedMailsForID(Convert.ToInt32(lb.CommandArgument), UserID, "BU");
                if (checkOpenedmails > 0)
                {
                    lnkopened.Text = checkOpenedmails.ToString();
                    lblopened.Visible = false;
                }
                else
                {
                    lblopened.Text = "0";
                    lnkopened.Visible = false;
                }
                int checkOptCount = 0;

                checkOptCount = objBusUpdate.GetOptCountForBusinessUpdateHisID(Convert.ToInt32(lb.CommandArgument), UserID);
                if (checkOptCount > 0)
                {
                    lnkoptout.Text = checkOptCount.ToString();
                    lbloptcount.Visible = false;

                }
                else
                {
                    lbloptcount.Text = "0";
                    lnkoptout.Visible = false;
                }
                Divnum = Divnum + 1;
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "GrdbusinessUpdates_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkUpdateName_Click(object sender, EventArgs e)
    {
        try
        {
            string previewHtml = string.Empty;
            LinkButton lnkdetails = sender as LinkButton;
            DataTable dtBusinessUpdateDetails = adminobj.UpdateBusinessUpdateDetails(Convert.ToInt32(lnkdetails.CommandArgument));
            if (dtBusinessUpdateDetails.Rows.Count > 0)
            {
                previewHtml = dtBusinessUpdateDetails.Rows[0]["UpdatedText"].ToString();
                previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' style='padding:30px;'>" + previewHtml + "</td></tr></table></body></html>";
                lblPreviewHTML.Text = previewHtml;
                lblupdatename.Text = dtBusinessUpdateDetails.Rows[0]["UpdateTitle"].ToString();
                ModalPopupExtender2.Show();
            }

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lnkUpdateName_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    protected void lnkruncampaion_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkrun = sender as LinkButton;
            BusinessUpdatesBLL objBusUpdates = new BusinessUpdatesBLL();
            DtCampaign = objBusUpdates.GetCampaignBusinessDetailsByDates(Convert.ToInt32(lnkrun.CommandArgument));
            // *** Issue 1031 *** //
            DataView dtcampview = DtCampaign.DefaultView;
            dtcampview.Sort = "sent_Flag ASC";
            DtCampaign = dtcampview.ToTable();
            // *** End Issue 1031 ***  //
            lblp.Text = lnkrun.CommandArgument;
            if (DtCampaign.Rows.Count > 0)
            {
                grdschemail.DataSource = DtCampaign;
                grdschemail.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lnkruncampaion_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lblsentupdate_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessBLL objBus = new BusinessBLL();
            BusinessUpdatesBLL objBusUpdates = new BusinessUpdatesBLL();
            int checkSch = 0;
            checkSch = objBusUpdates.CheckforBusinessUpdateSchedule(UserID);
            int cntUsage = 0;
            int checkCam = 0;
            if (checkSch > 0)
            {
                checkCam = 1;
            }
            DataTable dtGetuserUsage = new DataTable();
            dtGetuserUsage = objBus.GetUserContactDetailsUsage(DateTime.Now.Date, UserID);
            if (dtGetuserUsage.Rows.Count > 0)
            {
                cntUsage = Convert.ToInt32(dtGetuserUsage.Rows[0]["BusinessUpdate_Usage"].ToString());
            }
            int chek = cntUsage + checkSch;
            checkSch = BusinessUpdateUsageCount - chek;
            if (checkSch > 0)
            {
                Session["BusinessUpdateID"] = null;
                Session["BusinessUpdateDes"] = null;
                LinkButton lnkUpdateID = sender as LinkButton;
                int businessUpdateID = 0;
                BusinessUpdatesBLL objBusUdpate = new BusinessUpdatesBLL();
                DataTable dtGetBusUpate = new DataTable();
                businessUpdateID = Convert.ToInt32(lnkUpdateID.CommandArgument);
                dtGetBusUpate = objBusUdpate.UpdateBusinessUpdateDetails(businessUpdateID);
                if (dtGetBusUpate.Rows.Count > 0)
                {
                    string businessUpdateDes = dtGetBusUpate.Rows[0]["UpdatedText"].ToString();
                    Session["BusinessUpdateID"] = businessUpdateID.ToString();
                    Session["BusinessUpdateDes"] = businessUpdateDes;
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendUpdates.aspx"));
                }
            }
            else
            {
                if (checkCam > 0)
                {
                    string maxSchDate = string.Empty;
                    maxSchDate = objBusUpdates.GetBusinessUpdateMaxScheduleingDate(UserID);
                    maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.AlreadyHaveBusinessUpdateCampaign + " " + maxSchDate + ".</font>";
                }
                else
                {
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendaffiliatecountExceeded + "</font>";
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lblsentupdate_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lblhistroy_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkHis = sender as LinkButton;
            BusinessUpdatesBLL objBusUpdates = new BusinessUpdatesBLL();
            DtHis = objBusUpdates.GetBusinessUpdateDetailsByBusinessUpdateID(Convert.ToInt32(lnkHis.CommandArgument));
            if (DtHis.Rows.Count > 0)
            {
                // *** Issue 1031 *** //
                DataView dtcampview = DtHis.DefaultView;
                dtcampview.Sort = "sent_Flag ASC";
                DtHis = dtcampview.ToTable();
                // *** End Issue 1031 ***  //
                grdviewsenthis.DataSource = DtHis;
                grdviewsenthis.DataBind();
                DataTable dtNewMaster = new DataTable();
                dtNewMaster = objBusUpdates.UpdateBusinessUpdateDetails(Convert.ToInt32(lnkHis.CommandArgument));
                if (dtNewMaster.Rows.Count > 0)
                {
                    lblviewsentnewlettername.Text = dtNewMaster.Rows[0]["UpdateTitle"].ToString();
                }
                ModalPopupExtender3.Show();
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lblhistroy_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkmodifyUpdate = sender as LinkButton;
            int updateID = Convert.ToInt32(lnkmodifyUpdate.CommandArgument);
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ModifyBusinessUpdate.aspx?Update_ID=" + updateID));
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "btnModify_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkdelete = sender as LinkButton;
            BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
            int countCampaign = objBusUpdate.CheckBusinessUpdateCampaignCount(Convert.ToInt32(lnkdelete.CommandArgument));
            if (countCampaign == 0)
            {
                USPDHUBBLL.BusinessUpdatesBLL.DeleteBusinessUpdateDetails(Convert.ToInt32(lnkdelete.CommandArgument));
                FillDatalist();
                lblmess.Text = "<font color='red'>Your update has been deleted successfully.</font>";
            }
            else
            {
                string maxSchDate = string.Empty;
                maxSchDate = objBusUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
                maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                lblmess.Text = "<font color='green'>Sorry, you cannot delete your update now as you have a update campaign scheduled till" + " " + maxSchDate + ".</font>";
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lnkdelete_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void grdschemail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdschemail.PageIndex = e.NewPageIndex;
            grdschemail.DataSource = DtCampaign;
            grdschemail.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "grdschemail_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void grdschemail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbldate = e.Row.FindControl("Label2") as Label;
                Label lblCount = e.Row.FindControl("Label4") as Label;
                Label lblstatus = e.Row.FindControl("Label6") as Label;
                if (lblstatus.Text == "1")
                {
                    lblstatus.Text = "Sent";
                }
                else if (lblstatus.Text == "0")
                {
                    lblstatus.Text = "Scheduled";
                }
                else if (lblstatus.Text == "2")
                {
                    lblstatus.Text = "Cancel";
                }
                BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
                int count = 0;
                count = objBusUpdate.GetBusinessupdateCountforDayforUserDateAndUpdateID(UserID, Convert.ToDateTime(lbldate.Text), Convert.ToInt32(lblp.Text));
                lblCount.Text = count.ToString();
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "grdschemail_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void imclose_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void btnstopcampain_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
            objBusUpdate.UpdateBusinessUpdateUsageByUserID(UserID, DateTime.Today);
            objBusUpdate.CancelBusinessUpdateCampaign(Convert.ToInt32(lblp.Text));
            FillDatalist();
            lblmess.Text = "<font color='green'>Your update campaign has been cancelled successfully.</font>";
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "btnstopcampain_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void grdviewsenthis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdviewsenthis.PageIndex = e.NewPageIndex;
            grdviewsenthis.DataSource = DtHis;
            grdviewsenthis.DataBind();
            ModalPopupExtender3.Show();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "grdviewsenthis_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void grdviewsenthis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstatus = e.Row.FindControl("Label2") as Label;
                if (lblstatus.Text == "1")
                {
                    lblstatus.Text = "Sent";
                }
                else if (lblstatus.Text == "0")
                {
                    lblstatus.Text = "Scheduled";
                }
                else if (lblstatus.Text == "2")
                {
                    lblstatus.Text = "Cancel";
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "grdviewsenthis_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void GrdbusinessUpdates_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdbusinessUpdates.PageIndex = e.NewPageIndex;
            GrdbusinessUpdates.DataSource = Dtobj;
            GrdbusinessUpdates.DataBind();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "GrdbusinessUpdates_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private string UserProfileUnsubscribeLink()
    {
        string unSubscribeLinkText = string.Empty;
        string profileName = string.Empty;
        string totalAddress = string.Empty;
        try
        {
            BusinessBLL objBus = new BusinessBLL();
            DataTable dtProfileAddress = new DataTable();
            dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
          
            
            if (dtProfileAddress.Rows.Count > 0)
            {
                if (dtProfileAddress.Rows[0]["Profile_name"].ToString() != "")
                {
                    profileName = dtProfileAddress.Rows[0]["Profile_name"].ToString();
                }
                if (dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString() != "")
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString();
                }
                if (dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString() != "")
                {
                    if (totalAddress != "")
                    {
                        totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    else
                    {
                        totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                }
                if (dtProfileAddress.Rows[0]["Profile_City"].ToString() != "")
                {
                    if (totalAddress != "")
                    {
                        totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_City"].ToString();
                    }
                    else
                    {
                        totalAddress = dtProfileAddress.Rows[0]["Profile_City"].ToString();
                    }
                }
                if (dtProfileAddress.Rows[0]["Profile_State"].ToString() != "")
                {
                    if (totalAddress != "")
                    {
                        totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_State"].ToString();
                    }
                    else
                    {
                        totalAddress = dtProfileAddress.Rows[0]["Profile_State"].ToString();
                    }
                }
                if (dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString() != "")
                {
                    if (totalAddress != "")
                    {
                        totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                    }
                    else
                    {
                        totalAddress = dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        unSubscribeLinkText = "This message was sent " + profileName + " to &#60;recipient's email address&#62;. It was sent from &#60;sender's email address&#62;" + totalAddress + ". If you no longer wish to receive our updates, <a href='" + RootPath + "/Unsubscribeupdate.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
        return unSubscribeLinkText;
    }
    protected void btndashboard1_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

    protected void btnwizard_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/ManageBusinessDetails.aspx");
        Response.Redirect(urlinfo);
    }

    protected void lnkoptout_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkOptOutID = sender as LinkButton;

            BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
            DtOptOuts = objBusUpdate.GetOptOutCountForUpdateID(Convert.ToInt32(lnkOptOutID.CommandArgument));
            if (DtOptOuts.Rows.Count > 0)
            {
                grdoptouts.DataSource = DtOptOuts;
                grdoptouts.DataBind();
                ModalPopupExtender10.Show();
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lnkoptout_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void grdoptouts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdoptouts.PageIndex = e.NewPageIndex;
            grdoptouts.DataSource = DtOptOuts;
            grdoptouts.DataBind();
            ModalPopupExtender10.Show();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "grdoptouts_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected string GetSharestrings(int updateID, string updateTitle)
    {
        #region Sharelinks with Facebook, LinkedIn, Twitter, MySpace and Email
        ArticleTitle = updateTitle.ToString();
        ArticleSummary = updateTitle.ToString();


        //Facebook
        string facebookInurlinfo1 = "http://www.facebook.com/share.php?u=" + RootPath + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(updateID.ToString());
        FacebookInurlinfo = "<a href='" + facebookInurlinfo1 + "' onclick='return fbs_click()' target='_blank'><img src=" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/images/fshare.gif" + " alt='Share on Facebook' title='Share on Facebook' border='0' width='15' height='15' style='padding-top:5px;' /></a>&nbsp;";
        //Facebook


        //LinkedIN
        string update = EncryptDecrypt.DESEncrypt(updateID.ToString());
        string articleUrl1 = RootPath + "/OnlineUpdate.aspx?BID=" + update;
        string articleSource = RootPath;
        string linkedInurlinfo1 = "http://www.linkedin.com/shareArticle?mini=true&url=" + HttpUtility.UrlEncode(articleUrl1) + "&title=" + HttpUtility.UrlEncode(ArticleTitle) + "&summary=" + HttpUtility.UrlEncode(ArticleSummary) + "&source=" + HttpUtility.UrlEncode(articleSource);
        LinkedInurlinfo = "<a href='" + linkedInurlinfo1.ToString() + "' target='_blank'><img src=" + RootPath + "/images/linkedin.gif title='Share on Linkedin' border='0' width='15' height='15'/></a>&nbsp;";
        //LinkedIn

        //Twitter
        string twitterurlinfo1 = "http://twitter.com/home?status=" + ArticleTitle + " - " + articleUrl1;
        Twitterurlinfo = "<a href='" + twitterurlinfo1 + "' title='Click to share this post on Twitter' target='_blank'><img src=" + RootPath + "/images/twitter.gif alt='Share on Twitter' title='Share on Twitter' border='0' width='15' height='15'/></a>&nbsp;";
        //Twitter

        //Mail TO Url
        string url = RootPath + "/Business/Myaccount/ShareEmail.aspx?BU=" + update;
        Mailtourlinfo = "<a href=\"javascript:openEmailwindow('" + url + "')\"><img src=" + RootPath + "/images/message.gif title='Share on Email' width='15' height='15' alt='Share on Email'/></a>&nbsp;";


        //Mail TO Url

        //My Space
        // *** Issue1215 *** //
        //string desc = string.Empty;
        //string myspace = "<a href=\"javascript:GetThis('" + articleTitle + "','" + desc + "', '" + ur + "')\"><img src=" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/images/myspace.gif title='Share on MySpace' width='15' height='15' alt='Share on MySpace'/></a>";
        //My Space

        string returunurl = Mailtourlinfo + FacebookInurlinfo + Twitterurlinfo + LinkedInurlinfo;
        return returunurl;
        #endregion
    }
    protected void lnkopen_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkOpenID = sender as LinkButton;
            BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
            DtOptOuts = objBusUpdate.GetOpenedMailsForUpdateID(Convert.ToInt32(lnkOpenID.CommandArgument), "BU");
            if (DtOptOuts.Rows.Count > 0)
            {
                grdmailopen.DataSource = DtOptOuts;
                grdmailopen.DataBind();
                ModalPopupExtender4.Show();
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lnkopen_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void grdmailopen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdmailopen.PageIndex = e.NewPageIndex;
            grdmailopen.DataSource = DtOptOuts;
            grdmailopen.DataBind();
            ModalPopupExtender4.Show();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "grdmailopen_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void GrdbusinessUpdates_Sorting(object sender, GridViewSortEventArgs e)
    {

        try
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string sortExp = e.SortExpression.ToString();
            dtBusinessUpdates = (DataTable)Session["DtGetBusinessUpdates"];
            if (hdnsortdire.Value != "")
            {
                if (hdnsortdire.Value != sortExp)
                {
                    hdnsortdire.Value = sortExp;
                    SortDir = 0;
                    hdnsortcount.Value = "0";

                }

            }
            else
            {
                hdnsortdire.Value = sortExp;
            }
            DataView dv = new DataView(dtBusinessUpdates);
            if (SortDir == 0)
            {

                if (sortExp == "Name")
                {
                    dv.Sort = "updatetitle desc";
                }
                else if (sortExp == "Status")
                {
                    dv.Sort = "status desc";
                }
                else if (sortExp == "UpdateTime")
                {
                    dv.Sort = "UpdateTime desc";
                }

                hdnsortcount.Value = "1";
            }
            else
            {
                if (sortExp == "Name")
                {
                    dv.Sort = "updatetitle ASC";
                }
                else if (sortExp == "Status")
                {
                    dv.Sort = "status ASC";
                }
                else if (sortExp == "UpdateTime")
                {
                    dv.Sort = "UpdateTime asc";
                }

                hdnsortcount.Value = "0";
            }

            Session["DtGetBusinessUpdates"] = dv.ToTable();
            GrdbusinessUpdates.DataSource = dv;
            GrdbusinessUpdates.DataBind();

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BulletinVideoGallery.aspx.cs", "GrdbusinessUpdates_Sorting", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    //issue 1095
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkStatus = (LinkButton)sender;
            BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
            int i = 0;
            i = objBusUpdate.UpdateBusinessUpdateStatus(Convert.ToInt32(lnkStatus.CommandArgument), lnkStatus.Text == "Active" ? false : true, ProfileID, CUserID);
            if (i > 0)
                lblmess.Text = "<font color='green'>Status Updated Successfully</font>";

            FillDatalist();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "BusinessUpdates.aspx.cs", "lnkStatus_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}

