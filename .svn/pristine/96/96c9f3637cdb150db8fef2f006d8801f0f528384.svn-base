using System;
using System.Data;
using USPDHUBBLL;


namespace USPDHUB.ProfileIframes
{
    public partial class AddNotes : System.Web.UI.Page
    {
        AgencyBLL agencyobj = new AgencyBLL();
        DataTable dtobj = new DataTable();
        public int InquiryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminuserid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                InquiryId = Convert.ToInt32(Request.QueryString["ID"].ToString());

            if (!IsPostBack)
                FillNotes();
            TxtBxNotes.Focus();
        }

        protected void BtnNotes_Click(object sender, EventArgs e)
        {
            DateTime nextActDateTime = Convert.ToDateTime(txtActionDate.Text.Trim());
            nextActDateTime =  nextActDateTime.AddHours(Convert.ToInt32(ddlHours.SelectedValue));
            nextActDateTime = nextActDateTime.AddMinutes(Convert.ToInt32(ddlMints.SelectedValue));
            if (nextActDateTime < DateTime.Now)
            {
                lblError.Text = "<font size='2' color='red'>" + Resources.AdminResource.NextActionDateTime + "</font>";                
            }
            else
            {
                string notes = TxtBxNotes.Text.Trim();
                string notesBy = txtNotesBy.Text.Trim();
                int i = agencyobj.InsertEnquiryNotesWithActioDate(0, notes, notesBy, InquiryId, true, nextActDateTime);
                if (i > 0)
                {
                    FillNotes();
                    TxtBxNotes.Text = txtNotesBy.Text = "";
                    TxtBxNotes.Focus();
                }
            }
        }

        protected void FillNotes()
        {
            DataTable dtVerifyDetails = agencyobj.GetVerifyDetailsById(InquiryId);
            if (dtVerifyDetails.Rows.Count == 1)
            {
                if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["NextAction_Date"].ToString()))
                {
                    DateTime nextActionDateTime = Convert.ToDateTime(dtVerifyDetails.Rows[0]["NextAction_Date"].ToString());
                    txtActionDate.Text = nextActionDateTime.ToShortDateString();
                    ddlHours.SelectedValue = nextActionDateTime.Hour.ToString();
                    ddlMints.SelectedValue = nextActionDateTime.Minute.ToString();
                }
            }
            dtobj = agencyobj.GetEnquiryNotes(0, string.Empty, string.Empty, InquiryId, false);
            DataList_CustomerNotes.DataSource = dtobj;
            DataList_CustomerNotes.DataBind();
        }
    }
}