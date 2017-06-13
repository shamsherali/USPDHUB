using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using System.Data;
using System.Web.Services;
using System.Configuration;
using AjaxControlToolkit;

namespace USPDHUB.Business.MyAccount
{
    public partial class SurveryQuestions : BaseWeb
    {
        public string RootPath = "";
        public string DomainName = "";
        public int ProfileID = 0;
        public int UserID = 0;
        public int C_UserID = 0;
        public int SurveyID = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        SurveyBLL objSurveyBLL = new SurveyBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        DataTable dtQuestionTypes = new DataTable();
        DataTable dtQuestions = new DataTable();
        DataTable dtQuestion_Options = new DataTable();
        BusinessBLL objBus = new BusinessBLL();
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    //Log
                    objInBuiltData.ErrorHandling("LOG", "SurveryQuestions.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                    // *** Get Domain Name *** //
                    DomainName = Session["VerticalDomain"].ToString();
                    RootPath = Session["RootPath"].ToString();
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    C_UserID = UserID;
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);

                    /*** Newly Added ***/
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        /*
                        DataTable dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                        if (dtpermissions.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtpermissions.Rows.Count; i++)
                            {
                                if (dtpermissions.Rows[i]["ModuleName"].ToString() == "Surveys")
                                {
                                    if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                                        hdnPermissionType.Value = "A";
                                    if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                                        hdnPermissionType.Value = "P";
                                    break;
                                }
                            }
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                        */

                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Surveys");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            //UpdatePanel1.Visible = true;
                            //UpdatePanel3.Visible = UpdatePanel2.Visible = false;
                            //lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit contents.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;

                    }
                    /*** Newly Added ***/

                    /*** Store Module Functionality ***/
                    if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                    {
                        IsScheduleEmails = true;
                    }
                    if (!IsPostBack)
                    {
                        Session["SurveyQuestions"] = null;
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "DeleteAllBlocks()", true);
                        MaxOptions.Value = ConfigurationManager.AppSettings.Get("MaxQuestionOptions");


                        if (Request.QueryString["SurveyID"] != null)
                        {
                            Session["SurveyID"] = EncryptDecrypt.DESDecrypt(Request.QueryString["SurveyID"].ToString());
                            Session["SType"] = EncryptDecrypt.DESDecrypt(Request.QueryString["SType"].ToString());
                            ViewState["Mode"] = EncryptDecrypt.DESDecrypt(Request.QueryString["Mode"].ToString());

                            LoadQuestionTypes();
                            LoadThankYouPage();
                            //Session["MaxQuestion"] = objSurveyBLL.GetSurveyTypeMaxQuestionsCount(Convert.ToInt32(Session["ProfileID"])).ToString();

                            if (Convert.ToString(Session["CurrentQuestionNumber"]) == string.Empty)
                            {
                                Session["CurrentQuestionNumber"] = "1";
                                lblQuestionNumber.Text = Convert.ToString(Session["CurrentQuestionNumber"]);

                                if (Convert.ToInt32(Session["CurrentQuestionNumber"]) >= Convert.ToInt32(Session["MaxQuestion"]))
                                {
                                    btnSaveContnuie.Text = "Save & Exit";
                                }
                            }
                            else
                            {
                                lblQuestionNumber.Text = Convert.ToString(Session["CurrentQuestionNumber"]);
                            }

                            // Edit Mode
                            Session["QID"] = "0";
                            dtQuestions = objSurveyBLL.GetQuestionsBySurveyID(Convert.ToInt32(Session["SurveyID"]));
                            ViewState["dtQuestions"] = dtQuestions;

                            if (dtQuestions.Rows.Count > 0)
                            {
                                int totalAddQues = Convert.ToInt32(Session["CurrentQuestionNumber"]);
                                if (dtQuestions.Rows.Count < totalAddQues)
                                {
                                    Session["CurrentQuestionNumber"] = (Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1).ToString();
                                    Previuos_NextQuestions(1);
                                    LoadHTMLTable(0, Convert.ToInt32(ConfigurationManager.AppSettings.Get("MinQuestionOptions")));
                                }
                                else
                                {
                                    // Survey Validaion Rules
                                    if (dtQuestions.Rows[totalAddQues - 1]["IsRequired"] != null)
                                    {
                                        chkRequire.Checked = Convert.ToBoolean(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["IsRequired"]);
                                    }
                                    if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Error_Message"] != null)
                                    {
                                        txtChoiceErrorMessage.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Error_Message"]);
                                        FillErrorMessage();
                                    }
                                    if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"] != null)
                                    {
                                        //ddlAnswerCheckType.SelectedValue = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"]);
                                        AssignCheckAnswerType(Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"]));

                                    }
                                    if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckCount"] != null)
                                    {
                                        txtAnswesCheckCount.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckCount"]);
                                    }

                                    // Edit Questions & Answers
                                    txtQuestionName.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Text"]);
                                    Session["QID"] = dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Question_ID"];
                                    rbList.SelectedValue = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["QTypeID"]);
                                    LoadHTMLTable(Convert.ToInt32(Session["QID"]), Convert.ToInt32(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Type_NameNumber"]));
                                    // Delete Present Question
                                    //btnDeleteQuesion.Visible = true;
                                    btnDeleteQuesion.Style["display"] = "block";
                                    btnSkip.Style["display"] = "block";
                                }
                            }

                            else
                            {
                                // New Question & Answers
                                LoadHTMLTable(0, Convert.ToInt32(ConfigurationManager.AppSettings.Get("MinQuestionOptions")));
                            }

                            Show_HideControls();
                        }
                    }
                    lblPublish.Text = hdnPublishTitle.Value;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SetExpireDate()
        {
            try
            {
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                txtExpiryDate.Text = dtToday.AddMonths(1).ToShortDateString();
                ExpiryTimeControl1.Enabled = true;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "SetExpireDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadThankYouPage()
        {
            try
            {
                ExpiryTimeControl1.Enabled = false;
                DataTable dtSurveyDetails = objSurveyBLL.GetSurveyDetailsByID(Convert.ToInt32(Session["SurveyID"]));
                txtthanksMessage.Text = Convert.ToString(dtSurveyDetails.Rows[0]["Thanks_Message"]);               

                if (!string.IsNullOrEmpty(dtSurveyDetails.Rows[0]["Expiration_Date"].ToString()))
                {
                    DateTime expiryTime = Convert.ToDateTime(dtSurveyDetails.Rows[0]["Expiration_Date"]);
                    txtExpiryDate.Text = expiryTime.ToShortDateString();
                    ExpiryTimeControl1.Enabled = true;
                    ExpiryTimeControl1.SelectedTime = expiryTime.ToShortTimeString();
                }
                if (Convert.ToBoolean(dtSurveyDetails.Rows[0]["IsPrivate"].ToString()) == true)
                {
                    rbPrivate.Checked = true;
                    divpublish.Style.Add("display", "none");
                }
                else
                {
                    rbPublic.Checked = true;
                    if (IsScheduleEmails)
                        divpublish.Style.Add("display", "block");
                }
                DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                if (!string.IsNullOrEmpty(dtSurveyDetails.Rows[0]["Publish_Date"].ToString()))
                {
                    DateTime dtPublish = Convert.ToDateTime(dtSurveyDetails.Rows[0]["Publish_Date"]);
                    if (DateTime.Compare(dtPublish, dtNow) < 0)
                        txtPublishDate.Text = dtNow.ToShortDateString();
                    else
                        txtPublishDate.Text = dtPublish.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "LoadThankYouPage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadHTMLTable(int QID, int QTypeNumber)
        {
            try
            {
                // Display Previuos List
                PreviewQuestionList();
                // Show / Hide Back button
                Show_Hide_BackButton();

                var newRowText = "";
                if (QID > 0)
                {
                    dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(Session["QID"]));
                    for (int i = 0; i < dtQuestion_Options.Rows.Count; i++)
                    {
                        newRowText = newRowText + "&yen;" + Convert.ToString(dtQuestion_Options.Rows[i]["Answer_Option"]);
                    }
                    //

                    if (QTypeNumber != 3)
                    {
                        if (dtQuestion_Options.Rows.Count > 0)
                        {
                            hdnAnswers.Value = newRowText;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>AddEditTextBoxes('" + dtQuestion_Options.Rows.Count + "')</script>", false);
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "AddEditTextBoxes('" + dtQuestion_Options.Rows.Count + "')", true);
                        }
                        else
                        {
                            hdnAnswers.Value = "&yen;&yen;";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')</script>", false);
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);
                        }
                    }
                    else
                    {
                        hdnAnswers.Value = "&yen;&yen;";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')</script>", false);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);
                    }
                }
                else
                {
                    hdnAnswers.Value = "&yen;&yen;";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')</script>", false);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('1')", true);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "LoadHTMLTable", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadQuestionTypes()
        {
            try
            {
                dtQuestionTypes = objSurveyBLL.GetQuestionTypes(Convert.ToString(Session["SType"]));
                rbList.DataSource = dtQuestionTypes;
                rbList.DataTextField = "Type_Name";
                rbList.DataValueField = "QType_ID";
                rbList.DataBind();

                if (Convert.ToString(Session["SType"]) == "Poll")
                {
                    if (dtQuestionTypes.Rows.Count > 0)
                    {
                        rbList.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "LoadQuestionTypes", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Show_HideControls()
        {
            try
            {
                if (Convert.ToString(Session["SType"]) == "Poll")
                {
                    lblPollQuestion.Visible = true;
                    lblSurveyQuestion.Visible = false;
                    btnSaveContnuie.Text = "Submit";
                    //btnFinish.Visible = false;
                    btnFinish.Style["display"] = "none";
                    lblPollTitle.Visible = true;
                    lblSurveyTitle.Visible = false;
                    lblQuestionNumber.Visible = false;

                    lblQuestionType.Visible = false;
                }
                else
                {
                    lblPollQuestion.Visible = false;
                    lblSurveyQuestion.Visible = true;
                    lblQuestionNumber.Visible = true;
                    lblPollTitle.Visible = false;
                    lblSurveyTitle.Visible = true;

                    lblQuestionType.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "Show_HideControls", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSaveContnuie_Click(object sender, EventArgs e)
        {
            try
            {
                SaveQuestionDetails(0); // *** 0 means will navigate to next question *** //
                if (Convert.ToInt32(Session["CurrentQuestionNumber"]) >= Convert.ToInt32(Session["MaxQuestion"]))
                {
                    Panel1.Attributes.Add("style", "display:none");
                    Panel2.Attributes.Add("style", "display:block");
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "btnSaveContnuie_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public bool SaveQuestionDetails(int isNext)
        {

            lblerror.Text = "";
            var IsSucess = true;
            var optionText = "";

            int questionID = Convert.ToInt32(HttpContext.Current.Session["QID"]);
            int userID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            int surveyID = Convert.ToInt32(HttpContext.Current.Session["SurveyID"]);
            // Insert Question
            questionID = objSurveyBLL.Insert_Update_Questions(questionID, txtQuestionName.Text, Convert.ToInt32(rbList.SelectedValue), surveyID, userID,
                chkRequire.Checked, txtChoiceErrorMessage.Text.Trim(), ddlAnswerCheckType.SelectedValue.ToString(), txtAnswesCheckCount.Text.Trim());
            // Answers
            optionText = hdnAnswers.Value;

            if (questionID > 0)
            {
                // Delete Answers by QID
                objSurveyBLL.DeleteQuesionOptions(questionID);

                if (optionText.StartsWith("&yen;"))
                {
                    optionText = optionText.Substring(5).Trim();
                }
                if (optionText != string.Empty)
                {
                    var Value = optionText.Split(new string[] { "&yen;" }, StringSplitOptions.None);
                    for (int i = 0; i < Value.Count(); i++)
                    {
                        string option = Value[i].ToString();
                        option = option.Replace("&amp;", "&");
                        option = option.Replace("&apos;", "'");
                        objSurveyBLL.InsertAnswerOptions(questionID, surveyID, option, (i + 1), userID);
                    }
                }
                if (isNext == 0)
                    Previuos_NextQuestions(0);
                IsSucess = true;
            }
            else
            {
                IsSucess = false;
                lblerror.Text = "<span style='color:red;'>Sorry, you already have a question with this name; please enter another name.</span>";

                if (dtQuestions.Rows.Count >= Convert.ToInt32(Session["CurrentQuestionNumber"]))
                {
                    btnDeleteQuesion.Style["display"] = "block";
                    dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(Session["QID"]));
                }
                else
                {
                    btnDeleteQuesion.Style["display"] = "none";
                    // New Question & Answers
                    Session["QID"] = "0";
                }

                #region Create Answer Textboxes

                // Checking Answers 
                if (optionText.StartsWith("&yen;"))
                {
                    optionText = optionText.Substring(5).Trim();
                }
                if (optionText != string.Empty)
                {
                    var Value = optionText.Split(new string[] { "&yen;" }, StringSplitOptions.None);
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + Value.Count() + "')", true);
                }
                else
                {
                    hdnAnswers.Value = "&yen;&yen;";
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);
                }

                #endregion
            }

            // Display Previuos List
            if (isNext == 0)
                PreviewQuestionList();

            return IsSucess;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx");
            HttpContext.Current.Response.Redirect(urlinfo);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Delete Questions & Options
                objSurveyBLL.DeleteQuestion(Convert.ToInt32(Session["QID"]));
                Session["QID"] = 0;

                dtQuestions = objSurveyBLL.GetQuestionsBySurveyID(Convert.ToInt32(Session["SurveyID"]));
                ViewState["dtQuestions"] = dtQuestions;

                Session["CurrentQuestionNumber"] = (Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1).ToString();
                Previuos_NextQuestions(0);
                PreviewQuestionList();
                Show_HideControls();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "btnDelete_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Previuos_NextQuestions(int loadtype)
        {
            lblerror.Text = "";

            try
            {
                if (Convert.ToInt32(Session["CurrentQuestionNumber"]) >= Convert.ToInt32(Session["MaxQuestion"]))
                {
                    //Session["CurrentQuestionNumber"] = "";
                    Panel1.Attributes.Add("style", "display:none");
                    Panel2.Attributes.Add("style", "display:block");
                    //string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx");
                    //HttpContext.Current.Response.Redirect(urlinfo);
                }
                else
                {
                    Session["CurrentQuestionNumber"] = (Convert.ToInt32(Session["CurrentQuestionNumber"]) + 1).ToString();
                    lblQuestionNumber.Text = Convert.ToString(Session["CurrentQuestionNumber"]);
                    txtQuestionName.Text = "";

                    dtQuestions = (DataTable)ViewState["dtQuestions"];
                    var newRowText = "";
                    if (dtQuestions.Rows.Count >= Convert.ToInt32(Session["CurrentQuestionNumber"]))
                    {
                        btnDeleteQuesion.Style["display"] = "block";
                        btnSkip.Style["display"] = "block";

                        // Survey Validaion Rules
                        ValidationControlsDataClear();
                        if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["IsRequired"] != null)
                        {
                            chkRequire.Checked = Convert.ToBoolean(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["IsRequired"]);
                        }
                        if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Error_Message"] != null)
                        {
                            txtChoiceErrorMessage.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Error_Message"]);
                            FillErrorMessage();
                        }
                        if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"] != null)
                        {
                            //ddlAnswerCheckType.SelectedValue = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"]);
                            AssignCheckAnswerType(Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"]));
                        }
                        if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckCount"] != null)
                        {
                            txtAnswesCheckCount.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckCount"]);
                        }

                        //Edit Question & Answers
                        txtQuestionName.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Text"]);
                        Session["QID"] = dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Question_ID"];
                        rbList.SelectedValue = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["QTypeID"]);

                        dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(Session["QID"]));
                        for (int i = 0; i < dtQuestion_Options.Rows.Count; i++)
                        {
                            newRowText = newRowText + "&yen;" + Convert.ToString(dtQuestion_Options.Rows[i]["Answer_Option"]);
                        }
                        //
                        if (dtQuestion_Options.Rows.Count > 0)
                        {
                            hdnAnswers.Value = newRowText;
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + dtQuestion_Options.Rows.Count + "')", true);
                        }
                        else
                        {
                            hdnAnswers.Value = "&yen;&yen;";
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);

                        }

                        if (Convert.ToInt32(Session["CurrentQuestionNumber"]) >= Convert.ToInt32(Session["MaxQuestion"]))
                        {
                            btnSaveContnuie.Text = "Save & Exit";
                            btnFinish.Style["display"] = "none";
                            btnSkip.Style["display"] = "none";
                        }
                        else
                        {
                            btnSaveContnuie.Text = "Save & Continue";
                            btnFinish.Style["display"] = "block";
                            btnSkip.Style["display"] = "block";
                        }

                        // Fill Validation Rules Data

                    }
                    else
                    {
                        if (Convert.ToInt32(Session["CurrentQuestionNumber"]) >= Convert.ToInt32(Session["MaxQuestion"]))
                        {
                            btnSaveContnuie.Text = "Save & Exit";
                            btnFinish.Style["display"] = "none";
                            btnSkip.Style["display"] = "none";
                        }
                        else
                        {
                            btnSaveContnuie.Text = "Save & Continue";
                            btnFinish.Style["display"] = "block";
                            btnSkip.Style["display"] = "block";
                        }

                        btnDeleteQuesion.Style["display"] = "none";
                        btnSkip.Style["display"] = "none";

                        ValidationControlsDataClear();
                        // New Question & Answers
                        Session["QID"] = "0";
                        hdnAnswers.Value = "&yen;&yen;";
                        rbList.SelectedIndex = -1;
                        if (loadtype == 0)
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);
                    }
                    Show_Hide_BackButton();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "Previuos_NextQuestions", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnFinish_OnClick(object sender, EventArgs e)
        {
            if (SaveQuestionDetails(1)) // *** 1 means will finish and navigate to thank you page *** //
            {
                PreviewQuestionList();
                Panel1.Attributes.Add("style", "display:none");
                Panel2.Attributes.Add("style", "display:block");
            }
            //if (SaveQuestionDetails())
            //{
            //    Session["CurrentQuestionNumber"] = "";
            //    string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx");
            //    HttpContext.Current.Response.Redirect(urlinfo);
            //}
            /*else
            {
                var newRowText = "";
                if (dtQuestions.Rows.Count >= Convert.ToInt32(Session["CurrentQuestionNumber"]))
                {
                    btnDeleteQuesion.Visible = true;
                    //btnFinish.Visible = true;
                    dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(Session["QID"]));
                    for (int i = 0; i < dtQuestion_Options.Rows.Count; i++)
                    {
                        newRowText = newRowText + "&yen;" + Convert.ToString(dtQuestion_Options.Rows[i]["Answer_Option"]);
                    }
                    //
                    hdnAnswers.Value = newRowText;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + dtQuestion_Options.Rows.Count + "')", true);

                }
                else
                {
                    btnDeleteQuesion.Visible = false;
                    //btnFinish.Visible = false;
                    // New Question & Answers
                    Session["QID"] = "0";
                    //LoadHTMLTable(0);
                    hdnAnswers.Value = "&yen;&yen;";
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + ConfigurationManager.AppSettings.Get("MinQuestionOptions") + "')", true);
                }
            }
            */
        }

        protected void btnSkip_OnClick(object sender, EventArgs e)
        {
            Previuos_NextQuestions(0);
        }

        public void PreviewQuestionList()
        {
            try
            {
                dtQuestions = objSurveyBLL.GetQuestionsBySurveyID(Convert.ToInt32(Session["SurveyID"]));
                Session["SurveyQuestions"] = dtQuestions;
                string htmlTags = "";

                for (int i = 0; i < dtQuestions.Rows.Count; i++)
                {
                    // Question Names
                    htmlTags = htmlTags + "<h3 style='margin: 0px; font-weight:bold;' ><a href='#' onclick='javascript:CallPreviuosQuestionDetails(" + (i + 1) + ")'>" + Convert.ToString(dtQuestions.Rows[i]["Text"]) + "</a></h3>";

                    // Question Options
                    dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestions.Rows[i]["Question_ID"]));
                    string para = "";
                    for (int j = 0; j < dtQuestion_Options.Rows.Count; j++)
                    {
                        para = para + "<p style='margin:0px;'>" + (j + 1) + ". " + Convert.ToString(dtQuestion_Options.Rows[j]["Answer_Option"]) + "</p>";
                    }
                    para = "<div style='margin: 0px;'>" + para + "</div>";
                    htmlTags = htmlTags + para;
                }
                Panel2.Attributes.Add("style", "display:none");
                Panel1.Attributes.Add("style", "display:block");
                htmlTags = "<div id='accordion' style='width: 300px;'>" + htmlTags + "</div>";
                htmlTags = @"<link href=""../../css/accordion/jquery.ui.all.css"" rel=""stylesheet"" type=""text/css"" />
                        <link href=""../../css/accordion/jquery.ui.accordion.css"" rel=""stylesheet"" type=""text/css"" />
                        <link href=""../../css/accordion/jquery-ui.css"" rel=""stylesheet"" type=""text/css"" />" + htmlTags;
                lblQuestionPreview.Text = string.Empty;
                lblQuestionPreview.Text = htmlTags;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "PreviewQuestionList", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        // Show / Hide Back button
        private void Show_Hide_BackButton()
        {
            try
            {
                if (Convert.ToInt32(Session["CurrentQuestionNumber"]) > 1)
                {
                    btnBack.Style["display"] = "block";
                }
                else
                {
                    btnBack.Style["display"] = "none";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "Show_Hide_BackButton", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            try
            {
                // Display Previuos List
                PreviewQuestionList();
                Session["CurrentQuestionNumber"] = (Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1).ToString();
                lblQuestionNumber.Text = Convert.ToString(Session["CurrentQuestionNumber"]);
                txtQuestionName.Text = "";
                // btnFinish.Visible = true;

                // Survey Validaion Rules
                if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["IsRequired"] != null)
                {
                    chkRequire.Checked = Convert.ToBoolean(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["IsRequired"]);
                }
                if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Error_Message"] != null)
                {
                    txtChoiceErrorMessage.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Error_Message"]);
                    FillErrorMessage();
                }
                if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"] != null)
                {
                    //ddlAnswerCheckType.SelectedValue = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"]);
                    AssignCheckAnswerType(Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckType"]));
                }
                if (dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckCount"] != null)
                {
                    txtAnswesCheckCount.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Answers_CheckCount"]);
                }


                //Edit Question & Answers
                txtQuestionName.Text = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Text"]);
                Session["QID"] = dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["Question_ID"];
                rbList.SelectedValue = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(Session["CurrentQuestionNumber"]) - 1]["QTypeID"]);

                dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(Session["QID"]));
                var newRowText = "";
                for (int i = 0; i < dtQuestion_Options.Rows.Count; i++)
                {
                    newRowText = newRowText + "&yen;" + Convert.ToString(dtQuestion_Options.Rows[i]["Answer_Option"]);
                }
                //
                hdnAnswers.Value = newRowText;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + dtQuestion_Options.Rows.Count + "')", true);
                Panel2.Attributes.Add("style", "display:none");
                Panel1.Attributes.Add("style", "display:block");
                btnSaveContnuie.Text = "Save & Continue";
                btnFinish.Style["display"] = "block";
                btnDeleteQuesion.Style["display"] = "block";
                btnSkip.Style["display"] = "block";

                Show_Hide_BackButton();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "btnBack_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void ValidationControlsDataClear()
        {
            chkRequire.Checked = false;
            txtChoiceErrorMessage.Text = "";
            txtAnswesCheckCount.Text = "";
            ddlAnswerCheckType.SelectedIndex = 0;
            FillErrorMessage();
        }

        private void AssignCheckAnswerType(string value)
        {
            if (value == "at least" || value == "")
            {
                ddlAnswerCheckType.SelectedValue = "1";
            }
            else if (value == "at most")
            {
                ddlAnswerCheckType.SelectedValue = "2";
            }
            else if (value == "exactly")
            {
                ddlAnswerCheckType.SelectedValue = "3";
            }
            else
            {
                ddlAnswerCheckType.SelectedValue = value;
            }

        }

        [WebMethod]
        public static string[] CallPreviuosQuestionDetails(int CQNumber)
        {
            string[] result = new string[5];
            try
            {
                if (HttpContext.Current.Session["SurveyQuestions"] != null)
                {
                    SurveyBLL objSurveyBLL = new SurveyBLL();
                    DataTable dtQuestions = (DataTable)HttpContext.Current.Session["SurveyQuestions"];
                    HttpContext.Current.Session["CurrentQuestionNumber"] = CQNumber;
                    HttpContext.Current.Session["QID"] = dtQuestions.Rows[Convert.ToInt32(HttpContext.Current.Session["CurrentQuestionNumber"]) - 1]["Question_ID"];

                    string answersText = "";
                    DataTable dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(HttpContext.Current.Session["QID"]));
                    for (int i = 0; i < dtQuestion_Options.Rows.Count; i++)
                    {
                        answersText = answersText + "&yen;" + Convert.ToString(dtQuestion_Options.Rows[i]["Answer_Option"]);
                    }

                    int editQuestionCount = dtQuestion_Options.Rows.Count;
                    string QName = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(HttpContext.Current.Session["CurrentQuestionNumber"]) - 1]["Text"]);
                    //Question Number
                    result[0] = CQNumber.ToString();
                    // Question Name
                    result[1] = QName;
                    // Questions Answers Count
                    if (Convert.ToString(dtQuestions.Rows[Convert.ToInt32(HttpContext.Current.Session["CurrentQuestionNumber"]) - 1]["Type_NameNumber"]) != "3")
                    {
                        result[2] = dtQuestion_Options.Rows.Count.ToString();
                    }
                    else
                    {
                        result[2] = ConfigurationManager.AppSettings.Get("MinQuestionOptions");
                    }
                    //Question ANswerts Options values
                    result[3] = answersText;
                    //Selected QType
                    result[4] = Convert.ToString(dtQuestions.Rows[Convert.ToInt32(HttpContext.Current.Session["CurrentQuestionNumber"]) - 1]["QTypeID"]);

                }
            }
            catch (Exception ex)
            {
                //Error 
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "SurveryQuestions.aspx.cs", "CallPreviuosQuestionDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return result;
        }

        private void FillErrorMessage()
        {
            if (txtChoiceErrorMessage.Text.Trim() == string.Empty)
            {
                txtChoiceErrorMessage.Text = hdnChoiceErrorMessage.Value;
            }
        }


        protected void btnSaveContinuePanel2_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmitPanel2_OnClick(object sender, EventArgs e)
        {
            try
            {
                SurveyDetails surveyInfo = (SurveyDetails)Session["SurveyInfo"];
                DateTime? datePublish;
                DateTime? ExpiryDate;
                datePublish = null;
                ExpiryDate = null;
                bool addflag = true;

                bool IsPublish = true;
                bool IsPrivate = true;

                ExpiryDate = null;
                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";

                int? id = null;
                if (rbPublic.Checked)
                    IsPublish = false;
                else
                    IsPrivate = false;

                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);

                if (txtExpiryDate.Text.Trim() != string.Empty)
                {
                    exTime = ExpiryTimeControl1.SelectedTime;
                    ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text.Trim() + " " + exTime);
                    if (ExpiryDate < dtToday)
                    {
                        lblerror.Text = "<span style='color:red;'>Expiration date should be equal or later than current date.</span>";
                        txtExpiryDate.Focus();
                        addflag = false;
                    }
                }

                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        txtPublishDate.Focus();
                        addflag = false;
                    }
                }

                if (addflag)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //A for author
                        {
                            SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                                Convert.ToInt32(Session["UserID"]), surveyInfo.SurveyName, surveyInfo.SurveyDescription, surveyInfo.SurveyType,
                                txtthanksMessage.Text.Trim(), ExpiryDate, false, datePublish, id, IsPublish, C_UserID);
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), SurveyID, PageNames.SURVEY, UserID, Session["username"].ToString(), PageNames.SURVEY, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            if (IsPrivate == true)
                                SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                               Convert.ToInt32(Session["UserID"]), surveyInfo.SurveyName, surveyInfo.SurveyDescription, surveyInfo.SurveyType,
                               txtthanksMessage.Text.Trim(), ExpiryDate, IsPrivate, datePublish, C_UserID, IsPublish, C_UserID);
                            else
                                SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                               Convert.ToInt32(Session["UserID"]), surveyInfo.SurveyName, surveyInfo.SurveyDescription, surveyInfo.SurveyType,
                               txtthanksMessage.Text.Trim(), ExpiryDate, IsPrivate, datePublish, id, IsPublish, C_UserID);
                        }
                    }
                    else
                    {
                        if (IsPrivate == true)
                            SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                                Convert.ToInt32(Session["UserID"]), surveyInfo.SurveyName, surveyInfo.SurveyDescription, surveyInfo.SurveyType,
                                txtthanksMessage.Text.Trim(), ExpiryDate, IsPrivate, datePublish, C_UserID, IsPublish, C_UserID);
                        else
                            SurveyID = objSurveyBLL.Insert_Update_Survey(Convert.ToInt32(Session["SurveyID"]), Convert.ToInt32(Session["ProfileID"]),
                               Convert.ToInt32(Session["UserID"]), surveyInfo.SurveyName, surveyInfo.SurveyDescription, surveyInfo.SurveyType,
                               txtthanksMessage.Text.Trim(), ExpiryDate, IsPrivate, datePublish, id, IsPublish, C_UserID);
                    }
                    if (SurveyID < 0)
                    {
                        lblerror.Text = "<span style='color:red;'>Sorry, you already have a survey with this name; please enter another name.</span>";
                    }
                    else
                    {
                        Session["CurrentQuestionNumber"] = "";
                        System.Web.HttpContext.Current.Session["SurveySuccess"] = "";
                        if (Convert.ToString(Session["SurveyID"]) == "0")
                        {
                            System.Web.HttpContext.Current.Session["SurveySuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", surveyInfo.SurveyName);
                            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx");
                            HttpContext.Current.Response.Redirect(urlinfo);
                        }
                        else
                        {
                            System.Web.HttpContext.Current.Session["SurveySuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", surveyInfo.SurveyName);
                            string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx");
                            HttpContext.Current.Response.Redirect(urlinfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyQuestions.aspx.cs", "btnSubmitPanel2_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnBackPanel2_Click(object sender, EventArgs e)
        {
            try
            {
                /*back **/
                // Display Previuos List
                PreviewQuestionList();
                int queNo = Convert.ToInt32(Session["CurrentQuestionNumber"]);
                lblQuestionNumber.Text = Convert.ToString(queNo);
                txtQuestionName.Text = "";
                // btnFinish.Visible = true;
                queNo = queNo - 1;
                // Survey Validaion Rules
                if (dtQuestions.Rows[queNo]["IsRequired"] != null)
                {
                    chkRequire.Checked = Convert.ToBoolean(dtQuestions.Rows[queNo]["IsRequired"]);
                }
                if (dtQuestions.Rows[queNo]["Error_Message"] != null)
                {
                    txtChoiceErrorMessage.Text = Convert.ToString(dtQuestions.Rows[queNo]["Error_Message"]);
                    FillErrorMessage();
                }
                if (dtQuestions.Rows[queNo]["Answers_CheckType"] != null)
                {
                    AssignCheckAnswerType(Convert.ToString(dtQuestions.Rows[queNo]["Answers_CheckType"]));
                }
                if (dtQuestions.Rows[queNo]["Answers_CheckCount"] != null)
                {
                    txtAnswesCheckCount.Text = Convert.ToString(dtQuestions.Rows[queNo]["Answers_CheckCount"]);
                }


                //Edit Question & Answers
                txtQuestionName.Text = Convert.ToString(dtQuestions.Rows[queNo]["Text"]);
                Session["QID"] = dtQuestions.Rows[queNo]["Question_ID"];
                rbList.SelectedValue = Convert.ToString(dtQuestions.Rows[queNo]["QTypeID"]);

                dtQuestion_Options = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(Session["QID"]));
                var newRowText = "";
                for (int i = 0; i < dtQuestion_Options.Rows.Count; i++)
                {
                    newRowText = newRowText + "&yen;" + Convert.ToString(dtQuestion_Options.Rows[i]["Answer_Option"]);
                }
                //
                hdnAnswers.Value = newRowText;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "AddEditTextBoxes('" + dtQuestion_Options.Rows.Count + "')", true);
                btnSaveContnuie.Text = "Save & Continue";
                btnFinish.Style["display"] = "block";
                btnDeleteQuesion.Style["display"] = "block";
                btnSkip.Style["display"] = "block";

                Show_Hide_BackButton();
                /*************************/
                Panel2.Attributes.Add("style", "display:none");
                Panel1.Attributes.Add("style", "display:block");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SurveyQuestions.aspx.cs", "btnBackPanel2_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}
