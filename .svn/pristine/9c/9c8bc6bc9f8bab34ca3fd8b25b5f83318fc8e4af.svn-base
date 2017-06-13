using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageSmartConnectCategories : BaseWeb
    {
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
        public string Permission_Type = string.Empty;
        public int Permission_Value = 0;

        public DataTable dtCategories = new DataTable();
        public int CustomModuleId = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (Session["CustomModuleID"] == null)
                {
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
                }
                else
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());


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
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnCategoryPermission.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "SmartConnectCategories");

                        if (hdnCategoryPermission.Value == "A" || string.IsNullOrEmpty(hdnCategoryPermission.Value))
                        {
                            UpdatePanel1.Visible = false;
                            UpdatePanel2.Visible = true;
                            lblerrormsg.Text = "<font face=arial size=3>" + Resources.LabelMessages.SmartConnectCategoryPermission + "</font>";
                        }
                    }
                    //  Hdn control for Sorting
                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";

                    BindCategories();

                    if (Session["Success"] != null)
                    {
                        lblmess.Text = Session["Success"].ToString();
                        Session.Remove("Success");
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageWeblinksCategory.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindCategories()
        {
            try
            {
                hdnCommandArg.Value = "";
                dtCategories = objBus.GetSmartConnectCategories(CustomModuleId, DomainName, ProfileID);
                GrdCategories.DataSource = dtCategories;
                GrdCategories.DataBind();

                Session["dtCategories"] = dtCategories;
                hdnShowButtons.Value = "1";

                if (dtCategories.Rows.Count == 0)
                    hdnShowButtons.Value = "";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSmartConnectCategories.aspx.cs", "BindCategories()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtCategories = (DataTable)Session["dtCategories"];
                GrdCategories.PageIndex = e.NewPageIndex;
                GrdCategories.DataSource = dtCategories;
                GrdCategories.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSmartConnectCategories.aspx.cs", "GrdCategories_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdCategories_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtCategories = (DataTable)Session["dtCategories"];
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
                DataView Dv = new DataView(dtCategories);
                if (SortDir == 0)
                {
                    if (SortExp == "CategoryName")
                    {
                        Dv.Sort = "CategoryName desc";
                    }
                    else if (SortExp == "CreatedDate")
                    {
                        Dv.Sort = "CreatedDate desc";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "CategoryName")
                    {
                        Dv.Sort = "CategoryName ASC";
                    }
                    else if (SortExp == "CreatedDate")
                    {
                        Dv.Sort = "CreatedDate ASC";
                    }
                    hdnsortcount.Value = "0";
                }
                Session["dtCategories"] = Dv.ToTable();
                GrdCategories.DataSource = Dv;
                GrdCategories.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSmartConnectCategories.aspx.cs", "GrdCategories_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManagePublicCallIndexAddOns.aspx"));
        }

        protected void rbWeblinkCategory_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnkTitle = (LinkButton)row.FindControl("lnkName");
            hdnCommandArg.Value = lnkTitle.CommandArgument;
        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            lblmess.Text = "";
            hdnCommandArg.Value = "0";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
            lbleditext.Text = "";
            mpeWebLink.Show();
        }


        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                GetCategoryDetails();
            }
        }

        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            try
            {
                objBus.DeleteSmartConnectCategory(Convert.ToInt32(hdnCommandArg.Value), UserID, ProfileID);
                hdnCommandArg.Value = "";
                BindCategories();
                lblmess.Text = "<font size='3'>Your category has been deleted successfully.</font>";
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "SmartConnectCategory", "Delete");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSmartConnectCategories.aspx.cs", "lnkdelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        // Modal Popup Events


        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                lbleditext.Text = "";
                int categoryID = 0;
                if (hdnCommandArg.Value.ToString().Trim() != string.Empty)
                    categoryID = Convert.ToInt32(hdnCommandArg.Value);

                int result = objBus.Insert_Update_SmartConnectCategory(categoryID, txtCategoryName.Text.Trim(), txtDescription.Text.Trim(), CustomModuleId, ProfileID, UserID, SmartConnectCategoryType.User.ToString());

                if (result == -1)
                {
                    lbleditext.Text = "Sorry, you already have a category with this name; please enter another name.";
                    mpeWebLink.Show();
                }
                else
                {
                    if (categoryID == 0)
                    {
                        lblmess.Text = "Category has been saved successfully.";
                        objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "SmartConnectCategory", "Create");
                    }
                    else
                    {
                        lblmess.Text = "Category has been updated successfully.";
                        objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "SmartConnectCategory", "Update");
                    }
                    BindCategories();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSmartConnectCategories.aspx.cs", "btnSumbit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            //Session["UpdateSuccess"] = "Update has been updated successfully.";
        }

        private void GetCategoryDetails()
        {
            try
            {
                lblmess.Text = "";
                lbleditext.Text = "";


                mpeWebLink.Show();
                var dtDetails = objBus.GetSmartConnectCategoryDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
                txtCategoryName.Text = Convert.ToString(dtDetails.Rows[0]["CategoryName"]);
                txtDescription.Text = Convert.ToString(dtDetails.Rows[0]["Description"]);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSmartConnectCategories.aspx.cs", "GetCategoryDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ImcloseClick(object sender, ImageClickEventArgs e)
        {

        }

    }
}