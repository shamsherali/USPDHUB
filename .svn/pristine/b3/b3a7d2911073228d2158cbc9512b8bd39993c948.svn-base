using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Text;
using Winnovative.PdfCreator;
using Winnovative.HtmlToPdfClient;

public partial class Business_MyAccount_ManageInvoices : BaseWeb
{
    public static int UserID;
    DataTable dtSubscriptions = new DataTable();
    public string NoofCitiesSelected = string.Empty;
    public string NoofIndustrySelected = string.Empty;
    public string RootPath = "";
    public string DomainName = "";
    BusinessBLL objBus = new BusinessBLL();
    MServiceBLL objMServiceBLL = new MServiceBLL();
    CommonBLL objCommon = new CommonBLL();
    static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            Response.Redirect(urlinfo);
        }
        else
            UserID = Convert.ToInt32(Session["userid"]);
        // *** Get Domain Name *** //
        DomainName = Session["VerticalDomain"].ToString();
        RootPath = Session["RootPath"].ToString();
        if (!IsPostBack)
        {
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                string val = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.BillingHistory.ToString());
                if (val != "P")
                    Response.Redirect("Default.aspx");
            }
            dtSubscriptions = objBus.GetInvoiceDetails(UserID);

            if (dtSubscriptions.Rows.Count > 0)
            {
                DgInvoice.DataSource = dtSubscriptions;
                DgInvoice.DataBind();
            }
            else
            {
                lbl1.Text = "There are no billing receipts at this time.";
            }
        }
    }
    protected void lkbt1_Click(object sender, EventArgs e)
    {

        LinkButton lb = sender as LinkButton;
        DataTable dtInvoiceOrderDetails = new DataTable();
        dtInvoiceOrderDetails = objBus.GetOrderIDInvoice(int.Parse(lb.CommandArgument));
        DataTable dtUserDetails = new DataTable();
        dtUserDetails = objBus.GetUserDetailsByUserID(UserID);
        DataTable dtOrderDetails = new DataTable();
        dtOrderDetails = objBus.GetOrderDetailsByOrderID(int.Parse(lb.CommandArgument));
        decimal paidAmount = 0.00M;
        if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["PaidAmount"].ToString()))
            paidAmount = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["PaidAmount"].ToString());
        string invoiceID = string.Empty;
        DataTable dtprofileName = new DataTable();
        dtprofileName = objBus.GetProfileDetailsByProfileID(Convert.ToInt32(Session["ProfileID"]));
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
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
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
# if fixme
            strhtml.Append("<html><head>");
            strhtml.Append("<link href=" + Server.MapPath("~").ToString() + "\\css\\wowzzy_general.css rel='stylesheet' type='text/css' />");
            strhtml.Append("</head><body >");
            string logo = Server.MapPath("~") + "/Images/VerticalLogos/" + DomainName + "logo.png";
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' class='inputgrid'>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strhtml.Append("<tr><td><img src='" + logo + "'/></td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' bgcolor='#F0F7EC'>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
            strhtml.Append("<tr bgcolor='#3B86D4'><td><b>" + DomainName + ".com Invoice ID: " + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + "</b></td><td align='right'><b>Profile reference No: " + dtInvoiceOrderDetails.Rows[0]["Profile_ID"].ToString() + "</b></td></tr>");
            if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"].ToString()))
            {
                strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td align='right'><b>Purchase Order No: " + dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"].ToString() + "</b></td></tr>");
            }
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            if (billinginfo == "")
                strhtml.Append("<tr><td align='top'>" + "Billing Information:" + "<BR><b>" + profileBusinessName + "</b><BR>" + dtUserDetails.Rows[0]["firstname"].ToString() + "&nbsp;" + dtUserDetails.Rows[0]["lastname"].ToString() + "<BR>" + dtUserDetails.Rows[0]["User_address1"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_city"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_state"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_country"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_zipcode"].ToString() + "</td></tr>");
            else
                strhtml.Append("<tr><td align='top'>" + "Billing Information:" + "<BR><b>" + profileBusinessName + "</b><BR>" + billinginfo + "</td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("<tr bgcolor='#F0F7EC'><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
            strhtml.Append("<colgroup><col width='180px'/><col width='100px'/><col width='*'/><col width='120'/><col width='100'/></colgroup>");
            strhtml.Append("<tr bgcolor='#3B86D4'>" + "<td>Description</td>" + "<td style='width:100px;'>Invoice Date</td><td>Subscription Amount</td>" + "<td>Discount</td>" + "<td>Billable Amount</td></tr>");
            for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
            {
                strhtml.Append("<tr bgcolor='#F0F7EC'>" + "<td>" + dtOrderDetails.Rows[i]["Email_Description"].ToString() + "</td>" + "<td>" + dtOrderDetails.Rows[i]["Created_Date"].ToString() + "</td><td>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td>" + "<td>" + dtOrderDetails.Rows[i]["Discount_Amount"].ToString() + "</td><td>" + dtOrderDetails.Rows[i]["Billable_Amount"].ToString() + "</td></tr>");
                discAmt = discAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Discount_Amount"].ToString());
                totalAmount = totalAmount + Convert.ToDecimal(dtOrderDetails.Rows[i]["Total_Amount"].ToString());
                totalBalCalAmt = totalBalCalAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Billable_Amount"].ToString());
            }
            strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td></td><td>" + totalAmount + "</td><td>" + discAmt + "</td><td>" + totalBalCalAmt + "</td></tr>");
            decimal dueAmt = 0.00M;
            if (dueAmt > 0)
            {
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>Paid Amount</td>" + "<td>" + "&nbsp;$" + paidAmount + "</td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>Balance Due</td>" + "<td>" + "&nbsp;$" + dueAmt + "</td></tr>");
            }
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("</td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</table>");
            strhtml.Append("NOTE: If you have any questions regarding this invoice, please email support@" + DomainName + ".com");
            strhtml.Append("</body>");
            strhtml.Append("</html>");

#endif
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

            string RootPath = objMServiceBLL.GetConfigSettings(Session["ProfileID"].ToString(), "Paths", "RootPath");

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
            invoice_htmlText = invoice_htmlText.Replace("#CCDetails#", payInfo);
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
                // Check  Process Invoice Format -- Cheque
                if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "check" || Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "cheque" || Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Card_Type"]).ToLower() == "paypal")
                {
                    orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Email_Description"].ToString() + "</td>";
                    if (ordersCount == 0)
                        orderDetailsHTML = orderDetailsHTML + "<td style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'><table width='100%'><tr><td align='left'>$</td><td align='right'>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr></table></td></tr>";
                    else
                        orderDetailsHTML = orderDetailsHTML + "<td align='right' style='border-left: 1px solid black;  border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr>";
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




            /*  Old Logic
            //Convert into the PDF ...


            //set the license key
            //issue 264, 266
            LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

            //create a PDF document
            Document document = new Document();

            //optional settings for the PDF document like margins, compression level,
            //security options, viewer preferences, document information, etc
            document.CompressionLevel = CompressionLevel.NormalCompression;
            document.Margins = new Margins(10, 10, 0, 0);
            document.Security.CanPrint = true;
            document.Security.UserPassword = "";
            document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
            document.ViewerPreferences.HideToolbar = false;


            //Add a first page to the document. The next pages will inherit the settings from this page 
            PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

            // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

            //PdfPage page = document.Pages.AddNewPage();

            // add a font to the document that can be used for the texts elements 

            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

            // the result of adding an element to a PDF page

            AddElementResult addResult;

            // Get the specified location and size of the rendered content

            // A negative value for width and height means to auto determine

            // The auto determined width is the available width in the PDF page

            // and the auto determined height is the height necessary to render all the content

            float xLocation = 5;

            float yLocation = 5;

            float width = -1;

            float height = -1;

            // convert HTML to PDF

            HtmlToPdfElement htmlToPdfElement;

            // convert a URL to PDF

            string urlToConvert = hmtlfileurl;

            //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

            htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

            // add theHTML to PDF converter element to page
            addResult = page.AddElement(htmlToPdfElement);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            document.Save(Response, false, pdfilenameval);
            */

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
#if fixme
    protected void lkbt123_Click(object sender, EventArgs e)
    {
        LinkButton lb = sender as LinkButton;
        DataTable dtInvoiceOrderDetails = new DataTable();
        dtInvoiceOrderDetails = objBus.GetOrderIDInvoice(int.Parse(lb.CommandArgument));
        DataTable dtUserDetails = new DataTable();
        dtUserDetails = objBus.GetUserDetailsByUserID(UserID);
        string invoiceID = string.Empty;
        DataTable dtprofileName = new DataTable();
        dtprofileName = objBus.GetProfileDetailsByProfileID(Convert.ToInt32(Session["ProfileID"]));
        string profileBusinessName = string.Empty;
        if (dtprofileName.Rows.Count > 0)
        {
            profileBusinessName = dtprofileName.Rows[0]["Profile_Name"].ToString();
        }
        StringBuilder strhtml = new StringBuilder();
        if (dtInvoiceOrderDetails.Rows.Count > 0)
        {
            string subStartDate = string.Empty;
            string subEndDate = string.Empty;
            decimal discAmt = 0.00M;
            decimal totalAmount = 0.00M;
            string tools = string.Empty;
            decimal totalBalCalAmt = 0.00M;
            if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Subscription_EndDate"].ToString()))
            {
                subEndDate = Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Subscription_EndDate"]).AddDays(-1).ToShortDateString();
            }
            subStartDate = Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).ToShortDateString();
            tools = dtInvoiceOrderDetails.Rows[0]["Subscription_Package"].ToString();
            totalAmount = totalBalCalAmt = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Total_Amount"].ToString());

            if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Discount_Amount"].ToString()))
                discAmt = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Discount_Amount"].ToString());
            string subtype = string.Empty;
            // *** Fix For IRH-63 05-02-2013 *** //
            subtype = "Subscription for " + tools;
            if (tools.ToLower().Contains("branded"))
                subtype = "Annual Subscription for Branded App";
            else if (!string.IsNullOrEmpty(dtprofileName.Rows[0]["Parent_ProfileID"].ToString()))
                subtype = "Annual Subscription for Sub-App";
            strhtml.Append("<html><head>");
            strhtml.Append("<link href=" + Server.MapPath("~").ToString() + "\\css\\wowzzy_general.css rel='stylesheet' type='text/css' />");
            strhtml.Append("</head><body >");
            string logo = Server.MapPath("~") + "/Images/VerticalLogos/" + DomainName + "logo.png";
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' class='inputgrid'>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strhtml.Append("<tr><td><img src='" + logo + "'/></td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' bgcolor='#F0F7EC'>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
            strhtml.Append("<tr bgcolor='#3B86D4'><td><b>" + DomainName + ".com Invoice ID: " + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + "</b></td><td align='right'><b>Profile reference No: " + dtInvoiceOrderDetails.Rows[0]["Profile_ID"].ToString() + "</b></td></tr>");
            if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"].ToString()))
            {
                strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td align='right'><b>Purchase Order No: " + dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"].ToString() + "</b></td></tr>");
            }
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("<tr><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strhtml.Append("<tr><td align='top'>" + "To:" + "<BR><b>" + profileBusinessName + "</b><BR>" + dtUserDetails.Rows[0]["firstname"].ToString() + "&nbsp;" + dtUserDetails.Rows[0]["lastname"].ToString() + "<BR>" + dtUserDetails.Rows[0]["User_address1"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_city"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_state"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_country"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_zipcode"].ToString() + "</td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("<tr bgcolor='#F0F7EC'><td>");
            strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
            strhtml.Append("<colgroup><col width='180px'/><col width='100px'/><col width='*'/><col width='120'/><col width='100'/></colgroup>");
            strhtml.Append("<tr bgcolor='#3B86D4'>" + "<td>Description</td>" + "<td style='width:100px;'>Invoice Date</td><td>Subscription Period</td>" + "<td align='right'></td>" + "<td>Amount</td></tr>");
            strhtml.Append("<tr bgcolor='#F0F7EC'>" + "<td>" + subtype + "</td>" + "<td>" + subStartDate + "</td><td>" + subStartDate + " - " + subEndDate + "</td>" + "<td></td><td align='right'>" + "&nbsp;$" + totalAmount + "</td></tr>");
            string invoiceTotal = dtInvoiceOrderDetails.Rows[0]["OrderBillable_Amt"].ToString();
            if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString()))
            {
                totalBalCalAmt += Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString());
                invoiceTotal = (Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OrderBillable_Amt"].ToString()) + Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString())).ToString();
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>" + "One time setup fee" + "</td>" + "<td bgcolor='#F0F7EC' align='right'>" + "$" + dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString() + "</td></tr>");
            }
            if (discAmt > 0)
            {
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>" + "Discount Amount" + "</td>" + "<td bgcolor='#F0F7EC' align='right'>" + "$" + discAmt + "</td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td><td bgcolor='#F0F7EC' align='right'>" + "-------------" + "</td></tr>");
            }
            strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td></td><td></td><td>Billing Amount</td>" + "<td align='right'>" + "&nbsp;$" + invoiceTotal + "</td></tr>");
            decimal dueAmt = 0.00M;
            dueAmt = totalBalCalAmt - (Convert.ToDecimal(invoiceTotal) + discAmt);
            strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>Balance Due</td>" + "<td align='right'>" + "&nbsp;$" + dueAmt + "</td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</td></tr>");
            strhtml.Append("</td></tr>");
            strhtml.Append("</table>");
            strhtml.Append("</table>");
            strhtml.Append("NOTE: If you have any questions regarding this invoice, please email support@" + DomainName + ".com");
            strhtml.Append("</body>");
            strhtml.Append("</html>");


            string filepath = Server.MapPath("~");

            string filename = filepath + "/temp/" + DomainName + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

            string hmtlfileurl = RootPath + "/temp/" + DomainName + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

            string pdffilename = filepath + "/temp/" + DomainName + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

            string pdfilenameval = DomainName + "Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

            string pdffileurl = RootPath + "/temp/" + DomainName + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";
            invoiceID = dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString();
            //StreamWriter textwriter = new StreamWriter(filename);
            //textwriter.Write(strhtml);
            //textwriter.Close();

            //Convert into the PDF ...

            //set the license key
            //issue 264, 266
            LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

            //create a PDF document
            Document document = new Document();

            //optional settings for the PDF document like margins, compression level,
            //security options, viewer preferences, document information, etc
            document.CompressionLevel = CompressionLevel.NormalCompression;
            document.Margins = new Margins(10, 10, 0, 0);
            document.Security.CanPrint = true;
            document.Security.UserPassword = "";
            document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
            document.ViewerPreferences.HideToolbar = false;


            //Add a first page to the document. The next pages will inherit the settings from this page 
            PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

            // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

            //PdfPage page = document.Pages.AddNewPage();

            // add a font to the document that can be used for the texts elements 

            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

            // the result of adding an element to a PDF page

            AddElementResult addResult;

            // Get the specified location and size of the rendered content

            // A negative value for width and height means to auto determine

            // The auto determined width is the available width in the PDF page

            // and the auto determined height is the height necessary to render all the content

            float xLocation = 5;

            float yLocation = 5;

            float width = -1;

            float height = -1;

            // convert HTML to PDF

            HtmlToPdfElement htmlToPdfElement;

            // convert a URL to PDF

            string urlToConvert = hmtlfileurl;

            //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

            htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

            // add theHTML to PDF converter element to page
            addResult = page.AddElement(htmlToPdfElement);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            document.Save(Response, false, pdfilenameval);

            // New Logic
            string path3 = filepath + "/temp/" + DomainName + "_Invoice_" + invoiceID + ".pdf";
            string htmlpath3 = filepath + "/temp/" + DomainName + "Invoice_" + invoiceID + ".html";
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
            // End of the Logic
        }
    }
#endif
    protected void DgInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = e.Row.FindControl("lkbt1") as LinkButton;
            lb.CommandArgument = dtSubscriptions.Rows[e.Row.RowIndex]["SubscriptionType_ID"].ToString();
        }
    }
    // *** End of new pricing Plan *** //
    public string Packages(int value)
    {
        string pkgName = "";
        switch (value)
        {
            case 1:
                pkgName = "Basic";
                break;
            case 2:
                pkgName = "Plus";
                break;
            case 3:
                pkgName = "Pro";
                break;
            case 4:
                pkgName = "Premium";
                break;
            case 5:
                pkgName = "Premium Plus";
                break;
        }
        return pkgName;
    }
}
