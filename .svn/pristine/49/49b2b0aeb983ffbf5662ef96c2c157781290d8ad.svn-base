using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Data;
using System.Configuration;
using Winnovative.HtmlToPdfClient;

namespace USPDHUB.Admin
{
    public partial class BillingHistory : System.Web.UI.Page
    {
        BusinessBLL business = new BusinessBLL();
        CommonBLL common = new CommonBLL();
        MServiceBLL objMServiceBLL = new MServiceBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        string DomainName = "";
        int UserID;
        int profileID;
       // public string RootPath = "";

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Request.QueryString["pid"] != null)
            {
                profileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["pid"].ToString()));
                DataTable dtprofile = business.GetProfileDetailsByProfileID(profileID);
                if (dtprofile != null && dtprofile.Rows.Count > 0)
                {
                    UserID = Convert.ToInt32(dtprofile.Rows[0]["User_ID"]);
                    DomainName = dtprofile.Rows[0]["Vertical_Name"].ToString();
                    lblUid.Text = UserID.ToString();
                    lblPname.Text = dtprofile.Rows[0]["Profile_name"].ToString();
                }
            }
            //if (Session["userid"] == null || Session["VerticalDomain"] == null)
            //{
            //    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            //    Response.Redirect(urlinfo);
            //}
            //else
            //    UserID = Convert.ToInt32(Session["userid"]);
            //// *** Get Domain Name *** //
            //DomainName = Session["VerticalDomain"].ToString();
            //RootPath = Session["RootPath"].ToString();
            if (!IsPostBack)
            {
                //if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                //{
                //    string val = common.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.BillingHistory.ToString());
                //    if (val != "P")
                //        Response.Redirect("Default.aspx");
                //}                
                
                //int profileID = 10065;
                DataTable dtInvoice = new DataTable();
                dtInvoice = business.GetInvoiceDetail_New(profileID);
                if (dtInvoice != null && dtInvoice.Rows.Count > 0)
                {
                    rptrInvoiceDetails.DataSource = dtInvoice;
                    rptrInvoiceDetails.DataBind();
                }
            }

        }

        protected void rptrInvoice_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptrOrders = e.Item.FindControl("rptrOrders") as Repeater;
                int subscriptionID = int.Parse((e.Item.FindControl("hdnSubscriptionID") as HiddenField).Value);
                DataTable dtInvoice = new DataTable();
                dtInvoice = business.GetOrderDetailsByOrderID(subscriptionID);
                if (dtInvoice != null && dtInvoice.Rows.Count > 0)
                {
                    rptrOrders.DataSource = dtInvoice;
                    rptrOrders.DataBind();
                }
            }
        }




        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            LinkButton linkdownload = sender as LinkButton;
            int subscriptionID = Convert.ToInt32(linkdownload.CommandArgument);
            DataTable dtInvoiceOrderDetails = new DataTable();
            dtInvoiceOrderDetails = business.GetInvoiceDetailsBySubTypeID(subscriptionID);
            //DataTable dtUserDetails = new DataTable();
            //dtUserDetails = objBus.GetUserDetailsByUserID(UserID);
            DataTable dtOrderDetails = new DataTable();
            dtOrderDetails = business.GetOrderDetailsByOrderID(subscriptionID);
            decimal paidAmount = 0.00M;
            if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["PaidAmount"].ToString()))
                paidAmount = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["PaidAmount"].ToString());
            string invoiceID = string.Empty;
            DataTable dtprofileName = new DataTable();
            dtprofileName = business.GetProfileDetailsByProfileID(profileID);
            string profileBusinessName = string.Empty;
            if (dtprofileName.Rows.Count > 0)
            {
                profileBusinessName = dtprofileName.Rows[0]["Profile_Name"].ToString();
            }
            string strhtml = "";
            if (dtInvoiceOrderDetails.Rows.Count > 0)
            {
                decimal discAmt = 0.00M;
                decimal totalAmount = 0.00M;
                decimal totalBalCalAmt = 0.00M;
                string billinginfo = "";
                string FromEmailsupport = "";
                DataTable dtConfigsemails = common.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString()))
                {
                    if (profileBusinessName != "")
                        billinginfo = profileBusinessName + "<br/>";
                    billinginfo = billinginfo + dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString();
                    billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_LastName"].ToString();
                    billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Address1"].ToString();
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Address2"].ToString()))
                        billinginfo = billinginfo + ", " + dtInvoiceOrderDetails.Rows[0]["Billing_Address2"].ToString();
                    billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_City"].ToString();
                    billinginfo = billinginfo + ", " + dtInvoiceOrderDetails.Rows[0]["Billing_State"].ToString();
                    billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_Zipcode"].ToString();
                    billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_Country"].ToString();
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Phone"].ToString()))
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Phone"].ToString();
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString()))
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString();
                }

                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";

                StreamReader re = null;
                // Check  Process Invoice Format -- Cheque
                if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "check" || Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "cheque")
                {
                    re = File.OpenText(strfilepath + "InoviceFormat.txt");
                }
                else
                {
                    re = File.OpenText(strfilepath + "SalesReceipt.txt");
                }

                string invoice_htmlText = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    invoice_htmlText = invoice_htmlText + content;
                }

                string RootPath = objMServiceBLL.GetConfigSettings(profileID.ToString(), "Paths", "RootPath");

                invoice_htmlText = invoice_htmlText.Replace("#Logo#", RootPath + "/Images/Dashboard/logictree_logo.png");
                invoice_htmlText = invoice_htmlText.Replace("#BillingAddress#", billinginfo);
                string payInfo = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Number"])))
                {
                    payInfo = EncryptDecrypt.DESDecrypt(Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Number"]));
                    if (String.IsNullOrEmpty(payInfo.Trim()))
                    {
                        payInfo = Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Number"]);
                        if (payInfo.Length > 4)
                            payInfo = payInfo.Substring(payInfo.Length - 4);
                    }
                }


                /*** Paypal Payments ***/
                string ccInfo = "card";
                if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == PaymentModes.PayPal || Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == PaymentModes.BillMe ||
                    Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == string.Empty)
                {
                    ccInfo = Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]) == PaymentModes.PayPal ? "paypal" : "P.O.";
                }
                else
                {
                    /*** Credit card ***/
                    ccInfo = "credit card ending XXXX" + payInfo; ;
                }

                invoice_htmlText = invoice_htmlText.Replace("#CCDetails#", "Paid by " + ccInfo);
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceNumber#", dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString());
                invoice_htmlText = invoice_htmlText.Replace("#PONumber#", Convert.ToString(dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"]));

                string dueDate = "";
                if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Created_Date"]) == string.Empty)
                {
                    invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", "&nbsp;");
                }
                else
                {
                    invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).ToString("MMMM dd, yyyy"));
                    dueDate = "Net 30 " + Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).AddDays(30).ToShortDateString();
                }
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceNumber#", dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString());
                invoice_htmlText = invoice_htmlText.Replace("#PONumber#", Convert.ToString(dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"]));

                int ordersCount = 0;
                string orderDetailsHTML = "";
                for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                {
                    string includeText = "";
                    if (Convert.ToString(dtOrderDetails.Rows[i]["ParentOrderDetailsID"]) != string.Empty)
                    { includeText = "(Included)"; }

                    // Check  Process Invoice Format -- Cheque
                    if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "check" || Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "cheque")
                    {
                        orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 0px solid black; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Email_Description"].ToString() + includeText + "</td>";
                        if (ordersCount == 0)
                            orderDetailsHTML = orderDetailsHTML + "<td style='border-left: 0px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'><table width='100%'><tr><td align='left'>$</td><td align='right'>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr></table></td></tr>";
                        else
                            orderDetailsHTML = orderDetailsHTML + "<td align='right' style='border-left: 0px solid black;  border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr>";
                        ordersCount += 1;
                        if (!string.IsNullOrEmpty(dtOrderDetails.Rows[i]["Discount_Code"].ToString()))
                            orderDetailsHTML = orderDetailsHTML + "<tr>" + "<td style='border-left: 1px solid black; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Discount_Code"].ToString() + " discount</td>" + "<td align='right' style='border-left: 1px solid black;  border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>(" + dtOrderDetails.Rows[i]["Discount_Amount"].ToString() + ")</td></tr>";
                    }
                    else
                    {
                        orderDetailsHTML = orderDetailsHTML + "<tr><td style='font-weight: normal; text-align: right;'>" + dtOrderDetails.Rows[i]["Email_Description"].ToString() + ":</td>";
                        orderDetailsHTML = orderDetailsHTML + "<td style='font-weight: normal; text-align: right;'>$" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr>";
                        if (!string.IsNullOrEmpty(dtOrderDetails.Rows[i]["Discount_Code"].ToString()))
                            orderDetailsHTML = orderDetailsHTML + "<tr><td style='font-weight: normal; text-align: right;'>" + dtOrderDetails.Rows[i]["Discount_Code"].ToString() + " Discount:</td><td style='font-weight: normal; text-align: right;'>($" + dtOrderDetails.Rows[i]["Discount_Amount"].ToString() + ")</td></tr>";
                    }

                    discAmt = discAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Discount_Amount"].ToString());
                    totalAmount = totalAmount + Convert.ToDecimal(dtOrderDetails.Rows[i]["Total_Amount"].ToString());
                    totalBalCalAmt = totalBalCalAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Billable_Amount"].ToString());
                }
                decimal dueAmt = totalBalCalAmt - paidAmount;
                if (dueAmt < 0)
                    dueAmt = 0;
                if (dueAmt > 0)
                {
                    invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", Convert.ToString(dtInvoiceOrderDetails.Rows[0]["DueDateTitle"]));
                    invoice_htmlText = invoice_htmlText.Replace("#DueDate#", dueDate);
                }
                else
                {
                    invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", "");
                    invoice_htmlText = invoice_htmlText.Replace("#DueDate#", "");
                }
                invoice_htmlText = invoice_htmlText.Replace("#OrderDetailsRows#", orderDetailsHTML);
                invoice_htmlText = invoice_htmlText.Replace("#TotalBill#", totalBalCalAmt.ToString()); // *** totalAmount.ToString() ***//
                invoice_htmlText = invoice_htmlText.Replace("#PaidBill#", paidAmount.ToString());
                invoice_htmlText = invoice_htmlText.Replace("#BalanceBill#", dueAmt.ToString());
                invoice_htmlText = invoice_htmlText.Replace("#CustomNotes#", "&nbsp;");
                invoice_htmlText = invoice_htmlText.Replace("##SupportEmail##", FromEmailsupport);
                re.Close();
                re.Dispose();
                // final HTML Invoice Format
                strhtml = invoice_htmlText;
                string filepath = Server.MapPath("~");

                string filename = filepath + "/temp/" + DomainName + "_Receipt_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

                string hmtlfileurl = RootPath + "/temp/" + DomainName + "_Receipt_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

                string pdffilename = filepath + "/temp/" + DomainName + "_Receipt_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

                string pdfilenameval = DomainName + "_Receipt_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

                string pdffileurl = RootPath + "/temp/" + DomainName + "_Receipt_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";
                invoiceID = dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString();
                //StreamWriter textwriter = new StreamWriter(filename);
                //textwriter.Write(strhtml);
                //textwriter.Close();


                // New Logic
                string path3 = filepath + "/temp/" + DomainName + "_Receipt_" + invoiceID + ".pdf";
                string htmlpath3 = filepath + "/temp/" + DomainName + "_Receipt_" + invoiceID + ".html";

                try
                {
                    // New Logic azure htmml to pdf

                    // Get the server IP and port
                    String serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                    uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                    // Create a HTML to PDF converter object with default settings
                    HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);
                    htmlToPdfConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");
                    htmlToPdfConverter.HtmlViewerWidth = 650;
                    //htmlToImageConverter.HtmlViewerHeight = 200;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = Winnovative.HtmlToPdfClient.PdfPageSize.A4;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                    htmlToPdfConverter.PdfDocumentOptions.LeftMargin = 10;
                    htmlToPdfConverter.PdfDocumentOptions.TopMargin = 10;

                    htmlToPdfConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                    htmlToPdfConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));

                    // The buffer to receive the generated PDF document
                    byte[] outPdfBuffer = null;
                    string baseUrl = "";

                    // Convert a HTML string with a base URL to a PDF document in a memory buffer
                    outPdfBuffer = htmlToPdfConverter.ConvertHtml(strhtml.ToString(), baseUrl);
                    System.IO.File.WriteAllBytes(path3, outPdfBuffer);
                }
                catch (Exception ex)
                {
                    //Error 
                    objInBuiltData.ErrorHandling("ERROR", "ManageInvoices.aspx.cs", "lkbt1_Click", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }

                if (File.Exists(htmlpath3))
                    File.Delete(htmlpath3);

                bool forceDownload = true;
                string name = Path.GetFileName(path3);
                string ext = Path.GetExtension(path3);
                string type = "";
                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;
                    }
                }
                if (forceDownload)
                {
                    Response.AppendHeader("content-disposition", "attachment; filename=" + name);
                }
                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path3);
                Response.End();
            }
        }
    }
}