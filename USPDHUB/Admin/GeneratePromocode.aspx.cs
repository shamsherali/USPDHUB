using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using USPDHUBBLL;
using System.Configuration;

namespace USPDHUB.Admin
{
    public partial class GeneratePromocode : System.Web.UI.Page
    {
        public int AdminUserID = 0;
        USPDHUBBLL.AdminBLL objAdminBLL = new USPDHUBBLL.AdminBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        DataTable dtdomains = new DataTable();
        BusinessBLL objBus = new BusinessBLL();
        DataTable dtNewPromocodes = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string promo = "";
        DataTable dtProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] != null)
                {
                    AdminUserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }


                lblMsg.Text = "";
                if (!IsPostBack)
                {
                    //txtPercentage.Text = "0";
                    txtExpiryDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
                    hdnexpDate.Value = txtExpiryDate.Text;
                    hdnHowmany.Value = "1";
                    txtPercentage.Text = "100";
                    txtAmount.Text = "";
                    // *** Gettting Active Verticals *** //
                    dtdomains = agencyobj.GetDomainVerticals();
                    ddlDomains.DataSource = dtdomains;
                    ddlDomains.DataTextField = "Domain";
                    ddlDomains.DataValueField = "DomainName";
                    ddlDomains.DataBind();
                    if (dtdomains.Rows.Count > 0)
                    {
                        ddlDomains.SelectedValue = "uspdhubcom";
                        hdnDomain.Value = ddlDomains.SelectedItem.Text;
                    }
                    txtPromocode.Text = "";
                    txtPromocode.Text = hdnPromo.Value = objAdminBLL.GenerateNewPromocode();//GetUniquePromocode();
                    txtPromocode.Enabled = false;
                    BindProducts();
                }
                else
                {
                    BindPostBackPrice();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindPostBackPrice()
        {
            try
            {
                if (txtProdDiscount.Text == "")
                    txtProdDiscount.Text = "0.00";
                txtProdAmount.Text = Convert.ToString(Convert.ToDecimal(txtProdPrice.Text) - Convert.ToDecimal(txtProdDiscount.Text)).ToString();
                if (txtSetupDiscount.Text != "")
                    txtSetupAmount.Text = Convert.ToString(Convert.ToDecimal(txtSetupPrice.Text) - Convert.ToDecimal(txtSetupDiscount.Text)).ToString();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "BindPostBackPrice", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindProducts()
        {
            try
            {
                dtProducts = agencyobj.GetProductsByDomain(ddlDomains.SelectedValue);
                ddlProducts.DataSource = dtProducts;
                ddlProducts.DataTextField = "ProductName";
                ddlProducts.DataValueField = "ProductId";
                ddlProducts.DataBind();
                Session["PromoProducts"] = dtProducts;
                BindProductsPrice();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "BindProducts", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindProductsPrice()
        {
            try
            {
                if (Session["PromoProducts"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                dtProducts = (DataTable)Session["PromoProducts"];
                string filterQuery = string.Empty;
                if (ddlProducts.SelectedValue != string.Empty)
                {
                    filterQuery = "ProductId=" + Convert.ToInt32(ddlProducts.SelectedValue);
                    DataRow[] drProduct = dtProducts.Select(filterQuery);
                    txtProdPrice.Text = txtProdAmount.Text = drProduct[0]["ProductPrice"].ToString();
                    txtProdDiscount.Text = "0.00";
                    pnlSetupFee.Visible = false;
                    if (drProduct[0]["Type"].ToString().ToLower() == "branded")
                    {
                        pnlSetupFee.Visible = true;
                        filterQuery = "Type='Setup'";
                        DataRow[] drSetup = dtProducts.Select(filterQuery);
                        if (drSetup != null && drSetup.Length > 0)
                            txtSetupPrice.Text = txtSetupAmount.Text = drSetup[0]["ProductPrice"].ToString();
                        else
                            txtSetupPrice.Text = txtSetupAmount.Text = "0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "BindProductsPrice", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ddlDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProducts();
        }
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProductsPrice();
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Expiry date should be equal or later than current date.
                objInBuiltData.ErrorHandling("LOG", "GeneratePromocode.aspx.cs", "lnkSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                lblMsg.Text = "";
                bool isDollarAmount = true;
                bool isProduct = true;
                decimal productPrice = Convert.ToDecimal(txtProdPrice.Text);
                if (txtProdDiscount.Text == "")
                    txtProdDiscount.Text = "0.00";
                //decimal productAmtCharged = Convert.ToDecimal(txtProdPrice.Text) - Convert.ToDecimal(txtProdDiscount.Text);
                decimal productAmtCharged = Convert.ToDecimal(txtDiscount.Text);
                decimal? setupFee = null;
                decimal? setupFeeCharged = null;
                bool isLifeTime = false;
                string initialFirst = txtInitailFirst.Text.Trim();
                string initialLast = txtInitailLast.Text.Trim();
                bool isAutoGenerated = false;
                bool isSingle = true;
                if (RBMultiple.Checked)
                    isSingle = false;
                if (RBAutoGenerate.Checked)
                    isAutoGenerated = true;
                if (rbLifeTimeYes.Checked)
                    isLifeTime = true;
                if (pnlSetupFee.Visible == false)
                {
                    isProduct = false;
                }
                else
                {
                    setupFee = Convert.ToDecimal(txtSetupPrice.Text);
                    if (txtSetupDiscount.Text == "")
                        txtSetupDiscount.Text = "0.00";
                    //setupFeeCharged = Convert.ToDecimal(txtSetupPrice.Text) - Convert.ToDecimal(txtSetupDiscount.Text);
                    setupFeeCharged = Convert.ToDecimal(txtDiscount.Text);
                }
                int? duration = null;
                int AllowedCount = 1;
                if (RBMultiple.Checked)
                {
                    AllowedCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("PromocodeMultipleCount"));
                }
                int validFor = 2014;
                string promocodeDescription = txtPromoDes.Text;
                DateTime promocodeExDate = Convert.ToDateTime(txtExpiryDate.Text + " 11:59:00 PM");
                string domainName = ddlDomains.SelectedItem.Text;
                if (promocodeExDate < DateTime.Now)
                {
                    lblMsg.Text = "<span style='color:red;'>Expiration date should be equal or later than current date.</span>";
                }
                else
                {
                    string promoCode = txtPromocode.Text.Trim();
                    int productId = ddlProducts.SelectedValue != "" ? Convert.ToInt32(ddlProducts.SelectedValue) : 0;
                    string id = objAdminBLL.InsertPromocode(domainName, isSingle, AllowedCount, isAutoGenerated, promoCode, productId, productPrice, productAmtCharged, setupFee, setupFeeCharged, isLifeTime, initialFirst, initialLast, promocodeExDate, promocodeDescription, validFor, AdminUserID,
                        duration, isProduct, isDollarAmount);

                    if (Convert.ToInt32(id) > 0)
                    {
                        Session["PCSMsg"] = "<span style='color:green;'>Promocode has been saved successfully.</span>";
                        string urlinfo = Page.ResolveClientUrl("~/Admin/ManagePromocodes.aspx");
                        Response.Redirect(urlinfo);
                    }
                    else
                        lblMsg.Text = "<span style='color:red;'>Sorry, you already have a promocode with this name; please enter another name.</span>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "lnkSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/ManagePromocodes.aspx");
            Response.Redirect(urlinfo);
        }
        private void PromocodeExportToExcel()
        {
            //try
            //{
            //Log
            try
            {
                objInBuiltData.ErrorHandling("LOG", "GeneratePromocode.aspx.cs", "PromocodeExportToExcel()", string.Empty, string.Empty, string.Empty, string.Empty);
                string ExcelFileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond;

                string fileName = "attachment; filename=" + ExcelFileName + ".xls";

                grdPromocodes.HeaderRow.Font.Bold = true;
                grdPromocodes.HeaderRow.ForeColor = System.Drawing.Color.White;
                grdPromocodes.HeaderRow.BackColor = System.Drawing.Color.FromName("#657383");
                Response.Clear();
                Response.AddHeader("content-disposition", fileName);
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);

                grdPromocodes.RenderControl(htextw);
                Response.Flush();
                Response.Write(stw.ToString());
                Response.End();

                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                //Response.Flush();
                //}
                //catch (Exception ex)
                //{
                //    //Error 
                //    objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "PromocodeExportToExcel()", ex.Message,
                //    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                //}
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "GeneratePromocode.aspx.cs", "PromocodeExportToExcel", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //return;
        }
        protected void RBAutoGenerate_CheckedChanged(object sender, EventArgs e)
        {
            txtPromocode.Text = "";
            txtPromocode.Enabled = false;
            txtPromocode.Text = hdnPromo.Value;
        }
        protected void RBCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtPromocode.Text = "";
            txtPromocode.Enabled = true;
        }
    }
}