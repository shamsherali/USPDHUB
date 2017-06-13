using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.Web.UI;
using System.Collections.Generic;
using Facebook;
using System.Net;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageCannedMessage : BaseWeb
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public string DomainName = "";
        public string RootPath = string.Empty;
        public int SortDir = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblSuccessMsg.Text = "";

                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    UserID = Convert.ToInt32(Session["UserID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        CUserID = UserID;
                }

                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (!IsPostBack)
                {

                    LoadGrid();
                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";
                }
            }
            catch (Exception /*ex*/)
            {
            }
        }

        private void LoadGrid()
        {
            try
            {
                BusinessBLL objMessage = new BusinessBLL();
                DataTable dtMessage = objMessage.GetAllCannedMessages(ProfileID);
                Session["DtMessage"] = dtMessage;
                GVMessage.DataSource = dtMessage;
                GVMessage.DataBind();
            }
            catch (Exception /*ex*/)
            {
            }
        }

        protected void GVMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dtMessage = (DataTable)Session["DtMessage"];
                GVMessage.PageIndex = e.NewPageIndex;
                GVMessage.DataSource = dtMessage;
                GVMessage.DataBind();
            }
            catch
            {
            }
        }

        protected void GVMessage_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                lblSuccessMsg.Text = "";
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string sortExp = e.SortExpression.ToString();
                DataTable dtMessage = (DataTable)Session["DtMessage"];
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
                DataView dv = new DataView(dtMessage);
                if (SortDir == 0)
                {
                    if (sortExp == "CreatedDate")
                    {
                        dv.Sort = "CreatedDate ASC";
                    }

                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (sortExp == "CreatedDate")
                    {
                        dv.Sort = "CreatedDate desc";
                    }

                    hdnsortcount.Value = "0";
                }
                Session["DtMessage"] = dv.ToTable();
                GVMessage.DataSource = dv;
                GVMessage.DataBind();
            }
            catch
            {
            }
        }

        protected void GVMessage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BusinessBLL objCannedMsg = new BusinessBLL();
                DataSet dsMsg = new DataSet();
                int CannedMessageID = 0;
                CannedMessageID = Convert.ToInt32(e.CommandArgument);
                if (CannedMessageID > 0)
                {
                    if (e.CommandName == "DeleteRow")
                    {
                        objCannedMsg.InsertCannedMessage(CannedMessageID, ProfileID, UserID, txtMessage.Text, CUserID, CUserID, DateTime.Now, DateTime.Now, true);
                        lblSuccessMsg.Visible = true;
                        lblSuccessMsg.Text = "<font size='2' color='green'>Message has been deleted successfully.</font>";
                        LoadGrid();

                    }
                    else if (e.CommandName == "EditRow")
                    {
                        hdnEditID.Value = CannedMessageID.ToString();
                        lnkSave.Text = "Update";

                        dsMsg = objCannedMsg.GetMessageByCannedID(CannedMessageID);
                        if (dsMsg.Tables[0].Rows.Count > 0)
                        {
                            txtMessage.Text = dsMsg.Tables[0].Rows[0]["MessageText"].ToString();
                            lblLength.Text = (txtMessage.MaxLength - txtMessage.Text.Length).ToString();
                        }
                        MPEMessage.Show();

                    }
                }

            }
            catch (Exception ex)
            {
                lblSuccessMsg.Text = "<font size='2' color='red'>" + ex.Message.ToString() + "</font>";
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblSuccessMsg.Visible = true;
                string MessageText = txtMessage.Text;
                BusinessBLL objInsertCannedMsg = new BusinessBLL();
                if (lnkSave.Text == "Update")
                {
                    int CannedMessageID = Convert.ToInt32(hdnEditID.Value);
                    objInsertCannedMsg.InsertCannedMessage(CannedMessageID, ProfileID, UserID, txtMessage.Text, CUserID, CUserID, DateTime.Now, DateTime.Now, false);
                    lblSuccessMsg.Text = "<font size='2' color='green'>Message has been updated successfully.</font>";
                    txtMessage.Text = "";
                    LoadGrid();
                }
                else
                {
                    int insertMessage = objInsertCannedMsg.InsertCannedMessage(0, ProfileID, UserID, MessageText, CUserID, CUserID, DateTime.Now, DateTime.Now, false);
                    if (insertMessage > 0)
                    {
                        lblSuccessMsg.Text = "<font size='2' color='green'>Message has been saved successfully.</font>";
                        txtMessage.Text = "";
                        LoadGrid();
                    }
                    else
                    {
                        lblSuccessMsg.Text = "<font size='2' color='green'>Insertion Failed.Please try again.</font>";
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            MPEMessage.Hide();

        }

        protected void lnkAdd_OnClick(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            lnkSave.Text = "Save";
            lblLength.Text = (txtMessage.MaxLength - txtMessage.Text.Length).ToString();
            MPEMessage.Show();
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            string requestPageName = "";
            if (Request.QueryString["PageName"] != null)
                requestPageName = Request.QueryString["PageName"].ToString();

            if (requestPageName == "Tips")
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx"));
            else
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/InquiryAlerts.aspx"));

        }

    }
}