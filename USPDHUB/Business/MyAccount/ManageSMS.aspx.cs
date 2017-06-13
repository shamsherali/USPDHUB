using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Text;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageSMS : System.Web.UI.Page
    {
        DataTable dtManageSMS = new DataTable();
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";
        public int SortDir = 0;

        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();

        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();

        SMSBLL objSMSBLL = new SMSBLL();


        protected void Page_Load(object sender, EventArgs e)
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
            lblerrormessage.Text = "";
            if (!IsPostBack)
            {
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Surveys");
                    if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage sms.</font>";
                    }
                }
                //ends here

                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";

                if (Convert.ToString(Session["smsMessage"]) != "")
                {
                    lblmess.Text = Session["smsMessage"].ToString();
                    Session["smsMessage"] = "";
                }
                GetSMSDetails();

            }
        }

        private void GetSMSDetails()
        {
            dtManageSMS = objSMSBLL.GetManageSMS(ProfileID);
            Session["smsdetails"] = dtManageSMS;
            dgsms.DataSource = dtManageSMS;
            dgsms.DataBind();

            hdnShowButtons.Value = "1";

            if (dtManageSMS.Rows.Count == 0)
                hdnShowButtons.Value = "";
        }

        protected void btnNewSMS_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SMSCompose.aspx"));
        }

        protected void dgsms_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtManageSMS = (DataTable)Session["smsdetails"];
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
            DataView Dv = new DataView(dtManageSMS);
            if (SortDir == 0)
            {

                if (SortExp == "SMS_Message")
                {
                    Dv.Sort = "SMS_Message desc";
                }
                else if (SortExp == "Created_Date")
                {
                    Dv.Sort = "Created_Date desc";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "SMS_Message")
                {
                    Dv.Sort = "SMS_Message ASC";
                }
                else if (SortExp == "Created_Date")
                {
                    Dv.Sort = "Created_Date ASC";
                }

                hdnsortcount.Value = "0";
            }

            Session["smsdetails"] = Dv.ToTable();
            dgsms.DataSource = Dv;
            dgsms.DataBind();

        }

        protected void dgsms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtManageSMS = (DataTable)Session["smsdetails"];
            dgsms.PageIndex = e.NewPageIndex;
            dgsms.DataSource = dtManageSMS;
            dgsms.DataBind();
        }

        protected void rbSMS_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;

            LinkButton lblid = (LinkButton)row.FindControl("lnkName");
            hdnCommandArg.Value = lblid.CommandArgument;
        }

        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != string.Empty)
            {
                int SMSID = Convert.ToInt32(hdnCommandArg.Value);
                objSMSBLL.DeleteSMS(SMSID);
                GetSMSDetails();
                lblmess.Text = "<font size='3'>Your sms have been deleted successfully.</font>";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        protected void lnkName_Click(object sender, EventArgs e)
        {
            LinkButton lnkTitle = sender as LinkButton;
            ShowPreview(lnkTitle.CommandArgument);
        }

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                ShowPreview(hdnCommandArg.Value);
            }
        }

        private void ShowPreview(string SMSID)
        {
            ModalPopupExtender2.Show();

            DataTable dtSMSDetails = objSMSBLL.GetSMSDetailsBySMSID(Convert.ToInt32(SMSID));
            StringBuilder htmlString = new StringBuilder();
            htmlString.Append("<table  width='100%' border='0' cellspacing='0' cellpadding='5' style='font-family: Arial, Helvetica, sans-serif;  font-size: 14px; border: solid 2px #F4EBEB;'>");
            htmlString.Append("<tr><td style='width:150px;'> Mobile Numbers: </td><td>" + Convert.ToString(dtSMSDetails.Rows[0]["MobileNumbers"]) + "</td></tr>");
            htmlString.Append("<tr><td style='width:150px;'> Message: </td><td>" + Convert.ToString(dtSMSDetails.Rows[0]["Message"]) + "</td></tr>");
            htmlString.Append("</table>");

            lblPreviewHTML.Text = objCommon.ReplaceShortURltoHtmlString(htmlString.ToString());
        }

        protected void ImcloseClick(object sender, ImageClickEventArgs e)
        {

        }
    }
}