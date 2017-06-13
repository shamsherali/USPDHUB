using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml;
using System.Drawing;
using Winnovative.PdfCreator;
using Winnovative.HtmlToPdfClient;
using System.Web.UI.DataVisualization.Charting;


namespace USPDHUB.Business.MyAccount
{
    public partial class SmartConnectMessage : BaseWeb
    {

        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;
        public int UserModuleID = 0;
        public int SortDir = 0;
        public int TotalMessages;
        public string isBlocked;
        public string RootPath = "";
        public string DomainName = "";
        DropDownList ddlPageSize;
        AddOnBLL objAddOns = new AddOnBLL();
        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                // ** Get Domain Name ** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();

                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                lblmess.Text = "";
                if (Session["CustomModuleID"] != null)
                    UserModuleID = Convert.ToInt32(Session["CustomModuleID"].ToString());
                if (objBus.CheckModulePermission(WebConstants.Purchase_PublicCallAddOns, ProfileID))
                {
                    btnBlockUsers.Visible = true;
                }
                DisplayTabName(UserID);
                if (!IsPostBack)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageMessageReceipt");
                        if (hdnPermissionType.Value == "A")
                        {
                            UpdatePanel2.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=3>" + Resources.LabelMessages.SmartConnectPermission + "</font>";
                            return;
                        }
                    }
                    //ends here
                    string pageComesFrom = Convert.ToString(Request.UrlReferrer);
                    if (pageComesFrom.Contains("ViewMessageDetails.aspx") && Session["searchedKeywords"] != null)
                        showPrevSearchDetails();
                    else
                    {
                        //  Hdn control for Sorting
                        hdnsortdire.Value = "";
                        hdnsortcount.Value = "0";
                        hdnPubicCallSortDir.Value = "";
                        hdnPubicCallSortCount.Value = "0";
                        BindSmartConnectCategories();
                        BindDisplayReadFirst();
                        DataTable dtCurrentPublicCalls = new DataTable();
                        dtCurrentPublicCalls = objBus.GetMobilePublicCallsHistory(true, 0, ProfileID, false, false);
                        DataTable dtArchivePublicCalls = objBus.GetMobilePublicCallsHistory(true, 0, ProfileID, false, true);
                        dtCurrentPublicCalls.Merge(dtArchivePublicCalls.Copy());
                        TotalMessages = dtCurrentPublicCalls.Rows.Count;
                        if (TotalMessages == 0)
                        {
                            UpdatePanel2.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font size='3' color='green'>" + Resources.LabelMessages.NoSmartConnectMessages.ToString() + "<b></b><font>";

                        }
                        else
                        {
                            Session["ListSearch"] = null;
                            Session["GraphSearch"] = null;
                            if (chkDisplayUnread.Checked)
                            {
                                DisplayReadData();
                            }
                            else
                            {
                                GetSmartConnectMessages();
                            }
                        }
                    }

                }
                //ShowCurrentArchive();
                ddlPageSize = (DropDownList)PageSizes.FindControl("ddlPageSize");
                ddlPageSize.AutoPostBack = true;
                ddlPageSize.SelectedIndexChanged += ddlPageSize_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "Page_Load", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void BindDisplayReadFirst()
        {
            try
            {
                DataTable dtDisplayReadFirst = new DataTable();
                dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "SmartConnectMessage");
                hdnDisplayRead.Value = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(hdnDisplayRead.Value);
                if (hdnDisplayRead.Value.Trim() != "")
                {
                    if (xmldoc.SelectSingleNode("SmartConnectMessage/@IsChecked").Value.ToString() == "True")
                        chkDisplayUnread.Checked = true;
                    if (xmldoc.SelectSingleNode("SmartConnectMessage/@IsChecked").Value.ToString() == "False")
                        chkDisplayUnread.Checked = false;
                    if (!string.IsNullOrEmpty( xmldoc.SelectSingleNode("SmartConnectMessage/@MessagePageSize").Value.ToString()))
                    {
                        PageSizes.SelectedPage = xmldoc.SelectSingleNode("SmartConnectMessage/@MessagePageSize").Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "BindDisplayReadFirst", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void DisplayTabName(int UserID)
        {
            DataTable dtCustomModules = new DataTable();
            dtCustomModules = objBus.DashboardIcons(UserID);
            DataView dvCustomModules = new DataView(dtCustomModules);
            dvCustomModules.RowFilter = "ButtonType='PublicCallAddOns'";
            dtCustomModules = dvCustomModules.ToTable();
            lblTitle.Text = "SmartConnect (" + dtCustomModules.Rows[0]["TabName"].ToString() + ") - Messages";
            lblTitle1.Text = "SmartConnect (" + dtCustomModules.Rows[0]["TabName"].ToString() + ") - Messages";
        }
        private void GetSmartConnectMessages(int grdPageIndex = 0)
        {
            try
            {
                hdnCommandArg.Value = "";
                //int CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

                DataTable dtPublicCalls = new DataTable();
                DataTable dtGraph = new DataTable();
                if (hdnarchive.Value == "Archive")
                {
                    dtPublicCalls = objBus.GetMobilePublicCallsHistory(true, 0, ProfileID, false, true);
                    dtGraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, true);
                }
                else
                {
                    dtPublicCalls = objBus.GetMobilePublicCallsHistory(true, 0, ProfileID, false, false);
                    dtGraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, false);
                }

                Session["dtPublicCalls"] = dtPublicCalls;
                ViewState["dtPublicCalls"] = dtPublicCalls;
                showCurrArchives(true);
                //if (TotalMessages == 0)
                //    showCurrArchives(false);
                BindMessagesPageSize();
                grdPublicCallHistory.PageIndex = grdPageIndex;
                grdPublicCallHistory.DataSource = dtPublicCalls;
                grdPublicCallHistory.DataBind();

                Session["PrintChart"] = dtGraph;
                BindChart(dtGraph);

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "GetSmartConnectMessages", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void showCurrArchives(bool Flag)
        {
            lnkGetArchive.Visible = Flag;
            lnkCurrent.Visible = Flag;
        }
        private string BindSmartConnectCategories()
        {
            string returnCategoryName = "";
            string retrunCategoryID = "";
            try
            {
                DataTable dtCategories = objBus.GetSmartConnectCategoriesList(ProfileID, UserModuleID);
                for (int i = 0; i < dtCategories.Rows.Count; i++)
                {
                    returnCategoryName = returnCategoryName + dtCategories.Rows[i]["CategoryName"] + ",";
                    retrunCategoryID = retrunCategoryID + dtCategories.Rows[i]["CategoryID"] + ",";
                }

                if (returnCategoryName.EndsWith(","))
                {
                    returnCategoryName = returnCategoryName.Remove(returnCategoryName.Length - 1);
                }
                if (retrunCategoryID.EndsWith(","))
                {
                    retrunCategoryID = retrunCategoryID.Remove(retrunCategoryID.Length - 1);
                }
                hdnCategory.Value = returnCategoryName;
                hdnCategoryID.Value = retrunCategoryID;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>GetCategory()</script>", false);

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "BindSmartConnectCategories", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnCategoryName;
        }

        protected void grdPublicCallHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPublicCallHistory.PageIndex = e.NewPageIndex;
            hdnGvPageIndex.Value = Convert.ToString(grdPublicCallHistory.PageIndex);
            if (Session["ListSearch"] != null)
                grdPublicCallHistory.DataSource = Session["ListSearch"];
            else
                grdPublicCallHistory.DataSource = ViewState["dtPublicCalls"];
            grdPublicCallHistory.DataBind();
        }
        protected void grdPublicCallHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblchecked = e.Row.FindControl("lblpubliccallflag") as Label;
                    if (lblchecked.Text == "False")
                    {
                        e.Row.CssClass = "UnreadInquiry";
                    }
                    else
                    {
                        e.Row.CssClass = "readInquiry";
                    }

                    LinkButton lbldescription = e.Row.FindControl("lnkPublicCall") as LinkButton;

                    string[] data = lbldescription.Text.Split('|');
                    lbldescription.Text = data[0].ToString();
                    CheckBox headerchk = (CheckBox)grdPublicCallHistory.HeaderRow.FindControl("chkSelectAllPublicCalls");
                    CheckBox childchk = (CheckBox)e.Row.FindControl("chkPublicCalls");
                    childchk.Attributes.Add("onclick", "javascript:SelectPubliccheckboxes('" + headerchk.ClientID + "')");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "grdPublicCallHistory_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdPublicCallHistory_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnPubicCallSortCount.Value);
                string SortExp = e.SortExpression.ToString();
                DataTable dtPublicCallshistory = new DataTable();
                if (Session["ListSearch"] != null)
                {
                    dtPublicCallshistory = (DataTable)Session["ListSearch"];
                }
                else
                {
                    dtPublicCallshistory = (DataTable)ViewState["dtPublicCalls"];
                }

                if (hdnPubicCallSortDir.Value != "")
                {
                    if (hdnPubicCallSortDir.Value != SortExp)
                    {
                        hdnPubicCallSortDir.Value = SortExp;
                        SortDir = 0;
                        hdnPubicCallSortCount.Value = "0";
                    }
                }
                else
                {
                    hdnPubicCallSortDir.Value = SortExp;
                }
                DataView Dvpubliccall = DoMessagesSorting(dtPublicCallshistory, SortDir, SortExp, "");
                if (Session["ListSearch"] == null)
                    ViewState["dtPublicCalls"] = Dvpubliccall.ToTable();
                grdPublicCallHistory.DataSource = Dvpubliccall;
                grdPublicCallHistory.DataBind();

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "grdPublicCallHistory_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private DataView DoMessagesSorting(DataTable dtPublicCallshistory, int sortDir, string sortExp, string sortFrom)
        {
            DataView Dvpubliccall = new DataView(dtPublicCallshistory);
            if (sortDir == 0)
            {
                if (sortExp == "DateSent")
                {
                    Dvpubliccall.Sort = "CreatedDate ASC";
                }
                else if (sortExp == "ReferID")
                {
                    Dvpubliccall.Sort = "ReferenceID ASC";
                }
                if (sortFrom != "Export")
                    hdnPubicCallSortCount.Value = "1";
            }
            else
            {
                if (sortExp == "DateSent")
                {
                    Dvpubliccall.Sort = "CreatedDate DESC";
                }
                else if (sortExp == "ReferID")
                {
                    Dvpubliccall.Sort = "ReferenceID DESC";
                }
                if (sortFrom != "Export")
                    hdnPubicCallSortCount.Value = "0";
            }
            return Dvpubliccall;
        }
        protected void chkPublicCalls_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row1 in grdPublicCallHistory.Rows)
                {
                    if (((CheckBox)row1.FindControl("chkPublicCalls")).Checked)
                    {
                        hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkPublicCall")).CommandArgument);

                    }
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "chkPublicCalls_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void lnkCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
                lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
                hdnCommandArg.Value = "";
                hdnRowIndex.Value = "";
                hdnarchive.Value = "NoArchive";
                Session["ViewBGrid"] = null;
                MakeDefaultValues();
                GetSmartConnectMessages();

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkCurrent_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void lnkGetArchive_Click(object sender, EventArgs e)
        {
            try
            {
                lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
                lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
                hdnCommandArg.Value = "";
                hdnRowIndex.Value = "";
                hdnarchive.Value = "Archive";
                Session["ViewBGrid"] = "Archive";
                MakeDefaultValues();
                GetSmartConnectMessages();

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkGetArchive_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void lnkArchive_Click(object sender, EventArgs e)
        {

            bool ArchiveFlag = true;
            LinkButton lnkCurrArchive = sender as LinkButton;
            string lnkText = lnkCurrArchive.Text;
            if (lnkText.Contains("Current"))
            {
                ArchiveFlag = false;
            }
            else
            {
                ArchiveFlag = true;
            }
            //Identify CheckBox is checked or not
            foreach (GridViewRow row in grdPublicCallHistory.Rows)
            {
                if (((CheckBox)row.FindControl("chkPublicCalls")).Checked)
                {
                    int ArchiveID = Convert.ToInt32(((LinkButton)(row.FindControl("lnkPublicCall"))).CommandArgument);
                    objCommon.ArchiveSelectedNewsletter(ArchiveID, ArchiveFlag, "SmartConnect", C_UserID);
                }
            }

            if (ArchiveFlag == false)
                lblmess.Text = Resources.LabelMessages.ArchiveCurrentSuccess.Replace("#type#", "selected message");
            else
                lblmess.Text = Resources.LabelMessages.ArchiveSuccess.Replace("#type#", "selected message");
            GetSmartConnectMessages();

        }
        protected void lnkView_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton lnk = sender as LinkButton;
                string messageID = lnk.CommandArgument.ToString();
                hdnSelectedMsgHistoryId.Value = messageID;
                StoreSearchedValues();
                if (hdnCommandArg.Value != "")
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ViewMessageDetails.aspx?BT=" + EncryptDecrypt.DESEncrypt(ButtonTypes.SmartConnect) + "&MHID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value)));
                if (messageID != "")
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ViewMessageDetails.aspx?BT=" + EncryptDecrypt.DESEncrypt(ButtonTypes.SmartConnect) + "&MHID=" + EncryptDecrypt.DESEncrypt(messageID)));

            }

            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkView_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                GetSmartConnectMessages();
                DataTable dtexportexcel = new DataTable();
                dtexportexcel = (DataTable)Session["dtPublicCalls"];
                if (Session["ListSearch"] != null)
                {
                    dtexportexcel = (DataTable)Session["ListSearch"];
                }
                if (Session["GraphSearch"] != null)
                {
                    DataTable dtGraphSearch = (DataTable)Session["GraphSearch"];
                    chartAppUsage.Series.Clear();
                    chartAppUsage.Titles.Clear();
                    BindChart(dtGraphSearch);
                }
                if (chkArchiveExport.Checked)
                {
                    DataTable dtarchiveexport = new DataTable();
                    DataTable dtarchivegraph = new DataTable();
                    dtarchiveexport = objBus.GetMobilePublicCallsHistory(true, 0, ProfileID, false, true);
                    dtexportexcel.Merge(dtarchiveexport.Copy());
                    if (Session["GraphSearch"] != null)
                    {
                        DataTable dtGraphSearch = (DataTable)Session["GraphSearch"];
                        dtarchivegraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, true);
                        dtarchivegraph.Merge(dtGraphSearch.Copy());

                        DataTable dtnew = new DataTable();
                        dtnew = dtarchivegraph.Clone();
                        foreach (DataRow CDR in dtarchivegraph.Rows)
                        {
                            var rows = dtnew.Select("CategoryID=" + CDR["CategoryID"].ToString());
                            if (rows.Length == 0)
                            {
                               DataRow[] oldValue = dtarchivegraph.Select("CategoryID=" + CDR["CategoryID"].ToString());
                               int count = 0;
                               for (int i = 0; i < oldValue.Length; i++)
                               {
                                   count = count + Convert.ToInt32(oldValue[i]["MessageCount"]);
                               }

                               DataRow DR = dtnew.NewRow();
                               DR[0] = CDR["CategoryID"];
                               DR[1] = CDR["CategoryName"];
                               DR[2] = count;
                               dtnew.Rows.Add(DR);

                            }
                        }

                        dtarchivegraph = dtnew;
                    }
                    else
                    {
                        //False indicates IsArchive Status and 1 indicates both Current and Archive records
                        dtarchivegraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, false, 1);

                    }
                    chartAppUsage.Series.Clear();
                    chartAppUsage.Titles.Clear();
                    BindChart(dtarchivegraph);
                }
                if (hdnPubicCallSortDir.Value != "" && dtexportexcel.Rows.Count > 0)
                {
                    DataView dvPublicCallMsgs = DoMessagesSorting(dtexportexcel, Convert.ToInt32(hdnPubicCallSortCount.Value) == 0 ? 1 : 0, hdnPubicCallSortDir.Value, "Export");
                    dtexportexcel = dvPublicCallMsgs.ToTable();
                }
                if (dtexportexcel.Rows.Count > 0)
                {

                    string attachment = "attachment; filename=SmartConnect-" + DateTime.Now.ToString("MM-dd-yyyy-hh:mm") + ".xls";

                    StringWriter swtext = new StringWriter();
                    HtmlTextWriter hwtext = new HtmlTextWriter(swtext);
                    Table tableSearch = new Table();
                    TableRow rowCategory = new TableRow();
                    TableRow rowMID = new TableRow();
                    TableRow rowFTDate = new TableRow();
                    if (hdnResultCategory.Value != "")
                    {
                        rowCategory.Cells.Add(new TableCell());
                        rowCategory.Cells[0].Controls.Add(new Literal { Text = "Category" });
                        rowCategory.Cells.Add(new TableCell());
                        rowCategory.Cells[1].Controls.Add(new Literal { Text = hdnResultCategory.Value });
                        tableSearch.Rows.Add(rowCategory);
                    }
                    if (hdnMessageId.Value != "")
                    {
                        rowMID.Cells.Add(new TableCell());
                        rowMID.Cells[0].Controls.Add(new Literal { Text = "Message/Reference ID" });
                        rowMID.Cells.Add(new TableCell());
                        rowMID.Cells[1].Controls.Add(new Literal { Text = hdnMessageId.Value });
                        tableSearch.Rows.Add(rowMID);
                    }
                    if (hdnSearchDates.Value != "")
                    {
                        string junk = "|";
                        string[] datesList = hdnSearchDates.Value.Split(junk.ToCharArray());
                        rowFTDate.Cells.Add(new TableCell());
                        rowFTDate.Cells[0].Controls.Add(new Literal { Text = "From" });
                        rowFTDate.Cells.Add(new TableCell());
                        rowFTDate.Cells[1].Controls.Add(new Literal { Text = datesList[0] });
                        rowFTDate.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                        rowFTDate.Cells.Add(new TableCell());
                        rowFTDate.Cells[2].Controls.Add(new Literal { Text = "To" });
                        rowFTDate.Cells.Add(new TableCell());
                        rowFTDate.Cells[3].Controls.Add(new Literal { Text = datesList[1] });
                        rowFTDate.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                        tableSearch.Rows.Add(rowFTDate);
                    }
                    swtext = new StringWriter();
                    hwtext = new HtmlTextWriter(swtext);


                    grdPublicCallHistory.RowStyle.Wrap = false;
                    grdPublicCallHistory.AlternatingRowStyle.Wrap = false;
                    grdPublicCallHistory.AllowPaging = false;
                    grdPublicCallHistory.DataSource = dtexportexcel;
                    if (chkArchiveExport.Checked)
                    {
                        grdPublicCallHistory.Columns[22].Visible = true;
                    }

                    grdPublicCallHistory.DataBind();
                    grdPublicCallHistory.Columns[0].Visible = false;
                    grdPublicCallHistory.Columns[3].Visible = false;
                    grdPublicCallHistory.Columns[13].Visible = false;
                    //grdPublicCallHistory.Columns[14].Visible = true;

                    grdPublicCallHistory.Columns[4].Visible = false;
                    grdPublicCallHistory.Columns[5].Visible = false;
                    grdPublicCallHistory.Columns[6].Visible = false;
                    grdPublicCallHistory.Columns[7].Visible = false;
                    grdPublicCallHistory.Columns[8].Visible = false;
                    grdPublicCallHistory.Columns[9].Visible = false;
                    grdPublicCallHistory.Columns[10].Visible = false;
                    grdPublicCallHistory.Columns[11].Visible = false;
                    grdPublicCallHistory.Columns[12].Visible = false;
                    grdPublicCallHistory.Columns[14].Visible = false;
                    grdPublicCallHistory.Columns[15].Visible = false;
                    grdPublicCallHistory.Columns[17].Visible = false;
                    grdPublicCallHistory.Columns[18].Visible = false;
                    grdPublicCallHistory.Columns[19].Visible = false;
                    grdPublicCallHistory.Columns[20].Visible = false;
                    grdPublicCallHistory.Columns[21].Visible = false;
                    for (int i = 0; i < chkExportList.Items.Count; i++)
                    {
                        if (chkExportList.Items[i].Selected)
                        {
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[4].HeaderText)
                            {
                                grdPublicCallHistory.Columns[4].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[5].HeaderText)
                            {
                                grdPublicCallHistory.Columns[5].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[6].HeaderText)
                            {
                                grdPublicCallHistory.Columns[6].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[7].HeaderText)
                            {
                                grdPublicCallHistory.Columns[7].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[8].HeaderText)
                            {
                                grdPublicCallHistory.Columns[8].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[9].HeaderText)
                            {
                                grdPublicCallHistory.Columns[9].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[10].HeaderText)
                            {
                                grdPublicCallHistory.Columns[10].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[11].HeaderText)
                            {
                                grdPublicCallHistory.Columns[11].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[12].HeaderText)
                            {
                                grdPublicCallHistory.Columns[12].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[14].HeaderText)
                            {
                                grdPublicCallHistory.Columns[14].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[15].HeaderText)
                            {
                                grdPublicCallHistory.Columns[15].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[17].HeaderText)
                            {
                                grdPublicCallHistory.Columns[17].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[18].HeaderText)
                            {
                                grdPublicCallHistory.Columns[18].Visible = true;

                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[19].HeaderText)
                            {
                                grdPublicCallHistory.Columns[19].Visible = true;
                                grdPublicCallHistory.Columns[20].Visible = true;
                            }
                            if (chkExportList.Items[i].Text == grdPublicCallHistory.Columns[21].HeaderText)
                            {
                                grdPublicCallHistory.Columns[21].Visible = true;

                            }

                        }

                    }

                    foreach (TableCell cell in grdPublicCallHistory.HeaderRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Black;

                    }

                    grdPublicCallHistory.HeaderRow.Font.Bold = true;
                    grdPublicCallHistory.HeaderRow.ForeColor = System.Drawing.Color.White;
                    //grdPublicCallHistory.HeaderRow.BackColor = System.Drawing.Color.FromName("#23c0ef");

                    Response.Clear();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter stw = new StringWriter();
                    HtmlTextWriter htextw = new HtmlTextWriter(stw);

                    for (int i = 0; i < grdPublicCallHistory.HeaderRow.Cells.Count; i++)
                    {
                        grdPublicCallHistory.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");

                    }
                    foreach (GridViewRow gvrow in grdPublicCallHistory.Rows)
                    {
                        gvrow.BackColor = Color.White;
                        foreach (TableCell cell in gvrow.Cells)
                        {
                            if (gvrow.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grdPublicCallHistory.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grdPublicCallHistory.RowStyle.BackColor;
                            }

                        }
                    }
                    if (tableSearch.Rows.Count > 0)
                        tableSearch.RenderControl(hwtext);
                    Response.Write(swtext.ToString());
                    grdPublicCallHistory.RenderControl(htextw);
                    Response.Write(Regex.Replace(stw.ToString().Replace("<br>", ""), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));

                    //Response.Write(stw.ToString());

                    if (chkGraph.Checked)
                    {
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);


                        string ReportSummaryIMGtag = "";

                        string summaryImgName = ProfileID + "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                            + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".png";


                        if (!Directory.Exists(Server.MapPath("~") + "\\Upload\\SmartConnectMessageReport"))
                        {
                            Directory.CreateDirectory(Server.MapPath("~") + "\\Upload\\SmartConnectMessageReport");
                        }
                        string summaryIMGFullPath = Server.MapPath("~/Upload/SmartConnectMessageReport/") + summaryImgName;

                        // Save image.
                        chartAppUsage.SaveImage(summaryIMGFullPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
                        string TotalMessage = "<br/><br /><center><label>Total Messages - " + lblTotalCount.Text + "</label></center><br /><br />";
                        ReportSummaryIMGtag = "<img src='" + RootPath + "/Upload/SmartConnectMessageReport/" + summaryImgName + "' />";


                        Table table = new Table();
                        TableRow row = new TableRow();
                        TableRow rowlabel = new TableRow();

                        rowlabel.Cells.Add(new TableCell());
                        rowlabel.Cells[0].Controls.Add(new Literal { Text = TotalMessage });
                        table.Rows.Add(rowlabel);


                        row.Cells.Add(new TableCell());
                        row.Cells[0].Controls.Add(new Literal { Text = ReportSummaryIMGtag });
                        table.Rows.Add(row);

                        row = new TableRow();
                        row.Cells.Add(new TableCell());
                        row.Cells[0].Width = 200;
                        row.Cells[0].HorizontalAlign = HorizontalAlign.Center;

                        table.Rows.Add(row);

                        sw = new StringWriter();
                        hw = new HtmlTextWriter(sw);
                        table.RenderControl(hw);
                        Response.Write(sw.ToString());
                    }
                    Response.Flush();
                    Response.End();

                }

            }


            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnExport_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }


        }
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            if (hdnarchive.Value != "Archive")
            {
                foreach (GridViewRow row in grdPublicCallHistory.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPublicCalls")).Checked)
                    {
                        int MessageID = int.Parse(((LinkButton)(row.FindControl("lnkPublicCall"))).CommandArgument);
                        #region Save User Activity Log
                        string messageTitle = ((LinkButton)(row.FindControl("lnkPublicCall"))).Text;
                        objCommon.InsertUserActivityLog("has deleted a content named <b>" + messageTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        #endregion
                        objBus.DeletePubicCallHistory(MessageID);
                    }
                }
            }
            else
            {
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in grdPublicCallHistory.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPublicCalls")).Checked)
                    {
                        int MessageID = int.Parse(((LinkButton)(grdPublicCallHistory.Rows[row.RowIndex].FindControl("lnkPublicCall"))).CommandArgument);
                        #region Save User Activity Log
                        string messageTitle = ((LinkButton)(grdPublicCallHistory.Rows[row.RowIndex].FindControl("lnkPublicCall"))).Text;
                        objCommon.InsertUserActivityLog("has deleted a content named <b>" + messageTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        #endregion
                        objBus.DeletePubicCallHistory(MessageID);
                    }
                }
            }

            lblmess.Text = Resources.LabelMessages.DeleteSmartConnectMessages.ToString();
            grdPublicCallHistory.PageIndex = 0;
            GetSmartConnectMessages();

        }
        protected void lnkAssign_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryname = string.Empty;
                BindAssignCategories();

                foreach (GridViewRow row in grdPublicCallHistory.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPublicCalls")).Checked)
                    {
                        categoryname = grdPublicCallHistory.Rows[row.RowIndex].Cells[17].Text;
                        lblCategoryName.Text = categoryname;
                    }
                }
                modelAssign.Show();

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkAssign_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        private void BindAssignCategories()
        {
            try
            {
                DataTable dtAssignCategories = objBus.GetSmartConnectCategoriesList(ProfileID, UserModuleID);
                if (dtAssignCategories.Rows.Count > 0)
                {
                    ddlAssignCategory.DataSource = dtAssignCategories;
                    ddlAssignCategory.DataTextField = "CategoryName";
                    ddlAssignCategory.DataValueField = "CategoryID";
                    ddlAssignCategory.DataBind();
                }
                ddlAssignCategory.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "BindAssignCategories", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                int MID = 0, CID = 0;
                foreach (GridViewRow row in grdPublicCallHistory.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPublicCalls")).Checked)
                    {
                        MID = Convert.ToInt32(((LinkButton)(row.FindControl("lnkPublicCall"))).CommandArgument);
                        CID = Convert.ToInt32(ddlAssignCategory.SelectedValue);
                        objBus.AssignCategoryMessage(MID, CID);
                        GetSmartConnectMessages();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category Assigned Successfully')", true);
                    }
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnAssign_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bool isArchive = false;
                Session["GraphSearch"] = null;
                Session["PrintChart"] = null;
                DateTime? startDate = null;
                DateTime? endDate = null;
                DataSet dsSearch = new DataSet();
                DataTable dtListSearch = new DataTable();
                DataTable dtGraphSearch = new DataTable();
                DataTable dtLishSearchUnRead = new DataTable();

                if ((!string.IsNullOrEmpty(txtStartDate.Text)) && (!string.IsNullOrEmpty(txtEndDate.Text)))
                {
                    startDate = Convert.ToDateTime(txtStartDate.Text);
                    endDate = Convert.ToDateTime(txtEndDate.Text);
                }

                if (hdnarchive.Value == "Archive")
                    isArchive = true;
                dsSearch = objBus.GetSmartConnectSearch(hdnSelectCategoryID.Value, txtSearchMsg.Text, ProfileID, isArchive, startDate, endDate);

                //Graph Search
                dtGraphSearch = dsSearch.Tables[1];
                BindChart(dtGraphSearch);
                Session["GraphSearch"] = dtGraphSearch;
                Session["PrintChart"] = dtGraphSearch;

                BindDisplayReadFirst();

                if (chkDisplayUnread.Checked)
                {
                    //List Search with Display Unread First Checked
                    DataView dvSearchRead = new DataView(dsSearch.Tables[0]);
                    dvSearchRead.RowFilter = "isRead=false";

                    DataView dvSearchUnRead = new DataView(dsSearch.Tables[0]);
                    dvSearchUnRead.RowFilter = "isRead=true";

                    dtListSearch = dvSearchRead.ToTable();
                    dtLishSearchUnRead = dvSearchUnRead.ToTable();
                    dtListSearch.Merge(dtLishSearchUnRead.Copy());

                }
                else
                    dtListSearch = dsSearch.Tables[0];//General List Search
                BindMessagesPageSize();
                grdPublicCallHistory.DataSource = dtListSearch;
                grdPublicCallHistory.DataBind();
                Session["ListSearch"] = dtListSearch;
                hdnMessageId.Value = txtSearchMsg.Text.Trim();
                hdnSearchDates.Value = "";
                if (txtStartDate.Text.Trim() != "")
                    hdnSearchDates.Value = txtStartDate.Text + "|" + txtEndDate.Text;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>GetSelectedCategory()</script>", false);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnSearch_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        //protected void lnkListView_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        pnlGraph.Visible = false;
        //        pnlList.Visible = true;

        //        lnkListView.Text = "<img src='../../Images/Dashboard/list_h.png' title='List' border='0'/>";
        //        lnkGraph.Text = "<img src='../../Images/Dashboard/graph.png' title='Graph' border='0' style='margin-left: -3px;'/>";

        //    }
        //    catch (Exception ex)
        //    {
        //        objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkListView_Click", ex.Message,
        //        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        //    }
        //}
        //protected void lnkGraph_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        pnlGraph.Visible = true;
        //        pnlList.Visible = false;

        //        lnkGraph.Text = "<img src='../../Images/Dashboard/graph_h.png' title='Graph' style='margin-left: -3px;' border='0'/>";
        //        lnkListView.Text = "<img src='../../Images/Dashboard/list.png' title='List' border='0'/>";

        //        DataTable dtGraph = new DataTable();
        //        if (Session["GraphSearch"] != null)
        //        {
        //            dtGraph = (DataTable)Session["GraphSearch"];
        //        }
        //        else
        //        {
        //            if (hdnarchive.Value == "Archive")
        //                dtGraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, true);
        //            else
        //                dtGraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, false);
        //        }
        //        Session["PrintChart"] = dtGraph;
        //        BindChart(dtGraph);

        //    }
        //    catch (Exception ex)
        //    {
        //        objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkGraph_Click", ex.Message,
        //        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        //    }
        //}
        private void BindChart(DataTable dtGraph)
        {
            try
            {
                DataView dv = new DataView(dtGraph);
                dv.RowFilter = "MessageCount>0";
                dtGraph = dv.ToTable();
                Series series = new Series();
                //chartAppUsage.Titles.Add(lbldummyTitle.Text);

                DataTable ChartData = dtGraph;

                //storing total rows count to loop on each Record  
                string[] XPointMember = new string[ChartData.Rows.Count];
                int[] YPointMember = new int[ChartData.Rows.Count];
                int TotalMessagesCount = 0;

                for (int count = 0; count < ChartData.Rows.Count; count++)
                {
                    //storing Values for X axis  
                    XPointMember[count] = ChartData.Rows[count]["CategoryName"].ToString();
                    //storing values for Y Axis  
                    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["MessageCount"]);
                    series.Palette = ChartColorPalette.BrightPastel;
                    series.LabelForeColor = Color.Black;

                    TotalMessagesCount = TotalMessagesCount + Convert.ToInt32(ChartData.Rows[count]["MessageCount"]);
                }

                lblTotalCount.Text = TotalMessagesCount.ToString();

                series.Points.DataBindXY(XPointMember, YPointMember);
                chartAppUsage.Series.Add(series);

                // Set the PieLabelStyle custom attribute to the value of "Outside"
                chartAppUsage.Series[0]["PieLabelStyle"] = "Outside";

                // By default, the callout lines will not be drawn unless you set a color for the series border
                chartAppUsage.Series[0].BorderWidth = 1;
                chartAppUsage.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                chartAppUsage.Series[0].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);

                //setting Chart type   
                chartAppUsage.Series[0].ChartType = SeriesChartType.Pie;

                foreach (Series charts in chartAppUsage.Series)
                {
                    foreach (DataPoint point in charts.Points)
                    {
                        point.Label = string.Format("{1} - {0:0}({2})", point.YValues[0], point.AxisLabel, "#PERCENT{P0}");
                    }
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "BindChart", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnBlockUsers_Click(object sender, EventArgs e)
        {
            try
            {
                int totalBlockedCount = 0;
                int updatedCount = 0;
                /**** SmartConnect - Messages(Calls History) ***/
                foreach (GridViewRow gvrow in grdPublicCallHistory.Rows)
                {
                    CheckBox chkblock = (CheckBox)gvrow.FindControl("chkPublicCalls");
                    if (chkblock.Checked)
                    {
                        int messageID = Convert.ToInt32(grdPublicCallHistory.DataKeys[gvrow.RowIndex].Value);
                        int updateCount = objBus.BlockUnBlockSmartConnectSenders(messageID, true, C_UserID);
                        totalBlockedCount += 1;
                        if (updateCount > 0)
                            updatedCount += 1;
                    }
                }
                string msg = Resources.LabelMessages.BlockedAllSenders.ToString();
                if (updatedCount == 0)
                    msg = Resources.LabelMessages.BlockedSendersFailed.ToString();
                else if (totalBlockedCount != updatedCount)
                    msg = Resources.LabelMessages.BlockedPartialSenders.ToString();
                lblmess.Text = msg;
                GetSmartConnectMessages();

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnBlockUsers_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["message"] != null)
                {
                    DataTable dtCustomModules = objBus.DashboardIcons(UserID);
                    DataView dv = new DataView(dtCustomModules);
                    dv.RowFilter = "ButtonType='PublicCallAddOns'";
                    dtCustomModules = dv.ToTable();
                    Session["CustomModuleID"] = dtCustomModules.Rows[0]["UserModuleID"].ToString();
                }
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManagePublicCallIndexAddOns.aspx"));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnBack_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void MakeDefaultValues()
        {
            try
            {
                txtStartDate.Text = "";
                txtEndDate.Text = "";
                txtSearchMsg.Text = "";
                hdnresult.Value = "";
                //ddlCategory.SelectedIndex = 0;
                Session["GraphSearch"] = null;
                Session["ListSearch"] = null;
                Session["PrintChart"] = null;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "MakeDefaultValues", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                MakeDefaultValues();
                GetSmartConnectMessages();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnClear_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnDownload_OnClick(object sender, EventArgs e)
        {
            try
            {
                GetSmartConnectMessages();
                if (Session["GraphSearch"] != null)
                {
                    DataTable dtGraphSearch = (DataTable)Session["GraphSearch"];
                    chartAppUsage.Series.Clear();
                    chartAppUsage.Titles.Clear();
                    BindChart(dtGraphSearch);
                }
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ReportsHTML\\";
                StreamReader re = File.OpenText(strfilepath + "SmartConnectChart.htm");
                string htmlStr = string.Empty;
                string content = string.Empty;
                while ((content = re.ReadLine()) != null)
                {
                    htmlStr = htmlStr + content;
                }
                re.Close();
                re.Dispose();

                string graphIMGtag = "";

                string graphImgName = ProfileID + "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                    + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".png";


                if (!Directory.Exists(Server.MapPath("~") + "\\Upload\\SmartConnectMessageReport"))
                {
                    Directory.CreateDirectory(Server.MapPath("~") + "\\Upload\\SmartConnectMessageReport");
                }
                string graphIMGFullPath = Server.MapPath("~/Upload/SmartConnectMessageReport/") + graphImgName;

                // Save image.
                chartAppUsage.SaveImage(graphIMGFullPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

                graphIMGtag = "<img src='" + RootPath + "/Upload/SmartConnectMessageReport/" + graphImgName + "' />";
                htmlStr = htmlStr.Replace("#SmartconnectChartImage#", graphIMGtag);
                htmlStr = htmlStr.Replace("#TotalMessagesCount#", lblTotalCount.Text);
                string filename = "SmartConnectChart";
                string savelocation = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + filename + ".pdf";
                objCommon.HtmlToPDF_Print(htmlStr, filename, savelocation, true);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnDownload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {

                if (Session["PrintChart"] != null)
                {
                    string url = RootPath + "/PrintSmartConnectChart.aspx";
                    ScriptManager.RegisterClientScriptBlock(this.btnPrint, this.GetType(), "Print", "window.open('" + url + "');", true);
                    BindChart((DataTable)Session["PrintChart"]);

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "btnPrint_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkShowGraph_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGraph = new DataTable();
                if (Session["GraphSearch"] != null)
                {
                    dtGraph = (DataTable)Session["GraphSearch"];
                }
                else
                {
                    if (hdnarchive.Value == "Archive")
                        dtGraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, true);
                    else
                        dtGraph = objBus.GetPieChartDataForSmartConnectMessages(ProfileID, false);
                }
                Session["PrintChart"] = dtGraph;

                BindChart(dtGraph);
                modelPGraph.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lnkShowGraph_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void chkDisplayUnread_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SaveMessageSettings();
                DisplayReadData();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "chkDisplayUnread_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        private void DisplayReadData(int grdPageIndex = 0)
        {
            try
            {
                int CustomizeSettingsID;
                DataTable dtReadPublicCalls = new DataTable();
                DataTable dtUnReadPublicCalls = new DataTable();
                DataTable dtDisplayReadFirst = new DataTable();
                DataTable dtListSearch = new DataTable();
                DataTable dtLishSearchUnRead = new DataTable();

                dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "SmartConnectMessage");
                if (dtDisplayReadFirst.Rows.Count == 0)
                    CustomizeSettingsID = objBus.UserCustomizeSettings(0, ProfileID, UserID, "SmartConnectMessage", hdnDisplayRead.Value);
                else
                    CustomizeSettingsID = objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, "SmartConnectMessage", hdnDisplayRead.Value);
                BindDisplayReadFirst();

                if (Session["ListSearch"] != null)
                {
                    dtListSearch = (DataTable)Session["ListSearch"];
                    DataView dvSearchRead = new DataView(dtListSearch);
                    dvSearchRead.RowFilter = "isRead=false";

                    DataView dvSearchUnRead = new DataView(dtListSearch);
                    dvSearchUnRead.RowFilter = "isRead=true";

                    if (chkDisplayUnread.Checked)
                    {
                        dtListSearch = dvSearchRead.ToTable();
                        dtLishSearchUnRead = dvSearchUnRead.ToTable();
                        dtListSearch.Merge(dtLishSearchUnRead.Copy());
                    }
                    grdPublicCallHistory.PageIndex = grdPageIndex;
                    grdPublicCallHistory.DataSource = dtListSearch;
                    grdPublicCallHistory.DataBind();
                }
                else
                {
                    if (chkDisplayUnread.Checked)
                    {
                        if (CustomizeSettingsID > 0)
                        {
                            if (hdnarchive.Value == "Archive")
                            {
                                dtReadPublicCalls = objBus.GetReadPublicCalls(ProfileID, false, true);
                                dtUnReadPublicCalls = objBus.GetReadPublicCalls(ProfileID, true, true);
                                dtReadPublicCalls.Merge(dtUnReadPublicCalls.Copy());
                            }
                            else
                            {
                                dtReadPublicCalls = objBus.GetReadPublicCalls(ProfileID, false, false);
                                dtUnReadPublicCalls = objBus.GetReadPublicCalls(ProfileID, true, false);
                                dtReadPublicCalls.Merge(dtUnReadPublicCalls.Copy());
                            }
                            ViewState["dtPublicCalls"] = dtReadPublicCalls;
                            showCurrArchives(true);
                            grdPublicCallHistory.PageSize = Convert.ToInt32(PageSizes.SelectedPage);
                            grdPublicCallHistory.PageIndex = grdPageIndex;
                            grdPublicCallHistory.DataSource = dtReadPublicCalls;
                            grdPublicCallHistory.DataBind();
                        }
                    }
                    else
                    {

                        GetSmartConnectMessages();
                    }
                }


            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "DisplayReadData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected bool SetVisibility(object desc, int maxLength)
        {
            var description = (desc == DBNull.Value) ? string.Empty : (string)desc;

            if (string.IsNullOrEmpty(description)) { return false; }
            return description.Length > maxLength;


        }


        DataTable dtSearchKeyWords;
        
        public void StoreSearchedValues()
        {
            try
            {
                if (dtSearchKeyWords == null)
                {
                    dtSearchKeyWords = new DataTable();
                    dtSearchKeyWords.Columns.Add("Category", typeof(string));
                    dtSearchKeyWords.Columns.Add("Message", typeof(string));
                    dtSearchKeyWords.Columns.Add("FromDate", typeof(string));
                    dtSearchKeyWords.Columns.Add("ToDate", typeof(string));
                    dtSearchKeyWords.Columns.Add("GridRowIndex", typeof(string));
                    dtSearchKeyWords.Columns.Add("IsArchive", typeof(string));
                    dtSearchKeyWords.Columns.Add("hdnsortdire", typeof(string));
                    dtSearchKeyWords.Columns.Add("hdnsortcount", typeof(string));
                    dtSearchKeyWords.Columns.Add("hdnPubicCallSortDir", typeof(string));
                    dtSearchKeyWords.Columns.Add("hdnPubicCallSortCount", typeof(string));
                    dtSearchKeyWords.Columns.Add("hdnSelectedMsgHistoryId", typeof(string));
                    dtSearchKeyWords.Columns.Add("chkRead", typeof(bool));
                    dtSearchKeyWords.Columns.Add("PageSize", typeof(string));
                }
                dtSearchKeyWords.Rows.Add(hdnresult.Value, txtSearchMsg.Text, txtStartDate.Text, txtEndDate.Text, hdnGvPageIndex.Value,
                    hdnarchive.Value, hdnsortdire.Value,
                    hdnsortcount.Value, hdnPubicCallSortDir.Value, hdnPubicCallSortCount.Value, hdnSelectedMsgHistoryId.Value,
                    chkDisplayUnread.Checked ? true : false, PageSizes.SelectedPage
                    );
                Session["searchedKeywords"] = dtSearchKeyWords;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "StoreSearchedValues()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void showPrevSearchDetails()
        {
            try
            {
                //bool isArchive = false;
                DataTable dtPrevData = (DataTable)Session["searchedKeywords"];
                string strCategory = Convert.ToString(dtPrevData.Rows[0]["Category"]);
                txtSearchMsg.Text = Convert.ToString(dtPrevData.Rows[0]["Message"]);
                txtStartDate.Text = Convert.ToString(dtPrevData.Rows[0]["FromDate"]);
                txtEndDate.Text = Convert.ToString(dtPrevData.Rows[0]["ToDate"]);
                hdnarchive.Value = Convert.ToString(dtPrevData.Rows[0]["IsArchive"]);
                hdnsortdire.Value = Convert.ToString(dtPrevData.Rows[0]["hdnsortdire"]);
                hdnsortcount.Value = Convert.ToString(dtPrevData.Rows[0]["hdnsortcount"]);
                hdnPubicCallSortDir.Value = Convert.ToString(dtPrevData.Rows[0]["hdnPubicCallSortDir"]); ;
                hdnPubicCallSortCount.Value = Convert.ToString(dtPrevData.Rows[0]["hdnPubicCallSortCount"]);
                hdnresult.Value = strCategory;
                chkDisplayUnread.Checked = Convert.ToBoolean(dtPrevData.Rows[0]["chkRead"]);
                hdnSelectedMsgHistoryId.Value = Convert.ToString(dtPrevData.Rows[0]["hdnSelectedMsgHistoryId"]);
                PageSizes.SelectedPage = Convert.ToString(dtPrevData.Rows[0]["PageSize"]);
                if (hdnarchive.Value.ToLower().Equals("archive"))
                {//Archive
                    lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
                    lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
                }
                else
                {
                    //current
                    lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
                    lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
                }
                Session["searchedKeywords"] = null;
                hdnGvPageIndex.Value = (Convert.ToString(dtPrevData.Rows[0]["GridRowIndex"])) == "" ? "0" : Convert.ToString(dtPrevData.Rows[0]["GridRowIndex"]);
                ShowSearchResult(Convert.ToInt32(hdnGvPageIndex.Value));
                BindSmartConnectCategories();
                //BindChart((DataTable)Session["GraphSearch"]);
                //BindMessagesPageSize();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "showPrevSearchDetails()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void ShowSearchResult(int grdPageIndex = 0)
        {
            bool isArchive = false;
            Session["GraphSearch"] = null;
            Session["PrintChart"] = null;
            DateTime? startDate = null;
            DateTime? endDate = null;
            DataSet dsSearch = new DataSet();
            DataTable dtListSearch = new DataTable();
            DataTable dtGraphSearch = new DataTable();
            DataTable dtLishSearchUnRead = new DataTable();

            if ((!string.IsNullOrEmpty(txtStartDate.Text)) && (!string.IsNullOrEmpty(txtEndDate.Text)))
            {
                startDate = Convert.ToDateTime(txtStartDate.Text);
                endDate = Convert.ToDateTime(txtEndDate.Text);
            }

            if (hdnarchive.Value == "Archive")
                isArchive = true;
            if (hdnresult.Value != string.Empty || txtSearchMsg.Text.Trim() != string.Empty || txtStartDate.Text != string.Empty || txtEndDate.Text.Trim() != string.Empty)
            {
                dsSearch = objBus.GetSmartConnectSearch(hdnresult.Value, txtSearchMsg.Text, ProfileID, isArchive, startDate, endDate);

                //Graph Search
                dtGraphSearch = dsSearch.Tables[1];
                BindChart(dtGraphSearch);
                Session["GraphSearch"] = dtGraphSearch;
                Session["PrintChart"] = dtGraphSearch;

                BindDisplayReadFirst();

                if (chkDisplayUnread.Checked)
                {
                    //List Search with Display Unread First Checked
                    DataView dvSearchRead = new DataView(dsSearch.Tables[0]);
                    dvSearchRead.RowFilter = "isRead=false";

                    DataView dvSearchUnRead = new DataView(dsSearch.Tables[0]);
                    dvSearchUnRead.RowFilter = "isRead=true";

                    dtListSearch = dvSearchRead.ToTable();
                    dtLishSearchUnRead = dvSearchUnRead.ToTable();
                    dtListSearch.Merge(dtLishSearchUnRead.Copy());

                }
                else
                    dtListSearch = dsSearch.Tables[0];//General List Search
                grdPublicCallHistory.PageIndex = grdPageIndex;
                grdPublicCallHistory.DataSource = dtListSearch;
                grdPublicCallHistory.DataBind();
                Session["ListSearch"] = dtListSearch;
                BindMessagesPageSize();
            }
            else
            {
                if (chkDisplayUnread.Checked)
                {
                    DisplayReadData(grdPageIndex);
                }
                else
                {
                    GetSmartConnectMessages(grdPageIndex);
                }
            }
        }

        protected void lblImage_Click(object sender, EventArgs e)
        {
            try
            {
                string ImageName = "";
                LinkButton lnk = sender as LinkButton;
                ImageName = lnk.CommandName;

                string ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\PublicCallDirectoryTapImages\\" + ProfileID + "\\" + ImageName;
                string ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/PublicCallDirectoryTapImages/" + ProfileID + "/" + ImageName;
                if (File.Exists(ImageVirtualPath))
                {
                    lblImage.Text = "<img src='" + ImgRootPath + "' id='img1' border='0' />";
                    popSCimage.Show();
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessage.aspx.cs", "lblImage_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindMessagesPageSize()
        {
            try
            {
                DataTable dt = (DataTable)ViewState["dtPublicCalls"];
                if (dt == null)
                    dt = (DataTable)Session["ListSearch"];

                if (dt != null)
                {
                    grdPublicCallHistory.PageSize = Convert.ToInt32(PageSizes.SelectedPage);
                    grdPublicCallHistory.DataSource = dt;
                    grdPublicCallHistory.DataBind();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessages.aspx.cs", "BindMessagesPageSize()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SaveMessageSettings()
        {
            try
            {
                hdnDisplayRead.Value = "<SmartConnectMessage IsChecked='" + chkDisplayUnread.Checked + "'  MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
                var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "SmartConnectMessage");
                if (dtDisplayReadFirst.Rows.Count == 0)
                    objBus.UserCustomizeSettings(0, ProfileID, UserID, "SmartConnectMessage", hdnDisplayRead.Value);
                else
                    objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, "SmartConnectMessage", hdnDisplayRead.Value);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessages.aspx.cs", "SaveMessageSettings()", ex.Message,
                       Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaveMessageSettings();
                BindMessagesPageSize();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SmartConnectMessages.aspx.cs", "ddlPageSize_SelectedIndexChanged()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}