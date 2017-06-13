using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
namespace USPDHUB.Admin
{
    public partial class CreateSalesCode : BaseWeb
    {

        AdminBLL objAdmin = new AdminBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        int AdminUserID;
        int roleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["AdminID"] != null)
                {
                    AdminUserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["AdminID"]));
                }
                if (!IsPostBack)
                {
                    BindNames();
                }

            }
            catch
            {
            }
        }


        private void BindNames()
        {

            //Binding LT Manager
            DataTable dtLTManager = objAdmin.GetNamesByRoleID((int)Role.LTRoleID);
            ddlLtManager.DataSource = dtLTManager;
            ddlLtManager.DataTextField = "Name";
            ddlLtManager.DataValueField = "PartnerId";
            ddlLtManager.DataBind();
            ddlLtManager.Items.Insert(0, "Select");

            //Binding Channel Manager
            DataTable dtChannelManager = objAdmin.GetNamesByRoleID((int)Role.CMRoleID);
            ddlChannelManager.DataSource = dtChannelManager;
            ddlChannelManager.DataTextField = "Name";
            ddlChannelManager.DataValueField = "PartnerId";
            ddlChannelManager.DataBind();
            ddlChannelManager.Items.Insert(0, "Select");

            //Binding Channel Partner
            DataTable dtChannelPartner = objAdmin.GetNamesByRoleID((int)Role.CPRoleID);
            ddlChannelPartner.DataSource = dtChannelPartner;
            ddlChannelPartner.DataTextField = "Name";
            ddlChannelPartner.DataValueField = "PartnerId";
            ddlChannelPartner.DataBind();
            ddlChannelPartner.Items.Insert(0, "Select");

            //Binding Channel Affiliate
            DataTable dtChannelAffiliate = objAdmin.GetNamesByRoleID((int)Role.CARoleID);
            ddlChannelAffliate.DataSource = dtChannelAffiliate;
            ddlChannelAffliate.DataTextField = "Name";
            ddlChannelAffliate.DataValueField = "PartnerId";
            ddlChannelAffliate.DataBind();
            ddlChannelAffliate.Items.Insert(0, "Select");

        }
        protected void btnLTManager_Click(object sender, EventArgs e)
        {
            lblroleID.Text = ((int)Role.LTRoleID).ToString();
            mpeCreateSalesPerson.Show();


        }
        protected void btnCreatePartners_Click(object sender, EventArgs e)
        {
            try
            {
                objAdmin.InsertChannelPartnerDetails(txtFirstName.Text, txtLastName.Text, txtCompanyName.Text, txtAddress.Text, txtCity.Text, txtState.Text, Convert.ToInt32(txtZipcode.Text), txtEmailAddress.Text, txtWebsite.Text, Convert.ToInt32(lblroleID.Text), txtPhoneNumber.Text, txtPhoneExtension.Text);
                BindNames();
                if (ddlChannelPartner.SelectedIndex == 0)
                {
                    txtCPPercentage.Text = "";
                    txtCPPercentage.Enabled = false;
                }
                if (ddlLtManager.SelectedIndex == 0)
                {
                    txtLTMPercentage.Text = "";
                    txtLTMPercentage.Enabled = false;
                }
                if (ddlChannelManager.SelectedIndex == 0)
                {
                    txtCMPercentage.Text = "";
                    txtCMPercentage.Enabled = false;
                }
                if (ddlChannelAffliate.SelectedIndex == 0)
                {
                    txtCAPercentage.Text = "";
                    txtCAPercentage.Enabled = false;
                }
                clearall();
                lblmsg.Text = Resources.AdminResource.SalesDetails;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CreateSalesCode.aspx.cs", "btnCreatePartners_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void btnCreateSalesCode_Click(object sender, EventArgs e)
        {
            try
            {
                int LTMID, CMID, CPID, CAID, LTMCom, CMCom, CPCom, CACom;
                LTMID = (ddlLtManager.SelectedIndex == 0) ? 0 : Convert.ToInt32(ddlLtManager.SelectedValue);
                CMID = (ddlChannelManager.SelectedIndex == 0) ? 0 : Convert.ToInt32(ddlChannelManager.SelectedValue);
                CPID = (ddlChannelPartner.SelectedIndex == 0) ? 0 : Convert.ToInt32(ddlChannelPartner.SelectedValue);
                CAID = (ddlChannelAffliate.SelectedIndex == 0) ? 0 : Convert.ToInt32(ddlChannelAffliate.SelectedValue);
                LTMCom = (string.IsNullOrEmpty(txtLTMPercentage.Text)) ? 0 : Convert.ToInt32(txtLTMPercentage.Text);
                CMCom = (string.IsNullOrEmpty(txtCMPercentage.Text)) ? 0 : Convert.ToInt32(txtCMPercentage.Text);
                CPCom = (string.IsNullOrEmpty(txtCPPercentage.Text)) ? 0 : Convert.ToInt32(txtCPPercentage.Text);
                CACom = (string.IsNullOrEmpty(txtCAPercentage.Text)) ? 0 : Convert.ToInt32(txtCAPercentage.Text);
                DateTime agreementStartDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime agreementEndDate = Convert.ToDateTime(txtEndDate.Text);
                int ConfigID = objAdmin.InsertSalesPersonDetails(txtSalesCode.Text, LTMID, LTMCom, CPID, CPCom, CMID, CMCom, CAID, CACom, agreementStartDate, agreementEndDate, AdminUserID, txtNotes.Text.Trim(), txtCreatedBy.Text.Trim(), txtApprovedBy.Text.Trim());
                Response.Redirect("~/Admin/SalesCode.aspx?ConfigID=" + EncryptDecrypt.DESEncrypt(ConfigID.ToString()) + "&SC=" + EncryptDecrypt.DESEncrypt(txtSalesCode.Text));
                //lblmsg.Text = Resources.AdminResource.SalesPersonCreated;
            }

            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CreateSalesCode.aspx.cs", "btnCreateSalesCode_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void btnCreateCM_Click(object sender, EventArgs e)
        {
            lblroleID.Text = ((int)Role.CMRoleID).ToString();
            mpeCreateSalesPerson.Show();

        }

        protected void btnCreateCP_Click(object sender, EventArgs e)
        {
            lblroleID.Text = ((int)Role.CPRoleID).ToString();
            mpeCreateSalesPerson.Show();

        }

        protected void btnCreateCA_Click(object sender, EventArgs e)
        {
            lblroleID.Text = ((int)Role.CARoleID).ToString();
            mpeCreateSalesPerson.Show();

        }
        public void clearall()
        {
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneExtension.Text = "";
            txtPhoneNumber.Text = "";
            txtCompanyName.Text = "";
            txtEmailAddress.Text = "";
            txtWebsite.Text = "";
            txtZipcode.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/ManageSalesCode.aspx");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CreateSalesCode.aspx.cs", "btnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
       
    }
}