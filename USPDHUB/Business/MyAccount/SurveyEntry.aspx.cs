using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;

namespace USPDHUB.Business.MyAccount
{
    public partial class SurveyEntry : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public string RootPath = "";
        public string DomainName = "";

        SurveyBLL objSurveyBLL = new SurveyBLL();
        CommonBLL objCommon = new CommonBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        public int SurveyID = 0;
        public int C_UserID = 0;
        public string urlinfo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "SurveyEntry.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();

                if (Session["userid"] == null || Session["ProfileID"] == null)
                {
                    urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);

                if (!IsPostBack)
                {
                    DataTable dtpermissions = new DataTable();
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Surveys");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel3.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create survey.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here


                    Session["SurveyID"] = "0";

                    DataTable dtSurveyTypes = objSurveyBLL.GetSurveyTypes();
                    /*
                    ddlSurveyTypes.DataSource = dtSurveyTypes;
                    ddlSurveyTypes.DataTextField = "Type_Name";
                    ddlSurveyTypes.DataValueField = "STypeID";
                    ddlSurveyTypes.DataBind();
                     
                    if (dtSurveyTypes.Rows.Count > 0)
                    {
                        rbSurveyTypes.SelectedIndex = 0;
                    }
                    */
                    DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    // now
                    //txtExpiryDate.Text = dtToday.AddMonths(1).ToShortDateString();
                    //txtExHours.Enabled = true;
                    //txtExMinutes.Enabled = true;
                    //ddlExSS.Enabled = true;
                    if (Request.QueryString["SurveyID"] != null)
                    {
                        Session["SurveyID"] = EncryptDecrypt.DESDecrypt(Request.QueryString["SurveyID"].ToString());
                        SurveyID = Convert.ToInt32(Session["SurveyID"]);
                        LoadSurveyDetails();
                        btnSkip.Visible = true;
                        //ddlSurveyTypes.Enabled = false;
                        rbSurvey.Enabled = false;
                        rbPoll.Enabled = false;
                    }
                }
                //now
                //lblPublish.Text = hdnPublishTitle.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyEntry.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void LoadSurveyDetails()
        {
            try
            {
                DataTable dtSurveyDetails = objSurveyBLL.GetSurveyDetailsByID(Convert.ToInt32(Session["SurveyID"]));
                txtSurveyName.Text = Convert.ToString(dtSurveyDetails.Rows[0]["Name"]);
                txtDescription.Text = Convert.ToString(dtSurveyDetails.Rows[0]["Description"]);
                //ddlSurveyTypes.SelectedValue = Convert.ToString(dtSurveyDetails.Rows[0]["STypeID"]);
                if (Convert.ToString(dtSurveyDetails.Rows[0]["STypeID"]) == "1")
                {
                    rbSurvey.Checked = true;
                    rbPoll.Checked = false;
                }
                else
                {
                    rbPoll.Checked = true;
                    rbSurvey.Checked = false;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyEntry.aspx.cs", "LoadSurveyDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            { //Log
                objInBuiltData.ErrorHandling("LOG", "SurveyEntry.aspx.cs", "btnSaveExit_Click", string.Empty, string.Empty, string.Empty, string.Empty);


                DateTime? datePublish;
                DateTime? ExpiryDate;
                datePublish = null;
                ExpiryDate = null;
                bool addflag = true;

                bool IsPublish = true;
                bool IsPrivate = true;
                int? id = null;
                IsPrivate = false;

                // Survey 1== Poll 2
                int STypeValue = 1;
                string STypeString = "Survey";
                if (rbSurvey.Checked)
                {
                    STypeValue = 1;
                    STypeString = "Survey";
                }
                else
                {
                    STypeValue = 2;
                    STypeString = "Poll";
                }
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);

                #region Comment
                //if (txtExpiryDate.Text.Trim() != string.Empty)
                //{
                //    if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
                //    {
                //        exHour = txtExHours.Text;
                //        if (exHour == "")
                //            exHour = "12";
                //        exMin = txtExMinutes.Text;
                //        if (exMin == "")
                //            exMin = "00";
                //        exSS = ddlExSS.SelectedValue.ToString();

                //        exTime = exHour + ":" + exMin + ":00 " + exSS;
                //    }
                //    else
                //    {
                //        exHour = "12";
                //        exMin = "00";
                //        exSS = "AM";

                //        exTime = exHour + ":" + exMin + ":00 " + exSS;
                //    }

                //    ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text.Trim() + " " + exTime);
                //    if (ExpiryDate < dtToday)
                //    {
                //        lblerror.Text = "<span style='color:red;'>Expiration date should be equal or later than current date.</span>";
                //        txtExpiryDate.Focus();
                //        addflag = false;
                //    }
                //}


                //if (txtPublishDate.Text.Trim() != "")
                //{
                //    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                //    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
                //    {
                //        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                //        txtPublishDate.Focus();
                //        addflag = false;
                //    }
                //}
                #endregion

                /*** preserving values in class for future use ***/
                SurveyDetails surveyDtls = new SurveyDetails();
                surveyDtls.SurveyName = txtSurveyName.Text;
                surveyDtls.SurveyDescription = txtDescription.Text;
                surveyDtls.SurveyType = STypeValue;
                Session["SurveyInfo"] = surveyDtls;

                if (addflag)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //A for author
                        {
                            SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                                Convert.ToInt32(Session["UserID"]), txtSurveyName.Text.Trim(), txtDescription.Text.Trim(), Convert.ToInt32(STypeValue),
                                "", ExpiryDate, false, datePublish, id, IsPublish, C_UserID);
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), SurveyID, PageNames.SURVEY, UserID, Session["username"].ToString(), PageNames.SURVEY, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            if (IsPrivate == true)
                                SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                               Convert.ToInt32(Session["UserID"]), txtSurveyName.Text.Trim(), txtDescription.Text.Trim(), Convert.ToInt32(STypeValue),
                               "", ExpiryDate, IsPrivate, datePublish, C_UserID, IsPublish, C_UserID);
                            else
                                SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                               Convert.ToInt32(Session["UserID"]), txtSurveyName.Text.Trim(), txtDescription.Text.Trim(), Convert.ToInt32(STypeValue),
                               "", ExpiryDate, IsPrivate, datePublish, id, IsPublish, C_UserID);
                        }
                    }
                    else
                    {
                        if (IsPrivate == true)
                            SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                                Convert.ToInt32(Session["UserID"]), txtSurveyName.Text.Trim(), txtDescription.Text.Trim(), Convert.ToInt32(STypeValue),
                                "", ExpiryDate, IsPrivate, datePublish, C_UserID, IsPublish, C_UserID);
                        else
                            SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                               Convert.ToInt32(Session["UserID"]), txtSurveyName.Text.Trim(), txtDescription.Text.Trim(), Convert.ToInt32(STypeValue),
                               "", ExpiryDate, IsPrivate, datePublish, id, IsPublish, C_UserID);
                    }
                    if (SurveyID < 0)
                    {
                        lblerror.Text = "<span style='color:red;'>Sorry, you already have a survey with this name; please enter another name.</span>";
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["SurveySuccess"] = "";

                        if (rbSurvey.Checked)
                            Session["MaxQuestion"] = objSurveyBLL.GetSurveyTypeMaxQuestionsCount(Convert.ToInt32(Session["ProfileID"])).ToString();
                        else
                            Session["MaxQuestion"] = ConfigurationManager.AppSettings.Get("MaxPoll");

                        if (Convert.ToString(Session["SurveyID"]) == "0")
                        {
                            System.Web.HttpContext.Current.Session["SurveySuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", txtSurveyName.Text.Trim());
                            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/SurveryQuestions.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(SurveyID.ToString()) + "&SType=" + EncryptDecrypt.DESEncrypt(STypeString) + "&Mode=" + EncryptDecrypt.DESEncrypt("New"));
                            HttpContext.Current.Response.Redirect(urlinfo);
                        }
                        else
                        {
                            System.Web.HttpContext.Current.Session["SurveySuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", txtSurveyName.Text.Trim());
                            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/SurveryQuestions.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(SurveyID.ToString()) + "&SType=" + EncryptDecrypt.DESEncrypt(STypeString) + "&Mode=" + EncryptDecrypt.DESEncrypt("Edit"));
                            HttpContext.Current.Response.Redirect(urlinfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyEntry.aspx.cs", "btnSaveExit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx");
            HttpContext.Current.Response.Redirect(urlinfo);
        }

        protected void btnSkip_OnClick(object sender, EventArgs e)
        { // Survey 1== Poll 2
            try
            {
                int STypeValue = 1;
                string STypeString = "Survey";
                if (rbSurvey.Checked)
                {
                    STypeValue = 1;
                    STypeString = "Survey";
                }
                else
                {
                    STypeValue = 2;
                    STypeString = "Poll";
                }

                /*** preserving values in class for future use ***/
                SurveyDetails surveyDtls = new SurveyDetails();
                surveyDtls.SurveyName = txtSurveyName.Text;
                surveyDtls.SurveyDescription = txtDescription.Text;
                surveyDtls.SurveyType = STypeValue;
                Session["SurveyInfo"] = surveyDtls;

                if (rbSurvey.Checked)
                    Session["MaxQuestion"] = objSurveyBLL.GetSurveyTypeMaxQuestionsCount(Convert.ToInt32(Session["ProfileID"])).ToString();
                else
                    Session["MaxQuestion"] = ConfigurationManager.AppSettings.Get("MaxPoll");
                System.Web.HttpContext.Current.Session["SurveySuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", txtSurveyName.Text.Trim());

                string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/SurveryQuestions.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(Session["SurveyID"].ToString()) + "&SType=" + EncryptDecrypt.DESEncrypt(STypeString) + "&Mode=" + EncryptDecrypt.DESEncrypt("Edit"));
                HttpContext.Current.Response.Redirect(urlinfo);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyEntry.aspx.cs", "btnSkip_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }

    public class SurveyDetails
    {
        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }
        public int SurveyType { get; set; }
    }
}