using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class RequestCustomForm : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBus = new BusinessBLL();

        public string RequestCustomFormType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["Type"] != null)
                        {
                            // Custom Type like Custom Module OR Bulletin Custom Form OR Logo Customization from CheckStore.aspx
                            RequestCustomFormType = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["Type"]));
                        }

                        UserID = Convert.ToInt32(Session["userid"].ToString());
                        ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "RequestCustomForm.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

                string description = txtDescription.Text.Trim();
                string remarks = txtRemarks.Text.Trim();

                int _resultID = objBus.Insert_RequestCustomFormDetails(description, remarks, RequestCustomFormType, ProfileID, UserID);


                txtDescription.Text = "";
                txtRemarks.Text = "";
                lblMessage.Text = "<span style='color:green;'> Your Request Details is Successfully Saved. </span>";
                //Response.Redirect("ThankYou.aspx?Type=" + Request.QueryString["Type"].ToString());
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "RequestCustomForm.aspx.cs", "btnSubmit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckStore.aspx");
        }
    }
}