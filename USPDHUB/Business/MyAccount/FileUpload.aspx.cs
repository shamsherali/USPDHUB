using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class FileUpload1 : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        InBuiltDataBLL objInBulitData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        string XmlData = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            fileToUpload.Attributes.Add("onchange", "javascript:return ajaxFileUpload();");
            if (Session["userid"] == null || Session["ProfileID"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            }
            if (!IsPostBack)
            {
                CreateFolder();
                LoadDefaultData();
            }
        }
        protected void CreateFolder()
        {
            try
            {
                string Serverpath = Server.MapPath("~") + "Upload\\Bulletins\\";
                string sDirPath = Serverpath + ProfileID;
                DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

                if (!ObjSearchDir.Exists)
                {
                    ObjSearchDir.Create();
                    //Random number folder for file uploading

                    hdnUploadFilePath.Value = sDirPath;
                }
                hdnFileFolder.Value = ProfileID.ToString();

            }
            catch (Exception /*mEx*/)
            {

            }
        }
        private void LoadDefaultData()
        {
            // *** Bindig Month Data *** //
            ddlMonth.DataSource = objInBulitData.GetMonths();
            ddlMonth.DataTextField = "Text";
            ddlMonth.DataValueField = "Value";
            ddlMonth.DataBind();
            //ddlMonth.SelectedValue = DateTime.Today.ToString("MMMM");
            // *** Bindig Dates Data *** //
            ddlDate.DataSource = objInBulitData.GetDates();
            ddlDate.DataTextField = "Text";
            ddlDate.DataValueField = "Value";
            ddlDate.DataBind();
            //ddlDate.SelectedValue = DateTime.Today.Day.ToString();
            // *** Bindig Years Data *** //
            ddlYear.DataSource = objInBulitData.GetYears();
            ddlYear.DataTextField = "Text";
            ddlYear.DataValueField = "Value";
            ddlYear.DataBind();
            //ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            // *** Bindig Manufactured Years Data *** //
            ddlMfdYear.DataSource = objInBulitData.GetManufacturedYears();
            ddlMfdYear.DataTextField = "Text";
            ddlMfdYear.DataValueField = "Value";
            ddlMfdYear.DataBind();
            //ddlMfdYear.SelectedValue = DateTime.Today.Year.ToString();
            // *** Binding States *** //
            DataTable dtStates = objUtilities.GetAllStatesByCountry("USA");
            ddlStates.DataSource = dtStates;
            ddlStates.DataTextField = "State_Name";
            ddlStates.DataValueField = "State_Name";
            ddlStates.DataBind();
            ddlStates.Items.Insert(0, new ListItem("Select", ""));
            DataTable dtColors = objInBulitData.GetBulletinLabelData();
            DataRow[] drColors = dtColors.Select("Type='Color'");
            foreach (DataRow row in drColors)
            {
                ddlColors.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[2].ToString() });
            }
            ddlColors.Items.Insert(0, new ListItem("Select", ""));
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isCompleted = false;
            bool isPublish = false;
            if (rbCompleted.Checked)
                isCompleted = true;
            if (rbPublic.Checked)
                isPublish = true;
            XmlData = "<Bulletin Vehicle='" + hdnMissingVeh.Value + "' Make='" + txtMake.Text.Trim() + "'  Model='" + txtModel.Text.Trim() + "'  Style='" + txtStyle.Text.Trim() + "'  Year='" + ddlMfdYear.SelectedValue + "' Color='" + ddlColors.SelectedValue + "' State='" + ddlStates.SelectedValue + "'" +
                            "  LcsPlate='" + txtLcsPlate.Text.Trim() + "'  Marks='" + txtMarks.Text.Trim() + "'  LSMonth='" + ddlMonth.SelectedValue + "' LSDay='" + ddlDate.SelectedValue + "' LSYear='" + ddlYear.SelectedValue + "'" +
                            "  Remarks='" + txtRemarks.Text.Trim() + "' IsCall='" + chkCall.Checked + "'  IsPhoto='" + chkPhoto.Checked + "' IsContact='" + chkContact.Checked + "' IsCompleted='" + isCompleted + "' IsPublish='" + isPublish + "' ExpirationDate='" + txtExpires.Text.Trim() + "'/>";
        }
        private string BuildHTML()
        {
            string BulletinHtml = "";
            return BulletinHtml;
        }
    }
}