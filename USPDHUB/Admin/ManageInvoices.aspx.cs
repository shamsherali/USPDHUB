using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
namespace USPDHUB.Admin
{
    public partial class ManageInvoices : System.Web.UI.Page
    {
        AdminBLL objAdmin = new AdminBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        int ProfileID;
        int UserID;
        DateTime billMeDate=DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillData();
                    hdnManageInvoiceSortCount.Value = "0";
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void fillData()
        {

            DataTable details = new DataTable();
            details = objAdmin.getBillMeProfileDetails();
             grdBillMe.DataSource = details;
            grdBillMe.DataBind();
            Session["ManageInvoice"] = details;
        }

        //Send Invoice
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InvoiceData"] != null)
                {
                    DataTable dtTempInvoice = new DataTable();
                    dtTempInvoice = (DataTable)Session["InvoiceData"];
                    if ((dtTempInvoice.Rows[0]["BestCallTime"]).ToString() == "") {

                        billMeDate = billMeDate.Date;
                    }
                    ProfileID = Convert.ToInt32(dtTempInvoice.Rows[0]["Profile_ID"]);
                    UserID = Convert.ToInt32(dtTempInvoice.Rows[0]["UserID"]);
                    SendInvoice(dtTempInvoice.Rows[0]["BillingEmail"].ToString(), dtTempInvoice.Rows[0]["Location"].ToString(), dtTempInvoice.Rows[0]["Name"].ToString(), dtTempInvoice.Rows[0]["DomainName"].ToString(),
                      dtTempInvoice.Rows[0]["PurchaseOrder_No"].ToString(), billMeDate, dtTempInvoice.Rows[0]["Profile_phone1"].ToString(), Convert.ToInt32(dtTempInvoice.Rows[0]["SubscriptionID"].ToString()));
                    Session["InvoiceData"] = null;
                    MPEPreview.Hide();
                    txtInitial.Text = txtRemark.Text = "";
                    lblmsg.Text = Resources.AdminResource.InvoiceSent;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "ManageInvoice.cs", "btnSubmit_Click", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        //Preview of the Send Invoice
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string DomainName;
                string location = "";
                string strHTML = "";

                LinkButton btn = (LinkButton)sender;
                int SubscriptionID = Convert.ToInt32(btn.CommandArgument);

                DataTable dtSubscriptions = objAdmin.getBillMedetailsbySubID(SubscriptionID);

                if (dtSubscriptions.Rows[0]["Vertical_Name"].ToString().Contains("localhost"))
                {
                    DomainName = dtSubscriptions.Rows[0]["Vertical_Name"].ToString();
                }
                else
                    DomainName = dtSubscriptions.Rows[0]["Vertical_Name"].ToString() + "com";

                strHTML = objAdmin.CreateInvoiceHtml(SubscriptionID, dtSubscriptions.Rows[0]["Vertical_Name"].ToString(), DomainName, dtSubscriptions.Rows[0]["PurchaseOrder_No"].ToString(), Convert.ToDecimal(dtSubscriptions.Rows[0]["Discount_Amount"]), Convert.ToInt32(dtSubscriptions.Rows[0]["ProfileSubTypeID"].ToString()));
                location = objAdmin.CreateInvoiceReport(SubscriptionID, dtSubscriptions.Rows[0]["Vertical_Name"].ToString(), DomainName, strHTML);
                lblInvoice.Text = strHTML;
                DataTable dtTemp = new DataTable();
                dtTemp.Clear();
                dtTemp.Columns.AddRange(new DataColumn[10] { new DataColumn("BillingEmail"), new DataColumn("Location"), new DataColumn("Name"), new DataColumn("DomainName"), new DataColumn("PurchaseOrder_No"), new DataColumn("BestCallTime"), new DataColumn("Profile_phone1"), new DataColumn("SubscriptionID"), new DataColumn("Profile_ID"), new DataColumn("UserID") });
                string contactName = dtSubscriptions.Rows[0]["FirstName"] + (dtSubscriptions.Rows[0]["LastName"].ToString() != "" ? (" " + dtSubscriptions.Rows[0]["LastName"].ToString()) : "");
                dtTemp.Rows.Add(dtSubscriptions.Rows[0]["BillingEmail"].ToString(), location, contactName, DomainName, dtSubscriptions.Rows[0]["PurchaseOrder_No"].ToString(), dtSubscriptions.Rows[0]["BestCallTime"],
                 dtSubscriptions.Rows[0]["Profile_phone1"].ToString(), SubscriptionID, dtSubscriptions.Rows[0]["Profile_ID"], dtSubscriptions.Rows[0]["UserID"]);
                dtTemp.AcceptChanges();
                Session["InvoiceData"] = dtTemp;
                MPEPreview.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CommonBLL.cs", "btnSend_Click", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendInvoice(string username, string attachment, string contactPerson, string DomainName, string PurchaseOrderNo, DateTime BestDateTime, string PhoneNumber, int OrderID)
        {
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                string rootPath = "";
                DataTable dtOrderDetails = new DataTable();
                dtOrderDetails = objBus.GetOrderDetailsByOrderID(OrderID);
                DataTable dtConfigs = objCommonBLL.GetVerticalConfigsByType(DomainName, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                        {
                            rootPath = row[1].ToString();
                            break;
                        }
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommonBLL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailsupport = row[1].ToString();
                            break;
                        }
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "CreateInvoice.txt");
                StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                string msgbody = string.Empty;
                string msgbodyA = string.Empty;
                string content = string.Empty;
                string desclaimer = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    msgbody = msgbody + desclaimer;
                }

                reDeclaimer.Close();
                reDeclaimer.Dispose();

                msgbodyA = msgbody;
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR>";
                }
                re.Close();
                re.Dispose();

                msgbodyA = msgbody;
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#ContactPerson#", contactPerson);
                msgbody = msgbody.Replace("#RootUrl#", rootPath);
                msgbody = msgbody.Replace("#Name#", contactPerson);

                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Invoice Details", msgbody, ccemail, attachment, DomainName);

                re = File.OpenText(strfilepath + "CreateInvoiceAccounts.txt");
                input = string.Empty;
                content = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR>";
                }
                re.Close();
                re.Dispose();
                msgbodyA = msgbodyA.Replace("#msgBody#", content);
                msgbodyA = msgbodyA.Replace("#ContactPerson#", contactPerson);
                msgbodyA = msgbodyA.Replace("#BestCallTime#", BestDateTime.ToShortDateString());
                msgbodyA = msgbodyA.Replace("#PONumber#", PurchaseOrderNo.ToString());
                msgbodyA = msgbodyA.Replace("#PhoneNumber#", PhoneNumber);

                content = string.Empty;
                reDeclaimer = File.OpenText(strfilepath + "IncoiveAccounts.txt");
                string toEmails = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    toEmails = toEmails + desclaimer;
                }
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, toEmails, "Invoice Details", msgbodyA, ccemail, attachment, DomainName);
                AdminBLL objAdminBll = new AdminBLL();
                objAdmin.insertInvoiceSendHistory(ProfileID, UserID, Convert.ToDecimal(dtOrderDetails.Rows[0]["Renewal_Cost"]), txtInitial.Text.Trim(), txtRemark.Text.Trim());
                lblmsg.Text = Resources.AdminResource.InvoiceSent;
                fillData();


            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "ManageInvoice.cs", "SendInvoiceEmail", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }


        }

        protected void grdBillMe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBillMe.PageIndex = e.NewPageIndex;
            fillData();

        }

        protected void grdBillMe_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                int sortDir;
                sortDir = Convert.ToInt32(hdnManageInvoiceSortCount.Value);
                string SortExp = e.SortExpression.ToString();
                DataTable dtmanageInvoiceHistory = (DataTable)Session["ManageInvoice"];
                if (hdnManageInvoiceSorttDir.Value != "")
                {
                    if (hdnManageInvoiceSorttDir.Value != SortExp)
                    {
                        hdnManageInvoiceSorttDir.Value = SortExp;
                        sortDir = 0;
                        hdnManageInvoiceSorttDir.Value = "0";
                    }
                }
                else
                {
                    hdnManageInvoiceSorttDir.Value = SortExp;
                }
                DataView DvManageInvoices = new DataView(dtmanageInvoiceHistory);
                if (sortDir == 0)
                {
                    if (SortExp == "DateSent")
                    {
                        DvManageInvoices.Sort = "SentDate ASC";
                    }
                    hdnManageInvoiceSortCount.Value = "1";
                }
                else
                {
                    if (SortExp == "DateSent")
                    {
                        DvManageInvoices.Sort = "SentDate desc";
                    }
                    hdnManageInvoiceSortCount.Value = "0";
                }
                Session["ManageInvoice"] = DvManageInvoices.ToTable();
                grdBillMe.DataSource = DvManageInvoices;
                grdBillMe.DataBind();

            }
            catch (Exception ex) { }
        }
    }
}