using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageDirect : System.Web.UI.Page
    {
        AddOnBLL objAddOn = new AddOnBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserID"]) == "" || Session["VerticalDomain"] == null)
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
            {
                if (Request.QueryString["Type"] != null && Convert.ToString(Request.QueryString["Type"]) == "Call")
                {
                    DataTable dtAddOn = objAddOn.GetCallIndex_Buttons(Convert.ToInt32(Session["ProfileID"]), null);
                    if (dtAddOn.Rows.Count > 0)
                    {
                        Session["CustomModuleID"] = Convert.ToString(dtAddOn.Rows[0]["UserModuleID"]);
                        Response.Redirect(Session["RootPath"].ToString() + dtAddOn.Rows[0]["ManageUrl"].ToString().Replace("ManageAddOns", "ManageCallIndexAddOns"));
                    }
                }
                else
                {
                    DataTable dtAddOn = objAddOn.GetAddOnById(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                    if (dtAddOn.Rows.Count == 1)
                    {
                        if (Convert.ToString(dtAddOn.Rows[0]["ManageUrl"]) != "" && Session["RootPath"] != null)
                        {
                            Session["CustomModuleID"] = Request.QueryString["ID"].ToString();
                            if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateCallAddOns)
                            {
                                Response.Redirect(Session["RootPath"].ToString() + dtAddOn.Rows[0]["ManageUrl"].ToString().Replace("ManageAddOns", "ManageCallIndexAddOns"));
                            }
                            else if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PublicCallAddOns)
                            {
                                Response.Redirect(Session["RootPath"].ToString() + dtAddOn.Rows[0]["ManageUrl"].ToString().Replace("ManageAddOns", "ManagePublicCallIndexAddOns"));
                            }//
                            else if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateSmartConnectAddOns)
                            {
                                Response.Redirect(Session["RootPath"].ToString() + dtAddOn.Rows[0]["ManageUrl"].ToString().Replace("ManageAddOns", "ManagePSCCallIndexAddOns"));
                            }//
                            else
                            {
                                Response.Redirect(Session["RootPath"].ToString() + dtAddOn.Rows[0]["ManageUrl"].ToString());
                            }
                        }

                    }
                }
            }
        }
    }
}