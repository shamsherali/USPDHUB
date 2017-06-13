using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Aurigma.GraphicsMill;
using System.Drawing;


public partial class Business_MyAccount_MobileAppAlerts : BaseWeb
{
    BusinessBLL objBus = new BusinessBLL();
    public int UserID = 0;
    DataTable dtobj = new DataTable();
    DataTable dttips = new DataTable();
    DataTable dtPrivatecCalls = new DataTable();
    public int NewslettersCount = 0;
    public int C_UserID = 0;
    public int ProfileID = 0;
    public int SortDir = 0;
    public int TipsCount = 0;
    public DataTable dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    CommonBLL objCommon = new CommonBLL();
    public string Permission_Type = string.Empty;
    public int Permission_Value = 0;
    public string DisplayFeedTip = "Feedback";
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public int PrivateCallsCount = 0;
    public bool IsShowTipsGrid = false;
    public bool IsShowContactusGrid = false;
    public bool IsShowPrivateCallsGrid = false;
    public bool isHavingContactButton = false;
    public bool isHavingTipsButton = false;
    public bool isHavingPrivateCallButton = false;
    DropDownList ddlPageSize_Message;
    DropDownList ddlPageSize_Tips;
    DropDownList ddlPageSize_PrivateCall;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            if (Session["userid"] != null)
            {
                UserID = Convert.ToInt32(Session["userid"]);

                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            btnDelete.Attributes.Add("onclick", "javascript:return Confirmationbox(this.form,'1')");
            btnBlockUsers.Attributes.Add("onclick", "javascript:return Confirmationbox(this.form,'2')");
            if (Session["VerticalDomain"].ToString().ToLower().Contains("uspdhub"))
                DisplayFeedTip = "Tips";

            /*** Store Module Functionality ***/
            if (objBus.CheckModulePermission(WebConstants.Purchase_ContactUs_BlockSenderSetup, ProfileID))
            {
                IsShowContactusGrid = true;
                btnBlockUsers.Visible = true;
            }
            if (objBus.CheckModulePermission(WebConstants.Purchase_Tips_BlockSenderSetup, ProfileID))
            {
                IsShowTipsGrid = true;
                btnBlockUsers.Visible = true;
            }
            if (objBus.CheckModulePermission(WebConstants.Purchase_PrivateCallAddOns, ProfileID))
            {
                IsShowPrivateCallsGrid = true;
                btnBlockUsers.Visible = true;
            }
            if (!IsPostBack)
            {
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = "";
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageMessageReceipt");

                    if (hdnPermissionType.Value == "A")
                    {
                        UpdatePanel1.Visible = false;
                        UpdatePanel2.Visible = true;
                        lblerrormessage.Text = "<font face=arial size=2 color=red>You do not have permission to access app messages.</font>";
                        return;
                    }
                }//
                string pageComesFrom = Convert.ToString(Request.UrlReferrer);
                if (pageComesFrom.Contains("ViewMessageDetails.aspx") && Session["SelectedValues"] != null)
                    GetSelectedValues();
                else
                {

                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";
                    hdnsortdir.Value = "";
                    hdnsortcnt.Value = "0";
                    hdnPrivateCallSortCount.Value = "0";
                    hdnShowingContact.Value = "0"; //0 means Current, 1 means Archive
                    hdnShowingTips.Value = "0";
                    hdnShowingPrivateMsg.Value = "0";
                    filldata();
                }

                //ends here
                BindMessageTitles();
                GetMessagesCount();
            }
            checkHavingMessagesButton();
            ddlPageSize_Message = (DropDownList)PageSizes_Messages.FindControl("ddlPageSize");
            ddlPageSize_Message.AutoPostBack = true;
            ddlPageSize_Message.SelectedIndexChanged += ddlPageSize_Message_SelectedIndexChanged;

            ddlPageSize_Tips = (DropDownList)PageSize_Tips.FindControl("ddlPageSize");
            ddlPageSize_Tips.AutoPostBack = true;
            ddlPageSize_Tips.SelectedIndexChanged += ddlPageSize_Tips_SelectedIndexChanged;

            ddlPageSize_PrivateCall = (DropDownList)PageSize_PrivateCall.FindControl("ddlPageSize");
            ddlPageSize_PrivateCall.AutoPostBack = true;
            ddlPageSize_PrivateCall.SelectedIndexChanged += ddlPageSize_PrivateCall_SelectedIndexChanged;
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void grdNewsletercontacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblchecked = e.Row.FindControl("lblchecked") as Label;
                if (lblchecked.Text == "False")
                {
                    e.Row.CssClass = "UnreadInquiry";
                }
                else
                {
                    e.Row.CssClass = "readInquiry";
                }

                Label lbldescription = e.Row.FindControl("lbldescription") as Label;
                //Label lblReply = e.Row.FindControl("lblReply") as Label;
                string[] data = lbldescription.Text.Split('|');
                if (data.Length > 3)
                    lbldescription.Text = data[3].ToString();
                else
                    lbldescription.Text = "";

                //if (data[2] != null && data[2] != "")
                //{
                //    //lblReply.Text = "<a href=\"mailto:" + data[2].ToString() + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                //    lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + data[2].ToString() + "')\" />";
                //}

                CheckBox headerchk = (CheckBox)grdNewsletercontacts.HeaderRow.FindControl("chkSelectAllMsgs");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkMessages");
                childchk.Attributes.Add("onclick", "javascript:SelectMsgscheckboxes('" + headerchk.ClientID + "')");
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "grdNewsletercontacts_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    protected void grdNewsletercontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdNewsletercontacts.PageIndex = e.NewPageIndex;
        hdnPageIndex_Contact.Value = Convert.ToString(grdNewsletercontacts.PageIndex);
        dtobj = (DataTable)Session["DtMobileAppAlerts"];
        grdNewsletercontacts.DataSource = dtobj;
        grdNewsletercontacts.DataBind();
    }

    int archiveContactType = 0;
    int archiveTipType = 0;
    int archivePriveCallType = 0;

    protected void filldata() //Contact|Tips|PrivateCallMsg
    {
        try
        {
            getArchiveType();
            dtobj = objBus.GetMobileAppAlerts(true, UserID, null, archiveContactType);
            if (dtobj.Rows.Count <= 0)
                GetMessagesCount();
            GetSavedUserData();
            NewslettersCount = dtobj.Rows.Count;
            Session["DtMobileAppAlerts"] = dtobj;
            grdNewsletercontacts.PageIndex = Convert.ToInt32(hdnPageIndex_Contact.Value);
            grdNewsletercontacts.PageSize = Convert.ToInt32(hdnPageSize_Messages.Value);
            grdNewsletercontacts.DataSource = dtobj;
            grdNewsletercontacts.DataBind();

            dttips = objBus.GetMobileTips(true, UserID, null, archiveTipType);
            TipsCount = dttips.Rows.Count;
            Session["dttips"] = dttips;
            GrdTips.PageIndex = Convert.ToInt32(hdnPageIndex_Tips.Value);
            GrdTips.PageSize = Convert.ToInt32(hdnPageSize_Tips.Value);
            GrdTips.DataSource = dttips;
            GrdTips.DataBind();
            dtPrivatecCalls = objBus.GetMobilePrivateCallsHistory(true, 0, ProfileID, false, archivePriveCallType);
            PrivateCallsCount = dtPrivatecCalls.Rows.Count;
            Session["dtPrivateCalls"] = dtPrivatecCalls;
            grdPrivateCallHistory.PageIndex = Convert.ToInt32(hdnPageIndex_PrivateCalls.Value);
            grdPrivateCallHistory.PageSize = Convert.ToInt32(hdnPageSize_PrivateCalls.Value);
            grdPrivateCallHistory.DataSource = dtPrivatecCalls;
            grdPrivateCallHistory.DataBind();

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "filldata", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkcontactname_Click(object sender, EventArgs e)
    {
        StoreSelectedValues();
        LinkButton lnk = sender as LinkButton;
        string ContactID = lnk.CommandArgument.ToString();
        //ShowContactusDetails(ContactID, "NL");
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ViewMessageDetails.aspx?BT=" + EncryptDecrypt.DESEncrypt(ButtonTypes.ContactUs) + "&MHID=" + EncryptDecrypt.DESEncrypt(ContactID)));
    }

    protected void lnktips_Click(object sender, EventArgs e)
    {
        StoreSelectedValues();
        LinkButton lnk = sender as LinkButton;
        string ContactID = lnk.CommandArgument.ToString();
        //ShowContactusDetails(ContactID, "T");
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ViewMessageDetails.aspx?BT=" + EncryptDecrypt.DESEncrypt(ButtonTypes.Tips) + "&MHID=" + EncryptDecrypt.DESEncrypt(ContactID)));
    }


    protected void lnkArchiveToCurrentPrivate_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkArchive = sender as LinkButton;
            int messatgeId = Convert.ToInt32(lnkArchive.CommandArgument.ToString());
            objCommon.ArchiveSelectedNewsletter(messatgeId, false, "Privatecalladdon", C_UserID);

            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkArchiveToCurrentPrivate_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkArchivePrivat_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkArchive = sender as LinkButton;
            int messatgeId = Convert.ToInt32(lnkArchive.CommandArgument.ToString());
            objCommon.ArchiveSelectedNewsletter(messatgeId, true, "Privatecalladdon", C_UserID);
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkArchivePrivat_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkdel = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnkdel.CommandArgument.ToString());
            objBus.SelectMobileAppAlerts(0, ContactID, false, C_UserID);
            lblmsg.Text = "<font size='3' color='green'>" + Resources.LabelMessages.MobileMessage.ToString() + "<b></b><font>";
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkdelete_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkArchiveContacts_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkArchive = sender as LinkButton;
            int messatgeId = Convert.ToInt32(lnkArchive.CommandArgument.ToString());
            objCommon.ArchiveSelectedNewsletter(messatgeId, true, "Contact", C_UserID);
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkArchiveContacts_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkContactArchiveToCurrent_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkArchive = sender as LinkButton;
            int messatgeId = Convert.ToInt32(lnkArchive.CommandArgument.ToString());
            objCommon.ArchiveSelectedNewsletter(messatgeId, false, "Contact", C_UserID);

            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkArchiveToCurrent_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkTipsArchive_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkArchive = sender as LinkButton;
            int messatgeId = Convert.ToInt32(lnkArchive.CommandArgument.ToString());
            objCommon.ArchiveSelectedNewsletter(messatgeId, true, "Tips", C_UserID);
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkTipsArchive_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkContactArchiveToCurrentTips_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkArchive = sender as LinkButton;
            int messatgeId = Convert.ToInt32(lnkArchive.CommandArgument.ToString());
            objCommon.ArchiveSelectedNewsletter(messatgeId, false, "Tips", C_UserID);

            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkContactArchiveToCurrentTips_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        cleardata();
        ModalPopupExtender1.Hide();
        filldata();
    }
    private void ShowContactusDetails(int ContactID, string ContactusType)
    {
        try
        {
            cleardata();
            DataTable dtNLContact = new DataTable();
            dtNLContact = objBus.SelectMobileAppAlerts(UserID, ContactID, false, C_UserID);
            if (ContactusType == "T")
                lblmess.Text = "Tip:";
            else
                lblmess.Text = "Message:";

            if (dtNLContact.Rows.Count > 0)
            {
                string data = dtNLContact.Rows[0]["Message"].ToString();
                string[] message = data.Split('|');
                lblfn.Text = message[0].ToString();
                if (message[2] != null && message[2] != "")
                    lblemail.Text = message[2].ToString();
                if (message[1] != null && message[1] != "")
                    lblphone.Text = message[1].ToString();
                if (message.Length > 3)
                    lbldescription.Text = message[3].ToString();
                else
                    lbldescription.Text = "";
                lblheader.Text = " Subject: " + dtNLContact.Rows[0]["Subject"].ToString();

                // Used to Get the Address based on latitude and longitude......

                if (Convert.ToString(dtNLContact.Rows[0]["CurrentLocation"]) == string.Empty)
                {
                    if (dtNLContact.Rows[0]["Latitude1"] != null && dtNLContact.Rows[0]["Latitude1"].ToString() != "" && Convert.ToInt32(dtNLContact.Rows[0]["Latitude1"]) != 0)
                    {
                        if (dtNLContact.Rows[0]["Longitude1"] != null && dtNLContact.Rows[0]["Longitude1"].ToString() != "" && Convert.ToInt32(dtNLContact.Rows[0]["Longitude1"]) != 0)
                        {
                            string latitude = dtNLContact.Rows[0]["Latitude1"].ToString();
                            string longitude = dtNLContact.Rows[0]["Longitude1"].ToString();

                            lblLocation.Text = objCommon.GetAddressByLatitude_Longitude(latitude, longitude);
                        }
                    }
                }
                else
                {
                    lblLocation.Text = dtNLContact.Rows[0]["CurrentLocation"].ToString();
                }
                // Ends Here...

                objBus.SelectMobileAppAlerts(UserID, ContactID, true, C_UserID);

                string imageName = Convert.ToString(dtNLContact.Rows[0]["PhotoName"]);

                var TipsImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\DevicePhotos\\" + ProfileID + "\\" + imageName;
                if (File.Exists(TipsImageVirtualPath))
                {
                    btnCopyImg.Visible = true;

                    string ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/DevicePhotos/" + ProfileID + "/" + imageName;
                    int width = 0;
                    int height = 0;


                    using (FileStream fs = new FileStream(TipsImageVirtualPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            height = image.Height;
                            width = image.Width;
                        }
                    }

                    if (width > 350 && height > 250)
                    {
                        lblImg.Text = "<img src='" + ImgRootPath + "' Width='350' Height='250'  />";
                    }
                    else if (width > 350)
                    {
                        lblImg.Text = "<img src='" + ImgRootPath + "' Width='350' />";
                    }
                    else if (height > 250)
                    {
                        lblImg.Text = "<img src='" + ImgRootPath + "' Height='250' />";
                    }
                    else
                    {
                        lblImg.Text = "<img src='" + ImgRootPath + "'  />";
                    }
                }
                else
                {
                    btnCopyImg.Visible = false;
                    lblImg.Text = "";
                }


                if (imageName != string.Empty && imageName != null)
                {
                    hdnImgName.Value = imageName;
                    //getting image path 
                }


                ModalPopupExtender1.Show();
            }
            filldata();

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "ShowContactusDetails", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
    protected void grdNewsletercontacts_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            DataTable DtMobileAppAlerts = (DataTable)Session["DtMobileAppAlerts"];
            if (hdnsortdire.Value != "")
            {
                if (hdnsortdire.Value != SortExp)
                {
                    hdnsortdire.Value = SortExp;
                    SortDir = 0;
                    hdnsortcount.Value = "0";
                }
            }
            else
            {
                hdnsortdire.Value = SortExp;
            }
            DataView Dv = new DataView(DtMobileAppAlerts);
            if (SortDir == 0)
            {
                if (SortExp == "DateSent")
                {
                    Dv.Sort = "CREATED_DT ASC";
                }
                else if (SortExp == "Blocked")
                {
                    Dv.Sort = "Device_Blocked ASC";
                }
                else if (SortExp == "ReferenceID")
                {
                    Dv.Sort = "ReferenceID ASC";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "DateSent")
                {
                    Dv.Sort = "CREATED_DT desc";
                }
                else if (SortExp == "Blocked")
                {
                    Dv.Sort = "Device_Blocked desc";
                }
                else if (SortExp == "ReferenceID")
                {
                    Dv.Sort = "ReferenceID DESC";
                }
                hdnsortcount.Value = "0";
            }
            Session["DtMobileAppAlerts"] = Dv.ToTable();
            NewslettersCount = DtMobileAppAlerts.Rows.Count;
            grdNewsletercontacts.DataSource = Dv;
            grdNewsletercontacts.DataBind();


        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "grdNewsletercontacts_Sorting", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void cleardata()
    {
        lbldescription.Text = lblemail.Text = "";
        lblphone.Text = lblLocation.Text = "";
        lblheader.Text = lblfn.Text = lblImg.Text = "";
    }

    protected void GrdTips_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblchecked = e.Row.FindControl("lblchecked") as Label;
                if (lblchecked.Text == "False")
                {
                    e.Row.CssClass = "UnreadInquiry";
                }
                else
                {
                    e.Row.CssClass = "readInquiry";
                }
                Label lbldescription = e.Row.FindControl("lbldescription") as Label;
                //Label lblReply = e.Row.FindControl("lblReply") as Label;
                string[] data = lbldescription.Text.Split('|');
                lbldescription.Text = data[3].ToString();
                //if (data[2] != null && data[2] != "")
                //{
                //    // lblReply.Text = "<a href=\"mailto:" + data[2].ToString() + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                //    lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + data[2].ToString() + "')\" />";
                //}
                CheckBox headerchk = (CheckBox)GrdTips.HeaderRow.FindControl("chkSelectAllTips");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkTips");
                childchk.Attributes.Add("onclick", "javascript:SelectTipscheckboxes('" + headerchk.ClientID + "')");
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "GrdTips_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void GrdTips_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTips.PageIndex = e.NewPageIndex;
        hdnPageIndex_Tips.Value = Convert.ToString(GrdTips.PageIndex);
        dttips = (DataTable)Session["dttips"];
        GrdTips.DataSource = dttips;
        GrdTips.DataBind();
    }

    protected void GrdTips_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortDir = Convert.ToInt32(hdnsortcnt.Value);
            string SortExp = e.SortExpression.ToString();
            DataTable dttips = (DataTable)Session["dttips"];
            if (hdnsortdir.Value != "")
            {
                if (hdnsortdir.Value != SortExp)
                {
                    hdnsortdir.Value = SortExp;
                    SortDir = 0;
                    hdnsortcnt.Value = "0";
                }
            }
            else
            {
                hdnsortdir.Value = SortExp;
            }
            DataView Dvtips = new DataView(dttips);
            if (SortDir == 0)
            {
                if (SortExp == "DateSent")
                {
                    Dvtips.Sort = "CREATED_DT ASC";
                }
                else if (SortExp == "Blocked")
                {
                    Dvtips.Sort = "Device_Blocked ASC";
                }
                else if (SortExp == "ReferenceID")
                {
                    Dvtips.Sort = "ReferenceID ASC";
                }
                hdnsortcnt.Value = "1";
            }
            else
            {
                if (SortExp == "DateSent")
                {
                    Dvtips.Sort = "CREATED_DT desc";
                }
                else if (SortExp == "Blocked")
                {
                    Dvtips.Sort = "Device_Blocked desc";
                }
                else if (SortExp == "ReferenceID")
                {
                    Dvtips.Sort = "ReferenceID DESC";
                }
                hdnsortcnt.Value = "0";
            }

            Session["dttips"] = Dvtips.ToTable();
            TipsCount = dttips.Rows.Count;
            GrdTips.DataSource = Dvtips;
            GrdTips.DataBind();


        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "GrdTips_Sorting", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkTipdelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkdel = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnkdel.CommandArgument.ToString());
            objBus.SelectMobileTips(0, ContactID, false, C_UserID);
            lblmsg.Text = "<font size='3' color='green'>" + Resources.LabelMessages.MobileTip.ToString() + "<b></b><font>";
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkTipdelete_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    //Added for Check All in Messages and Tips 
    protected void ChkSelectAllMsgsCheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ChkSelectAllTipsCheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ChkMessagesCheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ChkTipsCheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int MessagesCount = 0;
            foreach (GridViewRow gvrow in grdNewsletercontacts.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkMessages");
                if (chkdelete.Checked)
                {
                    int messageID = Convert.ToInt32(grdNewsletercontacts.DataKeys[gvrow.RowIndex].Value);
                    USPDHUBBLL.BusinessBLL.DeleteMessages(messageID);
                    MessagesCount = MessagesCount + 1;
                }
            }
            foreach (GridViewRow gvrow in GrdTips.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkTips");
                if (chkdelete.Checked)
                {
                    int messageID = Convert.ToInt32(GrdTips.DataKeys[gvrow.RowIndex].Value);
                    USPDHUBBLL.BusinessBLL.DeleteMessages(messageID);
                    MessagesCount = MessagesCount + 1;
                }
            }
            foreach (GridViewRow gvrow in grdPrivateCallHistory.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkPrivateCalls");
                if (chkdelete.Checked)
                {
                    int historyid = Convert.ToInt32(grdPrivateCallHistory.DataKeys[gvrow.RowIndex].Value);
                    objBus.DeletePrivateCallHistory(historyid);
                    MessagesCount = MessagesCount + 1;
                }
            }
            if (MessagesCount > 0)
            {
                lblmsg.Text = "<font size='3' color='green'>" + Resources.LabelMessages.DeleteMessagesandTips.ToString() + "<font>";
            }
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "btnDelete_Click(ALL)", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnBlockUsers_Click(object sender, EventArgs e)
    {
        try
        {
            int totalBlockedCount = 0;
            int updatedCount = 0;

            /*** Contact Us - Messages ***/
            foreach (GridViewRow gvrow in grdNewsletercontacts.Rows)
            {
                CheckBox chkblock = (CheckBox)gvrow.FindControl("chkMessages");
                if (chkblock.Checked)
                {
                    int messageID = Convert.ToInt32(grdNewsletercontacts.DataKeys[gvrow.RowIndex].Value);
                    int updateCount = objBus.BlockUnBlockMessageSenders(messageID, true, C_UserID);
                    totalBlockedCount += 1;
                    if (updateCount > 0)
                        updatedCount += 1;
                }
            }

            /**** Tips - Messages ***/
            foreach (GridViewRow gvrow in GrdTips.Rows)
            {
                CheckBox chkblock = (CheckBox)gvrow.FindControl("chkTips");
                if (chkblock.Checked)
                {
                    int messageID = Convert.ToInt32(GrdTips.DataKeys[gvrow.RowIndex].Value);
                    int updateCount = objBus.BlockUnBlockMessageSenders(messageID, true, C_UserID);
                    totalBlockedCount += 1;
                    if (updateCount > 0)
                        updatedCount += 1;
                }
            }
            string msg = "<font size='2' color='green'>" + Resources.LabelMessages.BlockedAllSenders.ToString() + "<font>";
            if (updatedCount == 0)
                msg = "<font size='2' color='red'>" + Resources.LabelMessages.BlockedSendersFailed.ToString() + "<font>";
            else if (totalBlockedCount != updatedCount)
                msg = "<font size='2' color='green'>" + Resources.LabelMessages.BlockedPartialSenders.ToString() + "<font>";
            lblmsg.Text = msg;
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "btnBlockUsers_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnMsgs_Click(object sender, EventArgs e)
    {
        filldata();
    }

    protected void btnInquiries_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/InquiryAlerts.aspx"));
    }


    protected void btnReply_OnClick(object sender, EventArgs e)
    {
        try
        {
            string command = "";
            if (RBNone.Checked)
            { command = "mailto:" + hdnSelectedContactMailID.Value.ToString() + "?body=" + ""; }
            else
            {
                command = "mailto:" + hdnSelectedContactMailID.Value.ToString() + "?body=" + rbCList.SelectedValue.ToString();
            }
            Process.Start(command);
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "btnReply_OnClick", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkCannedMessage_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageCannedMessage.aspx?PageName=Tips"));
    }

    protected void rbCList_OnLoad(object sender, EventArgs e)
    {

    }
    protected void btnclosepopup_Click(object sender, EventArgs e)
    {
        ModalPopupExtender2.Hide();
        filldata();
    }
    protected void grdPrivateCallHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPrivateCallHistory.PageIndex = e.NewPageIndex;
        hdnPageIndex_PrivateCalls.Value = Convert.ToString(grdPrivateCallHistory.PageIndex);
        dtPrivatecCalls = (DataTable)Session["dtPrivateCalls"];
        grdPrivateCallHistory.DataSource = dtPrivatecCalls;
        grdPrivateCallHistory.DataBind();

    }
    protected void grdPrivateCallHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblchecked = e.Row.FindControl("lblprivatecallflag") as Label;
                if (lblchecked.Text == "False")
                {
                    e.Row.CssClass = "UnreadInquiry";
                }
                else
                {
                    e.Row.CssClass = "readInquiry";
                }
                //dtPublicCalls = objBus.GetMobilePublicCallsHistory(true, 0, ProfileID);
                Label lbldescription = e.Row.FindControl("lblPCallMessage") as Label;
                //Label lblReply = e.Row.FindControl("lblReply") as Label;
                string[] data = lbldescription.Text.Split('|');
                lbldescription.Text = data[0].ToString();

                //lblReply.Text = "<a href=\"mailto:" + dtPublicCalls.Rows[0]["ContactEmail"] + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                //lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + dtPublicCalls.Rows[0]["ContactEmail"] + "')\" />";

                CheckBox headerchk = (CheckBox)grdPrivateCallHistory.HeaderRow.FindControl("chkSelectAllPrivateCalls");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkPrivateCalls");
                childchk.Attributes.Add("onclick", "javascript:SelectallPrivatecheckboxes('" + headerchk.ClientID + "')");

            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "GrdTips_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void grdPrivateCallHistory_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            SortDir = Convert.ToInt32(hdnPrivateCallSortCount.Value);
            string SortExp = e.SortExpression.ToString();
            DataTable dtPrivateCallshistory = (DataTable)Session["dtPrivateCalls"];
            if (hdnPrivateCallSortCount.Value != "")
            {
                if (hdnPrivateCallSortDir.Value != SortExp)
                {
                    hdnPrivateCallSortDir.Value = SortExp;
                    SortDir = 0;
                    hdnPrivateCallSortCount.Value = "0";
                }
            }
            else
            {
                hdnPrivateCallSortDir.Value = SortExp;
            }
            DataView Dvprivatecall = new DataView(dtPrivateCallshistory);
            if (SortDir == 0)
            {
                if (SortExp == "DateSent")
                {
                    Dvprivatecall.Sort = "CreatedDate ASC";
                }
                else if (SortExp == "ReferenceID")
                {
                    Dvprivatecall.Sort = "ReferenceID ASC";
                }
                hdnPrivateCallSortCount.Value = "1";
            }
            else
            {
                if (SortExp == "DateSent")
                {
                    Dvprivatecall.Sort = "CreatedDate desc";
                }
                else if (SortExp == "ReferenceID")
                {
                    Dvprivatecall.Sort = "ReferenceID DESC";
                }
                hdnPrivateCallSortCount.Value = "0";
            }

            Session["dtPrivateCalls"] = Dvprivatecall.ToTable();
            PrivateCallsCount = dtPrivateCallshistory.Rows.Count;
            grdPrivateCallHistory.DataSource = Dvprivatecall;
            grdPrivateCallHistory.DataBind();

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "grdPublicCallHistory_Sorting", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void chkPrivateCallsCheckedChanged(object sender, EventArgs e)
    { }

    protected void lnkPrivateCall_Click(object sender, EventArgs e)
    {
        StoreSelectedValues();
        LinkButton lnkPrivateCallMsg = sender as LinkButton;
        string callAddonHistoyID = lnkPrivateCallMsg.CommandArgument.ToString();
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ViewMessageDetails.aspx?BT=" + EncryptDecrypt.DESEncrypt(ButtonTypes.PrivateCall) + "&MHID=" + EncryptDecrypt.DESEncrypt(callAddonHistoyID)));
        //showPopupPrivateCall(callAddonHistoyID);
    }
    protected void lnkPrivateCalldelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkdel = sender as LinkButton;
            int historyid = Convert.ToInt32(lnkdel.CommandArgument.ToString());
            objBus.DeletePrivateCallHistory(historyid);
            lblmsg.Text = "<font size='3' color='green'>" + Resources.LabelMessages.PrivateCallHistoryDeleteMsg.ToString() + "<b></b><font>";
            filldata();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkPrivateCalldelete_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void showPopupPrivateCall(int historyID)
    {

        trPrivateImg.Visible = false;
        lblPrivatelocation.Text = "";
        lblPrivateimagetext.Visible = true;
        lblPrivatelocationtext.Visible = true;
        DataTable dt = new DataTable("PrivateCallHistory");
        dt = objBus.GetMobilePrivateCallsHistory(false, historyID, ProfileID, true);
        if (dt != null && dt.Rows.Count > 0)
        {
            lblPrivatetitle.Text = dt.Rows[0]["Title"].ToString();
            lblprivateCallMsg.Text = dt.Rows[0]["CustomPredefinedMessage"].ToString();
            lblPrivateEmail.Text = dt.Rows[0]["ContactEmail"].ToString();
            lblPrivateNumber.Text = dt.Rows[0]["PhoneInformation"].ToString();
            lblPrivateName.Text = dt.Rows[0]["ContactName"].ToString();
            string imageName = Convert.ToString(dt.Rows[0]["ImageName"]).Trim();

            if (imageName.Trim() != string.Empty)
            {

                string ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "/PrivateCallDirectoryTapImages/" + ProfileID + "/" + imageName;
                int width = 0;
                int height = 0;


                if (File.Exists(ImageVirtualPath))
                {
                    trPrivateImg.Visible = true;
                    //btncopyImgtogalry.Visible = true;
                    string ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/PrivatecCallDirectoryTapImages/" + ProfileID + "/" + imageName;


                    using (FileStream fs = new FileStream(ImageVirtualPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            height = image.Height;
                            width = image.Width;
                        }
                    }

                    if (width > 350 && height > 250)
                    {
                        imgPrivateImage.Text = "<img src='" + ImgRootPath + "' Width='350' Height='250'  />";
                    }
                    else if (width > 350)
                    {
                        imgPrivateImage.Text = "<img src='" + ImgRootPath + "' Width='350' />";
                    }
                    else if (height > 250)
                    {
                        imgPrivateImage.Text = "<img src='" + ImgRootPath + "' Height='250' />";
                    }
                    else
                    {
                        imgPrivateImage.Text = "<img src='" + ImgRootPath + "'  />";
                    }
                }
                else
                {
                    btncopyImgtogalry.Visible = false;
                    lblImg.Text = "";
                }


                if (imageName != string.Empty && imageName != null)
                {
                    hdnImgName.Value = imageName;
                    //getting image path 
                }

            }
            else
                btncopyImgtogalry.Visible = false;
            lblimagetext.Visible = false;

            if (Convert.ToString(dt.Rows[0]["CurrentLocation"]) == string.Empty)
            {
                if (dt.Rows[0]["GPS_Details"] != null && dt.Rows[0]["GPS_Details"].ToString().Trim() != "")
                {
                    string[] address = dt.Rows[0]["GPS_Details"].ToString().Split(',');
                    string latitude = address[0];
                    string longitude = address[1];

                    lblPrivatelocation.Text = objCommon.GetAddressByLatitude_Longitude(latitude, longitude);

                }
            }
            else
            {
                lblPrivatelocation.Text = dt.Rows[0]["CurrentLocation"].ToString();
            }


            ModalPopupExtender4.Show();
            filldata();
        }
    }

    public void checkHavingMessagesButton()
    {
        DataTable dtCustomModules = objBus.DashboardIcons(UserID);
        if (dtCustomModules.Rows.Count > 0)
        {
            DataRow[] drContactUs = dtCustomModules.Select(string.Format("ButtonType ='{0}' ", ButtonTypes.ContactUs));
            DataRow[] drTips = dtCustomModules.Select(string.Format("ButtonType ='{0}' ", ButtonTypes.Tips));
            DataRow[] drPrivateCall = dtCustomModules.Select(string.Format("ButtonType ='{0}' ", ButtonTypes.PrivateCall));
            if (drContactUs != null)
                isHavingContactButton = true;
            else
                isHavingContactButton = false;
            if (drTips != null)
                isHavingTipsButton = true;
            else
                isHavingTipsButton = false;
            if (drPrivateCall != null)
                isHavingPrivateCallButton = true;
            else
                isHavingPrivateCallButton = false;
        }
    }
    public void getArchiveType()
    {
        archiveContactType = Convert.ToInt32(hdnShowingContact.Value);
        archivePriveCallType = Convert.ToInt32(hdnShowingPrivateMsg.Value);
        archiveTipType = Convert.ToInt32(hdnShowingTips.Value);
    }
    string strNormalArchivePath = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";//current_h
    string strNormalCurrentPath = "<img src='../../Images/Dashboard/current.gif' title='current' border='0'/>";
    string strHighlightArchivePath = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
    string strHighlightCurrentPath = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";

    protected void lnkCurrent_Click(object sender, EventArgs e)
    {
        try
        {
            hdnShowingContact.Value = "0"; //0 means Current, 1 means Archive
            heighligtCurrentAndArchive(lnkCurrentForContacts, lnkArchiveForContacts, 0); //flag 0 means highlight current
            this.grdNewsletercontacts.Columns[9].Visible = true; //reply
            this.grdNewsletercontacts.Columns[8].Visible = true; //archive
            this.grdNewsletercontacts.Columns[10].Visible = false; //current
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkCurrent_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkGetArchive_Click(object sender, EventArgs e)
    {
        try
        {
            heighligtCurrentAndArchive(lnkCurrentForContacts, lnkArchiveForContacts, 1);
            hdnShowingContact.Value = "1";
            this.grdNewsletercontacts.Columns[9].Visible = false; //reply
            this.grdNewsletercontacts.Columns[8].Visible = false; //archive
            this.grdNewsletercontacts.Columns[10].Visible = true; //current
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkGetArchive_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkCurrentForTips_Click(object sender, EventArgs e)
    {
        try
        {
            heighligtCurrentAndArchive(lnkCurrentForTips, lnkArchiveForTips, 0);
            hdnShowingTips.Value = "0";

            this.GrdTips.Columns[9].Visible = true; //reply
            this.GrdTips.Columns[8].Visible = true; //archive
            this.GrdTips.Columns[10].Visible = false; //current
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkCurrentForTips_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkArchiveForTips_Click(object sender, EventArgs e)
    {
        try
        {
            heighligtCurrentAndArchive(lnkCurrentForTips, lnkArchiveForTips, 1);
            hdnShowingTips.Value = "1";
            this.GrdTips.Columns[9].Visible = false; //reply
            this.GrdTips.Columns[8].Visible = false; //archive
            this.GrdTips.Columns[10].Visible = true; //current
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkArchiveForTips_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkCurrentForPrivateMsg_Click(object sender, EventArgs e)
    {
        try
        {
            heighligtCurrentAndArchive(lnkCurrentForPrivateMsg, lnkArchiveForPrivateMsg, 0);
            hdnShowingPrivateMsg.Value = "0";
            this.grdPrivateCallHistory.Columns[11].Visible = true; //reply
            this.grdPrivateCallHistory.Columns[10].Visible = true; //archive
            this.grdPrivateCallHistory.Columns[12].Visible = false; //current
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkCurrentForPrivateMsg_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkArchiveForPrivateMsg_Click(object sender, EventArgs e)
    {
        try
        {
            heighligtCurrentAndArchive(lnkCurrentForPrivateMsg, lnkArchiveForPrivateMsg, 1);
            hdnShowingPrivateMsg.Value = "1";

            this.grdPrivateCallHistory.Columns[11].Visible = false; //reply
            this.grdPrivateCallHistory.Columns[10].Visible = false; //archive
            this.grdPrivateCallHistory.Columns[12].Visible = true; //current
            filldata();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "lnkArchiveForPrivateMsg_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    private void BindMessageTitles()
    {
        lblContactUs.Text = objCommon.GetTabNameByType(UserID, "Contact");
        lblTipsTitle.Text = objCommon.GetTabNameByType(UserID, "Tips");
        //lblPrivateCallButtonTitle.Text = objCommon.GetTabNameByType(UserID, ButtonTypes.PrivateCall);
    }
    /// <summary>
    /// this method is used to highlight archive and current tabs
    /// </summary>
    /// <param name="lnkCurrent"></param>
    /// <param name="lnkArchive"></param>
    /// <param name="flag"></param>
    /// <author>vijayasai</author>
    public void heighligtCurrentAndArchive(LinkButton lnkCurrent, LinkButton lnkArchive, int flag)
    {
        if (flag.Equals(0)) //0 means highlighlight current
        {
            lnkCurrent.Text = strHighlightCurrentPath;
            lnkArchive.Text = strNormalArchivePath;
        }
        else
        {
            lnkCurrent.Text = strNormalCurrentPath;
            lnkArchive.Text = strHighlightArchivePath;
        }
    }

    public void GetMessagesCount()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objBus.GetModuleItemsCount(ProfileID, UserID);
            if (dt.Rows.Count > 0)
                hdnMessagesCount.Value = dt.Rows[0]["CONCTACTMESSAGE_COUNT"].ToString() + "|" + dt.Rows[0]["TIPS_COUNT"].ToString() + "|" + dt.Rows[0]["PRIVATEMESSAGE_COUNT"].ToString();
            else
                hdnMessagesCount.Value = "0|0|0";
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "GetMessagesCount()", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void ddlPageSize_Message_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnPageSize_Messages.Value = PageSizes_Messages.SelectedPage;
        hdnPageSize_Tips.Value = PageSize_Tips.SelectedPage;
        hdnPageSize_PrivateCalls.Value = PageSize_PrivateCall.SelectedPage;

        SaveUserSettings();
        grdNewsletercontacts.PageSize = Convert.ToInt32(hdnPageSize_Messages.Value);
        grdNewsletercontacts.DataSource = (DataTable)Session["DtMobileAppAlerts"];
        grdNewsletercontacts.DataBind();

        GrdTips.PageSize = Convert.ToInt32(hdnPageSize_Tips.Value);
        GrdTips.DataSource = (DataTable)Session["dttips"];
        GrdTips.DataBind();

        grdPrivateCallHistory.PageSize = Convert.ToInt32(hdnPageSize_PrivateCalls.Value);
        grdPrivateCallHistory.DataSource = (DataTable)Session["dtPrivateCalls"];
        grdPrivateCallHistory.DataBind();
    }

    protected void ddlPageSize_Tips_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnPageSize_Messages.Value = PageSizes_Messages.SelectedPage;
        hdnPageSize_Tips.Value = PageSize_Tips.SelectedPage;
        hdnPageSize_PrivateCalls.Value = PageSize_PrivateCall.SelectedPage;
        SaveUserSettings();
        grdNewsletercontacts.PageSize = Convert.ToInt32(hdnPageSize_Messages.Value);
        grdNewsletercontacts.DataSource = (DataTable)Session["DtMobileAppAlerts"];
        grdNewsletercontacts.DataBind();

        GrdTips.PageSize = Convert.ToInt32(hdnPageSize_Tips.Value);
        GrdTips.DataSource = (DataTable)Session["dttips"];
        GrdTips.DataBind();

        grdPrivateCallHistory.PageSize = Convert.ToInt32(hdnPageSize_PrivateCalls.Value);
        grdPrivateCallHistory.DataSource = (DataTable)Session["dtPrivateCalls"];
        grdPrivateCallHistory.DataBind();
    }

    protected void ddlPageSize_PrivateCall_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnPageSize_Messages.Value = PageSizes_Messages.SelectedPage;
        hdnPageSize_Tips.Value = PageSize_Tips.SelectedPage;
        hdnPageSize_PrivateCalls.Value = PageSize_PrivateCall.SelectedPage;
        SaveUserSettings();
        grdNewsletercontacts.PageSize = Convert.ToInt32(hdnPageSize_Messages.Value);
        grdNewsletercontacts.DataSource = (DataTable)Session["DtMobileAppAlerts"];
        grdNewsletercontacts.DataBind();

        GrdTips.PageSize = Convert.ToInt32(hdnPageSize_Tips.Value);
        GrdTips.DataSource = (DataTable)Session["dttips"];
        GrdTips.DataBind();

        grdPrivateCallHistory.PageSize = Convert.ToInt32(hdnPageSize_PrivateCalls.Value);
        grdPrivateCallHistory.DataSource = (DataTable)Session["dtPrivateCalls"];
        grdPrivateCallHistory.DataBind();
    }

    private void SaveUserSettings()
    {
        try
        {
            string PageSizes = hdnPageSize_Messages.Value + "|" + hdnPageSize_Tips.Value + "|" + hdnPageSize_PrivateCalls.Value;
            string XMLdata = "<MobileAppAlerts MessagePageSize='" + PageSizes + "'  /> ";
            var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "MobileAppAlerts", 0);
            if (dtDisplayReadFirst.Rows.Count == 0)
                objBus.UserCustomizeSettings(0, ProfileID, UserID, "MobileAppAlerts", XMLdata, 0);
            else
                objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, "MobileAppAlerts", XMLdata, 0);
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "SaveUserSettings()", ex.Message,
                   Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    public void GetSavedUserData()
    {
        string XMLValue = string.Empty;

        DataTable dtDisplayReadFirst = new DataTable();
        dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "MobileAppAlerts", 0);
        if (dtDisplayReadFirst.Rows.Count > 0)
        {
            XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(XMLValue);
            if (XMLValue != "")
            {
                if (xmldoc.SelectSingleNode("MobileAppAlerts/@MessagePageSize") != null)
                {
                    string values = xmldoc.SelectSingleNode("MobileAppAlerts/@MessagePageSize").Value;
                    string[] arrPageSize = values.Split('|');
                    hdnPageSize_Messages.Value = arrPageSize[0];
                    hdnPageSize_Tips.Value = arrPageSize[1];
                    hdnPageSize_PrivateCalls.Value = arrPageSize[2];

                    PageSizes_Messages.SelectedPage = hdnPageSize_Messages.Value;
                    PageSize_Tips.SelectedPage = hdnPageSize_Tips.Value;
                    PageSize_PrivateCall.SelectedPage = hdnPageSize_PrivateCalls.Value;
                }
            }
        }
    }
    DataTable dtSelectedValue;
    public void StoreSelectedValues()
    {
        try
        {
            if (dtSelectedValue == null)
            {
                dtSelectedValue = new DataTable();
                dtSelectedValue.Columns.Add("Contact_Archive_Flag", typeof(string));
                dtSelectedValue.Columns.Add("Contact_GridIndex", typeof(string));



                dtSelectedValue.Columns.Add("Tips_Archive_Flag", typeof(string));
                dtSelectedValue.Columns.Add("Tips_GridIndex", typeof(string));

                dtSelectedValue.Columns.Add("PrivateCall_Archive_Flag", typeof(string));
                dtSelectedValue.Columns.Add("PrivateCall_GridIndex", typeof(string));
            }//hdnShowingContact
            dtSelectedValue.Rows.Add(hdnShowingContact.Value, hdnPageIndex_Contact.Value, hdnShowingTips.Value, hdnPageIndex_Tips.Value, hdnShowingPrivateMsg.Value, hdnPageIndex_PrivateCalls.Value);

            Session["SelectedValues"] = dtSelectedValue;
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "StoreSelectedValues()", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    public void GetSelectedValues() 
    {
        try
        {
            DataTable PrevData = (DataTable)Session["SelectedValues"];
            hdnShowingContact.Value = Convert.ToString(PrevData.Rows[0]["Contact_Archive_Flag"]);
            hdnShowingTips.Value = Convert.ToString(PrevData.Rows[0]["Tips_Archive_Flag"]);
            hdnShowingPrivateMsg.Value = Convert.ToString(PrevData.Rows[0]["PrivateCall_Archive_Flag"]);

            hdnPageIndex_Contact.Value = Convert.ToString(PrevData.Rows[0]["Contact_GridIndex"]);
            hdnPageIndex_Tips.Value = Convert.ToString(PrevData.Rows[0]["Tips_GridIndex"]);
            hdnPageIndex_PrivateCalls.Value = Convert.ToString(PrevData.Rows[0]["PrivateCall_GridIndex"]);
            Session["SelectedValues"] = null;

            if (hdnShowingContact.Value.Equals("1")) 
            {
                heighligtCurrentAndArchive(lnkCurrentForContacts, lnkArchiveForContacts, 1);
            }
            if (hdnShowingTips.Value.Equals("1"))
            {
                heighligtCurrentAndArchive(lnkCurrentForTips, lnkArchiveForTips, 1);
            }
            if (hdnShowingPrivateMsg.Value.Equals("1"))
            {
                heighligtCurrentAndArchive(lnkCurrentForPrivateMsg, lnkArchiveForPrivateMsg, 1);
            }
            filldata();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "MobileAppAlerts.aspx.cs", "GetSelectedValues()", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
